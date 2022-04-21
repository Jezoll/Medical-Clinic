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
            string query = "SELECT id, login, password FROM user_credentials WHERE id = @id_credentials";

            MySqlCommand command = Database.command(query);

            command.Parameters.AddWithValue("@id_credentials", id_credentials);

            MySqlDataReader data = command.ExecuteReader();

            data.Read();
            UserCredentials credentials = new UserCredentials(data.GetInt32(0), data.GetString(1), data.GetString(2));

            Database.closeConnection();
            return credentials;
        }

        public static string insertNewUser(string login, string password)
        {
            Database.openConnection();
            string query = "INSERT INTO user_credentials (login, password) VALUES (@login, @password); SELECT LAST_INSERT_ID();";


            MySqlCommand command = Database.command(query);

            command.Parameters.AddWithValue("@login", login);
            command.Parameters.AddWithValue("@password", password);

            string user_id = command.ExecuteScalar().ToString();
            Database.closeConnection();

            return user_id;
        }

    }
}
