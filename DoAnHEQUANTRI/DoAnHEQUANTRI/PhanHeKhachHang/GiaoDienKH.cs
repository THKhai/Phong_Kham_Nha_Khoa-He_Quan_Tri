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
        public GiaoDienKH()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var myParent = (LoginKH)this.Owner;
            myParent.Show();
            this.Close();
        }
    }
}
