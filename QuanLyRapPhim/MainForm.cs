
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyRapPhim
{
    // Định nghĩa lớp ComboBoxItem để lưu trữ Text và Value của mỗi mục trong ComboBox
    
    public partial class MainForm : Form
    {
        private QuanLyPhimControl quanLyPhimControl; // Khai báo control ThemPhimControl
        private QuanLyUserControl quanLyUserControl;
        private BanVeControl banVeControl;
        Database database = new Database();

        public MainForm()
        {
            InitializeComponent();
        }
        // Tạo một biến static để lưu trữ phiên bản duy nhất của MainForm
        private static MainForm instance;

       

        // Đánh dấu trạng thái của form chính
        private static bool IsVisible = true;
        string username = LoginForm.username;
        // Phương thức tĩnh để ẩn hoặc hiển thị form chính
        public static void ToggleMainFormVisibility()
        {
            IsVisible = !IsVisible;
            if (IsVisible)
            {
                Application.OpenForms[nameof(MainForm)].Show();
            }
            else
            {
                Application.OpenForms[nameof(MainForm)].Hide();
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            userBtn.FlatStyle = FlatStyle.Flat;
            userBtn.FlatAppearance.BorderSize = 0;

            phimBtn.FlatStyle = FlatStyle.Flat;
            phimBtn.FlatAppearance.BorderSize = 0;

            banVeBtn.FlatStyle = FlatStyle.Flat;
            banVeBtn.FlatAppearance.BorderSize = 0;


            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            banVeBtn.Enabled = true;
            if (banVeBtn.Enabled)
            {
                banVeBtn.BackColor = Color.White;
            }
            quanLyPhimControl = new QuanLyPhimControl(); // Khởi tạo control ThemPhimControl
            quanLyUserControl = new QuanLyUserControl(); // Khởi tạo control ThemPhimControl        }
            banVeControl = new BanVeControl(); // Khởi tạo control ThemPhimControl        }
            ShowControl(banVeControl);
            //banVeBtn.Text = username;
            if (database.GetUserRoleFromDatabase(username) != "admin     ")
            {
                userBtn.Enabled = false;
                phimBtn.Enabled = false;
                button1.Enabled = false;

                userBtn.Hide();
                phimBtn.Hide();
                button1.Hide();
            }
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
            if (userBtn.Enabled)
            {
                userBtn.BackColor = Color.White;
                phimBtn.BackColor = Color.PeachPuff;
                banVeBtn.BackColor = Color.PeachPuff;
                banVeBtn.BackColor = Color.PeachPuff;
            }
        }

        private void phimBtn_Click(object sender, EventArgs e)
        {
            ShowControl(quanLyPhimControl);
            if (phimBtn.Enabled)
            {
                phimBtn.BackColor = Color.White;
                userBtn.BackColor = Color.PeachPuff;
                banVeBtn.BackColor = Color.PeachPuff;
            }
        }

        private void banVeBtn_Click(object sender, EventArgs e)
        {
            ShowControl(banVeControl);
            if (banVeBtn.Enabled) 
            {
                phimBtn.BackColor = Color.PeachPuff;
                userBtn.BackColor = Color.PeachPuff;
                banVeBtn.BackColor = Color.White;
            }
        }
      
    }
}
