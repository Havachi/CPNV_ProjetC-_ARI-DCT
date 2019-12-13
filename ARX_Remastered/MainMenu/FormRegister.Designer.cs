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
            this.btnRegisterCancel = new System.Windows.Forms.Button();
            this.lblRegisterTitle = new System.Windows.Forms.Label();
            this.tbxRegisterMail = new System.Windows.Forms.TextBox();
            this.tbxRegisterPassword = new System.Windows.Forms.TextBox();
            this.lblRegisterMail = new System.Windows.Forms.Label();
            this.lblRegisterPassword = new System.Windows.Forms.Label();
            this.btnRegisterRegister = new System.Windows.Forms.Button();
            this.tbxRegisterPasswordCheck = new System.Windows.Forms.TextBox();
            this.lblRegisterPasswordCheck = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRegisterCancel
            // 
            this.btnRegisterCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegisterCancel.Location = new System.Drawing.Point(126, 302);
            this.btnRegisterCancel.Name = "btnRegisterCancel";
            this.btnRegisterCancel.Size = new System.Drawing.Size(250, 60);
            this.btnRegisterCancel.TabIndex = 0;
            this.btnRegisterCancel.Text = "Annuler";
            this.btnRegisterCancel.UseVisualStyleBackColor = true;
            this.btnRegisterCancel.Click += new System.EventHandler(this.btnRegisterCancel_Click);
            // 
            // lblRegisterTitle
            // 
            this.lblRegisterTitle.AutoSize = true;
            this.lblRegisterTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegisterTitle.Location = new System.Drawing.Point(235, 26);
            this.lblRegisterTitle.Name = "lblRegisterTitle";
            this.lblRegisterTitle.Size = new System.Drawing.Size(330, 46);
            this.lblRegisterTitle.TabIndex = 1;
            this.lblRegisterTitle.Text = "Nouveau Compte";
            // 
            // tbxRegisterMail
            // 
            this.tbxRegisterMail.Location = new System.Drawing.Point(395, 158);
            this.tbxRegisterMail.Name = "tbxRegisterMail";
            this.tbxRegisterMail.Size = new System.Drawing.Size(125, 20);
            this.tbxRegisterMail.TabIndex = 2;
            this.tbxRegisterMail.Text = "Adresse Email";
            // 
            // tbxRegisterPassword
            // 
            this.tbxRegisterPassword.Location = new System.Drawing.Point(395, 194);
            this.tbxRegisterPassword.Name = "tbxRegisterPassword";
            this.tbxRegisterPassword.PasswordChar = '*';
            this.tbxRegisterPassword.Size = new System.Drawing.Size(125, 20);
            this.tbxRegisterPassword.TabIndex = 3;
            this.tbxRegisterPassword.Text = "Password";
            this.tbxRegisterPassword.TextChanged += new System.EventHandler(this.tbxRegisterPassword_TextChanged);
            // 
            // lblRegisterMail
            // 
            this.lblRegisterMail.AutoSize = true;
            this.lblRegisterMail.Location = new System.Drawing.Point(275, 158);
            this.lblRegisterMail.Name = "lblRegisterMail";
            this.lblRegisterMail.Size = new System.Drawing.Size(73, 13);
            this.lblRegisterMail.TabIndex = 4;
            this.lblRegisterMail.Text = "Adresse Email";
            // 
            // lblRegisterPassword
            // 
            this.lblRegisterPassword.AutoSize = true;
            this.lblRegisterPassword.Location = new System.Drawing.Point(275, 194);
            this.lblRegisterPassword.Name = "lblRegisterPassword";
            this.lblRegisterPassword.Size = new System.Drawing.Size(71, 13);
            this.lblRegisterPassword.TabIndex = 5;
            this.lblRegisterPassword.Text = "Mot de passe";
            // 
            // btnRegisterRegister
            // 
            this.btnRegisterRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegisterRegister.Location = new System.Drawing.Point(437, 302);
            this.btnRegisterRegister.Name = "btnRegisterRegister";
            this.btnRegisterRegister.Size = new System.Drawing.Size(250, 60);
            this.btnRegisterRegister.TabIndex = 6;
            this.btnRegisterRegister.Text = "Créer le compte";
            this.btnRegisterRegister.UseVisualStyleBackColor = true;
            this.btnRegisterRegister.Click += new System.EventHandler(this.btnRegisterSignup_Click);
            // 
            // tbxRegisterPasswordCheck
            // 
            this.tbxRegisterPasswordCheck.Location = new System.Drawing.Point(395, 232);
            this.tbxRegisterPasswordCheck.Name = "tbxRegisterPasswordCheck";
            this.tbxRegisterPasswordCheck.PasswordChar = '*';
            this.tbxRegisterPasswordCheck.Size = new System.Drawing.Size(125, 20);
            this.tbxRegisterPasswordCheck.TabIndex = 7;
            this.tbxRegisterPasswordCheck.Text = "Password";
            this.tbxRegisterPasswordCheck.TextChanged += new System.EventHandler(this.tbxRegisterPasswordCheck_TextChanged);
            // 
            // lblRegisterPasswordCheck
            // 
            this.lblRegisterPasswordCheck.AutoSize = true;
            this.lblRegisterPasswordCheck.Location = new System.Drawing.Point(206, 232);
            this.lblRegisterPasswordCheck.Name = "lblRegisterPasswordCheck";
            this.lblRegisterPasswordCheck.Size = new System.Drawing.Size(140, 13);
            this.lblRegisterPasswordCheck.TabIndex = 8;
            this.lblRegisterPasswordCheck.Text = "Vérification du mot de passe";
            // 
            // FormRegister
            // 
            this.AcceptButton = this.btnRegisterRegister;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnRegisterCancel;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblRegisterPasswordCheck);
            this.Controls.Add(this.tbxRegisterPasswordCheck);
            this.Controls.Add(this.btnRegisterRegister);
            this.Controls.Add(this.lblRegisterPassword);
            this.Controls.Add(this.lblRegisterMail);
            this.Controls.Add(this.tbxRegisterPassword);
            this.Controls.Add(this.tbxRegisterMail);
            this.Controls.Add(this.lblRegisterTitle);
            this.Controls.Add(this.btnRegisterCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormRegister";
            this.Text = "Register";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRegisterCancel;
        private System.Windows.Forms.Label lblRegisterTitle;
        private System.Windows.Forms.TextBox tbxRegisterMail;
        private System.Windows.Forms.TextBox tbxRegisterPassword;
        private System.Windows.Forms.Label lblRegisterMail;
        private System.Windows.Forms.Label lblRegisterPassword;
        private System.Windows.Forms.Button btnRegisterRegister;
        private System.Windows.Forms.TextBox tbxRegisterPasswordCheck;
        private System.Windows.Forms.Label lblRegisterPasswordCheck;
    }
}