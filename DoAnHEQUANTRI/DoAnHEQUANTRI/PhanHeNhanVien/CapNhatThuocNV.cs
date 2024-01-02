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
    public partial class CapNhatThuocNV : Form
    {
        SqlConnection _connection = null;
        SqlCommand _command = null;
        String _connectionString = "";
        
        decimal soluong = 0;
        public CapNhatThuocNV()
        {
            InitializeComponent();
            _connectionString = @"Data Source=SPUTNIK-I;Initial Catalog=QuanLyPhongKhamNhaKhoa_HQT;Integrated Security=True;Encrypt=False";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string MaThuoc = textBox1.Text;
            soluong = numericUpDown1.Value;
            // Kiểm tra số điện thoại không trống
            if (string.IsNullOrEmpty(MaThuoc))
            {
                MessageBox.Show("Vui lòng nhập mã thuốc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand("CapNhat_SoLuong_Thuoc", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaThuoc", MaThuoc);
                        command.Parameters.AddWithValue("@SoLuong", soluong);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Cập nhật số lượng thuốc thành công!");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi cập nhật số lượng thuốc: " + ex.Message);
            }
            finally
            {
                // Đảm bảo kết nối được đóng ngay cả khi có lỗi xảy ra hoặc không
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }

        }
    }
}
