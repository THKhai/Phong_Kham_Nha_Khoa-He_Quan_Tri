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
    public partial class LoginQTV : Form
    {
        public static LoginKH instance;
        SqlConnection _connection = null;
        SqlCommand _command = null;
        String _connectionString = "";
        public LoginQTV()
        {
            InitializeComponent();
            //_connectionString = @"Data Source=SPUTNIK-I;Initial Catalog=QuanLyPhongKhamNhaKhoa_HQT;Integrated Security=True;Encrypt=False";
            _connectionString = @"Data Source=DESKTOP-OB2NBQU;Initial Catalog=QuanLyPhongKhamNhaKhoa_HQT;Integrated Security=True;Encrypt=False";
        
        }

        private void Dangnhap_Click(object sender, EventArgs e)
        {
            try
            {

                _connection = new SqlConnection(_connectionString);
                _connection.Open();
                String procname = "p_KtraTKQTV";
                _command = new SqlCommand(procname);
                _command.CommandType = CommandType.StoredProcedure;
                _command.Connection = _connection;
                _command.Parameters.Add("@MAQTV", SqlDbType.VarChar, 20);
                _command.Parameters.Add("@MATKHAU", SqlDbType.NVarChar);
                _command.Parameters.Add("@OK", SqlDbType.Bit).Direction = ParameterDirection.Output;
                _command.Parameters["@MAQTV"].Value = textBox1.Text;
                _command.Parameters["@MATKHAU"].Value = textBox2.Text;
                _command.ExecuteNonQuery();
                bool ok = (bool)_command.Parameters["@OK"].Value;
                if (ok == true)
                {
                    MessageBox.Show("Đăng nhập thành công");
                    this.Hide();
                    // Thêm form giao diện khi đăng nhập thành công vào chỗ này
                    //test1.ShowDialog(this);
                    var form = new MenuQTV();
                    form.Show();
                    textBox1.Text = "";
                    textBox2.Text = "";


                }
                else
                {
                    MessageBox.Show("Dang nhap that bai");

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoginQTV_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var myParent = (Home)this.Owner;
            myParent.Show();
            this.Close();
        }
    }
}
