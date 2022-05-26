using medicalclinic_back;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Web;

namespace medicalclinic
{
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //Email.sendEmail("rerere", "rererer");

            LabelSec.Visible = false;
            IncorrectDataLabel.Visible = false;

            if (Session["timer"] != null)
            {
                if ((DateTime)Session["timer"] > DateTime.Now)
                {
                    Button1.Enabled = false;
                    TextBox1.Enabled = false;
                    TextBox2.Enabled = false;
                    LabelSec.Visible = true;
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Database.openConnection();
                MySqlCommand command = Database.command("SELECT * FROM user_credentials where login = @username AND password = @password");

                if (TextBox1.Text == "" || TextBox2.Text == "")
                {
                    IncorrectDataLabel.Visible = true;
                    IncorrectDataLabel.Text = "Wprowadź dane!";

                }
                if (LoginUser.checkAttempt() & Session["timer"] == null)
                {
                    Session["timer"] = DateTime.Now.AddMinutes(1);
                    Button1.Enabled = false;
                    TextBox1.Enabled = false;
                    TextBox2.Enabled = false;

                }
                else
                {
                    LoginUser.logIn(TextBox1.Text, TextBox2.Text);
                    if (LoginUser.checkIfLogged())
                    {
                        Session["id"] = TextBox1.Text;
                        //Random rd = new Random();
                        //int rand_num = rd.Next(5000, 9999);
                        HiddenField1.Value = TextBox1.Text;
                        Token.generateToken(HiddenField1.Value);
                        Response.Redirect("Default.aspx");
                        //Session.RemoveAll();
                    }
                    IncorrectDataLabel.Visible = true;
                    if (LoginUser.checkAttempt())
                    {
                        IncorrectDataLabel.Text = LoginUser.showInfo();
                        TextBox1.Enabled = false;
                        TextBox2.Enabled = false;
                        Button1.Enabled = false;

                    }
                    else
                    {
                        IncorrectDataLabel.Text = LoginUser.wrongData();
                    }

                }
            }
            catch
            {
                IncorrectDataLabel.Text = "Błąd";
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            if (Session["timer"] != null)
            {

                if ((DateTime)Session["timer"] > DateTime.Now)
                {
                    LabelSec.Visible = true;
                    LabelSec.Text = "Pozostało " + (((Int32)DateTime.Parse(Session["timer"].ToString()).Subtract(DateTime.Now).TotalSeconds) + " sekund blokady");
                    Button1.Enabled = false;
                    TextBox1.Enabled = false;
                    TextBox2.Enabled = false;

                }
                else
                {
                    Session["timer"] = null;
                    Button1.Enabled = true;
                    TextBox1.Enabled = true;
                    TextBox2.Enabled = true;
                    LoginUser.NumOfAttempt = 3;
                    Response.Redirect("Login.aspx");
                }

            }
        }
    }
}