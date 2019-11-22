using MySql.Data.MySqlClient;
using System;
using System.Data.Common;
using System.Threading;


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
            /// <summary>
            ///  Check if the username exist in database 
            /// </summary>
            /// <param name="username"></param>
            /// <returns></returns>
            public bool CheckUsername(string username)
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = $"SELECT UserID FROM users WHERE Username = \"{username}\"";
                DbDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        reader.Close();
                        return true;
                    }
                }

                throw new UnknownUsernameException();
                
            }
            /// <summary>
            /// check if the password entered by the user is the same as the one in the database
            /// </summary>
            /// <param name="UserID"></param>
            /// <param name="Password"></param>
            /// <returns></returns>
            public bool CheckPassword(string UserID, string Password)
            {
                string pswInDB;
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = $"SELECT UserPassword FROM users WHERE UserID = \"{UserID}\"";
                DbDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        pswInDB = reader.GetString(0);
                        if (pswInDB == Password)
                        {
                            reader.Close();
                            return true;
                        }
                    }
                }
                throw new InvalidPasswordException();
            }
            /// <summary>
            /// Get the UserID from the database with the username
            /// </summary>
            /// <param name="username"></param>
            /// <returns>String : UserID </returns>
            public string GetUserIDFromUsername(string username)
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = $"SELECT UserID FROM users WHERE Username =\"{username}\" ";
                DbDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var result = reader.GetString(0);
                        reader.Close();
                        return result;
                    }
                }
                throw new UnknownUsernameException();
            }
            /// <summary>
            /// Check if the Username that the user input is already taken
            /// </summary>
            /// <param name="username">User username</param>
            /// <returns>True : Username is not used</returns>
            /// <returns>False: Username already taken </returns>
            public bool CheckIfUsernameExistInDB(string username)
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = $"SELECT UserID FROM users WHERE Username =\"{username}\" ";
                DbDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        return false;
                    }
                }

                return true;
            }
            /// <summary>
            /// This method insert data in the database
            /// </summary>
            public void InsertDataInDB(string username,string password)
            {
                // Create a SQL command
                MySqlCommand cmd = connection.CreateCommand();
                OpenConnection();
                // SQL request
                cmd.CommandText = $"INSERT INTO Users (Username, UserPassword) values ({username}, {password})";

                // Execute the SQL command
                cmd.ExecuteNonQuery();
                CloseConnection();
            }   
        }
}


