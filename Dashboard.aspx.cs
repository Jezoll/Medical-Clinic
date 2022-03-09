using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using ConnectionDatabase;

namespace webapp
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {         
            if (Session["id"] == null)
                Response.Redirect("Default.aspx"); 
            else
                Label1.Text = Session["id"].ToString(); 
        }

        protected void LogOut_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("Default.aspx");
        }
    }
}