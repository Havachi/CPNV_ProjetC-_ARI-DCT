using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DBConnectionLib;
using MySql.Data.MySqlClient;
using ProjetBanque;

namespace MainMenuLib
{
    /// <summary>
    /// This class contain all method for login
    /// </summary>
    public class Login
    {
        private string userEmail;
        private string username;
        private string password;
        /// <summary>
        /// This is the constructor for the Login Object
        /// </summary>
        /// <param name="userEmail">Username of the user</param>
        /// <param name="password">Password of the user</param>
        public Login(string userEmail, string password)
        {
            this.userEmail = userEmail;
            this.password = password;

        }
        /// <summary>
        /// Check if the username and the password of the user is correct
        /// </summary>
        /// <param name="login"></param>
        /// <returns>True if OK</returns>
        /// <returns>Exception if not OK</returns>
        public bool LoginDB(Login login)
        {
            string hashedPassword;
            string userEmail = login.userEmail;
            string password = login.password;
            DBConnection connection = new DBConnection();
            
            CryptoPassword c = new CryptoPassword();

            hashedPassword = connection.GetUserPassword(userEmail);

            if (!connection.CheckEmail(userEmail))
            {
                throw new UnknownUserEmailAddressException();
            }
            if (!c.Verify(password, hashedPassword))
            {
                throw new InvalidPasswordException();
            }
            return true;
        }
    } 
}
