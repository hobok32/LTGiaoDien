using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LTGD_ThuyetTrinh
{
    public partial class Form1 : Form
    {
        bool active = false;
        LTWdemo2Entities2 db = new LTWdemo2Entities2();
        List<ProductLocal> pros = new DAO().SelectAllProduct();
        public Form1()
        {
            InitializeComponent();
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            id.Enabled = false;
            bindingSource1.DataSource = db.SanPham.ToList();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CreateImageList(imageList1, pros);
            LoadListView(pros);
            LoadTreeView(pros);
            LoadComboBox();
        }

        void CreateImageList(ImageList imgList, List<ProductLocal> pros)
        {
            for(int i = 0; i < 40; i++)
            {
                System.Net.WebRequest request = System.Net.WebRequest.Create(pros[i].ImgProduct);
                System.Net.WebResponse resp = request.GetResponse();
                System.IO.Stream respStream = resp.GetResponseStream();
                Bitmap bmp = new Bitmap(respStream);
                respStream.Dispose();
                imgList.Images.Add(bmp);
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (active == false)
                MessageBox.Show("Xin mời chọn loại thức uống!");
            else
            {
                OK.Enabled = false;
                LoadListBox(pros, comboBox1.SelectedIndex);
            }
        }

        void LoadListBox(List<ProductLocal> pros, int index)
        {
            for (int i = 0; i < pros.Count(); i++)
            {
                if (pros[i].IdCat == index+1)
                {
                    listBox1.Items.Add(pros[i].IdProduct + " | " + pros[i].NameProduct);
                }
            }
            OK.Enabled = true;
        }

        void LoadComboBox()
        {
            comboBox1.Items.Add("Cà phê");
            comboBox1.Items.Add("Đá Xay");
            comboBox1.Items.Add("Trà trái cây");
            comboBox1.Items.Add("Sinh tố");
            comboBox1.Items.Add("Macchiato");
            comboBox1.Items.Add("Khác");
            comboBox1.Items.Add("Topping");
            comboBox1.Items.Add("Snack");
        }

        void LoadListView(List<ProductLocal> pros)
        {
            for (int i = 0; i < 40; i++)
            {
                ListViewItem item = new ListViewItem() { Text = pros[i].NameProduct, ImageIndex=i };
                item.SubItems.Add(pros[i].IdProduct.ToString());
                item.SubItems.Add(pros[i].DescriptionProduct);
                listView1.Items.Add(item);
            }
        }

        void LoadTreeView(List<ProductLocal> pros)
        {
            treeView2.NodeMouseClick += TreeView2_NodeMouseClick;
            for (int i = 0; i < 40;i++ )
            {
                TreeNode node = new TreeNode() { Text = pros[i].NameProduct, ImageIndex = i, SelectedImageIndex = i };
                node.Nodes.Add(pros[i].IdProduct.ToString(), "ID: " + pros[i].IdProduct.ToString(), i, i);
                node.Nodes.Add(pros[i].DescriptionProduct,"Loại: "+ pros[i].DescriptionProduct, i, i);
                node.ImageIndex = i;
                treeView2.Nodes.Add(node);
            }
        }

        private void TreeView2_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            SanPham sp = bindingSource1.Current as SanPham;
            db.SanPham.Remove(sp);
            db.SaveChanges();
            bindingSource1.RemoveCurrent();
        }

        private void save_Click(object sender, EventArgs e)
        {
            SanPham sp = bindingSource1.Current as SanPham;
            if (sp.IdSp == 0)
                db.SanPham.Add(sp);
            else
                db.Entry(sp).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            id.Text = sp.IdSp.ToString();
            MessageBox.Show("OK");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView1.View = View.Details;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.View = View.LargeIcon;
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if(active==false)
                active = true;
            return;
        }
    }
}
