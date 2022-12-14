using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace medicalclinic_back
{
    public class Appointment
    {
        private int id;
        private int duration;
        private Boolean confirmed;
        private string type;
        private string employee;
        private int id_patient;
        private int office_number;
        private DateTime date_of_appointment;

        public int Id { get => id; }
        public int Duration { get => duration; }
        public Boolean Confirmed { get => confirmed; }
        public string Type { get => type; }
        public string Employee { get => employee; }
        public int Id_patient { get => id_patient; }
        public int Office_number { get => office_number; }
        public DateTime Date_of_appointment { get => date_of_appointment; }

        public Appointment(int id, int duration, Boolean confirmed, string type, string employee, int id_patient, int office_number, DateTime date_of_appointment)
        {
            this.id = id;
            this.duration = duration;
            this.confirmed = confirmed;
            this.type = type;
            this.employee = employee;
            this.id_patient = id_patient;
            this.office_number = office_number;
            this.date_of_appointment = date_of_appointment;
        }

        public static List<Appointment> GetAllAppointments(string sort_column = "v.id", string sort_direction = "ASC")
        {
            Database.openConnection();
            string query = $"SELECT v.id, v.duration, v.confirmed, v.type, CONCAT(e.first_name, ' ', e.second_name) AS 'first_name and second_name', v.id_patient, o.number_of_office, v.date FROM employees e INNER JOIN visits v ON e.id = v.id_employee INNER JOIN offices o ON v.id_office = o.id ORDER BY {sort_column} {sort_direction};";
            MySqlDataReader data = Database.dataReader(query);

            List<Appointment> appointments = new List<Appointment>();
            while (data.Read())
            {
                Appointment appointment = new Appointment(data.GetInt32(0), data.GetInt32(1), data.GetBoolean(2), data.GetString(3), data.GetString(4), data.GetInt32(5), data.GetInt32(6), data.GetDateTime(7));

                appointments.Add(appointment);
            }

            Database.closeConnection();
            return appointments;
        }


    }
}
