using System.Data;
using System.Data.SQLite;

namespace UserAPI
{
    public class DatabaseAction
    {
        // This function add user posted to database.
        public bool control { get; set; }
        public void AddUser(User user)
        {
            SQLiteConnection connection = new SQLiteConnection("Data source=Database/SampleDatabase.db;Versiyon=3");
            connection.Open();
            string sql = $"INSERT INTO Users (Name,Password,ConfirmPassword,Email,Birthday,Age) VALUES ('{user.Name}',{user.Password},{user.ConfirmPassword},'{user.Email}','{user.Birthday}',{user.Age});";
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
            connection.Close();
            control = true;
            Console.WriteLine("User added succesfully.");
        }

        // This function get users in database.
        public List<User> GetUsers()
        {
            SQLiteConnection connection = new SQLiteConnection("Data source=Database/SampleDatabase.db;Versiyon=3");
            connection.Open();
            string sql = "SELECT * FROM Users";
            SQLiteCommand cmd = new SQLiteCommand(sql, connection);
            SQLiteDataReader reader = cmd.ExecuteReader();
            string Name, Email, Birthday;
            int Password, Password2, Age;
            var UsersList = new List<User>();
            while (reader.Read())
            {

                Name = reader.GetString("Name");
                Password = reader.GetInt32("Password");
                Password2 = reader.GetInt32("ConfirmPassword");
                Email = reader.GetString("Email");
                Birthday = reader.GetString("Birthday");
                Age = reader.GetInt32("Age");
                UsersList.Add(new User { Name = Name, Password = Password, ConfirmPassword = Password2, Email = Email, Birthday = Birthday, Age = Age });

            }
            connection.Close();
            if (UsersList.Count > 0)
            {
                Console.WriteLine("Users are send.");
                return UsersList;
            }
            else
            {
                Console.WriteLine("No users found");
                return null;
            }
        }
    }
}
