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
                
                MessageBox.Show("Kết nối thành công!", "Cấu hình database", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Kết nối không thành công!", "Cấu hình database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
