using medicalclinic_back;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

namespace medicalclinic
{
    public partial class AddNewPatient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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

        protected void ButtonAddNewPatient_Click(object sender, EventArgs e)
        {
            string sexLongName = DropDownListSex.SelectedValue.ToString();
            string sex = "M";

            if (sexLongName == "Female")
            {
                sex = "F";
            }

            if (TextBoxName.Text.Equals(""))
            {
                AlertBox("Empty name space!", false);
                return;
            }

            if (TextBoxSurname.Text.Equals(""))
            {
                AlertBox("Empty surname space!", false);
                return;
            }

            if (TextBoxPesel.Text.Length < 11)
            {
                AlertBox("Empty or too short pesel number!", false);
                return;
            }

            if (TextBoxDateOfBirth.Text.Equals(""))
            {
                AlertBox("Empty date of birth space!", false);
                return;
            }

            if (TextBoxPhoneNumber.Text.Length < 9 || !Patient.ValidatePhoneNumber(TextBoxPhoneNumber.Text))
            {
                AlertBox("Incorrect phone number!", false);
                return;
            }

            if (TextBoxEmail.Text.Equals("") || !Patient.ValidateEmail(TextBoxEmail.Text))
            {
                AlertBox("Incorrect e-mail adress!", false);
                return;
            }

            if (!Patient.ValidatePesel(TextBoxPesel.Text, DateTime.Parse(TextBoxDateOfBirth.Text), DropDownListSex.SelectedValue))
            {
                AlertBox("Pesel does not match date of birth or gender!", false);
                return;
            }
            if (!Patient.ValidatePeselUnique(TextBoxPesel.Text))
            {
                AlertBox("Patient with this pesel already exist in datebase!", false);
                return;
            }


            AlertBox("Patient has been added to the database!", true);

            Patient.AddNewPatient(TextBoxName.Text, TextBoxSurname.Text, TextBoxPesel.Text, sex, TextBoxPhoneNumber.Text, TextBoxEmail.Text, TextBoxDateOfBirth.Text);

        }
        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListPatients.aspx");
        }
    }
}