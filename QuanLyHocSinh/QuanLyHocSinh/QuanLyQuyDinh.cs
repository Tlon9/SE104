using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocSinh
{
    public partial class QuanLyQuyDinh : Form
    {
        public QuanLyQuyDinh()
        {
            InitializeComponent();
            dataEntities dtb = new dataEntities();
            var dsLop = from obj in dtb.LOPs
                        select new { MaLop = obj.MaLop, TenLop = obj.TenLop };
            dgvDSLOP.DataSource = dsLop.ToList();
            dgvDSLOP.Show();
            var dsKhoi = from obj in dtb.KHOIs
                         select new { MaKhoi = obj.MaKhoi, TenKhoi = obj.TenKhoi };
            dgvDSKHOI.DataSource = dsKhoi.ToList();
            dgvDSKHOI.Show();
            var dsMonhoc = from obj in dtb.MONHOCs
                           select new { MaMonHoc = obj.MaMonHoc, TenMonHoc = obj.TenMonHoc };
            dgvDSMONHOC.DataSource = dsMonhoc.ToList();
            dgvDSMONHOC.Show();
            //Quy định tiếp nhận học sinh
            var min_Tuoi = from obj in dtb.THAMSOes
                           select obj.TuoiToiThieu;
            TuoiToiThieutxtbox.Text = min_Tuoi.First().ToString();
            var max_Tuoi = from obj in dtb.THAMSOes
                           select obj.TuoiToiDa;
            TuoiToiDatxtbox.Text = max_Tuoi.First().ToString();
            //Quy định lập danh sách lớp
            var max_Siso = from obj in dtb.THAMSOes
                           select obj.SiSoToiDa;
            Sisotextbox.Text = max_Siso.First().ToString();
            
        }

        private void dgvDSLOP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TenLoptextbox.Text = dgvDSLOP.CurrentRow.Cells[1].Value.ToString();
        }

        private void dgvDSKHOI_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TenKhoitextbox.Text = dgvDSKHOI.CurrentRow.Cells[1].Value.ToString();
        }

        private void updateTuoi_button_Click(object sender, EventArgs e)
        {
            using(var context = new dataEntities())
            {
                var std = context.THAMSOes.First();
                std.TuoiToiThieu = Convert.ToByte(TuoiToiThieutxtbox.Text);
                std.TuoiToiDa    = Convert.ToByte(TuoiToiDatxtbox.Text);
                context.SaveChanges();
            }
            MessageBox.Show("Cập nhật quy định thành công!");
        }

        private void updateSiso_button_Click(object sender, EventArgs e)
        {
            using(var context = new dataEntities())
            {
                var std = context.THAMSOes.First();
                std.SiSoToiDa = Convert.ToByte(Sisotextbox.Text);
                context.SaveChanges();
            }
            MessageBox.Show("Cập nhật quy định thành công!");
        }

        private void dgvDSMONHOC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Tenmhtextbox.Text = dgvDSMONHOC.CurrentRow.Cells[1].Value.ToString();
        }

        private void EditLop_button_Click(object sender, EventArgs e)
        {
            string malop = dgvDSLOP.CurrentRow.Cells[0].Value.ToString();
            using(var dtb = new dataEntities())
            {
                var std = dtb.LOPs.Where(r => r.MaLop == malop).First();
                std.TenLop = TenLoptextbox.Text;
                dtb.SaveChanges();
                var dsLop = from obj in dtb.LOPs
                            select new { MaLop = obj.MaLop, TenLop = obj.TenLop };
                dgvDSLOP.DataSource = dsLop.ToList();
                dgvDSLOP.Show();
            }
            MessageBox.Show("Cập nhật quy định thành công!");
        }

        private void AddLop_button_Click(object sender, EventArgs e)
        {
            string year = Convert.ToString(DateTime.Now.Year - 1 - 2000);
            string tenlop = TenLoptextbox.Text;
            string makhoi = year + tenlop[0] + tenlop[1];
            string namhoc = "NH" + Convert.ToString(DateTime.Now.Year - 1 - 2000) + Convert.ToString(DateTime.Now.Year - 2000);
            using (var dtb = new dataEntities())
            {
                var ds = dtb.LOPs.Select(r=>r.TenLop).ToList();
                bool check_tenlop = true;
                for(int i = 0;i < ds.Count;i++)
                {
                    if (ds[i] == tenlop) { check_tenlop = false; break;}
                }
                if (check_tenlop)
                {
                    LOP new_item = new LOP();
                    new_item.MaLop = year + TenLoptextbox.Text;
                    new_item.TenLop = TenLoptextbox.Text;
                    new_item.MaKhoi = makhoi;
                    new_item.MaNamHoc = namhoc;
                    dtb.LOPs.Add(new_item);
                    dtb.SaveChanges();
                    var dsLop = from obj in dtb.LOPs
                                select new { MaLop = obj.MaLop, TenLop = obj.TenLop };
                    dgvDSLOP.DataSource = dsLop.ToList();
                    dgvDSLOP.Show();
                    MessageBox.Show("Cập nhật quy định thành công!");
                }
                else MessageBox.Show("Tên lớp đã tồn tại!");
            }
        }

        private void DeleteLop_button_Click(object sender, EventArgs e)
        {
            string malop = dgvDSLOP.CurrentRow.Cells[0].Value.ToString();
            using (var dtb = new dataEntities())
            {
                var std = dtb.LOPs.Where(r => r.MaLop == malop).First();
                dtb.LOPs.Remove(std);
                dtb.SaveChanges();
                var dsLop = from obj in dtb.LOPs
                            select new { MaLop = obj.MaLop, TenLop = obj.TenLop };
                dgvDSLOP.DataSource = dsLop.ToList();
                dgvDSLOP.Show();
            }
            MessageBox.Show("Cập nhật quy định thành công!");
        }


        private void AddKhoi_button_Click(object sender, EventArgs e)
        {
            string year = Convert.ToString(DateTime.Now.Year - 1 - 2000);
            string tenkhoi = TenKhoitextbox.Text;
            string makhoi = year + tenkhoi;
        }
        private void guna2ImageButtonHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            TrangCaNhan newform = new TrangCaNhan();
            this.Hide();
            newform.ShowDialog();
            this.Show();
        }

        private void guna2ImageButtonMinimize1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void guna2ImageButtonClose1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);

        private void guna2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
    }
}
