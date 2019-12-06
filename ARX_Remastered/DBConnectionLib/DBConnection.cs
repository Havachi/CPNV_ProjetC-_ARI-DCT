using MySql.Data.MySqlClient;
using System;
using System.Data.Common;

//TODO IN THIS FILE: Remove Hardcoded values to connect to the database and replace by a JSON File containing those values

namespace DBConnectionLib
{
    /// <summary>
    /// This Class contains all method used to connect, disconnect, Inserting to the Database
    /// Also contains some method to check values in the database (E.g. Checking if the username is already used)
    /// </summary>
    public class DbConnection
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
        public DbConnection()
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

        /// <summary>
        /// This method check if the userEmail exist in database
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        public bool CheckEmail(string userEmail)
        {
            OpenConnection();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"SELECT UserID FROM users WHERE UserEmail = \"{userEmail}\"";
            DbDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    reader.Close();
                    CloseConnection();
                    return true;
                }
            }

            throw new UnknownUserEmailAddressException("Wrong password or Email Address, please try again");
        }

        /// <summary>
        /// Get the UserID from the database with the username
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns>String : UserID </returns>
        public int GetUserIdFromUserEmail(string userEmail)
        {
            OpenConnection();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"SELECT UserID FROM users WHERE Username =\"{userEmail}\" ";
            DbDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var result = reader.GetString(0);
                    int id = Int32.Parse(result);
                    reader.Close();
                    CloseConnection();
                    return id;
                }
            }
            throw new UnknownUserEmailAddressException();
        }

        /// <summary>
        /// Check if the Username that the user input is already taken
        /// </summary>
        /// <param name="userEmail">User username</param>
        /// <returns>False: Username not in use</returns>
        public bool CheckIfUserEmailExistInDb(string userEmail)
        {

            string query = $@"SELECT UserID FROM users WHERE UserEmail ='{userEmail}' ";

            MySqlCommand cmd = new MySqlCommand(query, connection);

            OpenConnection();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr.HasRows)
                {
                    CloseConnection();
                    return true;

                }
                CloseConnection();
                return false;
            }
            CloseConnection();
            return false;
        }

        public string GetUserPassword(string userEmail)
        {
            OpenConnection();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"SELECT UserPassword FROM users WHERE UserEmail =\"{userEmail}\" ";
            DbDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var result = reader.GetString(0);
                    reader.Close();
                    CloseConnection();
                    return result;
                }
            }

            throw new UnknownUserEmailAddressException("This Email Address doesn\'t exist");
        }

        /// <summary>
        /// This method insert data in the database
        /// </summary>
        public void InsertDataInDb(string username, string userEmail, string password)
        {
            OpenConnection();
            string query = $"INSERT INTO Users (Username, UserEmail, UserPassword) values (\"{username}\",\"{userEmail}\", \"{password}\")";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {

            }
            CloseConnection();
        }


        public void FullDeleteUser(int id)
        {
            OpenConnection();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"DELETE FROM users WHERE UserID =\"{id}\" ";
            DbDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    CloseConnection();
                }
            }
        }
        #endregion
    }
}