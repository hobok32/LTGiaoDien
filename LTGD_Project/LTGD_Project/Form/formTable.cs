using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Globalization;
using LTGD_Project.DAO;
using LTGD_Project.DTO;
using System.Threading;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using LTGD_Project.BUS;
using Firebase.Database;
using Firebase.Database.Query;

namespace LTGD_Project
{
    public partial class formTable : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "dHDi653cpD0hHaOOrAwgtlTahn7FC9ZBhYoDjeWV",
            BasePath = "https://cafe-4b7dd.firebaseio.com/"
        };

        IFirebaseClient client;

        string usernameLogin;

        float totalPrice = 0;

        Account account;

        List<int> idTopping = new List<int>();

        List<Topping> toppings = new List<Topping>();

        List<Table> tables;

        List<Kitchen> kitchens;

        //Nhận username từ loginForm
        public formTable(string username) : this()
        {
            usernameLogin = username;
            Text += " (" + usernameLogin.ToUpper() + " :3)";
            account = LoadAccount(usernameLogin);
        }
        
        public formTable()
        {
            InitializeComponent();
            LoadTable();
            LoadCategory();
            LoadComboBoxSwitchTable();
            toppingCount.Enabled = false;
            
        }
        
        //Load Account
        Account LoadAccount(string username)
        {
            return AccountDAO.Instance.SelectAccount(username);
        }
        
        //Hiển thị danh sách bàn
        public void LoadTable()
        {
            noteTxt.Text = "";
            listViewBill.Items.Clear();
            tableTxt.Text = "";
            flowLayoutPanelTable.Controls.Clear();
            List<Table> tables = TableDAO.Instance.LoadTableList();
            foreach (Table item in tables)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableWidth };
                btn.Text = item.NameTable + Environment.NewLine + item.StatusTable;
                btn.Click += Btn_Click;
                btn.Tag = item;
                switch (item.StatusTable)
                {
                    case "Trống":
                        btn.BackColor = Color.Gainsboro;
                        break;
                    default:
                        btn.BackColor = Color.SlateBlue;
                        break;
                }

                flowLayoutPanelTable.Controls.Add(btn);
            }
        }

        async void LoadTableFirebase()
        {
            List<Table> tables = TableDAO.Instance.LoadTableList();
            List<TableFirebase> tab = new List<TableFirebase>();
            for(int i = 0; i < tables.Count(); i++)
            {
                FirebaseResponse response = await client.GetTaskAsync("Table/" + tables[i].IdTable);
                TableFirebase table = response.ResultAs<TableFirebase>();
                tab.Add(table);
            }

            flowLayoutPanelTable.Controls.Clear();
            foreach (TableFirebase item in tab)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableWidth };
                btn.Text = item.nameTable + Environment.NewLine + item.statusTable;
                btn.Click += Btn_Click;
                btn.Tag = item;
                switch (item.statusTable)
                {
                    case "Trống":
                        btn.BackColor = Color.Gainsboro;
                        break;
                    default:
                        btn.BackColor = Color.SlateBlue;
                        break;
                }

                flowLayoutPanelTable.Controls.Add(btn);
            }

        }

        //Hiển thị danh sách combobox chuyển bàn
        void LoadComboBoxSwitchTable()
        {
            comboBoxSwitchTable.DataSource = TableDAO.Instance.LoadTableList();
            comboBoxSwitchTable.DisplayMember = "nameTable";
        }

        //Hiển thị hóa đơn theo bàn tương ứng
        private void ShowDetailBill(int idTable)
        {
            totalPrice = 0;
            listViewBill.Items.Clear();
            List<DTO.Menu> menu = MenuDAO.Instance.SelectMenu(idTable);
            int temp = 0;
            int tempIdBillDetail = 0;
            int active = 0;
            int i = 0;
            foreach (DTO.Menu item in menu)
            {
                if (item.Quantity > 0)
                {
                    if (active == 0)
                    {
                        ListViewItem listViewItem = new ListViewItem(item.NameProduct.ToString());
                        listViewItem.SubItems.Add(item.Price.ToString() + ".000");
                        listViewItem.SubItems.Add(item.Quantity.ToString());
                        if (item.NameTopping.ToString() == "Không có Topping")
                            listViewItem.SubItems.Add(item.NameTopping.ToString());
                        else
                            listViewItem.SubItems.Add(item.NameTopping.ToString() + " (+" + item.PriceTopping.ToString() + ".000) x" + item.QuantityTopping);
                        listViewItem.SubItems.Add(((item.Price + item.PriceTopping * item.QuantityTopping) * item.Quantity).ToString() + ".000");
                        listViewItem.SubItems.Add(item.IdProduct.ToString());
                        totalPrice += (int)((item.Price + item.PriceTopping * item.QuantityTopping) * item.Quantity);
                        listViewBill.Items.Add(listViewItem);
                        tempIdBillDetail = (int)item.IdDetailBill;
                        temp = (int)item.Price;
                        i++;
                        active = 1;
                    }
                    else
                    {
                        if (tempIdBillDetail != item.IdDetailBill)
                        {
                            ListViewItem listViewItem = new ListViewItem(item.NameProduct.ToString());
                            listViewItem.SubItems.Add(item.Price.ToString() + ".000");
                            listViewItem.SubItems.Add(item.Quantity.ToString());
                            if (item.NameTopping.ToString() == "Không có Topping")
                                listViewItem.SubItems.Add(item.NameTopping.ToString());
                            else
                                listViewItem.SubItems.Add(item.NameTopping.ToString() + " (+" + item.PriceTopping.ToString() + ".000) x" + item.QuantityTopping);
                            listViewItem.SubItems.Add(((item.Price + item.PriceTopping * item.QuantityTopping) * item.Quantity).ToString() + ".000");
                            listViewItem.SubItems.Add(item.IdProduct.ToString());
                            totalPrice += (int)((item.Price + item.PriceTopping * item.QuantityTopping) * item.Quantity);
                            listViewBill.Items.Add(listViewItem);
                            tempIdBillDetail = (int)item.IdDetailBill;
                            temp = (int)item.Price;
                            i++;
                        }
                        else
                        {
                            if (item.Price == temp)
                            {
                                listViewBill.Items[i - 1].SubItems[3].Text += ", \n" + (item.NameTopping.ToString()) + " (+" + (item.PriceTopping.ToString()) + ".000) x" + (item.QuantityTopping).ToString();
                                listViewBill.Items[i - 1].SubItems[4].Text = ((int.Parse(listViewBill.Items[i - 1].SubItems[4].Text.Remove(listViewBill.Items[i - 1].SubItems[4].Text.Length - 4)) / item.Quantity + item.PriceTopping * item.QuantityTopping) * item.Quantity).ToString() + ".000";
                                totalPrice += (int)((item.PriceTopping * item.QuantityTopping) * item.Quantity);
                            }
                            else
                            {
                                ListViewItem listViewItem = new ListViewItem(item.NameProduct.ToString());
                                listViewItem.SubItems.Add(item.Price.ToString() + ".000");
                                listViewItem.SubItems.Add(item.Quantity.ToString());
                                if (item.NameTopping.ToString() == "Không có Topping")
                                    listViewItem.SubItems.Add(item.NameTopping.ToString());
                                else
                                    listViewItem.SubItems.Add(item.NameTopping.ToString() + " (+" + item.PriceTopping.ToString() + ".000) x" + item.QuantityTopping);
                                listViewItem.SubItems.Add(((item.Price + item.PriceTopping * item.QuantityTopping) * item.Quantity).ToString() + ".000");
                                listViewItem.SubItems.Add(item.IdProduct.ToString());
                                totalPrice += (int)((item.Price + item.PriceTopping * item.QuantityTopping) * item.Quantity);
                                listViewBill.Items.Add(listViewItem);
                                tempIdBillDetail = (int)item.IdDetailBill;
                                temp = (int)item.Price;
                                i++;
                            }
                        }
                    }
                }
            }
            CultureInfo culture = new CultureInfo("vi-VN");
            totalPriceTxt.Text = (totalPrice * 1000).ToString("c", culture);
            listViewBill.Columns[5].Width = 0;
        }

        //Event khi ấn vào từng bàn
        private void Btn_Click(object sender, EventArgs e)
        {
            int idTable = ((sender as Button).Tag as Table).IdTable;
            tableTxt.Text = ((sender as Button).Tag as Table).NameTable.ToString();
            //Lưu bàn vừa chọn vào tag của listView
            listViewBill.Tag = (sender as Button).Tag;
            noteTxt.Text = BillDAO.Instance.SelectNoteBill(idTable);
            ShowDetailBill(idTable);
        }

        //Event đổi trạng thái bàn trên firebase
        async void EditStatusTableFirebase(int idTable, string nameTable, string status)
        {
            var data = new Table
            {
                IdTable = idTable,
                NameTable = nameTable,
                StatusTable = status
            };
            FirebaseResponse response = await client.UpdateTaskAsync("Tables/L1/B" + idTable, data);
        }

        //Event đổi Note của bill trên firebase
        async void EditNoteTableFirebase(int idTable, string note)
        {
            var notes = new Note {
                Notes = note 
            };
            FirebaseResponse response = await client.UpdateTaskAsync("OrderBills/B" + idTable , notes);
        }

        //Event đổi OrderBills trên firebase (dành cho bếp)
        async void EditOrderBillsTableFirebase(string nameProduct, string size, int quantity, int price, List<Topping> toppings, int quantityTopping, int idTable)
        {
            var kitchenBill = new KitchenBill
            {
                NameProduct = nameProduct,
                Size = size,
                SoLuong = quantity,
                Status = "false"
            };
            int index = 0;
            for(int i = 0; i < kitchens.Count(); i++)
            {
                if (kitchens[i].IdTable == idTable && kitchens[i].Bills != null)
                {
                    index = kitchens[i].Bills.Count();
                    break;
                }
                else if (kitchens[i].IdTable == idTable && kitchens[i].Bills == null)
                    index = 0;
            }
            FirebaseResponse response = await client.SetTaskAsync("OrderBills/B" + idTable + "/Bills/" + index, kitchenBill);
            
            for(int i = 0; i < toppings.Count(); i++)
            {
                var topping = new KitchenTopping
                {
                    SoLuong = quantityTopping.ToString(),
                    ToppingName = toppings[i].NameProduct
                };
                await client.SetTaskAsync("OrderBills/B" + idTable + "/Bills/" + index + "/Topping/" + i, topping);
            }
        }

        //Event khi ấn nút THÊM
        private async void addBtn_Click(object sender, EventArgs e)
        {
            if (tableTxt.Text.Trim() == "")
            {
                MessageBox.Show("Xin mời chọn bàn", "Thông báo");
            }
            else
            {
                if (priceProductTxt.Text.Trim() == "")
                {
                    MessageBox.Show("Xin mời chọn giá", "Thông báo");
                }
                else
                {
                    Table table = listViewBill.Tag as Table; 
                    int idBill = BillDAO.Instance.SelectIdBill(table.IdTable);
                    int idProduct = (comboBoxProduct.SelectedItem as Product).IdProduct;
                    string nameProduct = (comboBoxProduct.SelectedItem as Product).NameProduct;
                    string sizeProduct;
                    int quantity = (int)productCount.Value;
                    int quantityTopping = (int)toppingCount.Value;
                    if (int.Parse(priceProductTxt.Text) == (comboBoxProduct.SelectedItem as Product).PriceSmallProduct)
                        sizeProduct = "S";
                    else if (int.Parse(priceProductTxt.Text) == (comboBoxProduct.SelectedItem as Product).PriceMediumProduct)
                        sizeProduct = "M";
                    else if (int.Parse(priceProductTxt.Text) == (comboBoxProduct.SelectedItem as Product).PriceLargeProduct)
                        sizeProduct = "L";
                    else if (int.Parse(priceProductTxt.Text) == (comboBoxProduct.SelectedItem as Product).PriceProduct)
                        sizeProduct = "F";
                    else
                        sizeProduct = "X";
                    //Bill chưa tồn tại
                    if (idBill == -1)
                    {
                        BillDAO.Instance.AddBill(table.IdTable, usernameLogin);
                        TableDAO.Instance.UpdateStatusTable(table.IdTable, "Có người");
                        EditStatusTableFirebase(table.IdTable, table.NameTable, "Có người");
                        DetailBillDAO.Instance.AddDetailBill(BillDAO.Instance.SelectIdBillLast(), idProduct, quantity, int.Parse(priceProductTxt.Text), toppings, quantityTopping);
                        EditOrderBillsTableFirebase(nameProduct, sizeProduct, quantity, int.Parse(priceProductTxt.Text), toppings, quantityTopping, table.IdTable);
                    }
                    //Bill đã tồn tại
                    else
                    {
                        //Sản phẩm chưa tồn tại
                        if (DetailBillDAO.Instance.CheckIsProductExist(idProduct, idBill) == false)
                        {
                            DetailBillDAO.Instance.AddDetailBill(idBill, idProduct, quantity, int.Parse(priceProductTxt.Text), toppings, quantityTopping);
                            EditOrderBillsTableFirebase(nameProduct, sizeProduct, quantity, int.Parse(priceProductTxt.Text), toppings, quantityTopping, table.IdTable);
                        }
                        //Sản phẩm đã tồn tại
                        else
                        {
                            //Sản phẩm mới bị trùng size
                            if (DetailBillDAO.Instance.CheckIsPriceEqual(idProduct, int.Parse(priceProductTxt.Text), idBill) == true)
                            {
                                //Trùng Topping
                                if (DetailBillDAO.Instance.CheckIsToppingEqual(toppings, idProduct, int.Parse(priceProductTxt.Text), idBill) != 0)
                                {
                                    //Update lại số lượng của sản phẩm đó
                                    int idDetailBill = DetailBillDAO.Instance.CheckIsToppingEqual(toppings, idProduct, int.Parse(priceProductTxt.Text), idBill);
                                    DetailBillDAO.Instance.UpdateQuantityDetailBill(quantity, idDetailBill, quantityTopping);
                                    EditOrderBillsTableFirebase(nameProduct, sizeProduct, quantity, int.Parse(priceProductTxt.Text), toppings, quantityTopping, table.IdTable);
                                }
                                //Khác Topping
                                else
                                {
                                    //Thêm sản phẩm mới
                                    DetailBillDAO.Instance.AddDetailBill(idBill, idProduct, quantity, int.Parse(priceProductTxt.Text), toppings, quantityTopping);
                                    EditOrderBillsTableFirebase(nameProduct, sizeProduct, quantity, int.Parse(priceProductTxt.Text), toppings, quantityTopping, table.IdTable);
                                }
                            }
                            //Sản phẩm mới khác size 
                            else
                            {
                                //Thêm sản phẩm mới
                                DetailBillDAO.Instance.AddDetailBill(idBill, idProduct, quantity, int.Parse(priceProductTxt.Text), toppings, quantityTopping);
                                EditOrderBillsTableFirebase(nameProduct, sizeProduct, quantity, int.Parse(priceProductTxt.Text), toppings, quantityTopping, table.IdTable);
                            }
                        }
                    }
                    kitchens = await SelectAllKitchen();
                    LoadTable();
                    tableTxt.Text = table.NameTable;
                    noteTxt.Text = BillDAO.Instance.SelectNoteBill(table.IdTable);
                    ShowDetailBill(table.IdTable);
                }
            }
        }

        //Event đăng xuất
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Event khi ấn vào Chi tiết tài khoản => hiện form chi tiết tk
        private void chiTiếtTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formProfile f = new formProfile(usernameLogin);
            f.ShowDialog();
        }

        //Event khi ấn vào Quản lý sản phẩm => hiện form quản lý sản phẩm
        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formProduct f = new formProduct();
            f.ShowDialog();
            if (!f.IsDisposed)
                LoadCategory();
        }

        //Hiển thị category
        void LoadCategory()
        {
            List<Category> cats = CategoryDAO.Instance.SelectAllCat();
            comboBoxCategory.DataSource = cats;
            comboBoxCategory.DisplayMember = "nameCat";
        }

        //Hiển thị sản phẩm theo category
        void LoadProductByCategory(int idCat)
        {
            List<Product> pros = ProductDAO.Instance.SelectProductByIdCat(idCat);
            comboBoxProduct.DataSource = pros;
            comboBoxProduct.DisplayMember = "nameProduct";
        }

        //Hiển thị giá của sản phẩm
        void LoadListBoxProductPrice(Product pro)
        {
            listBoxProductPrice.Items.Clear();
            if (pro.PriceProduct != 0)
                listBoxProductPrice.Items.Add(pro.PriceProduct);

            if (pro.PriceLargeProduct != 0)
                listBoxProductPrice.Items.Add(pro.PriceLargeProduct);

            if (pro.PriceMediumProduct != 0)
                listBoxProductPrice.Items.Add(pro.PriceMediumProduct);

            if (pro.PriceSmallProduct != 0)
                listBoxProductPrice.Items.Add(pro.PriceSmallProduct);
        }

        //Hiển thị topping của sản phẩm
        void LoadToppingByIdProduct(int idProduct)
        {
            List<Topping> toppings = ToppingDAO.Instance.SelectToppingByIdProduct(idProduct);
            listBoxTopping.DataSource = toppings;
            listBoxToppingPrice.DataSource = toppings;
            listBoxTopping.DisplayMember = "nameProduct";
            listBoxToppingPrice.DisplayMember = "priceProduct";
        }

        //Event khi comboBoxCategory được chọn
        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox combo = sender as ComboBox;
            if (combo.SelectedItem == null)
                return;
            Category selected = combo.SelectedItem as Category;
            id = selected.IdCat;
            this.LoadProductByCategory(id);
        }

        //Event khi comboBoxProduct được chọn
        private void comboBoxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox combo = sender as ComboBox;
            if (combo.SelectedItem == null)
                return;
            Product selected = combo.SelectedItem as Product;
            id = selected.IdProduct;
            idTopping.Clear();
            toppings.Clear();
            toppingTxt.Text = "";
            this.LoadToppingByIdProduct(id);
            this.LoadListBoxProductPrice(selected);
        }

        //
        private void listBoxTopping_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        //Event chọn topping
        private void listBoxTopping_MouseClick(object sender, MouseEventArgs e)
        {
            int ok = 0;
            ListBox lb = sender as ListBox;
            if (lb.SelectedItem == null)
                return;
            Topping selected = lb.SelectedItem as Topping;
            if (idTopping.Count == 0)
            {
                idTopping.Add(selected.IdProduct);
                toppings.Add(selected);
                toppingTxt.Text = selected.NameProduct;
                toppingCount.Enabled = true;
            }
                
            else
                for (int i = 0; i < idTopping.Count(); i++)
                {
                    if (toppings[i].IdProduct == selected.IdProduct)
                    {
                        MessageBox.Show("Đã chọn topping này rùi!");
                        ok = 0;
                        break;
                    }
                    else
                        ok = 1;
                }
            if (ok == 1)
            {
                idTopping.Add(selected.IdProduct);
                toppings.Add(selected);
                toppingTxt.Text = toppingTxt.Text + ", " + selected.NameProduct;
                toppingCount.Enabled = true;
            }
                
        }

        //Event khi ấn nút Clear
        private void clearToppingBtn_Click(object sender, EventArgs e)
        {
            idTopping.Clear();
            toppings.Clear();
            toppingTxt.Text = "";
        }

        //Event chọn giá sản phẩm
        private void listBoxProductPrice_MouseClick(object sender, MouseEventArgs e)
        {
            ListBox lb = sender as ListBox;
            if (lb.SelectedItem == null)
                return;
            else
            {
                priceProductTxt.Text = lb.SelectedItem.ToString();
            }
        }

        //Event khi ấn thanh toán
        private void chargeBtn_Click(object sender, EventArgs e)
        {
            Table table = listViewBill.Tag as Table;
            if (table != null)
            {
                
                int discount = (int)discountCount.Value;
                int idBill = BillDAO.Instance.SelectIdBill(table.IdTable);
                float priceDiscount = (totalPrice - totalPrice * discount / 100) * 1000;
                CultureInfo culture = new CultureInfo("vi-VN");
                if (idBill != -1 || table.StatusTable != "Trống")
                {
                    if (MessageBox.Show(string.Format("Bạn đã chắc chắn thanh toán {0} chưa?\n\nGiảm giá: {1}%\n\nTổng tiền: {2}", table.NameTable, discount, priceDiscount.ToString("c", culture)), "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        formBill formBill = new formBill(table.IdTable, priceDiscount.ToString("c", culture), (int)discountCount.Value);
                        formBill.Show();
                        List<ProductRate> productRates = new List<ProductRate>();
                        for (int m = 0; m < listViewBill.Items.Count; m++)
                        {
                            ProductRate productRate = new ProductRate();
                            productRate.IdProduct = int.Parse(listViewBill.Items[m].SubItems[5].Text);
                            productRate.Rate = int.Parse(listViewBill.Items[m].SubItems[2].Text);
                            productRates.Add(productRate);
                        }
                        if (productRates.Count > 0)
                            ProductRateDAO.Instance.UpdateRateProduct(productRates);
                        BillDAO.Instance.ThanhToanBill(idBill, discount, priceDiscount/1000);
                        TableDAO.Instance.UpdateStatusTable(table.IdTable, "Trống");
                        EditStatusTableFirebase(table.IdTable, table.NameTable, "Trống");
                        ShowDetailBill(table.IdTable);
                        LoadTable();
                    }
                }
            }
        }

        //Event ấn vào nút chuyển bàn
        private void switchTableBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //Bàn hiện tại có bill
                if ((listViewBill.Tag as Table).StatusTable != "Trống" && (listViewBill.Tag as Table).IdTable != (comboBoxSwitchTable.SelectedItem as Table).IdTable)
                {
                    //Bàn hiện tại
                    int idTableCurrent = (listViewBill.Tag as Table).IdTable;
                    //Bàn chuyển tới
                    int idTableSwitch = (comboBoxSwitchTable.SelectedItem as Table).IdTable;
                    //Bill của bàn hiện tại
                    int idBillCurrent = BillDAO.Instance.SelectIdBill(idTableCurrent);
                    //Bill của bàn chuyển tới
                    int idBillSwitch = BillDAO.Instance.SelectIdBill(idTableSwitch);
                    //Bàn chuyển tới trống (CHUYỂN BÀN)
                    if (idBillSwitch == -1)
                    {
                        if (MessageBox.Show("Bạn đã chắc chắn muốn chuyển " + (listViewBill.Tag as Table).NameTable + " sang " + (comboBoxSwitchTable.SelectedItem as Table).NameTable + " chưa?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            BillDAO.Instance.AddBill(idTableSwitch, usernameLogin);
                            TableDAO.Instance.UpdateStatusTable(idTableSwitch, "Có người");
                            EditStatusTableFirebase(idTableSwitch, (comboBoxSwitchTable.SelectedItem as Table).NameTable, "Có người");
                            List<int> idDetailBills = DetailBillDAO.Instance.SelectIdDetailBill(idBillCurrent);
                            TableDAO.Instance.SwitchTable(BillDAO.Instance.SelectIdBillLast(), idDetailBills);
                            BillDAO.Instance.XoaBill(idBillCurrent);
                            TableDAO.Instance.UpdateStatusTable(idTableCurrent, "Trống");
                            EditStatusTableFirebase(idTableCurrent, (listViewBill.Tag as Table).NameTable, "Trống");
                            ShowDetailBill(idTableCurrent);
                            LoadTable();
                        }
                    }
                    //Bàn chuyển tới có bill (GỘP BÀN)
                    else
                    {
                        if (MessageBox.Show("Bạn đã chắc chắn muốn gộp " + (listViewBill.Tag as Table).NameTable + " sang " + (comboBoxSwitchTable.SelectedItem as Table).NameTable + " chưa?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            List<int> idDetailBills = DetailBillDAO.Instance.SelectIdDetailBill(idBillCurrent);
                            List<DetailBill> detailBills = DetailBillDAO.Instance.SelectDetailBill(idBillCurrent);

                            //TableDAO.Instance.SwitchTable(idBillSwitch, idDetailBills);
                            for (int i = 0; i < detailBills.Count(); i++)
                            {
                                //Sản phẩm chưa tồn tại
                                if (DetailBillDAO.Instance.CheckIsProductExist(detailBills[i].IdProduct, idBillSwitch) == false)
                                {
                                    List<int> temp = new List<int>();
                                    temp.Add(detailBills[i].IdDeTailBill);
                                    TableDAO.Instance.SwitchTable(idBillSwitch, temp);
                                }
                                //Sản phẩm đã tồn tại
                                else
                                {
                                    //Sản phẩm mới bị trùng size
                                    if (DetailBillDAO.Instance.CheckIsPriceEqual(detailBills[i].IdProduct, detailBills[i].Price, idBillSwitch) == true)
                                    {
                                        List<DetailTopping> detailToppings = DetailToppingDAO.Instance.SelectListDetailToppingById(detailBills[i].IdDeTailBill);
                                        //Có Topping
                                        if (detailToppings.Count() > 0)
                                        {
                                            List<Topping> tempTopping = new List<Topping>();
                                            for (int j = 0; j < detailToppings.Count(); j++)
                                            {
                                                Topping toppping = new Topping();
                                                toppping.IdProduct = detailToppings[j].IdTopping;
                                                toppping.NameProduct = detailToppings[j].IdDetailTopping.ToString();
                                                toppping.PriceProduct = detailToppings[j].PriceTopping;
                                                toppping.ImgProduct = detailToppings[j].QuantityTopping.ToString();
                                                tempTopping.Add(toppping);
                                            }

                                            //Trùng Topping
                                            if (DetailBillDAO.Instance.CheckIsToppingEqual(tempTopping, detailBills[i].IdProduct, detailBills[i].Price, idBillSwitch) != 0)
                                            {
                                                //Update lại số lượng của sản phẩm đó
                                                int idDetailBill = DetailBillDAO.Instance.CheckIsToppingEqual(tempTopping, detailBills[i].IdProduct, detailBills[i].Price, idBillSwitch);
                                                DetailBillDAO.Instance.UpdateQuantityDetailBill(detailBills[i].Quantity, idDetailBill, int.Parse(tempTopping[0].ImgProduct));
                                                //Xóa detailtopping cũ
                                                List<int> delTopping = new List<int>();
                                                for (int z = 0; z < tempTopping.Count(); z++)
                                                {
                                                    delTopping.Add(int.Parse(tempTopping[z].NameProduct));
                                                }
                                                DetailToppingDAO.Instance.DeleteDetailTopping(delTopping);
                                                //Xóa detailbill cũ
                                                DetailBillDAO.Instance.DeleteDetailBill(detailBills[i].IdDeTailBill);
                                            }
                                            //Khác Topping
                                            else
                                            {
                                                //Thêm sản phẩm mới
                                                List<int> temp = new List<int>();
                                                temp.Add(detailBills[i].IdDeTailBill);
                                                TableDAO.Instance.SwitchTable(idBillSwitch, temp);
                                            }
                                        }
                                        //Không có Topping
                                        else
                                        {
                                            //Trùng => Update số lượng
                                            if (DetailToppingDAO.Instance.CheckHaveTopping(detailBills[i].Price, detailBills[i].IdProduct, idBillSwitch) != 0)
                                            {
                                                int idDetailBill = DetailToppingDAO.Instance.CheckHaveTopping(detailBills[i].Price, detailBills[i].IdProduct, idBillSwitch);
                                                DetailBillDAO.Instance.UpdateQuantityDetailBill(detailBills[i].Quantity, idDetailBill, -9999);
                                                //Xóa detailbill cũ
                                                DetailBillDAO.Instance.DeleteDetailBill(detailBills[i].IdDeTailBill);
                                            }
                                            //Không trùng => Thêm mới
                                            else
                                            {
                                                List<int> temp = new List<int>();
                                                temp.Add(detailBills[i].IdDeTailBill);
                                                TableDAO.Instance.SwitchTable(idBillSwitch, temp);
                                            }
                                        }
                                    }
                                    //Sản phẩm mới khác size 
                                    else
                                    {
                                        //Thêm sản phẩm mới
                                        List<int> temp = new List<int>();
                                        temp.Add(detailBills[i].IdDeTailBill);
                                        TableDAO.Instance.SwitchTable(idBillSwitch, temp);
                                    }
                                }
                            }


                            BillDAO.Instance.XoaBill(idBillCurrent);
                            TableDAO.Instance.UpdateStatusTable(idTableCurrent, "Trống");
                            EditStatusTableFirebase(idTableCurrent, (listViewBill.Tag as Table).NameTable, "Trống");
                            ShowDetailBill(idTableCurrent);
                            LoadTable();
                        }
                    }
                }         
            }
            catch
            {

            }
        }

        //Event khi ấn vào nút doanh thu
        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formMoney f = new formMoney();
            f.ShowDialog();
        }

        //Event khi ấn vào nút quản lý bàn
        private void quảnLýBànToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foramTableManage f = new foramTableManage();
            f.ShowDialog();
            if (!f.IsDisposed)
                LoadTable();
        }
        
        //FIREBASE
        private async void formTable_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            //if (client != null)
            //{
            //    MessageBox.Show("Access to Firebase :3 :3 :3", "Yayyy");
            //}
            listViewKitchen.Columns[1].TextAlign = HorizontalAlignment.Center;
            listViewKitchen.Columns[2].TextAlign = HorizontalAlignment.Center;
            tables = await SelectAllTable();
            kitchens = await SelectAllKitchen();
            ListenFirebase();
            ListenKitchen();
        }
        
        //Show thông báo
        void ShowNoti()
        {
            MessageBox.Show("Refresh Tables Success!", "Thông báo");
        }
        private const string FIREBASE_APP = "https://cafe-4b7dd.firebaseio.com/";
        private FirebaseClient firebase = new FirebaseClient(FIREBASE_APP);
        int check = 0;

        //Lắng nghe thay đổi từ firebase
        public void ListenFirebase()
        {
            firebase.Child("Tables").Child("L1").AsObservable<Table>().Subscribe(async item =>
            {
                for (int i = 0; i < tables.Count(); i++)
                {
                    if (tables[i].IdTable == item.Object.IdTable && tables[i].StatusTable != item.Object.StatusTable)
                    {
                        BeginInvoke(new MethodInvoker(delegate { LoadTable(); }));
                        tables = await SelectAllTable();
                    }

                }
                //gridView.BeginInvoke(new MethodInvoker(delegate { gridView.DataSource = tables; LoadTable(); }));
                //gridView.BeginInvoke(new MethodInvoker(delegate { gridView.DataSource = tables; LoadTable(); ShowNoti(); }));
            });
        }

        //Lắng nghe thay đổi từ nhà bếp
        public void ListenKitchen()
        {
            firebase.Child("OrderBills").AsObservable<Kitchen>().Subscribe(item =>
            {
                for (int i = 0; i < kitchens.Count(); i++)
                {
                    //Kiểm tra có món hay không
                    if (kitchens[i].IdTable == item.Object.IdTable && item.Object.Bills != null && item.Object.Bills.Count > 0 && kitchens[i].Bills != null)
                    {
                        for (int j = 0; j < kitchens[i].Bills.Count(); j++)
                        {
                            if (kitchens[i].Bills[j].Status == "false" && item.Object.Bills[j].Status == "true")
                            {
                                kitchens[i].Bills[j].Status = item.Object.Bills[j].Status;
                                BeginInvoke(new MethodInvoker(delegate { ShowNotiKitchen(item.Object.NameTable, item.Object.Bills[j]); }));
                                break;
                            }
                        }
                    }
                }
            });
        }

        public void ShowNotiKitchen(string nameTable, KitchenBill kitchenBill)
        {
            string topping = "";
            if (kitchenBill.Topping != null && kitchenBill.Topping.Count() > 0)
            {
                for (int i = 0; i < kitchenBill.Topping.Count(); i++)
                {
                    if (i == 0)
                        topping = kitchenBill.Topping[i].ToppingName;
                    else
                        topping += (", " + kitchenBill.Topping[i].ToppingName);
                }
            }
            else
                topping = "Không có topping";

            ListViewItem listViewItem = new ListViewItem(kitchenBill.NameProduct.ToString());
            listViewItem.SubItems.Add(kitchenBill.Size.ToString());
            listViewItem.SubItems.Add(kitchenBill.SoLuong.ToString());
            listViewItem.SubItems.Add(topping.ToString());
            listViewItem.SubItems.Add(nameTable.ToString());
            listViewKitchen.Items.Insert(0, listViewItem);
        }

        //Lấy bàn từ firebase
        public async Task<List<Table>> SelectAllTable()
        {
            List<Table> tables = new List<Table>();
            //Trả tất cả các node có trong Table trên firebase
            var fbTable = await firebase.Child("Tables").Child("L1").OnceAsync<Table>();
            foreach (var item in fbTable)
                tables.Add(item.Object);
            return tables;
        }

        //Lấy bếp từ firebase
        public async Task<List<Kitchen>> SelectAllKitchen()
        {
            List<Kitchen> kitchens = new List<Kitchen>();
            //Trả tất cả các node có trong OrderBills trên firebase
            var fbKitchen = await firebase.Child("OrderBills").OnceAsync<Kitchen>();
            foreach (var item in fbKitchen)
                kitchens.Add(item.Object);
            return kitchens;
        }

        //Event khi ấn nút note
        private void noteBtn_Click(object sender, EventArgs e)
        {
            int idBill = BillDAO.Instance.SelectIdBill((listViewBill.Tag as Table).IdTable);
            if (MessageBox.Show("Bạn đã chắc chắn muốn ghi chú " + (listViewBill.Tag as Table).NameTable + " chưa?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (noteTxt.Text.Trim() == "")
                {
                    MessageBox.Show("Xin mời nhập ghi chú", "Thông báo");
                }
                else
                {
                    if (BillDAO.Instance.NoteBill(idBill, noteTxt.Text))
                    {
                        EditNoteTableFirebase((listViewBill.Tag as Table).IdTable, noteTxt.Text);
                        MessageBox.Show("Ghi chú thành công", "Thông báo");
                    }
                    else
                        MessageBox.Show("Ghi chú thất bại", "Thông báo");
                }
            }
        }
    }
}

