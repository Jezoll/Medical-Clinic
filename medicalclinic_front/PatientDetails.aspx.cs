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

                List<Appointment> appointments = Appointment.GetAllAppointments("visits.id", "ASC");
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
            string confirm_value = ConfirmMessageResponse.Value;
            if (confirm_value == "Yes")
            {
                Patient.DeletePatient(selected_patient_id);
                Response.Redirect("ListPatients.aspx");
            }
        }

    }
}