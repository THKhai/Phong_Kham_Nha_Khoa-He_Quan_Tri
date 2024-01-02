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

namespace DoAnHEQUANTRI.PhanHeNhanVien
{
    public partial class TinhTienNV : Form
    {
        SqlConnection _connection = null;
        SqlCommand _command = null;
        String _connectionString = "";
        public TinhTienNV()
        {
            InitializeComponent();
            _connectionString = @"Data Source=SPUTNIK-I;Initial Catalog=QuanLyPhongKhamNhaKhoa_HQT;Integrated Security=True;Encrypt=False";

        }
 
        private void button1_Click(object sender, EventArgs e)
        {
            // Lấy số điện thoại từ TextBox
            string phoneNumber = textBox1.Text;

            // Kiểm tra số điện thoại không trống
            if (string.IsNullOrEmpty(phoneNumber))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại bệnh nhân.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Kết nối đến cơ sở dữ liệu
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    // Tạo đối tượng SqlCommand để thực thi stored procedure
                    using (SqlCommand command = new SqlCommand("p_TinhTienNV", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        // Thêm tham số đầu vào
                        command.Parameters.AddWithValue("@SoDienThoai", phoneNumber);

                        // Thêm tham số đầu ra
                        command.Parameters.Add("@TotalCost", System.Data.SqlDbType.Float).Direction = System.Data.ParameterDirection.Output;

                        // Thực thi stored procedure
                        command.ExecuteNonQuery();

                        // Lấy giá trị tổng chi phí từ tham số đầu ra
                        float totalCost = Convert.ToSingle(command.Parameters["@TotalCost"].Value);

                        // Hiển thị kết quả
                        textBox2.Text = totalCost.ToString("C");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
