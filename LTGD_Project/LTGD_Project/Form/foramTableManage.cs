using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using LTGD_Project.DAO;
using LTGD_Project.DTO;

namespace LTGD_Project
{
    public partial class foramTableManage : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "dHDi653cpD0hHaOOrAwgtlTahn7FC9ZBhYoDjeWV",
            BasePath = "https://cafe-4b7dd.firebaseio.com/"
        };
        IFirebaseClient client;
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
            client = new FireSharp.FirebaseClient(config);
            if (client != null)
            {
                MessageBox.Show("Access to Firebase :3 :3 :3", "Yayyy");
            }
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
                            AddTableFirebase(TableDAO.Instance.SelectIdTableLast());
                            tables = TableDAO.Instance.LoadTableList();
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

        async void AddTableFirebase(int idTable)
        {
            var data = new Table
            {
                IdTable = idTable,
                NameTable = nameTable.Text,
                StatusTable = comboBoxStatus.Text
            };
            SetResponse response = await client.SetTaskAsync("Tables/L1/" + "B" + idTable, data);
        }

        private void dataGridViewTable_SelectionChanged(object sender, EventArgs e)
        {
            name = dataGridViewTable.CurrentRow.Cells[1].Value.ToString();
            status = dataGridViewTable.CurrentRow.Cells[2].Value.ToString();
            idTable = (int)dataGridViewTable.CurrentRow.Cells[0].Value;
        }

        async void EditTableFirebase()
        {
            var data = new Table
            {
                IdTable = idTable,
                NameTable = nameTable.Text,
                StatusTable = comboBoxStatus.Text
            };
            FirebaseResponse response = await client.UpdateTaskAsync("Tables/L1/B" + idTable, data);
        }

        async void DelTableFirebase()
        {
            FirebaseResponse response = await client.DeleteTaskAsync("Tables/L1/B" + idTable);
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
                            if (tables[i].NameTable == name)
                                continue;
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
                                EditTableFirebase();
                                tables = TableDAO.Instance.LoadTableList();
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
                        DelTableFirebase();
                        tables = TableDAO.Instance.LoadTableList();
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
