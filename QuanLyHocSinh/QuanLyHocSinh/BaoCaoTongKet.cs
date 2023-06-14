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

            var ComboBoxYearsSource = from obj in data.NAMHOCs
                                      orderby obj.MaNamHoc descending
                                      select obj;

            ComboBoxYears1.DataSource = ComboBoxYearsSource.ToList();
            ComboBoxYears1.DisplayMember = "NamHoc1";
            ComboBoxYears1.ValueMember = "MaNamHoc";

            ComboBoxYears2.DataSource = ComboBoxYearsSource.ToList();
            ComboBoxYears2.DisplayMember = "NamHoc1";
            ComboBoxYears2.ValueMember = "MaNamHoc";

            ComboBoxYears3.DataSource = ComboBoxYearsSource.ToList();
            ComboBoxYears3.DisplayMember = "NamHoc1";
            ComboBoxYears3.ValueMember = "MaNamHoc";

            ComboBoxYears4.DataSource = ComboBoxYearsSource.ToList();
            ComboBoxYears4.DisplayMember = "NamHoc1";
            ComboBoxYears4.ValueMember = "MaNamHoc";
        }


        private void guna2ImageButtonSearch1_Click(object sender, EventArgs e)
        {
            try
            {
                dataEntities dtb = new dataEntities();
                DataTable tbl = new DataTable();

                var cls_list = dtb.TongKetMonHocKy(ComboBoxSubjects1.SelectedValue.ToString(), ComboBoxSemesters1.SelectedValue.ToString(), ComboBoxYears1.SelectedValue.ToString()).Select(r => r.TenLop).Distinct().ToList();
                var sum = 0;


                if (cls_list.Count() == 0)
                {
                    MessageBox.Show("Không có dữ liệu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    tbl.Columns.Add("STT", typeof(string));
                    tbl.Columns.Add("Lớp", typeof(string));
                    tbl.Columns.Add("Sĩ số", typeof(int));
                    foreach (var item in dtb.XepLoai_NamApDung(ComboBoxYears1.SelectedValue.ToString()).OrderByDescending(r => r.DiemToiThieu))
                    {
                        if (item.MaXepLoai != "HSR")
                        {
                            tbl.Columns.Add(item.TenXepLoai, typeof(int));
                        }
                    }
                    var index = -1;
                    foreach (var item in cls_list)
                    {
                        int num = 0;
                        var cls = dtb.TongKetMonHocKy(ComboBoxSubjects1.SelectedValue.ToString(), ComboBoxSemesters1.SelectedValue.ToString(), ComboBoxYears1.SelectedValue.ToString()).Where(r => r.TenLop == item.ToString()).ToList();
                        DataRow row = tbl.NewRow();
                        index += 1;
                        row["STT"] = index + 1;
                        row["Lớp"] = item.ToString();
                        foreach (var item2 in dtb.XepLoai_NamApDung(ComboBoxYears1.SelectedValue.ToString()))
                        {
                            if (item2.MaXepLoai != "HSR")
                            {
                                row[item2.TenXepLoai] = "0";
                            }
                        }
                        foreach (var item2 in cls)
                        {
                            num += (int)item2.SoLuong;
                            sum += (int)item2.SoLuong;
                            var TenXepLoai = from obj in dtb.XepLoai_NamApDung(ComboBoxYears1.SelectedValue.ToString())
                                             where obj.MaXepLoai == item2.MaXepLoai
                                             select obj.TenXepLoai;
                            row[TenXepLoai.FirstOrDefault().ToString()] = item2.SoLuong;

                        }
                        row["Sĩ số"] = num;
                        tbl.Rows.Add(row);
                    }

                    DataTable ratio_Source = new DataTable();
                    ratio_Source.Columns.Add("Xếp loại", typeof(string));
                    ratio_Source.Columns.Add("Số lượng", typeof(int));
                    ratio_Source.Columns.Add("Tỉ lệ (%)", typeof(float));
                    foreach (var item in dtb.XepLoai_NamApDung(ComboBoxYears1.SelectedValue.ToString()).OrderByDescending(r => r.DiemToiThieu))
                    {
                        if (item.MaXepLoai != "HSR")
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
                    }


                    var TenMonHoc = from obj in dtb.MONHOCs
                                    where obj.MaMonHoc == ComboBoxSubjects1.SelectedValue
                                    select obj.TenMonHoc;
                    var NamHoc = from obj in dtb.NAMHOCs
                                 where obj.MaNamHoc == ComboBoxYears1.SelectedValue
                                 select obj.NamHoc1;


                    LabelNameReportGridview1.Text = $"BẢNG THỐNG KÊ MÔN {TenMonHoc.FirstOrDefault().ToString().ToUpper()} HỌC KỲ {ComboBoxSemesters1.SelectedValue.ToString()} NĂM {NamHoc.FirstOrDefault().ToString().ToUpper()}";
                    LabelNameReportGridview1.Show();

                    LabelNameRatio1.Show();

                    DataGridViewRatio1.DataSource = ratio_Source;
                    DataGridViewRatio1.Show();


                    ChartRatio1.DataSource = ratio_Source;
                    ChartRatio1.Series[0].XValueMember = "Xếp loại";
                    ChartRatio1.Series[0].YValueMembers = "Tỉ lệ (%)";
                    ChartRatio1.Series[0].IsValueShownAsLabel = true;
                    ChartRatio1.Show();

                    DataGridViewReport1.DataSource = tbl;
                    DataGridViewReport1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    DataGridViewReport1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    DataGridViewReport1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    DataGridViewReport1.Show();
                    ButtonPrint1.Show();
                }
            }
            catch
            {
                MessageBox.Show("Thao tác xảy ra lỗi, mời thực hiện lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2ImageButtonSearch2_Click(object sender, EventArgs e)
        {
            try
            {
                dataEntities dtb = new dataEntities();
                DataTable tbl = new DataTable();

                var cls_list = dtb.TongKetMonNamHoc(ComboBoxSubjects2.SelectedValue.ToString(), ComboBoxYears2.SelectedValue.ToString()).Select(r => r.TenLop).Distinct().ToList();


                if (cls_list.Count() == 0)
                {
                    MessageBox.Show("Không có dữ liệu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    tbl.Columns.Add("STT", typeof(string));
                    tbl.Columns.Add("Lớp", typeof(string));
                    tbl.Columns.Add("Sĩ số", typeof(int));
                    foreach (var item in dtb.XepLoai_NamApDung(ComboBoxYears2.SelectedValue.ToString()).OrderByDescending(r => r.DiemToiThieu))
                    {
                        if (item.MaXepLoai != "HSR")
                        {
                            tbl.Columns.Add(item.TenXepLoai, typeof(int));
                        }
                    }
                    int sum = 0;
                    int index = -1;
                    foreach (var item in cls_list)
                    {
                        DataRow row = tbl.NewRow();
                        index += 1;
                        row["STT"] = index + 1;
                        row["Lớp"] = item.ToString();
                        foreach (var item2 in dtb.XepLoai_NamApDung(ComboBoxYears2.SelectedValue.ToString()))
                        {
                            if (item2.MaXepLoai != "HSR")
                            {
                                row[item2.TenXepLoai] = 0;
                            }
                        }
                        var std_list = dtb.TongKetMonNamHoc(ComboBoxSubjects2.SelectedValue.ToString(), ComboBoxYears2.SelectedValue.ToString()).Where(r => r.TenLop == item.ToString()).Select(r => r.MaHocSinh).Distinct().ToList();
                        sum += std_list.Count();
                        row["Sĩ số"] = std_list.Count();
                        tbl.Rows.Add(row);
                        foreach (var item2 in std_list)
                        {
                            var sub = dtb.TongKetMonNamHoc(ComboBoxSubjects2.SelectedValue.ToString(), ComboBoxYears2.SelectedValue.ToString()).Where(r => r.MaHocSinh == item2.ToString()).ToList();
                            double score = 0;
                            double sum_TS = 0;
                            foreach (var item3 in sub)
                            {
                                var TS = from obj in dtb.HocKy_NamApDung(ComboBoxYears2.SelectedValue.ToString())
                                         where obj.MaHocKy == item3.HocKy
                                         select obj.TrongSo;
                                double ts_change = (double)TS.FirstOrDefault();
                                sum_TS += ts_change;
                                score += (double)item3.DiemTB * ts_change;
                            }
                            score = Math.Round(score / sum_TS, 2);
                            foreach (var item3 in dtb.XepLoai_NamApDung(ComboBoxYears2.SelectedValue.ToString()).OrderByDescending(r => r.DiemToiThieu))
                            {
                                    if (score >= item3.DiemToiThieu)
                                    {
                                        var temp = tbl.Rows[index][item3.TenXepLoai];
                                        temp = (int)temp + 1;
                                        tbl.Rows[index][item3.TenXepLoai] = temp;
                                        break;
                                    }
                            }
                        }
                    }
                    DataTable ratio_Source = new DataTable();
                    ratio_Source.Columns.Add("Xếp loại", typeof(string));
                    ratio_Source.Columns.Add("Số lượng", typeof(int));
                    ratio_Source.Columns.Add("Tỉ lệ (%)", typeof(float));
                    foreach (var item in dtb.XepLoai_NamApDung(ComboBoxYears2.SelectedValue.ToString()).OrderByDescending(r => r.DiemToiThieu))
                    {
                        if (item.MaXepLoai != "HSR")
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


                    DataGridViewRatio2.DataSource = ratio_Source;
                    DataGridViewRatio2.Show();


                    ChartRatio2.DataSource = ratio_Source;
                    ChartRatio2.Series[0].XValueMember = "Xếp loại";
                    ChartRatio2.Series[0].YValueMembers = "Tỉ lệ (%)";
                    ChartRatio2.Series[0].IsValueShownAsLabel = true;
                    ChartRatio2.Show();

                    DataGridViewReport2.DataSource = tbl;
                    DataGridViewReport2.Show();

                    DataGridViewReport2.DataSource = tbl;
                    DataGridViewReport2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    DataGridViewReport2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    DataGridViewReport2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    DataGridViewReport2.Show();
                    ButtonPrint2.Show();

                }
            }
            catch
            {
                MessageBox.Show("Thao tác xảy ra lỗi, mời thực hiện lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2ImageButtonSearch3_Click(object sender, EventArgs e)
        {
            try
            {
                dataEntities dtb = new dataEntities();
                DataTable tbl = new DataTable();
                var cls_list = dtb.TongKetHocKy(ComboBoxSemesters2.SelectedValue.ToString(), ComboBoxYears3.SelectedValue.ToString()).Select(r => r.TenLop).Distinct().ToList();

                if (cls_list.Count() == 0)
                {
                    MessageBox.Show("Không có dữ liệu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    tbl.Columns.Add("STT", typeof(string));
                    tbl.Columns.Add("Lớp", typeof(string));
                    tbl.Columns.Add("Sĩ số", typeof(int));
                    foreach (var item in dtb.XepLoai_NamApDung(ComboBoxYears3.SelectedValue.ToString()).OrderByDescending(r => r.DiemToiThieu))
                    {
                        if (item.MaXepLoai != "HSR")
                        {
                            tbl.Columns.Add(item.TenXepLoai, typeof(int));
                        }
                    }
                    var index = -1;
                    int sum = 0;
                    foreach (var item in cls_list)
                    {
                        DataRow row = tbl.NewRow();
                        index += 1;
                        row["STT"] = index + 1;
                        row["Lớp"] = item.ToString();
                        foreach (var item2 in dtb.XepLoai_NamApDung(ComboBoxYears3.SelectedValue.ToString()))
                        {
                            if (item2.MaXepLoai != "HSR")
                            {
                                row[item2.TenXepLoai] = 0;
                            }
                        }
                        var std_list = dtb.TongKetHocKy(ComboBoxSemesters2.SelectedValue.ToString(), ComboBoxYears3.SelectedValue.ToString()).Where(r => r.TenLop == item.ToString()).Select(r => r.MaHocSinh).ToList();
                        sum += std_list.Count();
                        row["Sĩ số"] = std_list.Count();
                        tbl.Rows.Add(row);
                        foreach (var item2 in std_list)
                        {
                            var std = dtb.TongKetHocKy(ComboBoxSemesters2.SelectedValue.ToString(), ComboBoxYears3.SelectedValue.ToString()).Where(r => r.MaHocSinh == item2.ToString()).FirstOrDefault();
                            double score = Math.Round((double)(std.DiemTB / std.SoLuong), 2);
                            foreach (var item3 in dtb.XepLoai_NamApDung(ComboBoxYears3.SelectedValue.ToString()).OrderByDescending(r => r.DiemToiThieu))
                            {
                                    if (score >= item3.DiemToiThieu)
                                    {
                                        if (std.DiemKC >= item3.DiemKhongChe)
                                        {
                                            var temp = tbl.Rows[index][item3.TenXepLoai];
                                            temp = (int)temp + 1;
                                            tbl.Rows[index][item3.TenXepLoai] = temp;
                                        }
                                        else
                                        {
                                            bool find = false;
                                            var item4 = dtb.XepLoai_NamApDung(ComboBoxYears3.SelectedValue.ToString()).FirstOrDefault();
                                            foreach (var item5 in dtb.XepLoai_NamApDung(ComboBoxYears3.SelectedValue.ToString()).OrderByDescending(r => r.DiemToiThieu))
                                            {
                                                if (score >= item5.DiemToiThieu)
                                                {
                                                    if (find)
                                                    {
                                                        item4 = item5;
                                                        break;
                                                    }
                                                    find = true;
                                                }
                                            }
                                            var temp = tbl.Rows[index][item4.TenXepLoai];
                                            temp = (int)temp + 1;
                                            tbl.Rows[index][item4.TenXepLoai] = temp;
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
                    foreach (var item in dtb.XepLoai_NamApDung(ComboBoxYears3.SelectedValue.ToString()).OrderByDescending(r => r.DiemToiThieu))
                    {
                        if (item.MaXepLoai != "HSR")
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
                    }


                    var NamHoc = from obj in dtb.NAMHOCs
                                 where obj.MaNamHoc == ComboBoxYears3.SelectedValue
                                 select obj.NamHoc1;


                    LabelNameReportGridview3.Text = $"BẢNG THỐNG KÊ HỌC KỲ {ComboBoxSemesters2.SelectedValue.ToString()} NĂM {NamHoc.FirstOrDefault().ToString().ToUpper()}";
                    LabelNameReportGridview3.Show();

                    LabelNameRatio3.Show();


                    DataGridViewRatio3.DataSource = ratio_Source;
                    DataGridViewRatio3.Show();


                    ChartRatio3.DataSource = ratio_Source;
                    ChartRatio3.Series[0].XValueMember = "Xếp loại";
                    ChartRatio3.Series[0].YValueMembers = "Tỉ lệ (%)";
                    ChartRatio3.Series[0].IsValueShownAsLabel = true;
                    ChartRatio3.Show();

                    DataGridViewReport3.DataSource = tbl;
                    DataGridViewReport3.Show();

                    DataGridViewReport3.DataSource = tbl;
                    DataGridViewReport3.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    DataGridViewReport3.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    DataGridViewReport3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    DataGridViewReport3.Show();
                    ButtonPrint3.Show();
                }
            }
            catch
            {
                MessageBox.Show("Thao tác xảy ra lỗi, mời thực hiện lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        bool CheckDiemKC(string MaHS, string NamHoc, double DiemKC)
        {
            dataEntities dtb = new dataEntities();
            var check_source = dtb.TongKetMon_HocSinh(NamHoc, MaHS).ToList();
            var sub_list = check_source.Select(r => r.MaMonHoc).Distinct().ToList();
            
            foreach(var item in sub_list)
            {
                double score = 0;
                double sum_TS = 0;
                var sub = check_source.Where(r => r.MaMonHoc == item.ToString()).ToList();
                foreach(var item2 in sub)
                {
                    var TS = from obj in dtb.HocKy_NamApDung(ComboBoxYears4.SelectedValue.ToString())
                             where obj.MaHocKy == item2.MaHocKy
                             select obj.TrongSo;
                    double ts_change = (double)TS.FirstOrDefault();
                    sum_TS += ts_change;
                    score += (double)item2.DiemTB * ts_change;
                }
                score = Math.Round(score / sum_TS, 2);
                if (score < DiemKC)
                    return false;
            }            
            return true;
        }
        private void guna2ImageButtonSearch4_Click(object sender, EventArgs e)
        {
            try
            {
                dataEntities dtb = new dataEntities();
                DataTable tbl = new DataTable();
                var cls_list = dtb.TongKetNamHoc(ComboBoxYears4.SelectedValue.ToString()).Select(r => r.TenLop).Distinct().ToList();
                if (cls_list.Count() == 0)
                {
                    MessageBox.Show("Không có dữ liệu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int index = -1;
                    int sum = 0;
                    tbl.Columns.Add("STT", typeof(string));
                    tbl.Columns.Add("Lớp", typeof(string));
                    tbl.Columns.Add("Sĩ số", typeof(int));
                    foreach (var item in dtb.XepLoai_NamApDung(ComboBoxYears4.SelectedValue.ToString()).OrderByDescending(r => r.DiemToiThieu))
                    {
                        if (item.MaXepLoai != "HSR")
                        {
                            tbl.Columns.Add(item.TenXepLoai, typeof(int));
                        }
                    }
                    foreach (var item in cls_list)
                    {
                        DataRow row = tbl.NewRow();
                        index += 1;
                        row["STT"] = index + 1;
                        row["Lớp"] = item.ToString();
                        foreach (var item2 in dtb.XepLoai_NamApDung(ComboBoxYears4.SelectedValue.ToString()))
                        {
                            if (item2.MaXepLoai != "HSR")
                            {
                                row[item2.TenXepLoai] = 0;
                            }
                        }
                        var std_list = dtb.TongKetNamHoc(ComboBoxYears4.SelectedValue.ToString()).Where(r => r.TenLop == item.ToString()).Select(r => r.MaHocSinh).Distinct().ToList();
                        sum += std_list.Count();
                        row["Sĩ số"] = std_list.Count();
                        tbl.Rows.Add(row);
                        foreach (var item2 in std_list)
                        {
                            var check_source = dtb.TongKetMon_HocSinh(ComboBoxYears4.SelectedValue.ToString(), item2.ToString()).ToList();
                            var sub_list = check_source.Select(r => r.MaMonHoc).Distinct().ToList();
                            double score = 0;

                            foreach (var item3 in sub_list)
                            {
                                double sub_score = 0;
                                double sum_TS = 0;
                                var sub = check_source.Where(r => r.MaMonHoc == item3.ToString()).ToList();
                                foreach (var item4 in sub)
                                {
                                    var TS = from obj in dtb.HocKy_NamApDung(ComboBoxYears4.SelectedValue.ToString())
                                             where obj.MaHocKy == item4.MaHocKy
                                             select obj.TrongSo;
                                    double ts_change = (double)TS.FirstOrDefault();
                                    sum_TS += ts_change;
                                    sub_score += (double)item4.DiemTB * ts_change;
                                }
                                sub_score = Math.Round(sub_score / sum_TS, 2);
                                score += sub_score;
                            }
                            score = Math.Round(score / sub_list.Count(), 2);
                            foreach (var item3 in dtb.XepLoai_NamApDung(ComboBoxYears4.SelectedValue.ToString()).OrderByDescending(r => r.DiemToiThieu))
                            {
                                    if (score >= item3.DiemToiThieu)
                                    {
                                        if (CheckDiemKC(item2.ToString(), ComboBoxYears4.SelectedValue.ToString(), (double)item3.DiemKhongChe))
                                        {
                                            var temp = tbl.Rows[index][item3.TenXepLoai];
                                            temp = (int)temp + 1;
                                            tbl.Rows[index][item3.TenXepLoai] = temp;
                                        }
                                        else
                                        {
                                            bool find = false;
                                            var item4 = dtb.XepLoai_NamApDung(ComboBoxYears4.SelectedValue.ToString()).FirstOrDefault();
                                            foreach (var item5 in dtb.XepLoai_NamApDung(ComboBoxYears4.SelectedValue.ToString()).OrderByDescending(r => r.DiemToiThieu))
                                            {
                                                if (score >= item5.DiemToiThieu)
                                                {
                                                    if (find)
                                                    {
                                                        item4 = item5;
                                                        break;
                                                    }
                                                    find = true;
                                                }
                                            }
                                            var temp = tbl.Rows[index][item4.TenXepLoai];
                                            temp = (int)temp + 1;
                                            tbl.Rows[index][item4.TenXepLoai] = temp;
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
                    foreach (var item in dtb.XepLoai_NamApDung(ComboBoxYears4.SelectedValue.ToString()).OrderByDescending(r => r.DiemToiThieu))
                    {
                        if (item.MaXepLoai != "HSR")
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
                    }


                    var NamHoc = from obj in dtb.NAMHOCs
                                 where obj.MaNamHoc == ComboBoxYears4.SelectedValue
                                 select obj.NamHoc1;


                    LabelNameReportGridview4.Text = $"BẢNG THỐNG KÊ NĂM HỌC {NamHoc.FirstOrDefault().ToString()}";
                    LabelNameReportGridview4.Show();

                    LabelNameRatio4.Show();

                    DataGridViewRatio4.DataSource = ratio_Source;
                    DataGridViewRatio4.Show();


                    ChartRatio4.DataSource = ratio_Source;
                    ChartRatio4.Series[0].XValueMember = "Xếp loại";
                    ChartRatio4.Series[0].YValueMembers = "Tỉ lệ (%)";
                    ChartRatio4.Series[0].IsValueShownAsLabel = true;
                    ChartRatio4.Show();

                    DataGridViewReport4.DataSource = tbl;
                    DataGridViewReport4.Show();

                    DataGridViewReport4.DataSource = tbl;
                    DataGridViewReport4.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    DataGridViewReport4.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    DataGridViewReport4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    DataGridViewReport4.Show();
                    ButtonPrint4.Show();
                }
            }
            catch
            {
                MessageBox.Show("Thao tác xảy ra lỗi, mời thực hiện lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportToExcel(DataGridView dataGridView,DataGridView dataGridView2)
        {
            try
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
            catch
            {
                MessageBox.Show("Thao tác xảy ra lỗi, mời thực hiện lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void guna2ImageButtonPrint1_Click(object sender, EventArgs e)
        {
            ExportToExcel(DataGridViewReport1,DataGridViewRatio1);
        }

        private void guna2ImageButtonPrint2_Click(object sender, EventArgs e)
        {
            ExportToExcel(DataGridViewReport2, DataGridViewRatio2);
        }

        private void guna2ImageButtonPrint3_Click(object sender, EventArgs e)
        {
            ExportToExcel(DataGridViewReport3, DataGridViewRatio3);
        }

        private void guna2ImageButtonPrint4_Click(object sender, EventArgs e)
        {
            ExportToExcel(DataGridViewReport4, DataGridViewRatio3);
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

        private void guna2ComboBoxYears1_SelectedValueChanged(object sender, EventArgs e)
        {
            dataEntities dtb = new dataEntities();
            var ComboBoxSemestersSource = dtb.HocKy_NamApDung(ComboBoxYears1.SelectedValue.ToString());
            ComboBoxSemesters1.DataSource = ComboBoxSemestersSource.ToList();
            ComboBoxSemesters1.DisplayMember = "HocKy";
            ComboBoxSemesters1.ValueMember = "MaHocKy";

            var ComboBoxSubjectsSource = dtb.MonHoc_NamApDung(ComboBoxYears1.SelectedValue.ToString());
            ComboBoxSubjects1.DataSource = ComboBoxSubjectsSource.ToList();
            ComboBoxSubjects1.DisplayMember = "TenMonHoc";
            ComboBoxSubjects1.ValueMember = "MaMonHoc";
        }


        private void guna2ComboBoxYears2_SelectedValueChanged(object sender, EventArgs e)
        {
            dataEntities dtb = new dataEntities();
            var ComboBoxSubjectsSource = dtb.MonHoc_NamApDung(ComboBoxYears2.SelectedValue.ToString());
            ComboBoxSubjects2.DataSource = ComboBoxSubjectsSource.ToList();
            ComboBoxSubjects2.DisplayMember = "TenMonHoc";
            ComboBoxSubjects2.ValueMember = "MaMonHoc";
        }

        private void guna2ComboBoxYears3_SelectedValueChanged(object sender, EventArgs e)
        {
            dataEntities dtb = new dataEntities();
            var ComboBoxSemestersSource = dtb.HocKy_NamApDung(ComboBoxYears3.SelectedValue.ToString());
            ComboBoxSemesters2.DataSource = ComboBoxSemestersSource.ToList();
            ComboBoxSemesters2.DisplayMember = "HocKy";
            ComboBoxSemesters2.ValueMember = "MaHocKy";
        }

        bool max = true;

    }
}
