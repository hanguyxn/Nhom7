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

    public partial class QuanLyPhimControl : UserControl
    {
        Database database = new Database();

        public QuanLyPhimControl()
        {
            InitializeComponent();
        }
        private void QuanLyPhimControl_Load(object sender, EventArgs e)
        {
            // Kiểm tra kết nối đến cơ sở dữ liệu
            if (!database.TestConnection())
            {
                MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu!");
                return;
            }

            // Load dữ liệu từ cơ sở dữ liệu vào DataGridView
            hienThiPhimGrid.DataSource = database.LayDanhSachPhim();
            theLoaiGrid.DataSource = database.LayDanhSachTheLoai();

            // Lấy danh sách các tên thể loại từ cơ sở dữ liệu
            DataTable dtTheLoai = database.LayDanhSachTheLoai();

            // Thêm một mục trống đầu tiên vào ComboBox để cho phép người dùng chọn
            theLoaiComboBox.Items.Add("Chọn thể loại");

            // Vòng lặp qua từng thể loại và thêm chúng vào ComboBox
            foreach (DataRow row in dtTheLoai.Rows)
            {
                string tenTheLoai = row["TenTheLoai"].ToString();

                // Thêm tên thể loại vào ComboBox
                theLoaiComboBox.Items.Add(tenTheLoai);
            }

            // Chọn mục đầu tiên trong ComboBox là mục trống
            theLoaiComboBox.SelectedIndex = 0;
        }
        public bool checkValid()
        {
            if(
                maPhimTextBox.Text != "" &&
                tenPhimTextBox.Text != "" &&
                moTaTextBox.Text != "" &&
                float.Parse(thoiLuongTextBox.Text) != null &&
                ngayKhoiChieuPicker.Value != null &&
                ngayKetThucPicker.Value != null &&
                quocGiaTextBox.Text != "" &&
                daoDienTextBox.Text != "" &&
                int.Parse(namSanXuatTextBox.Text) != null &&
                theLoaiComboBox.ToString() != "" &&
                bannerTextBox.Text != "")
            {
                return true;
            }
            return false;
        }
        private void themPhimBtn_Click(object sender, EventArgs e)
        {
            if (checkValid())
            {
                string maPhim = maPhimTextBox.Text;
                string tenPhim = tenPhimTextBox.Text;
                string moTa = moTaTextBox.Text;
                float thoiLuong = float.Parse(thoiLuongTextBox.Text);
                DateTime ngayKhoiChieu = ngayKhoiChieuPicker.Value;
                DateTime ngayKetThuc = ngayKetThucPicker.Value;
                string quocGia = quocGiaTextBox.Text;
                string daoDien = daoDienTextBox.Text;
                int namSanXuat = int.Parse(namSanXuatTextBox.Text);
                string theLoai = theLoaiComboBox.Text;
                string banner = bannerTextBox.Text;
                bool result = database.ThemPhim(maPhim, tenPhim, moTa, thoiLuong, ngayKhoiChieu, ngayKetThuc, quocGia, daoDien, namSanXuat, theLoai, banner);
                if (!result)
                {
                    MessageBox.Show("Thêm phim thất bại!", "HA",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                hienThiPhimGrid.DataSource = database.LayDanhSachPhim();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "HA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
        }

        private void themTheLoaiBtn_Click(object sender, EventArgs e)
        {
            if(maTheLoaiTextBox.TextLength > 0 && tenTheLoaiTextBox.TextLength > 0 && moTaTheLoaiTextBox.TextLength > 0) 
            {
                bool result = database.ThemTheLoai(maTheLoaiTextBox.Text, tenTheLoaiTextBox.Text, moTaTheLoaiTextBox.Text);
                if (!result)
                {
                    MessageBox.Show("Mã thể loại đã tồn tại!", "HA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                theLoaiGrid.DataSource = database.LayDanhSachTheLoai();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "HA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void xoaTheLoaiBtn_Click(object sender, EventArgs e)
        {
            if(theLoaiGrid.SelectedRows.Count > 0)
            {
                // Lấy hàng được chọn
                DataGridViewRow selectedRow = theLoaiGrid.SelectedRows[0];
                string maTheLoai = selectedRow.Cells["matheloai"].Value.ToString();
                bool result = database.XoaTheLoai(maTheLoai);
                if (result)
                {
                    MessageBox.Show("Xóa thành công!", "HA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                theLoaiGrid.DataSource = database.LayDanhSachTheLoai();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!", "HA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void xoaPhimBtn_Click(object sender, EventArgs e)
        {
            if (hienThiPhimGrid.SelectedRows.Count > 0)
            {
                // Lấy hàng được chọn
                DataGridViewRow selectedRow = hienThiPhimGrid.SelectedRows[0];
                string maphim = selectedRow.Cells["maphim"].Value.ToString();
                bool result = database.XoaPhim(maphim);
                if (!result)
                {
                    MessageBox.Show("Xóa phim lỗi!", "HA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                hienThiPhimGrid.DataSource = database.LayDanhSachPhim();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!", "HA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void suaPhimBtn_Click(object sender, EventArgs e)
        {
            if (hienThiPhimGrid.SelectedRows.Count > 0)
            {
                // Lấy hàng được chọn
                DataGridViewRow selectedRow = hienThiPhimGrid.SelectedRows[0];
                string maphim = selectedRow.Cells["maphim"].Value.ToString();
                SuaPhimForm suaPhimForm = new SuaPhimForm(maphim);
                suaPhimForm.ShowDialog();

                // Kiểm tra giá trị IsUpdated của SuaPhimForm để biết liệu sửa đã thành công hay không
                if (suaPhimForm.IsUpdated)
                {
                    MessageBox.Show("Sửa phim thành công!");
                    hienThiPhimGrid.DataSource = database.LayDanhSachPhim();
                    // Thực hiện các hành động cần thiết sau khi sửa thành công
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa!", "HA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
