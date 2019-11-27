using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        /// Va chercher les varables necéssaires 
        /// </summary>
        /// <param name="mail"></param>
        /// <param name="password"></param>
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

        /// <summary>
        /// Ajoute dans une liste les caractères interdits
        /// </summary>
        private void populateIllegalChar()
        {
            illegalChar.Add("-- ");
            illegalChar.Add("/*");
            illegalChar.Add("*/");
        }
        /// <summary>
        /// Vérifie que les champs mail et password correspondent aux exigeances (mail && password > 8)
        /// </summary>
        /// <param name="mail"></param>
        /// <param name="password"></param>
        public void VerifRegister(string mail, string password, string passwordCheck)
        {
            if (mail.Length < 8)
            {
                MessageBox.Show("mail too short, minimal 8 character");
                Exception e = new Exception("mail too short");
                throw e;

            }
            else
            {

                populateIllegalChar();
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
                }

                //Ajouter Check si mail
                //Ajouter génération username depuis mail

            }
            if (password.Length < 8)
            {
                MessageBox.Show("The password is too short, minimal 8 character");
                Exception e = new Exception("Password too short");
                throw e;
            }
            else
            {
                //Password encryption
            }




        }
    }
}
