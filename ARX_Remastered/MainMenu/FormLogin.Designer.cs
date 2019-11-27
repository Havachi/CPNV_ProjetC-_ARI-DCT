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
            this.lblLoginTitle = new System.Windows.Forms.Label();
            this.tbxLoginMail = new System.Windows.Forms.TextBox();
            this.tbxLoginPassword = new System.Windows.Forms.TextBox();
            this.lblLoginUsername = new System.Windows.Forms.Label();
            this.lblLoginPassword = new System.Windows.Forms.Label();
            this.btnLoginRegister = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLoginConnexion
            // 
            this.btnLoginConnexion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoginConnexion.Location = new System.Drawing.Point(126, 302);
            this.btnLoginConnexion.Name = "btnLoginConnexion";
            this.btnLoginConnexion.Size = new System.Drawing.Size(250, 60);
            this.btnLoginConnexion.TabIndex = 0;
            this.btnLoginConnexion.Text = "Sign In";
            this.btnLoginConnexion.UseVisualStyleBackColor = true;
            this.btnLoginConnexion.Click += new System.EventHandler(this.btnLoginConnexion_Click);
            // 
            // lblLoginTitle
            // 
            this.lblLoginTitle.AutoSize = true;
            this.lblLoginTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginTitle.Location = new System.Drawing.Point(315, 39);
            this.lblLoginTitle.Name = "lblLoginTitle";
            this.lblLoginTitle.Size = new System.Drawing.Size(118, 46);
            this.lblLoginTitle.TabIndex = 1;
            this.lblLoginTitle.Text = "Login";
            // 
            // tbxLoginMail
            // 
            this.tbxLoginMail.Location = new System.Drawing.Point(395, 158);
            this.tbxLoginMail.Name = "tbxLoginMail";
            this.tbxLoginMail.Size = new System.Drawing.Size(125, 20);
            this.tbxLoginMail.TabIndex = 2;
            this.tbxLoginMail.Text = "Mail";
            // 
            // tbxLoginPassword
            // 
            this.tbxLoginPassword.Location = new System.Drawing.Point(395, 213);
            this.tbxLoginPassword.Name = "tbxLoginPassword";
            this.tbxLoginPassword.PasswordChar = '*';
            this.tbxLoginPassword.Size = new System.Drawing.Size(125, 20);
            this.tbxLoginPassword.TabIndex = 3;
            this.tbxLoginPassword.Text = "Password";
            this.tbxLoginPassword.TextChanged += new System.EventHandler(this.tbxLoginPassword_TextChanged);
            // 
            // lblLoginUsername
            // 
            this.lblLoginUsername.AutoSize = true;
            this.lblLoginUsername.Location = new System.Drawing.Point(270, 158);
            this.lblLoginUsername.Name = "lblLoginUsername";
            this.lblLoginUsername.Size = new System.Drawing.Size(32, 13);
            this.lblLoginUsername.TabIndex = 4;
            this.lblLoginUsername.Text = "Email";
            // 
            // lblLoginPassword
            // 
            this.lblLoginPassword.AutoSize = true;
            this.lblLoginPassword.Location = new System.Drawing.Point(270, 213);
            this.lblLoginPassword.Name = "lblLoginPassword";
            this.lblLoginPassword.Size = new System.Drawing.Size(53, 13);
            this.lblLoginPassword.TabIndex = 5;
            this.lblLoginPassword.Text = "Password";
            // 
            // btnLoginRegister
            // 
            this.btnLoginRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoginRegister.Location = new System.Drawing.Point(437, 302);
            this.btnLoginRegister.Name = "btnLoginRegister";
            this.btnLoginRegister.Size = new System.Drawing.Size(250, 60);
            this.btnLoginRegister.TabIndex = 6;
            this.btnLoginRegister.Text = "Sign Up";
            this.btnLoginRegister.UseVisualStyleBackColor = true;
            this.btnLoginRegister.Click += new System.EventHandler(this.btnLoginRegister_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLoginRegister);
            this.Controls.Add(this.lblLoginPassword);
            this.Controls.Add(this.lblLoginUsername);
            this.Controls.Add(this.tbxLoginPassword);
            this.Controls.Add(this.tbxLoginMail);
            this.Controls.Add(this.lblLoginTitle);
            this.Controls.Add(this.btnLoginConnexion);
            this.Name = "FormLogin";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoginConnexion;
        private System.Windows.Forms.Label lblLoginTitle;
        private System.Windows.Forms.TextBox tbxLoginMail;
        private System.Windows.Forms.TextBox tbxLoginPassword;
        private System.Windows.Forms.Label lblLoginUsername;
        private System.Windows.Forms.Label lblLoginPassword;
        private System.Windows.Forms.Button btnLoginRegister;
    }
}