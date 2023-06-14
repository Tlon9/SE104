using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace QuanLyHocSinh
{
    public partial class DoiMatKhau : Form
    {
        public DoiMatKhau()
        {
            InitializeComponent();
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

        public Boolean show1 = true, show2 = true;

        private void guna2ImageButtonShowPass2_Click(object sender, EventArgs e)
        {
            if (show2)
            {
                TextBoxNewPass.UseSystemPasswordChar = false;
                TextBoxNewPass.PasswordChar = '\0';
                show2 = false;
            }
            else
            {
                TextBoxNewPass.UseSystemPasswordChar = true;
                TextBoxNewPass.PasswordChar = '.';
                show2 = true;
            }
        }

        private void guna2ButtonChangePass_Click(object sender, EventArgs e)
        {
            LabelSamePass.Visible = false;
            LabelWrongPass.Visible = false;
            if (TextBoxPass.Text != Account.MatKhau)
            {
                LabelWrongPass.Show();
                TextBoxNewPass.Text = "";
                TextBoxPass.Text = "";
            }
            else if (TextBoxPass.Text == TextBoxNewPass.Text)
            {
                LabelSamePass.Show();
                TextBoxNewPass.Text = "";
            }
            else
            {
                dataEntities dtb = new dataEntities();
                var changePass = dtb.TAIKHOANs.Where(r => r.TenDangNhap.ToString() == Account.TenDangNhap).FirstOrDefault();
                changePass.MatKhau = TextBoxNewPass.Text.ToString();
                dtb.Entry(changePass).State = System.Data.Entity.EntityState.Modified;
                dtb.SaveChanges();
                MessageBox.Show("Đổi mật khẩu thành công!");
                this.Close();
            }
        }

        private void guna2ImageButtonMinimize1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2ImageButtonClose1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2ImageButtonShowPass1_Click(object sender, EventArgs e)
        {
            if (show1)
            {
                TextBoxPass.UseSystemPasswordChar = false;
                TextBoxPass.PasswordChar = '\0';
                show1 = false;
            }
            else
            {
                TextBoxPass.UseSystemPasswordChar = true;
                TextBoxPass.PasswordChar = '.';
                show1 = true;
            }    
        }
    }
}
