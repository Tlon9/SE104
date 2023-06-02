using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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
                    Account.TenDangNhap = item.TenDangNhap.ToString();
                    Account.MatKhau = item.MatKhau.ToString();
                    Account.VaiTro = item.PHANQUYEN.VaiTro.ToString();
                    Account.HoTen = item.HoTen.ToString();
                    Account.NgaySinh = item.NgaySinh.ToString().Substring(0,9);
                    TrangChu newform = new TrangChu();
                    this.Hide();
                    newform.ShowDialog();
                    this.Close();
                }
            }
            labelWrong.Show();
            textBoxUsername.Text = "";
            textBoxPassword.Text = "";
        }




        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four); 
        private void guna2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }


        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
