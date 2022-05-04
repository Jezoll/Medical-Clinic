using medicalclinic_back;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace medicalclinic
{
    public partial class PatientDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                int selected_patient_id = Int32.Parse(Request.QueryString["selected_patient_id"]);
                string p_name = null;
                string p_surname = null;
                string p_pesel = null;
                string last_apppointment_date = null;
                List<Patient> patients = Patient.GetPatients(p_name, p_surname, p_pesel, last_apppointment_date);
                Label_id_value.Text = selected_patient_id.ToString();
                foreach (Patient p in patients)
                {
                    if (p.Id == selected_patient_id)
                    {  
                        if (p.Activity.ToString() == "Y") //Checking if patient is active
                        {
                            Label_activity_value.Text = "Active";
                            Button_activity.Text = "Deactivate Patient";
                        }
                        Label_first_name_value.Text = p.First_name;
                        TextBox_first_name.Text = p.First_name.ToString();
                        Label_surname_value.Text = p.Second_name;
                        TextBox_surname.Text = p.Second_name.ToString();
                        if (p.Sex.ToString() == "M")
                        {
                            Label_sex_value.Text = "Male";
                            RadioButton_sex_male.Checked = true;
                        }
                        else
                        {
                            Label_sex_value.Text = "Female";
                            RadioButton_sex_female.Checked = true;
                        }
                        Label_date_of_birth_value.Text = p.Date_of_birth.ToString("yyyy-MM-dd");
                        TextBox_date_of_birth.Text = p.Date_of_birth.ToString("yyyy-MM-dd");
                        Label_pesel_value.Text = p.Pesel;
                        TextBox_pesel.Text = p.Pesel.ToString();
                        Label_phone_number_value.Text = p.Phone_number;
                        TextBox_phone_number.Text = p.Phone_number.ToString();
                        Label_email_value.Text = p.Email;
                        TextBox_email.Text = p.Email.ToString();
                    }
                }

                List<Appointment> appointments = Appointment.GetAllAppointments("v.id", "ASC");
                List<Appointment> appointment_details = new List<Appointment>();
                foreach (Appointment a in appointments)
                {
                    if (a.Id_patient == selected_patient_id)
                    {
                        appointment_details.Add(a);
                    }

                }
                GridViewAppointments.DataSource = appointment_details;
                GridViewAppointments.DataBind();
            }
        }

        protected void Button_close_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListPatients.aspx");
        }

        protected void Button_Delete_Click(object sender, EventArgs e)
        {
            int selected_patient_id = Int32.Parse(Request.QueryString["selected_patient_id"]);
            string confirm_value = ConfirmMessageResponseDelete.Value;
            if (confirm_value == "Yes")
            {
                Patient.DeletePatient(selected_patient_id);
                Response.Redirect("ListPatients.aspx");
            }
        }
        private void AlertBox(string AlertMessage, bool success)
        {
            string alert = "alert('" + AlertMessage + "');";
            if (success)
            {
                alert = "alert('" + AlertMessage + "'); window.open('ListPatients.aspx', '_self');";
            }

            ClientScript.RegisterStartupScript(this.GetType(), "myalert", alert, true);
        }
        protected void Button_Modify_Click(object sender, EventArgs e)
        {
            string sex = "M";
            int selected_patient_id = Int32.Parse(Request.QueryString["selected_patient_id"]);
            string confirm_value = ConfirmMessageResponseModify.Value;
            if (RadioButton_sex_female.Checked)
            {
                sex = "F";
            }
            if (TextBox_first_name.Text.Equals("") || !Patient.ValidateName(TextBox_first_name.Text))
            {
                AlertBox("Incorrect name!", false);
                return;
            }

            if (TextBox_surname.Text.Equals("") || !Patient.ValidateSurname(TextBox_surname.Text))
            {
                AlertBox("Incorrect surname!", false);
                return;
            }
            if (TextBox_pesel.Text.Length < 11)
            {
                AlertBox("Empty or too short pesel number!", false);
                return;
            }
            if (TextBox_date_of_birth.Text.Equals("") || DateTime.Parse(TextBox_date_of_birth.Text) > DateTime.Now)
            {
                AlertBox("Empty or incorrect date of birth field!", false);
                return;
            }
            if (TextBox_phone_number.Text.Length < 9 || !Patient.ValidatePhoneNumber(TextBox_phone_number.Text))
            {
                AlertBox("Incorrect phone number!", false);
                return;
            }
            if (TextBox_email.Text.Equals("") || !Patient.ValidateEmail(TextBox_email.Text))
            {
                AlertBox("Incorrect e-mail adress!", false);
                return;
            }
            if (!Patient.ValidatePesel(TextBox_pesel.Text, DateTime.Parse(TextBox_date_of_birth.Text), sex))
            {
                AlertBox("Pesel does not match date of birth or gender!", false);
                return;
            }
            if (TextBox_pesel.Text != Label_pesel_value.Text && !Patient.ValidatePeselUnique(TextBox_pesel.Text))
            {
                AlertBox("Patient with this pesel already exist in datebase!", false);
                return;
            }

            if (confirm_value == "Yes")
            {
                Patient.ModifyPatient(selected_patient_id, TextBox_first_name.Text, TextBox_surname.Text, TextBox_pesel.Text, sex, TextBox_phone_number.Text, TextBox_email.Text, TextBox_date_of_birth.Text);
                Response.Redirect(string.Format("~/PatientDetails.aspx?selected_patient_id={0}", selected_patient_id));
            }

        }

        protected void Button_activity_Click(object sender, EventArgs e)
        {
            string activity = "";
            string p_name = null;
            string p_surname = null;
            string p_pesel = null;
            string last_apppointment_date = null;
            int selected_patient_id = Int32.Parse(Request.QueryString["selected_patient_id"]);
            List<Patient> patients = Patient.GetPatients(p_name, p_surname, p_pesel, last_apppointment_date);
            foreach (Patient p in patients)
            {
                if (p.Id == selected_patient_id)
                {
                    activity = p.Activity.ToString();
                }
            }
            if (activity == "Y")
            {
                Patient.ChangePatientsActivity(selected_patient_id, "N");
            }
            if (activity == "N")
            {
                Patient.ChangePatientsActivity(selected_patient_id, "Y");
            }
            Response.Redirect(string.Format("~/PatientDetails.aspx?selected_patient_id={0}", selected_patient_id));
        }
    }
}