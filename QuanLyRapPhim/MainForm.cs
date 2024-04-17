
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
        private QuanLyPhimControl quanLyPhimControl = new QuanLyPhimControl();
        private QuanLyUserControl quanLyUserControl = new QuanLyUserControl();
        private BanVeControl banVeControl = new BanVeControl();
        private ThongKeControl thongKeControl = new ThongKeControl();
        private Database database = new Database();
        private string username = LoginForm.username;
        private static bool IsVisible = true;

        public MainForm()
        {
            InitializeComponent();
        }
        // Tạo một biến static để lưu trữ phiên bản duy nhất của MainForm
        private static MainForm instance;

       
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
            InitializeUserInterface();

        }


            private void CloseMainForm(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


        private void ToggleButtonAppearanceX(Button clickedButton)
        {
            userBtn.BackColor = phimBtn.BackColor = banVeBtn.BackColor = thongKeBtn.BackColor = Color.PeachPuff;
            clickedButton.BackColor = Color.White;
        }

        private void InitializeUserInterface()
        {
            userBtn.FlatStyle = FlatStyle.Flat;
            userBtn.FlatAppearance.BorderSize = 0;

            phimBtn.FlatStyle = FlatStyle.Flat;
            phimBtn.FlatAppearance.BorderSize = 0;

            banVeBtn.FlatStyle = FlatStyle.Flat;
            banVeBtn.FlatAppearance.BorderSize = 0;

            thongKeBtn.FlatStyle = FlatStyle.Flat;
            thongKeBtn.FlatAppearance.BorderSize = 0;
            banVeBtn.Enabled = true;
            if (banVeBtn.Enabled)
            {
                banVeBtn.BackColor = Color.White;
            }
            ShowControl(banVeControl);
            if (!database.GetUserRoleFromDatabase(username).Equals("admin     "))
            {
                userBtn.Enabled = false;
                phimBtn.Enabled = false;
                thongKeBtn.Enabled = false;

                userBtn.Hide();
                phimBtn.Hide();
                thongKeBtn.Hide();
            }

            titleTop.Text = "Xin chào " + database.GetNameFromDatabase(username);
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
            ToggleButtonAppearanceX(userBtn);
        }

        private void phimBtn_Click(object sender, EventArgs e)
        {
            ShowControl(quanLyPhimControl);
            ToggleButtonAppearanceX(phimBtn);
        }

        private void banVeBtn_Click(object sender, EventArgs e)
        {
            ShowControl(banVeControl);
            ToggleButtonAppearanceX(banVeBtn);
        }

        private void thongKeBtn_Click(object sender, EventArgs e)
        {
            ShowControl(thongKeControl);
            ToggleButtonAppearanceX(thongKeBtn);
        }
    }
}
