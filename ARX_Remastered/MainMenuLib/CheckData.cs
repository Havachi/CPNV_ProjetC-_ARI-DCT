using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DBConnectionLib;

namespace MainMenuLib
{
    /// Cette classe a été faite pour vérifier les données entrée dans "LoginForm" avant de les envoyer au modèle. 
    public class CheckData
    {
        private string mail;
        private string password;
        private string passwordCheck;
        private List<string> illegalChar = new List<string>();



        /// <summary>
        /// Va chercher les varables necéssaires 
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
        public void CheckLoginField(string mail, string password)
        {
            if (mail == "" || password == "")
            {
                throw new EmptyFieldException("Please fill the field");
            }
        }

        public bool IsValidEmail(string mail)
        {
            return new EmailAddressAttribute().IsValid(mail);
        }
        /// <summary>
        /// Ajoute dans une liste les caractères interdits
        /// </summary>
        private void populateIllegalChar()
        {
            illegalChar.Add("-- ");
            illegalChar.Add("/*");
            illegalChar.Add("*/");
            illegalChar.Remove(".");
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
                throw new EmailTooShortException("The Email Address that you have entered is too short");
            }
            else
            {
                IsValidEmail(mail);

                /*populateIllegalChar();
                foreach (var c in illegalChar)
                {
                    foreach (var i in illegalChar)
                    {
                        if (c.Contains(i))
                        {
                            MessageBox.Show("Mail Invalid, don't put special character exept @");
                            Exception e = new Exception("Invalid mail");
                            throw e;
                        }
                    }
                }*/



            }
            if (password.Length < 8)
            {
                throw new PasswordTooShortException("The password that you have entered is too short");
            }
            else
            {
                //Password encryption
            }




        }
    }
}
