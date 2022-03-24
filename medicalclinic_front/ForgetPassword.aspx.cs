using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using medicalclinic_back;

namespace medicalclinic
{
    public partial class ForgetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IncorrectDataLabel.Visible = false;
            SendedMail.Visible = false;
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (email.Text.IndexOf("@") != -1)
            {
                if (RecoveryPassword.checkCredentials(login.Text, email.Text))
                {
                    SendedMail.Visible=true;
                    SendedMail.Text = Email.sendEmail("<a href=\"https://localhost:44320/PasswordChange.aspx\">Link do zmiany hasła</a>", "Link do zmiany hasła", email.Text);
                    
                }
                else
                {
                    IncorrectDataLabel.Visible = true;
                    IncorrectDataLabel.Text = "niepoprawne dane";
                }
            }
            else
            {
                IncorrectDataLabel.Visible = true;
                IncorrectDataLabel.Text = "niepoprawny format email";

            }

        }
    }


}
    
