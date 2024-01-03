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
    public partial class XemDMThuoc : Form
    {
        public XemDMThuoc()
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            SqlConnection myConn = new SqlConnection("Data Source=SPUTNIK-I;Initial Catalog=QuanLyPhongKhamNhaKhoa_HQT;Integrated Security=True;Encrypt=False");
            myConn.Open();
            SqlCommand myCmd = new SqlCommand("p_XemdanhmucthuocFIX", myConn);
            myCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(myCmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            myConn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new QuanLyThuocQTV();
            form.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new XemThuocDaHetHanQTV();
            form.Show();
            this.Close();
        }
    }
}
