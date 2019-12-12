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
using DBConnectionLib;
using MainMenuLib;

// ReSharper disable All

namespace MainMenu
{

    public partial class FormLogin : Form
    {
        private string userEmail;
        private string password;
        private bool isLogged;
        public Form formLogin;

        public FormLogin()
        {
            InitializeComponent();
        }
        public string UserEmail
        {
            get { return userEmail; }
        }

        private void btnLoginConnexion_Click(object sender, EventArgs e)
        {
            //Appelle la méthode permettant de se connecter
            //Définit les valeurs de username et password avant envoi
            userEmail = tbxLoginMail.Text;
            password = tbxLoginPassword.Text;

            Login login = new Login(userEmail, password);
            try
            {
                if (login.LoginDb(login))
                {
                    MessageBox.Show(@"Connexion réussite");
                    isLogged = true;
                    Close();
                }
            }
            catch (EmptyFieldException exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (UnknownUserEmailAddressException exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (InvalidPasswordException exception)
            {
                MessageBox.Show(exception.Message);
            }

            
        }

        private void btnLoginRegister_Click(object sender, EventArgs e)
        {
            FormRegister formRegister = new FormRegister();
            {
                formRegister.ShowDialog(this);
                userEmail = formRegister.UserEmail;
                this.isLogged = formRegister.IsLogged;
                Close();
            }
        }

        private void tbxLoginPassword_TextChanged(object sender, EventArgs e)
        {

        }
        public bool IsLogged
        {
            get { return isLogged; }
            set { isLogged = value; }
        }
    }
}