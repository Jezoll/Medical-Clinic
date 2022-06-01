using medicalclinic_back;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace medicalclinic
{
    public partial class Formularz_internetowy1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TextBox_Date.Text = Request.QueryString["selected_date"];
                TextBox_Time.Text = DateTime.Now.ToString("HH:mm");

                List<Patient> patients = Patient.GetPatients(null, null, null, null).OrderBy(patient => patient.First_name).ThenBy(patient => patient.Second_name).ToList();
                foreach (Patient patient in patients)
                {
                    DropDownList_Patient.Items.Add(new ListItem(patient.First_name + " " + patient.Second_name + "  "+patient.Pesel ,patient.Id.ToString()));
                }
                DropDownList_Patient.DataBind();

                List<MedicalSpecialization> specializations = MedicalSpecialization.getAllMedicalSpecialization();

                foreach (MedicalSpecialization specialization in specializations)
                {
                    DropDownList_Specialization.Items.Add(new ListItem(specialization.Name,specialization.Id.ToString()));
                }
                DropDownList_Specialization.DataBind();
                DropDownList_Specialization.AutoPostBack = true;
                DropDownList_Office.AutoPostBack = true;
            }
        }

        private void AlertBox(string AlertMessage, bool success)
        {
            string alert = "alert('" + AlertMessage + "');";
            if (success)
            {
                alert = "alert('" + AlertMessage + "'); window.open('AppointmentsManagement.aspx', '_self');";
            }

            ClientScript.RegisterStartupScript(this.GetType(), "myalert", alert, true);
        }
        protected void DropDownList_Specialization_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList_Doctor.Items.Clear();
            DropDownList_Office.Items.Clear();

            int index=int.Parse(DropDownList_Specialization.SelectedValue);

            List<Employee> employees = Employee.SelectedEmployee(index);
            foreach (Employee employee in employees)
            {
                DropDownList_Doctor.Items.Add(new ListItem(employee.First_name + " " + employee.Second_name, employee.Id.ToString()));
            }
            DropDownList_Doctor.DataBind();

            

            List<Office> offices = Office.GetSelected(index);
            foreach (Office office in offices)
            {
                DropDownList_Office.Items.Add(new ListItem(office.Number_of_office, office.Id.ToString()));
            }
            DropDownList_Office.DataBind();

            
        }

        protected void Button_AddNewAppointment_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Appointment.ValidateDateOfVisit(DateTime.Parse(TextBox_Date.Text)))
                {
                    AlertBox("Oudated termin!", false);
                    return;
                }

                if (!Appointment.ValidateTimeOfVisit(TimeSpan.Parse(TextBox_Time.Text), DateTime.Parse(TextBox_Date.Text)))
                {
                    AlertBox("Incorrect time!", false);
                    return;
                }

                if (!Appointment.ValidateDurationOfVisit(int.Parse(TextBox_Duration.Text)))
                {
                    AlertBox("Duration of the visit cannot equal 0!", false);
                    return;
                }

                if (!Appointment.ValidatePayment(double.Parse(TextBox_Payment.Text)))
                {
                    AlertBox("Duration of the visit cannot equal 0!", false);
                    return;
                }

                if (!Appointment.ValidateVisitHour(DateTime.Parse(TextBox_Date.Text), TimeSpan.Parse(TextBox_Time.Text), int.Parse(TextBox_Duration.Text), DropDownList_Doctor.SelectedValue, DropDownList_Patient.SelectedValue, DropDownList_Office.SelectedValue))
                {
                    AlertBox("There is a appointment in thouse hours!", false);
                    return;
                }
            }
            catch (Exception)
            {
                AlertBox("Correct empty fields", false);
                return;
            }
            
               
            AlertBox("New appointment has been added", true);

            Appointment.AddNewAppointment(int.Parse(TextBox_Duration.Text),TextBox_Description.Text,int.Parse(DropDownList_Doctor.SelectedValue.ToString()),int.Parse(DropDownList_Patient.SelectedValue.ToString()),int.Parse(DropDownList_Office.SelectedValue.ToString()),DateTime.Parse(TextBox_Date.Text),TimeSpan.Parse(TextBox_Time.Text),double.Parse(TextBox_Payment.Text));
        }

        protected void Button_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("AppointmentsManagement.aspx");
        }

    }
}