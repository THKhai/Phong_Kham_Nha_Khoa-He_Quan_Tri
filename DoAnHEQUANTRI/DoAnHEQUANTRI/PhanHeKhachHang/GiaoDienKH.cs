using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnHEQUANTRI
{   
    public partial class GiaoDienKH : Form
    {
        string maKH;
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
        }
    }
}
