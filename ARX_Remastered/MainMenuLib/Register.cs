/// 
/// File name : Register.cs
/// Author : Alessandro Rossi
/// Date : 21.11.2019
/// Description : This file contains code for register new user in a database.
/// 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MainMenuLib
{
    /// <summary>
    /// This class contains method for registering new users in the database 
    /// </summary>
    public class Register
    {
        private string username;
        private string password;
        private List<string> illegalChar = new List<string>();


        public Register(string username, string password)
        {
            populateIllegalChar();

            this.username = username;
            this.password = password;
        }
        public void VerifRegister()
        {

            if (username.Length < 8)
            {
                Exception e = new Exception("Username too short");
                throw e;
            }
            else
            {
                foreach (var c in illegalChar)
                {
                    foreach (var i in illegalChar)
                    {
                        if (c.Contains(i))
                        {
                            Exception e = new Exception("Invalid username");
                            throw e;
                        }
                    }
                }
            }
            if (password.Length < 8)
            {
                Exception e = new Exception("Password too short");
                throw e;
            }
            else
            {
                //Password encryption
            }

        }
        private void populateIllegalChar()
        {
            illegalChar.Add("-- ");
            illegalChar.Add("/*");
            illegalChar.Add("*/");
        }

    }
}

