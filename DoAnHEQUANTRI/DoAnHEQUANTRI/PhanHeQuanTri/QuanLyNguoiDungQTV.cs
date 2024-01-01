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
    public partial class QuanLyNguoiDungQTV : Form
    {
        public QuanLyNguoiDungQTV()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new DKTKMoiQTV();
            form.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new DKTKMoiQTV();
            form.Show();
            Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new LoginQTV();
            form.Show();
            Hide();
        }
    }
}
