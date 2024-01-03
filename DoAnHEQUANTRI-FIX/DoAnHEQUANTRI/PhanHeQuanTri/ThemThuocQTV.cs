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

namespace DoAnHEQUANTRI.PhanHeQuanTri
{
    public partial class ThemThuocQTV : Form
    {
        SqlConnection _connection = null;
        SqlCommand _command = null;
        String _connectionString = "";
        public ThemThuocQTV()
        {
            InitializeComponent();
            _connectionString = @"Data Source=DESKTOP-OB2NBQU;Initial Catalog=QuanLyPhongKhamNhaKhoa_HQT;Integrated Security=True;Encrypt=False";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text) || 
                    string.IsNullOrWhiteSpace(textBox2.Text) ||
                    string.IsNullOrWhiteSpace(textBox3.Text) || 
                    string.IsNullOrWhiteSpace(textBox4.Text) || 
                    string.IsNullOrWhiteSpace(textBox5.Text))
                {
                    MessageBox.Show("Không để trống những thông tin cần thiết");
                }
                else
                {
                    _connection = new SqlConnection(_connectionString);
                    _connection.Open();
                    String procname = "p_ThemThuoc";
                    _command = new SqlCommand(procname);
                    _command.CommandType = CommandType.StoredProcedure;
                    _command.Connection = _connection;
                    _command.Parameters.Add("@MaThuoc", SqlDbType.VarChar);
                    _command.Parameters.Add("@TenThuoc", SqlDbType.NVarChar);
                    _command.Parameters.Add("@DonViTinh", SqlDbType.NVarChar);
                    _command.Parameters.Add("@ChiDinh", SqlDbType.NVarChar);
                    _command.Parameters.Add("@SoLuongTon", SqlDbType.Int);
                    _command.Parameters.Add("@NgayHetHan", SqlDbType.Date);
                    _command.Parameters.Add("@Delay", SqlDbType.DateTime);


                    _command.Parameters["@MaThuoc"].Value = textBox1.Text;
                    _command.Parameters["@TenThuoc"].Value = textBox2.Text;
                    _command.Parameters["@DonViTinh"].Value = textBox3.Text;
                    _command.Parameters["@ChiDinh"].Value = textBox4.Text;
                    _command.Parameters["@SoLuongTon"].Value = textBox5.Text;
                    _command.Parameters["@NgayHetHan"].Value = dateTimePicker1.Text;
                    _command.Parameters["@Delay"].Value = dateTimePicker2.Text;
                    _command.ExecuteNonQuery();
                    MessageBox.Show("Thêm thuốc thành công");
                    this.Close();
                    var form = new ThemXoaSuaThuocQTV();
                    form.Show();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new ThemXoaSuaThuocQTV();
            form.Show();
            Hide();
        }
    }
}
