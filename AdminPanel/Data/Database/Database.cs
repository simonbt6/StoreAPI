using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace AdminPanel.Data.Database
{
    class Database
    {
        private Boolean connected;
        public string Server = "149.28.37.80";
        public string DatabaseName = "StoreAPI";
        private string Username = "root";
        private string Password = "_f3J)QqZ)MXp7~6";

        public MySqlConnection Connection { get; set; }

        private static Database _instance = null;

        public static Database Instance()
        {
            if(_instance == null)
            {
                _instance = new Database();
            }
            return _instance;
        }
        
        public bool isConnected()
        {
            if(Connection == null)
            {
                if (String.IsNullOrEmpty(DatabaseName))
                    return false;
                string connStr = string.Format("Server={0}; database={1}; UID={2}; password={3}", Server, DatabaseName, Username, Password);
                Connection = new MySqlConnection(connStr);
                Connection.Open();
            }
            return true;
        }

        public void Close()
        {
            Connection.Close();
        }
    }
}
