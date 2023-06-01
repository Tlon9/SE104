using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace QuanLyHocSinh
{
    public partial class BaoCaoTongKet : Form
    {
        public BaoCaoTongKet()
        {
            InitializeComponent();
            dataEntities data = new dataEntities();
            //Get source
            var ComboBoxSubjectsSource = from obj in data.MONHOCs
                                      select obj;

            var ComboBoxYearsSource = from obj in data.NAMHOCs
                                      select obj;

            var ComboBoxSemestersSource = from obj in data.HOCKies
                                          select obj;

            guna2ComboBoxSubjects1.DataSource = ComboBoxSubjectsSource.ToList();
            guna2ComboBoxSubjects1.DisplayMember = "TenMonHoc";
            guna2ComboBoxSubjects1.ValueMember = "MaMonHoc";

            guna2ComboBoxSubjects2.DataSource = ComboBoxSubjectsSource.ToList();
            guna2ComboBoxSubjects2.DisplayMember = "TenMonHoc";
            guna2ComboBoxSubjects2.ValueMember = "MaMonHoc";

            guna2ComboBoxYears1.DataSource = ComboBoxYearsSource.ToList();
            guna2ComboBoxYears1.DisplayMember = "NamHoc1";
            guna2ComboBoxYears1.ValueMember = "MaNamHoc";

            guna2ComboBoxYears2.DataSource = ComboBoxYearsSource.ToList();
            guna2ComboBoxYears2.DisplayMember = "NamHoc1";
            guna2ComboBoxYears2.ValueMember = "MaNamHoc";

            guna2ComboBoxYears3.DataSource = ComboBoxYearsSource.ToList();
            guna2ComboBoxYears3.DisplayMember = "NamHoc1";
            guna2ComboBoxYears3.ValueMember = "MaNamHoc";

            guna2ComboBoxYears4.DataSource = ComboBoxYearsSource.ToList();
            guna2ComboBoxYears4.DisplayMember = "NamHoc1";
            guna2ComboBoxYears4.ValueMember = "MaNamHoc";

            guna2ComboBoxSemesters1.DataSource = ComboBoxSemestersSource.ToList();
            guna2ComboBoxSemesters1.DisplayMember = "HocKy1";
            guna2ComboBoxSemesters1.ValueMember = "MaHocKy";

            guna2ComboBoxSemesters2.DataSource = ComboBoxSemestersSource.ToList();
            guna2ComboBoxSemesters2.DisplayMember = "HocKy1";
            guna2ComboBoxSemesters2.ValueMember = "MaHocKy";

        }


        private void guna2ImageButtonSearch1_Click(object sender, EventArgs e)
        {
            dataEntities dtb = new dataEntities();
            DataTable tbl = new DataTable();
            

            var Source = dtb.TongKetMonHocKy(guna2ComboBoxSubjects1.SelectedValue.ToString(), guna2ComboBoxSemesters1.SelectedValue.ToString(), guna2ComboBoxYears1.SelectedValue.ToString());
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
                int i = 3;
                foreach (var item in dtb.XepLoai_NamApDung(guna2ComboBoxYears1.SelectedValue.ToString()).OrderByDescending(r => r.DiemToiThieu))
                {
                    tbl.Columns.Add(item.TenXepLoai, typeof(int));
                    i += 1;


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
                        row["STT"] = index + 1;
                        row["Lớp"] = item.TenLop;
                        row["Sĩ số"] = num;
                        foreach (var item2 in dtb.XepLoai_NamApDung(guna2ComboBoxYears1.SelectedValue.ToString()))
                        {
                            row[item2.TenXepLoai] = "0";
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
                foreach (var item in dtb.XepLoai_NamApDung(guna2ComboBoxYears1.SelectedValue.ToString()).OrderByDescending(r => r.DiemToiThieu))
                {
                    DataRow row_ratio = ratio_Source.NewRow();
                    row_ratio["Xếp loại"] = item.TenXepLoai;
                    int count = Convert.ToInt32(tbl.Compute($"SUM([{item.TenXepLoai}])", string.Empty));
                    row_ratio["Số lượng"] = count;
                    double rat = Math.Round((float)(100 * count / sum), 2);
                    row_ratio["Tỉ lệ (%)"] = rat;
                    if (rat > 0)
                        ratio_Source.Rows.Add(row_ratio);
                }


                var TenMonHoc = from obj in dtb.MONHOCs
                                where obj.MaMonHoc == guna2ComboBoxSubjects1.SelectedValue
                                select obj.TenMonHoc;
                var NamHoc = from obj in dtb.NAMHOCs
                             where obj.MaNamHoc == guna2ComboBoxYears1.SelectedValue
                             select obj.NamHoc1;


                LabelNameReportGridview1.Text = $"BẢNG THỐNG KÊ MÔN {TenMonHoc.FirstOrDefault().ToString().ToUpper()} HỌC KỲ {guna2ComboBoxSemesters1.SelectedValue.ToString()} NĂM {NamHoc.FirstOrDefault().ToString().ToUpper()}";
                LabelNameReportGridview1.Show();

                LabelNameRatio1.Show();

                guna2DataGridViewRatio1.DataSource = ratio_Source;
                guna2DataGridViewRatio1.Show();


                ChartRatio.DataSource = ratio_Source;
                ChartRatio.Series[0].XValueMember = "Xếp loại";
                ChartRatio.Series[0].YValueMembers = "Tỉ lệ (%)";
                ChartRatio.Series[0].IsValueShownAsLabel = true;
                ChartRatio.Show();

                guna2DataGridViewReport1.DataSource = tbl;
                guna2DataGridViewReport1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                guna2DataGridViewReport1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                guna2DataGridViewReport1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;  
                guna2DataGridViewReport1.Show();
                guna2ImageButtonPrint1.Show();
            }
        }

        private void guna2ImageButtonSearch2_Click(object sender, EventArgs e)
        {
            dataEntities dtb = new dataEntities();
            DataTable tbl = new DataTable();

            var Source = dtb.TongKetMonNamHoc(guna2ComboBoxSubjects2.SelectedValue.ToString(), guna2ComboBoxYears2.SelectedValue.ToString());
            var reSource = Source.ToList();

            bool check = false;
            var HK = dtb.HOCKies.Count();
            int check_num = 0;
            string old_id = "";
            string old_cls = "";
            IDictionary<string, int> check_dir = new Dictionary<string, int>();
            foreach (var item in reSource)
            {
                if (old_cls == "" || old_cls != item.TenLop)
                {
                    old_cls = item.TenLop;
                    check_dir[item.TenLop] = 0;
                }
                if (old_id == "" || old_id != item.MaHocSinh)
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
                foreach (var item in dtb.XepLoai_NamApDung(guna2ComboBoxYears2.SelectedValue.ToString()).OrderByDescending(r => r.DiemToiThieu))
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
                double sum_TS = (double)dtb.HOCKies.Sum(r => r.TrongSo);
                foreach (var item in reSource)
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
                            foreach (var item2 in dtb.XepLoai_NamApDung(guna2ComboBoxYears2.SelectedValue.ToString()))
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
                            foreach (var item2 in dtb.XepLoai_NamApDung(guna2ComboBoxYears2.SelectedValue.ToString()).OrderByDescending(r => r.DiemToiThieu))
                            {
                                if (score >= item2.DiemToiThieu)
                                {
                                    var temp = tbl.Rows[index][item2.TenXepLoai];
                                    temp = (int)temp + 1;
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
                foreach (var item in dtb.XepLoai_NamApDung(guna2ComboBoxYears2.SelectedValue.ToString()).OrderByDescending(r => r.DiemToiThieu))
                {
                    DataRow row_ratio = ratio_Source.NewRow();
                    row_ratio["Xếp loại"] = item.TenXepLoai;
                    int count = Convert.ToInt32(tbl.Compute($"SUM([{item.TenXepLoai}])", string.Empty));
                    row_ratio["Số lượng"] = count;
                    double rat = Math.Round((float)(100 * count / sum), 2);
                    row_ratio["Tỉ lệ (%)"] = rat;
                    if (rat > 0)
                        ratio_Source.Rows.Add(row_ratio);
                }

                var TenMonHoc = from obj in dtb.MONHOCs
                                where obj.MaMonHoc == guna2ComboBoxSubjects2.SelectedValue
                                select obj.TenMonHoc;
                var NamHoc = from obj in dtb.NAMHOCs
                             where obj.MaNamHoc == guna2ComboBoxYears2.SelectedValue
                             select obj.NamHoc1;


                LabelNameReportGridview2.Text = $"BẢNG THỐNG KÊ MÔN {TenMonHoc.FirstOrDefault().ToString().ToUpper()} NĂM {NamHoc.FirstOrDefault().ToString().ToUpper()}";
                LabelNameReportGridview2.Show();

                LabelNameRatio2.Show();


                guna2DataGridViewRatio2.DataSource = ratio_Source;
                guna2DataGridViewRatio2.Show();


                ChartRatio2.DataSource = ratio_Source;
                ChartRatio2.Series[0].XValueMember = "Xếp loại";
                ChartRatio2.Series[0].YValueMembers = "Tỉ lệ (%)";
                ChartRatio2.Series[0].IsValueShownAsLabel = true;
                ChartRatio2.Show();

                guna2DataGridViewReport2.DataSource = tbl;
                guna2DataGridViewReport2.Show();

                guna2DataGridViewReport2.DataSource = tbl;
                guna2DataGridViewReport2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                guna2DataGridViewReport2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                guna2DataGridViewReport2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                guna2DataGridViewReport2.Show();
                guna2ImageButtonPrint2.Show();

            }
        }

        private void guna2ImageButtonSearch3_Click(object sender, EventArgs e)
        {
            dataEntities dtb = new dataEntities();
            DataTable tbl = new DataTable();
            var Source = dtb.TongKetHocKy(guna2ComboBoxSemesters2.SelectedValue.ToString(), guna2ComboBoxYears3.SelectedValue.ToString());
            var reSource = Source.ToList();

            bool check = false;
            foreach (var item in reSource)
            {
                string str = item.TenLop[1].ToString();
                if (item.SoLuong == dtb.MONHOCs.Where(r => r.MaMonHoc.Contains(str)).Count())
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
                foreach (var item in dtb.XepLoai_NamApDung(guna2ComboBoxYears3.SelectedValue.ToString()).OrderByDescending(r => r.DiemToiThieu))
                {
                    tbl.Columns.Add(item.TenXepLoai, typeof(int));
                }
                var index = -1;
                string cls = "";
                int sum = 0;
                foreach (var item in reSource)
                {
                    if (item.SoLuong == dtb.MONHOCs.Count() / 3)
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
                            foreach (var item2 in dtb.XepLoai_NamApDung(guna2ComboBoxYears3.SelectedValue.ToString()))
                            {
                                row[item2.TenXepLoai] = 0;
                            }
                            tbl.Rows.Add(row);
                        }
                        double score = Math.Round((double)(item.DiemTB / item.SoLuong), 2);
                        foreach (var item2 in dtb.XepLoai_NamApDung(guna2ComboBoxYears3.SelectedValue.ToString()).OrderByDescending(r => r.DiemToiThieu))
                        {
                            if (score >= item2.DiemToiThieu)
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
                                    var item3 = dtb.XepLoai_NamApDung(guna2ComboBoxYears3.SelectedValue.ToString()).FirstOrDefault();
                                    foreach (var item4 in dtb.XepLoai_NamApDung(guna2ComboBoxYears3.SelectedValue.ToString()).OrderByDescending(r => r.DiemToiThieu))
                                    {
                                        if (score >= item4.DiemToiThieu)
                                        {
                                            if (find)
                                            {
                                                item3 = item4;
                                                break;
                                            }
                                            find = true;
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
                foreach (var item in dtb.XepLoai_NamApDung(guna2ComboBoxYears3.SelectedValue.ToString()).OrderByDescending(r => r.DiemToiThieu))
                {
                    DataRow row_ratio = ratio_Source.NewRow();
                    row_ratio["Xếp loại"] = item.TenXepLoai;
                    int count = Convert.ToInt32(tbl.Compute($"SUM([{item.TenXepLoai}])", string.Empty));
                    row_ratio["Số lượng"] = count;
                    double rat = Math.Round((float)(100 * count / sum), 2);
                    row_ratio["Tỉ lệ (%)"] = rat;
                    if (rat > 0)
                        ratio_Source.Rows.Add(row_ratio);
                }


                var NamHoc = from obj in dtb.NAMHOCs
                             where obj.MaNamHoc == guna2ComboBoxYears3.SelectedValue
                             select obj.NamHoc1;


                LabelNameReportGridview3.Text = $"BẢNG THỐNG KÊ HỌC KỲ {guna2ComboBoxSemesters2.SelectedValue.ToString()} NĂM {NamHoc.FirstOrDefault().ToString().ToUpper()}";
                LabelNameReportGridview3.Show();

                LabelNameRatio3.Show();


                guna2DataGridViewRatio3.DataSource = ratio_Source;
                guna2DataGridViewRatio3.Show();


                ChartRatio3.DataSource = ratio_Source;
                ChartRatio3.Series[0].XValueMember = "Xếp loại";
                ChartRatio3.Series[0].YValueMembers = "Tỉ lệ (%)";
                ChartRatio3.Series[0].IsValueShownAsLabel = true;
                ChartRatio3.Show();

                guna2DataGridViewReport3.DataSource = tbl;
                guna2DataGridViewReport3.Show();

                guna2DataGridViewReport3.DataSource = tbl;
                guna2DataGridViewReport3.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                guna2DataGridViewReport3.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                guna2DataGridViewReport3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                guna2DataGridViewReport3.Show();
                guna2ImageButtonPrint3.Show();
            }
        }

        bool CheckDiemKC(string MaHS, string NamHoc, double DiemKC)
        {
            dataEntities dtb = new dataEntities();
            var check_source = dtb.TongKetMon_HocSinh(NamHoc, MaHS).ToList();
            var HK = dtb.HOCKies.Count();
            string old_sub = "";
            int check_num = 0;
            double score = 0;
            double sum_TS = (double)dtb.HOCKies.Sum(r => r.TrongSo);
            foreach (var item in check_source)
            {
                if (old_sub == "" || old_sub != item.MaMonHoc)
                {
                    check_num = 1;
                    old_sub = item.MaMonHoc;
                    score = 0;
                }
                else
                {
                    check_num += 1;
                }
                var TS = from obj in dtb.HOCKies
                         where obj.MaHocKy == item.MaHocKy
                         select obj.TrongSo;
                score += (double)item.DiemTB * (double)TS.FirstOrDefault();

                if (check_num == HK)
                {
                    score = Math.Round(score / sum_TS, 2);
                    if (score < DiemKC)
                        return false;
                }
            }
            return true;
        }
        private void guna2ImageButtonSearch4_Click(object sender, EventArgs e)
        {
            dataEntities dtb = new dataEntities();
            DataTable tbl = new DataTable();
            var Source = dtb.TongKetNamHoc(guna2ComboBoxYears4.SelectedValue.ToString());
            var reSource = Source.ToList();

            bool check = false;
            bool next = false;
            var HK = dtb.HOCKies.Count();
            int check_num = 0;
            string old_id = "";
            string old_cls = "";
            IDictionary<string, int> check_dir = new Dictionary<string, int>();
            foreach (var item in reSource)
            {
                if (old_cls == "" || old_cls != item.TenLop)
                {
                    old_cls = item.TenLop;
                    check_dir[item.TenLop] = 0;
                }
                if (old_id == "" || old_id != item.MaHocSinh)
                {

                    old_id = item.MaHocSinh;
                    next = false;
                    string str = item.TenLop[1].ToString();
                    if (item.SoLuongMon < dtb.MONHOCs.Where(r => r.MaMonHoc.Contains(str)).Count())
                    {
                        next = true;
                        continue;
                    }
                    check_num = 1;
                }
                else
                {
                    if (next) continue;
                    string str = item.TenLop[1].ToString();
                    if (item.SoLuongMon < dtb.MONHOCs.Where(r => r.MaMonHoc.Contains(str)).Count())
                    {
                        next = true;
                        continue;
                    }
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
                foreach (var item in dtb.XepLoai_NamApDung(guna2ComboBoxYears4.SelectedValue.ToString()).OrderByDescending(r => r.DiemToiThieu))
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
                double sum_TS = (double)dtb.HOCKies.Sum(r => r.TrongSo);
                foreach (var item in reSource)
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
                            foreach (var item2 in dtb.XepLoai_NamApDung(guna2ComboBoxYears4.SelectedValue.ToString()))
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
                                 where obj.MaHocKy == item.MaHocKy
                                 select obj.TrongSo;
                        score += (double)item.DiemTB * (double)TS.FirstOrDefault();

                        if (check_num == HK)
                        {
                            sum += 1;
                            num_cls += 1;
                            tbl.Rows[index]["Sĩ số"] = num_cls;

                            score = Math.Round(score / sum_TS, 2);
                            foreach (var item2 in dtb.XepLoai_NamApDung(guna2ComboBoxYears4.SelectedValue.ToString()).OrderByDescending(r => r.DiemToiThieu))
                            {
                                if (score >= item2.DiemToiThieu)
                                {
                                    if (CheckDiemKC(item.MaHocSinh, guna2ComboBoxYears4.SelectedValue.ToString(), (double)item2.DiemKhongChe))
                                    {
                                        var temp = tbl.Rows[index][item2.TenXepLoai];
                                        temp = (int)temp + 1;
                                        tbl.Rows[index][item2.TenXepLoai] = temp;
                                    }
                                    else
                                    {
                                        bool find = false;
                                        var item3 = dtb.XepLoai_NamApDung(guna2ComboBoxYears4.SelectedValue.ToString()).FirstOrDefault();
                                        foreach (var item4 in dtb.XepLoai_NamApDung(guna2ComboBoxYears4.SelectedValue.ToString()).OrderByDescending(r => r.DiemToiThieu))
                                        {
                                            if (score >= item4.DiemToiThieu)
                                            {
                                                if (find)
                                                {
                                                    item3 = item4;
                                                    break;
                                                }
                                                find = true;
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
                }
                DataTable ratio_Source = new DataTable();
                ratio_Source.Columns.Add("Xếp loại", typeof(string));
                ratio_Source.Columns.Add("Số lượng", typeof(int));
                ratio_Source.Columns.Add("Tỉ lệ (%)", typeof(float));
                foreach (var item in dtb.XepLoai_NamApDung(guna2ComboBoxYears4.SelectedValue.ToString()).OrderByDescending(r => r.DiemToiThieu))
                {
                    DataRow row_ratio = ratio_Source.NewRow();
                    row_ratio["Xếp loại"] = item.TenXepLoai;
                    int count = Convert.ToInt32(tbl.Compute($"SUM([{item.TenXepLoai}])", string.Empty));
                    row_ratio["Số lượng"] = count;
                    double rat = Math.Round((float)(100 * count / sum), 2);
                    row_ratio["Tỉ lệ (%)"] = rat;
                    if (rat > 0)
                        ratio_Source.Rows.Add(row_ratio);
                }


                var NamHoc = from obj in dtb.NAMHOCs
                             where obj.MaNamHoc == guna2ComboBoxYears4.SelectedValue
                             select obj.NamHoc1;


                LabelNameReportGridview4.Text = $"BẢNG THỐNG KÊ NĂM HỌC {NamHoc.FirstOrDefault().ToString()}";
                LabelNameReportGridview4.Show();

                LabelNameRatio4.Show();

                guna2DataGridViewRatio4.DataSource = ratio_Source;
                guna2DataGridViewRatio4.Show();


                ChartRatio4.DataSource = ratio_Source;
                ChartRatio4.Series[0].XValueMember = "Xếp loại";
                ChartRatio4.Series[0].YValueMembers = "Tỉ lệ (%)";
                ChartRatio4.Series[0].IsValueShownAsLabel = true;
                ChartRatio4.Show();

                guna2DataGridViewReport4.DataSource = tbl;
                guna2DataGridViewReport4.Show();

                guna2DataGridViewReport4.DataSource = tbl;
                guna2DataGridViewReport4.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                guna2DataGridViewReport4.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                guna2DataGridViewReport4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                guna2DataGridViewReport4.Show();
                guna2ImageButtonPrint4.Show();
            }
        }

        private void ExportToExcel(DataGridView dataGridView,DataGridView dataGridView2)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];
            for (int i = 1; i <= dataGridView.Columns.Count; i++)
            {
                worksheet.Cells[1, i] = dataGridView.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView.Columns.Count; j++)
                {
                    if (dataGridView.Rows[i].Cells[j].Value != null)
                        worksheet.Cells[i + 2, j + 1] = dataGridView.Rows[i].Cells[j].Value.ToString();
                }
            }
            workbook.Sheets.Add(After: workbook.Sheets[workbook.Sheets.Count]);
            Excel.Worksheet worksheet2 = (Excel.Worksheet)workbook.Sheets[2];
            for (int i = 1; i <= dataGridView2.Columns.Count; i++)
            {
                worksheet2.Cells[1, i] = dataGridView2.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView2.Columns.Count; j++)
                {
                    if (dataGridView2.Rows[i].Cells[j].Value != null)
                        worksheet2.Cells[i + 2, j + 1] = dataGridView2.Rows[i].Cells[j].Value.ToString();
                }
            }
            workbook.Close();
            excel.Quit();
        }
        private void guna2ImageButtonPrint1_Click(object sender, EventArgs e)
        {
            ExportToExcel(guna2DataGridViewReport1,guna2DataGridViewRatio1);
        }

        private void guna2ImageButtonPrint2_Click(object sender, EventArgs e)
        {
            ExportToExcel(guna2DataGridViewReport2, guna2DataGridViewRatio2);
        }

        private void guna2ImageButtonPrint3_Click(object sender, EventArgs e)
        {
            ExportToExcel(guna2DataGridViewReport3, guna2DataGridViewRatio3);
        }

        private void guna2ImageButtonPrint4_Click(object sender, EventArgs e)
        {
            ExportToExcel(guna2DataGridViewReport4, guna2DataGridViewRatio3);
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

        private void guna2ImageButtonMinimize1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2ImageButtonClose1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2ImageButtonHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            TrangCaNhan newform = new TrangCaNhan();
            this.Hide();
            newform.ShowDialog();
            this.Show();
        }
    }
}
