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
    public partial class KhoaTKQTV : Form
    {
        public KhoaTKQTV()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new KhoaTKNSQTV();
            form.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new KhoaTKKHQTV();
            form.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new QuanLyNguoiDungQTV();
            form.Show();
            this.Close();
        }
    }
}
