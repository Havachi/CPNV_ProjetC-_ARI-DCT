using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainMenuLib;

// ReSharper disable All

namespace MainMenu
{

    public partial class FormLogin : Form
    {
        private string mail;
        private string password;
        private string passwordCheck;
        public Form formLogin;

        public FormLogin()
        {
            InitializeComponent();
        }
        public string Mail
        {
            get { return this.mail; }
        }

        private void btnLoginConnexion_Click(object sender, EventArgs e)
        {
            ///Appelle la méthode permettant de se connecter
            ///Définit les valeurs de username et password avant envoi
            mail = tbxLoginMail.Text;
            password = tbxLoginPassword.Text;

            passwordCheck = "Fill";

            CheckData logincheck = new CheckData(mail, password, passwordCheck);

            ///Appelle la méthode de vérification de données
            logincheck.CheckLoginField(mail, password, passwordCheck);

            ///Appeler la fonction LoginDB pour se connecter
            Login login = new Login(mail, password);
            login.LoginDB(login);
            MessageBox.Show(@"Connexion établie");
            Close();
        }

        private void btnLoginRegister_Click(object sender, EventArgs e)
        {
            FormRegister formRegister = new FormRegister();
            {
                formRegister.ShowDialog(this);
                Close();
            }
        }

        private void tbxLoginPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}