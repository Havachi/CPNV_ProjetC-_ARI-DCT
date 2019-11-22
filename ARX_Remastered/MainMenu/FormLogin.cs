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

namespace MainMenu
{

    public partial class FormLogin : Form
    {
        private string username;
        private string password;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLoginConnexion_Click(object sender, EventArgs e)
        {
            //Appelle la méthode permettant de se connecter
            //Définit les valeurs de username et password avant envoi
            username = tbxLoginUsername.Text;
            password = tbxLoginPassword.Text;

            CheckData logincheck = new CheckData(username, password);

            MessageBox.Show("Connexion établie");
        }

        private void btnLoginRegister_Click(object sender, EventArgs e)
        {
            //Appelle la méthode permettant de créer un compte
            //Définit les valeurs de username et password avant envoi
            username = tbxLoginUsername.Text;
            password = tbxLoginPassword.Text;

            CheckData logincheck = new CheckData(username, password);

            MessageBox.Show("Votre compte a été créé");
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

    }
}
