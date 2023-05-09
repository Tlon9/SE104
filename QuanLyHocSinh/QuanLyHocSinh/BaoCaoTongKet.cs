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
            var reSource = from c in data.MONHOCs
                           select c.TenMonHoc;
            ComboBoxSubjects.DataSource = reSource.ToList();
        }


        /*private void BaoCaoTongKet_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'duLieu.MONHOC' table. You can move, or remove it, as needed.
            this.mONHOCTableAdapter.Fill(this.duLieu.MONHOC);

        }*/

        private void ButtonReport_Click(object sender, EventArgs e)
        {
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




        /*private void ButtonReport_Click(object sender, EventArgs e)
{
dataEntities dt = new dataEntities();
var reSource = from c in dt.MONHOCs
         where c.MaMonHoc == ComboBoxSubjects.SelectedValue
         select c;
dataGridViewSubjects.DataSource = reSource.ToList();
}*/

    }
}
