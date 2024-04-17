using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace QuanLyRapPhim.Control
{
    public partial class BanVeControl : UserControl
    {
        Database database = new Database();
        List<int> gheDaChon = new List<int>();
        public int ghe { get; private set; }
        public int gheMoiHang { get; private set; }
        private bool dataLoaded = false;
        public BanVeControl()
        {
            InitializeComponent();
        }

        private void BanVeControl_Load(object sender, EventArgs e)
        {
            
            if (this.Visible) // Chỉ thực hiện load dữ liệu nếu biến dataLoaded là false
            {
                // Kiểm tra kết nối đến cơ sở dữ liệu
                if (!database.TestConnection())
                {
                    MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu!");
                    return;
                }

                DataTable dtLichChieu = database.LayDanhSachLichChieu();
                Func.LoadComboBoxFromDataTable(lichChieuComboBox, dtLichChieu, "Chọn lịch chiếu", "id", "thoigianchieu");
            }
        }


        
        // Phương thức xử lý sự kiện khi nút ghế được nhấn
        private void BtnGhe_Click(object sender, EventArgs e)
        {
            Button btnGhe = (Button)sender;
            // Xử lý logic khi nút ghế được nhấn
            MessageBox.Show("Bạn đã chọn ghế: " + btnGhe.Text);
        }
        public static void HienThiGhe(Panel ghePanel, int soGheTrongPhong, int soGheMoiHang, List<int> gheDaChon, List<int> gheDaBan)
        {
            // Xóa các nút ghế đã có trong ghePanel trước khi thêm mới
            ghePanel.Controls.Clear();

            // Tính số hàng
            if (soGheTrongPhong > 0 && soGheMoiHang > 0)
            {
                int soHang = soGheTrongPhong / soGheMoiHang;
                int soGheThua = soGheTrongPhong % soGheMoiHang; // Số ghế thừa dư

                // Padding bên phải
                int paddingRight = 100;

                // Tạo và hiển thị các nút ghế
                for (int i = 0; i < soHang; i++)
                {
                    for (int j = 0; j < soGheMoiHang; j++)
                    {
                        int soThuTuGhe = i * soGheMoiHang + j + 1;
                        Button btnGhe = new Button();
                        btnGhe.Text = "Ghế " + soThuTuGhe; // Đặt tên cho ghế
                        btnGhe.Width = 60; // Thiết lập chiều rộng cho nút
                        btnGhe.Height = 30; // Thiết lập chiều cao cho nút
                        btnGhe.Top = i * 40; // Tính toạ độ top
                        btnGhe.Left = j * 70 + (paddingRight * j); // Tính toạ độ left với padding bên phải

                        // Kiểm tra xem ghế có trong danh sách ghế đã bán hay không
                        if (gheDaBan.Contains(soThuTuGhe))
                        {
                            btnGhe.BackColor = Color.Red; // Nếu đã bán, đổi màu nền thành đỏ
                        }
                        else
                        {
                            // Kiểm tra xem ghế có trong danh sách đã chọn hay không
                            if (gheDaChon.Contains(soThuTuGhe))
                            {
                                btnGhe.BackColor = Color.LightGreen; // Nếu đã được chọn, đổi màu nền sang xanh lá
                            }
                            else
                            {
                                btnGhe.BackColor = Color.LightCyan; // Mặc định màu nền cho ghế
                            }
                        }

                        // Xử lý sự kiện click cho ghế
                        btnGhe.Click += (sender, e) =>
                        {
                            XuLyClickGhe(sender as Button, soThuTuGhe, gheDaChon, gheDaBan);
                        };

                        ghePanel.Controls.Add(btnGhe); // Thêm nút vào ghePanel
                    }
                }

                // Xử lý số ghế thừa
                if (soGheThua > 0)
                {
                    for (int j = 0; j < soGheThua; j++)
                    {
                        int soThuTuGhe = soHang * soGheMoiHang + j + 1;
                        Button btnGhe = new Button();
                        btnGhe.Text = "Ghế " + soThuTuGhe; // Đặt tên cho ghế
                        btnGhe.Width = 60; // Thiết lập chiều rộng cho nút
                        btnGhe.Height = 30; // Thiết lập chiều cao cho nút
                        btnGhe.Top = soHang * 40; // Tính toạ độ top
                        btnGhe.Left = j * 70 + (paddingRight * j); // Tính toạ độ left với padding bên phải

                        // Kiểm tra xem ghế có trong danh sách ghế đã bán hay không
                        if (gheDaBan.Contains(soThuTuGhe))
                        {
                            btnGhe.BackColor = Color.Red; // Nếu đã bán, đổi màu nền thành đỏ
                            btnGhe.Enabled = false; // Nếu đã được bán, vô hiệu hóa nút ghế
                        }
                        else
                        {
                            // Kiểm tra xem ghế có trong danh sách đã chọn hay không
                            if (gheDaChon.Contains(soThuTuGhe))
                            {
                                btnGhe.BackColor = Color.LightGreen; // Nếu đã được chọn, đổi màu nền sang xanh lá
                            }
                            else
                            {
                                btnGhe.BackColor = Color.LightCyan; // Mặc định màu nền cho ghế
                            }
                        }

                        // Xử lý sự kiện click cho ghế
                        btnGhe.Click += (sender, e) =>
                        {
                            XuLyClickGhe(sender as Button, soThuTuGhe, gheDaChon, gheDaBan);
                        };

                        ghePanel.Controls.Add(btnGhe); // Thêm nút vào ghePanel
                    }
                }
            }
        }


        // Hàm xử lý sự kiện khi click vào ghế
        private static void XuLyClickGhe(Button btnGhe, int soThuTuGhe, List<int> gheDaChon, List<int> gheDaBan)
        {
            // Kiểm tra xem ghế đã bán chưa
            if (gheDaBan.Contains(soThuTuGhe))
            {
                // Nếu ghế đã bán, không thực hiện thay đổi trạng thái
                MessageBox.Show("Ghế đã được bán và không thể chọn lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Đảo trạng thái của ghế khi click
            if (gheDaChon.Contains(soThuTuGhe))
            {
                gheDaChon.Remove(soThuTuGhe); // Nếu đã chọn, loại bỏ khỏi danh sách đã chọn
                btnGhe.BackColor = System.Drawing.Color.LightCyan; // Đổi màu nền về mặc định
            }
            else
            {
                gheDaChon.Add(soThuTuGhe); // Nếu chưa chọn, thêm vào danh sách đã chọn
                btnGhe.BackColor = System.Drawing.Color.LightGreen; // Đổi màu nền sang đỏ
            }
        }




        string maLichChieu;
        string maPhong;
        string tenPhim;
        string thoiGianChieu;
        decimal giaVe;
        decimal tongTien;
        private void lichChieuComboBox_CellCLick(object sender, EventArgs e)
        {

            maLichChieu = Func.splitIdLichChieu(lichChieuComboBox,0);
            maPhong = database.LayMaPhongTuMaLichChieu(maLichChieu);

            ghe = database.LaySoLuongGheTuMaPhong(maPhong);
            gheMoiHang = database.LaySoLuongGheMoiHang(maPhong);
            tenPhim = database.LayTenPhimTuMaLichChieu(maLichChieu);
            decimal giaVe = database.LayGiaVeTuIdLichChieu(maLichChieu);
            phongChieuLabel.Text = "Phòng: " + maPhong;
            phimChieuLabel.Text = "Phim: " + tenPhim;
            string giaVeFormatted = giaVe.ToString("N0");
            giaVeLabel.Text = "Giá vé: " + giaVeFormatted + " VND";
            

            
            HienThiGhe(ghePanel, ghe, gheMoiHang, gheDaChon, database.LayDanhSachGheDaBan(maLichChieu));
 
        }

        private decimal TinhTongTien(List<int> gheDaChon)
        {
            maLichChieu = Func.splitIdLichChieu(lichChieuComboBox, 0 );
            // Lấy giá vé từ cơ sở dữ liệu hoặc từ trường dữ liệu đã có
            giaVe = database.LayGiaVeTuIdLichChieu(maLichChieu); // Lấy giá vé từ cơ sở dữ liệu hoặc trường dữ liệu đã có

            // Tính tổng tiền dựa trên số lượng ghế và giá vé của mỗi ghế
            int soLuongGheDaChon = gheDaChon.Count;
            decimal tongTien = soLuongGheDaChon * giaVe;

            return tongTien;
        }
        
        private void thanhToanBtn_Click(object sender, EventArgs e)
        {
            if(gheDaChon.Count != 0)
            {
                thoiGianChieu = Func.splitIdLichChieu(lichChieuComboBox, 1);
                tongTien = TinhTongTien(gheDaChon);
                // Hiển thị hóa đơn
                string hoaDon = $"*** HÓA ĐƠN ***\n" +
                                $"Mã lịch chiếu: {maLichChieu}\n" +
                                $"Tên phim: {tenPhim}\n" +
                                $"Thời gian chiếu: {thoiGianChieu}\n" +
                                $"Số ghế đã chọn: {string.Join(", ", gheDaChon)}\n" +
                                $"Tổng tiền: {tongTien.ToString("N0")} VND";
               // Hiển thị MessageBox và sau đó tạo một instance của FormThanhToan
                DialogResult result = MessageBox.Show(hoaDon, "HA", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    string imageUrl = "https://img.vietqr.io/image/mbbank-6868039999-compact2.png?amount=" + tongTien + "&addInfo=Thanh toan ve&accountName=NGUYEN QUANG HA";

                    FormThanhToan formThanhToan = new FormThanhToan(imageUrl);

                    // Ẩn form chính
                    MainForm.ToggleMainFormVisibility();

                    // Hiển thị form thanh toán
                    formThanhToan.FormClosed += (s, args) =>
                    {
                        // Hiện lại MainForm khi FormThanhToan đóng
                        MainForm.ToggleMainFormVisibility();

                        // Kiểm tra xem FormThanhToan đã được đóng do thành công hay không
                        if (formThanhToan.ThanhToanThanhCong)
                        {
                            if (gheDaChon.Count > 0)
                            {
                                // Thực hiện các hành động khi thanh toán thành công
                                //// Ví dụ: Hiển thị thông báo, thêm vé vào database, v.v.
                                //MessageBox.Show("Thanh toán thành công!");
                                //bool resultTaoVe = database.ThemVe(maLichChieu, gheDaChon, giaVe, "1");
                                //if (resultTaoVe)
                                //{
                                //    MessageBox.Show("Đã thêm vé vào cơ sở dữ liệu!");
                                //    gheDaChon.Clear();
                                //    testLabel.Text = maLichChieu;
                                //    // Cập nhật danh sách ghế đã bán
                                //    List<int> gheDaBan = database.LayDanhSachGheDaBan(maLichChieu);

                                //    // Cập nhật lại hiển thị ghế

                                //    HienThiGhe(ghePanel, ghe, gheMoiHang, gheDaChon, gheDaBan);
                                //}
                                //else
                                //{
                                //    MessageBox.Show("Thêm vé vào cơ sở dữ liệu thất bại!");
                                //}
                                //---------------------------
                                // Sau khi thêm vé vào cơ sở dữ liệu và hiển thị thông báo

                                bool resultTaoVe = database.ThemVe(maLichChieu, gheDaChon, giaVe, "1");
                                if (resultTaoVe)
                                {
                                    DialogResult dialogResult = MessageBox.Show("Thanh toán thành công!\nBạn có muốn tạo vé để in không?", "HA", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                                    if(dialogResult == DialogResult.Yes)
                                    {
                                        foreach (var ghe in gheDaChon)
                                        {
                                            // Tạo một document PDF mới cho mỗi ghế với kích thước trang mới
                                            PdfDocument pdf = new PdfDocument();
                                            PdfPage page = pdf.AddPage();

                                            // Đặt kích thước trang PDF (ví dụ: 8.5 x 11 inch)
                                            double pageWidth = XUnit.FromInch(4.5);
                                            double pageHeight = XUnit.FromInch(7);
                                            page.Width = pageWidth;
                                            page.Height = pageHeight;

                                            // Tạo đối tượng graphics từ trang PDF
                                            XGraphics gfx = XGraphics.FromPdfPage(page);

                                            // Tạo một font cho văn bản
                                            XFont titleFont = new XFont("Arial", 14, XFontStyle.Bold);
                                            XFont regularFont = new XFont("Arial", 14);

                                            // Vẽ từng dòng thông tin một
                                            int lineHeight = 10; // Độ lớn của mỗi dòng
                                            int yPosition = 80; // Vị trí dọc ban đầu

                                            // Vẽ các thông tin vé lên trang PDF
                                            gfx.DrawString("Phong chieu:", titleFont, XBrushes.Black, new XPoint(30, yPosition));
                                            gfx.DrawString(maPhong, regularFont, XBrushes.Black, new XPoint(180, yPosition += lineHeight));

                                            gfx.DrawString("Thoi gian chieu:", titleFont, XBrushes.Black, new XPoint(30, yPosition += lineHeight));
                                            gfx.DrawString(thoiGianChieu, regularFont, XBrushes.Black, new XPoint(180, yPosition += lineHeight));

                                            gfx.DrawString("Ghe:", titleFont, XBrushes.Black, new XPoint(30, yPosition += lineHeight));
                                            gfx.DrawString(ghe.ToString(), regularFont, XBrushes.Black, new XPoint(180, yPosition += lineHeight));

                                            gfx.DrawString("Gia ve:", titleFont, XBrushes.Black, new XPoint(30, yPosition += lineHeight));
                                            gfx.DrawString(giaVe.ToString(), regularFont, XBrushes.Black, new XPoint(180, yPosition += lineHeight));

                                            // Tạo mã vạch cho mã lịch chiếu
                                            BarcodeWriter barcodeWriter = new BarcodeWriter();
                                            barcodeWriter.Format = BarcodeFormat.CODE_128;
                                            barcodeWriter.Options.Width = 470; // Độ rộng của mã vạch
                                            barcodeWriter.Options.Height = 80; // Độ cao của mã vạch
                                            Bitmap barcodeBitmap = barcodeWriter.Write(maLichChieu);

                                            // Chuyển đổi bitmap mã vạch
                                            XImage barcodeImage = XImage.FromGdiPlusImage(barcodeBitmap);

                                            // Vẽ mã vạch lên trang PDF
                                            gfx.DrawImage(barcodeImage, new XRect(50, 20, barcodeImage.PixelWidth / 2, barcodeImage.PixelHeight / 2));

                                            // Lưu trữ PDF vào một tệp với tên tương ứng với ghế
                                            string pdfFileName = "ve_" + maLichChieu + "_ghe_" + ghe + ".pdf";
                                            pdf.Save(pdfFileName);

                                            // Hiển thị thông báo khi PDF được tạo thành công
                                            System.Diagnostics.Process.Start(pdfFileName);
                                        }
                                    }
                                    

                                    gheDaChon.Clear();
                                    testLabel.Text = maLichChieu;

                                    // Cập nhật danh sách ghế đã bán
                                    List<int> gheDaBan = database.LayDanhSachGheDaBan(maLichChieu);

                                    // Cập nhật lại hiển thị ghế
                                    HienThiGhe(ghePanel, ghe, gheMoiHang, gheDaChon, gheDaBan);
                                }





                                //-------------
                            }
                        }
                    };
                    formThanhToan.Show();


                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ghế cần mua!", "HA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
      
    }
}
