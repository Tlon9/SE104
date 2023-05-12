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
        }

        string GetHoTen(string MaHS, dataEntities dtb)
        {
            var HoTen = from h in dtb.HOCSINHs
                        where h.MaHocSinh == MaHS
                        select h.HoTen;
            return HoTen.First();
        }
        string GetLop(string MaLop,string HK, string Nam, dataEntities dtb)
        {
            var Lop = from src in dtb.CTLOPs
                      join cls in dtb.DIEMs on src.MaHocSinh equals cls.MaHocSinh
                      join l in dtb.LOPs on src.MaLop equals l.MaLop
                      where src.MaHocSinh == MaLop && cls.HocKy == HK && Nam == cls.NamHoc
                      select l.TenLop;
            return Lop.First();
        }
        void TraCuuDiemHocKy()
        {
            dataEntities dtb = new dataEntities();
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
            }
        }
        void TraCuuDiemNamHoc()
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

        private void DHKGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
