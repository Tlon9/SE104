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
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace QuanLyHocSinh
{
    public partial class BangDiemHocSinh : Form
    {
        public BangDiemHocSinh()
        {

            InitializeComponent();
            DataGridViewScoreSemester.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridViewScoreSemester.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
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

        string MaNamHoc(string namhoc)
        {
            dataEntities data = new dataEntities();
            var manamhoc = from obj in data.NAMHOCs
                           where obj.NamHoc1 == ComboBoxYear2.Text
                           select obj.MaNamHoc;
            return manamhoc.ToString();
        }
        string GetHoTen(string MaHS, dataEntities dtb)
        {
            var HoTen = from h in dtb.HOCSINHs
                        where h.MaHocSinh == MaHS
                        select h.HoTen;
            return HoTen.First();
        }
        string GetLop(string MaLop,string NH, dataEntities dtb)
        {
            var Lop = from ctl in dtb.CTLOPs
                      join kq in dtb.KETQUA_MONHOC_HOCSINH on ctl.MaHocSinh equals kq.MaHocSinh
                      join l in dtb.LOPs on ctl.MaLop equals l.MaLop
                      join nh in dtb.NAMHOCs on kq.MaNamHoc equals nh.MaNamHoc
                      where kq.MaHocSinh == MaLop && nh.NamHoc1 == NH
                      select l.TenLop;
            return Lop.First();
        }
        List<double?> Diem_TP(string MHS, string HK, string NH, string TP,string MH)
        {
            dataEntities dtb = new dataEntities();
            var DIEM = from d in dtb.DIEMs
                       join kq in dtb.KETQUA_MONHOC_HOCSINH on d.MaKetQua equals kq.MaKetQua
                       join hk in dtb.HOCKies on kq.MaHocKy equals hk.MaHocKy
                       join nh in dtb.NAMHOCs on kq.MaNamHoc equals nh.MaNamHoc
                       join mh in dtb.MONHOCs on kq.MaMonHoc equals mh.MaMonHoc
                       join tp in dtb.THANHPHANs on d.MaThanhPhan equals tp.MaThanhPhan
                       where kq.MaHocSinh == MHS && hk.HocKy1 == HK && nh.NamHoc1 == NH
                       && tp.TenThanhPhan == TP && mh.MaMonHoc == MH
                       select d.Diem1;
            return DIEM.ToList();
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
            if (Kiemtra_input(TextBoxID1.Text, ComboBoxSemester.Text, ComboBoxYear1.Text))
            {
                dataEntities dtb = new dataEntities();
                var DIEMTB = from kq in dtb.KETQUA_MONHOC_HOCSINH
                             join hk in dtb.HOCKies on kq.MaHocKy equals hk.MaHocKy
                             join nh in dtb.NAMHOCs on kq.MaNamHoc equals nh.MaNamHoc
                             join mh in dtb.MONHOCs on kq.MaMonHoc equals mh.MaMonHoc
                             where kq.MaHocSinh == TextBoxID1.Text && hk.HocKy1 == ComboBoxSemester.Text && nh.NamHoc1 == ComboBoxYear1.Text
                             select (kq.DiemTB != null ? kq.DiemTB : null);
                var MaMonHoc = from c in dtb.KETQUA_MONHOC_HOCSINH
                               join g in dtb.HOCKies on c.MaHocKy equals g.MaHocKy
                               join k in dtb.NAMHOCs on c.MaNamHoc equals k.MaNamHoc
                               where c.MaHocSinh == TextBoxID1.Text && g.HocKy1 == ComboBoxSemester.Text && k.NamHoc1 == ComboBoxYear1.Text
                               select c.MaMonHoc;
                var TenMonHoc = from c in dtb.KETQUA_MONHOC_HOCSINH
                                join g in dtb.HOCKies on c.MaHocKy equals g.MaHocKy
                                join k in dtb.NAMHOCs on c.MaNamHoc equals k.MaNamHoc
                                join m in dtb.MONHOCs on c.MaMonHoc equals m.MaMonHoc
                                where c.MaHocSinh == TextBoxID1.Text && g.HocKy1 == ComboBoxSemester.Text && k.NamHoc1 == ComboBoxYear1.Text
                                select m.TenMonHoc;
                var ds_thanhphan = dtb.THANHPHANs.Where(r => r.NamApDung == ComboBoxYear1.SelectedValue.ToString()).OrderByDescending(r=>r.MaThanhPhan).Select(r => r.TenThanhPhan).ToList();
                DataGridViewScoreSemester.Columns.Clear();
                DataGridViewScoreSemester.Columns.Add("STT", "STT");
                DataGridViewScoreSemester.Columns.Add("Mã môn học", "Mã môn học");
                DataGridViewScoreSemester.Columns.Add("Tên môn học", "Tên môn học");
                for (int j = 0; j < ds_thanhphan.Count; j++)
                {
                    DataGridViewScoreSemester.Columns.Add(ds_thanhphan[j].ToString(),"Điểm " + ds_thanhphan[j].ToString());
                }
                DataGridViewScoreSemester.Columns.Add("Điểm TB", "Điểm TB");
                DataGridViewScoreSemester.Rows.Clear();
                for (int i = 0; i < MaMonHoc.Count(); i++)
                {
                    string Mamh = MaMonHoc.ToList()[i].ToString();
                    DataGridViewRow newRow = new DataGridViewRow();
                    newRow.CreateCells(DataGridViewScoreSemester);
                    newRow.Cells[0].Value = i + 1;
                    newRow.Cells[1].Value = MaMonHoc.ToList()[i];
                    newRow.Cells[2].Value = TenMonHoc.ToList()[i];
                    for(int j = 0; j < ds_thanhphan.Count; j++)
                    {
                        var DiemTP = Diem_TP(TextBoxID1.Text, ComboBoxSemester.Text, ComboBoxYear1.Text, ds_thanhphan[j].ToString(), MaMonHoc.ToList()[i]);
                        if (DiemTP.Count != 0) newRow.Cells[j+3].Value = DiemTP[0];
                    }

                    newRow.Cells[ds_thanhphan.Count+3].Value = DIEMTB.ToList()[i];
                    DataGridViewScoreSemester.Rows.Add(newRow);
                }
                //Ho Ten
                TextBoxName1.Text = GetHoTen(TextBoxID1.Text, dtb);

                //LOP
                TextBoxClass1.Text = GetLop(TextBoxID1.Text,ComboBoxYear1.Text, dtb);

                //Diem trung binh ca hoc ky
                var DTBHK = DIEMTB.Sum(row => row) / DIEMTB.Count(row => row != null);
                DTBHK = Math.Round((double)DTBHK, 2);
                TextBoxAverageScore1.Text = DTBHK.ToString();

                //XepLoai
                var MaNamHoc = from n in dtb.NAMHOCs
                            where n.NamHoc1 == ComboBoxYear1.Text
                            select n.MaNamHoc;
                var DiemToiThieu = dtb.XepLoai_NamApDung(MaNamHoc.ToString()).OrderByDescending(r => r.DiemToiThieu).Select(r=>r.DiemToiThieu).ToList();
                var DiemKhongChe = dtb.XepLoai_NamApDung(MaNamHoc.ToString()).OrderByDescending(r => r.DiemToiThieu).Select(r=>r.DiemKhongChe).ToList();
                var TenXepLoai = dtb.XepLoai_NamApDung(MaNamHoc.ToString()).OrderByDescending(r=>r.DiemToiThieu).Select(r=>r.TenXepLoai).ToList();
                for (int k = 0; k < DiemToiThieu.Count(); k++)
                {
                    if (DTBHK >= DiemToiThieu[k])
                    {
                        if (DIEMTB.Min() < DiemKhongChe.ToList()[k])
                        {
                            TextBoxClassify1.Text = TenXepLoai.ToList()[k + 1].ToString();
                        }
                        else TextBoxClassify1.Text = TenXepLoai.ToList()[k].ToString();
                        break;
                    }
                }
            }
        }
        void TraCuuDiemNamHoc()
        {

            if (Kiemtra_input(TextBoxID2.Text, " ", ComboBoxYear2.Text))
            {
                dataEntities dtb = new dataEntities();
                var MaMonHoc = from c in dtb.KETQUA_MONHOC_HOCSINH
                               join g in dtb.HOCKies on c.MaHocKy equals g.MaHocKy
                               join k in dtb.NAMHOCs on c.MaNamHoc equals k.MaNamHoc
                               where c.MaHocSinh == TextBoxID2.Text && g.MaHocKy == "1" && k.NamHoc1 == ComboBoxYear2.Text
                               select c.MaMonHoc;
                var TenMonHoc = from c in dtb.KETQUA_MONHOC_HOCSINH
                                join g in dtb.HOCKies on c.MaHocKy equals g.MaHocKy
                                join k in dtb.NAMHOCs on c.MaNamHoc equals k.MaNamHoc
                                join m in dtb.MONHOCs on c.MaMonHoc equals m.MaMonHoc
                                where c.MaHocSinh == TextBoxID2.Text && g.MaHocKy == "1" && k.NamHoc1 == ComboBoxYear2.Text
                                select m.TenMonHoc;
                var MaNamHoc = from n in dtb.NAMHOCs
                               where n.NamHoc1 == ComboBoxYear2.Text
                               select n.MaNamHoc;
                double Tong_DiemTB = 0;
                double Min_DiemTB = 10;
                int so_mon_da_co_diem = MaMonHoc.Count();
                var ds_hocky = dtb.HocKy_NamApDung(ComboBoxYear2.SelectedValue.ToString()).Select(r => r.MaHocKy).ToList();
                DataGridViewScoreYear.Rows.Clear();
                DataGridViewScoreYear.Columns.Clear();
                DataGridViewScoreYear.Columns.Add("STT", "STT");
                DataGridViewScoreYear.Columns.Add("Mã môn học", "Mã môn học");
                DataGridViewScoreYear.Columns.Add("Tên môn học", "Tên môn học");
                for (int j = 0; j < ds_hocky.Count; j++)
                {
                    DataGridViewScoreYear.Columns.Add("Điểm HK " + ds_hocky[j].ToString(), "Điểm HK " + ds_hocky[j].ToString());
                }
                DataGridViewScoreYear.Columns.Add("Điểm TB", "Điểm TB cả năm");
                for (int i = 0; i < MaMonHoc.Count(); i++)
                {

                    DataGridViewRow newRow = new DataGridViewRow();
                    newRow.CreateCells(DataGridViewScoreYear);
                    newRow.Cells[0].Value = i + 1;
                    newRow.Cells[1].Value = MaMonHoc.ToList()[i];
                    newRow.Cells[2].Value = TenMonHoc.ToList()[i];
                    double tong_trong_so = 0;
                    double Tong_DiemTB_mon = 0;

                    for (int j = 3; j < ds_hocky.Count+3; j++)
                    {
                        var DiemTBhk = dtb.TongKetMon_HocSinh(MaNamHoc.ToList()[0].ToString(), TextBoxID2.Text).Where(r => r.MaMonHoc == MaMonHoc.ToList()[i] && r.MaHocKy == ds_hocky[j-3]).Select(r=>r.DiemTB).ToList();
                        var trong_so_hk = dtb.HocKy_NamApDung(MaNamHoc.ToList()[0].ToString()).Where(r => r.MaHocKy == ds_hocky[j-3]).Select(r => r.TrongSo).ToList();
                        if (DiemTBhk.Count() == 1)
                        {
                            newRow.Cells[j].Value = DiemTBhk[0];
                            Tong_DiemTB_mon += (double)(DiemTBhk[0] * trong_so_hk[0]);
                            tong_trong_so += (double)trong_so_hk[0];
                            
                        }
                        else
                        {
                            newRow.Cells[j].Value = null;
                        }
                    }
                    double DiemTB_mon_namhoc = 0; 
                    if (newRow.Cells[ds_hocky.Count + 2].Value != null && newRow.Cells[ds_hocky.Count + 1].Value != null)
                        DiemTB_mon_namhoc = Math.Round(Tong_DiemTB_mon / tong_trong_so, 2);
                    else if (newRow.Cells[ds_hocky.Count + 2].Value == null)
                        DiemTB_mon_namhoc = Convert.ToDouble(newRow.Cells[ds_hocky.Count + 1].Value);
                    else if (newRow.Cells[ds_hocky.Count + 1].Value == null)
                        DiemTB_mon_namhoc = Convert.ToDouble(newRow.Cells[ds_hocky.Count + 2].Value);
                    else so_mon_da_co_diem -= 1;
                    if (Min_DiemTB > DiemTB_mon_namhoc) Min_DiemTB = DiemTB_mon_namhoc;

                    newRow.Cells[ds_hocky.Count + 3].Value = DiemTB_mon_namhoc;
                    Tong_DiemTB += DiemTB_mon_namhoc;
                    DataGridViewScoreYear.Rows.Add(newRow);
                }
                //Ho Ten
                HoTenTxtBox_nh.Text = GetHoTen(TextBoxID2.Text, dtb);

                //LOP
                LopTxtBox_nh.Text = GetLop(TextBoxID2.Text,ComboBoxYear2.Text, dtb);

                //Tinh Diem TB
                double DiemTB = Math.Round((double)(Tong_DiemTB / so_mon_da_co_diem),2);
                DTBNHTextBox.Text = DiemTB.ToString();

                //Xep Loai
                
                var DiemToiThieu = dtb.XepLoai_NamApDung(MaNamHoc.ToString()).OrderByDescending(r => r.DiemToiThieu).Select(r => r.DiemToiThieu).ToList();
                var DiemKhongChe = dtb.XepLoai_NamApDung(MaNamHoc.ToString()).OrderByDescending(r => r.DiemToiThieu).Select(r => r.DiemKhongChe).ToList();
                var TenXepLoai = dtb.XepLoai_NamApDung(MaNamHoc.ToString()).OrderByDescending(r => r.DiemToiThieu).Select(r => r.TenXepLoai).ToList();
                for (int k = 0; k < DiemToiThieu.Count(); k++)
                {
                    if (DiemTB >= DiemToiThieu[k])
                    {
                        if (Min_DiemTB < DiemKhongChe.ToList()[k])
                        {
                            XepLoaiTxtBox_nh.Text = TenXepLoai.ToList()[k + 1].ToString();
                        }
                        else XepLoaiTxtBox_nh.Text = TenXepLoai.ToList()[k].ToString();
                        break;
                    }
                }
                

            }
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
                    if(dataGridView.Rows[i].Cells[j].Value != null)
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


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);

        private void guna2Panel1_MouseDown_1(object sender, MouseEventArgs e)
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
            TraCuuDiemHocKy();
        }

        private void ButtonPrint1_Click(object sender, EventArgs e)
        {
            ExportToExcel(DataGridViewScoreSemester);
        }

        private void ButtonSearch2_Click(object sender, EventArgs e)
        {
            TraCuuDiemNamHoc();
        }

        private void ButtonPrint2_Click(object sender, EventArgs e)
        {
            ExportToExcel(DataGridViewScoreYear);
        }

        private void ComboBoxYear1_SelectedValueChanged(object sender, EventArgs e)
        {
            dataEntities data = new dataEntities();
            var ComboBoxSubjectsSource = data.HocKy_NamApDung(ComboBoxYear1.SelectedValue.ToString());
            ComboBoxSemester.DataSource = ComboBoxSubjectsSource.ToList();
            ComboBoxSemester.DisplayMember = "HocKy";
            ComboBoxSemester.ValueMember = "MaHocKy";
        }
    }
}

