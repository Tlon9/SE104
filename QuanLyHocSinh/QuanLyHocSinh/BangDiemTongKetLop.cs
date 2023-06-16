using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
namespace QuanLyHocSinh
{
    public partial class BangDiemTongKetLop : Form
    {
        public BangDiemTongKetLop()
        {
            InitializeComponent();
            DataGridViewScoreSemester.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridViewScoreSemester.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataEntities data = new dataEntities();
            var ComboBoxYearSource = from obj in data.NAMHOCs orderby obj.NamHoc1 descending select obj;
            ComboBoxYear2.DataSource = ComboBoxYearSource.ToList();
            ComboBoxYear2.DisplayMember = "NamHoc1";
            ComboBoxYear2.ValueMember = "MaNamHoc";
            ComboBoxYear1.DataSource = ComboBoxYearSource.ToList();
            ComboBoxYear1.DisplayMember = "NamHoc1";
            ComboBoxYear1.ValueMember = "MaNamHoc";

        }
        List<double?> DiemTB(string ten, string hk, string nh, string lop, string mon)
        {
            dataEntities dtb = new dataEntities();
            var DiemTB = from kq in dtb.KETQUA_MONHOC_HOCSINH
                         join hs in dtb.HOCSINHs on kq.MaHocSinh equals hs.MaHocSinh
                         join h in dtb.HOCKies on kq.MaHocKy equals h.MaHocKy
                         join n in dtb.NAMHOCs on kq.MaNamHoc equals n.MaNamHoc
                         join mh in dtb.MONHOCs on kq.MaMonHoc equals mh.MaMonHoc
                         join ctl in dtb.CTLOPs on hs.MaHocSinh equals ctl.MaHocSinh
                         join l in dtb.LOPs on ctl.MaLop equals l.MaLop
                         where hs.MaHocSinh == ten && h.HocKy1 == hk && n.NamHoc1 == nh && mh.MaMonHoc == mon
                         select kq.DiemTB;
            return DiemTB.ToList();
        }
        void TongKetHocKy()
        {
            dataEntities dtb = new dataEntities();
            var MaNamHoc = from obj in dtb.NAMHOCs
                           where obj.NamHoc1 == ComboBoxYear1.Text
                           select obj.MaNamHoc;
            var TenMonHoc = dtb.MonHoc_NamApDung(MaNamHoc.ToList()[0]).Where(r => r.MaMonHoc.Substring(r.MaMonHoc.Length - 2) == ComboBoxClass1.Text.Substring(0, 2)).Select(r => r.TenMonHoc).ToList();
            var MaMonHoc = dtb.MonHoc_NamApDung(MaNamHoc.ToList()[0]).Where(r => r.MaMonHoc.Substring(r.MaMonHoc.Length - 2) == ComboBoxClass1.Text.Substring(0, 2)).Select(r => r.MaMonHoc).ToList();

            var HoTen = from ctl in dtb.CTLOPs
                        join l in dtb.LOPs on ctl.MaLop equals l.MaLop
                        join nh in dtb.NAMHOCs on l.MaNamHoc equals nh.MaNamHoc
                        join hs in dtb.HOCSINHs on ctl.MaHocSinh equals hs.MaHocSinh
                        where l.TenLop == ComboBoxClass1.Text && nh.NamHoc1 == ComboBoxYear1.Text
                        select hs.HoTen;
            var MHS = from ctl in dtb.CTLOPs
                      join l in dtb.LOPs on ctl.MaLop equals l.MaLop
                      join nh in dtb.NAMHOCs on l.MaNamHoc equals nh.MaNamHoc
                      join hs in dtb.HOCSINHs on ctl.MaHocSinh equals hs.MaHocSinh
                      where l.TenLop == ComboBoxClass1.Text && nh.NamHoc1 == ComboBoxYear1.Text
                      select hs.MaHocSinh;
            DataGridViewScoreSemester.Columns.Clear();
            DataGridViewScoreSemester.Rows.Clear();
            DataGridViewScoreSemester.Columns.Add("STT", "STT");
            DataGridViewScoreSemester.Columns.Add("Hoten", "Họ và tên");
            DataGridViewScoreSemester.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            for (int i = 0; i < TenMonHoc.Count(); i++)
            {
                DataGridViewColumn newcol = new DataGridViewColumn();
                string[] split_word = TenMonHoc[i].Split();
                string ten = "";
                for (int j = 0; j < split_word.Count() - 1; j++) ten += (split_word[j] + " ");
                DataGridViewScoreSemester.Columns.Add(ten, ten);
            }
            DataGridViewScoreSemester.Columns.Add("Điểm TB", "Điểm TB");
            DataGridViewScoreSemester.Columns.Add("Xếp loại", "Xếp loại");
            DataGridViewScoreSemester.Columns[DataGridViewScoreSemester.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            var DiemToiThieu = dtb.XepLoai_NamApDung(MaNamHoc.ToString()).OrderByDescending(r => r.DiemToiThieu).Select(r => r.DiemToiThieu).ToList();
            var TenXepLoai = dtb.XepLoai_NamApDung(MaNamHoc.ToString()).OrderByDescending(r => r.DiemToiThieu).Select(r => r.TenXepLoai).ToList();
            var DiemKhongChe = dtb.XepLoai_NamApDung(MaNamHoc.ToString()).OrderByDescending(r => r.DiemToiThieu).Select(r => r.DiemKhongChe).ToList();
            int DiemTb_index = TenMonHoc.Count();
            int Xeploai_index = DiemTb_index + 1;
            int[] xeploai = new int[TenXepLoai.Count()];
            if (HoTen.Count() == 0) return;
            for (int i = 0; i < HoTen.Count(); i++)
            {
                double min_DiemTbmon = 10;
                DataGridViewRow newrow = new DataGridViewRow();
                newrow.CreateCells(DataGridViewScoreSemester);
                newrow.Cells[0].Value = i + 1;
                newrow.Cells[1].Value = HoTen.ToList()[i].ToString();
                double?[] diem = new double?[TenMonHoc.Count];
                double? sum = 0;
                int so_mon_da_co_diem = 0;
                string mhs = MHS.ToList()[i].ToString();
                for (int j = 0; j < TenMonHoc.Count(); j++)
                {
                    string mon = MaMonHoc[j].ToString();
                    int diemtbmon_ketqua = DiemTB(mhs, ComboBoxSemester.Text, ComboBoxYear1.Text, ComboBoxClass1.Text, mon).ToList().Count();
                    if (diemtbmon_ketqua != 0)
                    {
                        so_mon_da_co_diem += 1;
                        double? diemtb_mon = DiemTB(mhs, ComboBoxSemester.Text, ComboBoxYear1.Text, ComboBoxClass1.Text, mon).ToList()[0];
                        newrow.Cells[j + 2].Value = diemtb_mon;
                        if (diemtb_mon < min_DiemTbmon) min_DiemTbmon = (double)diemtb_mon;
                        sum += diemtb_mon;
                    }
                }
                double diemtb_hk = (double)(sum / so_mon_da_co_diem);
                if (sum != 0) newrow.Cells[DiemTb_index + 2].Value = Math.Round(diemtb_hk, 2);
                if (so_mon_da_co_diem > 0)
                {
                    for (int k = 0; k < DiemToiThieu.Count(); k++)
                    {
                        if (diemtb_hk > DiemToiThieu[k] && sum != 0)
                        {
                            if (min_DiemTbmon >= DiemKhongChe.ToList()[k])
                            {
                                newrow.Cells[Xeploai_index + 2].Value = TenXepLoai.ToList()[k].ToString();
                                xeploai[k] += 1;
                            }
                            else
                            {
                                newrow.Cells[Xeploai_index + 2].Value = TenXepLoai.ToList()[k + 1].ToString();
                                xeploai[k + 1] += 1;

                            }
                            break;

                        }
                    }
                }
                DataGridViewScoreSemester.Rows.Add(newrow);
            }
            DataGridViewScoreSemester.Show();
            DataTable ratio_Source = new DataTable();
            ratio_Source.Columns.Add("Xếp loại", typeof(string));
            ratio_Source.Columns.Add("Số lượng", typeof(int));
            ratio_Source.Columns.Add("Tỉ lệ (%)", typeof(float));
            int z = 0;
            foreach (var item in dtb.XepLoai_NamApDung(MaNamHoc.ToString()).OrderByDescending(r => r.DiemToiThieu))
            {
                DataRow row_ratio = ratio_Source.NewRow();
                row_ratio["Xếp loại"] = item.TenXepLoai;

                row_ratio["Số lượng"] = xeploai[z];
                double rat = 0;
                if (xeploai.Sum() == 0) rat = 0;
                else rat = Math.Round((float)(100 * xeploai[z] / xeploai.Sum()), 2);
                row_ratio["Tỉ lệ (%)"] = rat;
                if (rat > 0)
                    ratio_Source.Rows.Add(row_ratio);
                z++;
            }

            var NamHoc = from obj in dtb.NAMHOCs
                         where obj.MaNamHoc == ComboBoxYear1.Text
                         select obj.NamHoc1;


            labelName.Text = $"BẢNG THỐNG KÊ LỚP {ComboBoxClass1.Text}";
            labelName.Show();

            LabelNameRatio1.Show();

            DataGridViewRatitoSemester.DataSource = ratio_Source;
            DataGridViewRatitoSemester.Show();

            ChartRatioSemester.DataSource = ratio_Source;
            ChartRatioSemester.Series[0].XValueMember = "Xếp loại";
            ChartRatioSemester.Series[0].YValueMembers = "Tỉ lệ (%)";
            ChartRatioSemester.Series[0].IsValueShownAsLabel = true;

            ChartRatioSemester.Show();

        }
        double DiemTBmon_namhoc(string MHS, string Monhoc)
        {
            dataEntities dtb = new dataEntities();
            var ds_hocky = dtb.HocKy_NamApDung(ComboBoxYear2.SelectedValue.ToString()).Select(r => r.MaHocKy).ToList();
            double Tong_Diem = 0;
            double tong_trongso = 0;
            var MaNamHoc = from obj in dtb.NAMHOCs
                           where obj.NamHoc1 == ComboBoxYear2.Text
                           select obj.MaNamHoc;
            bool check = false;
            for (int i = 0; i < ds_hocky.Count; i++)
            {
                var DIEMTB = dtb.TongKetMon_HocSinh(ComboBoxYear2.SelectedValue.ToString(), MHS).Where(r => r.MaHocKy == ds_hocky[i] && r.MaMonHoc == Monhoc).Select(r => r.DiemTB).ToList();
                var trong_so_hk = dtb.HocKy_NamApDung(MaNamHoc.ToList()[0].ToString()).Where(r => r.MaHocKy == ds_hocky[i]).Select(r => r.TrongSo).ToList();
                if (DIEMTB.Count != 0)
                {
                    check = true;
                    Tong_Diem += (double)DIEMTB[0] * (double)trong_so_hk[0];
                    tong_trongso += (double)trong_so_hk[0];
                }

            }
            if (check == false) return -1;
            return Math.Round(Tong_Diem / tong_trongso, 2);
        }
        void TongKetNamHoc()
        {
            dataEntities dtb = new dataEntities();
            var MaNamHoc = from obj in dtb.NAMHOCs
                           where obj.NamHoc1 == ComboBoxYear2.Text
                           select obj.MaNamHoc;
            var TenMonHoc = dtb.MonHoc_NamApDung(MaNamHoc.ToList()[0]).Where(r => r.MaMonHoc.Substring(r.MaMonHoc.Length - 2) == ComboBoxClass2.Text.Substring(0, 2)).Select(r => r.TenMonHoc).ToList();
            var MaMonHoc = dtb.MonHoc_NamApDung(MaNamHoc.ToList()[0]).Where(r => r.MaMonHoc.Substring(r.MaMonHoc.Length - 2) == ComboBoxClass2.Text.Substring(0, 2)).Select(r => r.MaMonHoc).ToList();
            var HoTen = from ctl in dtb.CTLOPs
                        join l in dtb.LOPs on ctl.MaLop equals l.MaLop
                        join nh in dtb.NAMHOCs on l.MaNamHoc equals nh.MaNamHoc
                        join hs in dtb.HOCSINHs on ctl.MaHocSinh equals hs.MaHocSinh
                        where l.TenLop == ComboBoxClass2.Text && nh.NamHoc1 == ComboBoxYear2.Text
                        select hs.HoTen;
            var MHS = from ctl in dtb.CTLOPs
                      join l in dtb.LOPs on ctl.MaLop equals l.MaLop
                      join nh in dtb.NAMHOCs on l.MaNamHoc equals nh.MaNamHoc
                      join hs in dtb.HOCSINHs on ctl.MaHocSinh equals hs.MaHocSinh
                      where l.TenLop == ComboBoxClass2.Text && nh.NamHoc1 == ComboBoxYear2.Text
                      select hs.MaHocSinh;

            DataGridViewScoreYear.Columns.Clear();
            DataGridViewScoreYear.Rows.Clear();
            DataGridViewScoreYear.Columns.Add("STT", "STT");
            DataGridViewScoreYear.Columns.Add("Hoten", "Họ và tên");
            DataGridViewScoreYear.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            for (int i = 0; i < TenMonHoc.Count(); i++)
            {
                DataGridViewColumn newcol = new DataGridViewColumn();
                string[] split_word = TenMonHoc[i].Split();
                string ten = "";
                for (int j = 0; j < split_word.Count() - 1; j++) ten += (split_word[j] + " ");
                DataGridViewScoreYear.Columns.Add(ten, ten);
            }
            DataGridViewScoreYear.Columns.Add("Điểm TB", "Điểm TB");
            DataGridViewScoreYear.Columns.Add("Xếp loại", "Xếp loại");
            DataGridViewScoreYear.Columns[DataGridViewScoreYear.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            var DiemToiThieu = dtb.XepLoai_NamApDung(MaNamHoc.ToString()).OrderByDescending(r => r.DiemToiThieu).Select(r => r.DiemToiThieu).ToList();
            var TenXepLoai = dtb.XepLoai_NamApDung(MaNamHoc.ToString()).OrderByDescending(r => r.DiemToiThieu).Select(r => r.TenXepLoai).ToList();
            var DiemKhongChe = dtb.XepLoai_NamApDung(MaNamHoc.ToString()).OrderByDescending(r => r.DiemToiThieu).Select(r => r.DiemKhongChe).ToList();
            int DiemTb_index = TenMonHoc.Count();
            int Xeploai_index = DiemTb_index + 1;
            int[] xeploai = new int[TenXepLoai.Count()];
            for (int i = 0; i < HoTen.Count(); i++)
            {
                double min_DiemTbmon = 10;
                DataGridViewRow newrow = new DataGridViewRow();
                newrow.CreateCells(DataGridViewScoreYear);
                newrow.Cells[0].Value = i + 1;
                newrow.Cells[1].Value = HoTen.ToList()[i].ToString();
                double sum = 0;
                int so_mon_da_co_diem = 0;
                for (int j = 0; j < TenMonHoc.Count(); j++)
                {
                    string ten = HoTen.ToList()[i].ToString();
                    string mon = MaMonHoc[j].ToString();
                    double temp = DiemTBmon_namhoc(MHS.ToList()[i].ToString(), mon);
                    if (temp != -1)
                    {
                        newrow.Cells[j + 2].Value = temp;
                        if (min_DiemTbmon > temp) min_DiemTbmon = temp;
                        sum += temp;
                        so_mon_da_co_diem += 1;
                    }

                }
                double diemtb_hk = (double)(sum / so_mon_da_co_diem);

                if (sum != 0) newrow.Cells[DiemTb_index + 2].Value = Math.Round(diemtb_hk, 2);
                if (so_mon_da_co_diem > 0)
                {
                    for (int k = 0; k < DiemToiThieu.Count(); k++)
                    {
                        if (diemtb_hk > DiemToiThieu[k] && sum != 0)
                        {
                            if (min_DiemTbmon >= DiemKhongChe.ToList()[k])
                            {
                                newrow.Cells[Xeploai_index + 2].Value = TenXepLoai.ToList()[k].ToString();
                                xeploai[k] += 1;
                            }
                            else
                            {
                                newrow.Cells[Xeploai_index + 2].Value = TenXepLoai.ToList()[k + 1].ToString(); xeploai[k + 1] += 1;
                            }
                            break;
                        }
                    }
                }
                DataGridViewScoreYear.Rows.Add(newrow);
            }

            DataGridViewScoreYear.Show();
            DataTable ratio_Source = new DataTable();
            ratio_Source.Columns.Add("Xếp loại", typeof(string));
            ratio_Source.Columns.Add("Số lượng", typeof(int));
            ratio_Source.Columns.Add("Tỉ lệ (%)", typeof(float));
            int z = 0;
            foreach (var item in dtb.XepLoai_NamApDung(MaNamHoc.ToString()).OrderByDescending(r => r.DiemToiThieu))
            {
                DataRow row_ratio = ratio_Source.NewRow();
                row_ratio["Xếp loại"] = item.TenXepLoai;

                row_ratio["Số lượng"] = xeploai[z];
                double rat = 0;
                if (xeploai.Sum() == 0) rat = 0;
                else rat = Math.Round((float)(100 * xeploai[z] / xeploai.Sum()), 2);
                row_ratio["Tỉ lệ (%)"] = rat;
                if (rat > 0)
                    ratio_Source.Rows.Add(row_ratio);
                z++;
            }

            var NamHoc = from obj in dtb.NAMHOCs
                         where obj.MaNamHoc == ComboBoxYear2.Text
                         select obj.NamHoc1;


            labelName_nh.Text = $"BẢNG THỐNG KÊ LỚP {ComboBoxClass2.Text}";
            labelName_nh.Show();

            label2.Show();
            DataGridViewRatioYear.DataSource = ratio_Source;
            DataGridViewRatioYear.Show();

            ChartRatioYear.DataSource = ratio_Source;
            ChartRatioYear.Series[0].XValueMember = "Xếp loại";
            ChartRatioYear.Series[0].YValueMembers = "Tỉ lệ (%)";
            ChartRatioYear.Series[0].IsValueShownAsLabel = true;

            ChartRatioYear.Show();
        }

        private void ExportToExcel(DataGridView dataGridView, DataGridView dataGridView2)
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

        private void guna2ImageButton3_Click(object sender, EventArgs e)
        {
            TrangCaNhan newform = new TrangCaNhan();
            this.Hide();
            newform.ShowDialog();
            this.Show();
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


        private void ButtonHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonAccount_Click(object sender, EventArgs e)
        {
            TrangCaNhan newform = new TrangCaNhan();
            this.Hide();
            newform.ShowDialog();
            this.Show();
        }

        private void ButtonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ButtonSearch1_Click(object sender, EventArgs e)
        {
            TongKetHocKy();
        }

        private void ButtonPrint1_Click(object sender, EventArgs e)
        {
            ExportToExcel(DataGridViewScoreSemester, DataGridViewRatitoSemester);
        }

        private void ButtonSearch2_Click(object sender, EventArgs e)
        {
            TongKetNamHoc();
        }

        private void ButtonPrint2_Click(object sender, EventArgs e)
        {
            ExportToExcel(DataGridViewScoreYear, DataGridViewRatioYear);
        }

        private void ComboBoxYear1_SelectedValueChanged(object sender, EventArgs e)
        {
            dataEntities data = new dataEntities();
            var ComboBoxSemesterSource = data.HocKy_NamApDung(ComboBoxYear1.SelectedValue.ToString());
            ComboBoxSemester.DataSource = ComboBoxSemesterSource.ToList();
            ComboBoxSemester.DisplayMember = "HocKy";
            ComboBoxSemester.ValueMember = "MaHocKy";
            var ComboBoxClassSource = from obj in data.LOPs
                                      join cls in data.NAMHOCs on obj.MaNamHoc equals cls.MaNamHoc
                                      where cls.NamHoc1 == ComboBoxYear1.Text
                                      select obj;
            ComboBoxClass1.DataSource = ComboBoxClassSource.ToList();
            ComboBoxClass1.DisplayMember = "TenLop";
            ComboBoxClass1.ValueMember = "MaLop";
        }

        private void ComboBoxYear2_SelectedValueChanged(object sender, EventArgs e)
        {
            dataEntities data = new dataEntities();
            var ComboBoxClassSource = from obj in data.LOPs
                                      join cls in data.NAMHOCs on obj.MaNamHoc equals cls.MaNamHoc
                                      where cls.NamHoc1 == ComboBoxYear2.Text
                                      select obj;
            ComboBoxClass2.DataSource = ComboBoxClassSource.ToList();
            ComboBoxClass2.DisplayMember = "TenLop";
            ComboBoxClass2.ValueMember = "MaLop";
        }
    }
}
