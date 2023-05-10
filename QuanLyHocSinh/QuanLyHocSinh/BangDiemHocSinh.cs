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
    public partial class BangDiemHocSinh : Form
    {
        public BangDiemHocSinh()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        void LoadData()
        {
            dataEntities dtb = new dataEntities();
            var result = from c in dtb.DIEMs
                         where c.MaHocSinh == textBox1.Text && c.HocKy == textBox2.Text && c.NamHoc == textBox3.Text
                         select new {c.MaMonHoc,c.MONHOC.TenMonHoc, c.DiemTX, c.DiemGK, c.DiemCK, c.DiemTB};
            dataGridView1.DataSource = result.ToList();
        }

        private void TraCuuButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
