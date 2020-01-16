namespace ARX_Tests.VisualTests
{
    partial class ProceduralGenerationShowImage
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
            this.btnGenerate = new System.Windows.Forms.Button();
            this.pbxMapImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMapImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(45, 12);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // pbxMapImage
            // 
            this.pbxMapImage.Location = new System.Drawing.Point(45, 46);
            this.pbxMapImage.Name = "pbxMapImage";
            this.pbxMapImage.Size = new System.Drawing.Size(600, 600);
            this.pbxMapImage.TabIndex = 1;
            this.pbxMapImage.TabStop = false;
            // 
            // ProceduralGenerationShowImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 661);
            this.Controls.Add(this.pbxMapImage);
            this.Controls.Add(this.btnGenerate);
            this.Name = "ProceduralGenerationShowImage";
            this.Text = "ProceduralGenerationShowImage";
            this.Load += new System.EventHandler(this.ProceduralGenerationShowImage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxMapImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.PictureBox pbxMapImage;
    }
}