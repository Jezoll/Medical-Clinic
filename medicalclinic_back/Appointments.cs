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
        private int id_employee;
        private int id_patient;
        private int id_office;
        private DateTime date_of_appointment;

        public int Id { get => id; }
        public int Duration { get => duration; }
        public Boolean Confirmed { get => confirmed; }
        public string Type { get => type; }
        public int Id_employee { get => id_employee; }
        public int Id_patient { get => id_patient; }
        public int Id_office { get => id_office; }
        public DateTime Date_of_appointment { get => date_of_appointment; }

        public Appointment(int id, int duration, Boolean confirmed, string type, int id_employee, int id_patient, int id_office, DateTime date_of_appointment)
        {
            this.id = id;
            this.duration = duration;
            this.confirmed = confirmed;
            this.type = type;
            this.id_employee = id_employee;
            this.id_patient = id_patient;
            this.id_office = id_office;
            this.date_of_appointment = date_of_appointment;
        }

        public static List<Appointment> GetAllAppointments(string sort_column = "visits.id", string sort_direction = "ASC")
        {
            Database.openConnection();
            string query = $"SELECT visits.id, duration, confirmed, type, id_employee, id_patient, id_office, date FROM visits ORDER BY {sort_column} {sort_direction}";

            MySqlDataReader data = Database.dataReader(query);

            List<Appointment> appointments = new List<Appointment>();
            while (data.Read())
            {
                Appointment appointment = new Appointment(data.GetInt32(0), data.GetInt32(1), data.GetBoolean(2), data.GetString(3), data.GetInt32(4), data.GetInt32(5), data.GetInt32(6), data.GetDateTime(7));

                appointments.Add(appointment);
            }

            Database.closeConnection();
            return appointments;
        }


    }
}
