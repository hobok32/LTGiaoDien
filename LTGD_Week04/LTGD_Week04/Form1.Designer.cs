namespace LTGD_Week04
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.msKH = new System.Windows.Forms.TextBox();
            this.hoTen = new System.Windows.Forms.TextBox();
            this.diaChi = new System.Windows.Forms.TextBox();
            this.dki = new System.Windows.Forms.Button();
            this.nhapMoi = new System.Windows.Forms.Button();
            this.tongKet = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.domainUpDown1 = new System.Windows.Forms.DomainUpDown();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-3, -4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(805, 93);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(50, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(719, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "COOP MARK - ĐĂNG KÝ KHÁCH HÀNG VIP ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "MS Khách hàng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Họ và tên";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ngày";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Địa chỉ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(51, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Nghề nghiệp";
            // 
            // msKH
            // 
            this.msKH.Location = new System.Drawing.Point(147, 118);
            this.msKH.Name = "msKH";
            this.msKH.Size = new System.Drawing.Size(156, 20);
            this.msKH.TabIndex = 6;
            this.msKH.TextChanged += new System.EventHandler(this.msKH_TextChanged);
            // 
            // hoTen
            // 
            this.hoTen.Location = new System.Drawing.Point(147, 144);
            this.hoTen.Name = "hoTen";
            this.hoTen.Size = new System.Drawing.Size(156, 20);
            this.hoTen.TabIndex = 7;
            this.hoTen.TextChanged += new System.EventHandler(this.msKH_TextChanged);
            // 
            // diaChi
            // 
            this.diaChi.Location = new System.Drawing.Point(147, 196);
            this.diaChi.Name = "diaChi";
            this.diaChi.Size = new System.Drawing.Size(410, 20);
            this.diaChi.TabIndex = 9;
            this.diaChi.TextChanged += new System.EventHandler(this.msKH_TextChanged);
            // 
            // dki
            // 
            this.dki.Location = new System.Drawing.Point(147, 248);
            this.dki.Name = "dki";
            this.dki.Size = new System.Drawing.Size(75, 23);
            this.dki.TabIndex = 11;
            this.dki.Text = "Đăng ký";
            this.dki.UseVisualStyleBackColor = true;
            this.dki.Click += new System.EventHandler(this.dki_Click);
            // 
            // nhapMoi
            // 
            this.nhapMoi.Location = new System.Drawing.Point(228, 248);
            this.nhapMoi.Name = "nhapMoi";
            this.nhapMoi.Size = new System.Drawing.Size(75, 23);
            this.nhapMoi.TabIndex = 12;
            this.nhapMoi.Text = "Nhập mới";
            this.nhapMoi.UseVisualStyleBackColor = true;
            this.nhapMoi.Click += new System.EventHandler(this.nhapMoi_Click);
            // 
            // tongKet
            // 
            this.tongKet.Location = new System.Drawing.Point(309, 248);
            this.tongKet.Name = "tongKet";
            this.tongKet.Size = new System.Drawing.Size(75, 23);
            this.tongKet.TabIndex = 13;
            this.tongKet.Text = "Tổng kết";
            this.tongKet.UseVisualStyleBackColor = true;
            this.tongKet.Click += new System.EventHandler(this.tongKet_Click);
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(390, 248);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(75, 23);
            this.exit.TabIndex = 14;
            this.exit.Text = "Thoát";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(147, 170);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(100, 20);
            this.numericUpDown1.TabIndex = 15;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.msKH_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(253, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Tháng";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(294, 170);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(100, 20);
            this.numericUpDown2.TabIndex = 17;
            this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(400, 173);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Năm sinh";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(457, 170);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            2019,
            0,
            0,
            0});
            this.numericUpDown3.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(100, 20);
            this.numericUpDown3.TabIndex = 19;
            this.numericUpDown3.Value = new decimal(new int[] {
            1998,
            0,
            0,
            0});
            this.numericUpDown3.ValueChanged += new System.EventHandler(this.msKH_TextChanged);
            // 
            // domainUpDown1
            // 
            this.domainUpDown1.Items.Add("Bác sĩ");
            this.domainUpDown1.Items.Add("Công nhân");
            this.domainUpDown1.Items.Add("Giáo viên");
            this.domainUpDown1.Items.Add("Hướng dẫn viên du lịch");
            this.domainUpDown1.Items.Add("Nhân viên VP");
            this.domainUpDown1.Items.Add("Thông dịch viên");
            this.domainUpDown1.Items.Add("Y tá");
            this.domainUpDown1.Location = new System.Drawing.Point(147, 222);
            this.domainUpDown1.Name = "domainUpDown1";
            this.domainUpDown1.Size = new System.Drawing.Size(156, 20);
            this.domainUpDown1.TabIndex = 20;
            this.domainUpDown1.Text = "Bác sĩ";
            this.domainUpDown1.TextChanged += new System.EventHandler(this.msKH_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.domainUpDown1);
            this.Controls.Add(this.numericUpDown3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.tongKet);
            this.Controls.Add(this.nhapMoi);
            this.Controls.Add(this.dki);
            this.Controls.Add(this.diaChi);
            this.Controls.Add(this.hoTen);
            this.Controls.Add(this.msKH);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox msKH;
        private System.Windows.Forms.TextBox hoTen;
        private System.Windows.Forms.TextBox diaChi;
        private System.Windows.Forms.Button dki;
        private System.Windows.Forms.Button nhapMoi;
        private System.Windows.Forms.Button tongKet;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.DomainUpDown domainUpDown1;
    }
}

