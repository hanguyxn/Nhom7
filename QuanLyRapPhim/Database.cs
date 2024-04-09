using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyRapPhim
{
    class Phim
    {
        public string MaPhim { get; set; }
        public string TenPhim { get; set; }
        public string MoTa { get; set; }
        public float ThoiLuong { get; set; }
        public DateTime NgayKhoiChieu { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string QuocGia { get; set; }
        public string DaoDien { get; set; }
        public int NamSanXuat { get; set; }
        public string TheLoai { get; set; }
        public string Banner { get; set; }

        public Phim(string maPhim, string tenPhim, string moTa, float thoiLuong, DateTime ngayKhoiChieu,
                    DateTime ngayKetThuc, string quocGia, string daoDien, int namSanXuat, string theLoai, string banner)
        {
            MaPhim = maPhim;
            TenPhim = tenPhim;
            MoTa = moTa;
            ThoiLuong = thoiLuong;
            NgayKhoiChieu = ngayKhoiChieu;
            NgayKetThuc = ngayKetThuc;
            QuocGia = quocGia;
            DaoDien = daoDien;
            NamSanXuat = namSanXuat;
            TheLoai = theLoai;
            Banner = banner;
        }
    }
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
        public DataTable LayDanhSachTheLoai()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM TheLoai";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }
        public DataTable LayDanhSachLichChieu()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM lichchieu";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        public DataTable LayDanhSachPhongChieu()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM PhongChieu";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }


        public DataTable LayDanhSachUser()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Users";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }
        public bool XoaTheLoai(string maTheLoai)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM TheLoai WHERE MaTheLoai = @MaTheLoai";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaTheLoai", maTheLoai);
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
        public bool ThemPhim(string maPhim, string tenPhim, string moTa, float thoiLuong, DateTime ngayKhoiChieu, DateTime ngayKetThuc, string quocGia, string daoDien, int namSanXuat, string theLoai, string banner)
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
                        {
                            return true;
                        }
                            
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
        public bool XoaPhim(string maPhim)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Phim WHERE MaPhim = @MaPhim";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaPhim", maPhim);
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
        public bool ThemTheLoai(string maTheLoai, string tenTheLoai, string moTa)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO TheLoai (MaTheLoai, TenTheLoai, MoTa) VALUES (@MaTheLoai, @TenTheLoai, @MoTa)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaTheLoai", maTheLoai);
                    command.Parameters.AddWithValue("@TenTheLoai", tenTheLoai);
                    command.Parameters.AddWithValue("@MoTa", moTa);
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
        public void HienThiThongTinPhim(string maPhim,TextBox maPhimTxt, TextBox tenPhimTxt, TextBox thoiLuongTxt, DateTimePicker ngayKhoiChieuDateTimePicker, DateTimePicker ngayKetThucDateTimePicker, TextBox quocGiaTxt, TextBox daoDienTxt, TextBox namSanXuatTextBox, ComboBox theLoaiComboBox)
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
                        namSanXuatTextBox.Text = reader["NamSanXuat"].ToString();
                        theLoaiComboBox.Text = reader["TheLoai"].ToString(); // Hiển thị thông tin thể loại phim trong ComboBox
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        public bool ThemPhongChieu(string maPhong, string tenPhong, int soLuongGhe, int soGheMoiHang, int tinhTrang)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO PhongChieu (MaPhong, TenPhong, SoLuongGhe, SoGheMoiHang, TinhTrang) VALUES (@MaPhong, @TenPhong, @SoLuongGhe, @SoGheMoiHang, @TinhTrang)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaPhong", maPhong);
                    command.Parameters.AddWithValue("@TenPhong", tenPhong);
                    command.Parameters.AddWithValue("@SoLuongGhe", soLuongGhe);
                    command.Parameters.AddWithValue("@SoGheMoiHang", soGheMoiHang);
                    command.Parameters.AddWithValue("@TinhTrang", tinhTrang);
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
        public bool SuaPhongChieu(string maPhong, string tenPhong, int soLuongGhe, int soGheMoiHang, int tinhTrang)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE PhongChieu SET TenPhong = @TenPhong, SoLuongGhe = @SoLuongGhe, SoGheMoiHang = @SoGheMoiHang, TinhTrang = @TinhTrang WHERE MaPhong = @MaPhong";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TenPhong", tenPhong);
                    command.Parameters.AddWithValue("@SoLuongGhe", soLuongGhe);
                    command.Parameters.AddWithValue("@SoGheMoiHang", soGheMoiHang);
                    command.Parameters.AddWithValue("@TinhTrang", tinhTrang);
                    command.Parameters.AddWithValue("@MaPhong", maPhong);
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

        public bool XoaPhongChieu(string maPhong)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM PhongChieu WHERE MaPhong = @MaPhong";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaPhong", maPhong);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0; // Trả về true nếu có ít nhất một hàng được xóa
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public bool ThemNhanVien(string username, string password, string hoTen, string diaChi, string sdt, string role)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Users (Username, Password, HoTen, DiaChi, SDT, Role) VALUES (@Username, @Password, @HoTen, @DiaChi, @SDT, @Role)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@HoTen", hoTen);
                    command.Parameters.AddWithValue("@DiaChi", diaChi);
                    command.Parameters.AddWithValue("@SDT", sdt);
                    command.Parameters.AddWithValue("@Role", role);
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
        public bool SuaThongTinNhanVien(string username, string password, string hoTen, string diaChi, string sdt, string role)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Users SET Password = @Password, HoTen = @HoTen, DiaChi = @DiaChi, SDT = @SDT, Role = @Role WHERE Username = @Username";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@HoTen", hoTen);
                    command.Parameters.AddWithValue("@DiaChi", diaChi);
                    command.Parameters.AddWithValue("@SDT", sdt);
                    command.Parameters.AddWithValue("@Role", role);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0; // Trả về true nếu có ít nhất một hàng được cập nhật
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public bool XoaNhanVien(string username)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Users WHERE Username = @Username";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", username);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0; // Trả về true nếu có ít nhất một hàng được xóa
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
        //lịch chiếu
        public bool ThemLichChieu(string id, DateTime thoigianchieu, string idphong, decimal giave, int trangthai)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO LichChieu (id, thoigianchieu, idphong, giave, trangthai) VALUES (@Id, @ThoiGianChieu, @IdPhong, @GiaVe, @TrangThai)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@ThoiGianChieu", thoigianchieu);
                    command.Parameters.AddWithValue("@IdPhong", idphong);
                    command.Parameters.AddWithValue("@GiaVe", giave);
                    command.Parameters.AddWithValue("@TrangThai", trangthai);
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


        //////////////////het lich chieu
    }
}
