using System;
using System.Windows.Forms;
using DBConnectionLib;
using MainMenuLib;

// ReSharper disable All

namespace MainMenu
{
    public partial class FormRegister : Form
    {
        public FormMainMenu FormMainMenu;
        public Form formRegister;
        private string password;
        private string passwordCheck;
        private string userEmail;
        private string username;

        public FormRegister()
        {
            InitializeComponent();
        }

        public string UserEmail
        {
            get { return userEmail; }
        }

        private void btnRegisterSignup_Click(object sender, EventArgs e)
        {
            /// Call Register method
            /// Define username and password data before throw
            userEmail = tbxRegisterMail.Text;
            password = tbxRegisterPassword.Text;
            passwordCheck = tbxRegisterPasswordCheck.Text;

            /// Call RegisterDB to create the new account

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
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
        }

        private void btnRegisterCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}