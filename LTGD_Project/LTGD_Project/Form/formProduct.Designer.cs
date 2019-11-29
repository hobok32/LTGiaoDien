namespace LTGD_Project
{
    partial class formProduct
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
            this.components = new System.ComponentModel.Container();
            this.productTab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBoxCatUpdate = new System.Windows.Forms.ComboBox();
            this.delToppingBtn = new System.Windows.Forms.Button();
            this.smallSizeTxt = new System.Windows.Forms.NumericUpDown();
            this.mediumSizeTxt = new System.Windows.Forms.NumericUpDown();
            this.largeSizeTxt = new System.Windows.Forms.NumericUpDown();
            this.freeSizeTxt = new System.Windows.Forms.NumericUpDown();
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.pictureBoxTopping = new System.Windows.Forms.PictureBox();
            this.addToppingBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.delBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.dataGridViewAllTopping = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBoxProduct = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.rateTxt = new System.Windows.Forms.TextBox();
            this.desTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewTopping = new System.Windows.Forms.DataGridView();
            this.comboBoxCat = new System.Windows.Forms.ComboBox();
            this.searchBtn = new System.Windows.Forms.Button();
            this.searchTxt = new System.Windows.Forms.TextBox();
            this.dataGridViewProduct = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewCat = new System.Windows.Forms.DataGridView();
            this.pictureBoxCat = new System.Windows.Forms.PictureBox();
            this.nameCatTxt = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.addCatBtn = new System.Windows.Forms.Button();
            this.delCatBtn = new System.Windows.Forms.Button();
            this.editCatBtn = new System.Windows.Forms.Button();
            this.uploadImg = new System.Windows.Forms.Button();
            this.pickImgCat = new System.Windows.Forms.Button();
            this.productTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smallSizeTxt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mediumSizeTxt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.largeSizeTxt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.freeSizeTxt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTopping)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllTopping)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTopping)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProduct)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCat)).BeginInit();
            this.SuspendLayout();
            // 
            // productTab
            // 
            this.productTab.AccessibleName = "";
            this.productTab.Controls.Add(this.tabPage1);
            this.productTab.Controls.Add(this.tabPage2);
            this.productTab.Location = new System.Drawing.Point(12, 12);
            this.productTab.Name = "productTab";
            this.productTab.SelectedIndex = 0;
            this.productTab.Size = new System.Drawing.Size(776, 452);
            this.productTab.TabIndex = 0;
            this.productTab.Enter += new System.EventHandler(this.productTab_Enter);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.uploadImg);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.comboBoxCatUpdate);
            this.tabPage1.Controls.Add(this.delToppingBtn);
            this.tabPage1.Controls.Add(this.smallSizeTxt);
            this.tabPage1.Controls.Add(this.mediumSizeTxt);
            this.tabPage1.Controls.Add(this.largeSizeTxt);
            this.tabPage1.Controls.Add(this.freeSizeTxt);
            this.tabPage1.Controls.Add(this.nameTxt);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.pictureBoxTopping);
            this.tabPage1.Controls.Add(this.addToppingBtn);
            this.tabPage1.Controls.Add(this.editBtn);
            this.tabPage1.Controls.Add(this.delBtn);
            this.tabPage1.Controls.Add(this.addBtn);
            this.tabPage1.Controls.Add(this.dataGridViewAllTopping);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.pictureBoxProduct);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.rateTxt);
            this.tabPage1.Controls.Add(this.desTxt);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.dataGridViewTopping);
            this.tabPage1.Controls.Add(this.comboBoxCat);
            this.tabPage1.Controls.Add(this.searchBtn);
            this.tabPage1.Controls.Add(this.searchTxt);
            this.tabPage1.Controls.Add(this.dataGridViewProduct);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 426);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Sản phẩm";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(353, 272);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 13);
            this.label12.TabIndex = 42;
            this.label12.Text = "Loại";
            // 
            // comboBoxCatUpdate
            // 
            this.comboBoxCatUpdate.FormattingEnabled = true;
            this.comboBoxCatUpdate.Location = new System.Drawing.Point(408, 267);
            this.comboBoxCatUpdate.Name = "comboBoxCatUpdate";
            this.comboBoxCatUpdate.Size = new System.Drawing.Size(111, 21);
            this.comboBoxCatUpdate.TabIndex = 11;
            this.comboBoxCatUpdate.SelectedIndexChanged += new System.EventHandler(this.comboBoxCatUpdate_SelectedIndexChanged);
            // 
            // delToppingBtn
            // 
            this.delToppingBtn.Location = new System.Drawing.Point(570, 361);
            this.delToppingBtn.Name = "delToppingBtn";
            this.delToppingBtn.Size = new System.Drawing.Size(192, 63);
            this.delToppingBtn.TabIndex = 18;
            this.delToppingBtn.Text = "XÓA TOPPING";
            this.delToppingBtn.UseVisualStyleBackColor = true;
            this.delToppingBtn.Click += new System.EventHandler(this.delToppingBtn_Click);
            // 
            // smallSizeTxt
            // 
            this.smallSizeTxt.Location = new System.Drawing.Point(408, 58);
            this.smallSizeTxt.Name = "smallSizeTxt";
            this.smallSizeTxt.Size = new System.Drawing.Size(87, 20);
            this.smallSizeTxt.TabIndex = 5;
            // 
            // mediumSizeTxt
            // 
            this.mediumSizeTxt.Location = new System.Drawing.Point(408, 84);
            this.mediumSizeTxt.Name = "mediumSizeTxt";
            this.mediumSizeTxt.Size = new System.Drawing.Size(87, 20);
            this.mediumSizeTxt.TabIndex = 6;
            // 
            // largeSizeTxt
            // 
            this.largeSizeTxt.Location = new System.Drawing.Point(408, 110);
            this.largeSizeTxt.Name = "largeSizeTxt";
            this.largeSizeTxt.Size = new System.Drawing.Size(87, 20);
            this.largeSizeTxt.TabIndex = 7;
            // 
            // freeSizeTxt
            // 
            this.freeSizeTxt.Location = new System.Drawing.Point(408, 136);
            this.freeSizeTxt.Name = "freeSizeTxt";
            this.freeSizeTxt.Size = new System.Drawing.Size(87, 20);
            this.freeSizeTxt.TabIndex = 8;
            // 
            // nameTxt
            // 
            this.nameTxt.Location = new System.Drawing.Point(407, 32);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(140, 20);
            this.nameTxt.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(353, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 13);
            this.label11.TabIndex = 33;
            this.label11.Text = "Tên";
            // 
            // pictureBoxTopping
            // 
            this.pictureBoxTopping.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxTopping.Location = new System.Drawing.Point(219, 296);
            this.pictureBoxTopping.Name = "pictureBoxTopping";
            this.pictureBoxTopping.Size = new System.Drawing.Size(128, 128);
            this.pictureBoxTopping.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxTopping.TabIndex = 32;
            this.pictureBoxTopping.TabStop = false;
            // 
            // addToppingBtn
            // 
            this.addToppingBtn.Location = new System.Drawing.Point(570, 296);
            this.addToppingBtn.Name = "addToppingBtn";
            this.addToppingBtn.Size = new System.Drawing.Size(192, 59);
            this.addToppingBtn.TabIndex = 17;
            this.addToppingBtn.Text = "THÊM TOPPING";
            this.addToppingBtn.UseVisualStyleBackColor = true;
            this.addToppingBtn.Click += new System.EventHandler(this.addToppingBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(687, 267);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(75, 23);
            this.editBtn.TabIndex = 14;
            this.editBtn.Text = "SỬA";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // delBtn
            // 
            this.delBtn.Location = new System.Drawing.Point(606, 267);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(75, 23);
            this.delBtn.TabIndex = 13;
            this.delBtn.Text = "XÓA";
            this.delBtn.UseVisualStyleBackColor = true;
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(525, 267);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 12;
            this.addBtn.Text = "THÊM";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // dataGridViewAllTopping
            // 
            this.dataGridViewAllTopping.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAllTopping.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAllTopping.Location = new System.Drawing.Point(356, 296);
            this.dataGridViewAllTopping.Name = "dataGridViewAllTopping";
            this.dataGridViewAllTopping.ReadOnly = true;
            this.dataGridViewAllTopping.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAllTopping.Size = new System.Drawing.Size(208, 127);
            this.dataGridViewAllTopping.TabIndex = 25;
            this.dataGridViewAllTopping.SelectionChanged += new System.EventHandler(this.dataGridViewAllTopping_SelectionChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(501, 139);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "x 1000đ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(501, 113);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "x 1000đ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(501, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "x 1000đ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(501, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "x 1000đ";
            // 
            // pictureBoxProduct
            // 
            this.pictureBoxProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxProduct.Location = new System.Drawing.Point(553, 32);
            this.pictureBoxProduct.Name = "pictureBoxProduct";
            this.pictureBoxProduct.Size = new System.Drawing.Size(209, 150);
            this.pictureBoxProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProduct.TabIndex = 17;
            this.pictureBoxProduct.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(353, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Đã bán";
            // 
            // rateTxt
            // 
            this.rateTxt.Location = new System.Drawing.Point(407, 162);
            this.rateTxt.Name = "rateTxt";
            this.rateTxt.ReadOnly = true;
            this.rateTxt.Size = new System.Drawing.Size(88, 20);
            this.rateTxt.TabIndex = 9;
            // 
            // desTxt
            // 
            this.desTxt.Location = new System.Drawing.Point(407, 188);
            this.desTxt.Multiline = true;
            this.desTxt.Name = "desTxt";
            this.desTxt.Size = new System.Drawing.Size(355, 73);
            this.desTxt.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(353, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Mô tả";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(353, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Free size";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(353, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Size lớn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(353, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Size vừa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(353, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Size nhỏ";
            // 
            // dataGridViewTopping
            // 
            this.dataGridViewTopping.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTopping.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTopping.Location = new System.Drawing.Point(6, 296);
            this.dataGridViewTopping.Name = "dataGridViewTopping";
            this.dataGridViewTopping.ReadOnly = true;
            this.dataGridViewTopping.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTopping.Size = new System.Drawing.Size(207, 127);
            this.dataGridViewTopping.TabIndex = 4;
            // 
            // comboBoxCat
            // 
            this.comboBoxCat.FormattingEnabled = true;
            this.comboBoxCat.Location = new System.Drawing.Point(6, 5);
            this.comboBoxCat.Name = "comboBoxCat";
            this.comboBoxCat.Size = new System.Drawing.Size(120, 21);
            this.comboBoxCat.TabIndex = 1;
            this.comboBoxCat.SelectedIndexChanged += new System.EventHandler(this.comboBoxCat_SelectedIndexChanged);
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(272, 6);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(75, 20);
            this.searchBtn.TabIndex = 3;
            this.searchBtn.Text = "SEARCH";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // searchTxt
            // 
            this.searchTxt.Location = new System.Drawing.Point(132, 6);
            this.searchTxt.Name = "searchTxt";
            this.searchTxt.Size = new System.Drawing.Size(134, 20);
            this.searchTxt.TabIndex = 2;
            // 
            // dataGridViewProduct
            // 
            this.dataGridViewProduct.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProduct.Location = new System.Drawing.Point(6, 32);
            this.dataGridViewProduct.Name = "dataGridViewProduct";
            this.dataGridViewProduct.ReadOnly = true;
            this.dataGridViewProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProduct.Size = new System.Drawing.Size(341, 258);
            this.dataGridViewProduct.TabIndex = 0;
            this.dataGridViewProduct.SelectionChanged += new System.EventHandler(this.dataGridViewProduct_SelectionChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pickImgCat);
            this.tabPage2.Controls.Add(this.editCatBtn);
            this.tabPage2.Controls.Add(this.delCatBtn);
            this.tabPage2.Controls.Add(this.addCatBtn);
            this.tabPage2.Controls.Add(this.nameCatTxt);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.pictureBoxCat);
            this.tabPage2.Controls.Add(this.dataGridViewCat);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(768, 426);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Danh mục";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Enter += new System.EventHandler(this.tabPage2_Enter);
            // 
            // dataGridViewCat
            // 
            this.dataGridViewCat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCat.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewCat.Name = "dataGridViewCat";
            this.dataGridViewCat.ReadOnly = true;
            this.dataGridViewCat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCat.Size = new System.Drawing.Size(208, 107);
            this.dataGridViewCat.TabIndex = 26;
            this.dataGridViewCat.SelectionChanged += new System.EventHandler(this.dataGridViewCat_SelectionChanged);
            // 
            // pictureBoxCat
            // 
            this.pictureBoxCat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxCat.Location = new System.Drawing.Point(6, 119);
            this.pictureBoxCat.Name = "pictureBoxCat";
            this.pictureBoxCat.Size = new System.Drawing.Size(454, 301);
            this.pictureBoxCat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCat.TabIndex = 27;
            this.pictureBoxCat.TabStop = false;
            // 
            // nameCatTxt
            // 
            this.nameCatTxt.Location = new System.Drawing.Point(274, 6);
            this.nameCatTxt.Name = "nameCatTxt";
            this.nameCatTxt.Size = new System.Drawing.Size(186, 20);
            this.nameCatTxt.TabIndex = 34;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(220, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 13);
            this.label13.TabIndex = 35;
            this.label13.Text = "Tên";
            // 
            // addCatBtn
            // 
            this.addCatBtn.Location = new System.Drawing.Point(223, 32);
            this.addCatBtn.Name = "addCatBtn";
            this.addCatBtn.Size = new System.Drawing.Size(75, 23);
            this.addCatBtn.TabIndex = 36;
            this.addCatBtn.Text = "THÊM";
            this.addCatBtn.UseVisualStyleBackColor = true;
            // 
            // delCatBtn
            // 
            this.delCatBtn.Location = new System.Drawing.Point(304, 32);
            this.delCatBtn.Name = "delCatBtn";
            this.delCatBtn.Size = new System.Drawing.Size(75, 23);
            this.delCatBtn.TabIndex = 37;
            this.delCatBtn.Text = "XÓA";
            this.delCatBtn.UseVisualStyleBackColor = true;
            // 
            // editCatBtn
            // 
            this.editCatBtn.Location = new System.Drawing.Point(385, 32);
            this.editCatBtn.Name = "editCatBtn";
            this.editCatBtn.Size = new System.Drawing.Size(75, 23);
            this.editCatBtn.TabIndex = 38;
            this.editCatBtn.Text = "SỬA";
            this.editCatBtn.UseVisualStyleBackColor = true;
            // 
            // uploadImg
            // 
            this.uploadImg.Location = new System.Drawing.Point(501, 162);
            this.uploadImg.Name = "uploadImg";
            this.uploadImg.Size = new System.Drawing.Size(46, 20);
            this.uploadImg.TabIndex = 43;
            this.uploadImg.Text = "PICK";
            this.uploadImg.UseVisualStyleBackColor = true;
            // 
            // pickImgCat
            // 
            this.pickImgCat.Location = new System.Drawing.Point(223, 61);
            this.pickImgCat.Name = "pickImgCat";
            this.pickImgCat.Size = new System.Drawing.Size(237, 52);
            this.pickImgCat.TabIndex = 39;
            this.pickImgCat.Text = "PICK";
            this.pickImgCat.UseVisualStyleBackColor = true;
            // 
            // formProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 476);
            this.Controls.Add(this.productTab);
            this.MaximizeBox = false;
            this.Name = "formProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý sản phẩm";
            this.productTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smallSizeTxt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mediumSizeTxt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.largeSizeTxt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.freeSizeTxt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTopping)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllTopping)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTopping)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProduct)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl productTab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.DataGridView dataGridViewAllTopping;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBoxProduct;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox rateTxt;
        private System.Windows.Forms.TextBox desTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewTopping;
        private System.Windows.Forms.ComboBox comboBoxCat;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.TextBox searchTxt;
        private System.Windows.Forms.DataGridView dataGridViewProduct;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button delBtn;
        private System.Windows.Forms.Button addToppingBtn;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.PictureBox pictureBoxTopping;
        private System.Windows.Forms.TextBox nameTxt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown smallSizeTxt;
        private System.Windows.Forms.NumericUpDown mediumSizeTxt;
        private System.Windows.Forms.NumericUpDown largeSizeTxt;
        private System.Windows.Forms.NumericUpDown freeSizeTxt;
        private System.Windows.Forms.Button delToppingBtn;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBoxCatUpdate;
        private System.Windows.Forms.PictureBox pictureBoxCat;
        private System.Windows.Forms.DataGridView dataGridViewCat;
        private System.Windows.Forms.Button uploadImg;
        private System.Windows.Forms.Button editCatBtn;
        private System.Windows.Forms.Button delCatBtn;
        private System.Windows.Forms.Button addCatBtn;
        private System.Windows.Forms.TextBox nameCatTxt;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button pickImgCat;
    }
}