using medicalclinic_back;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace medicalclinic
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ButtonSKIP_Click(object sender, EventArgs e)
        {
            LeaveThisForm();
            //wyswietl popout
        }

        protected void ButtonOK_Click(object sender, EventArgs e)
        {
            string login = TextBoxLogin.Text;
            string password = TextBoxPassword.Text;
            string employee_id = Request.QueryString["emp"].ToString();

            if(!UserCredentials.passwordValidation(password))
            {
                AlertBox("password need to contains 8-15 characters, at least one: number, symbol, upper character and lower character");
                return;
            }
            if(login.Length<1)
            {
                AlertBox("login cannot be empty");
                return;
            }
            if (!UserCredentials.loginValidationUnique(login))
            {
                AlertBox("login already in use");
                return;
            }
            string user_id = UserCredentials.insertNewUser(login, password);
            Employee.createRelationToUser(user_id, employee_id);
            AlertBox("new user has been added");
            LeaveThisForm();
        }

        private void LeaveThisForm()
        {
            string window = "window.open('EmployeeManagement.aspx', '_self');";
            ClientScript.RegisterStartupScript(this.GetType(), "backtomainmenu", window, true);
        }

        private void AlertBox(string AlertMessage)
        {
            string alert = "alert('" + AlertMessage + "');";
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", alert, true);
        }
    }
}