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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBorderStyle = new System.Windows.Forms.ComboBox();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(147, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "BorderStyle";
            // 
            // cmbBorderStyle
            // 
            this.cmbBorderStyle.FormattingEnabled = true;
            this.cmbBorderStyle.Location = new System.Drawing.Point(215, 13);
            this.cmbBorderStyle.Name = "cmbBorderStyle";
            this.cmbBorderStyle.Size = new System.Drawing.Size(121, 21);
            this.cmbBorderStyle.TabIndex = 3;
            this.cmbBorderStyle.SelectedIndexChanged += new System.EventHandler(this.cmbBorderStyle_SelectedIndexChanged);
            // 
            // ProceduralGenerationShowImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 661);
            this.Controls.Add(this.cmbBorderStyle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbxMapImage);
            this.Controls.Add(this.btnGenerate);
            this.Name = "ProceduralGenerationShowImage";
            this.Text = "ProceduralGenerationShowImage";
            this.Load += new System.EventHandler(this.ProceduralGenerationShowImage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxMapImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.PictureBox pbxMapImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBorderStyle;
    }
}