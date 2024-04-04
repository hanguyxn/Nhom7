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
        private Database database;
        public ConfigDatabase()
        {
            InitializeComponent();
        }

        private void checkConnectBtn_Click(object sender, EventArgs e)
        {
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
