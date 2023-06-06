
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
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
            if (Account.VaiTro == "Giáo viên")
            {
                this.MenuItemSubjectScore.Visible = true;
            }
            else if (Account.VaiTro == "Người quản lý")
            {
                this.MenuItemListCreate.Visible = true;
                this.MenuItemAddStudent.Visible = true;
                this.MenuQuanLyQuyDinh.Visible = true;
            }
            this.MenuItemSearch.Visible = true;
            this.MenuItemFinalReport.Visible = true;
        }

        private void MenuItemFinalReport_Click(object sender, EventArgs e)
        {
            BaoCaoTongKet newform = new BaoCaoTongKet();
            this.Hide();
            newform.ShowDialog();
            this.Show();
        }


        private void MenuItemAddStudent_Click(object sender, EventArgs e)
        {
            TiepNhanHocSinh newform = new TiepNhanHocSinh(this);
            this.Hide();
            newform.ShowDialog();
            this.Show();
        }


        private void MenuItemClassScore_Click(object sender, EventArgs e)
        {
            BangDiemTongKetLop newform = new BangDiemTongKetLop();
            this.Hide();
            newform.ShowDialog();
            this.Show();
        }

        private void MenuItemFindStudent_Click(object sender, EventArgs e)
        {
            TraCuuHocSinh newform = new TraCuuHocSinh(this);
            this.Hide();
            newform.ShowDialog();
            this.Show();
        }

        private void MenuItemScoreBoard_Click(object sender, EventArgs e)
        {
            BangDiemHocSinh newform = new BangDiemHocSinh();
            this.Hide();
            newform.ShowDialog();
            this.Show();
        }

        private void MenuItemSubjectScore_Click(object sender, EventArgs e)
        {
            LapBangDiemMonHoc newform = new LapBangDiemMonHoc(this);
            this.Hide();
            newform.ShowDialog();
            this.Show();
        }

        private void MenuItemSubjectScoreYear_Click(object sender, EventArgs e)
        {
            BangDiemMonHocCuaLopTrongNam newform = new BangDiemMonHocCuaLopTrongNam(this);
            this.Hide();
            newform.ShowDialog();
            this.Show();
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

        private void MenuQuanLyQuyDinh_Click(object sender, EventArgs e)
        {
            QuanLyQuyDinh newform = new QuanLyQuyDinh();
            this.Hide();
            newform.ShowDialog();
            this.Show();
        }

        private void MenuItemListCreate_Click(object sender, EventArgs e)
        {
            LapDanhSachLop newform = new LapDanhSachLop();
            this.Hide();
            newform.ShowDialog();
            this.Show();
        }
    }
}
