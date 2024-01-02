using DoAnHEQUANTRI.PhanHeKhachHang;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DoAnHEQUANTRI
{   
    public partial class GiaoDienKH : Form
    {
        string maKH;
        SqlConnection _connection = null;
        SqlCommand _command = null;
        String _connectionString = "";
        public GiaoDienKH(string MAKH)
        {
            InitializeComponent();
            maKH = MAKH;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var myParent = (LoginKH)this.Owner;
            myParent.Show();
            this.Close();
        }

        private void GiaoDienKH_Load(object sender, EventArgs e)
        {
            label1.Text = "Mã khách hàng của bạn là: " + maKH;
            _connectionString = @"Data Source=SPUTNIK-I;Initial Catalog=QuanLyPhongKhamNhaKhoa_HQT;Integrated Security=True;Encrypt=False";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DangKyLichHen dk = new DangKyLichHen(maKH);
            dk.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string proc = "p_XemHoSoBn";
                _connection = new SqlConnection(_connectionString);
                SqlDataAdapter da = new SqlDataAdapter(proc, _connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@MABN", SqlDbType.VarChar,10).Value = maKH;
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                _connection.Close();
            }
            catch (SqlException ex) { MessageBox.Show(ex.ToString()); }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string proc = "p_ViewLHBenhNhan";
                _connection = new SqlConnection(_connectionString);
                SqlDataAdapter da = new SqlDataAdapter(proc, _connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@MABN", SqlDbType.VarChar, 10).Value = maKH;
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                _connection.Close();
            }
            catch (SqlException ex) { MessageBox.Show(ex.ToString()); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string proc = "p_XemInfoBn";
                _connection = new SqlConnection(_connectionString);
                SqlDataAdapter da = new SqlDataAdapter(proc, _connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@MABN", SqlDbType.VarChar, 10).Value = maKH;
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                _connection.Close();
            }
            catch (SqlException ex) { MessageBox.Show(ex.ToString()); }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UpdateInfoBenhNhan updateInfoBenhNhan = new UpdateInfoBenhNhan(maKH);
            updateInfoBenhNhan.ShowDialog();
        }
    }
    
    
    
}
