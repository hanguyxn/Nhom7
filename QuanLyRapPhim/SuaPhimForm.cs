using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyRapPhim
{
    public partial class SuaPhimForm : Form
    {
        public bool IsUpdated { get; private set; }
        private Database database = new Database();
        private string maPhim;

        public SuaPhimForm(string maPhim)
        {
            InitializeComponent();
            this.maPhim = maPhim;
        }
        public SuaPhimForm()
        {
            InitializeComponent();
        }


        public string MaPhim { get; set; }

        private void SuaPhimForm_Load(object sender, EventArgs e)
        {
            // Gọi phương thức HienThiThongTinPhim từ lớp Database để hiển thị thông tin phim vào các TextBox
            database.HienThiThongTinPhim(maPhim,maPhimTxt, tenPhimTxt, thoiLuongTxt, dateTimeKhoiChieu, dateTimeKetThuc, quocGiaTxt, daoDienTxt, namSanXuatTextBox, theLoaiComboBox);
            // Lấy danh sách các tên thể loại từ cơ sở dữ liệu
            DataTable dtTheLoai = database.LayDanhSachTheLoai();

            // Thêm một mục trống đầu tiên vào ComboBox để cho phép người dùng chọn
            //theLoaiComboBox.Items.Add("Chọn thể loại");

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

        private void luuBtn_Click(object sender, EventArgs e)
        {
            string tenPhim = tenPhimTxt.Text;
            int thoiLuong = Convert.ToInt32(thoiLuongTxt.Text);
            DateTime ngayKhoiChieu = Convert.ToDateTime(dateTimeKhoiChieu.Value);
            DateTime ngayKetThuc = Convert.ToDateTime(dateTimeKetThuc.Value);
            string quocGia = quocGiaTxt.Text;
            string daoDien = daoDienTxt.Text;
            int namSanXuat = int.Parse(namSanXuatTextBox.Text);

            if (theLoaiComboBox.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn thể loại phim!");
                return;
            }
            else
            {
                string theLoai = theLoaiComboBox.SelectedItem.ToString(); // Lấy thể loại phim từ ComboBox

                // Gọi phương thức sửa phim từ lớp Database
                bool result = database.SuaPhim(maPhim, tenPhim, thoiLuong, ngayKhoiChieu, ngayKetThuc, quocGia, daoDien, namSanXuat, theLoai);

                // Kiểm tra kết quả và hiển thị thông báo tương ứng
                if (result)
                {
                    IsUpdated = true;
                    this.Close(); // Đóng form sau khi sửa thành công
                }
                else
                {
                    IsUpdated = false;
                }
            }
        }
    }
}
