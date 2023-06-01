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
            DHKGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DHKGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DHKGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DHKGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataEntities data = new dataEntities();
            List<string> dsNamhoc = new List<string>();
            foreach(var d in data.NAMHOCs)
            {
                dsNamhoc.Add(d.NamHoc1.ToString());
            }
            List<string> dsHocky = new List<string>();
            foreach(var d in data.HOCKies)
            {
                dsHocky.Add(d.HocKy1.ToString());
            }
            NamHocCbb_nh.DataSource = dsNamhoc;
            NamHocCbb_hk.DataSource = dsNamhoc;
            HocKyCbb.DataSource = dsHocky;
        }

        string GetHoTen(string MaHS, dataEntities dtb)
        {
            var HoTen = from h in dtb.HOCSINHs
                        where h.MaHocSinh == MaHS
                        select h.HoTen;
            return HoTen.First();
        }
        string GetLop(string MaLop, string HK, string NH, dataEntities dtb)
        {
            var Lop = from ctl in dtb.CTLOPs
                      join kq in dtb.KETQUA_MONHOC_HOCSINH on ctl.MaHocSinh equals kq.MaHocSinh
                      join l in dtb.LOPs on ctl.MaLop equals l.MaLop
                      join hk in dtb.HOCKies on kq.MaHocKy equals hk.MaHocKy
                      join nh in dtb.NAMHOCs on kq.MaNamHoc equals nh.MaNamHoc
                      where kq.MaHocSinh == MaLop && hk.HocKy1 == HK && nh.NamHoc1 == NH
                      select l.TenLop;
            return Lop.First();
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
            if (Kiemtra_input(MHStextbox_hk.Text, HocKyCbb.Text, NamHocCbb_hk.Text))
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

                DHKGridView.Rows.Clear();
                for (int i = 0; i < DIEMTB.ToList().Count; i++)
                {
                    var DIEMTX = DIEM_TP(MHStextbox_hk.Text, HocKyCbb.Text, NamHocCbb_hk.Text, "TX");
                    var DIEMGK = DIEM_TP(MHStextbox_hk.Text, HocKyCbb.Text, NamHocCbb_hk.Text, "GK");
                    var DIEMCK = DIEM_TP(MHStextbox_hk.Text, HocKyCbb.Text, NamHocCbb_hk.Text, "CK");
                    string Mamh = MaMonHoc.ToList()[i].ToString();
                    DataGridViewRow newRow = new DataGridViewRow();
                    newRow.CreateCells(DHKGridView);
                    newRow.Cells[0].Value = i + 1;
                    newRow.Cells[1].Value = MaMonHoc.ToList()[i];
                    newRow.Cells[2].Value = TenMonHoc.ToList()[i];
                    if (i < DIEMTX.Length) newRow.Cells[3].Value = DIEMTX.GetValue(i);
                    if (i < DIEMGK.Length) newRow.Cells[4].Value = DIEMGK.GetValue(i);
                    if (i < DIEMCK.Length) newRow.Cells[5].Value = DIEMCK.GetValue(i);
                    newRow.Cells[6].Value = DIEMTB.ToList()[i];
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
                var MaNamHoc = from n in dtb.NAMHOCs
                            where n.NamHoc1 == NamHocCbb_hk.Text
                            select n.MaNamHoc;
                foreach(var item in dtb.XepLoai_NamApDung(MaNamHoc.ToString()).OrderByDescending(r => r.DiemToiThieu))
                {
                    if (DTBHK >= item.DiemToiThieu)
                    {
                        if (DIEMTB.Min() < item.DiemKhongChe)
                        {
                            XepLoaiTextBox.Text = item.TenXepLoai;
                        }
                        else XepLoaiTextBox.Text = item.TenXepLoai;
                        break;
                    }
                }
            }
        }
        void TraCuuDiemNamHoc()
        {
            if (Kiemtra_input(MHStextbox_nh.Text, " ", NamHocCbb_nh.Text))
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
                float Min_DiemTB = 10;
                for (int i = 0; i < MaMonHoc.Count(); i++)
                {

                    DataGridViewRow newRow = new DataGridViewRow();
                    newRow.CreateCells(DNHGridView);
                    newRow.Cells[0].Value = i + 1;
                    newRow.Cells[1].Value = MaMonHoc.ToList()[i];
                    newRow.Cells[2].Value = TenMonHoc.ToList()[i];
                    newRow.Cells[3].Value = DiemTBhk1.ToArray().GetValue(i);
                    if (DiemTBhk2.Count() != 0 && i < DiemTBhk2.ToList().Count()) newRow.Cells[4].Value = DiemTBhk2.ToList()[i];
                    if (i < DiemTBhk1.Count() && i < DiemTBhk2.Count())
                    {
                        var trong_so_hk1 = from t in dtb.HOCKies
                                           where t.HocKy1 == "HKI"
                                           select t.TrongSo;
                        var trong_so_hk2 = from t in dtb.HOCKies 
                                           where t.HocKy1 == "HKII"
                                           select t.TrongSo; 
                        var DiemTbmon = DiemTBhk1.ToList()[i] * trong_so_hk1.ToList()[0] + DiemTBhk2.ToList()[i] * trong_so_hk2.ToList()[0];

                        newRow.Cells[5].Value = Math.Round((double)DiemTbmon / (double)(trong_so_hk1.ToList()[0] + trong_so_hk2.ToList()[0]), 2);

                    }
                    else if (i >= DiemTBhk1.Count())
                    {
                        var DiemTbmon = DiemTBhk2.ToList()[i];
                        newRow.Cells[4].Value = DiemTbmon;

                    }
                    else if (i >= DiemTBhk2.Count())
                    {
                        var DiemTbmon = DiemTBhk1.ToList()[i];
                        newRow.Cells[4].Value = DiemTbmon;
                    }
                    if (Convert.ToInt64(newRow.Cells[4].Value) < Min_DiemTB) Min_DiemTB = Convert.ToInt64(newRow.Cells[4].Value);
                    Tong_DiemTB += Convert.ToInt64(newRow.Cells[4].Value);
                    DNHGridView.Rows.Add(newRow);
                }
                //Ho Ten
                HoTenTxtBox_nh.Text = GetHoTen(MHStextbox_nh.Text, dtb);

                //LOP
                LopTxtBox_nh.Text = GetLop(MHStextbox_nh.Text, "HKI", NamHocCbb_nh.Text, dtb);


                double DiemTB = Math.Round(Tong_DiemTB / Math.Max(DiemTBhk1.Count(row => row != null), DiemTBhk2.Count(row => row != null)), 2);
                DTBNHTextBox.Text = DiemTB.ToString();
                var MaNamHoc = from n in dtb.NAMHOCs
                               where n.NamHoc1 == NamHocCbb_nh.Text
                               select n.MaNamHoc;
                foreach (var item in dtb.XepLoai_NamApDung(MaNamHoc.ToString()).OrderByDescending(r => r.DiemToiThieu))
                {
                    if (DiemTB >= item.DiemToiThieu)
                    {
                        if (Min_DiemTB < item.DiemKhongChe)
                        {
                            XepLoaiTxtBox_nh.Text = item.TenXepLoai;
                        }
                        else XepLoaiTxtBox_nh.Text = item.TenXepLoai;
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

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void TraCuuButton_hk_Click(object sender, EventArgs e)
        {
            TraCuuDiemHocKy();
        }

        private void TraCuuButton_nh_Click(object sender, EventArgs e)
        {
            TraCuuDiemNamHoc();
        }

        private void guna2ImageButtonMinimize1_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void guna2ImageButtonClose1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void guna2ImageButtonHome_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            ExportToExcel(DHKGridView);
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            ExportToExcel(DHKGridView);
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

        private void guna2Panel1_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
    }
}

