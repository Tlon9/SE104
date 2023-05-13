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
    struct reportformat 
    {
        private int stt;
        private string lop;
        private int siso;
        private int gioi;
        private int kha;
        private int tb;
        private int yeu;
        private int kem;

        public int STT { get { return stt; } set { stt = value; } }
        public string LOP { get { return lop; } set { lop = value; } }
        public int SISO { get { return siso; } set { siso = value; } }
        public int GIOI { get { return gioi; } set { gioi = value; } }
        public int KHA { get { return kha; } set { kha = value; } }
        public int TB { get { return tb; } set { tb = value; } }
        public int YEU { get { return yeu; } set { yeu = value; } }
        public int KEM { get { return kem; } set { kem = value; } }

    }
    public partial class BaoCaoTongKet : Form
    {
        public BaoCaoTongKet()
        {
            InitializeComponent();
            PanelStudent.Hide();
            PanelStudent2.Hide();
            PanelStudent3.Hide();
            PanelStudent4.Hide();
            dataGridViewReport.Hide();
            dataGridViewReport2.Hide();
            dataGridViewReport3.Hide();
            dataGridViewReport4.Hide();
            dataEntities data = new dataEntities();
            var ComboBoxSubjectsSource = from obj in data.MONHOCs
                           select obj;
            ComboBoxSubjects.DataSource = ComboBoxSubjectsSource.ToList();
            ComboBoxSubjects.DisplayMember = "TenMonHoc";
            ComboBoxSubjects.ValueMember = "MaMonHoc";
            ComboBoxSubjects2.DataSource = ComboBoxSubjectsSource.ToList();
            ComboBoxSubjects2.DisplayMember = "TenMonHoc";
            ComboBoxSubjects.ValueMember = "MaMonHoc";
        }


        private void ButtonReport_Click(object sender, EventArgs e)
        {
            dataEntities dtb = new dataEntities();
            var Source = from scr in dtb.DIEMs
                           join cls_detail in dtb.CTLOPs on scr.MaHocSinh equals cls_detail.MaHocSinh
                           join cls in dtb.LOPs on cls_detail.MaLop equals cls.MaLop
                           where ComboBoxSubjects.SelectedValue == scr.MaMonHoc && ComboBoxYears.SelectedItem == scr.NamHoc && ComboBoxSemesters.SelectedItem == scr.HocKy
                           group new {cls_detail, cls, scr }
                           by new { cls_detail.MaLop, cls.TenLop, scr.XepLoai}
                           into grp
                           select new { Tenlop = grp.Key.TenLop, XepLoai = grp.Key.XepLoai, Soluong = grp.Count()};
            var reSource = new List<reportformat>();
            var temp = new reportformat();
            var index = -1;
            foreach (var item in Source)
            { 
                if (index == -1 || (index != -1 && reSource[index].LOP != item.Tenlop))
                {
                    index += 1;
                    temp.STT = index + 1;
                    temp.LOP = item.Tenlop;
                    temp.SISO = 0;
                    temp.GIOI = 0;
                    temp.KHA = 0;
                    temp.TB = 0;
                    temp.YEU = 0;
                    temp.KEM = 0;
                    reSource.Add(temp);
                }
                temp = reSource[index];
                switch (item.XepLoai.ToString())
                {
                    case "GIOI      ":
                        temp.GIOI += item.Soluong;
                        break;
                    case "KHA       ":
                        temp.KHA += item.Soluong;
                        break;
                    case "TRUNG BINH":
                        temp.TB += item.Soluong;
                        break;
                    case "YEU       ":
                        temp.YEU += item.Soluong;
                        break;
                    case "KEM       ":
                        temp.KEM += item.Soluong;
                        break;
                }
                temp.SISO += item.Soluong;
                reSource[index] = temp;
            }
            int Gioi = 0;
            int Kha = 0;
            int Tb = 0;
            int Yeu = 0;
            int Kem = 0;
            int TongSo = 0;
            foreach (var item in reSource)
            {
                Gioi += item.GIOI;
                Kha += item.KHA;
                Tb += item.TB;
                Yeu += item.YEU;
                Kem += item.KEM;
                TongSo += item.SISO;
            }
            double ratio1 = 100 * Gioi / TongSo;
            double ratio2 = 100 * Kha / TongSo;
            double ratio3 = 100 * Tb / TongSo;
            double ratio4 = 100 * Yeu / TongSo;
            double ratio5 = 100 * Kem / TongSo;

            textBoxStudent.Text = TongSo.ToString();
            textBoxStudent1.Text = Gioi.ToString();
            textBoxStudent2.Text = Kha.ToString();
            textBoxStudent3.Text = Tb.ToString();
            textBoxStudent4.Text = Yeu.ToString();
            textBoxStudent5.Text = Kem.ToString();

            textBoxRatio1.Text = Math.Round(ratio1, 2).ToString() +'%' ;
            textBoxRatio2.Text = Math.Round(ratio2, 2).ToString() + '%';
            textBoxRatio3.Text = Math.Round(ratio3, 2).ToString() + '%';
            textBoxRatio4.Text = Math.Round(ratio4, 2).ToString() + '%';
            textBoxRatio5.Text = Math.Round(ratio5, 2).ToString() + '%';

            dataGridViewReport.DataSource = reSource;
            PanelStudent.Show();
            dataGridViewReport.Show();

        }



        private void ButtonReport2_Click(object sender, EventArgs e)
        {
            PanelStudent2.Show();
            dataGridViewReport2.Show();
        }

        private void buttonReport3_Click(object sender, EventArgs e)
        {
            PanelStudent3.Show();
            dataGridViewReport3.Show();
        }

        private void buttonReport4_Click(object sender, EventArgs e)
        {
            PanelStudent4.Show();
            dataGridViewReport4.Show();
        }


    }
}
