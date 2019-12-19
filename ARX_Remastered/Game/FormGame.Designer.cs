namespace Game
{
    partial class FormGame
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
            this.pbx_FormGameMap = new System.Windows.Forms.PictureBox();
            this.pbx_FormGameGame = new System.Windows.Forms.PictureBox();
            this.lblGameUserLogged = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_FormGameMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_FormGameGame)).BeginInit();
            this.SuspendLayout();
            // 
            // pbx_FormGameMap
            // 
            this.pbx_FormGameMap.Location = new System.Drawing.Point(1299, 12);
            this.pbx_FormGameMap.Name = "pbx_FormGameMap";
            this.pbx_FormGameMap.Size = new System.Drawing.Size(600, 600);
            this.pbx_FormGameMap.TabIndex = 0;
            this.pbx_FormGameMap.TabStop = false;
            // 
            // pbx_FormGameGame
            // 
            this.pbx_FormGameGame.Location = new System.Drawing.Point(13, 13);
            this.pbx_FormGameGame.Name = "pbx_FormGameGame";
            this.pbx_FormGameGame.Size = new System.Drawing.Size(1280, 720);
            this.pbx_FormGameGame.TabIndex = 1;
            this.pbx_FormGameGame.TabStop = false;
            // 
            // lblGameUserLogged
            // 
            this.lblGameUserLogged.AutoSize = true;
            this.lblGameUserLogged.Location = new System.Drawing.Point(1690, 981);
            this.lblGameUserLogged.Name = "lblGameUserLogged";
            this.lblGameUserLogged.Size = new System.Drawing.Size(66, 13);
            this.lblGameUserLogged.TabIndex = 2;
            this.lblGameUserLogged.Text = "Logged as : ";
            // 
            // FormGame
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1920, 1061);
            this.Controls.Add(this.lblGameUserLogged);
            this.Controls.Add(this.pbx_FormGameGame);
            this.Controls.Add(this.pbx_FormGameMap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormGame";
            this.Text = "ARX Remastered";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormGame_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pbx_FormGameMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_FormGameGame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbx_FormGameMap;
        private System.Windows.Forms.PictureBox pbx_FormGameGame;
        private System.Windows.Forms.Label lblGameUserLogged;
    }
}

