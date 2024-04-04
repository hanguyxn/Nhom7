
using QuanLyRapPhim.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyRapPhim
{
    public partial class MainForm : Form
    {
        private QuanLyPhimControl quanLyPhimControl; // Khai báo control ThemPhimControl
        private QuanLyUserControl quanLyUserControl;


        public MainForm()
        {
            InitializeComponent();
            

        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            quanLyPhimControl = new QuanLyPhimControl(); // Khởi tạo control ThemPhimControl
            quanLyUserControl = new QuanLyUserControl(); // Khởi tạo control ThemPhimControl        }
        }


            private void CloseMainForm(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }



        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            
            
        }

  
        private void ShowControl(System.Windows.Forms.Control control)
        {
            // Xóa tất cả các control cũ khỏi form
            mainPanel.Controls.Clear();

            // Thêm control mới vào form
            mainPanel.Controls.Add(control);
            //this.Controls.Add(control);
        }

        private void userBtn_Click(object sender, EventArgs e)
        {
            
            quanLyUserControl.Dock = DockStyle.Fill; // Dock control để lấp đầy form
            ShowControl(quanLyUserControl);
        }

        private void phimBtn_Click(object sender, EventArgs e)
        {
            // Hiển thị control ThemPhimControl khi nhấp vào button
            
            quanLyPhimControl.Dock = DockStyle.Fill; // Dock control để lấp đầy form
            ShowControl(quanLyPhimControl);
        }
    }
}
