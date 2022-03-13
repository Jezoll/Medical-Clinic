using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

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

        public static List<Employee> getAllEmployees(string sort_column = "employees.id", string sort_direction = "DESC") 
        {
            Database.openConnection();
            string query = $"SELECT employees.id, first_name, second_name, pesel, sex, phone_number, email, date_of_birth, is_active, medical_specializations.id, medical_specializations.name, user_addresses.id, user_addresses.country, user_addresses.state, user_addresses.city, user_addresses.postal_code, user_addresses.street, user_addresses.number, user_roles.id, user_roles.name, departments.id, departments.name FROM employees INNER JOIN medical_specializations ON employees.id_specialization = medical_specializations.id INNER JOIN user_addresses ON employees.id_address = user_addresses.id INNER JOIN user_roles ON employees.id_role = user_roles.id INNER JOIN departments ON employees.id_department = departments.id ORDER BY {sort_column} {sort_direction}";

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
    }
}