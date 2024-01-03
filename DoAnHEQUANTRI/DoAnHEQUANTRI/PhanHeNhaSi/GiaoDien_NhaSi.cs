using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DoAnHEQUANTRI.PhanHeNhaSi
{
    public partial class GiaoDien_NhaSi : Form
    {
        string Ngay = null;
        string MaNhaSi = null;
        string status = null;
        string MaBN_pick = null;
        SqlConnection _connection = null;
        SqlCommand _command = null;
        string _connectionString = null;
        public GiaoDien_NhaSi(string maNhaSi)
        {
            MaNhaSi = maNhaSi;
            InitializeComponent();
            _connectionString = @"Data Source=KHAINEHAHA;Initial Catalog=QuanLyPhongKhamNhaKhoa_HQT;Integrated Security=True;Encrypt=False";
        }
        // LOAD FORM
        private void GiaoDien_NhaSi_Load(object sender, EventArgs e)
        {
            label5.Text = MaNhaSi;
            textBox2.ReadOnly = true;   
        }

        // FUNCTIONS HERE
            // Load data HoSoBenhNha             BenhNhan
        private void LoadAllData_BN()
        {
            status = "BenhNhan";
            using (_connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("p_Read_BenhNhan", _connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    _connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        // Hiển thị dữ liệu lên form (ví dụ: sử dụng DataGridView)
                        dataGridView1.DataSource = dataTable;
                    }
                    _connection.Close();
                }
            }
        }
        private void LoadAllData_HoSoBenhNha()   //HoSebenhNhan
        {
            status = "HoSoBenhNhan";
            using (_connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("p_Read_HoSoBenhNhan", _connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    _connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        // Hiển thị dữ liệu lên form (ví dụ: sử dụng DataGridView)
                        dataGridView1.DataSource = dataTable;
                    }
                    _connection.Close();
                }
            }
        }
        private void LoadAllData_CuocHenNhaSi()  // CuocHen
        {
            status = "CuocHen";
            using (_connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("p_Read_CuocHenNhaSi", _connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MaNhaSi", MaNhaSi);
                    _connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        // Hiển thị dữ liệu lên form (ví dụ: sử dụng DataGridView)
                        dataGridView1.DataSource = dataTable;
                    }
                    _connection.Close();
                }
            }
        }

            //Load finded painter
        private void find_painter()
        {
            string MaBN = textBox2.Text.Trim();
            if (!string.IsNullOrEmpty(MaBN))
            {
                using (_connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand("Tim_KH", _connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaBN", MaBN);
                        _connection.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            // Display the search result in the DataGridView
                            dataGridView1.DataSource = dataTable;
                        }
                        _connection.Close();
                    }
                }
            }
            else
            {
                LoadAllData_BN();
            }
        }
        // Load finded HoSoBenhNhan
        private void find_HSBN()
        {
            string MaBN = textBox2.Text.Trim();
            if (!string.IsNullOrEmpty(MaBN))
            {
                using (_connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand("Tim_HoSoBenhNhan", _connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaBN", MaBN);
                        _connection.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            // Display the search result in the DataGridView
                            dataGridView1.DataSource = dataTable;
                        }
                        _connection.Close();
                    }
                }
            }
            else
            {
                LoadAllData_HoSoBenhNha();  
            }
        }
        // Load finded CuocHen
        private void find_CuocHen()
        {
            string MaNhaSI = textBox2.Text.Trim();
            if (!string.IsNullOrEmpty(MaNhaSI))
            {
                using (_connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand("Tim_CuocHen", _connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaNhaSi", MaNhaSI);
                        _connection.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            // Display the search result in the DataGridView
                            dataGridView1.DataSource = dataTable;
                        }
                        _connection.Close();
                    }
                }
            }
            else
            {
                LoadAllData_CuocHenNhaSi();
            }
        }
        // DATAAGRIFVIEEW
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
            if(status == "BenhNhan" || status == "HoSoBenhNhan")
            {
                label3.Text = selectedRow.Cells["MaBN"].Value.ToString();
                MaBN_pick = label3.Text;
            }
            else if(status == "CuocHen" && (bool)selectedRow.Cells["NhaSiDat"].Value == true)
            {
                label3.Text = selectedRow.Cells["MaBN"].Value.ToString();
                MaBN_pick = label3.Text;
                Ngay = selectedRow.Cells["NgayGio"].Value.ToString();
            }
            else
            {
                label3.Text = ".......";
            }
        }

        // LABEL
        private void label2_Click(object sender, EventArgs e)
        {

        }
     
        // TEXTBOX
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if(status == "BenhNhan")
            {
                find_painter();
            }
            else if (status == "HoSoBenhNhan")
            {
                find_HSBN();
            }
            else if(status == "CuocHen")
            {
                find_CuocHen();
            }
        }

        //button
        private void button1_Click(object sender, EventArgs e)
        {
            if (status == "BenhNhan")
            {
                ThemHSBN T_HSBN = new ThemHSBN(MaBN_pick);
                this.Hide();
                T_HSBN.ShowDialog();
                this.Show();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DangKyKH dkkh = new DangKyKH();
            this.Hide();
            dkkh.ShowDialog();
            LoadAllData_BN();
            this.Show();

        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.ReadOnly == true)
                textBox2.ReadOnly = false;
            LoadAllData_BN();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.ReadOnly == true)
                textBox2.ReadOnly = false;
            LoadAllData_HoSoBenhNha();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox2.ReadOnly == true)
                textBox2.ReadOnly = false;
            LoadAllData_CuocHenNhaSi();
        }

        private void Đang_Xuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ThemCuocHen_NhaSi chns = new ThemCuocHen_NhaSi(MaBN_pick);
            chns.ShowDialog();

        }

        private void ChinhSua_Click(object sender, EventArgs e)
        {
            if(status == "CuocHen")
            {
                UpdateCuocHenNhaSi udchns =new UpdateCuocHenNhaSi(MaBN_pick,MaNhaSi,Ngay);
                this.Hide();
                udchns.ShowDialog();
                this.Show();
                LoadAllData_CuocHenNhaSi();
            }    
        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("Xem_LH_Ngay", _connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MaNhaSi",MaNhaSi);
                    command.Parameters.Add("@Ngay", SqlDbType.Date).Value = dateTimePicker1.Value.Date;
                    _connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        // Display the search result in the DataGridView
                        dataGridView1.DataSource = dataTable;
                    }
                    _connection.Close();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
