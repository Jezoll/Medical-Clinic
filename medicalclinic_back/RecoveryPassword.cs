using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using medicalclinic_back;

namespace medicalclinic_back
{
    public static class RecoveryPassword
    {
        public static bool checkCredentials(string login, string email)
        {
            Database.openConnection();
            MySqlCommand cmd = Database.command("SELECT user_credentials.login, employees.email FROM user_credentials LEFT JOIN employees ON employees.id_credentials = user_credentials.id WHERE user_credentials.login = @login AND employees.email = @email; ");
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@email", email);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return true;
            }
            Database.closeConnection();
            reader.Close();
            return false;
        }
        public static bool changePassword(string email, string passw)
        {
            Database.openConnection();
            MySqlCommand cmd = Database.command("UPDATE user_credentials SET password = @password WHERE login=(SELECT user_credentials.login FROM user_credentials LEFT JOIN employees ON employees.id_credentials = user_credentials.id WHERE employees.email = @email); ");
            cmd.Parameters.AddWithValue("@password", passw);
            cmd.Parameters.AddWithValue("@email", email);
            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
