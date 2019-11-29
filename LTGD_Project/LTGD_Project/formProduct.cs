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

namespace LTGD_Project
{
    public partial class formProduct : Form
    {
        List<ProductTopping> productToppings;
        int Id = 0;
        int check = 0;
        public formProduct()
        {
            InitializeComponent();
            LoadCategory();
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
            if (id != Id)
            {
                //GetCatProToppingByIdCat
                List<ProductTopping> ProductToppings = new CatProToppingBUS().SelectProductTopping(id);
                productToppings = ProductToppings;
                bindingSource1.DataSource = productToppings;
                LoadListProduct();
                Id = id;
            }
        }

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

        void LoadListTopping(int id)
        {
            for(int i = 0; i < productToppings.Count(); i++)
            {
                if (productToppings[i].IdProduct == id)
                {
                    dataGridViewTopping.DataSource = productToppings[i].Topping;
                }
            }
            return;
        }

        void BindingProduct()
        {
            smallSizeTxt.DataBindings.Clear();
            smallSizeTxt.DataBindings.Add(new Binding("Text", dataGridViewProduct.DataSource, "priceSmallProduct"));

            mediumSizeTxt.DataBindings.Clear();
            mediumSizeTxt.DataBindings.Add(new Binding("Text", dataGridViewProduct.DataSource, "priceMediumProduct"));

            largeSizeTxt.DataBindings.Clear();
            largeSizeTxt.DataBindings.Add(new Binding("Text", dataGridViewProduct.DataSource, "priceLargeProduct"));

            freeSizeTxt.DataBindings.Clear();
            freeSizeTxt.DataBindings.Add(new Binding("Text", dataGridViewProduct.DataSource, "priceProduct"));

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
            LoadListTopping(id);
        }


    }
}
