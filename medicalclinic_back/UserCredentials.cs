using MySql.Data.MySqlClient;

namespace medicalclinic_back
{
    public class UserCredentials
    {
        private int id;
        private string login;
        private string password;

        public int Id { get => id; }
        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }

        public UserCredentials(int id, string login, string password) 
        { 
            this.id = id;
            this.login = login;
            this.password = password;
        }

        public static UserCredentials getUserCredentials(string id_credentials)
        {
            Database.openConnection();
            string query = $"SELECT id, login, password FROM user_credentials WHERE id = {id_credentials}";


            MySqlDataReader data = Database.dataReader(query);

            data.Read();
            UserCredentials credentials = new UserCredentials(data.GetInt32(0), data.GetString(1), data.GetString(2));


            Database.closeConnection();
            return credentials;
        }

    }
}
