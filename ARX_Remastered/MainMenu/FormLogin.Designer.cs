namespace MainMenu
{
    partial class FormLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLoginConnexion = new System.Windows.Forms.Button();
            this.tbxLoginMail = new System.Windows.Forms.TextBox();
            this.tbxLoginPassword = new System.Windows.Forms.TextBox();
            this.btnLoginRegister = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLoginConnexion
            // 
            this.btnLoginConnexion.BackgroundImage = global::MainMenu.Properties.Resources.btnSignin;
            this.btnLoginConnexion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoginConnexion.Location = new System.Drawing.Point(114, 438);
            this.btnLoginConnexion.Name = "btnLoginConnexion";
            this.btnLoginConnexion.Size = new System.Drawing.Size(250, 60);
            this.btnLoginConnexion.TabIndex = 3;
            this.btnLoginConnexion.UseVisualStyleBackColor = true;
            this.btnLoginConnexion.Click += new System.EventHandler(this.btnLoginConnexion_Click);
            // 
            // tbxLoginMail
            // 
            this.tbxLoginMail.Location = new System.Drawing.Point(464, 303);
            this.tbxLoginMail.Name = "tbxLoginMail";
            this.tbxLoginMail.Size = new System.Drawing.Size(125, 20);
            this.tbxLoginMail.TabIndex = 1;
            this.tbxLoginMail.Text = "UserEmail";
            // 
            // tbxLoginPassword
            // 
            this.tbxLoginPassword.Location = new System.Drawing.Point(464, 348);
            this.tbxLoginPassword.Name = "tbxLoginPassword";
            this.tbxLoginPassword.PasswordChar = '*';
            this.tbxLoginPassword.Size = new System.Drawing.Size(125, 20);
            this.tbxLoginPassword.TabIndex = 2;
            this.tbxLoginPassword.Text = "Password";
            this.tbxLoginPassword.TextChanged += new System.EventHandler(this.tbxLoginPassword_TextChanged);
            // 
            // btnLoginRegister
            // 
            this.btnLoginRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoginRegister.Image = global::MainMenu.Properties.Resources.btnRegister;
            this.btnLoginRegister.Location = new System.Drawing.Point(425, 438);
            this.btnLoginRegister.Name = "btnLoginRegister";
            this.btnLoginRegister.Size = new System.Drawing.Size(250, 60);
            this.btnLoginRegister.TabIndex = 4;
            this.btnLoginRegister.UseVisualStyleBackColor = true;
            this.btnLoginRegister.Click += new System.EventHandler(this.btnLoginRegister_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MainMenu.Properties.Resources.BCK_Login;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnLoginRegister);
            this.Controls.Add(this.tbxLoginPassword);
            this.Controls.Add(this.tbxLoginMail);
            this.Controls.Add(this.btnLoginConnexion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormLogin";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoginConnexion;
        private System.Windows.Forms.TextBox tbxLoginMail;
        private System.Windows.Forms.TextBox tbxLoginPassword;
        private System.Windows.Forms.Button btnLoginRegister;
    }
}