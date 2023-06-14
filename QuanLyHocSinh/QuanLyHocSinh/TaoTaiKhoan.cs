using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Runtime.InteropServices;

namespace QuanLyHocSinh
{
    public partial class TaoTaiKhoan : Form
    {
        public TaoTaiKhoan()
        {
            InitializeComponent();
            var dtb = new dataEntities();
            var comboBoxSource = dtb.PHANQUYENs;
            ComboBoxRole.DataSource = comboBoxSource.ToList();
            ComboBoxRole.ValueMember = "MaPhanQuyen";
            ComboBoxRole.DisplayMember = "VaiTro";
        }

        private void guna2ButtonAccount_Click(object sender, EventArgs e)
        {
            label6.Hide();
            LabelWarning.Hide();
            if (TextBoxName.Text == "" || TextBoxBirthday.Text == "" || TextBoxUserName.Text == "" || TextBoxPass.Text == "")
            {
                label6.Show();
                TextBoxName.Text = "";
                TextBoxBirthday.Text = "";
                TextBoxUserName.Text = "";
                TextBoxPass.Text = "";
            }
            else
            {
                var dtb = new dataEntities();
                var check_source = dtb.TAIKHOANs.Select(r => r.TenDangNhap).ToList();
                bool check = true;
                foreach (var item in check_source)
                {
                    if (TextBoxUserName.Text == item.ToString())
                    {
                        LabelWarning.Show();
                        TextBoxUserName.Text = "";
                        check = false;
                        break;
                    }
                }
                if (check)
                {
                    try
                    {
                        var account = new TAIKHOAN();
                        account.HoTen = TextBoxName.Text;
                        CultureInfo provider = CultureInfo.InvariantCulture;
                        account.NgaySinh = DateTime.ParseExact(TextBoxBirthday.Text, "dd/MM/yyyy", provider);
                        account.MaPhanQuyen = ComboBoxRole.SelectedValue.ToString();
                        account.TenDangNhap = TextBoxUserName.Text;
                        account.MatKhau = TextBoxPass.Text;
                        var MaTK = dtb.TAIKHOANs.Where(r => r.MaPhanQuyen == account.MaPhanQuyen).OrderByDescending(r => r.MaTaiKhoan).Select(r => r.MaTaiKhoan).FirstOrDefault();
                        
                        int num = Convert.ToInt32(MaTK.Substring(2));
                        num += 1;
                        account.MaTaiKhoan = MaTK.Substring(0,2) + num.ToString();
                        dtb.TAIKHOANs.Add(account);
                        dtb.SaveChanges();
                        MessageBox.Show("Tạo tài khoản thành công!");
                    }
                    catch
                    {
                        MessageBox.Show("Mời nhập đúng định dạng ngày sinh!");
                    }
                }
            }
        }

        private void guna2ImageButtonMinimize1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2ImageButtonClose1_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void guna2ImageButtonHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
