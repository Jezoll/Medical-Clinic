using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace medicalclinic_back
{
    public  class Calendar_Appointments
    {
        private string date;
        private string name;
        private string surname;
        private string pesel;
        private string sex;
        private DateTime birth;
        private string phone;
        private string email;

        public string Date { get => date; set => date = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Pesel { get => pesel; set => pesel = value; }
        public string Sex { get => sex; set => sex = value; }
        public DateTime Birth { get => birth; set => birth = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }

        public Calendar_Appointments(string date, string name, string surname, string pesel, string sex, DateTime birth, string phone, string email)
        {
            this.date = date;
            this.name = name;
            this.surname = surname;
            this.pesel = pesel;
            this.sex = sex;
            this.birth = birth;
            this.phone = phone;
            this.email = email;
            
        }
        
        //filtrowanie imie met
        public static List<Calendar_Appointments> Filtr_byname(string name)
        {
            string p_name = name + "%";

            Database.openConnection();

            MySqlCommand query = Database.command("SELECT vis.date AS Date, pat.first_name AS Name, pat.second_name AS Surname, pat.pesel AS PESEL, pat.sex as Sex, pat.date_of_birth AS Birth, pat.phone_number AS Phone, pat.email FROM visits vis INNER JOIN patients pat ON vis.id_patient = pat.id where pat.first_name like @name ORDER BY Date ASC"); 
            query.Parameters.AddWithValue("@name", p_name);
            MySqlDataReader data = query.ExecuteReader();
            List<Calendar_Appointments> filters = new List<Calendar_Appointments>();
            while (data.Read())
            {
                Calendar_Appointments type = new Calendar_Appointments(data.GetString(0), data.GetString(1), data.GetString(2), data.GetString(3), data.GetString(4), data.GetDateTime(5), data.GetString(6), data.GetString(7)); 
                filters.Add(type);

            }
            data.Close();

            Database.closeConnection();
            return filters;

            }
        
        //filtrowanie nazwisko
        public static List<Calendar_Appointments> Filtr_bysurname(string surname)
        {
            string p_surname = surname + "%";

            Database.openConnection();

            MySqlCommand query = Database.command("SELECT vis.date AS Date, pat.first_name AS Name, pat.second_name AS Surname, pat.pesel AS PESEL, pat.sex as Sex, pat.date_of_birth AS Birth, pat.phone_number AS Phone, pat.email FROM visits vis INNER JOIN patients pat ON vis.id_patient = pat.id where pat.second_name like @surname ORDER BY Date ASC");
            query.Parameters.AddWithValue("@surname", p_surname);
            MySqlDataReader data = query.ExecuteReader();
            List<Calendar_Appointments> filters = new List<Calendar_Appointments>();
            while (data.Read())
            {
                Calendar_Appointments type = new Calendar_Appointments(data.GetString(0), data.GetString(1), data.GetString(2), data.GetString(3), data.GetString(4), data.GetDateTime(5), data.GetString(6), data.GetString(7));
                filters.Add(type);

            }
            data.Close();

            Database.closeConnection();
            return filters;
        }

        //filtrowanie imie + nazwisko
        public static List<Calendar_Appointments> Filtr_byname_and_surname(string name, string surname)
        {
            string p_name = name + "%";
            string p_surname = surname + "%";

            Database.openConnection();

            MySqlCommand query = Database.command("SELECT vis.date AS Date, pat.first_name AS Name, pat.second_name AS Surname, pat.pesel AS PESEL, pat.sex as Sex, pat.date_of_birth AS Birth, pat.phone_number AS Phone, pat.email FROM visits vis INNER JOIN patients pat ON vis.id_patient = pat.id where pat.first_name like @name " + "AND pat.second_name like @surname ORDER BY Date ASC"); 
            query.Parameters.AddWithValue("@name", p_name);
            query.Parameters.AddWithValue("@surname", p_surname);

            MySqlDataReader data = query.ExecuteReader();
            List<Calendar_Appointments> filters = new List<Calendar_Appointments>();
            while (data.Read())
            {
                Calendar_Appointments type = new Calendar_Appointments(data.GetString(0), data.GetString(1), data.GetString(2), data.GetString(3), data.GetString(4), data.GetDateTime(5), data.GetString(6), data.GetString(7));
                filters.Add(type);
            }
            data.Close();

            Database.closeConnection();
            return filters;
        }

        //wyswietlanie kalendarza na cały miesiąc (szczegółowy)
        public static List<Calendar_Appointments> Calendar_details(int month, int year)
        {
            Database.openConnection();
            MySqlCommand query = Database.command("SELECT vis.date AS Date, pat.first_name AS Name, pat.second_name AS Surname, pat.pesel AS PESEL, pat.sex as Sex, pat.date_of_birth AS Birth, pat.phone_number AS Phone, pat.email FROM visits vis INNER JOIN patients pat ON vis.id_patient = pat.id where month(date) =  @month AND year(date) = @year ORDER BY vis.date ASC");
            query.Parameters.AddWithValue("@year", year);
            query.Parameters.AddWithValue("@month", month);



            MySqlDataReader data = query.ExecuteReader();
            List<Calendar_Appointments> filters = new List<Calendar_Appointments>();
            while (data.Read())
            {
                Calendar_Appointments type = new Calendar_Appointments(data.GetString(0), data.GetString(1), data.GetString(2), data.GetString(3), data.GetString(4), data.GetDateTime(5), data.GetString(6), data.GetString(7));
                filters.Add(type);
            }
            data.Close();

            Database.closeConnection();
            return filters;
        }

        //wyświetlanie szczegółów na wybrany dzień
        public static List<Calendar_Appointments> Calendar_sectionchanged(int day, int month)
        {
            MySqlCommand query = Database.command("SELECT vis.date AS Date, pat.first_name AS Name, pat.second_name AS Surname, pat.pesel AS PESEL, pat.sex as Sex, pat.date_of_birth AS Birth, pat.phone_number AS Phone, pat.email FROM visits vis INNER JOIN patients pat ON vis.id_patient = pat.id where day(date) = @day AND month(date) = @month ORDER BY Name ASC");
            Database.openConnection();

            query.Parameters.AddWithValue("@day", day);
            query.Parameters.AddWithValue("@month", month);


            MySqlDataReader data = query.ExecuteReader();
            List<Calendar_Appointments> filters = new List<Calendar_Appointments>();
            while (data.Read())
            {
                Calendar_Appointments type = new Calendar_Appointments(data.GetString(0), data.GetString(1), data.GetString(2), data.GetString(3), data.GetString(4), data.GetDateTime(5), data.GetString(6), data.GetString(7));
                filters.Add(type);
            }
            data.Close();

            Database.closeConnection();
            return filters;
        }
    }
}


