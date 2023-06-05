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
            dataEntities db = new dataEntities();
            this.cbSchoolYear.DataSource = (from obj in db.NAMHOCs
                                            orderby obj.MaNamHoc descending
                                            select obj.NamHoc1).ToList();
            this.cbGrade.DataSource = (from obj in db.KHOIs
                                       orderby obj.MaKhoi ascending
                                       select obj.TenKhoi).ToList();
            this.cbSchoolYear.SelectedIndex = 0;
            this.cbGrade.SelectedIndex = 0;
        }

        private void ShowClassInfo()
        {
            dataEntities db = new dataEntities();
            // Show class info

            // Show class info
        }

        private void cbSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataEntities db = new dataEntities();
            this.cbClass.DataSource = (from l in db.LOPs
                                       join nh in db.NAMHOCs on l.MaNamHoc equals nh.MaNamHoc
                                       join k in db.KHOIs on l.MaKhoi equals k.MaKhoi
                                       where nh.NamHoc1 == cbSchoolYear.SelectedText
                                       && k.TenKhoi == cbGrade.SelectedText
                                       orderby l.MaLop ascending
                                       select l.TenLop).ToList();
        }

        private void cbGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataEntities db = new dataEntities();
            this.cbClass.DataSource = (from l in db.LOPs
                                       join nh in db.NAMHOCs on l.MaNamHoc equals nh.MaNamHoc
                                       join k in db.KHOIs on l.MaKhoi equals k.MaKhoi
                                       where nh.NamHoc1 == cbSchoolYear.SelectedText
                                       && k.TenKhoi == cbGrade.SelectedText
                                       orderby l.MaLop ascending
                                       select l.TenLop).ToList();
        }

        private void cbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowClassInfo();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void LapDanhSachLop_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'duLieu.CTLOP' table. You can move, or remove it, as needed.
            this.cTLOPTableAdapter.Fill(this.duLieu.CTLOP);
            // TODO: This line of code loads data into the 'duLieu.HOCSINH' table. You can move, or remove it, as needed.
            this.hOCSINHTableAdapter.Fill(this.duLieu.HOCSINH);

        }
    }
}
