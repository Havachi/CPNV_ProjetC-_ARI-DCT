namespace MainMenu
{
    partial class FormRegister
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
            this.btnRegisterConnexion = new System.Windows.Forms.Button();
            this.tbxRegisterMail = new System.Windows.Forms.TextBox();
            this.tbxRegisterPassword = new System.Windows.Forms.TextBox();
            this.btnRegisterRegister = new System.Windows.Forms.Button();
            this.tbxRegisterPasswordCheck = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnRegisterConnexion
            // 
            this.btnRegisterConnexion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegisterConnexion.Image = global::MainMenu.Properties.Resources.btnCancel;
            this.btnRegisterConnexion.Location = new System.Drawing.Point(123, 432);
            this.btnRegisterConnexion.Name = "btnRegisterConnexion";
            this.btnRegisterConnexion.Size = new System.Drawing.Size(250, 60);
            this.btnRegisterConnexion.TabIndex = 5;
            this.btnRegisterConnexion.UseVisualStyleBackColor = true;
            this.btnRegisterConnexion.Click += new System.EventHandler(this.btnRegisterCancel_Click);
            // 
            // tbxRegisterMail
            // 
            this.tbxRegisterMail.Location = new System.Drawing.Point(474, 284);
            this.tbxRegisterMail.Name = "tbxRegisterMail";
            this.tbxRegisterMail.Size = new System.Drawing.Size(125, 20);
            this.tbxRegisterMail.TabIndex = 1;
            this.tbxRegisterMail.Text = "UserEmail";
            // 
            // tbxRegisterPassword
            // 
            this.tbxRegisterPassword.Location = new System.Drawing.Point(474, 324);
            this.tbxRegisterPassword.Name = "tbxRegisterPassword";
            this.tbxRegisterPassword.PasswordChar = '*';
            this.tbxRegisterPassword.Size = new System.Drawing.Size(125, 20);
            this.tbxRegisterPassword.TabIndex = 2;
            this.tbxRegisterPassword.Text = "Password";
            // 
            // btnRegisterRegister
            // 
            this.btnRegisterRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegisterRegister.Image = global::MainMenu.Properties.Resources.btnSignup;
            this.btnRegisterRegister.Location = new System.Drawing.Point(434, 432);
            this.btnRegisterRegister.Name = "btnRegisterRegister";
            this.btnRegisterRegister.Size = new System.Drawing.Size(250, 60);
            this.btnRegisterRegister.TabIndex = 4;
            this.btnRegisterRegister.UseVisualStyleBackColor = true;
            this.btnRegisterRegister.Click += new System.EventHandler(this.btnRegisterSignup_Click);
            // 
            // tbxRegisterPasswordCheck
            // 
            this.tbxRegisterPasswordCheck.Location = new System.Drawing.Point(474, 366);
            this.tbxRegisterPasswordCheck.Name = "tbxRegisterPasswordCheck";
            this.tbxRegisterPasswordCheck.PasswordChar = '*';
            this.tbxRegisterPasswordCheck.Size = new System.Drawing.Size(125, 20);
            this.tbxRegisterPasswordCheck.TabIndex = 3;
            this.tbxRegisterPasswordCheck.Text = "Password";
            // 
            // FormRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MainMenu.Properties.Resources.BCK_Register;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.ControlBox = false;
            this.Controls.Add(this.tbxRegisterPasswordCheck);
            this.Controls.Add(this.btnRegisterRegister);
            this.Controls.Add(this.tbxRegisterPassword);
            this.Controls.Add(this.tbxRegisterMail);
            this.Controls.Add(this.btnRegisterConnexion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormRegister";
            this.Text = "Register";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRegisterConnexion;
        private System.Windows.Forms.TextBox tbxRegisterMail;
        private System.Windows.Forms.TextBox tbxRegisterPassword;
        private System.Windows.Forms.Button btnRegisterRegister;
        private System.Windows.Forms.TextBox tbxRegisterPasswordCheck;
    }
}