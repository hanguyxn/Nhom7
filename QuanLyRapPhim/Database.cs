using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyRapPhim
{
    public class Database
    {
        ConfigDatabase db;

        // Chuỗi kết nối
        private string connectionString = @"Data Source=DESKTOP-03VO761\;Initial Catalog=cinema;Integrated Security=True";
        public bool TestConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        // Phương thức để lấy dữ liệu phim
        public DataTable LayDanhSachPhim()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT maphim, tenphim, mota, thoiluong, ngaykhoichieu, ngayketthuc, quocgia, daodien, namsanxuat, theloai, banner FROM phim";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }
        public bool Login(string username, string password)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"SELECT COUNT(*) FROM Users WHERE Username = '{username}' AND Password = '{password}'";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    if (count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false ;
                    }
                }
            }
        }
        public bool ThemPhim(string maPhim, string tenPhim, string moTa, int thoiLuong, DateTime ngayKhoiChieu, DateTime ngayKetThuc, string quocGia, string daoDien, int namSanXuat, string theLoai, string banner)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO phim (maphim, tenphim, mota, thoiluong, ngaykhoichieu, ngayketthuc, quocgia, daodien, namsanxuat, theloai, banner) VALUES (@MaPhim, @TenPhim, @MoTa, @ThoiLuong, @NgayKhoiChieu, @NgayKetThuc, @QuocGia, @DaoDien, @NamSanXuat, @TheLoai, @Banner)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaPhim", maPhim);
                    command.Parameters.AddWithValue("@TenPhim", tenPhim);
                    command.Parameters.AddWithValue("@MoTa", moTa);
                    command.Parameters.AddWithValue("@ThoiLuong", thoiLuong);
                    command.Parameters.AddWithValue("@NgayKhoiChieu", ngayKhoiChieu);
                    command.Parameters.AddWithValue("@NgayKetThuc", ngayKetThuc);
                    command.Parameters.AddWithValue("@QuocGia", quocGia);
                    command.Parameters.AddWithValue("@DaoDien", daoDien);
                    command.Parameters.AddWithValue("@NamSanXuat", namSanXuat);
                    command.Parameters.AddWithValue("@TheLoai", theLoai);
                    command.Parameters.AddWithValue("@Banner", banner);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
        public bool SuaPhim(string maPhim, string tenPhim, int thoiLuong, DateTime ngayKhoiChieu, DateTime ngayKetThuc, string quocGia, string daoDien, int namSanXuat, string theLoai)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Tạo câu lệnh SQL để cập nhật thông tin phim trong cơ sở dữ liệu
                    string query = @"UPDATE Phim SET TenPhim = @TenPhim, ThoiLuong = @ThoiLuong, NgayKhoiChieu = @NgayKhoiChieu, NgayKetThuc = @NgayKetThuc, QuocGia = @QuocGia, DaoDien = @DaoDien, NamSanXuat = @NamSanXuat, TheLoai = @TheLoai WHERE MaPhim = @MaPhim";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số cho câu lệnh SQL
                        command.Parameters.AddWithValue("@TenPhim", tenPhim);
                        command.Parameters.AddWithValue("@ThoiLuong", thoiLuong);
                        command.Parameters.AddWithValue("@NgayKhoiChieu", ngayKhoiChieu);
                        command.Parameters.AddWithValue("@NgayKetThuc", ngayKetThuc);
                        command.Parameters.AddWithValue("@QuocGia", quocGia);
                        command.Parameters.AddWithValue("@DaoDien", daoDien);
                        command.Parameters.AddWithValue("@NamSanXuat", namSanXuat);
                        command.Parameters.AddWithValue("@TheLoai", theLoai);
                        command.Parameters.AddWithValue("@MaPhim", maPhim);

                        // Thực thi câu lệnh SQL
                        int rowsAffected = command.ExecuteNonQuery();

                        // Kiểm tra số dòng đã bị ảnh hưởng, nếu lớn hơn 0 thì cập nhật thành công
                        if (rowsAffected > 0)
                            return true;
                        else
                            return false;
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có
                MessageBox.Show("Lỗi: " + ex.Message);
                return false;
            }

        }
        public void HienThiThongTinPhim(string maPhim,TextBox maPhimTxt, TextBox tenPhimTxt, TextBox thoiLuongTxt, DateTimePicker ngayKhoiChieuDateTimePicker, DateTimePicker ngayKetThucDateTimePicker, TextBox quocGiaTxt, TextBox daoDienTxt, DateTimePicker namSanXuatDateTimePicker, ComboBox theLoaiComboBox)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM phim WHERE MaPhim = @MaPhim";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaPhim", maPhim);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        maPhimTxt.Text = maPhim;
                        tenPhimTxt.Text = reader["TenPhim"].ToString();
                        thoiLuongTxt.Text = reader["ThoiLuong"].ToString();
                        ngayKhoiChieuDateTimePicker.Value = Convert.ToDateTime(reader["NgayKhoiChieu"]);
                        ngayKetThucDateTimePicker.Value = Convert.ToDateTime(reader["NgayKetThuc"]);
                        quocGiaTxt.Text = reader["QuocGia"].ToString();
                        daoDienTxt.Text = reader["DaoDien"].ToString();
                        // Đọc giá trị từ cột "NamSanXuat" trong cơ sở dữ liệu
                        int namSanXuatValue = (int)reader["NamSanXuat"];

                        // Tạo một đối tượng DateTime từ giá trị int đọc được
                        DateTime namSanXuatDateTime = new DateTime(namSanXuatValue, 1, 1); // 1/1 là ngày mặc định vì chúng ta chỉ có năm

                        // Gán giá trị DateTime cho DateTimePicker
                        namSanXuatDateTimePicker.Value = namSanXuatDateTime;
                        theLoaiComboBox.Text = reader["TheLoai"].ToString(); // Hiển thị thông tin thể loại phim trong ComboBox
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
    }
}
