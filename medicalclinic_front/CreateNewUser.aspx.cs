using medicalclinic_back;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;

namespace medicalclinic
{
    public partial class WebForm2 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["role"].ToString()=="Administrator" || Session["role"].ToString() =="SuperAdmin")
            {
                if (!IsPostBack)
                {
                    Database.openConnection();
                    string query = @"SELECT employees.id, first_name, second_name FROM employees WHERE id_credentials IS NULL AND email !='' AND email IS NOT NULL;";
                    MySqlCommand mySqlCommand = Database.command(query);
                    MySqlDataReader data = mySqlCommand.ExecuteReader();

                    while (data.Read())
                    {
                        DropDownList1.Items.Add(data.GetString(0).ToString() + " " + data.GetString(1).ToString() + " " + data.GetString(2).ToString());
                        DropDownList1.DataSource = data;
                        DropDownList1.DataValueField = "employees.id";
                    }
                }
                Database.closeConnection();

            }
            else
            {

            }
            
        }

        protected void ButtonSKIP_Click(object sender, EventArgs e)
        {
            LeaveThisForm();
            //wyswietl popout
        }

        protected void ButtonOK_Click(object sender, EventArgs e)
        {
            string[] id = DropDownList1.SelectedItem.ToString().Split(' ');
            int id1 = Int32.Parse(id[0]);

            string login = AddUser.GenerateLogin(id1);
            string password = AddUser.GeneratePassword();
            //string employee_id = Request.QueryString["emp"].ToString();

            if (!UserCredentials.passwordValidation(password))
            {
                AlertBox("password need to contains 8-15 characters, at least one: number, symbol, upper character and lower character");
                return;
            }
            if (login.Length < 1)
            {
                AlertBox("login cannot be empty");
                return;
            }
            if (!UserCredentials.loginValidationUnique(login))
            {
                AlertBox("login already in use");
                return;
            }
            //string user_id = UserCredentials.insertNewUser(login, password);
            //Employee.createRelationToUser(user_id, employee_id);
            AddUser.InsertNewUser(login, password, id1);
            Email.sendEmail("Login: " + login + "\nHasło: " + password, "Dane do nowego konta", "test.kacperkowalski@gmail.com");
            Label1.Text = "User has been added";
            //Response.Redirect("AddUser.aspx");
            //LeaveThisForm();
        }

        private void LeaveThisForm()
        {
            string window = "window.open('UserManagment.aspx', '_self');";
            ClientScript.RegisterStartupScript(this.GetType(), "backtomainmenu", window, true);
        }

        private void AlertBox(string AlertMessage)
        {
            string alert = "alert('" + AlertMessage + "');";
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", alert, true);
        }

    }
}