using LapBangDiemMonHocCuaLopNamHoc;
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
            this.Show();
        }

        private void MenuItemSubjectScore_Click(object sender, EventArgs e)
        {
            LapBangDiemMonHoc newform = new LapBangDiemMonHoc();
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

        private void MenuItemSubjectScoreYear_Click(object sender, EventArgs e)
        {
            LapBangDiemMonHocCuaLopTrongNamHoc newform = new LapBangDiemMonHocCuaLopTrongNamHoc();
            this.Hide();
            newform.ShowDialog();
            this.Show();
        }
    }
}
