
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
    // Định nghĩa lớp ComboBoxItem để lưu trữ Text và Value của mỗi mục trong ComboBox
    
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
            mainPanel.Controls.Clear();
            //control.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(control);
            
        }

        private void userBtn_Click(object sender, EventArgs e)
        {
            ShowControl(quanLyUserControl);
        }

        private void phimBtn_Click(object sender, EventArgs e)
        {
            ShowControl(quanLyPhimControl);
        }
    }
}
