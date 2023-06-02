using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
namespace QuanLyHocSinh
{
    public partial class BangDiemTongKetLop : Form
    {
        public BangDiemTongKetLop()
        {
            InitializeComponent();
            dgvHocKy.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHocKy.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataEntities data = new dataEntities();
            List<string> dsNamhoc = new List<string>();
            foreach (var d in data.NAMHOCs)
            {
                dsNamhoc.Add(d.NamHoc1.ToString());
            }
            List<string> dsHocky = new List<string>();
            foreach (var d in data.HOCKies)
            {
                dsHocky.Add(d.HocKy1.ToString());
            }
            List<string> dsLop = new List<string>();
            foreach (var d in data.LOPs)
            {
                dsLop.Add(d.TenLop.ToString());
            }
            LopCbb_hk.DataSource = dsLop;
            LopCbb_nh.DataSource = dsLop;
            NamHocCbb_nh.DataSource = dsNamhoc;
            NamHocCbb_hk.DataSource = dsNamhoc;
            HocKyCbb.DataSource = dsHocky;
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
                         where hs.HoTen == ten && h.HocKy1 == hk && n.NamHoc1 == nh && l.TenLop == lop && mh.MaMonHoc == mon
                         select kq.DiemTB;
            return DiemTB.ToList();
        }
        void TongKetHocKy()
        {
            dataEntities dtb = new dataEntities();
            var TenMonHoc = dtb.KETQUA_MONHOC_HOCSINH
                            .Join(dtb.HOCKies, kq => kq.MaHocKy, hk => hk.MaHocKy, (kq, hk) => new { kq, hk })
                            .Join(dtb.NAMHOCs, kqhk => kqhk.kq.MaNamHoc, nh => nh.MaNamHoc, (kqhk, nh) => new { kqhk.kq, kqhk.hk, nh })
                            .Join(dtb.MONHOCs, kqhknh => kqhknh.kq.MaMonHoc, mh => mh.MaMonHoc, (kqhknh, mh) => new { kqhknh.kq, kqhknh.hk, kqhknh.nh, mh })
                            .GroupBy(kqhknhmh => kqhknhmh.mh.TenMonHoc)
                            .Select(g => g.Key)
                            .ToList();
            var MaMonHoc = dtb.KETQUA_MONHOC_HOCSINH
                .Join(dtb.HOCKies, kq => kq.MaHocKy, hk => hk.MaHocKy, (kq, hk) => new { kq, hk })
                .Join(dtb.NAMHOCs, kqhk => kqhk.kq.MaNamHoc, nh => nh.MaNamHoc, (kqhk, nh) => new { kqhk.kq, kqhk.hk, nh })
                .Join(dtb.MONHOCs, kqhknh => kqhknh.kq.MaMonHoc, mh => mh.MaMonHoc, (kqhknh, mh) => new { kqhknh.kq, kqhknh.hk, kqhknh.nh, mh })
                .GroupBy(kqhknhmh => kqhknhmh.mh.MaMonHoc)
                .Select(g => g.Key)
                .ToList();
            var HoTen = from ctl in dtb.CTLOPs
                        join l in dtb.LOPs on ctl.MaLop equals l.MaLop
                        join hs in dtb.HOCSINHs on ctl.MaHocSinh equals hs.MaHocSinh
                        where l.TenLop == LopCbb_hk.Text
                        select hs.HoTen;


            dgvHocKy.Columns.Clear();
            dgvHocKy.Rows.Clear();
            dgvHocKy.Columns.Add("STT", "STT");
            dgvHocKy.Columns.Add("Hoten", "Họ và tên");
            for (int i = 0; i < TenMonHoc.Count(); i++)
            {
                DataGridViewColumn newcol = new DataGridViewColumn();
                string[] split_word = TenMonHoc[i].Split();
                string ten = "Điểm " + split_word[0] + " " + (split_word[1] != "10" ? split_word[1] : "");
                dgvHocKy.Columns.Add(ten, ten);
            }
            dgvHocKy.Columns.Add("Điểm TB", "Điểm TB");
            dgvHocKy.Columns.Add("Xếp loại", "Xếp loại");
            var MaNamHoc = from n in dtb.NAMHOCs
                           where n.NamHoc1 == NamHocCbb_hk.Text
                           select n.MaNamHoc;
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
                newrow.CreateCells(dgvHocKy);
                newrow.Cells[0].Value = i + 1;
                newrow.Cells[1].Value = HoTen.ToList()[i].ToString();
                double?[] diem = new double?[TenMonHoc.Count];
                double? sum = 0;
                int so_mon_da_co_diem = 0;

                for (int j = 0; j < TenMonHoc.Count(); j++)
                {
                    string ten = HoTen.ToList()[i].ToString();
                    string mon = MaMonHoc[j].ToString();
                    int diemtbmon_ketqua = DiemTB(ten, HocKyCbb.Text, NamHocCbb_hk.Text, LopCbb_hk.Text, mon).ToList().Count();
                    if (diemtbmon_ketqua != 0)
                    {
                        so_mon_da_co_diem += 1;
                        double? diemtb_mon = DiemTB(ten, HocKyCbb.Text, NamHocCbb_hk.Text, LopCbb_hk.Text, mon).ToList()[0];
                        newrow.Cells[j + 2].Value = diemtb_mon;
                        if (diemtb_mon < min_DiemTbmon) min_DiemTbmon = (double)diemtb_mon;
                        sum += diemtb_mon;
                    }
                }
                double diemtb_hk = (double)(sum / so_mon_da_co_diem);
                if (sum != 0) newrow.Cells[DiemTb_index + 2].Value = Math.Round(diemtb_hk, 2);
                if (so_mon_da_co_diem == TenMonHoc.Count())
                {
                    for (int k = 0; k < DiemToiThieu.Count(); k++)
                    {
                        if (diemtb_hk >= DiemToiThieu[k] && sum != 0)
                        {
                            if (min_DiemTbmon < DiemKhongChe.ToList()[i])
                            {
                                newrow.Cells[Xeploai_index + 2].Value = TenXepLoai.ToList()[i + 1].ToString();
                            }
                            else newrow.Cells[Xeploai_index + 2].Value = TenXepLoai.ToList()[k].ToString();
                            xeploai[k] += 1;
                            break;
                        }
                    }
                }
                dgvHocKy.Rows.Add(newrow);
            }

            dgvHocKy.Show();
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
                row_ratio["Tỉ lệ (%)"] = Math.Round((float)(100 * xeploai[z] / (dgvHocKy.Rows.Count - 1)), 2);
                ratio_Source.Rows.Add(row_ratio);
                z++;
            }

            var NamHoc = from obj in dtb.NAMHOCs
                         where obj.MaNamHoc == NamHocCbb_hk.Text
                         select obj.NamHoc1;


            labelName.Text = $"BẢNG THỐNG KÊ LỚP {LopCbb_hk.Text}";
            labelName.Show();

            LabelNameRatio1.Show();

            dgvRatio.DataSource = ratio_Source;
            dgvRatio.Show();

            ChartRatio.DataSource = ratio_Source;
            ChartRatio.Series[0].XValueMember = "Xếp loại";
            ChartRatio.Series[0].YValueMembers = "Tỉ lệ (%)";
            ChartRatio.Series[0].IsValueShownAsLabel = true;

            ChartRatio.Show();

        }
        void TongKetNamHoc()
        {
            dataEntities dtb = new dataEntities();
            var TenMonHoc = dtb.KETQUA_MONHOC_HOCSINH
                            .Join(dtb.HOCKies, kq => kq.MaHocKy, hk => hk.MaHocKy, (kq, hk) => new { kq, hk })
                            .Join(dtb.NAMHOCs, kqhk => kqhk.kq.MaNamHoc, nh => nh.MaNamHoc, (kqhk, nh) => new { kqhk.kq, kqhk.hk, nh })
                            .Join(dtb.MONHOCs, kqhknh => kqhknh.kq.MaMonHoc, mh => mh.MaMonHoc, (kqhknh, mh) => new { kqhknh.kq, kqhknh.hk, kqhknh.nh, mh })
                            .GroupBy(kqhknhmh => kqhknhmh.mh.TenMonHoc)
                            .Select(g => g.Key)
                            .ToList();
            var MaMonHoc = dtb.KETQUA_MONHOC_HOCSINH
                .Join(dtb.HOCKies, kq => kq.MaHocKy, hk => hk.MaHocKy, (kq, hk) => new { kq, hk })
                .Join(dtb.NAMHOCs, kqhk => kqhk.kq.MaNamHoc, nh => nh.MaNamHoc, (kqhk, nh) => new { kqhk.kq, kqhk.hk, nh })
                .Join(dtb.MONHOCs, kqhknh => kqhknh.kq.MaMonHoc, mh => mh.MaMonHoc, (kqhknh, mh) => new { kqhknh.kq, kqhknh.hk, kqhknh.nh, mh })
                .GroupBy(kqhknhmh => kqhknhmh.mh.MaMonHoc)
                .Select(g => g.Key)
                .ToList();
            var HoTen = from ctl in dtb.CTLOPs
                        join l in dtb.LOPs on ctl.MaLop equals l.MaLop
                        join hs in dtb.HOCSINHs on ctl.MaHocSinh equals hs.MaHocSinh
                        where l.TenLop == LopCbb_nh.Text
                        select hs.HoTen;


            dgvNamHoc.Columns.Clear();
            dgvNamHoc.Rows.Clear();
            dgvNamHoc.Columns.Add("STT", "STT");
            dgvNamHoc.Columns.Add("Hoten", "Họ và tên");
            for (int i = 0; i < TenMonHoc.Count(); i++)
            {
                DataGridViewColumn newcol = new DataGridViewColumn();
                string[] split_word = TenMonHoc[i].Split();
                string ten = "Điểm " + split_word[0] + " " + (split_word[1] != "10" ? split_word[1] : "");
                dgvNamHoc.Columns.Add(ten, ten);
            }
            dgvNamHoc.Columns.Add("Điểm TB", "Điểm TB");
            dgvNamHoc.Columns.Add("Xếp loại", "Xếp loại");
            var MaNamHoc = from n in dtb.NAMHOCs
                           where n.NamHoc1 == NamHocCbb_nh.Text
                           select n.MaNamHoc;
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
                newrow.CreateCells(dgvNamHoc);
                newrow.Cells[0].Value = i + 1;
                newrow.Cells[1].Value = HoTen.ToList()[i].ToString();
                double?[] diem = new double?[TenMonHoc.Count];
                double? sum = 0;
                int so_mon_da_co_diem = 0;

                for (int j = 0; j < TenMonHoc.Count(); j++)
                {
                    string ten = HoTen.ToList()[i].ToString();
                    string mon = MaMonHoc[j].ToString();
                    bool diemtbmon_ketqua = true;
                    var tb_mon_hk1 = DiemTB(ten, "HKI", NamHocCbb_nh.Text, LopCbb_nh.Text, mon);
                    var tb_mon_hk2 = DiemTB(ten, "HKII", NamHocCbb_nh.Text, LopCbb_nh.Text, mon);

                    if (tb_mon_hk1.ToList().Count == 0 || tb_mon_hk2.ToList().Count == 0) diemtbmon_ketqua = false;
                    else
                    {
                        var trong_so_hk1 = from t in dtb.HOCKies
                                           where t.HocKy1 == "HKI"
                                           select t.TrongSo;
                        var trong_so_hk2 = from t in dtb.HOCKies
                                           where t.HocKy1 == "HKII"
                                           select t.TrongSo;

                        var diemtb_mon = (tb_mon_hk1.ToList()[0] * trong_so_hk1.ToList()[0] + tb_mon_hk2.ToList()[0] * trong_so_hk2.ToList()[0]) / (trong_so_hk1.ToList()[0] + trong_so_hk2.ToList()[0]);
                        double diemtbmon = Math.Round((double)diemtb_mon, 2);
                        if (diemtbmon_ketqua == true)
                        {
                            so_mon_da_co_diem += 1;
                            newrow.Cells[j + 2].Value = diemtbmon;
                            if (diemtb_mon < min_DiemTbmon) min_DiemTbmon = (double)diemtbmon;
                            sum += (double)diemtbmon;
                        }
                    }
                }
                double diemtb_hk = (double)(sum / so_mon_da_co_diem);
                if (sum != 0) newrow.Cells[DiemTb_index + 2].Value = Math.Round(diemtb_hk, 2);
                if (so_mon_da_co_diem == TenMonHoc.Count())
                {
                    for (int k = 0; k < DiemToiThieu.Count(); k++)
                    {
                        if (diemtb_hk >= DiemToiThieu[k] && sum != 0)
                        {
                            if (min_DiemTbmon < DiemKhongChe.ToList()[i])
                            {
                                newrow.Cells[Xeploai_index + 2].Value = TenXepLoai.ToList()[i + 1].ToString();
                            }
                            else newrow.Cells[Xeploai_index + 2].Value = TenXepLoai.ToList()[k].ToString();
                            xeploai[k] += 1;
                            break;
                        }
                    }
                }
                dgvNamHoc.Rows.Add(newrow);
            }

            dgvNamHoc.Show();
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
                row_ratio["Tỉ lệ (%)"] = Math.Round((float)(100 * xeploai[z] / (dgvNamHoc.Rows.Count - 1)), 2);
                ratio_Source.Rows.Add(row_ratio);
                z++;
            }

            var NamHoc = from obj in dtb.NAMHOCs
                         where obj.MaNamHoc == NamHocCbb_nh.Text
                         select obj.NamHoc1;

            
            labelName_nh.Text = $"BẢNG THỐNG KÊ LỚP {LopCbb_nh.Text}";
            labelName_nh.Show();

            label2.Show();
            dgvRatio_nh.DataSource = ratio_Source;
            dgvRatio_nh.Show();

            chartRatio_nh.DataSource = ratio_Source;
            chartRatio_nh.Series[0].XValueMember = "Xếp loại";
            chartRatio_nh.Series[0].YValueMembers = "Tỉ lệ (%)";
            chartRatio_nh.Series[0].IsValueShownAsLabel = true;

            chartRatio_nh.Show();
        }


        private void TraCuuButton_hk_Click(object sender, EventArgs e)
        {
            TongKetHocKy();
        }
        private void ExportToExcel(DataGridView dataGridView)
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
            /*workbook.SaveAs("output.xlsx", Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing,
                Excel.XlSaveAsAccessMode.xlExclusive,
                Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing);*/
            workbook.Close();
            excel.Quit();
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            ExportToExcel(dgvHocKy);
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

        private void TraCuuButton_nh_Click(object sender, EventArgs e)
        {
            TongKetNamHoc();
        }
    }
}
