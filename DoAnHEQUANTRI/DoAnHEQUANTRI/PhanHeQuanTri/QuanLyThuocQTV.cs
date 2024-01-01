using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnHEQUANTRI.PhanHeQuanTri
{
    public partial class QuanLyThuocQTV : Form
    {
        public QuanLyThuocQTV()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new ThemXoaSuaThuocQTV();
            form.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new XemDMThuoc();
            form.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new MenuQTV();
            form.Show();
            Hide();
        }
    }
}
