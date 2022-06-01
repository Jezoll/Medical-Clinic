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
                alert = "alert('" + AlertMessage + "'); window.open('AppointmentManagement.aspx', '_self');";
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

        protected void DropDownList_Doctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void Button_AddNewAppointment_Click(object sender, EventArgs e)
        {

            

            try
            {
                if (Appointment.ValidateDate(DateTime.Parse(TextBox_Date.Text)))
                {
                    AlertBox("Outdate termin!", false);
                    return;
                }

                if (Appointment.ValidateVisitTime(TimeSpan.Parse(TextBox_Time.Text)))
                {
                    AlertBox("Wrong time!", false);
                    return;
                }

                if (Appointment.ValidateDuration(int.Parse(TextBox_Duration.Text)))
                {
                    AlertBox("Duration of the visit cannot equal 0!", false);
                    return;
                }
            }
            catch (Exception)
            {
                AlertBox("Error!", false);
                return;
            }

            

            Appointment.AddNewAppointment(int.Parse(TextBox_Duration.Text),TextBox_Description.Text,int.Parse(DropDownList_Doctor.SelectedValue.ToString()),int.Parse(DropDownList_Patient.SelectedValue.ToString()),int.Parse(DropDownList_Office.SelectedValue.ToString()),DateTime.Parse(TextBox_Date.Text),TimeSpan.Parse(TextBox_Time.Text),double.Parse(TextBox_Payment.Text));
        }
    }
}