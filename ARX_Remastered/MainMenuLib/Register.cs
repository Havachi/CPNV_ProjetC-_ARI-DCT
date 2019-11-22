﻿/// 
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

        public Register(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}

