using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Drawing;
using System.Collections;

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

        // Chuỗi kết nối
        public bool TestConnection()
        {
            SqlConnection connection = new SqlConnection(ConfigDatabase.connectionString);
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
        public bool TestConnection(string dataSource, string initialCatalog)
        {
           
            SqlConnection connection = new SqlConnection(ConfigDatabase.connectionString);
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
            using (SqlConnection connection = new SqlConnection(ConfigDatabase.connectionString))
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


        public DataTable LayDanhSach(string query)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConfigDatabase.connectionString))
            {
                
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
            using (SqlConnection connection = new SqlConnection(ConfigDatabase.connectionString))
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
            using (SqlConnection connection = new SqlConnection(ConfigDatabase.connectionString))
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
            using (SqlConnection connection = new SqlConnection(ConfigDatabase.connectionString))
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
            using (SqlConnection connection = new SqlConnection(ConfigDatabase.connectionString))
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
        public string LayMaPhongTuThoiGianChieu(string thoigianchieu)
        {
            string maPhong = "";
            using (SqlConnection connection = new SqlConnection(ConfigDatabase.connectionString))
            {
                string query = "SELECT maphong FROM lichchieu WHERE thoigianchien = @ThoiGianChieu";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ThoiGianChieu", thoigianchieu);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        maPhong = result.ToString();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi: " + ex.Message);
                }
            }
            return maPhong;
        }
        public string LayMaPhongTuMaLichChieu(string maLichChieu)
        {
            string maPhong = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigDatabase.connectionString))
                {
                    connection.Open();
                    string query = "SELECT idphong FROM LichChieu WHERE id = @MaLichChieu";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaLichChieu", maLichChieu);
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        maPhong = result.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return maPhong;
        }
        public string LayTenPhimTuMaLichChieu(string maLichChieu)
        {
            string tenPhim = string.Empty;
            using (SqlConnection connection = new SqlConnection(ConfigDatabase.connectionString))
            {
                string query = "SELECT TenPhim FROM Phim WHERE MaPhim IN (SELECT MaPhim FROM LichChieu WHERE id = @MaLichChieu)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaLichChieu", maLichChieu);
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        tenPhim = result.ToString();
                    }
                }
            }
            return tenPhim;
        }
        public decimal LayGiaVeTuIdLichChieu(string idLichChieu)
        {
            decimal giaVe = 0;
            using (SqlConnection connection = new SqlConnection(ConfigDatabase.connectionString))
            {
                string query = "SELECT GiaVe FROM LichChieu WHERE id = @IdLichChieu";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdLichChieu", idLichChieu);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        giaVe = Convert.ToDecimal(result);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    // Xử lý ngoại lệ nếu cần thiết
                }
            }
            return giaVe;
        }
        public int LaySoLuongGheTuMaPhong(string maPhong)
        {
            int soLuongGhe = 0;
            using (SqlConnection connection = new SqlConnection(ConfigDatabase.connectionString))
            {
                string query = "SELECT soluongghe FROM phongchieu WHERE maphong = @MaPhong";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaPhong", maPhong);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        soLuongGhe = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi: " + ex.Message);
                }
            }
            return soLuongGhe;
        }
        public string GetUserRoleFromDatabase(string username)
        {
            string userRole = ""; // Vai trò của người dùng

            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigDatabase.connectionString))
                {
                    string query = "SELECT Role FROM Users WHERE Username = @Username";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                userRole = reader["Role"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return userRole;
        }

        public string GetNameFromDatabase(string username)
        {
            string userRole = ""; // Vai trò của người dùng

            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigDatabase.connectionString))
                {
                    string query = "SELECT HoTen FROM Users WHERE Username = @Username";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                userRole = reader["HoTen"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return userRole;
        }
        public int LaySoLuongGheMoiHang(string maPhong)
        {
            int soLuongGhe = 0;
            using (SqlConnection connection = new SqlConnection(ConfigDatabase.connectionString))
            {
                string query = "SELECT soghemoihang FROM phongchieu WHERE maphong = @MaPhong";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaPhong", maPhong);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        soLuongGhe = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi: " + ex.Message);
                }
            }
            return soLuongGhe;
        }
        public bool XoaTheLoai(string maTheLoai)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigDatabase.connectionString))
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

            using (SqlConnection connection = new SqlConnection(ConfigDatabase.connectionString))
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
                using (SqlConnection connection = new SqlConnection(ConfigDatabase.connectionString))
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
                using (SqlConnection connection = new SqlConnection(ConfigDatabase.connectionString))
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
                using (SqlConnection connection = new SqlConnection(ConfigDatabase.connectionString))
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
                using (SqlConnection connection = new SqlConnection(ConfigDatabase.connectionString))
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
            using (SqlConnection connection = new SqlConnection(ConfigDatabase.connectionString))
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
                using (SqlConnection connection = new SqlConnection(ConfigDatabase.connectionString))
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
                using (SqlConnection connection = new SqlConnection(ConfigDatabase.connectionString))
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
                using (SqlConnection connection = new SqlConnection(ConfigDatabase.connectionString))
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
                using (SqlConnection connection = new SqlConnection(ConfigDatabase.connectionString))
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
                using (SqlConnection connection = new SqlConnection(ConfigDatabase.connectionString))
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
                using (SqlConnection connection = new SqlConnection(ConfigDatabase.connectionString))
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

        public bool Xoa(string table, string cell, string value)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigDatabase.connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM "+ table + " WHERE "+ cell + " = @"+ cell;
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@"+ cell, value);
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
        public bool ThemLichChieu(string id, DateTime thoigianchieu, string idphong,string phim, decimal giave, int trangthai)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigDatabase.connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO LichChieu (id, thoigianchieu, idphong, phim, giave, trangthai) VALUES (@Id, @ThoiGianChieu, @IdPhong,@Phim, @GiaVe, @TrangThai)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@ThoiGianChieu", thoigianchieu);
                    command.Parameters.AddWithValue("@IdPhong", idphong);
                    command.Parameters.AddWithValue("@Phim", phim);
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


        public int LaySoGheTrongPhong(string maPhongChieu)
        {
            int soLuongGhe = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigDatabase.connectionString))
                {
                    string query = "SELECT SoLuongGhe FROM PhongChieu WHERE MaPhongChieu = @MaPhongChieu";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaPhongChieu", maPhongChieu);
                        connection.Open();
                        soLuongGhe = (int)command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            return soLuongGhe;
        }


        public int LaySoGheMoiHang(string maPhongChieu)
        {
            int soGheMoiHang = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigDatabase.connectionString))
                {
                    string query = "SELECT SoGheMoiHang FROM PhongChieu WHERE MaPhongChieu = @MaPhongChieu";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaPhongChieu", maPhongChieu);
                        connection.Open();
                        soGheMoiHang = (int)command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            return soGheMoiHang;
        }
        ///////vé
        public bool ThemVe(string maLichChieu, List<int> danhSachGhe, decimal giaVe, string maKhachHang)
        {
            try
            {
                using (var connection = new SqlConnection(ConfigDatabase.connectionString))
                {
                    connection.Open();

                    foreach (int soGhe in danhSachGhe)
                    {
                        string maVe = RandomMaVe(); // Tạo chuỗi mã vé ngẫu nhiên
                        DateTime ngayBanVe = DateTime.Now; // Lấy thời gian hiện tại

                        // Kiểm tra mã vé có tồn tại trong cơ sở dữ liệu chưa
                        while (KiemTraMaVeTonTai(maVe))
                        {
                            maVe = RandomMaVe();
                        }

                        string query = "INSERT INTO Ve (MaVe, idlichchieu, Ghe, NgayBanVe, GiaVe, MaKhachHang) VALUES (@MaVe, @IdLichChieu, @Ghe, @NgayBanVe, @GiaVe, @MaKhachHang)";
                        using (var command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@MaVe", maVe);
                            command.Parameters.AddWithValue("@IdLichChieu", maLichChieu);
                            command.Parameters.AddWithValue("@Ghe", soGhe);
                            command.Parameters.AddWithValue("@NgayBanVe", ngayBanVe);
                            command.Parameters.AddWithValue("@GiaVe", giaVe);
                            command.Parameters.AddWithValue("@MaKhachHang", maKhachHang);

                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected <= 0)
                            {
                                return false; // Trả về false nếu thêm vé không thành công
                            }
                        }
                    }

                    return true; // Trả về true khi thêm vé thành công cho tất cả ghế
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        private string RandomMaVe()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, 7)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private bool KiemTraMaVeTonTai(string maVe)
        {
            using (var connection = new SqlConnection(ConfigDatabase.connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Ve WHERE MaVe = @MaVe";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaVe", maVe);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        public List<int> LayDanhSachGheDaBan(string maLichChieu)
        {
            // Khởi tạo danh sách lưu trữ vị trí của các ghế đã bán
            List<int> danhSachGheDaBan = new List<int>();

            // Mở kết nối đến cơ sở dữ liệu
            using (SqlConnection connection = new SqlConnection(ConfigDatabase.connectionString))
            {
                try
                {
                    connection.Open();

                    // Tạo câu truy vấn SQL để lấy danh sách ghế đã bán dựa trên mã lịch chiếu
                    string query = "SELECT Ghe FROM Ve WHERE IdLichChieu = @MaLichChieu";

                    // Tạo đối tượng SqlCommand
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số @MaLichChieu vào câu truy vấn
                        command.Parameters.AddWithValue("@MaLichChieu", maLichChieu);

                        // Thực thi câu truy vấn và đọc dữ liệu từ bảng Ve
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Duyệt qua các dòng kết quả
                            while (reader.Read())
                            {
                                // Lấy giá trị cột Ghe từ mỗi dòng và thêm vào danh sách danhSachGheDaBan
                                int soGhe = reader.GetInt32(0);
                                danhSachGheDaBan.Add(soGhe);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý ngoại lệ
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            // Trả về danh sách các ghế đã bán
            return danhSachGheDaBan;
        }
    }
}
