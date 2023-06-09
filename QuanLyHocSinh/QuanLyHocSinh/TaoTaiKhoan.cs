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
    public partial class TaoTaiKhoan : Form
    {
        public TaoTaiKhoan()
        {
            InitializeComponent();
            var dtb = new dataEntities();
            var comboBoxSource = dtb.PHANQUYENs;
            guna2ComboBox1.DataSource = comboBoxSource.ToList();
            guna2ComboBox1.ValueMember = "MaPhanQuyen";
            guna2ComboBox1.DisplayMember = "VaiTro";
        }

        private void guna2ButtonAccount_Click(object sender, EventArgs e)
        {
            label6.Hide();
            label7.Hide();
            if (guna2TextBox1.Text == "" || guna2TextBox2.Text == "" || guna2TextBox3.Text == "" || guna2TextBox4.Text == "")
            {
                label6.Show();
                guna2TextBox1.Text = "";
                guna2TextBox2.Text = "";
                guna2TextBox3.Text = "";
                guna2TextBox4.Text = "";
            }
            else
            {
                var dtb = new dataEntities();
                var check_source = dtb.TAIKHOANs.Select(r => r.TenDangNhap).ToList();
                bool check = true;
                foreach (var item in check_source)
                {
                    if (guna2TextBox3.Text == item.ToString())
                    {
                        label7.Show();
                        guna2TextBox3.Text = "";
                        check = false;
                        break;
                    }
                }
                if (check)
                {
                    var account = new TAIKHOAN();
                    account.HoTen = guna2TextBox1.Text;
                    //account.NgaySinh = guna2TextBox2.Text;
                }
            }
        }
    }
}
