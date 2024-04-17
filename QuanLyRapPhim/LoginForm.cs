using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyRapPhim
{
    public partial class LoginForm : Form
    {
        Database database = new Database();

        public LoginForm()
        {
            InitializeComponent();
           

        }
     
        public static string username { get; private set; }
        public static string password { get; private set; }
        private void loginBtn_Click(object sender, EventArgs e)
        {
            Login();


            //MainForm mainForm = new MainForm();
            //this.Hide();
            //mainForm.Show();
        }

        private void configDatabaseBtn_Click(object sender, EventArgs e)
        {
            ConfigDatabase configDatabase = new ConfigDatabase();
            configDatabase.Show();
        }

        private void LoginFom_Load(object sender, EventArgs e)
        {
            usernameTextBox.Focus();
            // Kiểm tra nếu có thông tin tài khoản trong cài đặt
            if (!string.IsNullOrEmpty(Properties.Settings.Default.username))
            {
                // Tự động điền thông tin tài khoản vào các ô TextBox
                usernameTextBox.Text = Properties.Settings.Default.username;
                passwordTextBox.Text = Properties.Settings.Default.password;
                saveLoginInfo.Checked = true;
                // Thực hiện đăng nhập tự động
                //Login();
            }
            
        }
        private void Login()
        {
            username = usernameTextBox.Text;
            password = passwordTextBox.Text;

            if (ConfigDatabase.initialCatalog != null && ConfigDatabase.dataSource != null)
            {
                
                if (database.Login(username, password))
                {
                    if (saveLoginInfo.Checked)
                    {
                        // Lưu thông tin tài khoản vào cài đặt
                        Properties.Settings.Default.username = username;
                        Properties.Settings.Default.password = password;
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        // Lưu thông tin tài khoản vào cài đặt
                        Properties.Settings.Default.username = "";
                        Properties.Settings.Default.password = "";
                        Properties.Settings.Default.Save();
                    }
                    

                    // Đăng nhập thành công, chuyển đến MainForm
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại!", "LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng kết nối csdl!", "LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                ConfigDatabase configDatabase = new ConfigDatabase();
                configDatabase.Show();

                
            }
        }
        private void configDbBtn_Click(object sender, EventArgs e)
        {
            ConfigDatabase configDatabase = new ConfigDatabase();
            configDatabase.Show();
        }
    }
}
