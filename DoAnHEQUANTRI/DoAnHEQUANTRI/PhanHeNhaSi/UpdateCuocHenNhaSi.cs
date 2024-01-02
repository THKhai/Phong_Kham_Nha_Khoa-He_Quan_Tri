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

namespace DoAnHEQUANTRI.PhanHeNhaSi
{
    public partial class UpdateCuocHenNhaSi : Form
    {
        string current_MaBN = null;
        string current_MaNhaSi = null;
        SqlConnection _connection = null;
        SqlCommand _command = null;
        string _connectionString = null;
        public UpdateCuocHenNhaSi(string MaBN,string MaNhaSi)
        {
            current_MaBN = MaBN;
            current_MaNhaSi= MaNhaSi;
            InitializeComponent();
            _connectionString = @"Data Source=KHAINEHAHA;Initial Catalog=QuanLyPhongKhamNhaKhoa_HQT;Integrated Security=True;Encrypt=False";
            label3.Text = current_MaBN;
            label6.Text = current_MaNhaSi;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void dangky_Click(object sender, EventArgs e)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("CapNhatLichHenNS", _connection))
                {
                    command.Parameters.AddWithValue("@MaNhaSi", current_MaNhaSi);
                    command.Parameters.AddWithValue("@NgayGio", ThoiGian.Value);
                    command.Parameters.AddWithValue("@MaBN", current_MaBN);
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        _connection.Open();
                        command.ExecuteNonQuery();

                        // Display success message
                        MessageBox.Show("Lịch hẹn đã được cập nhật thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Close the form
                        this.Close();
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 50000 && ex.Class == 14)
                        {
                            MessageBox.Show("Lịch hẹn đặt đã bị trùng giờ với một lịch hẹn khác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    finally
                    {
                        _connection.Close();
                    }
                }
            }
        }


        private void ThoiGian_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
