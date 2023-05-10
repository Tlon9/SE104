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
            var reSource = from scr in dtb.DIEMs
                           join cls in dtb.CTLOPs on scr.MaHocSinh equals cls.MaHocSinh
                           where ComboBoxSubjects.SelectedValue == scr.MaMonHoc && ComboBoxYears.SelectedItem == scr.NamHoc && ComboBoxSemesters.SelectedItem == scr.HocKy
                           select new { Malop = cls.MaLop, Mahocsinh = scr.MaHocSinh, Diemcuoiky = scr.DiemCK };

            dataGridViewReport.DataSource = reSource.ToList();
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
