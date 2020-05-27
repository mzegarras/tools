using System;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace CustomerApi.Data
{
    public class DBConnection
    {
        private DBConnection()
        {
        }


        private MySqlConnection connection = null;
        public MySqlConnection Connection
        {
            get { return connection; }
        }

        private static DBConnection _instance = null;
        public static DBConnection Instance()
        {
            if (_instance == null)
                _instance = new DBConnection();
           return _instance;
        }

        public bool IsConnect()
        {
            if (Connection == null)
            {
                //string connectionString = "Server=localhost;Database=appdb;Uid=demouser;Pwd=demopwd;";
                string connectionString = "Server=db;Database=appdb;Uid=demouser;Pwd=demopwd;";
                System.Console.WriteLine(connectionString);
                
                if (String.IsNullOrEmpty(connectionString))
                    return false;

                //string connstring = string.Format("Server=localhost; database={0}; UID=UserName; password=your password", databaseName);
                connection = new MySqlConnection(connectionString);
                connection.Open();
            }

            return true;
        }

        public void Close()
        {
            connection.Close();
        }        
    }
}