using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace QuanLyRapPhim.Control
{

    public partial class QuanLyPhimControl : UserControl
    {
        Database database = new Database();

        public QuanLyPhimControl()
        {
            InitializeComponent();
        }
        private void loadFormFromDataBase()
        {
            // Kiểm tra kết nối đến cơ sở dữ liệu
            if (!database.TestConnection())
            {
                MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu!");
                return;
            }

            // Lấy danh sách các tên thể loại từ cơ sở dữ liệu
            DataTable dtTheLoai = database.LayDanhSachTheLoai();

            DataTable dtDanhSachPhim = database.LayDanhSachPhim();
            DataTable dtPhongChieu = database.LayDanhSachPhongChieu();
            DataTable dtLichChieu = database.LayDanhSachLichChieu();
            DataTable dtVe = database.LayDanhSach("SELECT * FROM ve");
            // Load dữ liệu từ cơ sở dữ liệu vào DataGridView
            hienThiPhimGrid.DataSource = dtDanhSachPhim;
            theLoaiGrid.DataSource = dtTheLoai;

            phongChieuGrid.DataSource = dtPhongChieu;
            lichChieuGridView.DataSource = dtLichChieu;
            veGridView.DataSource = dtVe;


            

            // Gọi hàm LoadComboBoxFromDataTable để nạp dữ liệu vào ComboBox
            Func.LoadComboBoxFromDataTable(theLoaiComboBox, dtTheLoai, "Chọn thể loại", "TenTheLoai");
            Func.LoadComboBoxFromDataTable(idPhongInLichChieu, dtPhongChieu, "Chọn phòng chiếu", "maphong");
            Func.LoadComboBoxFromDataTable(chonPhimInLichChieuComboBox, dtDanhSachPhim, "Chọn phim", "tenphim");

        }
        private void QuanLyPhimControl_Load(object sender, EventArgs e)
        {
            // Kiểm tra kết nối đến cơ sở dữ liệu
            if (!database.TestConnection())
            {
                MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu!");
                return;
            }

            loadFormFromDataBase();

        }
        
        private void phongChieuGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Lấy chỉ số của dòng được chọn
            int rowIndex = e.RowIndex;

            if (rowIndex >= 0 && rowIndex < phongChieuGrid.Rows.Count)
            {
                // Lấy dữ liệu từ các ô của dòng được chọn
                DataGridViewRow selectedRow = phongChieuGrid.Rows[rowIndex];

                maPhongTextBox.Text = selectedRow.Cells["maphong"].Value.ToString();
                tenPhongTextBox.Text = selectedRow.Cells["tenphong"].Value.ToString();
                soLuongGheTextBox.Text = selectedRow.Cells["soluongghe"].Value.ToString();
                soGheMoiHangTextBox.Text = selectedRow.Cells["soghemoihang"].Value.ToString();
                tinhTrangGheTextBox.Text = selectedRow.Cells["tinhtrang"].Value.ToString();

            }
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
                loadFormFromDataBase();
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
                loadFormFromDataBase();
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
                loadFormFromDataBase();
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
                    loadFormFromDataBase();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa!", "HA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void themPhongBtn_Click(object sender, EventArgs e)
        {
            if(maPhongTextBox.Text.Length > 0 && tenPhongTextBox.Text.Length > 0 && soLuongGheTextBox.Text.Length > 0 && soGheMoiHangTextBox.Text.Length > 0 && tinhTrangGheTextBox.Text.Length > 0)
            {
                bool result = database.ThemPhongChieu(maPhongTextBox.Text, tenPhongTextBox.Text, int.Parse(soLuongGheTextBox.Text), int.Parse(soGheMoiHangTextBox.Text), int.Parse(tinhTrangGheTextBox.Text));
                if(!result)
                {
                    MessageBox.Show("Thêm lỗi!", "HA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                loadFormFromDataBase();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "HA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void xoaPhongBtn_Click(object sender, EventArgs e)
        {
            if (phongChieuGrid.SelectedRows.Count > 0)
            {
                // Lấy hàng được chọn
                DataGridViewRow selectedRow = phongChieuGrid.SelectedRows[0];
                string maPhong = selectedRow.Cells["maphong"].Value.ToString();
                bool result = database.XoaPhongChieu(maPhong);
                if (!result)
                {
                    MessageBox.Show("Vui Lỗi xóa!", "HA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                loadFormFromDataBase();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa!", "HA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void themLichBtn_Click(object sender, EventArgs e)
        {
            if(maLichChieuTextBox.Text.Length > 0 && idPhongInLichChieu.SelectedItem != "" && int.Parse(giaVeTextBox.Text) > 0 && trangThaiTextBox.Text != "")
            {

                // Gọi hàm để thêm lịch chiếu và kiểm tra kết quả
                bool result = database.ThemLichChieu(maLichChieuTextBox.Text, lichChieuPicker.Value, idPhongInLichChieu.Text, chonPhimInLichChieuComboBox.Text, decimal.Parse(giaVeTextBox.Text), int.Parse(trangThaiTextBox.Text));
                if (!result)
                {
                    MessageBox.Show("Thêm lịch chiếu thất bại!");
                }
                loadFormFromDataBase();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "HA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void suaPhongBtn_Click(object sender, EventArgs e)
        {
            if (phongChieuGrid.SelectedRows.Count > 0)
            {
                // Thử sửa đổi thông tin của một phòng chiếu trong cơ sở dữ liệu
                bool result = database.SuaPhongChieu(
                    maPhongTextBox.Text,
                    tenPhongTextBox.Text,
                    int.Parse(soLuongGheTextBox.Text),
                    int.Parse(soGheMoiHangTextBox.Text),
                    int.Parse(tinhTrangGheTextBox.Text)
                );

                // Kiểm tra kết quả của việc sửa đổi phòng chiếu
                if (!result)
                {
                    // Hiển thị thông báo lỗi nếu sửa đổi không thành công
                    MessageBox.Show("Sửa lỗi!", "HA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Nếu sửa đổi thành công, cập nhật lưới dữ liệu với danh sách phòng chiếu mới
                    phongChieuGrid.DataSource = database.LayDanhSachPhongChieu();
                }
                loadFormFromDataBase();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa!", "HA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void loadFormFromDb(object sender, EventArgs e)
        {
            loadFormFromDataBase();
        }

        private void xoaVeBtn_Click(object sender, EventArgs e)
        {
            if (veGridView.SelectedRows.Count > 0)
            {

                // Lấy hàng được chọn
                DataGridViewRow selectedRow = veGridView.SelectedRows[0];
                string value = selectedRow.Cells["mave"].Value.ToString();
                bool result = database.Xoa("Ve","MaVe", value);
                if (!result)
                {
                    MessageBox.Show("Lỗi xóa!", "HA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                loadFormFromDataBase();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!", "HA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void xoaLichBtn_Click(object sender, EventArgs e)
        {
            if (lichChieuGridView.SelectedRows.Count > 0)
            {

                // Lấy hàng được chọn
                DataGridViewRow selectedRow = lichChieuGridView.SelectedRows[0];
                string value = selectedRow.Cells["id"].Value.ToString();
                bool result = database.Xoa("LichChieu", "id", value);
                if (!result)
                {
                    MessageBox.Show("Lỗi xóa!", "HA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                loadFormFromDataBase();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!", "HA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBox1.Text;
            DataTable filteredData = Func.SearchAndUpdateDataGridView(veGridView, database.LayDanhSach("SELECT * FROM ve"), keyword);

            // Cập nhật DataGridView với dữ liệu đã lọc
            veGridView.DataSource = filteredData;
        }

        private void loadFormFromDataBase(object sender, EventArgs e)
        {
            loadFormFromDataBase();
        }
    }
}
