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

    public partial class FormRegister : Form
    {
        private string mail;
        private string password;
        private string passwordCheck;
        public Form formRegister;

        public FormRegister()
        {
            InitializeComponent();
        }

        private void btnRegisterSignup_Click(object sender, EventArgs e)
        {
            ///Appelle la méthode permettant de créer un compte
            ///Définit les valeurs de username et password avant envoi
            mail = tbxRegisterMail.Text;
            password = tbxRegisterPassword.Text;

            CheckData logincheck = new CheckData(mail, password, passwordCheck);

            ///Appelle les métodes de vérifications
            logincheck.CheckLoginField(mail, password, passwordCheck);
            logincheck.VerifRegister(mail, password, passwordCheck);

            MessageBox.Show(@"Votre compte a été créé");


            ///Appeler la fonction RegisterDB pour se connecter
            Register register = new Register(mail, password);
            register.RegisterInDB(register);

            Close();
            ShowDialog(this);
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnRegisterCancel_Click(object sender, EventArgs e)
        {

        }
    }
}