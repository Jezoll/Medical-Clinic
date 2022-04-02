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
using AjaxControlToolkit;


namespace medicalclinic
{
    public partial class WebForm1 : System.Web.UI.Page
    {
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
                AlertBox("Incorrect PESEL number.", false);
                return;
            }

            if(!Employee.validatePeselUnique(TextBoxPESEL.Text))
            {
                AlertBox("This PESEL is already in the database.", false);
                return;
            }

            if(!AdressCheck())
            {
                AlertBox("To add an address, all address fields must be completed.", false);
                    return;
            }

            if(TextBoxEmail.Text.Length>0)
            {
                if(!Employee.validateEmail(TextBoxEmail.Text))
                {
                    AlertBox("Incorrect e-mail adress.", false);
                    return;
                }
            }

            if (TextBoxPhoneNumber.Text!="" && TextBoxPhoneNumber.Text.Length != 9)
            {
                AlertBox("Incorrect phone number.", false);
                return;
            }



            string address_id = Address.insertNewAddress(TextBoxCountry.Text, TextBoxState.Text, TextBoxCity.Text, TextBoxPostalCode.Text, TextBoxStreet.Text, TextBoxHouseNumber.Text);

            string sexLongName = DropDownListSex.SelectedValue.ToString();
            string sex = "M";

            if (sexLongName == "Female")
            {
                sex = "F";
            }

            Employee.insertNewEmployee(TextBoxName.Text, TextBoxSurname.Text, TextBoxPESEL.Text, sex, TextBoxPhoneNumber.Text, TextBoxEmail.Text, CalendarTextBox.Text, address_id);


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

            AlertBox("New Employee has been added to database", true);
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

        private void AlertBox(string AlertMessage, bool success)
        {
            string alert = "alert('" + AlertMessage + "');";
            if (success) 
            {
                alert = "alert('" + AlertMessage + "'); window.open('AddUser.aspx', '_self');";
            }

            ClientScript.RegisterStartupScript(this.GetType(), "myalert", alert, true);
        }

        private bool AdressCheck()
        {
            int notemptytextboxes = 0;
            int textboxescount = 0;
            TextBox currenttextbox;
            foreach (Control tbox in AddressPanel.Controls)
            {

                if (tbox is TextBox)
                {
                    textboxescount++;
                    currenttextbox = (TextBox)tbox;
                }
                else
                {
                    continue;
                }

                if (currenttextbox.Text.Length > 0)
                {
                    notemptytextboxes++;
                }
            }

            if (notemptytextboxes > 0 && notemptytextboxes < textboxescount)
            {
                return false;
            }

            return true;
        }
    }
}