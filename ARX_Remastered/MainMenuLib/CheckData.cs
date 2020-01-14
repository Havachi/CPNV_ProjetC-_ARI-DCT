using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DBConnectionLib;

namespace MainMenuLib
{
    /// This class exist for check data in LoginForm and RegisterForm before using them
    public class CheckData
    {
        private List<string> illegalChar = new List<string>();
        private string mail;
        private string password;
        private string passwordCheck;


        /// <summary>
        ///     Get necessary data
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
        ///     Check if username and username are not empty
        /// </summary>
        /// <param name="mail"></param>
        /// <param name="password"></param>
        public void CheckLoginField(string mail, string password)
        {
            if (mail == "" || password == "") throw new EmptyFieldException("Please fill the field");
        }

        public bool CheckRegisterField(string mail, string password, string passwordCheck)
        {
            if (mail == "" || password == "" || passwordCheck == "")
                throw new EmptyFieldException("Please fill the field");

            return true;
        }

        public bool IsValidEmail(string mail)
        {
            return new EmailAddressAttribute().IsValid(mail);
        }

        /// <summary>
        ///     Check mail and password (mail && password > 8)
        /// </summary>
        /// <param name="mail"></param>
        /// <param name="password"></param>
        public void VerifRegister(string mail, string password)
        {
            if (mail.Length < 8)
                throw new EmailTooShortException("The Email Address that you have entered is too short");
            IsValidEmail(mail);
            if (password.Length < 8)
                throw new PasswordTooShortException("The password that you have entered is too short");
        }
    }
}