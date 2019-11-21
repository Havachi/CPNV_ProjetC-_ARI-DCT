using System;
using MySql.Data.MySqlClient;

namespace DBConnectionLib
    {
        public class DBConnection
        {
            private MySqlConnection connection;

            public DBConnection()
            {
                InitConnection();
            }

            /// <summary>
            /// Initialize the connection to the database
            /// </summary>
            private void InitConnection()
            {
                // Creation of the connection string : where, who
                // Avoid user id and pwd hardcoded
                string connectionString = "SERVER=127.0.0.1; DATABASE=arx_db; UID=DBConnector; PASSWORD=1234";
                connection = new MySqlConnection(connectionString);
            }

            /// <summary>
            /// Open connection to the database
            /// </summary>
            public void OpenConnection()
            {
                connection.Open();
            }

            /// <summary>
            /// Close connection to the database
            /// </summary>
            public void CloseConnection()
            {
                connection.Dispose();
            }

        }
    }

}
