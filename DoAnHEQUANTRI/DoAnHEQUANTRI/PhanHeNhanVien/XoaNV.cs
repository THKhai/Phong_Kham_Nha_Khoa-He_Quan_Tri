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

namespace DoAnHEQUANTRI.PhanHeNhanVien
{
    public partial class XoaNV : Form
    {
        SqlConnection _connection = null;
        SqlCommand _command = null;
        String _connectionString = "";
        public XoaNV()
        {
            InitializeComponent();
            _connectionString = @"Data Source=DESKTOP-HSNG6J5\SQLEXPRESS;Initial Catalog=DB_QuanLyPhongKhamNhaKhoa_HQT;Integrated Security=True;Encrypt=False";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Không để trống những thông tin cần thiết");
                }
                else
                {
                    _connection = new SqlConnection(_connectionString);
                    _connection.Open();
                    String procname = "p_XoaNV";
                    _command = new SqlCommand(procname);
                    _command.CommandType = CommandType.StoredProcedure;
                    _command.Connection = _connection;
                    _command.Parameters.Add("@MaNV", SqlDbType.VarChar);
                    //_command.Parameters.Add("@Delay", SqlDbType.Time);

                    _command.Parameters["@MaNV"].Value = textBox1.Text;
                    //_command.Parameters["@Delay"].Value = dateTimePicker2.Text;
                    _command.ExecuteNonQuery();
                    MessageBox.Show("Xóa nhân viên thành công");
                    this.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new ThemXoaSuaNV();
            form.Show();
            Hide();
        }
    }
    
}
