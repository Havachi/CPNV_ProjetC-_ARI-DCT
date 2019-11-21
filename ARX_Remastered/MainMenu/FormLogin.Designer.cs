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
            this.button1 = new System.Windows.Forms.Button();
            this.lbl_Login_title = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lbl_Login_username = new System.Windows.Forms.Label();
            this.lbl_Login_password = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Monoton", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(270, 300);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(250, 60);
            this.button1.TabIndex = 0;
            this.button1.Text = "Se Connecter";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl_Login_title
            // 
            this.lbl_Login_title.AutoSize = true;
            this.lbl_Login_title.Font = new System.Drawing.Font("Monoton", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Login_title.Location = new System.Drawing.Point(315, 39);
            this.lbl_Login_title.Name = "lbl_Login_title";
            this.lbl_Login_title.Size = new System.Drawing.Size(165, 62);
            this.lbl_Login_title.TabIndex = 1;
            this.lbl_Login_title.Text = "Login";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(395, 158);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 20);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(395, 213);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(125, 20);
            this.textBox2.TabIndex = 3;
            // 
            // lbl_Login_username
            // 
            this.lbl_Login_username.AutoSize = true;
            this.lbl_Login_username.Location = new System.Drawing.Point(270, 158);
            this.lbl_Login_username.Name = "lbl_Login_username";
            this.lbl_Login_username.Size = new System.Drawing.Size(55, 13);
            this.lbl_Login_username.TabIndex = 4;
            this.lbl_Login_username.Text = "Username";
            this.lbl_Login_username.Click += new System.EventHandler(this.label2_Click);
            // 
            // lbl_Login_password
            // 
            this.lbl_Login_password.AutoSize = true;
            this.lbl_Login_password.Location = new System.Drawing.Point(270, 213);
            this.lbl_Login_password.Name = "lbl_Login_password";
            this.lbl_Login_password.Size = new System.Drawing.Size(53, 13);
            this.lbl_Login_password.TabIndex = 5;
            this.lbl_Login_password.Text = "Password";
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl_Login_password);
            this.Controls.Add(this.lbl_Login_username);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lbl_Login_title);
            this.Controls.Add(this.button1);
            this.Name = "FormLogin";
            this.Text = "FormLogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbl_Login_title;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lbl_Login_username;
        private System.Windows.Forms.Label lbl_Login_password;
    }
}