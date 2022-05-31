using medicalclinic_back;
using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Web.UI;

namespace medicalclinic
{
    public partial class AppointmentManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DropDownList_doctor.AutoPostBack = true;
            DropDownList_patient.AutoPostBack = true;
            DropDownList_office.AutoPostBack = true;
            if (!IsPostBack)
            {
                DropDownList_doctor.Items.Add(new ListItem("All", 0.ToString()));
                DropDownList_patient.Items.Add(new ListItem("All", 0.ToString()));
                DropDownList_office.Items.Add(new ListItem("All", 0.ToString()));
                //Fills DropDownList_doctor with all employees
                List<Employee> employees = Employee.getAllEmployees().OrderBy(employee => employee.First_name).ThenBy(employee => employee.Second_name).ToList();
                foreach (Employee employee in employees)
                {
                    DropDownList_doctor.Items.Add(new ListItem(employee.First_name + " " + employee.Second_name, employee.Id.ToString()));
                }
                DropDownList_doctor.DataBind();
                //Fills DropDownList_patient with all patients
                List<Patient> patients = Patient.GetPatients(null, null, null, null).OrderBy(patient => patient.First_name).ThenBy(patient => patient.Second_name).ToList();
                foreach (Patient patient in patients)
                {
                    DropDownList_patient.Items.Add(new ListItem(patient.First_name + " " + patient.Second_name, patient.Id.ToString()));
                }
                DropDownList_patient.DataBind();
                //Fills DropDownList_office with all offices
                List<Office> offices = Office.GetAllOffices().OrderBy(office => office.Number_of_office).ToList(); ;
                foreach (Office office in offices)
                {
                    DropDownList_office.Items.Add(new ListItem(office.Number_of_office, office.Id.ToString()));
                }
                DropDownList_office.DataBind();
            }

        }

        protected void Calendar_appointments_DayRender(object sender, DayRenderEventArgs e)
        {
            int employee_id = int.Parse(DropDownList_doctor.SelectedValue);
            int patient_id = int.Parse(DropDownList_patient.SelectedValue);
            int office_id = int.Parse(DropDownList_office.SelectedValue);

            List<Appointment> appointments = Appointment.GetAppointments(employee_id, patient_id, office_id);
            foreach (Appointment appointment in appointments)
            {
                if (e.Day.Date.Equals(appointment.Date_of_appointment))
                {
                    e.Cell.BackColor = System.Drawing.Color.Yellow;
                }
            }
        }

        protected void ButtonFilter_Click(object sender, EventArgs e)
        {
            //Generalnie to nic nie robi, ale robi tak, że strona się aktualizuje xD
        }

        protected void Calendar_appointments_SelectionChanged(object sender, EventArgs e)
        {
            string selected_date = Calendar_appointments.SelectedDate.ToString("yyyy-MM-dd");
            int employee_id = int.Parse(DropDownList_doctor.SelectedValue);
            int patient_id = int.Parse(DropDownList_patient.SelectedValue);
            int office_id = int.Parse(DropDownList_office.SelectedValue);

            Response.Redirect(string.Format("~/ListAppointments.aspx?selected_date={0}&employee_id={1}&patient_id={2}&office_id={3}", selected_date, employee_id, patient_id, office_id));
        }

    }
}