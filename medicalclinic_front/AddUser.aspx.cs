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
            //sprawdz poprawnosc loginu i uprawnien

            string user_id = UserCredentials.insertNewUser(login, password);
            Employee.createRelationToUser(user_id, employee_id);
            //wyswietl popout
            LeaveThisForm();
        }

        private void LeaveThisForm()
        {
            Response.Redirect("EmployeeManagement.aspx");
        }
    }
}