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
    public partial class TiepNhanHocSinh : Form
    {
        public TrangChu formTNHocSinh { get; set; }

        public TiepNhanHocSinh(TrangChu mainform)
        {
            this.formTNHocSinh = mainform;
            InitializeComponent();
            this.uC_ThemHocSinhMoi1.Visible = true;
            this.uC_XemThongTinHocSinh1.Visible = false;
        }

        private void btnHomeScreen_Click(object sender, EventArgs e)
        {
            (this.formTNHocSinh as TrangChu).Show();
            this.Close();
        }

        private void btnAddNewStudent_Click(object sender, EventArgs e)
        {
            if(this.uC_ThemHocSinhMoi1.Visible == false)
            {
                this.uC_ThemHocSinhMoi1.Visible = true;
                this.uC_XemThongTinHocSinh1.Visible = false;
            }
        }

        private void btnInteractStudentInfo_Click(object sender, EventArgs e)
        {
            if(this.uC_XemThongTinHocSinh1.Visible == false)
            {
                this.uC_XemThongTinHocSinh1.Visible = true;
                this.uC_ThemHocSinhMoi1.Visible = false;
            }
        }
    }
}
