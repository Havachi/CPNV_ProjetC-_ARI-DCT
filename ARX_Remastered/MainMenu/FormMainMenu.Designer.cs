namespace MainMenu
{
    partial class FormMainMenu
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblARXMainMenu = new System.Windows.Forms.Label();
            this.lblMainMenuLogged = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(247, 380);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(250, 60);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Connexion";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblARXMainMenu
            // 
            this.lblARXMainMenu.AutoSize = true;
            this.lblARXMainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 30.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblARXMainMenu.Location = new System.Drawing.Point(230, 55);
            this.lblARXMainMenu.Name = "lblARXMainMenu";
            this.lblARXMainMenu.Size = new System.Drawing.Size(295, 47);
            this.lblARXMainMenu.TabIndex = 1;
            this.lblARXMainMenu.Text = "Menu Principal";
            // 
            // lblMainMenuLogged
            // 
            this.lblMainMenuLogged.AutoSize = true;
            this.lblMainMenuLogged.Location = new System.Drawing.Point(645, 55);
            this.lblMainMenuLogged.Name = "lblMainMenuLogged";
            this.lblMainMenuLogged.Size = new System.Drawing.Size(66, 13);
            this.lblMainMenuLogged.TabIndex = 2;
            this.lblMainMenuLogged.Text = "Déconnecté";
            // 
            // FormMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.lblMainMenuLogged);
            this.Controls.Add(this.lblARXMainMenu);
            this.Controls.Add(this.btnLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormMainMenu";
            this.Text = "ARX_Remastered : Main Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainMenu_Closing);
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblARXMainMenu;
        private System.Windows.Forms.Label lblMainMenuLogged;
    }
}

