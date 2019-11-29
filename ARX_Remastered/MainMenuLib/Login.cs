using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBConnectionLib;
using MySql.Data.MySqlClient;

namespace MainMenuLib
{
    /// <summary>
    /// This class contain all method for login
    /// </summary>
    public class Login
    {
        private string userEmail;
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
            string hashedPassword = null;
            string userEmail = login.userEmail;
            string password = login.password;
            
            DBConnection connection = new DBConnection();
            
            CryptoPassword c = new CryptoPassword();


            
            
            try
            {
                if (!connection.CheckEmail(userEmail))
                {
                    return false;
                }

            }
            catch (UnknownUserEmailAddressException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }

            hashedPassword = connection.GetUserPassword(userEmail);

            try
            {
                if (!c.Verify(password, hashedPassword))
                {
                    return false;
                }
                return true;
            }
            catch (InvalidPasswordException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            
            
        }
    } 
}
