﻿using System;
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

namespace DoAnHEQUANTRI.PhanHeQuanTri
{
    public partial class DKTKNVMoiQTV : Form
    {
        SqlConnection _connection = null;
        SqlCommand _command = null;
        String _connectionString = "";
        public DKTKNVMoiQTV()
        {
            InitializeComponent();
            _connectionString = @"Data Source=SPUTNIK-I;Initial Catalog=QuanLyPhongKhamNhaKhoa_HQT;Integrated Security=True;Encrypt=False";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                    string.IsNullOrWhiteSpace(textBox2.Text) ||
                    string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    MessageBox.Show("Không để trống những thông tin cần thiết");
                }
                else
                {
                    _connection = new SqlConnection(_connectionString);
                    _connection.Open();
                    String procname = "p_DangKyTKNV";
                    _command = new SqlCommand(procname);
                    _command.CommandType = CommandType.StoredProcedure;
                    _command.Connection = _connection;
                    _command.Parameters.Add("@MaNV", SqlDbType.VarChar);
                    _command.Parameters.Add("@HoTen", SqlDbType.NVarChar);
                    _command.Parameters.Add("@MatKhau", SqlDbType.NVarChar);

                    _command.Parameters["@MaNV"].Value = textBox1.Text;
                    _command.Parameters["@HoTen"].Value = textBox2.Text;
                    _command.Parameters["@MatKhau"].Value = textBox3.Text;
                    _command.ExecuteNonQuery();
                    MessageBox.Show("Đăng ký tài khoản thành công");
                    var form = new DKTKMoiQTV();
                    form.Show();
                    this.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new DKTKMoiQTV();
            form.Show();
            this.Close();
        }
    }
}
