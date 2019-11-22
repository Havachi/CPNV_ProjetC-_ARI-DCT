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
    /// This class contains method for registering new users in the database 
    /// </summary>
    public class Register
    {
        private string username;
        private string password;

        public Register(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public bool RegisterInDB(Register reg)
        {
            DBConnection connection = new DBConnection();


            if (connection.CheckIfUsernameExistInDB(username))
            {
                throw new UsernameAlreadyExistException();
            }
            else
            {
                connection.InsertDataInDB(username,password);
                return true;
            }
            
        }

    }
}

