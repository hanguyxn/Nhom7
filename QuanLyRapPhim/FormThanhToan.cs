using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyRapPhim
{
    public partial class FormThanhToan : Form
    {
        // Thuộc tính để lưu kết quả thanh toán
        public bool ThanhToanThanhCong { get; private set; }
        public bool NgayBanVe { get; private set; }
        public FormThanhToan(string imageUrl)
        {
            InitializeComponent();
            try
            {

            }catch { }
            // Tải ảnh từ URL và hiển thị trên PictureBox
            using (WebClient webClient = new WebClient())
            {
                byte[] data = webClient.DownloadData(imageUrl);
                using (var stream = new System.IO.MemoryStream(data))
                {
                    qrPictureBox.Image = Image.FromStream(stream);
                }
            }
        }
        private void thanhToanXong_Click(object sender, EventArgs e)
        {
            ThanhToanThanhCong = true;
            this.Close();
        }
    }
}
