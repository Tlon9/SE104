using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using QuanLyHocSinh.Model;

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
        /*string GetLop(string MaLop,string HK, string Nam, dataEntities dtb)
        {
            var Lop = from src in dtb.CTLOPs
                      join cls in dtb.DIEMs on src.MaHocSinh equals cls.MaHocSinh
                      join l in dtb.LOPs on src.MaLop equals l.MaLop
                      where src.MaHocSinh == MaLop && cls.HocKy == HK && Nam == cls.NamHoc
                      select l.TenLop;
            return Lop.First();
        }*/
        void TraCuuDiemHocKy()
        {
            /*dataEntities dtb = new dataEntities();
            var result = from c in dtb.DIEMs
                         where c.MaHocSinh == MHStextbox_hk.Text && c.HocKy == HocKyCbb.Text && c.NamHoc == NamHocCbb_hk.Text
                         select new {c.MaMonHoc,c.MONHOC.TenMonHoc, c.DiemTX, c.DiemGK, c.DiemCK, c.DiemTB };

                        
            //Nhap sai
            if (result.Count() == 0)
            {
                var DsHocSinh = from c in dtb.DIEMs
                                select c.MaHocSinh;
                bool checkMaHS = false;
                foreach (var d in DsHocSinh )
                {
                    if (d == MHStextbox_hk.Text)
                    {
                        checkMaHS = true;
                        break;
                    }
                }
                if (checkMaHS == false) MessageBox.Show("Mã số học sinh không tồn tại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Không có dữ liệu điểm của học kỳ hoặc năm học này");
                
            } 
            else
            {
                DHKGridView.DataSource = result.ToList();
                //Ho Ten
                HoTenTextBox.Text = GetHoTen(MHStextbox_hk.Text, dtb);

                //LOP
                LopTextBox.Text = GetLop(MHStextbox_hk.Text, HocKyCbb.Text, NamHocCbb_hk.Text, dtb);

                //Diem trung binh ca hoc ky
                var DTBHK = result.Sum(row => row.DiemTB) / 13;
                DTBHK = Math.Round((double)DTBHK, 2);
                DTBHKTextBox.Text = DTBHK.ToString();

                //XepLoai
                if (DTBHK >= 8) XepLoaiTextBox.Text = "Giỏi";
                else if (DTBHK >= 6.5) XepLoaiTextBox.Text = "Khá";
                else if (DTBHK >= 5) XepLoaiTextBox.Text = "Trung Bình";
                else if (DTBHK >= 3.5) XepLoaiTextBox.Text = "Yếu";
                else XepLoaiTextBox.Text = "Kém";
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
            {
                
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(DNHGridView);
                newRow.Cells[0].Value = MaMonHoc.ToList()[i];
                newRow.Cells[1].Value = TenMonHoc.ToList()[i];
                newRow.Cells[2].Value = DiemTBhk1.ToList()[i];
                newRow.Cells[3].Value = DiemTbhk2.ToList()[i];
                newRow.Cells[4].Value = Math.Round((double)DiemTbnh.ToList()[i]/2, 2);
                DNHGridView.Rows.Add(newRow);
            }
            //Ho Ten
            HoTenTxtBox_nh.Text = GetHoTen(MHStextbox_nh.Text, dtb);

            //LOP
            LopTxtBox_nh.Text = GetLop(MHStextbox_nh.Text,"2", NamHocCbb_nh.Text, dtb);


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
