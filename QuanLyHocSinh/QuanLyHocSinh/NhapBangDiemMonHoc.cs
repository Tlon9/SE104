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
{   public partial class LapBangDiemMonHoc : Form
    {
        public LapBangDiemMonHoc()
        {
            InitializeComponent();
            panelInput.Hide();
            panelPrint.Hide();
        }

        private void buttonInput_Click(object sender, EventArgs e)
        {
            if (panelPrint.Visible) { panelPrint.Hide(); }
            panelInput.Show();
        }
        private void buttonPrint_Click(object sender, EventArgs e)
        {
            if (panelInput.Visible) { panelInput.Hide(); }
            panelPrint.Show();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            textBoxID.Text = string.Empty;
            textBoxName.Text = string.Empty;
            numericUpDownScore_1.Text = string.Empty;
            numericUpDownScore_2.Text = string.Empty;
            numericUpDownScore_3.Text = string.Empty;
            textBoxAverageScore.Text = string.Empty;
            textBoxClassify.Text = string.Empty;
        }

        private void textBoxScore_1_TextChanged(object sender, EventArgs e)
        {
            float number;
            if (float.TryParse(textBoxID.Text, out number))
            {
                MessageBox.Show("So diem phai khong am, khong lon hon 10 va la so thuc!");
            }
        }
        /*public LapBangDiemMonHoc()
{
InitializeComponent();
Panel1.Hide();
}

private void tổngKếtMônNămHọcToolStripMenuItem_Click(object sender, EventArgs e)
{
Panel1.Show();
}

private void ComboBoxSubjects_SelectedValueChanged(object sender, EventArgs e)
{
ComboBox subject = sender as ComboBox;
MessageBox.Show(subject.SelectedItem.ToString());
}*/
    }

}
