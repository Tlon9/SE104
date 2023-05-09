using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LapBangDiemMonHocCuaLopNamHoc
{
    public partial class LapBangDiemMonHocCuaLopTrongNamHoc : Form
    {
        public LapBangDiemMonHocCuaLopTrongNamHoc()
        {
            InitializeComponent();
            panelPrint.Hide();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            panelPrint.Show();
        }
    }
}
