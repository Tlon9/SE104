using QuanLyHocSinh.Properties;
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
    public partial class LapBangDiemMonHocCuaLopNamHoc : Form
    {
        public LapBangDiemMonHocCuaLopNamHoc()
        {
            InitializeComponent();
            dataEntities data = new dataEntities();
            var ComboBoxSubjectsSource = from obj in data.MONHOCs select obj;
            comboBoxSubject.DataSource = ComboBoxSubjectsSource.ToList();
            comboBoxSubject.DisplayMember = "TenMonHoc";
            comboBoxSubject.ValueMember = "MaMonHoc";
            var comboxClassSource = from obj in data.LOPs select obj;
            comboBoxClass.DataSource = comboxClassSource.ToList();
            comboBoxClass.DisplayMember = "MaLop";
            comboBoxClass.ValueMember = "MaLop";
            panelPrint.Hide();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
        string funcXeploai(double a)
        {
            dataEntities data = new dataEntities();
            var reSource = from r in data.XEPLOAIs
                           select r;
            foreach(var item in reSource)
            {
                if (a >= Convert.ToDouble(item.DiemToiThieu) && a <= Convert.ToDouble(item.DiemToiDa))
                {
                    return item.MaXepLoai;
                }
            }
            return string.Empty;
        }
        private void buttonPrint_Click(object sender, EventArgs e)
        {
            dataEntities dtb = new dataEntities();
            var reSource1 = from scr in dtb.DIEMs
                            join cls in dtb.CTLOPs on scr.MaHocSinh equals cls.MaHocSinh
                            join cls1 in dtb.HOCSINHs on cls.MaHocSinh equals cls1.MaHocSinh
                            where comboBoxSubject.SelectedValue == scr.MaMonHoc && comboBoxYear.SelectedItem == scr.NamHoc && cls.MaLop == comboBoxClass.Text && scr.HocKy == "1" && scr.DiemTB != null
                            select new { Mahocsinh = cls.MaHocSinh, Hotenhocsinh = cls1.HoTen, DiemTBHK1 = scr.DiemTB };
            var reSource2 = from scr in dtb.DIEMs
                            join cls in dtb.CTLOPs on scr.MaHocSinh equals cls.MaHocSinh
                            join cls1 in dtb.HOCSINHs on cls.MaHocSinh equals cls1.MaHocSinh
                            where comboBoxSubject.SelectedValue == scr.MaMonHoc && comboBoxYear.SelectedItem == scr.NamHoc && cls.MaLop == comboBoxClass.Text && scr.HocKy == "2" && scr.DiemTB != null
                            select new { Mahocsinh = cls.MaHocSinh, DiemTBHK2 = scr.DiemTB };
            var reSource4 = from r in reSource1.ToList()
                            join r1 in reSource2.ToList() on r.Mahocsinh equals r1.Mahocsinh
                            select new { Mahocsinh =  r.Mahocsinh, Hotenhocsinh = r.Hotenhocsinh, DiemTBHK1 = r.DiemTBHK1, DiemTBHK2 = r1.DiemTBHK2, DiemTBNam = (r.DiemTBHK1 + r1.DiemTBHK2) / 2, Xeploai = funcXeploai(Convert.ToDouble((r.DiemTBHK1 + r1.DiemTBHK2) / 2)) };
            var reSource3 = from scr in reSource4
                     join cls in dtb.XEPLOAIs on scr.Xeploai equals cls.MaXepLoai
                     select new { Mahocsinh = scr.Mahocsinh, Hotenhocsinh = scr.Hotenhocsinh, DiemTBHK1 = scr.DiemTBHK1, DiemTBHK2 = scr.DiemTBHK2, DiemTBNam = Math.Round(Convert.ToDouble(scr.DiemTBNam),2), Xeploai = cls.TenXepLoai };
            if (reSource1.Count() == 0) MessageBox.Show("Không tìm thấy dữ liệu phù hợp", "Error", MessageBoxButtons.OK);
            else
            {
                //int total = Convert.ToInt32(dtb.LOPs.Where(p => p.MaLop==comboBoxClass.Text).Select(p => p.SiSo).SingleOrDefault());
                int total = reSource4.Count(p => p.Xeploai != "HSR");
                int good = reSource4.Count(p => p.Xeploai == "HSG");
                textBoxNumberOfExcellent.Text = good.ToString();
                double ratio = good * 100 / total;
                textBoxRatioOfExcellent.Text = ratio.ToString() + "%";
                good = reSource4.Count(p => p.Xeploai == "HSK");
                textBoxNumberOfGood.Text = good.ToString();
                ratio = good * 100 / total;
                textBoxRatioOfGood.Text = ratio.ToString() + "%";
                good = reSource4.Count(p => p.Xeploai == "HSTB");
                textBoxNumberOfAverage.Text = good.ToString();
                ratio = good * 100 / total;
                textBoxRatioOfAverage.Text = ratio.ToString() + "%";
                good = reSource4.Count(p => p.Xeploai == "HSY");
                textBoxNumberOfB_Average.Text = good.ToString();
                ratio = good * 100 / total;
                textBoxRatioOfB_Average.Text = ratio.ToString() + "%";
                good = reSource4.Count(p => p.Xeploai == "HSKEM");
                textBoxNumberOfPoor.Text = good.ToString();
                ratio = good * 100 / total;
                textBoxRatioOfPoor.Text = ratio.ToString() + "%";

                dataGridView1.DataSource = reSource3.ToList();
                dataGridView1.Columns[0].HeaderCell.Value = "Mã học sinh";
                dataGridView1.Columns[1].HeaderCell.Value = "Họ tên học sinh";
                dataGridView1.Columns[2].HeaderCell.Value = "Điểm TB học kì 1";
                dataGridView1.Columns[3].HeaderCell.Value = "Điểm TB học kì 2";
                dataGridView1.Columns[4].HeaderCell.Value = "Điểm TB cả năm";
                dataGridView1.Columns[5].HeaderCell.Value = "Xếp loại";
                panelPrint.Show();
                dataGridView1.Show();
            }
        }
    }
}
