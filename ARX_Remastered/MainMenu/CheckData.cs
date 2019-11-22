using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainMenu
{
    /// Cette classe a été faite pour vérifier les données entrée dans "LoginForm" avant de les envoyer au modèle. 
    public class CheckData
    {
        private string username;
        private string password;
        private List<string> illegalChar = new List<string>();

        /// <summary>
        /// Va chercher les varables necéssaires 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public CheckData(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        /// <summary>
        /// Vérifie que username et password ne soient pas vide
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void CheckLoginField(string username, string password)
        {
            if (username == "" || password == "")
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
        /// Vérifie que les champs username et password correspondent aux exigeances (username && password > 8)
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void VerifRegister(string username, string password)
        {

            if (username.Length < 8)
            {
                Exception e = new Exception("Username too short");
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
    }
}
