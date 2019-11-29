﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;
using DBConnectionLib;

namespace MainMenu
{
    /// Cette classe a été faite pour vérifier les données entrée dans "LoginForm" avant de les envoyer au modèle. 
    public class CheckData
    {
        private string mail;
        private string password;
        private string passwordCheck;
        private List<string> illegalChar = new List<string>();



        /// <summary>
        /// Va chercher les variables necéssaires 
        /// </summary>
        /// <param name="mail"></param>
        /// <param name="password"></param>
        public CheckData()
        {


        }
        public CheckData(string mail, string password, string passwordCheck)
        {
            this.mail = mail;
            this.password = password;
            this.passwordCheck = passwordCheck;
        }

        /// <summary>
        /// Vérifie que mail et password ne soient pas vide
        /// </summary>
        /// <param name="mail"></param>
        /// <param name="password"></param>
        public void CheckLoginField(string mail, string password, string passwordCheck)
        {
            if (mail == "" || password == "")
            {
                throw new ArgumentNullException();
            }
        }

        public bool IsValidEmail(string mail)
        {
            return new EmailAddressAttribute().IsValid(mail);
        }

        /// <summary>
        /// Vérifie que les champs mail et password correspondent aux exigeances (mail && password > 8)
        /// </summary>
        /// <param name="mail"></param>
        /// <param name="password"></param>
        public void VerifRegister(string mail, string password)
        {
            if (mail.Length < 8)
            {
                throw new EmailTooShortException();
            }
            else
            {
                IsValidEmail(mail);

            }
            if (password.Length < 8)
            {
                throw new PasswordTooShortException();
            }
            else
            {
                //Password encryption
            }




        }
    }
}