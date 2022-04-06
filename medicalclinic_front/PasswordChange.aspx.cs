using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using medicalclinic_back;

namespace medicalclinic
{
    public partial class PasswordChange : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (Session["change_passw"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            IncorrectDataLabel.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            if(new_passw.Text == confirm_passw.Text)
            {
                if(RecoveryPassword.changePassword(login.Text,new_passw.Text))
                {
                    IncorrectDataLabel.Visible = true;
                    IncorrectDataLabel.Text = "Hasło zostało pomyślnie zmienione";
                }
            }
            else
            {
                IncorrectDataLabel.Visible = true;
                IncorrectDataLabel.Text = "Podane hasła nie są identyczne. Spróbuj ponownie";
            }
        }

        protected void returnBtn_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            login.Text = "";
            new_passw.Text = "";
            confirm_passw.Text = "";
            Response.Redirect("HomePage.html");

        }
    }
}