using DoAnHEQUANTRI.PhanHeNhanVien;
using DoAnHEQUANTRI.PhanHeNhaSi;
using DoAnHEQUANTRI.PhanHeQuanTri;
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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoginNS loginNS = new LoginNS();
            this.Hide();
            loginNS.ShowDialog(this);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginKH login = new LoginKH();
            this.Hide();
            login.ShowDialog(this);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoginNV login = new LoginNV();
            this.Hide();
            login.ShowDialog(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoginQTV login = new LoginQTV();
            this.Hide();
            login.ShowDialog(this);
        }
    }
}
