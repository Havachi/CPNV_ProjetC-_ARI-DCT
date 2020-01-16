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
            this.startX = new System.Windows.Forms.Label();
            this.startY = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblStartX = new System.Windows.Forms.Label();
            this.lblStartY = new System.Windows.Forms.Label();
            this.lblEndX = new System.Windows.Forms.Label();
            this.lblEndY = new System.Windows.Forms.Label();
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
            this.label1.Location = new System.Drawing.Point(651, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Start Point";
            // 
            // startX
            // 
            this.startX.AutoSize = true;
            this.startX.Location = new System.Drawing.Point(667, 78);
            this.startX.Name = "startX";
            this.startX.Size = new System.Drawing.Size(20, 13);
            this.startX.TabIndex = 3;
            this.startX.Text = "X :";
            // 
            // startY
            // 
            this.startY.AutoSize = true;
            this.startY.Location = new System.Drawing.Point(667, 91);
            this.startY.Name = "startY";
            this.startY.Size = new System.Drawing.Size(20, 13);
            this.startY.TabIndex = 4;
            this.startY.Text = "Y :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(651, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "End Point";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(667, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "X :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(667, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Y :";
            // 
            // lblStartX
            // 
            this.lblStartX.AutoSize = true;
            this.lblStartX.Location = new System.Drawing.Point(693, 78);
            this.lblStartX.Name = "lblStartX";
            this.lblStartX.Size = new System.Drawing.Size(16, 13);
            this.lblStartX.TabIndex = 8;
            this.lblStartX.Text = "...";
            // 
            // lblStartY
            // 
            this.lblStartY.AutoSize = true;
            this.lblStartY.Location = new System.Drawing.Point(693, 91);
            this.lblStartY.Name = "lblStartY";
            this.lblStartY.Size = new System.Drawing.Size(16, 13);
            this.lblStartY.TabIndex = 9;
            this.lblStartY.Text = "...";
            // 
            // lblEndX
            // 
            this.lblEndX.AutoSize = true;
            this.lblEndX.Location = new System.Drawing.Point(693, 126);
            this.lblEndX.Name = "lblEndX";
            this.lblEndX.Size = new System.Drawing.Size(16, 13);
            this.lblEndX.TabIndex = 10;
            this.lblEndX.Text = "...";
            // 
            // lblEndY
            // 
            this.lblEndY.AutoSize = true;
            this.lblEndY.Location = new System.Drawing.Point(693, 139);
            this.lblEndY.Name = "lblEndY";
            this.lblEndY.Size = new System.Drawing.Size(16, 13);
            this.lblEndY.TabIndex = 11;
            this.lblEndY.Text = "...";
            // 
            // ProceduralGenerationShowImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 661);
            this.Controls.Add(this.lblEndY);
            this.Controls.Add(this.lblEndX);
            this.Controls.Add(this.lblStartY);
            this.Controls.Add(this.lblStartX);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.startY);
            this.Controls.Add(this.startX);
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
        private System.Windows.Forms.Label startX;
        private System.Windows.Forms.Label startY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblStartX;
        private System.Windows.Forms.Label lblStartY;
        private System.Windows.Forms.Label lblEndX;
        private System.Windows.Forms.Label lblEndY;
    }
}