using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyRapPhim.Control
{
    public partial class QuanLyUserControl : UserControl
    {
        Database database = new Database();
        public QuanLyUserControl()
        {
            InitializeComponent();

        }
        private void QuanLyUserControl_Load(object sender, EventArgs e)
        {
            DataTable dtUser = database.LayDanhSachUser();
            userGrid.DataSource = database.LayDanhSachUser();
        }
        private void userGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Lấy chỉ số của dòng được chọn
            int rowIndex = e.RowIndex;

            if (rowIndex >= 0 && rowIndex < userGrid.Rows.Count)
            {
                // Lấy dữ liệu từ các ô của dòng được chọn
                DataGridViewRow selectedRow = userGrid.Rows[rowIndex];

                username.Text = selectedRow.Cells["Username"].Value.ToString();
                password.Text = selectedRow.Cells["Password"].Value.ToString();
                hoTen.Text = selectedRow.Cells["Hoten"].Value.ToString();
                diaChi.Text = selectedRow.Cells["Diachi"].Value.ToString();
                sdt.Text = selectedRow.Cells["Sdt"].Value.ToString();
                roleComboBox.Text = selectedRow.Cells["Role"].Value.ToString();

            }
        }
        private void addUserBtn_Click(object sender, EventArgs e)
        {
            if(username.Text != "" && password.Text != "" && hoTen.Text != "" && diaChi.Text != "" && sdt.Text != "" && roleComboBox.SelectedValue != "")
            {
                bool result = database.ThemNhanVien(username.Text, password.Text, hoTen.Text, diaChi.Text, sdt.Text, roleComboBox.Text);
                if(!result)
                {
                    MessageBox.Show("Thêm thất bại!", "HA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    username.Text = "";
                    password.Text = "";
                    hoTen.Text = "";
                    diaChi.Text = "";
                    sdt.Text = "";
                    roleComboBox.Text = "";
                }
                userGrid.DataSource = database.LayDanhSachUser();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "HA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void editUserBtn_Click(object sender, EventArgs e)
        {
            if (username.Text != "" && password.Text != "" && hoTen.Text != "" && diaChi.Text != "" && sdt.Text != "" && roleComboBox.SelectedValue != "")
            {
                if (userGrid.SelectedRows.Count > 0)
                {
                    bool result = database.SuaThongTinNhanVien(username.Text, password.Text, hoTen.Text, diaChi.Text, sdt.Text, roleComboBox.Text);
                    if (!result)
                    {
                        MessageBox.Show("Sửa thất bại!", "HA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    userGrid.DataSource = database.LayDanhSachUser();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn dòng để sửa!", "HA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                 
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "HA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void xoaUserBtn_Click(object sender, EventArgs e)
        {
            if (userGrid.SelectedRows.Count > 0)
            {
                bool result = database.XoaNhanVien(username.Text);
                if (!result)
                {
                    MessageBox.Show("Xóa thất bại!", "HA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                userGrid.DataSource = database.LayDanhSachUser();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng để xóa!", "HA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBox1.Text;
            DataTable filteredData = Func.SearchAndUpdateDataGridView(userGrid, database.LayDanhSachUser(), keyword);

            // Cập nhật DataGridView với dữ liệu đã lọc
            userGrid.DataSource = filteredData;
        }
    }
}
