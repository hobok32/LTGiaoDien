using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using LTGD_Project.DAO;

namespace LTGD_Project
{
    public partial class formBill : Form
    {
        int totalPrice = 0;

        public formBill()
        {
            InitializeComponent();

        }
        public formBill(int idTable, string discount, int disc) : this()
        {
            SetHeight(listViewBill, 50);
            listViewBill.Columns[5].Width = 0;
            discTxt.Text = disc.ToString() + "%";
            totalPriceTxt.Text = discount;
            ShowDetailBill(idTable);
        }
        private void SetHeight(ListView listView, int height)
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, height);
            listView.SmallImageList = imgList;
        }
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
            textBox1.Text = (totalPrice * 1000).ToString("c", culture);
            listViewBill.Columns[5].Width = 0;
        }

        Bitmap bitmap;

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        private void formBill_Load(object sender, EventArgs e)
        {
            listViewBill.Columns[5].Width = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            bitmap = new Bitmap(this.Size.Width, this.Size.Height, g);
            Graphics mg = Graphics.FromImage(bitmap);
            mg.CopyFromScreen(this.Location.X+10, this.Location.Y, 0, 0, this.Size);
            printPreviewDialog1.Document.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("a5", this.Width, this.Height-20);
            printPreviewDialog1.ShowDialog();
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
