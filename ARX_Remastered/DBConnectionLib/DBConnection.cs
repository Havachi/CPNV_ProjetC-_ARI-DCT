using MySql.Data.MySqlClient;
using System;
using System.Data.Common;

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
            /// get the name of the player according to his id
            /// </summary>
            /// <param name="id">id of the player</param>
            /// <returns></returns>
            public string GetPlayerName(int id)
            {
                string name = "";

                // Create a command object
                MySqlCommand cmd = connection.CreateCommand();

                cmd.CommandText = "SELECT Username FROM users WHERE UserID = " + id;

                DbDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    //we go through the result of the select, we might get only one response. 
                    //Despite this, we use a while
                    while (reader.Read())
                    {
                        name = reader.GetString(0);
                        //if a field can be null, we check if the result is not null before getting the value
                        //if (!reader.IsDBNull(2))
                        //{
                        //    telContact = reader.GetString(2);
                        //}

                    }
                    return name;
                }

                return name;
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

            public string CheckUsername(string username)
            {

                string id;
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT UserID FROM users WHERE Username = " + username;
                DbDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    id = reader.GetString(0);
                }
                else
                {
                    id = null;
                }

                return id;
            }

            public void CheckPassword(string UserID)
            {
                string id;
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT UserPassword FROM users WHERE UserID = " + UserID;
                DbDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    id = reader.GetString(0);
                }
        }
        }
}


