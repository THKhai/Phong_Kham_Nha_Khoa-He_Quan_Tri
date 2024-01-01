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
    public partial class ThemLichHenNV : Form
    {
        SqlConnection _connection = null;
        SqlCommand _command = null;
        String _connectionString = "";
        string mabn;
        public ThemLichHenNV()
        {
            InitializeComponent();
            _connectionString = @"Data Source=DESKTOP-HSNG6J5\SQLEXPRESS;Initial Catalog=DB_QuanLyPhongKhamNhaKhoa_HQT;Integrated Security=True;Encrypt=False";


        }
        private void dangky_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(comboBox1.Text) ||
                    string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Không để trống những thông tin cần thiết");
                }
                else
                {
                    try

                    {
                        _connection = new SqlConnection(_connectionString);
                        _connection.Open();
                        string proc = "p_DangKyLichHenKH";
                        _command = new SqlCommand(proc);
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Connection = _connection;
                        _command.Parameters.Add("@NGAYGIO", SqlDbType.DateTime).Value = ThoiGian.Value;
                        _command.Parameters.Add("@MABN", SqlDbType.VarChar, 10).Value = textBox1.Text;
                        _command.Parameters.Add("@MANHASI", SqlDbType.VarChar, 10).Value = comboBox1.SelectedValue.ToString();
                        _command.ExecuteNonQuery();
                        MessageBox.Show("Đăng ký thành công");
                        _connection.Close();
                        this.Close();


                    }

                    catch (SqlException ex)

                    { MessageBox.Show(ex.ToString()); }

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            var form = new MenuNV();
            form.Show();
            Hide();
        }

        private void ThoiGian_ValueChanged_1(object sender, EventArgs e)
        {
            string proc = "p_ViewNhaSiCoTheHen";
            _connection = new SqlConnection(_connectionString);
            SqlDataAdapter da = new SqlDataAdapter(proc, _connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@THOIGIAN", SqlDbType.DateTime).Value = ThoiGian.Value;
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.ValueMember = "MaNhaSi";
            comboBox1.DisplayMember = "HoTen";
            comboBox1.DataSource = dt;
            comboBox1.SelectedIndex = -1;


            _connection.Close();
        }
    }
}
