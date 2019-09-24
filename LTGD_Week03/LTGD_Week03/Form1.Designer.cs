namespace LTGD_Week03
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.text = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.boldanditalic = new System.Windows.Forms.CheckBox();
            this.italic = new System.Windows.Forms.CheckBox();
            this.bold = new System.Windows.Forms.CheckBox();
            this.regular = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.blue = new System.Windows.Forms.CheckBox();
            this.green = new System.Windows.Forms.CheckBox();
            this.red = new System.Windows.Forms.CheckBox();
            this.auto = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.left = new System.Windows.Forms.CheckBox();
            this.right = new System.Windows.Forms.CheckBox();
            this.center = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.exit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.text);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Location = new System.Drawing.Point(151, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(569, 88);
            this.panel1.TabIndex = 0;
            // 
            // text
            // 
            this.text.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.text.Location = new System.Drawing.Point(0, 29);
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(569, 37);
            this.text.TabIndex = 0;
            this.text.Text = "Trung tâm đào tạo tin học TPHCM";
            this.text.Click += new System.EventHandler(this.text_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(296, 94);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(142, 151);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Font Style";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.boldanditalic);
            this.groupBox1.Controls.Add(this.italic);
            this.groupBox1.Controls.Add(this.bold);
            this.groupBox1.Controls.Add(this.regular);
            this.groupBox1.Location = new System.Drawing.Point(151, 120);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(142, 112);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Font Style";
            // 
            // boldanditalic
            // 
            this.boldanditalic.AutoSize = true;
            this.boldanditalic.Location = new System.Drawing.Point(6, 89);
            this.boldanditalic.Name = "boldanditalic";
            this.boldanditalic.Size = new System.Drawing.Size(93, 17);
            this.boldanditalic.TabIndex = 3;
            this.boldanditalic.Text = "Bold and Italic";
            this.boldanditalic.UseVisualStyleBackColor = true;
            this.boldanditalic.CheckedChanged += new System.EventHandler(this.boldanditalic_CheckedChanged);
            this.boldanditalic.Click += new System.EventHandler(this.boldanditalic_Click);
            // 
            // italic
            // 
            this.italic.AutoSize = true;
            this.italic.Location = new System.Drawing.Point(6, 66);
            this.italic.Name = "italic";
            this.italic.Size = new System.Drawing.Size(48, 17);
            this.italic.TabIndex = 2;
            this.italic.Text = "Italic";
            this.italic.UseVisualStyleBackColor = true;
            this.italic.CheckedChanged += new System.EventHandler(this.italic_CheckedChanged);
            this.italic.Click += new System.EventHandler(this.italic_Click);
            // 
            // bold
            // 
            this.bold.AutoSize = true;
            this.bold.Location = new System.Drawing.Point(6, 43);
            this.bold.Name = "bold";
            this.bold.Size = new System.Drawing.Size(47, 17);
            this.bold.TabIndex = 1;
            this.bold.Text = "Bold";
            this.bold.UseVisualStyleBackColor = true;
            this.bold.CheckedChanged += new System.EventHandler(this.bold_CheckedChanged);
            this.bold.Click += new System.EventHandler(this.bold_Click);
            // 
            // regular
            // 
            this.regular.AutoSize = true;
            this.regular.Location = new System.Drawing.Point(6, 20);
            this.regular.Name = "regular";
            this.regular.Size = new System.Drawing.Size(63, 17);
            this.regular.TabIndex = 0;
            this.regular.Text = "Regular";
            this.regular.UseVisualStyleBackColor = true;
            this.regular.CheckedChanged += new System.EventHandler(this.regular_CheckedChanged);
            this.regular.Click += new System.EventHandler(this.regular_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.blue);
            this.groupBox2.Controls.Add(this.green);
            this.groupBox2.Controls.Add(this.red);
            this.groupBox2.Controls.Add(this.auto);
            this.groupBox2.Location = new System.Drawing.Point(299, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(142, 112);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Color";
            // 
            // blue
            // 
            this.blue.AutoSize = true;
            this.blue.Location = new System.Drawing.Point(7, 89);
            this.blue.Name = "blue";
            this.blue.Size = new System.Drawing.Size(47, 17);
            this.blue.TabIndex = 3;
            this.blue.Text = "Blue";
            this.blue.UseVisualStyleBackColor = true;
            this.blue.Click += new System.EventHandler(this.blue_Click);
            // 
            // green
            // 
            this.green.AutoSize = true;
            this.green.Location = new System.Drawing.Point(7, 66);
            this.green.Name = "green";
            this.green.Size = new System.Drawing.Size(55, 17);
            this.green.TabIndex = 2;
            this.green.Text = "Green";
            this.green.UseVisualStyleBackColor = true;
            this.green.Click += new System.EventHandler(this.green_Click);
            // 
            // red
            // 
            this.red.AutoSize = true;
            this.red.Location = new System.Drawing.Point(7, 43);
            this.red.Name = "red";
            this.red.Size = new System.Drawing.Size(46, 17);
            this.red.TabIndex = 1;
            this.red.Text = "Red";
            this.red.UseVisualStyleBackColor = true;
            this.red.CheckedChanged += new System.EventHandler(this.red_CheckedChanged);
            this.red.Click += new System.EventHandler(this.red_Click);
            // 
            // auto
            // 
            this.auto.AutoSize = true;
            this.auto.Location = new System.Drawing.Point(7, 20);
            this.auto.Name = "auto";
            this.auto.Size = new System.Drawing.Size(48, 17);
            this.auto.TabIndex = 0;
            this.auto.Text = "Auto";
            this.auto.UseVisualStyleBackColor = true;
            this.auto.Click += new System.EventHandler(this.auto_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.left);
            this.groupBox4.Controls.Add(this.right);
            this.groupBox4.Controls.Add(this.center);
            this.groupBox4.Location = new System.Drawing.Point(453, 120);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(142, 112);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Text Align";
            // 
            // left
            // 
            this.left.AutoSize = true;
            this.left.Location = new System.Drawing.Point(6, 20);
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(44, 17);
            this.left.TabIndex = 4;
            this.left.Text = "Left";
            this.left.UseVisualStyleBackColor = true;
            this.left.Click += new System.EventHandler(this.left_Click);
            // 
            // right
            // 
            this.right.AutoSize = true;
            this.right.Location = new System.Drawing.Point(6, 43);
            this.right.Name = "right";
            this.right.Size = new System.Drawing.Size(51, 17);
            this.right.TabIndex = 5;
            this.right.Text = "Right";
            this.right.UseVisualStyleBackColor = true;
            this.right.Click += new System.EventHandler(this.right_Click);
            // 
            // center
            // 
            this.center.AutoSize = true;
            this.center.Location = new System.Drawing.Point(6, 66);
            this.center.Name = "center";
            this.center.Size = new System.Drawing.Size(57, 17);
            this.center.TabIndex = 6;
            this.center.Text = "Center";
            this.center.UseVisualStyleBackColor = true;
            this.center.Click += new System.EventHandler(this.center_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(601, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Font Size:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(604, 139);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(116, 20);
            this.numericUpDown1.TabIndex = 8;
            this.numericUpDown1.Value = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // exit
            // 
            this.exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.exit.Location = new System.Drawing.Point(604, 165);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(116, 61);
            this.exit.TabIndex = 9;
            this.exit.Text = "EXIT";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 438);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label text;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox boldanditalic;
        private System.Windows.Forms.CheckBox italic;
        private System.Windows.Forms.CheckBox bold;
        private System.Windows.Forms.CheckBox regular;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox blue;
        private System.Windows.Forms.CheckBox green;
        private System.Windows.Forms.CheckBox red;
        private System.Windows.Forms.CheckBox auto;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox left;
        private System.Windows.Forms.CheckBox right;
        private System.Windows.Forms.CheckBox center;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button exit;
    }
}

