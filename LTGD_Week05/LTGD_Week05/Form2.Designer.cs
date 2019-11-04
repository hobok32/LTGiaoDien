namespace LTGD_Week05
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.start = new System.Windows.Forms.Button();
            this.end = new System.Windows.Forms.Button();
            this.timeStart = new System.Windows.Forms.TextBox();
            this.timeEnd = new System.Windows.Forms.TextBox();
            this.stop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Máy 1";
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(12, 25);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 1;
            this.start.Text = "Bat dau";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // end
            // 
            this.end.Location = new System.Drawing.Point(12, 54);
            this.end.Name = "end";
            this.end.Size = new System.Drawing.Size(75, 23);
            this.end.TabIndex = 2;
            this.end.Text = "Ket thuc";
            this.end.UseVisualStyleBackColor = true;
            this.end.Click += new System.EventHandler(this.end_Click);
            // 
            // timeStart
            // 
            this.timeStart.Location = new System.Drawing.Point(93, 27);
            this.timeStart.Name = "timeStart";
            this.timeStart.Size = new System.Drawing.Size(168, 20);
            this.timeStart.TabIndex = 3;
            // 
            // timeEnd
            // 
            this.timeEnd.Location = new System.Drawing.Point(93, 56);
            this.timeEnd.Name = "timeEnd";
            this.timeEnd.Size = new System.Drawing.Size(168, 20);
            this.timeEnd.TabIndex = 4;
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(12, 83);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(249, 23);
            this.stop.TabIndex = 5;
            this.stop.Text = "Dung chuong trinh";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 116);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.timeEnd);
            this.Controls.Add(this.timeStart);
            this.Controls.Add(this.end);
            this.Controls.Add(this.start);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button end;
        private System.Windows.Forms.TextBox timeStart;
        private System.Windows.Forms.TextBox timeEnd;
        private System.Windows.Forms.Button stop;
    }
}