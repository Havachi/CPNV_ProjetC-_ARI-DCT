using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DBConnectionLib;

namespace MainMenuLib
{
    /// <summary>
    /// This class contains all the method for registering new users in the database 
    /// </summary>
    public class Register
    {
        private string username;
        private string password;
        private string userEmail;

        /// <summary>
        /// Constructor for the Register Object
        /// </summary>
        /// <param name="username">Username of the user</param>
        /// <param name="password">Password of the user</param>
        public Register(string userEmail, string username, string password)
        {
            this.userEmail = userEmail;
            this.username = username;
            this.password = password;
        }
        /// <summary>
        /// Register new users in the database, also check if the username is already used.
        /// </summary>
        /// <param name="reg">Contains a username and a password</param>
        /// <returns>True: Everything OK</returns>
        /// 
        public bool RegisterInDB(Register reg)
        {
            DBConnection connection = new DBConnection();
            
            CryptoPassword c = new CryptoPassword();
            string hashedPassword = c.Hash(password); ;
            if (connection.CheckIfUsernameExistInDB(username))
            {
                throw new UserEmailAlreadyExistException();
            }
            else
            {
                connection.InsertDataInDB(username,userEmail,hashedPassword);
                return true;
            }
            
            
        }


    }
}

