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
    public partial class foramTableManage : Form
    {
        string name = "";
        int idTable = 0;
        string status = "Trống";
        List<Table> tables = TableDAO.Instance.LoadTableList();
        public foramTableManage()
        {
            InitializeComponent();
            LoadTable();
        }

        void LoadTable()
        {
            dataGridViewTable.DataSource = TableDAO.Instance.LoadTableList();
            dataGridViewTable.Columns[0].HeaderText = "ID";
            dataGridViewTable.Columns[1].HeaderText = "Tên bàn";
            dataGridViewTable.Columns[2].HeaderText = "Trạng thái";
            nameTable.DataBindings.Clear();
            nameTable.DataBindings.Add(new Binding("Text", dataGridViewTable.DataSource, "nameTable"));
            comboBoxStatus.DataBindings.Clear();
            comboBoxStatus.DataBindings.Add(new Binding("Text", dataGridViewTable.DataSource, "statusTable", true));
        }

        private void foramTableManage_Load(object sender, EventArgs e)
        {

        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            AddTable();
        }

        void AddTable()
        {
            if (nameTable.Text.Trim() != "")
            {
                if (MessageBox.Show("Bạn đã chắc chắn muốn thêm "+ nameTable.Text +" chưa?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    int check = 0;
                    for (int i = 0; i < tables.Count(); i++)
                    {
                        if (nameTable.Text == tables[i].NameTable)
                        {
                            check = 1;
                            break;
                        }
                    }
                    if (check == 0)
                    {
                        if (TableDAO.Instance.AddTable(nameTable.Text, comboBoxStatus.Text))
                        {
                            LoadTable();
                            MessageBox.Show("Thêm thành công", "Thông báo");
                        }
                        else
                            MessageBox.Show("Thêm thất bại", "Thông báo");
                    }
                    else
                        MessageBox.Show("Tên trùng", "Thông báo");

                }
            }
            else
                MessageBox.Show("Xin mời nhập tên", "Thông báo");
        }

        private void dataGridViewTable_SelectionChanged(object sender, EventArgs e)
        {
            name = dataGridViewTable.CurrentRow.Cells[1].Value.ToString();
            status = dataGridViewTable.CurrentRow.Cells[2].Value.ToString();
            idTable = (int)dataGridViewTable.CurrentRow.Cells[0].Value;
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (nameTable.Text.Trim() != "")
            {
                if (MessageBox.Show("Bạn đã chắc chắn muốn sửa " + name + " chưa?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    if (status == "Có người")
                        MessageBox.Show("Xin mời thanh toán bill để chuyển lại trạng thái Trống", "Thông báo");
                    else
                    {
                        int check = 0;
                        for (int i = 0; i < tables.Count(); i++)
                        {
                            if (nameTable.Text == tables[i].NameTable)
                            {
                                check = 1;
                                break;
                            }
                        }
                        if (check == 0)
                        {
                            if (TableDAO.Instance.EditTable(nameTable.Text, comboBoxStatus.Text, idTable))
                            {
                                LoadTable();
                                MessageBox.Show("Sửa thành công", "Thông báo");
                            }
                            else
                                MessageBox.Show("Sửa thất bại", "Thông báo");
                        }
                        else
                            MessageBox.Show("Tên trùng", "Thông báo");
                    }
                }
            }
            else
                MessageBox.Show("Xin mời nhập tên", "Thông báo");
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            DelTable();
        }
        void DelTable()
        {
            if (MessageBox.Show("Bạn đã chắc chắn muốn xóa " + name + " chưa?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (status == "Có người")
                    MessageBox.Show("Xin mời thanh toán hêt bill để xóa bàn", "Thông báo");
                else
                {
                    if (TableDAO.Instance.DelTable(idTable))
                    {
                        LoadTable();
                        MessageBox.Show("Xóa thành công", "Thông báo");
                    }
                    else
                        MessageBox.Show("Xóa thất bại", "Thông báo");
                }
            }
        }
    }
}
