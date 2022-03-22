using medicalclinic_back;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;

namespace medicalclinic
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IncorrectDataLabel.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Database.openConnection();
                MySqlCommand command = Database.command("SELECT * FROM user_credentials where login = @username AND password = @password");

                command.Parameters.AddWithValue("@username", TextBox1.Text);
                command.Parameters.AddWithValue("@password", TextBox2.Text);

                MySqlDataAdapter sda = new MySqlDataAdapter(command);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                //int i = cmd.ExecuteNonQuery();
                if (dt.Rows.Count > 0)
                {
                    Session["id"] = TextBox1.Text;
                    Response.Redirect("Default.aspx");
                    Session.RemoveAll();
                }
                else
                {
                    IncorrectDataLabel.Visible = true;
                }
                Database.closeConnection();
            }
            catch
            {
                IncorrectDataLabel.Text = "Błąd";
            }
        }
    }
}