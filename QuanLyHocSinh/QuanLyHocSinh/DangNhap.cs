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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            dataEntities dtb = new dataEntities();
            foreach(var item in dtb.TAIKHOANs)
            {
                if (item.TenDangNhap == textBoxUsername.Text && item.MatKhau == textBoxPassword.Text)
                {
                    TrangChu newform = new TrangChu();
                    this.Hide();
                    newform.ShowDialog();
                    this.Close();
                }
            }
            labelWrong.Show();

        }


        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }
    }
}
