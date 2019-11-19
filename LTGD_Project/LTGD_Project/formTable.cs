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

namespace LTGD_Project
{
    public partial class formTable : Form
    {
        public formTable()
        {
            InitializeComponent();
            LoadTable();
        }

        //Hiển thị danh sách bàn
        void LoadTable()
        {
            List<Table> tables =  TableDAO.Instance.LoadTableList();

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
            int active = 0;
            int i = 0;
            foreach (DTO.Menu item in menu)
            {
                if(active == 0)
                {
                    ListViewItem listViewItem = new ListViewItem(item.NameProduct.ToString());
                    listViewItem.SubItems.Add(item.PriceProduct.ToString() + ".000");
                    listViewItem.SubItems.Add(item.Quantity.ToString());
                    listViewItem.SubItems.Add(item.NameTopping.ToString() + " (+" + item.PriceTopping.ToString() + ".000)");
                    listViewItem.SubItems.Add(item.Total.ToString() + ".000");
                    totalPrice += item.Total;
                    listViewBill.Items.Add(listViewItem);
                    temp = item.IdProduct;
                    i++;
                    active = 1;
                }
                else
                {
                    if (temp != item.IdProduct)
                    {
                        ListViewItem listViewItem = new ListViewItem(item.NameProduct.ToString());
                        listViewItem.SubItems.Add(item.PriceProduct.ToString() + ".000");
                        listViewItem.SubItems.Add(item.Quantity.ToString());
                        listViewItem.SubItems.Add(item.NameTopping.ToString() + " (+" + item.PriceTopping.ToString() + ".000)");
                        listViewItem.SubItems.Add(item.Total.ToString() + ".000");
                        totalPrice += item.Total;
                        listViewBill.Items.Add(listViewItem);
                        temp = item.IdProduct;
                        i++;
                    }
                    else
                    {
                        listViewBill.Items[i - 1].SubItems[3].Text += ", \n" + (item.NameTopping.ToString()) + " (+" + (item.PriceTopping.ToString()) + ".000)";

                        listViewBill.Items[i - 1].SubItems[4].Text = ((int.Parse(listViewBill.Items[i - 1].SubItems[4].Text.Remove(listViewBill.Items[i - 1].SubItems[4].Text.Length - 4))/item.Quantity + item.PriceTopping)*item.Quantity).ToString() + ".000";
                        totalPrice += (int)(item.PriceTopping * item.Quantity);
                    }
                }
                
            }
            totalPriceTxt.Text = totalPrice.ToString() + ".000 VNĐ";
        }

        //Event khi ấn vào từng bàn
        private void Btn_Click(object sender, EventArgs e)
        {
            int idTable = ((sender as Button).Tag as Table).IdTable;
            ShowDetailBill(idTable);
        }

        //Event khi ấn nút THÊM
        private void addBtn_Click(object sender, EventArgs e)
        {

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

        void LoadCategory()
        {

        }

        void LoadFoodByCategory(int idCat)
        {

        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            this.LoadFoodByCategory(id);
        }
    }
}
