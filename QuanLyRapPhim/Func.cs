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
        public static void LoadComboBoxFromDataTable(ComboBox comboBox, DataTable dataTable, string indexString, string displayMember1, string displayMember2)
        {
            // Xóa các mục đã có trong ComboBox trước khi thêm mới
            comboBox.Items.Clear();

            // Thêm một mục trống đầu tiên vào ComboBox để cho phép người dùng chọn
            comboBox.Items.Add(indexString);

            // Thêm từng mục từ DataTable vào ComboBox
            foreach (DataRow row in dataTable.Rows)
            {
                // Lấy giá trị từ cột displayMember1 và displayMember2 của mỗi dòng
                string displayValue = row[displayMember1].ToString() + " | " + row[displayMember2].ToString();
                comboBox.Items.Add(displayValue);
            }

            // Chọn mục đầu tiên trong ComboBox là mục trống
            comboBox.SelectedIndex = 0;
        }

        public static string splitIdLichChieu(ComboBox box, int so)
        {
            string maLichChieu = "";
            // Lấy giá trị của ComboBox khi người dùng chọn
            string selectedValue = box.SelectedItem.ToString();

            // Tách chuỗi để lấy phần tử đầu tiên
            string[] parts = selectedValue.Split('|');
            if (parts.Length > 0)
            {
                // Gán phần tử đầu tiên vào biến maLichChieu
                return maLichChieu = parts[so].Trim();
            }
            return maLichChieu;
        }

        public static DataTable SearchAndUpdateDataGridView(DataGridView dataGridView, DataTable YourDataSource, string keyword)
        {
            // Tạo một DataTable mới để lưu trữ dữ liệu lọc
            DataTable filteredData = YourDataSource.Clone();

            // Kiểm tra xem từ khóa tìm kiếm có rỗng hay không
            if (string.IsNullOrWhiteSpace(keyword))
            {
                // Nếu rỗng, hiển thị toàn bộ dữ liệu
                return YourDataSource;
            }
            else
            {
                // Nếu không rỗng, tìm kiếm dữ liệu phù hợp với từ khóa
                foreach (DataRow row in YourDataSource.Rows)
                {
                    // Kiểm tra mỗi cột trong hàng để xem có cột nào chứa từ khóa không
                    foreach (var item in row.ItemArray)
                    {
                        if (item.ToString().Contains(keyword))
                        {
                            // Nếu hàng chứa từ khóa, thêm hàng đó vào DataTable lọc
                            filteredData.ImportRow(row);
                            break;
                        }
                    }
                }

                // Trả về DataTable lọc
                return filteredData;
            }
        }

    }
}
