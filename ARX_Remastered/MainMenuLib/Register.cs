using System;
using System.Collections.Generic;
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
    /// This class contains all the method for registering new users in the database 
    /// </summary>
    public class Register
    {
        private string userEmail;
        private string username;
        private string password;
        private string passwordCheck;
        


        /// <summary>
        /// Constructor for the Register Object
        /// </summary>
        /// <param name="username">Username of the user</param>
        /// <param name="password">Password of the user</param>
        public Register(string userEmail,string username, string password, string passwordCheck)
        {
            this.userEmail = userEmail;
            this.username = username;
            this.password = password;
            this.passwordCheck = passwordCheck;
        }
        /// <summary>
        /// Register new users in the database, also check if the username is already used.
        /// </summary>
        /// <param name="reg">Contains a username and a password</param>
        /// <returns>True: Everything OK</returns>
        /// 
        public bool RegisterInDb(Register reg)
        {
            DbConnection connection = new DbConnection();
            CryptoPassword c = new CryptoPassword();
            string hashedPassword = c.Hash(password);
            CheckData registerCheck = new CheckData();


            //Try to check if the userEmail an password are valid (> 8 char)
            try
            {
                if (!registerCheck.CheckRegisterField(reg.userEmail, reg.password, reg.passwordCheck))
                {
                    return false;
                }
            }
            catch (EmptyFieldException exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
            try
            {
                registerCheck.VerifRegister(reg.userEmail, reg.password);
            }
            catch (PasswordTooShortException exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
            catch (EmailTooShortException exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }

            //Try to Check if the userEmail exist in the database
            try
            {
                connection.CheckIfUserEmailExistInDb(userEmail);
            }
            catch (UserEmailAlreadyExistException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }

            //Try to insert the data in the Database
            try
            {
                connection.InsertDataInDb(username, userEmail, hashedPassword);
                return true;
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }

            
        }


    }
}

