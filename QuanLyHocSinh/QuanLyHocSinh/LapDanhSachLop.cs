using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocSinh
{
    public partial class LapDanhSachLop : Form
    {
        public LapDanhSachLop()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void LapDanhSachLop_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'duLieu.LOP' table. You can move, or remove it, as needed.
            this.lOPTableAdapter.Fill(this.duLieu.LOP);

        }
    }
}
