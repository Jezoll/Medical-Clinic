using System;
using System.Web.UI;
using medicalclinic_back;

namespace medicalclinic
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LogOut_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            LoginUser.logOut();
            Response.Redirect("Login.aspx");
            
            

            
        }
    }
}