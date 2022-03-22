﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace medicalclinic_back
{
    public class Employee
    {
        private int id;
        private string first_name;
        private string second_name;
        private string pesel;
        private char sex;
        private string phone_number;
        private string email;
        private DateTime date_of_birth;
        private bool is_active;
        private MedicalSpecialization medical_specialization;
        private Address address;
        private UserRole user_role;
        private UserDepartment user_department;
        private UserCredentials user_credentials;

        public int Id { get => id; set => id = value; }
        public string First_name { get => first_name; set => first_name = value; }
        public string Second_name { get => second_name; set => second_name = value; }
        public string Pesel { get => pesel; set => pesel = value; }
        public char Sex { get => sex; set => sex = value; }
        public string Phone_number { get => phone_number; set => phone_number = value; }
        public string Email { get => email; set => email = value; }
        public DateTime Date_of_birth { get => date_of_birth; set => date_of_birth = value; }
        public bool Is_active { get => is_active; set => is_active = value; }
        public MedicalSpecialization Medical_specialization { get => medical_specialization; set => medical_specialization = value; }
        public Address Address { get => address; set => address = value; }
        public UserRole User_role { get => user_role; set => user_role = value; }
        public UserDepartment User_department { get => user_department; set => user_department = value; }
        public UserCredentials User_login { get => user_credentials; set => user_credentials = value; }

        public Employee(int id, string first_name, string second_name, string pesel, char sex, string phone_number, string email, DateTime date_of_birth, bool is_active, MedicalSpecialization specialization, Address address, UserRole role, UserDepartment department)
        {
            this.id = id;
            this.first_name = first_name;
            this.second_name = second_name;
            this.pesel = pesel;
            this.sex = sex;
            this.phone_number = phone_number;
            this.email = email;
            this.date_of_birth = date_of_birth;
            this.is_active = is_active;
            this.medical_specialization = specialization;
            this.address = address;
            this.user_role = role;
            this.user_department = department;
        }

        public static List<Employee> getAllEmployees(string sort_column = "employees.id", string sort_direction = "DESC", FilterColumnEmployee filter_column = FilterColumnEmployee.Undefined, string filter_query = null)
        {
            string filter = "";
            if (filter_column == FilterColumnEmployee.Role)
            {
                filter = $"WHERE user_roles.name = '{filter_query}'";
            }
            else if (filter_column == FilterColumnEmployee.Active)
            {
                filter = $"WHERE is_active = '{filter_query}'";
            }

            Database.openConnection();
            string query = $"SELECT employees.id, first_name, second_name, pesel, sex, phone_number, email, date_of_birth, is_active, medical_specializations.id, medical_specializations.name, user_addresses.id, user_addresses.country, user_addresses.state, user_addresses.city, user_addresses.postal_code, user_addresses.street, user_addresses.number, user_roles.id, user_roles.name, departments.id, departments.name FROM employees INNER JOIN medical_specializations ON employees.id_specialization = medical_specializations.id INNER JOIN user_addresses ON employees.id_address = user_addresses.id INNER JOIN user_roles ON employees.id_role = user_roles.id INNER JOIN departments ON employees.id_department = departments.id {filter} ORDER BY {sort_column} {sort_direction}";

            MySqlDataReader data = Database.dataReader(query);

            List<Employee> employees = new List<Employee>();
            while (data.Read())
            {
                MedicalSpecialization specialization = new MedicalSpecialization(data.GetInt32(9), data.GetString(10));
                Address address = new Address(data.GetInt32(11), data.GetString(12), data.GetString(13), data.GetString(14), data.GetString(15), data.GetString(16), data.GetString(17));
                UserRole role = new UserRole(data.GetInt32(18), data.GetString(19));
                UserDepartment department = new UserDepartment(data.GetInt32(20), data.GetString(21));

                Employee employee = new Employee(data.GetInt32(0), data.GetString(1), data.GetString(2), data.GetString(3), data.GetChar(4), data.GetString(5), data.GetString(6), data.GetDateTime(7), data.GetBoolean(8), specialization, address, role, department);

                employees.Add(employee);
            }

            Database.closeConnection();
            return employees;
        }

        public bool validatePesel()//zakladam ze przy dodawaniu pracownika robimy obiekt employee. Inaczej trzebaby zmienic metode na static i dac jej argumenty(pesel, data ur,plec)
        {
            string dayOfBirth, monthOfBirth;
            int yearOfBirth;
            char gender;
            bool result = false;

            int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 }; //wagi poszczegolnych cyfr nr pesel

            gender = this.sex;


            List<string> peselDigits = new List<string>(); //lista do przechowywania wszystkich cyfr podanego nr pesel
            foreach(char digit in this.pesel.ToCharArray())
            {
                peselDigits.Add(digit.ToString());
            }

            yearOfBirth = this.date_of_birth.Year; // przypisywanie prawdziwego roku urodzin (wybranego z kalendarza)
            if (this.date_of_birth.Day < 10) //przypisywanie prawdziwego dnia urodzin (wybranego z kalendarza) - taki jaki powinien byc w dobrym peselu
            {
                dayOfBirth = "0" + this.date_of_birth.Day.ToString();
            }
            else
            {
                dayOfBirth = this.date_of_birth.Day.ToString();
            }

            if(this.date_of_birth.Month < 10) // przypisywanie prawdziwego miesiaca urodzin (wybranego z kalendarza)
            {
                monthOfBirth = "0" + this.date_of_birth.Month.ToString();
            }
            else
            {
                monthOfBirth = this.date_of_birth.Month.ToString();
            }


            string thirdAndFourthDigit;

            if (peselDigits.Count == 11)
            {
                if (yearOfBirth >= 2000) //przypisywanie miesiaca urodzenia, ktory powinien byc w prawidlowym peselu
                {
                    if (this.date_of_birth.Month >=10)
                    {
                        thirdAndFourthDigit = "3" + monthOfBirth[1];
                    }
                    else
                    {
                        thirdAndFourthDigit = "2" + monthOfBirth[1];
                    }

                }
                else
                {
                    thirdAndFourthDigit = monthOfBirth;
                }

                char[] yearAsCharArray = yearOfBirth.ToString().ToCharArray();
                string firstTwoDigits = yearAsCharArray[2].ToString() + yearAsCharArray[3].ToString(); //pierwsze dwie cyfry, ktore powinny byc w prawidlowym peselu

                string year = peselDigits[0] +  peselDigits[1]; //rok ktory wynika z podanego peselu
                string month = peselDigits[2] + peselDigits[3]; // miesiac ktory wynika z podanego peselu
                string day = peselDigits[4] + peselDigits[5]; // dzien urodzenia ktory wynika z podanego peselu

                if (firstTwoDigits == year && thirdAndFourthDigit == month && dayOfBirth == day)//sprawdzenie czy data urodzenia wybrana pokrywa sie z datą wynikającą z nr pesel
                {
                    int tenthDigit = Convert.ToInt32(peselDigits[9]); //pobranie 10 cyfry nr pesel
                    if (tenthDigit % 2 == 1 && gender == 'M' || tenthDigit % 2 == 0 && gender == 'K')
                    {
                        int checksum =0;
                        for(int i = 0; i<= weights.Length - 1; i++) //wyliczanie sumy kontrolnej
                        {
                            checksum += Convert.ToInt32(peselDigits[i]) * weights[i];
                        }
                        checksum = checksum % 10;

                        if(checksum != 0)
                        {
                            checksum = 10 - checksum;
                        }

                        if (checksum.ToString() == peselDigits[10]) //sprawdzenie czy wpisana cyfra kontrolna jest rowna wyliczonej przez program
                        {
                            result = true;
                        }
                    }
                }
            }

            return result;
        }
    }
}