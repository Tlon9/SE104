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
    struct reportformat 
    {
        private int stt;
        private string lop;
        private int siso;
        private int gioi;
        private int kha;
        private int tb;
        private int yeu;
        private int kem;

        public int STT { get { return stt; } set { stt = value; } }
        public string LOP { get { return lop; } set { lop = value; } }
        public int SISO { get { return siso; } set { siso = value; } }
        public int GIOI { get { return gioi; } set { gioi = value; } }
        public int KHA { get { return kha; } set { kha = value; } }
        public int TB { get { return tb; } set { tb = value; } }
        public int YEU { get { return yeu; } set { yeu = value; } }
        public int KEM { get { return kem; } set { kem = value; } }

    }
    public partial class BaoCaoTongKet : Form
    {
        public BaoCaoTongKet()
        {
            InitializeComponent();
            PanelStudent.Hide();
            PanelStudent2.Hide();
            PanelStudent3.Hide();
            PanelStudent4.Hide();
            dataGridViewReport.Hide();
            dataGridViewReport2.Hide();
            dataGridViewReport3.Hide();
            dataGridViewReport4.Hide();
            dataEntities data = new dataEntities();
            var ComboBoxSubjectsSource = from obj in data.MONHOCs
                           select obj;
            ComboBoxSubjects.DataSource = ComboBoxSubjectsSource.ToList();
            ComboBoxSubjects.DisplayMember = "TenMonHoc";
            ComboBoxSubjects.ValueMember = "MaMonHoc";
            ComboBoxSubjects2.DataSource = ComboBoxSubjectsSource.ToList();
            ComboBoxSubjects2.DisplayMember = "TenMonHoc";
            ComboBoxSubjects.ValueMember = "MaMonHoc";
        }


        private void ButtonReport_Click(object sender, EventArgs e)
        {
            dataEntities dtb = new dataEntities();
            var Source = from scr in dtb.DIEMs
                           join cls_detail in dtb.CTLOPs on scr.MaHocSinh equals cls_detail.MaHocSinh
                           join cls in dtb.LOPs on cls_detail.MaLop equals cls.MaLop
                           where ComboBoxSubjects.SelectedValue == scr.MaMonHoc && ComboBoxYears.SelectedItem == scr.NamHoc 
                                 && ComboBoxSemesters.SelectedItem == scr.HocKy && scr.NamHoc == cls.NamHoc
                           group new {cls_detail, cls, scr }
                           by new { cls_detail.MaLop, cls.TenLop, scr.MaXepLoai}
                           into grp
                           select new { Tenlop = grp.Key.TenLop, XepLoai = grp.Key.MaXepLoai, Soluong = grp.Count()};
            if (Source.Count() == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var reSource = new List<reportformat>();
                var temp = new reportformat();
                var index = -1;
                foreach (var item in Source)
                {
                    if (index == -1 || (index != -1 && reSource[index].LOP != item.Tenlop))
                    {
                        index += 1;
                        temp.STT = index + 1;
                        temp.LOP = item.Tenlop;
                        temp.SISO = 0;
                        temp.GIOI = 0;
                        temp.KHA = 0;
                        temp.TB = 0;
                        temp.YEU = 0;
                        temp.KEM = 0;
                        reSource.Add(temp);
                    }
                    temp = reSource[index];
                    switch (item.XepLoai.ToString())
                    {
                        case "HSG":
                            temp.GIOI += item.Soluong;
                            break;
                        case "HSK":
                            temp.KHA += item.Soluong;
                            break;
                        case "HSTB":
                            temp.TB += item.Soluong;
                            break;
                        case "HSY":
                            temp.YEU += item.Soluong;
                            break;
                        case "HSKEM":
                            temp.KEM += item.Soluong;
                            break;
                    }
                    temp.SISO += item.Soluong;
                    reSource[index] = temp;
                }
                int Gioi = 0;
                int Kha = 0;
                int Tb = 0;
                int Yeu = 0;
                int Kem = 0;
                int TongSo = 0;
                foreach (var item in reSource)
                {
                    Gioi += item.GIOI;
                    Kha += item.KHA;
                    Tb += item.TB;
                    Yeu += item.YEU;
                    Kem += item.KEM;
                    TongSo += item.SISO;
                }
                double ratio1 = 100 * Gioi / TongSo;
                double ratio2 = 100 * Kha / TongSo;
                double ratio3 = 100 * Tb / TongSo;
                double ratio4 = 100 * Yeu / TongSo;
                double ratio5 = 100 * Kem / TongSo;

                textBoxStudent.Text = TongSo.ToString();
                textBoxStudent1.Text = Gioi.ToString();
                textBoxStudent2.Text = Kha.ToString();
                textBoxStudent3.Text = Tb.ToString();
                textBoxStudent4.Text = Yeu.ToString();
                textBoxStudent5.Text = Kem.ToString();

                textBoxRatio1.Text = Math.Round(ratio1, 2).ToString() + '%';
                textBoxRatio2.Text = Math.Round(ratio2, 2).ToString() + '%';
                textBoxRatio3.Text = Math.Round(ratio3, 2).ToString() + '%';
                textBoxRatio4.Text = Math.Round(ratio4, 2).ToString() + '%';
                textBoxRatio5.Text = Math.Round(ratio5, 2).ToString() + '%';

                dataGridViewReport.DataSource = reSource;
                PanelStudent.Show();
                dataGridViewReport.Show();
            }
        }



        private void ButtonReport2_Click(object sender, EventArgs e)
        {
            dataEntities dtb = new dataEntities();
            var Source = from scr in dtb.DIEMs
                         join cls_detail in dtb.CTLOPs on scr.MaHocSinh equals cls_detail.MaHocSinh
                         join cls in dtb.LOPs on cls_detail.MaLop equals cls.MaLop
                         where ComboBoxSubjects2.SelectedValue == scr.MaMonHoc && ComboBoxYears2.SelectedItem == scr.NamHoc
                               && scr.NamHoc == cls.NamHoc
                         group new { cls_detail, cls, scr }
                         by new { cls_detail.MaLop, cls.TenLop, scr.MaHocSinh}
                         into grp
                         select new { Tenlop = grp.Key.TenLop, DiemTb = grp.Sum(row => row.scr.DiemTB), Soluong = grp.Count() };
            bool check = false;
            foreach(var item in Source)
            {
                if (item.Soluong==2)
                {
                    check = true;
                    break;
                }
            }
            if (!check)
            {
                MessageBox.Show("Không có dữ liệu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var reSource = new List<reportformat>();
                var temp = new reportformat();
                var index = -1;
                foreach (var item in Source)
                {
                    if (item.Soluong == 2)
                    {
                        if (index == -1 || (index != -1 && reSource[index].LOP != item.Tenlop))
                        {
                            index += 1;
                            temp.STT = index + 1;
                            temp.LOP = item.Tenlop;
                            temp.SISO = 0;
                            temp.GIOI = 0;
                            temp.KHA = 0;
                            temp.TB = 0;
                            temp.YEU = 0;
                            temp.KEM = 0;
                            reSource.Add(temp);
                        }
                        temp = reSource[index];

                        var HSG = (from xl in dtb.XEPLOAIs
                                  where xl.MaXepLoai == "HSG"
                                  select xl.DiemToiThieu).FirstOrDefault() ;
                        var HSK = (from xl in dtb.XEPLOAIs
                                  where xl.MaXepLoai == "HSK"
                                  select xl.DiemToiThieu).FirstOrDefault();
                        var HSTB = (from xl in dtb.XEPLOAIs
                                   where xl.MaXepLoai == "HSTB"
                                   select xl.DiemToiThieu).FirstOrDefault();
                        var HSY = (from xl in dtb.XEPLOAIs
                                  where xl.MaXepLoai == "HSY"
                                  select xl.DiemToiThieu).FirstOrDefault();

                        var DTBnh = Math.Round((double)item.DiemTb/2, 2);
                        if (DTBnh >= HSG) temp.GIOI += 1;
                        else if (DTBnh >= HSK) temp.KHA += 1;
                        else if (DTBnh >= HSTB) temp.TB += 1;
                        else if (DTBnh >= HSY) temp.YEU += 1;
                        else temp.KEM += 1;
                        temp.SISO += 1;
                        reSource[index] = temp;
                    }
                }
                int Gioi = 0;
                int Kha = 0;
                int Tb = 0;
                int Yeu = 0;
                int Kem = 0;
                int TongSo = 0;
                foreach (var item in reSource)
                {
                    Gioi += item.GIOI;
                    Kha += item.KHA;
                    Tb += item.TB;
                    Yeu += item.YEU;
                    Kem += item.KEM;
                    TongSo += item.SISO;
                }
                double ratio6 = 100 * Gioi / TongSo;
                double ratio7 = 100 * Kha / TongSo;
                double ratio8 = 100 * Tb / TongSo;
                double ratio9 = 100 * Yeu / TongSo;
                double ratio10 = 100 * Kem / TongSo;

                textBoxStudent6.Text = TongSo.ToString();
                textBoxStudent7.Text = Gioi.ToString();
                textBoxStudent8.Text = Kha.ToString();
                textBoxStudent9.Text = Tb.ToString();
                textBoxStudent10.Text = Yeu.ToString();
                textBoxStudent11.Text = Kem.ToString();

                textBoxRatio6.Text = Math.Round(ratio6, 2).ToString() + '%';
                textBoxRatio7.Text = Math.Round(ratio7, 2).ToString() + '%';
                textBoxRatio8.Text = Math.Round(ratio8, 2).ToString() + '%';
                textBoxRatio9.Text = Math.Round(ratio9, 2).ToString() + '%';
                textBoxRatio10.Text = Math.Round(ratio10, 2).ToString() + '%';

                dataGridViewReport2.DataSource = reSource;
                PanelStudent2.Show();
                dataGridViewReport2.Show();
            }
        }

        private void buttonReport3_Click(object sender, EventArgs e)
        {
            dataEntities dtb = new dataEntities();
            var Source = from scr in dtb.DIEMs
                         join cls_detail in dtb.CTLOPs on scr.MaHocSinh equals cls_detail.MaHocSinh
                         join cls in dtb.LOPs on cls_detail.MaLop equals cls.MaLop
                         where comboBoxSemesters2.SelectedItem == scr.HocKy && comboBoxYears3.SelectedItem == scr.NamHoc
                               && scr.NamHoc == cls.NamHoc  
                         group new { cls_detail, cls, scr }
                         by new { cls_detail.MaLop, cls.TenLop, scr.MaHocSinh }
                         into grp
                         select new { Tenlop = grp.Key.TenLop, DiemTb = grp.Sum(row => row.scr.DiemTB),DiemKC = grp.Min(row => row.scr.DiemTB), Soluong = grp.Count() };
            bool check = false;
            foreach (var item in Source)
            {
                if (item.Soluong == 13)
                {
                    check = true;
                    break;
                }
            }
            if (!check)
            {
                MessageBox.Show("Không có dữ liệu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var reSource = new List<reportformat>();
                var temp = new reportformat();
                var index = -1;
                foreach (var item in Source)
                {
                    if (item.Soluong == 13)
                    {
                        if (index == -1 || (index != -1 && reSource[index].LOP != item.Tenlop))
                        {
                            index += 1;
                            temp.STT = index + 1;
                            temp.LOP = item.Tenlop;
                            temp.SISO = 0;
                            temp.GIOI = 0;
                            temp.KHA = 0;
                            temp.TB = 0;
                            temp.YEU = 0;
                            temp.KEM = 0;
                            reSource.Add(temp);
                        }
                        temp = reSource[index];

                        var HSG = (from xl in dtb.XEPLOAIs
                                   where xl.MaXepLoai == "HSG"
                                   select new { xl.DiemToiThieu, xl.DiemKhongChe }).FirstOrDefault();
                        var HSK = (from xl in dtb.XEPLOAIs
                                   where xl.MaXepLoai == "HSK"
                                   select new { xl.DiemToiThieu, xl.DiemKhongChe }).FirstOrDefault();
                        var HSTB = (from xl in dtb.XEPLOAIs
                                    where xl.MaXepLoai == "HSTB"
                                    select new { xl.DiemToiThieu, xl.DiemKhongChe }).FirstOrDefault();
                        var HSY = (from xl in dtb.XEPLOAIs
                                   where xl.MaXepLoai == "HSY"
                                   select new { xl.DiemToiThieu, xl.DiemKhongChe }).FirstOrDefault();

                        var DTBnh = Math.Round((double)item.DiemTb / 13, 2);
                        if (DTBnh >= HSG.DiemToiThieu)
                        {
                            if (item.DiemKC >= HSG.DiemKhongChe)
                            {
                                temp.GIOI += 1;
                            }
                            else if (item.DiemKC >= HSTB.DiemToiThieu)
                            {
                                temp.KHA += 1;
                            }
                            else
                            {
                                temp.TB += 1;
                            }

                        }
                        else if (DTBnh >= HSK.DiemToiThieu)
                        {
                            if (item.DiemKC >= HSK.DiemKhongChe)
                            {
                                temp.KHA += 1;
                            }
                            else if (item.DiemKC >= HSY.DiemToiThieu)
                            {
                                temp.TB += 1;
                            }
                            else
                            {
                                temp.YEU += 1;
                            }
                        }
                        else if (DTBnh >= HSTB.DiemToiThieu)
                        {
                            if (item.DiemKC >= HSTB.DiemKhongChe)
                            {
                                temp.TB += 1;
                            }
                            else
                            {
                                temp.YEU += 1;
                            }
                        }
                        else if (DTBnh >= HSY.DiemToiThieu)
                        {
                            if (item.DiemKC >= HSY.DiemKhongChe)
                            {
                                temp.YEU += 1;
                            }
                            else
                            {
                                temp.KEM += 1;
                            }
                        }
                        else temp.KEM += 1;
                        temp.SISO += 1;
                        reSource[index] = temp;
                    }
                }
                int Gioi = 0;
                int Kha = 0;
                int Tb = 0;
                int Yeu = 0;
                int Kem = 0;
                int TongSo = 0;
                foreach (var item in reSource)
                {
                    Gioi += item.GIOI;
                    Kha += item.KHA;
                    Tb += item.TB;
                    Yeu += item.YEU;
                    Kem += item.KEM;
                    TongSo += item.SISO;
                }
                double ratio11 = 100 * Gioi / TongSo;
                double ratio12 = 100 * Kha / TongSo;
                double ratio13 = 100 * Tb / TongSo;
                double ratio14 = 100 * Yeu / TongSo;
                double ratio15 = 100 * Kem / TongSo;

                textBoxStudent12.Text = TongSo.ToString();
                textBoxStudent13.Text = Gioi.ToString();
                textBoxStudent14.Text = Kha.ToString();
                textBoxStudent15.Text = Tb.ToString();
                textBoxStudent16.Text = Yeu.ToString();
                textBoxStudent17.Text = Kem.ToString();

                textBoxRatio11.Text = Math.Round(ratio11, 2).ToString() + '%';
                textBoxRatio12.Text = Math.Round(ratio12, 2).ToString() + '%';
                textBoxRatio13.Text = Math.Round(ratio13, 2).ToString() + '%';
                textBoxRatio14.Text = Math.Round(ratio14, 2).ToString() + '%';
                textBoxRatio15.Text = Math.Round(ratio15, 2).ToString() + '%';

                dataGridViewReport3.DataSource = reSource;
                PanelStudent3.Show();
                dataGridViewReport3.Show();
            }
        }

        private void buttonReport4_Click(object sender, EventArgs e)
        {
            dataEntities dtb = new dataEntities();
            var Source = from scr in dtb.DIEMs
                         join cls_detail in dtb.CTLOPs on scr.MaHocSinh equals cls_detail.MaHocSinh
                         join cls in dtb.LOPs on cls_detail.MaLop equals cls.MaLop
                         where comboBoxYears4.SelectedItem == scr.NamHoc && scr.NamHoc == cls.NamHoc
                         group new { cls_detail, cls, scr }
                         by new { cls_detail.MaLop, cls.TenLop, scr.MaHocSinh, scr.MaMonHoc}
                         into grp
                         select new { Tenlop = grp.Key.TenLop, MaHS = grp.Key.MaHocSinh, MaMH = grp.Key.MaMonHoc, DiemTb = Math.Round((double)grp.Sum(row => row.scr.DiemTB)/2,2), SoLuong = grp.Count() };
            bool check = false;
            int count = 0;

            var check_Source = from sce in Source
                               where sce.SoLuong == 2
                               group sce
                               by new { sce.MaHS, sce.Tenlop}
                               into grp
                               select new {Tenlop = grp.Key.Tenlop, MaHS = grp.Key.MaHS, SoLuong = grp.Count(), DiemTb = Math.Round((double)grp.Sum(row => row.DiemTb)/13,2), DiemKC = grp.Min(row => row.DiemTb)};
            foreach (var item in check_Source)
            {
                if (item.SoLuong == 13)
                {
                    check = true;
                    break;
                }
            }  
            if (!check)
            {
                MessageBox.Show("Không có dữ liệu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var reSource = new List<reportformat>();
                var temp = new reportformat();
                var index = -1;
                foreach (var item in check_Source)
                {
                    if (item.SoLuong == 13)
                    {
                        if (index == -1 || (index != -1 && reSource[index].LOP != item.Tenlop))
                        {
                            index += 1;
                            temp.STT = index + 1;
                            temp.LOP = item.Tenlop;
                            temp.SISO = 0;
                            temp.GIOI = 0;
                            temp.KHA = 0;
                            temp.TB = 0;
                            temp.YEU = 0;
                            temp.KEM = 0;
                            reSource.Add(temp);
                        }
                        temp = reSource[index];

                        var HSG = (from xl in dtb.XEPLOAIs
                                   where xl.MaXepLoai == "HSG"
                                   select new { xl.DiemToiThieu, xl.DiemKhongChe }).FirstOrDefault();
                        var HSK = (from xl in dtb.XEPLOAIs
                                   where xl.MaXepLoai == "HSK"
                                   select new { xl.DiemToiThieu, xl.DiemKhongChe }).FirstOrDefault();
                        var HSTB = (from xl in dtb.XEPLOAIs
                                    where xl.MaXepLoai == "HSTB"
                                    select new { xl.DiemToiThieu, xl.DiemKhongChe }).FirstOrDefault();
                        var HSY = (from xl in dtb.XEPLOAIs
                                   where xl.MaXepLoai == "HSY"
                                   select new { xl.DiemToiThieu, xl.DiemKhongChe }).FirstOrDefault();

                        var DTBnh = item.DiemTb;
                        if (DTBnh >= HSG.DiemToiThieu)
                        {
                            if (item.DiemKC >= HSG.DiemKhongChe)
                            {
                                temp.GIOI += 1;
                            }
                            else if (item.DiemKC >= HSTB.DiemToiThieu)
                            {
                                temp.KHA += 1;
                            }
                            else
                            {
                                temp.TB += 1;
                            }

                        }
                        else if (DTBnh >= HSK.DiemToiThieu)
                        {
                            if (item.DiemKC >= HSK.DiemKhongChe)
                            {
                                temp.KHA += 1;
                            }
                            else if (item.DiemKC >= HSY.DiemToiThieu)
                            {
                                temp.TB += 1;
                            }
                            else
                            {
                                temp.YEU += 1;
                            }
                        }
                        else if (DTBnh >= HSTB.DiemToiThieu)
                        {
                            if (item.DiemKC >= HSTB.DiemKhongChe)
                            {
                                temp.TB += 1;
                            }
                            else
                            {
                                temp.YEU += 1;
                            }
                        }
                        else if (DTBnh >= HSY.DiemToiThieu)
                        {
                            if (item.DiemKC >= HSY.DiemKhongChe)
                            {
                                temp.YEU += 1;
                            }
                            else
                            {
                                temp.KEM += 1;
                            }
                        }
                        else temp.KEM += 1;
                        temp.SISO += 1;
                        reSource[index] = temp;
                    }
                }
                int Gioi = 0;
                int Kha = 0;
                int Tb = 0;
                int Yeu = 0;
                int Kem = 0;
                int TongSo = 0;
                foreach (var item in reSource)
                {
                    Gioi += item.GIOI;
                    Kha += item.KHA;
                    Tb += item.TB;
                    Yeu += item.YEU;
                    Kem += item.KEM;
                    TongSo += item.SISO;
                }
                double ratio16 = 100 * Gioi / TongSo;
                double ratio17 = 100 * Kha / TongSo;
                double ratio18 = 100 * Tb / TongSo;
                double ratio19 = 100 * Yeu / TongSo;
                double ratio20 = 100 * Kem / TongSo;

                textBoxStudent18.Text = TongSo.ToString();
                textBoxStudent19.Text = Gioi.ToString();
                textBoxStudent20.Text = Kha.ToString();
                textBoxStudent21.Text = Tb.ToString();
                textBoxStudent22.Text = Yeu.ToString();
                textBoxStudent23.Text = Kem.ToString();

                textBoxRatio16.Text = Math.Round(ratio16, 2).ToString() + '%';
                textBoxRatio17.Text = Math.Round(ratio17, 2).ToString() + '%';
                textBoxRatio18.Text = Math.Round(ratio18, 2).ToString() + '%';
                textBoxRatio19.Text = Math.Round(ratio19, 2).ToString() + '%';
                textBoxRatio20.Text = Math.Round(ratio20, 2).ToString() + '%';

                dataGridViewReport4.DataSource = reSource;
                PanelStudent4.Show();
                dataGridViewReport4.Show();
            }
        }

  
    }
}
