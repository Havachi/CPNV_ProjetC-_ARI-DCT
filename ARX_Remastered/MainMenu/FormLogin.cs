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
        private string mail;
        private string password;
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
            //Appelle la méthode permettant de se connecter
            //Définit les valeurs de username et password avant envoi
            mail = tbxLoginMail.Text;
            password = tbxLoginPassword.Text;

            Login login = new Login(mail, password);
            try
            {
                if (login.LoginDb(login))
                {
                    MessageBox.Show(@"Login Successful");
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
                Close();
            }
        }

        private void tbxLoginPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}