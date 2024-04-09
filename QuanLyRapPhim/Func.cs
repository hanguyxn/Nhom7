using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyRapPhim
{
    public class Func
    {
        public static void LoadComboBoxFromDataTable(ComboBox comboBox, DataTable dataTable, string indexString, string displayMember)
        {
            // Xóa các mục đã có trong ComboBox trước khi thêm mới
            comboBox.Items.Clear();

            // Thêm một mục trống đầu tiên vào ComboBox để cho phép người dùng chọn
            comboBox.Items.Add(indexString);

            // Thêm từng mục từ DataTable vào ComboBox
            foreach (DataRow row in dataTable.Rows)
            {
                // Lấy giá trị từ cột displayMember của mỗi dòng
                string displayValue = row[displayMember].ToString();
                comboBox.Items.Add(displayValue);
            }

            // Chọn mục đầu tiên trong ComboBox là mục trống
            comboBox.SelectedIndex = 0;
        }
    }
}
