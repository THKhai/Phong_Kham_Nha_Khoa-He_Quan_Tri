using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnHEQUANTRI.PhanHeQuanTri
{
    public partial class MokhoaTKNSFinalQTV : Form
    {
        SqlConnection _connection = null;
        SqlCommand _command = null;
        String _connectionString = "";
        public MokhoaTKNSFinalQTV()
        {
            InitializeComponent();
            _connectionString = @"Data Source=DESKTOP-OB2NBQU;Initial Catalog=QuanLyPhongKhamNhaKhoa_HQT;Integrated Security=True;Encrypt=False";

        }

        private void button2_Click(object sender, EventArgs e)
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
                    String procname = "p_UnbanTKNS";
                    _command = new SqlCommand(procname);
                    _command.CommandType = CommandType.StoredProcedure;
                    _command.Connection = _connection;
                    _command.Parameters.Add("@MaNS", SqlDbType.VarChar);

                    _command.Parameters["@MaNS"].Value = textBox1.Text;
                    _command.ExecuteNonQuery();
                    MessageBox.Show("Mở khóa tài khoản thành công");
                    var form = new KhoaTKNSQTV();
                    form.Show();
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
            var form = new KhoaTKNSQTV();
            form.Show();
            this.Close();
        }
    }
}
