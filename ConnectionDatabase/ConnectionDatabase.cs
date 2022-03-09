using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ConnectionDatabase
{
    public class Connection_Query
    {
        string ConnectionString = @"Password=!Testowanie; User ID=rdsxx; Data Source=medicalclinic.database.windows.net; Initial Catalog=MedicalClinic";
        SqlConnection conn;

        public void openConnection() //creates new sql connection
        {
            conn = new SqlConnection(ConnectionString);
            conn.Open();
        }

        public void closeConnection() //close existing sql connection
        {
            conn.Close();
        }

        public SqlCommand executeQuery(string query) //execute queries 
        {
            SqlCommand cmd = new SqlCommand(query, conn);
            return cmd;
        }

        public SqlDataReader dataReader(string query) //execute query and returns SqlDataReader object
        {
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public SqlDataAdapter dataAdapter(string query)
        {
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            return da;
        }
    }
}
