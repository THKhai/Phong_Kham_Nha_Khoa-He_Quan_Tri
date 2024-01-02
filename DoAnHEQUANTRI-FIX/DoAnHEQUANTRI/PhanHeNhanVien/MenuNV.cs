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
    public partial class MenuNV : Form
    {
        public MenuNV()
        {
            InitializeComponent();
        }
        
        private void button2_Click_1(object sender, EventArgs e)
        {
            var form = new ThemLichHenNV();
            form.Show();
            Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            var form = new TinhTienNV();
            form.Show();
            Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            var form = new CapNhatThuocNV();
            form.Show();
            Hide();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            var form = new LoginNV();
            form.Show();
            Hide();
        }
    }
}

