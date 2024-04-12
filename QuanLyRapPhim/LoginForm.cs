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
        private void loginBtn_Click(object sender, EventArgs e)
        {
            if(ConfigDatabase.initialCatalog != null && ConfigDatabase.dataSource != null)
            {
                username = usernameTextBox.Text;
                if (database.Login(usernameTextBox.Text, passwordTextBox.Text))
                {
                    //MessageBox.Show("Đăng nhập thành công!", "LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm mainForm = new MainForm();
                    this.Hide();
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại!", "LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Vui lòng kết nối csdl!", "LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


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
        }

        private void configDbBtn_Click(object sender, EventArgs e)
        {
            ConfigDatabase configDatabase = new ConfigDatabase();
            configDatabase.Show();
        }
    }
}
