using System;
using System.Diagnostics;
using System.Web.UI;
using medicalclinic_back;

namespace medicalclinic
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["id"]!=null)
            {
                Label1.Text = Session["id"].ToString();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }           
        }
    }
}