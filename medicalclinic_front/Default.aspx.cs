using System;
using System.Diagnostics;
using System.Web.UI;

namespace medicalclinic
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
                Response.Redirect("Login.aspx");
            else
                Label1.Text = Session["id"].ToString();
        }
    }
}