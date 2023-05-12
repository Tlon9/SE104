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
    public partial class TraCuuHocSinh : Form
    {
        public TraCuuHocSinh()
        {
            InitializeComponent();
        }


        void TraCuuHS ()
        {
            dataEntities db = new dataEntities();
            var result = from iter in db.HOCSINHs
                         where iter.MaHocSinh == textBox1.Text
                         select iter;

            //Ko tim duoc HocSinh
            if (result.Count()==0)      MessageBox.Show("Không tìm thấy học sinh phù hợp với mã số sinh viên đã nhập","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            else
            {

            }    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TraCuuHS();
        }
    }
}
