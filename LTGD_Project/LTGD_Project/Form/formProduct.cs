using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using LTGD_Project.DTO;
using LTGD_Project.DAO;
using LTGD_Project.BUS;
using System.Net;

namespace LTGD_Project
{
    public partial class formProduct : Form
    {
        List<ProductTopping> productToppings;
        int Id = 0;
        int check = 0;
        int idCat = 0;
        int idTopping = 0;
        int idProduct = 0;
        string name = "";
        public formProduct()
        {
            InitializeComponent();
            LoadCategory();
            LoadAllTopping();
        }

        //Hiển thị tất cả topping
        void LoadAllTopping()
        {
            dataGridViewAllTopping.DataSource = new GlobalDAO().SelectAllTopping();
            dataGridViewAllTopping.Columns[0].Visible = false;
            dataGridViewAllTopping.Columns[1].Visible = false;
            dataGridViewAllTopping.Columns[2].HeaderText = "Tên Topping";
            dataGridViewAllTopping.Columns[3].Visible = false;
            dataGridViewAllTopping.Columns[4].Visible = false;
            dataGridViewAllTopping.Columns[5].Visible = false;
            dataGridViewAllTopping.Columns[6].HeaderText = "Giá";
            dataGridViewAllTopping.Columns[7].Visible = false;
            dataGridViewAllTopping.Columns[8].Visible = false;
            dataGridViewAllTopping.Columns[9].Visible = false;
            dataGridViewAllTopping.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        //Hiển thị category
        void LoadCategory()
        {
            if (check == 0)
            {
                List<Category> cats = CategoryDAO.Instance.SelectAllCat();
                comboBoxCat.DataSource = cats;
                comboBoxCat.DisplayMember = "nameCat";
                check = 1;
            }
        }

        //Event khi comboBoxCategory được chọn
        private void comboBoxCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox combo = sender as ComboBox;

            if (combo.SelectedItem == null)
                return;
            Category selected = combo.SelectedItem as Category;
            id = selected.IdCat;
            idCat = selected.IdCat;
            if (id != Id)
            {
                //GetCatProToppingByIdCat
                GetCatProToppingByIdCat(id);
            }
        }

        void GetCatProToppingByIdCat(int id)
        {
            List<ProductTopping> ProductToppings = new CatProToppingBUS().SelectProductTopping(id);
            productToppings = ProductToppings;
            bindingSource1.DataSource = productToppings;
            LoadListProduct();
            Id = id;
        }

        //Hiển thị sản phẩm trên grid
        void LoadListProduct()
        {
            dataGridViewProduct.DataSource = bindingSource1.DataSource;
            dataGridViewProduct.Columns[0].HeaderText = "ID";
            dataGridViewProduct.Columns[1].Visible = false;
            dataGridViewProduct.Columns[2].HeaderText = "Tên sản phẩm";
            dataGridViewProduct.Columns[3].Visible = false;
            dataGridViewProduct.Columns[4].Visible = false;
            dataGridViewProduct.Columns[5].Visible = false;
            dataGridViewProduct.Columns[6].Visible = false;
            dataGridViewProduct.Columns[7].Visible = false;
            dataGridViewProduct.Columns[8].Visible = false;
            dataGridViewProduct.Columns[9].HeaderText = "Đã bán";
            dataGridViewProduct.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            BindingProduct();
        }

        //Hiển thị topping trên grid của sản phẩm tương ứng
        void LoadListTopping(int id)
        {
            for (int i = 0; i < productToppings.Count(); i++)
            {
                if (productToppings[i].IdProduct == id)
                {
                    dataGridViewTopping.DataSource = productToppings[i].Topping;
                    dataGridViewTopping.Columns[0].Visible = false;
                    dataGridViewTopping.Columns[1].HeaderText = "Tên Topping";
                    dataGridViewTopping.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridViewTopping.Columns[2].HeaderText = "Giá";
                    dataGridViewTopping.Columns[3].Visible = false;
                }
            }
            return;
        }

        //Bindingsource
        void BindingProduct()
        {
            nameTxt.DataBindings.Clear();
            nameTxt.DataBindings.Add(new Binding("Text", dataGridViewProduct.DataSource, "nameProduct"));

            smallSizeTxt.DataBindings.Clear();
            smallSizeTxt.DataBindings.Add(new Binding("Value", dataGridViewProduct.DataSource, "priceSmallProduct",true));

            mediumSizeTxt.DataBindings.Clear();
            mediumSizeTxt.DataBindings.Add(new Binding("Value", dataGridViewProduct.DataSource, "priceMediumProduct", true));

            largeSizeTxt.DataBindings.Clear();
            largeSizeTxt.DataBindings.Add(new Binding("Value", dataGridViewProduct.DataSource, "priceLargeProduct", true));

            freeSizeTxt.DataBindings.Clear();
            freeSizeTxt.DataBindings.Add(new Binding("Value", dataGridViewProduct.DataSource, "priceProduct",true));

            desTxt.DataBindings.Clear();
            desTxt.DataBindings.Add(new Binding("Text", dataGridViewProduct.DataSource, "descriptionProduct"));

            rateTxt.DataBindings.Clear();
            rateTxt.DataBindings.Add(new Binding("Text", dataGridViewProduct.DataSource, "rating"));
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewProduct_SelectionChanged(object sender, EventArgs e)
        {
            int id = (int)dataGridViewProduct.CurrentRow.Cells[0].Value;
            idProduct = id;
            string img = dataGridViewProduct.CurrentRow.Cells[8].Value.ToString();
            var request = WebRequest.Create(img);
            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                pictureBoxProduct.Image = Bitmap.FromStream(stream);
            }
            LoadListTopping(id);
        }

        private void dataGridViewAllTopping_SelectionChanged(object sender, EventArgs e)
        {
            idTopping = (int)dataGridViewAllTopping.CurrentRow.Cells[0].Value;
            name = dataGridViewAllTopping.CurrentRow.Cells[2].Value.ToString();
            string img = dataGridViewAllTopping.CurrentRow.Cells[8].Value.ToString();
            var request = WebRequest.Create(img);
            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                pictureBoxTopping.Image = Bitmap.FromStream(stream);
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            string img = "https://www.cohindia.com/wp-content/uploads/2018/06/Worship-Mumbai.jpeg";
            AddNewProduct(nameTxt.Text.Trim(), (int)smallSizeTxt.Value, (int)mediumSizeTxt.Value, (int)largeSizeTxt.Value, (int)freeSizeTxt.Value, desTxt.Text.Trim(), img, idCat);
        }

        void AddNewProduct(string name, int priceSmall, int priceMedium, int priceLarge, int price, string description, string img, int idCat)
        {
            if (name == "" || (priceSmall == 0 && priceMedium == 0 && priceLarge == 0 && price == 0) || description == "")
            {
                MessageBox.Show("Xin mời nhập đủ thông tin", "Thông báo");
            }
            else
            {
                if (price != 0 && (priceSmall == 0 && priceMedium == 0 && priceLarge == 0))
                {
                    if (MessageBox.Show("Bạn đã chắc chắn muốn thêm "+ name +" chưa?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        if (ProductDAO.Instance.AddProduct(idCat, name, (int?)priceSmall, (int?)priceMedium, (int?)priceLarge, (int?)price, description, img))
                        {
                            GetCatProToppingByIdCat(idCat);
                            if (idCat == 7)
                                LoadAllTopping();
                            MessageBox.Show("Thêm sản phẩm thành công", "Thông báo");
                        }
                        else
                            MessageBox.Show("Thất bại rùi :(", "Thông báo");
                    }
                }
                else if (price == 0 && (priceSmall != 0 || priceMedium != 0 || priceLarge != 0))
                {
                    if (MessageBox.Show("Bạn đã chắc chắn muốn thêm " + name + " chưa?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        if (ProductDAO.Instance.AddProduct(idCat, name, (int?)priceSmall, (int?)priceMedium, (int?)priceLarge, (int?)price, description, img))
                        {
                            GetCatProToppingByIdCat(idCat);
                            if (idCat == 7)
                                LoadAllTopping();
                            MessageBox.Show("Thêm sản phẩm thành công", "Thông báo");
                        }
                        else
                            MessageBox.Show("Thất bại rùi :(", "Thông báo");
                    }
                }
                else
                {
                    MessageBox.Show("Sản phẩm FreeSize sẽ không có 3 size còn lại", "Thông báo");
                }
            }
        }

        private void addToppingBtn_Click(object sender, EventArgs e)
        {
            if (idProduct != 0)
            {
                if (idTopping != 0)
                    AddNewTopping(idProduct,idTopping, idCat, name);
                else
                    MessageBox.Show("Xin mời chọn topping để thêm", "Thông báo");
            }
            else
                MessageBox.Show("Xin mời chọn sản phẩm", "Thông báo");
        }

        void AddNewTopping(int idProduct, int idTopping, int idCat, string name)
        {
            if (MessageBox.Show("Bạn đã chắc chắn muốn thêm topping " + name + " chưa?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (idCat != 7)
                {
                    bool result = new GlobalDAO().AddNewTopping(idProduct, idTopping);
                    if (result)
                    {
                        GetCatProToppingByIdCat(idCat);
                        idTopping = 0;
                        name = "";
                        MessageBox.Show("Thêm topping thành công", "Thông báo");
                    }
                }
                else
                    MessageBox.Show("Không thể thêm topping cho topping :3", "Thông báo");
            }
        }

        private void delToppingBtn_Click(object sender, EventArgs e)
        {
            if (idProduct != 0)
            {
                if (idTopping != 0)
                    DelTopping(idProduct, idTopping, idCat, name);
                else
                    MessageBox.Show("Xin mời chọn topping để xóa", "Thông báo");
            }
            else
                MessageBox.Show("Xin mời chọn sản phẩm", "Thông báo");
        }

        void DelTopping(int idProduct, int idTopping, int idCat, string name)
        {
            if (MessageBox.Show("Bạn đã chắc chắn muốn xóa topping " + name + " chưa?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (idCat != 7)
                {
                    bool result = new GlobalDAO().DelTopping(idProduct, idTopping);
                    if (result)
                    {
                        GetCatProToppingByIdCat(idCat);
                        idTopping = 0;
                        name = "";
                        MessageBox.Show("Xóa topping thành công", "Thông báo");
                    }
                }
                else
                    MessageBox.Show("Tại sao dòng này lại xuất hiện?!? :3", "Thông báo");
            }
        }
    }
}
