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
    public partial class KiemTraNV : Form
    {
        public KiemTraNV()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new ThemXoaSuaNV();
            form.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new XemDMNV();
            form.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new MenuNV();
            form.Show();
            Hide();
        }

        private void KiemTraNV_Load(object sender, EventArgs e)
        {

        }
    }
}
