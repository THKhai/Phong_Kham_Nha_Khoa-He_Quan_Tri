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
using System.Xml.Serialization;

namespace DoAnHEQUANTRI.PhanHeNhaSi
{
    public partial class ThemHSBN : Form
    {
        DateTime NgayKham = DateTime.Now;
        int STT = 0;
        string MaNhasSi = null;
        string Dich_Vu = null;
        string current_MaBN;
        float phi = 0;
        string MaDT = null;
        SqlConnection _connection = null;
        SqlCommand _command = null;
        string _connectionString = null;
        public ThemHSBN(string MaBN)
        {
            current_MaBN = MaBN;
            InitializeComponent();
            _connectionString = @"Data Source=KHAINEHAHA;Initial Catalog=QuanLyPhongKhamNhaKhoa_HQT;Integrated Security=True;Encrypt=False";
            LoadCombobox();
            generate_STT();
            LoadCombobox_v2();
        }
        //FUNCTIONS
        // Load
        private void LoadCombobox()
        {
            comboBox1.Items.Add("Chụp X-Quang");
            comboBox1.Items.Add("Trám Răng");
            comboBox1.Items.Add("Cạo râu");
        }
        // load combobox
        private void LoadCombobox_v2()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Thực hiện truy vấn để lấy danh sách tên thuốc
                string query = "SELECT HoTen FROM NhaSi";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Thêm tên thuốc vào ComboBox
                        while (reader.Read())
                        {
                            comboBox2.Items.Add(reader["HoTen"].ToString());
                        }
                    }
                }
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
            Dich_Vu = comboBox1.Text;
        }

        private void generate_STT()
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("Take_NewSTT", _connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@MaBN", SqlDbType.VarChar, 10).Value = current_MaBN;
                    command.Parameters.Add("@res", SqlDbType.Int).Direction = ParameterDirection.Output;

                    _connection.Open();
                    command.ExecuteNonQuery();

                    // Retrieve the output parameter value after executing the stored procedure
                    STT = Convert.ToInt32(command.Parameters["@res"].Value);

                    _connection.Close();
                    Label_STT.Text = STT.ToString();
                }
            }
        }
        // find MaNhSi
        private void Find_MaNhaSi()
        {
            string TenNhaSi = comboBox2.Text;
            if (!string.IsNullOrEmpty(TenNhaSi))
            {
                using (_connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand("Tim_Ten_NhaSi", _connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Ten", TenNhaSi);
                        command.Parameters.Add("@res", SqlDbType.Char, 10).Direction = ParameterDirection.Output;
                        _connection.Open();
                        command.ExecuteNonQuery();
                        _connection.Close();
                        MaNhasSi = Convert.ToString(command.Parameters["@res"].Value);
                        label4.Text = MaNhasSi;
                    }
                }
            }

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dich_Vu = comboBox1.Text.ToString();
        }

        private void Cost_Click(object sender, EventArgs e)
        {

        }

        private void ThemHSBN_Load(object sender, EventArgs e)
        {
            Label_MaBN.Text = current_MaBN;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            NgayKham = dateTimePicker1.Value;
        }

        private void addHSBN()
        {
            try
            {
                using (_connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand("Them_HSBN", _connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@MaBN", SqlDbType.VarChar, 10).Value = current_MaBN;
                        command.Parameters.Add("@STT", SqlDbType.Int).Value = STT;
                        command.Parameters.Add("@Ngay_Kham", SqlDbType.Date).Value = NgayKham;
                        command.Parameters.Add("@MaNhaSi", SqlDbType.VarChar, 10).Value = MaNhasSi;
                        command.Parameters.Add("@PhiKham", SqlDbType.VarChar, 10).Value = phi;
                        command.Parameters.Add("@DichVu", SqlDbType.VarChar, 255).Value = Dich_Vu;
                        command.Parameters.Add("@DonThuoc", SqlDbType.VarChar, 255).Value = MaDT;
                        command.Parameters.AddWithValue("@TimeDelay", textBox2.Text);
                        


                        _connection.Open();
                        command.ExecuteNonQuery();
                        DanhSachThuoc dst = new DanhSachThuoc(STT, current_MaBN, MaDT);
                        this.Close();
                        dst.ShowDialog();
                        // Retrieve the output parameter value after executing the stored procedure
                    }
                }
            }
            catch (SqlException ex)
            {
                foreach (SqlError error in ex.Errors)
                {
                    if (error.Number == 2627)
                    {
                        // Duplicate key violation for DonThuoc
                        MessageBox.Show("Lỗi: Mã hóa Đơn Đã Tồn Tại. Vui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi: " + error.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addHSBN();
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Find_MaNhaSi();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            MaDT = textBox1.Text;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            phi = (int)numericUpDown1.Value;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
