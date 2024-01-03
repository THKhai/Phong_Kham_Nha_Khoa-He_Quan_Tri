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
    public partial class SuaThuocQTV : Form
    {
        SqlConnection _connection = null;
        SqlCommand _command = null;
        String _connectionString = "";
        public SuaThuocQTV()
        {
            InitializeComponent();
            _connectionString = @"Data Source=SPUTNIK-I;Initial Catalog=QuanLyPhongKhamNhaKhoa_HQT;Integrated Security=True;Encrypt=False";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                    string.IsNullOrWhiteSpace(textBox2.Text) ||
                    string.IsNullOrWhiteSpace(textBox3.Text) ||
                    string.IsNullOrWhiteSpace(textBox4.Text) ||
                    string.IsNullOrWhiteSpace(textBox5.Text) ||
                    string.IsNullOrWhiteSpace(textBox6.Text) )
                {
                    MessageBox.Show("Không để trống những thông tin cần thiết");
                }
                else
                {
                    _connection = new SqlConnection(_connectionString);
                    _connection.Open();
                    String procname = "p_SuaThuocFIX";
                    _command = new SqlCommand(procname);
                    _command.CommandType = CommandType.StoredProcedure;
                    _command.Connection = _connection;
                    _command.Parameters.Add("@MaThuocCu", SqlDbType.VarChar);
                    _command.Parameters.Add("@MaThuocMoi", SqlDbType.VarChar);
                    _command.Parameters.Add("@TenThuoc", SqlDbType.NVarChar);
                    _command.Parameters.Add("@DonViTinh", SqlDbType.NVarChar);
                    _command.Parameters.Add("@ChiDinh", SqlDbType.NVarChar);
                    _command.Parameters.Add("@SoLuongTon", SqlDbType.Int);
                    _command.Parameters.Add("@NgayHetHan", SqlDbType.Date);
                    _command.Parameters.Add("@Delay", SqlDbType.Time);


                    _command.Parameters["@MaThuocCu"].Value = textBox1.Text;
                    _command.Parameters["@MaThuocMoi"].Value = textBox2.Text;
                    _command.Parameters["@TenThuoc"].Value = textBox3.Text;
                    _command.Parameters["@DonViTinh"].Value = textBox4.Text;
                    _command.Parameters["@ChiDinh"].Value = textBox5.Text;
                    _command.Parameters["@SoLuongTon"].Value = textBox6.Text;
                    _command.Parameters["@NgayHetHan"].Value = dateTimePicker1.Text;
                    _command.Parameters["@Delay"].Value = dateTimePicker2.Text;
                    _command.ExecuteNonQuery();
                    MessageBox.Show("Sửa thuốc thành công");
                    this.Close();
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
            this.Close();
        }
    }
}
