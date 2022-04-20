using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace medicalclinic_back
{
    public class Patient
    {
        private int id;
        private string first_name;
        private string second_name;
        private string pesel;
        private SexEnum sex;
        private string phone_number;
        private string email;
        private DateTime date_of_birth;
        private string date_of_last_appointment;

        public int Id { get => id; set => id = value; }
        public string First_name { get => first_name; set => first_name = value; }
        public string Second_name { get => second_name; set => second_name = value; }
        public string Pesel { get => pesel; set => pesel = value; }
        public SexEnum Sex { get => sex; set => sex = value; }
        public string Phone_number { get => phone_number; set => phone_number = value; }
        public string Email { get => email; set => email = value; }
        public DateTime Date_of_birth { get => date_of_birth; set => date_of_birth = value; }
        public string Date_of_last_appointment { get => date_of_last_appointment; set => date_of_last_appointment = value; }

        public Patient(int id, string first_name, string second_name, string pesel, SexEnum sex, string phone_number, string email, DateTime date_of_birth, string date_of_last_appointment)
        {
            this.id = id;
            this.first_name = first_name;
            this.second_name = second_name;
            this.pesel = pesel;
            this.sex = sex;
            this.phone_number = phone_number;
            this.email = email;
            this.date_of_birth = date_of_birth;
            this.date_of_last_appointment = date_of_last_appointment;
        }

        public static List<Patient> GetPatients(string patient_name, string patient_surname, string patient_pesel, string appointment_date, string sort_column = "p.id", string sort_direction = "ASC")
        {
            Database.openConnection();
            string query;
            string p_name = "'" + patient_name + "%'";
            string p_surname = "'" + patient_surname + "%'";
            string p_pesel = "'" + patient_pesel + "%'";
            if (appointment_date == null)
            {
                query = $"SELECT p.id, p.first_name, p.second_name, p.pesel, p.sex, p.phone_number, p.email, p.date_of_birth, IFNULL((SELECT MAX(v.date) FROM visits v WHERE p.id = v.id_patient), (SELECT 'no appointments')) as date FROM patients p WHERE p.first_name LIKE {p_name} AND p.second_name LIKE {p_surname} AND p.pesel LIKE {p_pesel} ORDER BY {sort_column} {sort_direction}";
            }
            else
            {
                string v_date = "'" + appointment_date + "'";
                query = $"SELECT p.id, p.first_name, p.second_name, p.pesel, p.sex, p.phone_number, p.email, p.date_of_birth, CONVERT((SELECT MAX(v.date) FROM visits v WHERE p.id = v.id_patient), NCHAR) as date FROM patients p WHERE ABS(DATEDIFF({v_date}, (SELECT MAX(v.date) FROM visits v WHERE p.id = v.id_patient))) <= 3 AND p.first_name LIKE {p_name} AND p.second_name LIKE {p_surname} AND p.pesel LIKE {p_pesel} ORDER BY {sort_column} {sort_direction}";
            }

            MySqlDataReader data = Database.dataReader(query);

            List<Patient> patients = new List<Patient>();
            while (data.Read())
            {
                Patient patient = new Patient(data.GetInt32(0), data.GetString(1), data.GetString(2), data.GetString(3), (SexEnum)Enum.Parse(typeof(SexEnum), data.GetString(4)), data.GetString(5), data.GetString(6), data.GetDateTime(7), data.GetString(8));

                patients.Add(patient);
            }

            Database.closeConnection();
            return patients;
        }
        public static void DeletePatient(int Id)
        {
            Database.openConnection();
            string query = $"DELETE FROM patients WHERE @Id = id";
            MySqlCommand command = Database.command(query);
            command.Parameters.AddWithValue("@Id", Id);
            command.ExecuteNonQuery();
            Database.closeConnection();
        }

        public static void AddNewPatient(string first_name, string surname, string pesel, string sex, string phone_number, string email, string date_of_birth)
        {
            Database.openConnection();
            string query = $"INSERT INTO patients (id, first_name, second_name,pesel, sex, date_of_birth, phone_number, email) VALUES (DEFAULT,@FirstName,@Surname,@Pesel,@Sex,@Date,@PhoneNumber,@Email)";


            MySqlCommand command = Database.command(query);

            command.Parameters.AddWithValue("@FirstName", first_name);
            command.Parameters.AddWithValue("@Surname", surname);
            command.Parameters.AddWithValue("@Pesel", pesel);
            command.Parameters.AddWithValue("@Sex", sex);
            command.Parameters.AddWithValue("@PhoneNumber", phone_number);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Date", date_of_birth);

            command.ExecuteNonQuery();
            Database.closeConnection();
        }

        public static bool ValidateEmail(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);

            if (!match.Success)
            {
                return false;
            }

            return true;
        }
        public static bool ValidatePhoneNumber(string phonenumber)
        {
            Regex regex = new Regex(@"^[0-9]{9}$");
            Match match = regex.Match(phonenumber);

            if (!match.Success)
            {
                return false;
            }

            return true;
        }
        public static bool ValidatePesel(string pesel, DateTime birth, string sex)
        {
            string dayOfBirth, monthOfBirth;
            char gender;
            bool result = false;

            int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 }; //wagi poszczegolnych cyfr nr pesel

            if (sex == "Male")
            {
                gender = 'M';
            }
            else
            {
                gender = 'K';
            }



            List<int> peselDigits = new List<int>(); //lista do przechowywania wszystkich cyfr podanego nr pesel
            foreach (char digit in pesel)
            {
                if (char.IsDigit(digit))
                {
                    peselDigits.Add(Convert.ToInt32(digit.ToString()));
                }
                else
                {
                    return result;
                }
            }

            if (peselDigits.Count == 11)
            {
                dayOfBirth = birth.Day.ToString("00");
                monthOfBirth = birth.Month.ToString("00");

                string thirdAndFourthDigit;

                if (birth.Year >= 2000 && birth.Year < 2400) //przypisywanie miesiaca urodzenia, ktory powinien byc w prawidlowym peselu
                {

                    int digitOfHundreds = (birth.Year - 2000) / 100; //pobiera cyfre setek z roku urodzenia >2000
                    int toAddToMonth = 0;
                    switch (digitOfHundreds)
                    {
                        case 0:
                            toAddToMonth = 20;
                            break;
                        case 1:
                            toAddToMonth = 40;
                            break;
                        case 2:
                            toAddToMonth = 60;
                            break;
                        case 3:
                            toAddToMonth = 80;
                            break;

                    }
                    thirdAndFourthDigit = (Convert.ToInt32(monthOfBirth) + toAddToMonth).ToString();

                }
                else
                {
                    thirdAndFourthDigit = monthOfBirth;
                }

                string yearAsString = birth.Year.ToString();
                string firstTwoDigits = yearAsString[2].ToString() + yearAsString[3].ToString(); //pierwsze dwie cyfry, ktore powinny byc w prawidlowym peselu

                string year = peselDigits[0].ToString() + peselDigits[1].ToString(); //rok ktory wynika z podanego peselu
                string month = peselDigits[2].ToString() + peselDigits[3].ToString(); // miesiac ktory wynika z podanego peselu
                string day = peselDigits[4].ToString() + peselDigits[5].ToString(); // dzien urodzenia ktory wynika z podanego peselu

                bool verifyYear = (firstTwoDigits == year);
                bool verifyMonth = (thirdAndFourthDigit == month);
                bool verifyDay = (dayOfBirth == day);
                bool verifyGenderIfMen = (peselDigits[9] % 2 == 1 && gender == 'M');
                bool verifyGenderIfWomen = (peselDigits[9] % 2 == 0 && gender == 'K');

                if (verifyYear && verifyMonth && verifyDay && (verifyGenderIfMen || verifyGenderIfWomen))
                {
                    int checksum = 0;
                    for (int i = 0; i <= weights.Length - 1; i++) //wyliczanie sumy kontrolnej
                    {
                        checksum += peselDigits[i] * weights[i];
                    }
                    checksum %= 10;

                    if (checksum != 0)
                    {
                        checksum = 10 - checksum;
                    }

                    if (checksum.ToString() == peselDigits[10].ToString()) //sprawdzenie czy wpisana cyfra kontrolna jest rowna wyliczonej przez program
                    {
                        result = true;
                    }
                }

            }


            return result;
        }
        public static bool ValidatePeselUnique(string pesel)
        {
            List<Patient> PatientList = GetPatients(null, null, null, null);

            foreach (Patient pat in PatientList)
            {
                if (pat.Pesel == pesel)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
