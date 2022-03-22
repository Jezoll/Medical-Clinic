using medicalclinic_back;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace medicalclinic
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private string date_tmp;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ComboboxRoleFill();
                ComboboxSpecializationFill();
                CalendarBirthDate.SelectedDate = DateTime.Today;
            }
            else
            {
                CalendarBirthDate.SelectedDate = DateTime.ParseExact(CalendarTextBox.Text, CalendarBirthDate.Format, null);
            }
            CalendarTextBox.Attributes.Add("readonly", "readonly");
        }

        private void ComboboxRoleFill()
        {
            List<UserRole> data = UserRole.getAllRoles();
            DropDownListRole.Items.Clear();
            foreach (UserRole role in data)
            {
                DropDownListRole.Items.Add(role.Name);
            }
        }

        private void ComboboxSpecializationFill()
        {
            List<MedicalSpecialization> data = MedicalSpecialization.getAllMedicalSpecialization();
            DropDownListSpecialization.Items.Clear();
            foreach (MedicalSpecialization spec in data)
            {
                DropDownListSpecialization.Items.Add(spec.Name);
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeManagement.aspx");
        }

        protected void TexBoxName_TextChanged(object sender, EventArgs e)
        {
            IsEmpty();
        }

        protected void TextBoxSurname_TextChanged(object sender, EventArgs e)
        {
            IsEmpty();
        }

        protected void TextBoxPESEL_TextChanged(object sender, EventArgs e)
        {
            IsEmpty();
        }

        private void IsEmpty()
        {
            if(TextBoxName.Text=="" || TextBoxSurname.Text== "" || TextBoxPESEL.Text== "")
            {
                ButtonNext.Enabled = false;
                return;
            }

            ButtonNext.Enabled = true;
        }

        protected void ButtonNext_Click(object sender, EventArgs e)
        {
            if (!Employee.validatePesel(TextBoxPESEL.Text, (DateTime)CalendarBirthDate.SelectedDate, DropDownListSex.SelectedValue))
            {
                Debug.WriteLine(CalendarBirthDate.SelectedDate.ToString());
                AlertBox("incorrect pesel number");
                return;
            }

            if(!Employee.validatePeselUnique(TextBoxPESEL.Text))
            {
                AlertBox("This pesel is already in the database");
                return;
            }

            if(TextBoxEmail.Text.Length>0)
            {
                if(!Employee.validateEmail(TextBoxEmail.Text))
                {
                    AlertBox("incorrect e-mail adress");
                    return;
                }
            }

            if (TextBoxPhoneNumber.Text!="" && TextBoxPhoneNumber.Text.Length != 9)
            {
                AlertBox("incorrect phone number");
                return;
            }



            string address_id = Address.insertNewAddress(TextBoxCountry.Text, TextBoxState.Text, TextBoxCity.Text, TextBoxPostalCode.Text, TextBoxStreet.Text, TextBoxHouseNumber.Text);

            Employee.insertNewEmployee(TextBoxName.Text, TextBoxSurname.Text, TextBoxPESEL.Text, "m", TextBoxPhoneNumber.Text, TextBoxEmail.Text, CalendarTextBox.Text, address_id);


            if (TextBoxEmail.Text.Length > 0)
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("medicalclinicjandzban@gmail.com", "Klinika1234"),
                    EnableSsl = true,
                };

                smtpClient.Send("medicalclinicjandzban@gmail.com", TextBoxEmail.Text, "MedicalClinic", "You were added as employee to our Medical Clinic Database, Congratulations (this message was generated for students project)");
            }

            AlertBox("New Employee has been added to batabase");
            Response.Redirect("AddUser.aspx");
        }
        protected void DropDownListRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DropDownListRole.SelectedValue!="Lekarz")
            {
                DropDownListSpecialization.Visible = false;
                return;
            }

            DropDownListSpecialization.Visible = true;

        
        }

        private void AlertBox(string AlertMessage)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + AlertMessage + "');", true);
        }
    }
}