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
    public partial class ThemXoaSuaThuocQTV : Form
    {
        public ThemXoaSuaThuocQTV()
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            SqlConnection myConn = new SqlConnection("Data Source=DESKTOP-OB2NBQU;Initial Catalog=QuanLyPhongKhamNhaKhoa_HQT;Integrated Security=True");
            myConn.Open();
            SqlCommand myCmd = new SqlCommand("p_Xemdanhmucthuoc", myConn);
            myCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(myCmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            myConn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var form = new QuanLyThuocQTV();
            form.Show();
            Hide();
        }
    }
}
