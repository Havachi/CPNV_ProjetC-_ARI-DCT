using System;
using System.Windows.Forms;
using DBConnectionLib;
using MainMenuLib;

// ReSharper disable All

namespace MainMenu
{
    public partial class FormLogin : Form
    {
        public Form formLogin;
        private string password;
        private string userEmail;

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
            /// Call Login method
            /// Define username and password sata before throw
            userEmail = tbxLoginMail.Text;
            password = tbxLoginPassword.Text;

            Login login = new Login(userEmail, password);
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
                userEmail = formRegister.UserEmail;
                Close();
            }
        }

        private void tbxLoginPassword_TextChanged(object sender, EventArgs e)
        {
        }
    }
}