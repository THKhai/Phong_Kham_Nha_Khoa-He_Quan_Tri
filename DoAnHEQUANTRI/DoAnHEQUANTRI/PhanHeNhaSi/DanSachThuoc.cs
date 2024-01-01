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

namespace DoAnHEQUANTRI.PhanHeNhaSi
{
    public partial class DanhSachThuoc : Form
    {
        
        int stt = 0;
        string current_mabn = null;
        string madt = null;
        string mat = null;
        SqlConnection _connection = null;
        SqlCommand _command = null;
        string _connectionString = null;
        public DanhSachThuoc(int STT,string current_MaBn, string MaDT)
        {
            stt = STT;
            current_mabn=current_MaBn;
            madt = MaDT;
            InitializeComponent();
            _connectionString = @"Data Source=KHAINEHAHA;Initial Catalog=QuanLyPhongKhamNhaKhoa_HQT;Integrated Security=True;Encrypt=False";
            Load_DanhSachThuoc();
        }

        // FUNCTIONS
        // Load  data
        private void Load_DanhSachThuoc()
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("XemDanhSachThuoc", _connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    _connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView2.DataSource = dataTable;
                    }
                    _connection.Close();
                }
            }
        }
        private void Load_DonThuoc()
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("XemDonThuoc", _connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@DonThuoc", madt);
                    _connection.Open();
                    command.ExecuteNonQuery();
                    _connection.Close();
                }
            }
        }
        // tìm kiếm trong datagrifview thuốc
        private void find_medicin()
        {
            string MaThuoc = textBox1.Text.Trim();
            if (!string.IsNullOrEmpty(MaThuoc))
            {
                using (_connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand("Tim_Thuoc", _connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaThuoc", MaThuoc);
                        _connection.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            // Display the search result in the DataGridView
                            dataGridView2.DataSource = dataTable;
                        }
                        _connection.Close();
                    }
                }
            }
            else
            {
                Load_DanhSachThuoc();
            }   
        } 

        private void label2_Click(object sender, EventArgs e)
        {

        }
        // generate don vi Don Thuoc
        
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView2.Rows[e.RowIndex];
            label8.Text = selectedRow.Cells["TenThuoc"].Value.ToString();
            mat = label7.Text = selectedRow.Cells["MaThuoc"].Value.ToString();
           
        }

        private void label8_Click(object sender, EventArgs e)
        {
            
        }

        private void DanhSachThuoc_Load(object sender, EventArgs e)
        {
            label9.Text = madt;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("ThemDonThuoc", _connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@DonTHuoc",madt);
                    command.Parameters.AddWithValue("@MaTHuoc",mat);
                    _connection.Open();
                    command.ExecuteNonQuery() ; 
                    _connection.Close();
                }
            }
            Load_DonThuoc();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            find_medicin();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
