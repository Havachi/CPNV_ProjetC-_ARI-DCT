using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        /// <param name="userEmail">The email Address of the user</param>
        /// <param name="username">Username of the user</param>
        /// <param name="password">Password of the user</param>
        /// <param name="passwordCheck">The password verification of th user</param>
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
        /// <param name="reg">Contains userEmail, username and a password</param>
        /// <returns>True: Everything OK</returns>
        /// 
        public bool RegisterInDb(Register reg)
        {
            DbConnection connection = new DbConnection();
            CryptoPassword c = new CryptoPassword();
            string hashedPassword = c.Hash(password);
            CheckData registerCheck = new CheckData();
            try
            {
                if (!registerCheck.CheckRegisterField(reg.userEmail, reg.password, reg.passwordCheck))
                {
                    return false;
                }

                if (!registerCheck.VerifRegister(reg.userEmail, reg.password))
                {
                    return false;
                }
                if (connection.CheckIfUserEmailExistInDb(userEmail))
                {
                    return false;
                }

                if (!connection.InsertDataInDb(username, userEmail, hashedPassword))
                {
                    return false;
                }
            }
            catch(InvalidEmailAddressException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            catch (EmptyFieldException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            catch (EmailTooShortException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            catch (PasswordTooShortException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            catch (UserEmailAlreadyExistException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Un erreur est survenu lors de la connection avec la base de donnée");
                return false;
            }

            return true;
        }


    }
}

