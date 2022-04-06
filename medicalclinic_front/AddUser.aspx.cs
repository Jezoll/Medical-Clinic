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
            //wywal do employee management
            //wyswietl popout
        }

        protected void ButtonOK_Click(object sender, EventArgs e)
        {
            LeaveThisForm();
            //sprawdz poprawnosc loginu i uprawnien
            //dodaj usera
            //wywal do employee management
            //wyswietl popout
        }

        private void LeaveThisForm()
        {

            Response.Redirect("EmployeeManagement.aspx");
            
        }
    }
}