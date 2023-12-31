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

namespace DoAnHEQUANTRI.PhanHeNhaSi
{
    public partial class GiaoDien_NhaSi : Form
    {
        SqlConnection _connection = null;
        SqlCommand _command = null;
        string _connectionString = null;
        public GiaoDien_NhaSi()
        {
            InitializeComponent();
            _connectionString = @"Data Source=KHAINEHAHA;Initial Catalog=QuanLyPhongKhamNhaKhoa_HQT;Integrated Security=True;Encrypt=False";
        }

        private void GiaoDien_NhaSi_Load(object sender, EventArgs e)
        {

        }
        private void LoadAllData(object sender, EventArgs e)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("", _connection))
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
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
