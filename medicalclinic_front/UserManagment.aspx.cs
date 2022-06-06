using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using medicalclinic_back;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace medicalclinic
{
	public partial class UserManagment : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            Database.openConnection();
            MySqlDataAdapter dataAdapter = Database.dataAdapter("SELECT user_credentials.id, user_credentials.login, employees.first_name, employees.second_name, employees.email FROM user_credentials INNER JOIN employees ON employees.`id_credentials` = user_credentials.`id` ORDER BY user_credentials.id ASC;");
            DataTable employees = new DataTable();
            dataAdapter.Fill(employees);

            UserTable.DataSource = employees;
            UserTable.DataBind();
            Database.closeConnection();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateNewUser.aspx");
        }
    }
}