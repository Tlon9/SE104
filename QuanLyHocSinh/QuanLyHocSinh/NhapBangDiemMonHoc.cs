using QuanLyHocSinh.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
//using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyHocSinh
{   public partial class LapBangDiemMonHoc : Form
    {
        dataEntities data = new dataEntities();
        public LapBangDiemMonHoc()
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
            panelInput.Hide();
            panelPrint.Hide();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

        }

        private void buttonInput_Click(object sender, EventArgs e)
        {
            if (panelPrint.Visible) { panelPrint.Hide(); }
            if (panelInput.Visible) { panelInput.Hide(); }
            var comboxID = from obj in data.CTLOPs where obj.MaLop == comboBoxClass.SelectedValue.ToString() select obj.MaHocSinh;
            comboBoxID.DataSource = comboxID.ToList();
            var reSource1 = from scr in data.DIEMs
                            join cls in data.CTLOPs on scr.MaHocSinh equals cls.MaHocSinh
                            join cls1 in data.HOCSINHs on cls.MaHocSinh equals cls1.MaHocSinh
                            where comboBoxSubject.SelectedValue == scr.MaMonHoc && comboBoxYear.SelectedItem == scr.NamHoc && cls.MaLop == comboBoxClass.Text && scr.HocKy == comboBoxSemester.Text
                            select new { MaHocSinh = scr.MaHocSinh, DiemTX = scr.DiemTX, DiemGK = scr.DiemGK, Diemcuoiky = scr.DiemCK, DiemTB = scr.DiemTB, Xeploai = scr.MaXepLoai };
            if (reSource1.Count() == 0) MessageBox.Show("Không tìm thấy dữ liệu phù hợp", "Error", MessageBoxButtons.OK);
            else
            {
                ShowGrid();
                panelInput.Show();
            }
            
        }
        private void buttonPrint_Click(object sender, EventArgs e)
        {
            if (panelInput.Visible) { panelInput.Hide(); }
            if (panelPrint.Visible) { panelPrint.Hide(); }
            var reSource = from scr in data.DIEMs
                            join cls in data.CTLOPs on scr.MaHocSinh equals cls.MaHocSinh
                            join cls1 in data.HOCSINHs on cls.MaHocSinh equals cls1.MaHocSinh
                            where comboBoxSubject.SelectedValue == scr.MaMonHoc && comboBoxYear.SelectedItem == scr.NamHoc && cls.MaLop == comboBoxClass.Text && scr.HocKy == comboBoxSemester.Text
                            select new { MaHocSinh = scr.MaHocSinh, Hoten = cls1.HoTen, DiemTX = scr.DiemTX, DiemGK = scr.DiemGK, Diemcuoiky = scr.DiemCK, DiemTB = scr.DiemTB, Xeploai = scr.MaXepLoai };
            var reSource1 = from scr in reSource
                      join cls in data.XEPLOAIs on scr.Xeploai equals cls.MaXepLoai
                      select new { MaHocSinh = scr.MaHocSinh, Hoten = scr.Hoten, DiemTX = scr.DiemTX, DiemGK = scr.DiemGK, Diemcuoiky = scr.Diemcuoiky, DiemTB = scr.DiemTB, Xeploai = cls.TenXepLoai };
            if (reSource1.Count() == 0) MessageBox.Show("Không tìm thấy dữ liệu phù hợp", "Error", MessageBoxButtons.OK);
            else
            {
                int total = reSource.Count();
                int good = reSource.Count(p => p.Xeploai == "HSG");
                textBoxNumberOfExcellent.Text = good.ToString();
                int ratio = good * 100 / total;
                textBoxRatioOfExcellent.Text = ratio.ToString() + "%";
                good = reSource.Count(p => p.Xeploai == "HSK");
                textBoxNumberOfGood.Text = good.ToString();
                ratio = good * 100 / total;
                textBoxRatioOfGood.Text = ratio.ToString() + "%";
                good = reSource.Count(p => p.Xeploai == "HSTB");
                textBoxNumberOfAverage.Text = good.ToString();
                ratio = good * 100 / total;
                textBoxRatioOfAverage.Text = ratio.ToString() + "%";
                good = reSource.Count(p => p.Xeploai == "HSY");
                textBoxNumberOfB_Average.Text = good.ToString();
                ratio = good * 100 / total;
                textBoxRatioOfB_Average.Text = ratio.ToString() + "%";
                good = reSource.Count(p => p.Xeploai == "HSKEM");
                textBoxNumberOfPoor.Text = good.ToString();
                ratio = good * 100 / total;
                textBoxRatioOfPoor.Text = ratio.ToString() + "%";

                dataGridView2.DataSource = reSource1.ToList();
                dataGridView2.Columns[0].HeaderCell.Value = "Mã học sinh";
                dataGridView2.Columns[1].HeaderCell.Value = "Họ tên học sinh";
                dataGridView2.Columns[2].HeaderCell.Value = "Điểm TX";
                dataGridView2.Columns[3].HeaderCell.Value = "Điểm GK";
                dataGridView2.Columns[4].HeaderCell.Value = "Điểm CK";
                dataGridView2.Columns[5].HeaderCell.Value = "Điểm TB";
                dataGridView2.Columns[6].HeaderCell.Value = "Xếp loại";

                panelPrint.Show();
                dataGridView2.Show();
            }
        }
        string funcXepLoai(double a)
        {
            var reSource = from r in data.XEPLOAIs
                           select r;
            foreach (var item in reSource)
            {
                if (a >= Convert.ToDouble(item.DiemToiThieu) && a <= Convert.ToDouble(item.DiemToiDa))
                {
                    return item.MaXepLoai;
                }
            }
            return string.Empty;
        }
        private void comboBoxID_SelectedValueChanged(object sender, EventArgs e)
        {
            var a = from obj in data.HOCSINHs where obj.MaHocSinh == comboBoxID.Text select obj.HoTen;
            textBoxName.Text = a.ToList().SingleOrDefault();
            var reSource1 = from scr in data.DIEMs
                            join cls in data.CTLOPs on scr.MaHocSinh equals cls.MaHocSinh
                            join cls1 in data.XEPLOAIs on scr.MaXepLoai equals cls1.MaXepLoai
                            where comboBoxID.Text == scr.MaHocSinh && comboBoxSubject.SelectedValue == scr.MaMonHoc && comboBoxYear.SelectedItem == scr.NamHoc && comboBoxSemester.Text == scr.HocKy && cls.MaLop == comboBoxClass.Text
                            select new { DiemTX = scr.DiemTX, DiemGK = scr.DiemGK, DiemCK = scr.DiemCK, DiemTB = scr.DiemTB, Xeploai = cls1.TenXepLoai };
            if (reSource1.Count() != 0)
            {
                textBoxScore_1.Text = reSource1.ToList().SingleOrDefault().DiemTX.Value.ToString();
                textBoxScore_2.Text = reSource1.ToList().SingleOrDefault().DiemGK.Value.ToString();
                textBoxScore_3.Text = reSource1.ToList().SingleOrDefault().DiemCK.Value.ToString();
                textBoxAverageScore.Text = reSource1.ToList().SingleOrDefault().DiemTB.Value.ToString();
                textBoxClassify.Text = reSource1.ToList().SingleOrDefault().Xeploai.ToString();
            }
            else
            {
                textBoxScore_1.Text = null;
                textBoxScore_2.Text = null;
                textBoxScore_3.Text = null;
                textBoxAverageScore.Text = null;
                textBoxClassify.Text = null;
            }
        }
        void ShowGrid()
        {
            var reSource = from scr in data.DIEMs
                            join cls in data.CTLOPs on scr.MaHocSinh equals cls.MaHocSinh
                            join cls1 in data.HOCSINHs on cls.MaHocSinh equals cls1.MaHocSinh
                            where comboBoxSubject.SelectedValue == scr.MaMonHoc && comboBoxYear.SelectedItem == scr.NamHoc && cls.MaLop == comboBoxClass.Text && scr.HocKy == comboBoxSemester.Text
                            select new { MaHocSinh = scr.MaHocSinh, TenHocSinh = cls1.HoTen, DiemTX = scr.DiemTX, DiemGK = scr.DiemGK, Diemcuoiky = scr.DiemCK, DiemTB = scr.DiemTB, Xeploai = scr.MaXepLoai };
            var reSource1 = from scr in reSource
                           join cls in data.XEPLOAIs on scr.Xeploai equals cls.MaXepLoai
                           select new { MaHocSinh = scr.MaHocSinh, TenHocSinh = scr.TenHocSinh, DiemTX = scr.DiemTX, DiemGK = scr.DiemGK, Diemcuoiky = scr.Diemcuoiky, DiemTB = scr.DiemTB, Xeploai = cls.TenXepLoai };
            if (reSource1.Count() == 0) MessageBox.Show("Không tìm thấy dữ liệu phù hợp", "Error", MessageBoxButtons.OK);
            else
            {
                dataGridView1.DataSource = reSource1.ToList();
                dataGridView1.Columns[0].HeaderCell.Value = "Mã học sinh";
                dataGridView1.Columns[1].HeaderCell.Value = "Họ tên học sinh";
                dataGridView1.Columns[2].HeaderCell.Value = "Điểm TX";
                dataGridView1.Columns[3].HeaderCell.Value = "Điểm GK";
                dataGridView1.Columns[4].HeaderCell.Value = "Điểm CK";
                dataGridView1.Columns[5].HeaderCell.Value = "Điểm TB";
                dataGridView1.Columns[6].HeaderCell.Value = "Xếp loại";
                dataGridView1.Show();
            }
        }
        private void buttonLook_Click(object sender, EventArgs e)
        {
            ShowGrid();
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            var ratio = from r in data.THAMSOes
                        select new { tsTX = r.TsTX, tsGK = r.TsGK, tsCK = r.TsCK };
            var ratio2 = ratio.ToList().SingleOrDefault();
            var reSource1 = from scr in data.DIEMs
                            join cls in data.CTLOPs on scr.MaHocSinh equals cls.MaHocSinh
                            where comboBoxID.Text == scr.MaHocSinh && comboBoxSubject.SelectedValue == scr.MaMonHoc && comboBoxYear.SelectedItem == scr.NamHoc && comboBoxSemester.Text == scr.HocKy && cls.MaLop == comboBoxClass.Text
                            select scr.MaDiem;
            var temp = from scr in data.DIEMs
                       select scr.MaDiem;
            
            int index = temp.Select(int.Parse).ToList().Max();
            DIEM new_diem = new DIEM();
            if (reSource1.Count() == 0)
            {
                DIEM new_hs = new DIEM() { MaDiem = (index + 1).ToString(), MaMonHoc = comboBoxSubject.SelectedValue.ToString(), MaHocSinh = comboBoxID.Text, NamHoc = comboBoxYear.Text, HocKy = comboBoxSemester.Text, DiemTX = Convert.ToDouble(textBoxScore_1.Text), DiemGK = Convert.ToDouble(textBoxScore_2.Text), DiemCK = Convert.ToDouble(textBoxScore_3.Text) };
                //if (Double.TryParse(textBoxScore_1.Text, out double score_1) && Double.TryParse(textBoxScore_1.Text, out double score_2) && Double.TryParse(textBoxScore_1.Text, out double score_3))
                new_hs.DiemTB = ratio2.tsTX * new_hs.DiemTX.Value + ratio2.tsGK * new_hs.DiemGK.Value + new_hs.DiemCK.Value * ratio2.tsCK;
                    //new_hs.MaXepLoai = funcXepLoai(new_hs.DiemTB.Value);
                new_hs.MaXepLoai = funcXepLoai(new_hs.DiemTB.Value);
                data.DIEMs.Add(new_hs);
                try
                {
                    data.SaveChanges();
                }
                catch (DbEntityValidationException e1)
                {
                    Console.WriteLine(e1);
                }
                new_diem = new_hs;
            }
            else
            {
                string ID = reSource1.ToList().SingleOrDefault();
                DIEM new_hs = data.DIEMs.Where(p => p.MaDiem == ID).FirstOrDefault();
                if (Convert.ToDouble(textBoxScore_1.Text) != new_hs.DiemTX.Value)
                {
                    new_hs.DiemTX = Convert.ToDouble(textBoxScore_1.Text);
                }
                if (Convert.ToDouble(textBoxScore_2.Text) != new_hs.DiemGK.Value)
                {
                    new_hs.DiemGK = Convert.ToDouble(textBoxScore_2.Text);
                }
                if (Convert.ToDouble(textBoxScore_3.Text) != new_hs.DiemCK.Value)
                {
                    new_hs.DiemCK = Convert.ToDouble(textBoxScore_3.Text);
                }
            
                new_hs.DiemTB = ratio2.tsTX * new_hs.DiemTX + ratio2.tsGK * new_hs.DiemGK + new_hs.DiemCK * ratio2.tsCK;
                new_hs.MaXepLoai = funcXepLoai(Convert.ToDouble(new_hs.DiemTB));
                data.SaveChanges();
                new_diem = new_hs;
            }
            /*comboBoxID.Text = string.Empty;
            textBoxName.Text = string.Empty;
            textBoxScore_1.Text = null;
            textBoxScore_2.Text = null;
            textBoxScore_3.Text = null;*/
            textBoxAverageScore.Text = new_diem.DiemTB.ToString();
            string tenxl = data.XEPLOAIs.Where(p => p.MaXepLoai == new_diem.MaXepLoai).Select(p => p.TenXepLoai).SingleOrDefault().ToString();
            textBoxClassify.Text = tenxl;
            ShowGrid();
        }



        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var reSource1 = from scr in data.DIEMs
                            join cls in data.CTLOPs on scr.MaHocSinh equals cls.MaHocSinh
                            where comboBoxID.Text == scr.MaHocSinh && comboBoxSubject.SelectedValue == scr.MaMonHoc && comboBoxYear.SelectedItem == scr.NamHoc && comboBoxSemester.Text == scr.HocKy && cls.MaLop == comboBoxClass.Text
                            select scr.MaDiem;
            string ID = reSource1.ToList().SingleOrDefault();
            DIEM new_hs = data.DIEMs.Where(p => p.MaDiem == ID).FirstOrDefault();
            data.DIEMs.Remove(new_hs);
            data.SaveChanges();
            comboBoxID.Text = string.Empty;
            textBoxName.Text = string.Empty;
            textBoxScore_1.Text = null;
            textBoxScore_2.Text = null;
            textBoxScore_3.Text = null;
            textBoxAverageScore.Text = string.Empty;
            textBoxClassify.Text = string.Empty;
            ShowGrid();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string name;
            if (e.RowIndex > -1 && dataGridView1.Rows[e.RowIndex].Cells[0].Value != null)
            {
                name = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                comboBoxID.Text = name;
            }

        }

        private void textBoxScore_1_TextChanged(object sender, EventArgs e)
        {
            if (Double.TryParse(textBoxScore_1.Text, out double score))
            {
                if (score < 0 || score > 10)
                {
                    MessageBox.Show("Điểm phải là một số thực không bé hơn 0 và không lớn hơn 10", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void textBoxScore_2_TextChanged(object sender, EventArgs e)
        {
            if (Double.TryParse(textBoxScore_2.Text, out double score))
            {
                if (score < 0 || score > 10)
                {
                    MessageBox.Show("Điểm phải là một số thực không bé hơn 0 và không lớn hơn 10", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void textBoxScore_3_TextChanged(object sender, EventArgs e)
        {
            if (Double.TryParse(textBoxScore_3.Text, out double score))
            {
                if (score < 0 || score > 10)
                {
                    MessageBox.Show("Điểm phải là một số thực không bé hơn 0 và không lớn hơn 10", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

    }

}
