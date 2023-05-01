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
        }
    }
}
