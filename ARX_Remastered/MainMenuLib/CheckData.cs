using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DBConnectionLib;
using System.Globalization;
using System.Text.RegularExpressions;
using System;

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
        // https://docs.microsoft.com/en-us/dotnet/standard/base-types/how-to-verify-that-strings-are-in-valid-email-format
        public static bool IsValidEmail(string mail)
        {
            if (string.IsNullOrWhiteSpace(mail))
                return false;

            try
            {
                // Normalize the domain
                mail = Regex.Replace(mail, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(mail,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        /// <summary>
        ///     Check mail and password (mail && password > 8)
        /// </summary>
        /// <param name="mail"></param>
        /// <param name="password"></param>
        public bool VerifRegister(string mail, string password)
        {
            if (mail.Length < 8)
            {
                throw new EmailTooShortException("The Email Address that you have entered is too short");
            }

            if (!IsValidEmail(mail))
            {
                throw new InvalidEmailAddressException("The Email Address that you have entered is not valid");
            }
            
            if (password.Length < 8)
            {
                throw new PasswordTooShortException("The password that you have entered is too short");
            }

            return true;
        }
    }
}