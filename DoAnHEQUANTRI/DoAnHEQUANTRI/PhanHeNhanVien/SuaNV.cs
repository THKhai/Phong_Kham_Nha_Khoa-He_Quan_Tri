using DoAnHEQUANTRI.PhanHeQuanTri;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DoAnHEQUANTRI.PhanHeNhanVien
{
    public partial class SuaNV : Form
    {
        SqlConnection _connection = null;
        SqlCommand _command = null;
        String _connectionString = "";
        public SuaNV()
        {
            InitializeComponent();
            _connectionString = @"Data Source=DESKTOP-HSNG6J5\SQLEXPRESS;Initial Catalog=DB_QuanLyPhongKhamNhaKhoa_HQT;Integrated Security=True;Encrypt=False";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                    string.IsNullOrWhiteSpace(textBox2.Text) ||
                    string.IsNullOrWhiteSpace(textBox3.Text) ||
                    string.IsNullOrWhiteSpace(textBox4.Text))
                {
                    MessageBox.Show("Không để trống những thông tin cần thiết");
                }
                else
                {
                    _connection = new SqlConnection(_connectionString);
                    _connection.Open();
                    String procname = "p_SuaNV";
                    _command = new SqlCommand(procname);
                    _command.CommandType = CommandType.StoredProcedure;
                    _command.Connection = _connection;
                    _command.Parameters.Add("@MaNvcu", SqlDbType.VarChar);
                    _command.Parameters.Add("@MaNVmoi", SqlDbType.VarChar);
                    _command.Parameters.Add("@HoTen", SqlDbType.NVarChar);
                    _command.Parameters.Add("@MatKhau", SqlDbType.NVarChar);
                    _command.Parameters.Add("@Delay", SqlDbType.Time);


                    _command.Parameters["@MaNvcu"].Value = textBox1.Text;
                    _command.Parameters["@MaNVmoi"].Value = textBox2.Text;
                    _command.Parameters["@HoTen"].Value = textBox3.Text;
                    _command.Parameters["@MatKhau"].Value = textBox4.Text;
                    _command.Parameters["@Delay"].Value = dateTimePicker2.Text;
                    _command.ExecuteNonQuery();
                    MessageBox.Show("Sửa nhân viên thành công");
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
            var form = new ThemXoaSuaNV();
            form.Show();
            this.Close();
        }
    }
}
