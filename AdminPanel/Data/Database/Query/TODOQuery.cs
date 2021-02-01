using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using AdminPanel.Content.Management;

namespace AdminPanel.Data.Database.Query
{
    class TODOQuery
    {
        private static Database database;

        static TODOQuery()
        {
            database = Database.Instance();
        }

        public static List<TODO> getAll()
        {
            List<TODO> todoList = new List<TODO>();

            string queryString = "SELECT * FROM admin_todo WHERE ended='0' ORDER BY priority DESC";

            if (database.isConnected())
            {
                MySqlDataReader reader = null;
                try
                {
                    MySqlCommand results = new MySqlCommand(queryString, database.Connection);
                    reader = results.ExecuteReader();
                    while (reader.Read())
                    {
                        TODO todo = new TODO(
                            reader.GetString("title"),
                            reader.GetString("description"),
                            reader.GetString("user_id"),
                            reader.GetInt16("priority"),
                            reader.GetDateTime("created_at"),
                            reader.GetDateTime("updated_at"),
                            reader.GetDateTime("starting_at"),
                            reader.GetDateTime("ending_at")
                        );
                        todoList.Add(todo);
                    }
                }
                catch(MySqlException e)
                {
                    Console.WriteLine(e);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
                finally
                {
                    reader.Close();
                }
                return todoList;

            }
            else return null;
        }

        public static void addTODO(TODO todo)
        {
            if(todo != null)
            {
                if (database.isConnected())
                {
                    MySqlDataReader reader = null;
                    Console.WriteLine("Adding todo to database.");
                    string queryString = "INSERT INTO admin_todo (title, description, user_id, priority, updated_at, created_at, starting_at, ending_at)" +
                        " VALUES ('" + todo.GetTitle() + "', '" + todo.GetDescription() + "', '" + todo.GetUserId() + "', '" + todo.GetPriority() + "', '" + todo.UpdatedAt + "'," +
                        " '" + todo.CreatedAt + "', '" + todo.StartingAt + "', '" + todo.EndingAt + "')";
                    try
                    {
                        MySqlCommand cmd = new MySqlCommand(queryString, database.Connection);
                        reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            Console.WriteLine("Query executed.");
                            Console.WriteLine(reader);
                        }
                    }
                    catch(MySqlException e)
                    {
                        Console.WriteLine(e);
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    finally
                    {
                        reader.Close();
                    }
                    
                }
            }
        }

        public static void endTODO(TODO todo)
        {
            if(todo != null)
            {
                if (database.isConnected())
                {
                    MySqlDataReader reader = null;
                    string queryString = "UPDATE admin_todo SET ended=1 WHERE title='"+todo.GetTitle()+"'";
                    try
                    {
                        MySqlCommand cmd = new MySqlCommand(queryString, database.Connection);
                        reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            
                        }
                    }
                    catch(MySqlException e)
                    {
                        Console.WriteLine(e);
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    finally
                    {
                        reader.Close();
                    }
                }
            }
        }
    }
}
