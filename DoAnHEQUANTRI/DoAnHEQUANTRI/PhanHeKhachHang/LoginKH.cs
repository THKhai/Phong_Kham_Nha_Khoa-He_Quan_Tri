using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DoAnHEQUANTRI
{
    public partial class LoginKH : Form
    {
        public static LoginKH instance;
        SqlConnection _connection = null;
        SqlCommand _command = null;
        String _connectionString = "";
        public LoginKH()
        {
            InitializeComponent();
            _connectionString = @"Data Source=SPUTNIK-I;Initial Catalog=QuanLyPhongKhamNhaKhoa_HQT;Integrated Security=True;Encrypt=False";
        }
        private void LoginKH_Load(object sender, EventArgs e)
        {

        }
        private void Dangnhap_Click(object sender, EventArgs e)
        {
            try
            {
                
                _connection = new SqlConnection(_connectionString);
                _connection.Open();
                String procname = "p_KtraTKKH";
                _command = new SqlCommand(procname);
                _command.CommandType = CommandType.StoredProcedure;
                _command.Connection = _connection;
                _command.Parameters.Add("@SDT", SqlDbType.NVarChar);
                _command.Parameters.Add("@MATKHAU", SqlDbType.NVarChar);
                _command.Parameters.Add("@OK", SqlDbType.Bit).Direction = ParameterDirection.Output;
                _command.Parameters["@SDT"].Value = textBox1.Text;
                _command.Parameters["@MATKHAU"].Value = textBox2.Text;
                _command.ExecuteNonQuery();
                bool ok = (bool)_command.Parameters["@OK"].Value;
                if (ok == true) 
                { 
                    GiaoDienKH test1 = new GiaoDienKH();
                    MessageBox.Show("Đăng nhập thành công");
                    this.Hide();
                    test1.ShowDialog(this);
                    
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

        private void DangKy_Click(object sender, EventArgs e)
        {
            DangKyKH dangKyKH = new DangKyKH();
            dangKyKH.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var myParent = (Home)this.Owner;
            myParent.Show();
            this.Close();
        }
    }
}
