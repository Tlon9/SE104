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

        private void ThemHocSinhVaoLop()
        {
            
        }

        private void cbSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataEntities db = new dataEntities();
            this.cbClass.DataSource = from l in db.LOPs
                                      join nh in db.NAMHOCs on l.MaNamHoc equals nh.MaNamHoc
                                      join k in db.KHOIs on l.MaKhoi equals k.MaKhoi
                                      where nh.NamHoc1 == this.cbSchoolYear.Text
                                      && k.TenKhoi == this.cbGrade.Text
                                      orderby l.MaLop ascending
                                      select l.TenLop;
        }

        private void cbGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataEntities db = new dataEntities();
            this.cbClass.DataSource = from l in db.LOPs
                                      join nh in db.NAMHOCs on l.MaNamHoc equals nh.MaNamHoc
                                      join k in db.KHOIs on l.MaKhoi equals k.MaKhoi
                                      where nh.NamHoc1 == this.cbSchoolYear.Text
                                      && k.TenKhoi == this.cbGrade.Text
                                      orderby l.MaLop ascending
                                      select l.TenLop;
        }

        private void cbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataEntities db = new dataEntities();
            //this.dgvClassDetail.DataSource = from ctl in db.CTLOPs.AsEnumerable()
            //                                 join hs in db.HOCSINHs.AsEnumerable() on ctl.MaHocSinh equals hs.MaHocSinh
            //                                 join l in db.LOPs.AsEnumerable() on ctl.MaLop equals l.MaLop
            //                                 where l.MaLop == this.cbClass.Text
            //                                 group new {ctl, hs, l}
            //                                 by new {hs.MaHocSinh, hs.HoTen, hs.GioiTinh, hs.NgaySinh, hs.DiaChi, hs.SDT}
            //                                 into g
            //                                 select new
            //                                 {
            //                                     MaHocSinh = g.Key.MaHocSinh,
            //                                     HoTen = g.Key.HoTen,
            //                                     GioiTinh = g.Key.GioiTinh,
            //                                     NgaySinh = g.Key.NgaySinh,
            //                                     DiaChi = g.Key.DiaChi,
            //                                     SDT = g.Key.SDT
            //                                 };
            

        }

        private void Btn_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnHomeScreen_Click(object sender, EventArgs e)
        {
            TrangChu newform = new TrangChu();
            this.Hide();
            newform.ShowDialog();
            this.Show();
        }
    }
}
