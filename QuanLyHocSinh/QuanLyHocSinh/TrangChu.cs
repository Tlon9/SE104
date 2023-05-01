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
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
        }

        private void MenuItemFinalReport_Click(object sender, EventArgs e)
        {
            BaoCaoTongKet newform = new BaoCaoTongKet();
            this.Hide();
            newform.ShowDialog();
            this.Close();
        }
    }
}
