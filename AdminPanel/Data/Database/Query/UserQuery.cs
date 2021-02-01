using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminPanel.Content.Model.User;
using SHA3.Net;
using MySql.Data.MySqlClient;

namespace AdminPanel.Data.Database.Query
{
    class UserQuery
    {
        private static Database database;

        static UserQuery()
        {
            database = Database.Instance();
        }

        public static AdminUser login(string username, string password)
        {
            password = hashPassword(password);

            string queryString = "SELECT * FROM admin_user WHERE email='" + username + "' AND password='" + password + "' LIMIT 1";

            if (database.isConnected())
            {
                var results = new MySqlCommand(queryString, database.Connection);
                MySqlDataReader reader = results.ExecuteReader();

                if (reader.Read())
                {
                    AdminUser user = new AdminUser(
                            reader.GetInt16("id")+"",
                            reader.GetString("firstname"),
                            reader.GetString("lastname"),
                            reader.GetString("email"),
                            reader.GetInt16("authLevel")
                        );
                    reader.Close();
                    return user;
                }
                else reader.Close();
            }
            return null;
        }

        private static string hashPassword(string password)
        {
            using (var sha = Sha3.Sha3512())
            {
                byte[] hashedPassword = sha.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedPassword.Length; i++)
                {
                    builder.Append(hashedPassword[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        
        public static List<User> getUsers()
        {
            List<User> users = new List<User>();

            if (database.isConnected())
            {
                string queryString = "SELECT * FROM user";
                MySqlDataReader reader = null;
                try
                {
                    MySqlCommand cmd = new MySqlCommand(queryString, database.Connection);
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        User user = new User(
                            reader.GetString("uuid"),
                            reader.GetString("firstname"),
                            reader.GetString("lastname"),
                            reader.GetString("email")
                        );
                        users.Add(user);
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
                finally
                {
                    try
                    {
                        reader.Close();
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                
            }


            return users;
        }
    }
}
