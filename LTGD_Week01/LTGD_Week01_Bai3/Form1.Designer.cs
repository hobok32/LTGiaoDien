namespace LTGD_Week01_Bai3
{
    partial class Form1
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
            this.borderStyle = new System.Windows.Forms.Button();
            this.reSize = new System.Windows.Forms.Button();
            this.Opacityy = new System.Windows.Forms.Button();
            this.NRF = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // borderStyle
            // 
            this.borderStyle.Location = new System.Drawing.Point(12, 12);
            this.borderStyle.Name = "borderStyle";
            this.borderStyle.Size = new System.Drawing.Size(75, 23);
            this.borderStyle.TabIndex = 0;
            this.borderStyle.Text = "BorderStyle";
            this.borderStyle.UseVisualStyleBackColor = true;
            this.borderStyle.Click += new System.EventHandler(this.borderStyle_Click);
            // 
            // reSize
            // 
            this.reSize.Location = new System.Drawing.Point(93, 12);
            this.reSize.Name = "reSize";
            this.reSize.Size = new System.Drawing.Size(68, 23);
            this.reSize.TabIndex = 2;
            this.reSize.Text = "Resize";
            this.reSize.UseVisualStyleBackColor = true;
            this.reSize.Click += new System.EventHandler(this.reSize_Click);
            // 
            // Opacityy
            // 
            this.Opacityy.Location = new System.Drawing.Point(167, 12);
            this.Opacityy.Name = "Opacityy";
            this.Opacityy.Size = new System.Drawing.Size(75, 23);
            this.Opacityy.TabIndex = 3;
            this.Opacityy.Text = "Opacity";
            this.Opacityy.UseVisualStyleBackColor = true;
            this.Opacityy.Click += new System.EventHandler(this.Opacity_Click);
            // 
            // NRF
            // 
            this.NRF.Location = new System.Drawing.Point(12, 41);
            this.NRF.Name = "NRF";
            this.NRF.Size = new System.Drawing.Size(230, 23);
            this.NRF.TabIndex = 4;
            this.NRF.Text = "Non_Rectangle Form";
            this.NRF.UseVisualStyleBackColor = true;
            this.NRF.Click += new System.EventHandler(this.NRF_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 86);
            this.Controls.Add(this.NRF);
            this.Controls.Add(this.Opacityy);
            this.Controls.Add(this.reSize);
            this.Controls.Add(this.borderStyle);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button borderStyle;
        private System.Windows.Forms.Button reSize;
        private System.Windows.Forms.Button Opacityy;
        private System.Windows.Forms.Button NRF;
    }
}

