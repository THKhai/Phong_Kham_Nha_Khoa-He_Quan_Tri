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

namespace DoAnHEQUANTRI.PhanHeKhachHang
{
    public partial class UpdateInfoBenhNhan : Form
    {
        SqlConnection _connection = null;
        SqlCommand _command = null;
        String _connectionString = "";
        string maBN;
        public UpdateInfoBenhNhan(string mabn)
        {
            InitializeComponent();
            _connectionString = @"Data Source=KHAINEHAHA;Initial Catalog=QuanLyPhongKhamNhaKhoa_HQT;Integrated Security=True;Encrypt=False";
            maBN = mabn;
        }

        private void UpdateInfoBenhNhan_Load(object sender, EventArgs e)
        {
            try
            {
                string proc = "p_XemInfoBn";
                _connection = new SqlConnection(_connectionString);
                SqlDataAdapter da = new SqlDataAdapter(proc, _connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@MABN", SqlDbType.VarChar, 10).Value = maBN;
                DataTable dt = new DataTable();
                da.Fill(dt);
                textBox1.Text = dt.Rows[0][1].ToString();
                textBox2.Text = dt.Rows[0][3].ToString();
                textBox3.Text = dt.Rows[0][4].ToString();
                textBox4.Text = dt.Rows[0][5].ToString();
                dateTimePicker1.Value = DateTime.Parse(dt.Rows[0][2].ToString());
                _connection.Close();
            }
            catch (SqlException ex) { MessageBox.Show(ex.ToString()); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try

            {
                _connection = new SqlConnection(_connectionString);
                _connection.Open();
                string proc = "p_UpdateInfoBN";
                _command = new SqlCommand(proc);
                _command.CommandType = CommandType.StoredProcedure;
                _command.Connection = _connection;
                
                _command.Parameters.Add("@MABN", SqlDbType.VarChar, 10).Value = maBN;
                _command.Parameters.Add("@HOTEN", SqlDbType.NVarChar, 255).Value = textBox1.Text;
                _command.Parameters.Add("@NGAYSINH", SqlDbType.DateTime).Value = dateTimePicker1.Value;
                _command.Parameters.Add("@DIACHI", SqlDbType.NVarChar, 255).Value = textBox2.Text;
                _command.Parameters.Add("@SODIENTHOAI", SqlDbType.NVarChar, 255).Value = textBox3.Text;
                _command.Parameters.Add("@MATKHAU", SqlDbType.NVarChar, 255).Value = textBox4.Text;
                _command.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thành công");
                _connection.Close();
                this.Close();


            }

            catch (SqlException ex)

            { MessageBox.Show(ex.ToString()); }
        }
    }
}
