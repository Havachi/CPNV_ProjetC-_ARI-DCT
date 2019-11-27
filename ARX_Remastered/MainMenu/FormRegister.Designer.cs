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
            // btnRegisterConnexion
            // 
            this.btnRegisterConnexion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegisterConnexion.Location = new System.Drawing.Point(126, 302);
            this.btnRegisterConnexion.Name = "btnRegisterConnexion";
            this.btnRegisterConnexion.Size = new System.Drawing.Size(250, 60);
            this.btnRegisterConnexion.TabIndex = 0;
            this.btnRegisterConnexion.Text = "Cancel";
            this.btnRegisterConnexion.UseVisualStyleBackColor = true;
            this.btnRegisterConnexion.Click += new System.EventHandler(this.btnRegisterCancel_Click);
            // 
            // lblRegisterTitle
            // 
            this.lblRegisterTitle.AutoSize = true;
            this.lblRegisterTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegisterTitle.Location = new System.Drawing.Point(315, 39);
            this.lblRegisterTitle.Name = "lblRegisterTitle";
            this.lblRegisterTitle.Size = new System.Drawing.Size(168, 46);
            this.lblRegisterTitle.TabIndex = 1;
            this.lblRegisterTitle.Text = "Register";
            // 
            // tbxRegisterMail
            // 
            this.tbxRegisterMail.Location = new System.Drawing.Point(395, 158);
            this.tbxRegisterMail.Name = "tbxRegisterMail";
            this.tbxRegisterMail.Size = new System.Drawing.Size(125, 20);
            this.tbxRegisterMail.TabIndex = 2;
            this.tbxRegisterMail.Text = "Mail";
            // 
            // tbxRegisterPassword
            // 
            this.tbxRegisterPassword.Location = new System.Drawing.Point(395, 194);
            this.tbxRegisterPassword.Name = "tbxRegisterPassword";
            this.tbxRegisterPassword.Size = new System.Drawing.Size(125, 20);
            this.tbxRegisterPassword.TabIndex = 3;
            this.tbxRegisterPassword.Text = "Password";
            // 
            // lblRegisterMail
            // 
            this.lblRegisterMail.AutoSize = true;
            this.lblRegisterMail.Location = new System.Drawing.Point(270, 158);
            this.lblRegisterMail.Name = "lblRegisterMail";
            this.lblRegisterMail.Size = new System.Drawing.Size(32, 13);
            this.lblRegisterMail.TabIndex = 4;
            this.lblRegisterMail.Text = "Email";
            // 
            // lblRegisterPassword
            // 
            this.lblRegisterPassword.AutoSize = true;
            this.lblRegisterPassword.Location = new System.Drawing.Point(273, 194);
            this.lblRegisterPassword.Name = "lblRegisterPassword";
            this.lblRegisterPassword.Size = new System.Drawing.Size(53, 13);
            this.lblRegisterPassword.TabIndex = 5;
            this.lblRegisterPassword.Text = "Password";
            // 
            // btnRegisterRegister
            // 
            this.btnRegisterRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegisterRegister.Location = new System.Drawing.Point(437, 302);
            this.btnRegisterRegister.Name = "btnRegisterRegister";
            this.btnRegisterRegister.Size = new System.Drawing.Size(250, 60);
            this.btnRegisterRegister.TabIndex = 6;
            this.btnRegisterRegister.Text = "Create Account";
            this.btnRegisterRegister.UseVisualStyleBackColor = true;
            this.btnRegisterRegister.Click += new System.EventHandler(this.btnRegisterSignup_Click);
            // 
            // tbxRegisterPasswordCheck
            // 
            this.tbxRegisterPasswordCheck.Location = new System.Drawing.Point(395, 232);
            this.tbxRegisterPasswordCheck.Name = "tbxRegisterPasswordCheck";
            this.tbxRegisterPasswordCheck.Size = new System.Drawing.Size(125, 20);
            this.tbxRegisterPasswordCheck.TabIndex = 7;
            this.tbxRegisterPasswordCheck.Text = "Password (Check)";
            // 
            // lblRegisterPasswordCheck
            // 
            this.lblRegisterPasswordCheck.AutoSize = true;
            this.lblRegisterPasswordCheck.Location = new System.Drawing.Point(273, 232);
            this.lblRegisterPasswordCheck.Name = "lblRegisterPasswordCheck";
            this.lblRegisterPasswordCheck.Size = new System.Drawing.Size(87, 13);
            this.lblRegisterPasswordCheck.TabIndex = 8;
            this.lblRegisterPasswordCheck.Text = "Password Check";
            // 
            // FormRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblRegisterPasswordCheck);
            this.Controls.Add(this.tbxRegisterPasswordCheck);
            this.Controls.Add(this.btnRegisterRegister);
            this.Controls.Add(this.lblRegisterPassword);
            this.Controls.Add(this.lblRegisterMail);
            this.Controls.Add(this.tbxRegisterPassword);
            this.Controls.Add(this.tbxRegisterMail);
            this.Controls.Add(this.lblRegisterTitle);
            this.Controls.Add(this.btnRegisterConnexion);
            this.Name = "FormRegister";
            this.Text = "Register";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRegisterConnexion;
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