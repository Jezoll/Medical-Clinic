using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using medicalclinic_back;

namespace medicalclinic
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = int.Parse(Request.QueryString[0]);
            Debug.WriteLine(id);
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            //TextBoxPassword.Text = "";
            //TextBoxLogin.Text = "";
        }

        protected void ConfirmButton_Click(object sender, EventArgs e)
        {


            if (!UserCredentials.IsLoginDataCorrect(TextBoxLogin.Text, TextBoxPassword.Text))
            {
                AlertBox("Incorrect login data!");
                return;
            }

            if(!UserCredentials.IsActiveAdmin(TextBoxLogin.Text))
            {
                AlertBox("No administrator permissions!");
                return;
            }

            Employee.ChangeActiveStatus(id);
            //UPDATE `employees` SET `is_active` = b'1' WHERE `employees`.`id` = 12
            AlertBox("Employee status has been changed");

            

        }

        protected void TextBoxPassword_TextChanged(object sender, EventArgs e)
        {
            UnlockConfirmButton();
        }

        protected void UnlockConfirmButton()
        {
            if (TextBoxPassword.Text.Length < 1)
            {
                ConfirmButton.Enabled = false;
                return;
            }

            if (TextBoxLogin.Text.Length < 1)
            {
                ConfirmButton.Enabled = false;
                return;
            }
            ConfirmButton.Enabled = true;
        }

        protected void TextBoxLogin_TextChanged(object sender, EventArgs e)
        {
            UnlockConfirmButton();
        }

        private void AlertBox(string AlertMessage)
        {
            string alert = "alert('" + AlertMessage + "');";
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", alert, true);
        }
    }
}