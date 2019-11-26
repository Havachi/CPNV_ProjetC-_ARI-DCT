using MySql.Data.MySqlClient;
using System;
using System.Data.Common;
using System.Threading;

//TODO IN THIS FILE: Remove Hardcoded values to connect to the database and replace by a JSON File containing those values

namespace DBConnectionLib
{
        /// <summary>
        /// This Class contains all method used to connect, disconnect, Inserting to the Database
        /// Also contains some method to check values in the database (E.g. Checking if the username is already used)
        /// </summary>
        public class DBConnection
        {
            #region private attibut

            private MySqlConnection connection;

            #endregion

            #region Private methods

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


            #endregion

            #region Public methods

            /// <summary>
        /// Constructor for the Object DBConnection
        /// </summary>
            public DBConnection()
            {
                InitConnection();
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
            #endregion
        }
}