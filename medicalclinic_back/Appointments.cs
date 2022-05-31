using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace medicalclinic_back
{
    public class Appointment
    {
        private int id;
        private int duration;
        private StatusEnum status;
        private string description;
        private int id_employee;
        private string employee;
        private int id_patient;
        private string patient;
        private int id_office;
        private int office_number;
        private DateTime date_of_appointment;
        private TimeSpan time_of_appointment;
        private double payment;

        public int Id { get => id; set => id = value; }
        public int Duration { get => duration; set => duration = value; }
        public StatusEnum Confirmed { get => status; set => status = value; }
        public string Description { get => description; set => description = value; }
        public int Id_employee { get => id_employee; set => id_employee = value; }
        public string Employee { get => employee; set => employee = value; }
        public int Id_patient { get => id_patient; set => id_patient = value; }
        public string Patient { get => patient; set => patient = value; }
        public int Id_office { get => id_office; set => id_office = value; }
        public int Office_number { get => office_number; set => office_number = value; }
        public DateTime Date_of_appointment { get => date_of_appointment; set => date_of_appointment = value; }
        public TimeSpan Time_of_appointment { get => time_of_appointment; set => time_of_appointment = value; }
        public double Payment { get => payment; set => payment = value; }

        public Appointment(int id, int duration, StatusEnum status, string description, int id_employee, string employee, int id_patient, string patient, int id_office, int office_number, DateTime date_of_appointment, TimeSpan time_of_appointment, double payment)
        {
            this.Id = id;
            this.Duration = duration;
            this.Confirmed = status;
            this.Description = description;
            this.Id_employee = id_employee;
            this.Employee = employee;
            this.Id_patient = id_patient;
            this.Patient = patient;
            this.Id_office = id_office;
            this.Office_number = office_number;
            this.Date_of_appointment = date_of_appointment;
            this.Time_of_appointment = time_of_appointment;
            this.Payment = payment;
        }

        public static List<Appointment> GetAppointments(int employee_id, int patient_id, int office_id, string selected_date = "all")
        {
            string e_id = "'%'";
            string p_id = "'%'";
            string o_id = "'%'";
            string appointment_date = "'%'";
            if(employee_id != 0)
            {
                e_id = "'" + employee_id.ToString() + "'";
            }
            if(patient_id != 0)
            {
                p_id ="'" + patient_id.ToString() + "'";
            }
            if(office_id != 0)
            {
                o_id ="'" + office_id.ToString() + "'";
            }
            if(selected_date != "all")
            {
                appointment_date ="'" + selected_date + "'";
            }

            Database.openConnection();
            string query = $"SELECT v.id, v.duration, v.status, v.description, v.id_employee, CONCAT(e.first_name, ' ', e.second_name) AS 'doctor', v.id_patient, (SELECT CONCAT(p.first_name, ' ',p.second_name) FROM patients p WHERE p.id = v.id_patient) AS 'patient', v.id_office, o.number_of_office, v.date, v.time, v.payments FROM employees e INNER JOIN visits v ON e.id = v.id_employee INNER JOIN offices o ON v.id_office = o.id WHERE v.id_employee LIKE {e_id} AND v.id_patient LIKE {p_id} AND v.id_office LIKE {o_id} AND v.date LIKE {appointment_date};";

            MySqlDataReader data = Database.dataReader(query);
            List<Appointment> appointments = new List<Appointment>();
            while (data.Read())
            {
                Appointment appointment = new Appointment(data.GetInt32(0), data.GetInt32(1), (StatusEnum)Enum.Parse(typeof(StatusEnum), data.GetString(2)), data.GetString(3), data.GetInt32(4), data.GetString(5), data.GetInt32(6), data.GetString(7), data.GetInt32(8), data.GetInt32(9), data.GetDateTime(10), data.GetTimeSpan(11), data.GetDouble(12));

                appointments.Add(appointment);
            }

            Database.closeConnection();
            return appointments;
        }
        public static List<Appointment> GetThisPatientAppointments(int this_patient_id)
        {
            Database.openConnection();
            string query = $"SELECT v.id, v.duration, v.status, v.description, CONCAT(e.first_name, ' ', e.second_name) AS 'first_name and second_name', v.id_patient, o.number_of_office, v.date FROM employees e INNER JOIN visits v ON e.id = v.id_employee INNER JOIN offices o ON v.id_office = o.id WHERE v.id_patient LIKE {this_patient_id};";
            MySqlDataReader data = Database.dataReader(query);

            List<Appointment> appointments = new List<Appointment>();
            while (data.Read())
            {
                Appointment appointment = new Appointment(data.GetInt32(0), data.GetInt32(1), (StatusEnum)Enum.Parse(typeof(StatusEnum), data.GetString(2)), data.GetString(3), data.GetInt32(4), data.GetString(5), data.GetInt32(6), data.GetString(7), data.GetInt32(8), data.GetInt32(9), data.GetDateTime(10), data.GetTimeSpan(11), data.GetDouble(12));

                appointments.Add(appointment);
            }

            Database.closeConnection();
            return appointments;
        }


    }
}
