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
        private string mail;
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
            mail = tbxRegisterMail.Text;
            password = tbxRegisterPassword.Text;
            passwordCheck = tbxRegisterPasswordCheck.Text;

            //Appeler la fonction RegisterDB pour créer le compte

            username = (mail.Split('@')[0]);
            CheckData registerCheckData = new CheckData();
            Register register = new Register(mail, username, password, passwordCheck);
            try
            {
                
                if (register.RegisterInDb(register))
                {
                    MessageBox.Show(@"Your account as been created");
                    Close();
                }
                else
                {
                    MessageBox.Show("This Email Address or Password is already in use, please try again");
                }
            }
            catch (EmptyFieldException exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (PasswordTooShortException exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (UserEmailAlreadyExistException exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (EmailTooShortException exception)
            {
                MessageBox.Show(exception.Message);
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
    }
}