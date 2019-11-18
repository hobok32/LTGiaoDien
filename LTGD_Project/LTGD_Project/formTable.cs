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

        void ShowDetailBill(int idTable)
        {
            listViewBill.Items.Clear();
            List<DTO.Menu> menu = MenuDAO.Instance.SelectMenu(idTable);

            foreach (DTO.Menu item in menu)
            {
                ListViewItem listViewItem = new ListViewItem(item.NameProduct.ToString());
                listViewItem.SubItems.Add(item.PriceProduct.ToString()+".000");
                listViewItem.SubItems.Add(item.Quantity.ToString());
                listViewItem.SubItems.Add(item.Total.ToString()+".000");
                listViewBill.Items.Add(listViewItem);
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            int idTable = ((sender as Button).Tag as Table).IdTable;
            ShowDetailBill(idTable);
        }

        private void addBtn_Click(object sender, EventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chiTiếtTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formProfile f = new formProfile();
            f.ShowDialog();
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formProduct f = new formProduct();
            f.ShowDialog();
        }
    }
}
