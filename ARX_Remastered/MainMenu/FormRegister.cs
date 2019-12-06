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

    public partial class FormRegister : Form
    {
        private string username;
        private string userEmail;
        private string password;
        private string passwordCheck;
        public Form formRegister;
        public FormMainMenu FormMainMenu;

        public FormRegister()
        {
            InitializeComponent();
        }

        private void btnRegisterSignup_Click(object sender, EventArgs e)
        {
            //Appelle la méthode permettant de créer un compte
            //Définit les valeurs de username et password avant envoi
            userEmail = tbxRegisterMail.Text;
            password = tbxRegisterPassword.Text;
            passwordCheck = tbxRegisterPasswordCheck.Text;

            //Appeler la fonction RegisterDB pour créer le compte

            username = (userEmail.Split('@')[0]);
            Register register = new Register(userEmail, username, password, passwordCheck);
            try
            {
                if (register.RegisterInDb(register))
                {
                    MessageBox.Show(@"Votre compte a été créé");
                    
                    Close();
                }

            }
            catch (InvalidPasswordException exception)
            {
                MessageBox.Show(exception.Message.ToString());
                throw;


            }
            catch (UserEmailAlreadyExistException exception)
            {
                MessageBox.Show(exception.Message.ToString());
                throw;
            }

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnRegisterCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbxRegisterPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxRegisterPasswordCheck_TextChanged(object sender, EventArgs e)
        {

        }

        public string UserEmail
        {
            get { return userEmail; }
        }
    }
}