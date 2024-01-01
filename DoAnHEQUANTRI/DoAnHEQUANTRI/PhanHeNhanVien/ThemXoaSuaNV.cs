using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnHEQUANTRI.PhanHeNhanVien
{
    public partial class ThemXoaSuaNV : Form
    {
        public ThemXoaSuaNV()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new ThemNV();
            form.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new XoaNV();
            form.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new SuaNV();
            form.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var form = new KiemTraNV();
            form.Show();
            Hide();
        }
    }
}
