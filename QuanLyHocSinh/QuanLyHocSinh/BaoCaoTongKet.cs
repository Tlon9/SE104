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
            List<reportformat> reSource = new List<reportformat>();
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
