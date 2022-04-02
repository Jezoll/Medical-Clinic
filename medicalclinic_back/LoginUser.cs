using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace medicalclinic_back
{
    public static class LoginUser
    {
        static UserCredentials credentials;
        private static int attempt = 3;
        private static bool islogged = false;
        public static int NumOfAttempt { get { return attempt; } set { attempt = value; } }
        public static bool IsLogged { get { return islogged; } set { islogged = value; } }
        public static string wrongData()
        {
            NumOfAttempt--;
            return "Nieprawidłowy login lub hasło! Pozostało " + NumOfAttempt + " próby.";
        }
        public static bool checkAttempt()
        {
            if (NumOfAttempt == 1)
                return true;
            return false;
        }

        public static string showInfo()
        {
            return "Nie udało się zalogować po kilku próbach! Nałożono karę czasową";
        }
        public static void logIn(string login, string passw)
        {
            Database.openConnection();
            MySqlCommand cmd = Database.command("SELECT * FROM user_credentials where BINARY login =@login AND BINARY password = @password");
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@password", passw);
            MySqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                IsLogged = true;
                NumOfAttempt = 3;

            }
            sdr.Close();
            Database.closeConnection();
        }
        public static bool checkIfLogged()
        {
            if (IsLogged)
                return true;
            return false;
        }
        public static void logOut()
        {
            IsLogged = false;
        }
    }
}
