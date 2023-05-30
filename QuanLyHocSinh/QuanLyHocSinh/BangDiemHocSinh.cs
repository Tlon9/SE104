using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Diagnostics.Eventing.Reader;

namespace QuanLyHocSinh
{
    public partial class BangDiemHocSinh : Form
    {
        public BangDiemHocSinh()
        {

            InitializeComponent();
            DHKGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DHKGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DNHGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DNHGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        string GetHoTen(string MaHS, dataEntities dtb)
        {
            var HoTen = from h in dtb.HOCSINHs
                        where h.MaHocSinh == MaHS
                        select h.HoTen;
            return HoTen.First();
        }
<<<<<<< HEAD
        string GetLop(string MaLop,string HK, string NH, dataEntities dtb)
=======
        /*string GetLop(string MaLop,string HK, string Nam, dataEntities dtb)
>>>>>>> 6a709344071403f5e3781826145849662f76719b
        {
            var Lop = from ctl in dtb.CTLOPs
                      join kq in dtb.KETQUA_MONHOC_HOCSINH on ctl.MaHocSinh equals kq.MaHocSinh
                      join l in dtb.LOPs on ctl.MaLop equals l.MaLop
                      join hk in dtb.HOCKies on kq.MaHocKy equals hk.MaHocKy
                      join nh in dtb.NAMHOCs on kq.MaNamHoc equals nh.MaNamHoc
                      where kq.MaHocSinh == MaLop && hk.HocKy1 == HK && nh.NamHoc1 == NH
                      select l.TenLop;
            return Lop.First();
<<<<<<< HEAD
        }
        Array DIEM_TP(string MHS, string HK, string NH, string TP)
        {
            dataEntities dtb = new dataEntities();
            var DIEM = from d in dtb.DIEMs
                         join kq in dtb.KETQUA_MONHOC_HOCSINH on d.MaKetQua equals kq.MaKetQua
                         join hk in dtb.HOCKies on kq.MaHocKy equals hk.MaHocKy
                         join nh in dtb.NAMHOCs on kq.MaNamHoc equals nh.MaNamHoc
                         join mh in dtb.MONHOCs on kq.MaMonHoc equals mh.MaMonHoc
                         join tp in dtb.THANHPHANs on d.MaThanhPhan equals tp.MaThanhPhan
                         where kq.MaHocSinh == MHS && hk.HocKy1 == HK && nh.NamHoc1 == NH && tp.MaThanhPhan == TP
                         select (d.Diem1 != null ? d.Diem1 : null);
            return DIEM.ToArray();
        }
        bool Kiemtra_input(string MHS, string HK = "", string NH = "")
        {
            dataEntities dtb = new dataEntities();
            var DsHocSinh = from hs in dtb.HOCSINHs
                            select hs.MaHocSinh;
            var DsDiemHS = from kq in dtb.KETQUA_MONHOC_HOCSINH
                           select kq.MaHocSinh;
            var DsNamHoc = from kq in dtb.KETQUA_MONHOC_HOCSINH
                           join nh in dtb.NAMHOCs on kq.MaNamHoc equals nh.MaNamHoc
                           where kq.MaHocSinh == MHS
                           select nh.NamHoc1;
            var DsHocKy = from kq in dtb.KETQUA_MONHOC_HOCSINH
                          join nh in dtb.NAMHOCs on kq.MaNamHoc equals nh.MaNamHoc
                          join hk in dtb.HOCKies on kq.MaHocKy equals hk.MaHocKy
                          where kq.MaHocSinh == MHS
                          select hk.HocKy1;
            bool checkMaHS = false;
            foreach (var d in DsHocSinh)
=======
        }*/
        void TraCuuDiemHocKy()
        {
            /*dataEntities dtb = new dataEntities();
            var result = from c in dtb.DIEMs
                         where c.MaHocSinh == MHStextbox_hk.Text && c.HocKy == HocKyCbb.Text && c.NamHoc == NamHocCbb_hk.Text
                         select new {c.MaMonHoc,c.MONHOC.TenMonHoc, c.DiemTX, c.DiemGK, c.DiemCK, c.DiemTB };

                        
            //Nhap sai
            if (result.Count() == 0)
>>>>>>> 6a709344071403f5e3781826145849662f76719b
            {
                if (d == MHS)
                {
                    checkMaHS = true;
                    break;
                }
            }
            bool checkDiemHS = false;
            foreach (var d in DsDiemHS)
            {
                if (d == MHS)
                {
                    checkDiemHS = true;
                    break;
                }
            }
            bool checkNamHoc = false;
            foreach (var n in DsNamHoc)
            {
                if (n == NH)
                {
                    checkNamHoc = true;
                    break;
                }
            }
            bool checkHocKy = false;
            foreach (var h in DsHocKy)
            {
                if (h == HK)
                {
                    checkHocKy = true;
                    break;
                }
            }
            if (checkMaHS == false)
            {
                MessageBox.Show("Mã số học sinh không tồn tại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (checkDiemHS == false)
            {
                MessageBox.Show("Không có dữ liệu điểm của học sinh này", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (checkNamHoc == false)
            {
                MessageBox.Show("Học sinh này không có dữ liệu điểm trong năm học này", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (HK == " ") return true;
            else if (checkHocKy == false)
            {
                MessageBox.Show("Học sinh này không có dữ liệu điểm trong học kỳ này", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        void TraCuuDiemHocKy()
        {
            //Nhap sai
            if (Kiemtra_input(MHStextbox_hk.Text,HocKyCbb.Text,NamHocCbb_hk.Text))
            {
                dataEntities dtb = new dataEntities();
                var DIEMTB = from kq in dtb.KETQUA_MONHOC_HOCSINH
                             join hk in dtb.HOCKies on kq.MaHocKy equals hk.MaHocKy
                             join nh in dtb.NAMHOCs on kq.MaNamHoc equals nh.MaNamHoc
                             join mh in dtb.MONHOCs on kq.MaMonHoc equals mh.MaMonHoc
                             where kq.MaHocSinh == MHStextbox_hk.Text && hk.HocKy1 == HocKyCbb.Text && nh.NamHoc1 == NamHocCbb_hk.Text
                             select (kq.DiemTB != null ? kq.DiemTB : null);
                var MaMonHoc = from c in dtb.KETQUA_MONHOC_HOCSINH
                               join g in dtb.HOCKies on c.MaHocKy equals g.MaHocKy
                               join k in dtb.NAMHOCs on c.MaNamHoc equals k.MaNamHoc
                               where c.MaHocSinh == MHStextbox_hk.Text && g.HocKy1 == HocKyCbb.Text && k.NamHoc1 == NamHocCbb_hk.Text
                               select c.MaMonHoc;
                var TenMonHoc = from c in dtb.KETQUA_MONHOC_HOCSINH
                                join g in dtb.HOCKies on c.MaHocKy equals g.MaHocKy
                                join k in dtb.NAMHOCs on c.MaNamHoc equals k.MaNamHoc
                                join m in dtb.MONHOCs on c.MaMonHoc equals m.MaMonHoc
                                where c.MaHocSinh == MHStextbox_hk.Text && g.HocKy1 == HocKyCbb.Text && k.NamHoc1 == NamHocCbb_hk.Text
                                select m.TenMonHoc;
                DNHGridView.Rows.Clear();
                for (int i = 0; i < MaMonHoc.ToList().Count; i++)
                {
                    string Mamh = MaMonHoc.ToList()[i].ToString();
                    DataGridViewRow newRow = new DataGridViewRow();
                    newRow.CreateCells(DHKGridView);
                    newRow.Cells[0].Value = MaMonHoc.ToList()[i];
                    newRow.Cells[1].Value = TenMonHoc.ToList()[i];
                    newRow.Cells[2].Value = DIEM_TP(MHStextbox_hk.Text, HocKyCbb.Text, NamHocCbb_hk.Text, "TX").GetValue(i);
                    newRow.Cells[3].Value = DIEM_TP(MHStextbox_hk.Text, HocKyCbb.Text, NamHocCbb_hk.Text, "GK").GetValue(i);
                    newRow.Cells[4].Value = DIEM_TP(MHStextbox_hk.Text, HocKyCbb.Text, NamHocCbb_hk.Text, "CK").GetValue(i);
                    newRow.Cells[5].Value = DIEMTB.ToList()[i];
                    DHKGridView.Rows.Add(newRow);
                }
                //Ho Ten
                HoTenTextBox.Text = GetHoTen(MHStextbox_hk.Text, dtb);

                //LOP
                LopTextBox.Text = GetLop(MHStextbox_hk.Text, HocKyCbb.Text, NamHocCbb_hk.Text, dtb);

                //Diem trung binh ca hoc ky
                var DTBHK = DIEMTB.Sum(row => row) / DIEMTB.Count(row => row != null);
                DTBHK = Math.Round((double)DTBHK, 2);
                DTBHKTextBox.Text = DTBHK.ToString();

                //XepLoai
                if (DTBHK >= 8) XepLoaiTextBox.Text = "Giỏi";
                else if (DTBHK >= 6.5) XepLoaiTextBox.Text = "Khá";
                else if (DTBHK >= 5) XepLoaiTextBox.Text = "Trung Bình";
                else if (DTBHK >= 3.5) XepLoaiTextBox.Text = "Yếu";
                else XepLoaiTextBox.Text = "Kém";
<<<<<<< HEAD
            } 
        }
        void TraCuuDiemNamHoc()
        {
            //Nhap sai
            if (Kiemtra_input(MHStextbox_nh.Text," ", NamHocCbb_nh.Text))
=======
            }*/
        }
        void TraCuuDiemNamHoc()
        {
            /*dataEntities dtb = new dataEntities();
            var MaMonHoc = from c in dtb.DIEMs
                           where c.MaHocSinh == MHStextbox_nh.Text && c.NamHoc == NamHocCbb_nh.Text && c.HocKy == "1"
                           select c.MaMonHoc;
            var TenMonHoc = from c in dtb.DIEMs
                            join g in dtb.MONHOCs on c.MaMonHoc equals g.MaMonHoc
                            where c.MaHocSinh == MHStextbox_nh.Text && c.NamHoc == NamHocCbb_nh.Text && c.HocKy == "1"
                            select c.MONHOC.TenMonHoc;
            var DiemTBhk1 = from c in dtb.DIEMs
                            where c.MaHocSinh == MHStextbox_nh.Text && c.NamHoc == NamHocCbb_nh.Text && c.HocKy == "1"
                            select c.DiemTB;
            var DiemTbhk2 = from c in dtb.DIEMs
                            where c.MaHocSinh == MHStextbox_nh.Text && c.NamHoc == NamHocCbb_nh.Text && c.HocKy == "2"
                            select c.DiemTB;
            var DiemTbnh = from c in dtb.DIEMs
                           where c.MaHocSinh == MHStextbox_nh.Text && c.NamHoc == NamHocCbb_nh.Text
                           group c by new { c.MaHocSinh, c.NamHoc, c.MaMonHoc } into g
                           select g.Sum(row => row.DiemTB);
            DNHGridView.Rows.Clear();
            for (int i = 0; i < MaMonHoc.Count(); i++)
>>>>>>> 6a709344071403f5e3781826145849662f76719b
            {
                dataEntities dtb = new dataEntities();
                var MaMonHoc = from c in dtb.KETQUA_MONHOC_HOCSINH
                               join g in dtb.HOCKies on c.MaHocKy equals g.MaHocKy
                               join k in dtb.NAMHOCs on c.MaNamHoc equals k.MaNamHoc
                               where c.MaHocSinh == MHStextbox_nh.Text && g.HocKy1 == "HKI" && k.NamHoc1 == NamHocCbb_nh.Text
                               select c.MaMonHoc;
                var TenMonHoc = from c in dtb.KETQUA_MONHOC_HOCSINH
                                join g in dtb.HOCKies on c.MaHocKy equals g.MaHocKy
                                join k in dtb.NAMHOCs on c.MaNamHoc equals k.MaNamHoc
                                join m in dtb.MONHOCs on c.MaMonHoc equals m.MaMonHoc
                                where c.MaHocSinh == MHStextbox_nh.Text && g.HocKy1 == "HKI" && k.NamHoc1 == NamHocCbb_nh.Text
                                select m.TenMonHoc;
                var DiemTBhk1 = from c in dtb.KETQUA_MONHOC_HOCSINH
                                join g in dtb.HOCKies on c.MaHocKy equals g.MaHocKy
                                join k in dtb.NAMHOCs on c.MaNamHoc equals k.MaNamHoc
                                where c.MaHocSinh == MHStextbox_nh.Text && g.HocKy1 == "HKI" && k.NamHoc1 == NamHocCbb_nh.Text
                                select (c.DiemTB != null ? c.DiemTB : null);
                var DiemTBhk2 = from c in dtb.KETQUA_MONHOC_HOCSINH
                                join g in dtb.HOCKies on c.MaHocKy equals g.MaHocKy
                                join k in dtb.NAMHOCs on c.MaNamHoc equals k.MaNamHoc
                                where c.MaHocSinh == MHStextbox_nh.Text && g.HocKy1 == "HKII" && k.NamHoc1 == NamHocCbb_nh.Text
                                select (c.DiemTB != null ? c.DiemTB : null);
                DNHGridView.Rows.Clear();
                float Tong_DiemTB = 0;
                for (int i = 0; i < MaMonHoc.Count(); i++)
                {

                    DataGridViewRow newRow = new DataGridViewRow();
                    newRow.CreateCells(DNHGridView);
                    newRow.Cells[0].Value = MaMonHoc.ToList()[i];
                    newRow.Cells[1].Value = TenMonHoc.ToList()[i];
                    newRow.Cells[2].Value = DiemTBhk1.ToArray().GetValue(i);
                    if (DiemTBhk2.Count() != 0) newRow.Cells[3].Value = DiemTBhk2.ToArray().GetValue(i);
                    if (DiemTBhk1.Count() != 0 && DiemTBhk2.Count() != 0)
                    {
                        var DiemTbmon = DiemTBhk1.ToList()[i] + DiemTBhk2.ToList()[i];
                        newRow.Cells[4].Value = Math.Round((double)DiemTbmon / 2, 2);

                    }
                    else if (DiemTBhk1.Count() == 0)
                    {
                        var DiemTbmon = DiemTBhk2.ToList()[i];
                        newRow.Cells[4].Value = DiemTbmon;

                    }
                    else if (DiemTBhk2.Count() == 0)
                    {
                        var DiemTbmon = DiemTBhk1.ToList()[i];
                        newRow.Cells[4].Value = DiemTbmon;
                    }
                    Tong_DiemTB += Convert.ToInt64(newRow.Cells[4].Value);
                    DNHGridView.Rows.Add(newRow);
                }
                //Ho Ten
                HoTenTxtBox_nh.Text = GetHoTen(MHStextbox_nh.Text, dtb);

                //LOP
                LopTxtBox_nh.Text = GetLop(MHStextbox_nh.Text, "HKI", NamHocCbb_nh.Text, dtb);


<<<<<<< HEAD
                //Diem trung binh nam hoc
                var DiemTB = Tong_DiemTB / Math.Max(DiemTBhk1.Count(row => row != null), DiemTBhk2.Count(row => row != null));
                DTBNHTxtBox.Text = DiemTB.ToString();
=======
            //Diem trung binh nam hoc
            var DTBnh = DiemTbnh.Sum(row=>row)/13;
            DTBnh = Math.Round((double)DTBnh/2, 2);
            DTBNHTxtBox.Text = DTBnh.ToString();

            //XepLoai
            if (DTBnh >= 8) XepLoaiTxtBox_nh.Text = "Giỏi";
            else if (DTBnh >= 6.5) XepLoaiTxtBox_nh.Text = "Khá";
            else if (DTBnh >= 5) XepLoaiTxtBox_nh.Text = "Trung Bình";
            else if (DTBnh >= 3.5) XepLoaiTxtBox_nh.Text = "Yếu";
            else XepLoaiTxtBox_nh.Text = "Kém";*/
>>>>>>> 6a709344071403f5e3781826145849662f76719b

                //XepLoai
                if (DiemTB >= 8) XepLoaiTxtBox_nh.Text = "Giỏi";
                else if (DiemTB >= 6.5) XepLoaiTxtBox_nh.Text = "Khá";
                else if (DiemTB >= 5) XepLoaiTxtBox_nh.Text = "Trung Bình";
                else if (DiemTB >= 3.5) XepLoaiTxtBox_nh.Text = "Yếu";
                else XepLoaiTxtBox_nh.Text = "Kém";
            }                
        }

        private void TraCuuButton_hk_Click(object sender, EventArgs e)
        {
            TraCuuDiemHocKy();
        }

        private void TraCuuButton_nh_Click(object sender, EventArgs e)
        {
            TraCuuDiemNamHoc();
        }
    }
}
