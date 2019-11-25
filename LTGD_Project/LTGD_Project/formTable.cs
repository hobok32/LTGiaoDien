using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using LTGD_Project.DAO;
using LTGD_Project.DTO;
//Testgithub
namespace LTGD_Project
{
    public partial class formTable : Form
    {
        List<int> idTopping = new List<int>();
        List<Table> tables = TableDAO.Instance.LoadTableList();
        List<Topping> toppings = new List<Topping>();
        public formTable()
        {
            InitializeComponent();
            LoadTable();
            LoadCategory();
            toppingCount.Enabled = false;
        }

        //Hiển thị danh sách bàn
        void LoadTable()
        {
            foreach(Table item in tables)
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

        //Hiển thị hóa đơn theo bàn tương ứng
        void ShowDetailBill(int idTable)
        {
            listViewBill.Items.Clear();
            List<DTO.Menu> menu = MenuDAO.Instance.SelectMenu(idTable);
            int totalPrice = 0;
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
                        listViewItem.SubItems.Add(item.NameTopping.ToString() + " (+" + item.PriceTopping.ToString() + ".000) x" + item.QuantityTopping);
                        listViewItem.SubItems.Add(((item.Price + item.PriceTopping * item.QuantityTopping) * item.Quantity).ToString() + ".000");
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
                            listViewItem.SubItems.Add(item.NameTopping.ToString() + " (+" + item.PriceTopping.ToString() + ".000) x" + item.QuantityTopping);
                            listViewItem.SubItems.Add(((item.Price + item.PriceTopping * item.QuantityTopping) * item.Quantity).ToString() + ".000");
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
                                listViewItem.SubItems.Add(item.NameTopping.ToString() + " (+" + item.PriceTopping.ToString() + ".000) x" + item.QuantityTopping);
                                listViewItem.SubItems.Add(((item.Price + item.PriceTopping * item.QuantityTopping) * item.Quantity).ToString() + ".000");
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
            totalPriceTxt.Text = totalPrice.ToString() + ".000 VNĐ";
        }

        //Event khi ấn vào từng bàn
        private void Btn_Click(object sender, EventArgs e)
        {
            int idTable = ((sender as Button).Tag as Table).IdTable;
            tableTxt.Text = ((sender as Button).Tag as Table).NameTable.ToString();
            //Lưu bàn vừa chọn vào tag của listView
            listViewBill.Tag = (sender as Button).Tag;
            ShowDetailBill(idTable);
        }

        //Event khi ấn nút THÊM
        private void addBtn_Click(object sender, EventArgs e)
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
                    string idAccount = "an.nd";
                    int idBill = BillDAO.Instance.SelectIdBill(table.IdTable);
                    int idProduct = (comboBoxProduct.SelectedItem as Product).IdProduct;
                    int quantity = (int)productCount.Value;
                    int quantityTopping = (int)toppingCount.Value;
                    //Bill chưa tồn tại
                    if (idBill == -1)
                    {
                        BillDAO.Instance.AddBill(table.IdTable, idAccount);
                        TableDAO.Instance.UpdateStatusTable(table.IdTable, "Có người");
                        DetailBillDAO.Instance.AddDetailBill(BillDAO.Instance.SelectIdBillLast(), idProduct, quantity, int.Parse(priceProductTxt.Text), toppings, quantityTopping);

                    }
                    //Bill đã tồn tại
                    else
                    {
                        //Sản phẩm chưa tồn tại
                        if (DetailBillDAO.Instance.CheckIsProductExist(idProduct, idBill) == false)
                        {
                            DetailBillDAO.Instance.AddDetailBill(idBill, idProduct, quantity, int.Parse(priceProductTxt.Text), toppings, quantityTopping);
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
                                }
                                //Khác Topping
                                else
                                {
                                    //Thêm sản phẩm mới
                                    DetailBillDAO.Instance.AddDetailBill(idBill, idProduct, quantity, int.Parse(priceProductTxt.Text), toppings, quantityTopping);
                                }
                            }
                            //Sản phẩm mới khác size 
                            else
                            {
                                //Thêm sản phẩm mới
                                DetailBillDAO.Instance.AddDetailBill(idBill, idProduct, quantity, int.Parse(priceProductTxt.Text), toppings, quantityTopping);
                            }
                        }
                    }
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
            formProfile f = new formProfile();
            f.ShowDialog();
        }

        //Event khi ấn vào Quản lý sản phẩm => hiện form quản lý sản phẩm
        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formProduct f = new formProduct();
            f.ShowDialog();
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
            if (pro.PriceProduct == null)
                pro.PriceProduct = 0;
            else
                listBoxProductPrice.Items.Add(pro.PriceProduct);

            if (pro.PriceLargeProduct == null)
                pro.PriceLargeProduct = 0;
            else
                listBoxProductPrice.Items.Add(pro.PriceLargeProduct);

            if (pro.PriceMediumProduct == null)
                pro.PriceMediumProduct = 0;
            else
                listBoxProductPrice.Items.Add(pro.PriceMediumProduct);

            if (pro.PriceSmallProduct == null)
                pro.PriceSmallProduct = 0;
            else
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
    }
}
