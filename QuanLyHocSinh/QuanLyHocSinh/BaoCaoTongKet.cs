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
            PanelStudent4.Hide();
            dataGridViewReport4.Hide();
            dataEntities data = new dataEntities();
            //Get source
            var ComboBoxSubjectsSource = from obj in data.MONHOCs
                                      select obj;

            var ComboBoxYearsSource = from obj in data.NAMHOCs
                                      select obj;

            var ComboBoxSemestersSource = from obj in data.HOCKies
                                          select obj;

            ComboBoxSubjects.DataSource = ComboBoxSubjectsSource.ToList();
            ComboBoxSubjects.DisplayMember = "TenMonHoc";
            ComboBoxSubjects.ValueMember = "MaMonHoc";

            ComboBoxSubjects2.DataSource = ComboBoxSubjectsSource.ToList();
            ComboBoxSubjects2.DisplayMember = "TenMonHoc";
            ComboBoxSubjects.ValueMember = "MaMonHoc";

            ComboBoxYears.DataSource = ComboBoxYearsSource.ToList();
            ComboBoxYears.DisplayMember = "NamHoc1";
            ComboBoxYears.ValueMember = "MaNamHoc";

            ComboBoxYears2.DataSource = ComboBoxYearsSource.ToList();
            ComboBoxYears2.DisplayMember = "NamHoc1";
            ComboBoxYears2.ValueMember = "MaNamHoc";

            ComboBoxYears3.DataSource = ComboBoxYearsSource.ToList();
            ComboBoxYears3.DisplayMember = "NamHoc1";
            ComboBoxYears3.ValueMember = "MaNamHoc";

            ComboBoxYears4.DataSource = ComboBoxYearsSource.ToList();
            ComboBoxYears4.DisplayMember = "NamHoc1";
            ComboBoxYears4.ValueMember = "MaNamHoc";

            ComboBoxSemesters.DataSource = ComboBoxSemestersSource.ToList();
            ComboBoxSemesters.DisplayMember = "HocKy1";
            ComboBoxSemesters.ValueMember = "MaHocKy";

            ComboBoxSemesters2.DataSource = ComboBoxSemestersSource.ToList();
            ComboBoxSemesters2.DisplayMember = "HocKy1";
            ComboBoxSemesters2.ValueMember = "MaHocKy";

        }


        private void ButtonReport_Click(object sender, EventArgs e)
        {
            dataEntities dtb = new dataEntities();
            DataTable tbl = new DataTable();
            
            var Source = dtb.TongKetMonHocKy(ComboBoxSubjects.SelectedValue.ToString(),ComboBoxSemesters.SelectedValue.ToString(),ComboBoxYears.SelectedValue.ToString());
            var reSource = Source.ToList();
            var sum = 0;
            

            if (reSource.Count() == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                tbl.Columns.Add("STT", typeof(string));
                tbl.Columns.Add("Lớp", typeof(string));
                tbl.Columns.Add("Sĩ số", typeof(int));
                foreach (var item in dtb.XEPLOAIs.OrderByDescending(r => r.DiemToiThieu))
                {
                    tbl.Columns.Add(item.TenXepLoai, typeof(int));
                }
                var index = -1;
                string cls = "";
                int num = 0;
                foreach (var item in reSource)
                {
                    sum += item.SoLuong.GetValueOrDefault();
                    if (index == -1 || (index != -1 && cls != item.TenLop))
                    {
                        DataRow row = tbl.NewRow();
                        cls = item.TenLop;
                        num = item.SoLuong.GetValueOrDefault();
                        index += 1;
                        row["STT"] = index+1;
                        row["Lớp"] = item.TenLop;
                        row["Sĩ số"] = num;
                        foreach (var item2 in dtb.XEPLOAIs)
                        {
                            row[item2.TenXepLoai] = 0;
                        }
                        var TenXepLoai = from obj in dtb.XEPLOAIs
                                         where obj.MaXepLoai == item.MaXepLoai
                                         select obj.TenXepLoai;
                        row[TenXepLoai.FirstOrDefault().ToString()] = item.SoLuong;
                        tbl.Rows.Add(row);
                    }
                    else
                    {
                        var TenXepLoai = from obj in dtb.XEPLOAIs
                                         where obj.MaXepLoai == item.MaXepLoai
                                         select obj.TenXepLoai;
                        
                        tbl.Rows[index][TenXepLoai.FirstOrDefault().ToString()] = item.SoLuong;
                        num += item.SoLuong.GetValueOrDefault();
                        tbl.Rows[index]["Sĩ số"] = num;
                    }
                }
                DataTable ratio_Source = new DataTable();
                ratio_Source.Columns.Add("Xếp loại", typeof(string));
                ratio_Source.Columns.Add("Số lượng", typeof(int));
                ratio_Source.Columns.Add("Tỉ lệ (%)", typeof(float));
                foreach (var item in dtb.XEPLOAIs.OrderByDescending(r => r.DiemToiThieu))
                {
                    DataRow row_ratio = ratio_Source.NewRow();
                    row_ratio["Xếp loại"] = item.TenXepLoai;
                    int count = Convert.ToInt32(tbl.Compute($"SUM([{item.TenXepLoai}])", string.Empty));
                    row_ratio["Số lượng"] = count;
                    row_ratio["Tỉ lệ (%)"] = Math.Round((float)(100 * count / sum), 2);
                    ratio_Source.Rows.Add(row_ratio);
                }
                
                var TenMonHoc = from obj in dtb.MONHOCs
                                where obj.MaMonHoc == ComboBoxSubjects.SelectedValue
                                select obj.TenMonHoc;
                var NamHoc = from obj in dtb.NAMHOCs
                                where obj.MaNamHoc == ComboBoxYears.SelectedValue
                                select obj.NamHoc1;
                
              
                LabelNameReportGridview.Text = $"BẢNG THỐNG KÊ MÔN {TenMonHoc.FirstOrDefault().ToString().ToUpper()} HỌC KỲ {ComboBoxSemesters.SelectedValue.ToString()} NĂM {NamHoc.FirstOrDefault().ToString().ToUpper()}";
                LabelNameReportGridview.Show();

                LabelNameRatio.Show();

                dataGridViewRatio.DataSource = ratio_Source;
                dataGridViewRatio.Show();


                ChartRatio.DataSource = ratio_Source;
                ChartRatio.Series[0].XValueMember = "Xếp loại";
                ChartRatio.Series[0].YValueMembers = "Tỉ lệ (%)";
                ChartRatio.Series[0].IsValueShownAsLabel = true;
                ChartRatio.Show();

                dataGridViewReport.DataSource = tbl;
                dataGridViewReport.Show();
            }
            
        }



        private void ButtonReport2_Click(object sender, EventArgs e)
        {
            dataEntities dtb = new dataEntities();
            DataTable tbl = new DataTable();

            var Source = dtb.TongKetMonNamHoc(ComboBoxSubjects2.SelectedValue.ToString(), ComboBoxYears2.SelectedValue.ToString());
            var reSource = Source.ToList();

            bool check = false;
            var HK = dtb.HOCKies.Count();
            int check_num = 0;
            string old_id = "";
            string old_cls = "";
            IDictionary<string,int> check_dir = new Dictionary<string,int>();
            foreach(var item in reSource)
            {
                if (old_cls == ""|| old_cls!=item.TenLop )
                {
                    old_cls = item.TenLop;
                    check_dir[item.TenLop] = 0;
                }
                if (old_id == "" || old_id!=item.MaHocSinh)
                {
                    check_num = 1;
                    old_id = item.MaHocSinh;
                }
                else
                {
                    check_num += 1;
                    if (check_num == HK)
                    {
                        check = true;
                        check_dir[item.TenLop] += 1;
                    }    
                }
            }
            if (!check)
            {
                MessageBox.Show("Không có dữ liệu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                tbl.Columns.Add("STT", typeof(string));
                tbl.Columns.Add("Lớp", typeof(string));
                tbl.Columns.Add("Sĩ số", typeof(int));
                foreach (var item in dtb.XEPLOAIs.OrderByDescending(r=>r.DiemToiThieu))
                {
                    tbl.Columns.Add(item.TenXepLoai, typeof(int));
                }
                int sum = 0;
                old_cls = "";
                int num_cls = 0;
                old_id = "";
                check_num = 0;
                double score = 0;
                int index = -1;
                double sum_TS =(double) dtb.HOCKies.Sum(r => r.TrongSo);
                foreach(var item in reSource)
                {
                    if (check_dir[item.TenLop] != 0)
                    {
                        if (old_cls == "" || old_cls != item.TenLop)
                        {
                            num_cls = 0;
                            old_cls = item.TenLop;
                            DataRow row = tbl.NewRow();
                            index += 1;
                            row["STT"] = index + 1;
                            row["Lớp"] = item.TenLop;
                            row["Sĩ số"] = 0;
                            foreach (var item2 in dtb.XEPLOAIs)
                            {
                                row[item2.TenXepLoai] = 0;
                            }
                            tbl.Rows.Add(row);
                        }
                        if (old_id == "" || old_id != item.MaHocSinh)
                        {
                            check_num = 1;
                            old_id = item.MaHocSinh;
                            score = 0;
                        }
                        else 
                        {
                            check_num += 1;
                        }
                        var TS = from obj in dtb.HOCKies
                                 where obj.MaHocKy == item.HocKy
                                 select obj.TrongSo;
                        score += (double)item.DiemTB * (double)TS.FirstOrDefault();
                        
                        if (check_num == HK)
                        {
                            sum += 1;
                            num_cls += 1;
                            tbl.Rows[index]["Sĩ số"] = num_cls;

                            score = Math.Round(score / sum_TS, 2);
                            foreach (var item2 in dtb.XEPLOAIs.OrderByDescending(r => r.DiemToiThieu))
                            {
                                if (score >= item2.DiemToiThieu)
                                {
                                    var temp = tbl.Rows[index][item2.TenXepLoai];
                                    temp = (int)temp+1;
                                    tbl.Rows[index][item2.TenXepLoai] = temp;
                                    break;
                                }
                            }
                        }
                    }
                }
                DataTable ratio_Source = new DataTable();
                ratio_Source.Columns.Add("Xếp loại", typeof(string));
                ratio_Source.Columns.Add("Số lượng", typeof(int));
                ratio_Source.Columns.Add("Tỉ lệ (%)", typeof(float));
                foreach (var item in dtb.XEPLOAIs.OrderByDescending(r => r.DiemToiThieu))
                {
                    DataRow row_ratio = ratio_Source.NewRow();
                    row_ratio["Xếp loại"] = item.TenXepLoai;
                    int count = Convert.ToInt32(tbl.Compute($"SUM([{item.TenXepLoai}])", string.Empty));
                    row_ratio["Số lượng"] = count;
                    row_ratio["Tỉ lệ (%)"] = Math.Round((float)(100 * count / sum), 2);
                    ratio_Source.Rows.Add(row_ratio);
                }

                var TenMonHoc = from obj in dtb.MONHOCs
                                where obj.MaMonHoc == ComboBoxSubjects2.SelectedValue
                                select obj.TenMonHoc;
                var NamHoc = from obj in dtb.NAMHOCs
                             where obj.MaNamHoc == ComboBoxYears2.SelectedValue
                             select obj.NamHoc1;


                LabelNameReportGridview2.Text = $"BẢNG THỐNG KÊ MÔN {TenMonHoc.FirstOrDefault().ToString().ToUpper()} NĂM {NamHoc.FirstOrDefault().ToString().ToUpper()}";
                LabelNameReportGridview2.Show();

                LabelNameRatio2.Show();


                dataGridViewRatio2.DataSource = ratio_Source;
                dataGridViewRatio2.Show();


                ChartRatio2.DataSource = ratio_Source;
                ChartRatio2.Series[0].XValueMember = "Xếp loại";
                ChartRatio2.Series[0].YValueMembers = "Tỉ lệ (%)";
                ChartRatio2.Series[0].IsValueShownAsLabel = true;
                ChartRatio2.Show();

                dataGridViewReport2.DataSource = tbl;
                dataGridViewReport2.Show();
                
            }
        }

        private void buttonReport3_Click(object sender, EventArgs e)
        {
            dataEntities dtb = new dataEntities();
            DataTable tbl = new DataTable();
            var Source = dtb.TongKetHocKy(ComboBoxSemesters2.SelectedValue.ToString(), ComboBoxYears3.SelectedValue.ToString());
            var reSource = Source.ToList();

            bool check = false;
            foreach (var item in reSource)
            {
                if (item.SoLuong == dtb.MONHOCs.Count()/3)
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
                tbl.Columns.Add("STT", typeof(string));
                tbl.Columns.Add("Lớp", typeof(string));
                tbl.Columns.Add("Sĩ số", typeof(int));
                foreach (var item in dtb.XEPLOAIs.OrderByDescending(r => r.DiemToiThieu))
                {
                    tbl.Columns.Add(item.TenXepLoai, typeof(int));
                }
                var index = -1;
                string cls = "";
                int sum = 0;
                foreach (var item in reSource)
                {
                    if (item.SoLuong == dtb.MONHOCs.Count()/3)
                    {
                        sum += 1;
                        if (cls == "" || cls != item.TenLop)
                        {
                            DataRow row = tbl.NewRow();
                            cls = item.TenLop;
                            index += 1;
                            row["STT"] = index + 1;
                            row["Lớp"] = item.TenLop;
                            row["Sĩ số"] = 1;
                            foreach (var item2 in dtb.XEPLOAIs)
                            {
                                row[item2.TenXepLoai] = 0;
                            }
                            tbl.Rows.Add(row);
                        }
                        double score = Math.Round((double)(item.DiemTB/item.SoLuong), 2);
                        foreach (var item2 in dtb.XEPLOAIs.OrderByDescending(r => r.DiemToiThieu))
                        {
                            if (score >= item2.DiemToiThieu )
                            {
                                if (item.DiemKC > item2.DiemKhongChe)
                                {
                                    var temp = tbl.Rows[index][item2.TenXepLoai];
                                    temp = (int)temp + 1;
                                    tbl.Rows[index][item2.TenXepLoai] = temp;
                                }
                                else
                                {
                                    bool find = false;
                                    var item3 = dtb.XEPLOAIs.FirstOrDefault();
                                    foreach (var item4 in dtb.XEPLOAIs.OrderByDescending(r => r.DiemToiThieu))
                                    {
                                        if (score >= item4.DiemToiThieu)
                                        {
                                            if (find)
                                            {
                                                item3 = item4;
                                                break;
                                            }
                                            if (item.DiemKC <= item4.DiemKhongChe)
                                            { find = true; }
                                        }
                                    }
                                    var temp = tbl.Rows[index][item3.TenXepLoai];
                                    temp = (int)temp + 1;
                                    tbl.Rows[index][item3.TenXepLoai] = temp;
                                }
                                break;
                            }
                        }
                    }
                }

                DataTable ratio_Source = new DataTable();
                ratio_Source.Columns.Add("Xếp loại", typeof(string));
                ratio_Source.Columns.Add("Số lượng", typeof(int));
                ratio_Source.Columns.Add("Tỉ lệ (%)", typeof(float));
                foreach (var item in dtb.XEPLOAIs.OrderByDescending(r => r.DiemToiThieu))
                {
                    DataRow row_ratio = ratio_Source.NewRow();
                    row_ratio["Xếp loại"] = item.TenXepLoai;
                    int count = Convert.ToInt32(tbl.Compute($"SUM([{item.TenXepLoai}])", string.Empty));
                    row_ratio["Số lượng"] = count;
                    row_ratio["Tỉ lệ (%)"] = Math.Round((float)(100 * count / sum), 2);
                    ratio_Source.Rows.Add(row_ratio);
                }

                
                var NamHoc = from obj in dtb.NAMHOCs
                             where obj.MaNamHoc == ComboBoxYears3.SelectedValue
                             select obj.NamHoc1;


                LabelNameReportGridview3.Text = $"BẢNG THỐNG KÊ HỌC KỲ {ComboBoxSemesters2.SelectedValue.ToString()} NĂM {NamHoc.FirstOrDefault().ToString().ToUpper()}";
                LabelNameReportGridview3.Show();

                LabelNameRatio3.Show();


                dataGridViewRatio3.DataSource = ratio_Source;
                dataGridViewRatio3.Show();


                ChartRatio3.DataSource = ratio_Source;
                ChartRatio3.Series[0].XValueMember = "Xếp loại";
                ChartRatio3.Series[0].YValueMembers = "Tỉ lệ (%)";
                ChartRatio3.Series[0].IsValueShownAsLabel = true;
                ChartRatio3.Show();

                dataGridViewReport3.DataSource = tbl;
                dataGridViewReport3.Show();
            }

        }

        private void buttonReport4_Click(object sender, EventArgs e)
        {
            dataEntities dtb = new dataEntities();
            /*var Source = from scr in dtb.DIEMs
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
            }*/
        }

    }
}
