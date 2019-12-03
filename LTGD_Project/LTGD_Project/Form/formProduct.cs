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
using System.IO;
using System.Drawing.Imaging;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace LTGD_Project
{
    public partial class formProduct : Form
    {

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "dHDi653cpD0hHaOOrAwgtlTahn7FC9ZBhYoDjeWV",
            BasePath = "https://cafe-4b7dd.firebaseio.com/"
        };

        IFirebaseClient client;

        List<ProductTopping> productToppings;
        string img = "https://www.cohindia.com/wp-content/uploads/2018/06/Worship-Mumbai.jpeg";
        int Id = 0;
        int check = 0;
        int idCat = 0;
        int idCatUpdate = 0;
        int idTopping = 0;
        int idProduct = 0;
        string name = "";
        string namePro = "";
        string nameCat = "";
        string nameCatEdit = "";
        int idCatEdit = 0;
        string imgCat = "https://www.cohindia.com/wp-content/uploads/2018/06/Worship-Mumbai.jpeg";
        List<Category> catsCheck;
        public formProduct()
        {
            InitializeComponent();
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
                catsCheck = cats;
                comboBoxCat.DataSource = cats;
                comboBoxCat.DisplayMember = "nameCat";
                check = 1;
            }
        }

        void LoadCategoryGrid()
        {
            List<Category> cats = CategoryDAO.Instance.SelectAllCat();
            dataGridViewCat.DataSource = cats;
            dataGridViewCat.Columns[0].HeaderText = "ID";
            dataGridViewCat.Columns[1].HeaderText = "Tên Category";
            dataGridViewCat.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCat.Columns[2].Visible = false;

            nameCatTxt.DataBindings.Clear();
            nameCatTxt.DataBindings.Add(new Binding("Text", dataGridViewCat.DataSource, "nameCat"));
        }

        void LoadCategoryUpdate()
        {
            List<Category> cats = CategoryDAO.Instance.SelectAllCat();
            comboBoxCatUpdate.DataSource = cats;
            comboBoxCatUpdate.DisplayMember = "nameCat";
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

        private void dataGridViewAllTopping_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                idTopping = (int)dataGridViewAllTopping.CurrentRow.Cells[0].Value;
                name = dataGridViewAllTopping.CurrentRow.Cells[2].Value.ToString();
                string img = dataGridViewAllTopping.CurrentRow.Cells[8].Value.ToString();
                if (img.Substring(0, 4) == "http")
                {
                    var request = WebRequest.Create(img);
                    using (var response = request.GetResponse())
                    using (var stream = response.GetResponseStream())
                    {
                        pictureBoxTopping.Image = Bitmap.FromStream(stream);
                    }
                }
                else
                {
                    byte[] b = Convert.FromBase64String(img);

                    MemoryStream memoryStream = new MemoryStream();
                    memoryStream.Write(b, 0, Convert.ToInt32(b.Length));

                    Bitmap bm = new Bitmap(memoryStream, false);
                    memoryStream.Dispose();
                    pictureBoxTopping.Image = bm;
                }
            }
            catch
            {

            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            AddNewProduct(nameTxt.Text.Trim(), (int)smallSizeTxt.Value, (int)mediumSizeTxt.Value, (int)largeSizeTxt.Value, (int)freeSizeTxt.Value, desTxt.Text.Trim(), img, idCat, idCatUpdate);
        }

        void AddNewProduct(string name, int priceSmall, int priceMedium, int priceLarge, int price, string description, string img, int idCat, int idCatUpdate)
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
                        bool result = new ProductBUS().AddProduct(idCatUpdate, name, (int?)priceSmall, (int?)priceMedium, (int?)priceLarge, (int?)price, description, img);
                        if (result)
                        {
                            GetCatProToppingByIdCat(idCatUpdate);
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
                        bool result = new ProductBUS().AddProduct(idCatUpdate, name, (int?)priceSmall, (int?)priceMedium, (int?)priceLarge, (int?)price, description, img);
                        if (result)
                        {
                            GetCatProToppingByIdCat(idCatUpdate);
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
                    AddNewTopping(idProduct, idTopping, idCat, name);
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

        private void delBtn_Click(object sender, EventArgs e)
        {
            if (idProduct != 0)
            {
                DelProduct(idProduct, namePro, idCat);
            }
            else
                MessageBox.Show("Xin mời chọn sản phẩm", "Thông báo");
        }

        void DelProduct(int idProduct, string name, int idCat)
        {
            if (MessageBox.Show("Bạn đã chắc chắn muốn xóa " + name + " chưa?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                bool result = new ProductBUS().DelProduct(idProduct);
                if (result)
                {
                    GetCatProToppingByIdCat(idCat);
                    namePro = "";
                    MessageBox.Show("Xóa thành công :3", "Thông báo");
                }
                else
                    MessageBox.Show("Xóa thất bại :(", "Thông báo");
            }
        }

        private void comboBoxCatUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = sender as ComboBox;
            if (combo.SelectedItem == null)
                return;
            Category selected = combo.SelectedItem as Category;
            idCatUpdate = selected.IdCat;
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            UpdateProduct(nameTxt.Text.Trim(), (int)smallSizeTxt.Value, (int)mediumSizeTxt.Value, (int)largeSizeTxt.Value, (int)freeSizeTxt.Value, desTxt.Text.Trim(), img, idCat, idCatUpdate, idProduct);
        }

        void UpdateProduct(string name, int priceSmall, int priceMedium, int priceLarge, int price, string description, string img, int idCat, int idCatUpdate, int idProduct)
        {
            if (name == "" || (priceSmall == 0 && priceMedium == 0 && priceLarge == 0 && price == 0) || description == "")
            {
                MessageBox.Show("Xin mời nhập đủ thông tin", "Thông báo");
            }
            else
            {
                if (price != 0 && (priceSmall == 0 && priceMedium == 0 && priceLarge == 0))
                {
                    if (MessageBox.Show("Bạn đã chắc chắn muốn sửa "+namePro+" chưa?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        bool result = new ProductBUS().EditProduct(idCatUpdate, name, (int?)priceSmall, (int?)priceMedium, (int?)priceLarge, (int?)price, description, img, idProduct);
                        if (result)
                        {
                            GetCatProToppingByIdCat(idCatUpdate);
                            if (idCat == 7)
                                LoadAllTopping();
                            MessageBox.Show("Sửa sản phẩm thành công", "Thông báo");
                        }
                        else
                            MessageBox.Show("Thất bại rùi :(", "Thông báo");
                    }
                }
                else if (price == 0 && (priceSmall != 0 || priceMedium != 0 || priceLarge != 0))
                {
                    if (MessageBox.Show("Bạn đã chắc chắn muốn sửa "+namePro+" chưa?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        bool result = new ProductBUS().EditProduct(idCatUpdate, name, (int?)priceSmall, (int?)priceMedium, (int?)priceLarge, (int?)price, description, img, idProduct);
                        if (result)
                        {
                            GetCatProToppingByIdCat(idCatUpdate);
                            if (idCat == 7)
                                LoadAllTopping();
                            MessageBox.Show("Sửa sản phẩm thành công", "Thông báo");
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

        private void searchBtn_Click(object sender, EventArgs e)
        {
            List<ProductTopping> pros = new GlobalDAO().SelectProductToppingByIdCatAndName(idCat, searchTxt.Text.Trim());
            bindingSource1.DataSource = pros;
            LoadListProduct();
            BindingProduct();
        }

        private void productTab_Enter(object sender, EventArgs e)
        {
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            LoadCategoryGrid();
        }

        private void dataGridViewCat_SelectionChanged(object sender, EventArgs e)
        {
            string img = dataGridViewCat.CurrentRow.Cells[2].Value.ToString();
            idCatEdit = (int)dataGridViewCat.CurrentRow.Cells[0].Value;
            nameCatEdit = dataGridViewCat.CurrentRow.Cells[1].Value.ToString();
            if (img.Substring(0, 4) == "http")
            {
                var request = WebRequest.Create(img);
                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    pictureBoxCat.Image = Bitmap.FromStream(stream);
                }
            }
            else
            {
                byte[] b = Convert.FromBase64String(img);

                MemoryStream memoryStream = new MemoryStream();
                memoryStream.Write(b, 0, Convert.ToInt32(b.Length));

                Bitmap bm = new Bitmap(memoryStream, false);
                memoryStream.Dispose();
                pictureBoxCat.Image = bm;
            }
        }

        private void dataGridViewProduct_SelectionChanged(object sender, EventArgs e)
        {
            int id = (int)dataGridViewProduct.CurrentRow.Cells[0].Value;
            namePro = dataGridViewProduct.CurrentRow.Cells[2].Value.ToString();
            idProduct = id;
            string img = dataGridViewProduct.CurrentRow.Cells[8].Value.ToString();
            try
            {
                if (img.Substring(0, 4) == "http")
                {
                    var request = WebRequest.Create(img);
                    using (var response = request.GetResponse())
                    using (var stream = response.GetResponseStream())
                    {
                        pictureBoxProduct.Image = Bitmap.FromStream(stream);
                    }
                    LoadListTopping(id);
                }
                else
                {
                    byte[] b = Convert.FromBase64String(img);

                    MemoryStream memoryStream = new MemoryStream();
                    memoryStream.Write(b, 0, Convert.ToInt32(b.Length));

                    Bitmap bm = new Bitmap(memoryStream, false);
                    memoryStream.Dispose();
                    pictureBoxProduct.Image = bm;
                    LoadListTopping(id);
                }
            }
            catch { }
        }

        private void addCatBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn đã chắc chắn muốn thêm "+nameCatTxt.Text+" chưa?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                int checkk = 0;
                for (int i = 0; i < catsCheck.Count(); i++)
                {
                    if (nameCatTxt.Text == catsCheck[i].NameCat)
                    {
                        checkk = 1;
                        break;
                    }
                }
                if (checkk == 0)
                {
                    if (CategoryDAO.Instance.AddCat(nameCatTxt.Text, imgCat))
                    {
                        LoadCategoryGrid();
                        check = 0;
                        MessageBox.Show("Thêm thành công", "Thông báo");
                    }
                    else
                        MessageBox.Show("Thêm thất bại", "Thông báo");
                }
                else
                    MessageBox.Show("Tên Trùng", "Thông báo");
            }
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            if (check == 0)
            {
                LoadCategory();
                LoadAllTopping();
                LoadCategoryUpdate();
            }
        }

        private void editCatBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn đã chắc chắn muốn sửa " + nameCatEdit + " chưa?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                int checkk = 0;
                for (int i = 0; i < catsCheck.Count(); i++)
                {
                    if (catsCheck[i].NameCat == nameCatEdit)
                        continue;
                    if (nameCatTxt.Text == catsCheck[i].NameCat)
                    {
                        checkk = 1;
                        break;
                    }
                }
                if (checkk == 0)
                {
                    if (CategoryDAO.Instance.EditCat(nameCatTxt.Text, imgCat, idCatEdit))
                    {
                        if (idCatEdit > 0)
                        {
                            LoadCategoryGrid();
                            check = 0;
                            MessageBox.Show("Sửa thành công", "Thông báo");
                        }
                    }
                    else
                        MessageBox.Show("Sửa thất bại", "Thông báo");
                }
                else
                    MessageBox.Show("Tên Trùng", "Thông báo");
            }
        }

        private void delCatBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn đã chắc chắn muốn xóa " + nameCatEdit + " chưa?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (CategoryDAO.Instance.DelCat(idCatEdit))
                {
                    if (idCatEdit > 0)
                    {
                        LoadCategoryGrid();
                        check = 0;
                        MessageBox.Show("Xóa thành công", "Thông báo");
                    }
                }
                else
                    MessageBox.Show("Xóa thất bại", "Thông báo");
            }
        }

        private async void uploadImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Chọn hình ảnh";
            open.Filter = "Image Files(*.jpg) | *.jpg";

            if (open.ShowDialog() == DialogResult.OK)
            {
                System.Drawing.Image img = new Bitmap(open.FileName);
                pictureBoxProduct.Image = img;
            }
            addBtn.Enabled = false;
            editBtn.Enabled = false;
            MemoryStream ms = new MemoryStream();
            pictureBoxProduct.Image.Save(ms, ImageFormat.Jpeg);

            byte[] byteConvert = ms.GetBuffer();

            string output = Convert.ToBase64String(byteConvert);

            var data = new DTO.Image
            {
                Img = output
            };

            SetResponse response = await client.SetTaskAsync("Image/", data);

            DTO.Image result = response.ResultAs<DTO.Image>();
            img = result.Img;
            addBtn.Enabled = true;
            editBtn.Enabled = true;
            //byte[] b = Convert.FromBase64String(result.Img);

            //MemoryStream memoryStream = new MemoryStream();
            //memoryStream.Write(b, 0, Convert.ToInt32(b.Length));

            //Bitmap bm = new Bitmap(memoryStream, false);
            //memoryStream.Dispose();
            //Picturebox.Image=bm;

        }

        private void formProduct_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            if (client != null)
            {
                MessageBox.Show("Access to Firebase :3 :3 :3", "Yayyy");
            }
        }

        private async void pickImgCat_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Chọn hình ảnh";
            open.Filter = "Image Files(*.jpg) | *.jpg";

            if (open.ShowDialog() == DialogResult.OK)
            {
                System.Drawing.Image img = new Bitmap(open.FileName);
                pictureBoxCat.Image = img;
            }
            addCatBtn.Enabled = false;
            editCatBtn.Enabled = false;
            MemoryStream ms = new MemoryStream();
            pictureBoxCat.Image.Save(ms, ImageFormat.Jpeg);

            byte[] byteConvert = ms.GetBuffer();

            string output = Convert.ToBase64String(byteConvert);

            var data = new DTO.Image
            {
                Img = output
            };

            SetResponse response = await client.SetTaskAsync("Image/", data);

            DTO.Image result = response.ResultAs<DTO.Image>();
            imgCat = result.Img;
            addCatBtn.Enabled = true;
            editCatBtn.Enabled = true;
        }
    }
}
