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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IncorrectDataLabel.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {   
                Connection_Query con = new Connection_Query();
                // SqlConnection con = new SqlConnection(@"Password=!Testowanie; User ID=rdsxx; Data Source=medicalclinic.database.windows.net; Initial Catalog=MedicalClinic");

                con.openConnection();
                //con.Open();
                //SqlCommand cmd = new SqlCommand("select * from tb_login where login_u = @username and password_u = @password COLLATE Polish_CS_AI", con);
                SqlCommand cmd = con.executeQuery("select * from tb_login where login_u = @username and password_u = @password COLLATE Polish_CS_AI");

                cmd.Parameters.AddWithValue("@username", TextBox1.Text);
                cmd.Parameters.AddWithValue("@password", TextBox2.Text);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                //int i = cmd.ExecuteNonQuery();
                if(dt.Rows.Count > 0)
                {
                    Session["id"] = TextBox1.Text;
                    Response.Redirect("Dashboard.aspx");
                    Session.RemoveAll();
                }
                else
                {
                    IncorrectDataLabel.Visible = true;
                }
                //con.Close();
                con.closeConnection();
            }
            catch
            {
                IncorrectDataLabel.Text = "Błąd";
            }
        }     
    }
}