using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using DBConnectionLib;

namespace MainMenuLib
{
    public class Login
    {
        private string username;
        private string password;

        public Login(string username, string password)
        {
            this.username = username;
            this.password = password;

        }

        public void LoginDB()
        {
            string ID;
            DBConnection connection = new DBConnection();
            connection.OpenConnection();
            ID = connection.CheckUsername(username);
            if (ID!=null)
            {
                connection.CheckPassword(ID);
            }
            else
            {
                //Exception
            }
        }
    } 
}
