using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyRapPhim
{
    public partial class ConfigDatabase : Form
    {
        private Database database = new Database();
        public ConfigDatabase()
        {
            InitializeComponent();
        }
        public static string dataSource { get; private set; }
        public static string initialCatalog { get; private set; }
        public static string connectionString { get; private set; }

        private void checkConnectBtn_Click(object sender, EventArgs e)
        {
            dataSource = dataSourceTextBox.Text;
            initialCatalog = initialCatalogTextBox.Text;
            connectionString = @"Data Source=" + ConfigDatabase.dataSource + @"\;Initial Catalog=" + ConfigDatabase.initialCatalog + @";Integrated Security=True";

            if (database.TestConnection())
            {
                // Lưu thông tin tài khoản vào cài đặt
                Properties.Settings.Default.dataSource = dataSource;
                Properties.Settings.Default.initialCatalog = initialCatalog;
                Properties.Settings.Default.Save();
                //MessageBox.Show("Kết nối thành công!", "Cấu hình database", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Kết nối không thành công!", "Cấu hình database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigDatabase_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.dataSource) && !string.IsNullOrEmpty(Properties.Settings.Default.initialCatalog))
            {
                dataSourceTextBox.Text = Properties.Settings.Default.dataSource;
                initialCatalogTextBox.Text = Properties.Settings.Default.initialCatalog;
            }
        }
    }
}
