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
            //Danh sách lớp
            var dsLop = from obj in dtb.LOPs
                        where obj.TenLop != null
                        select new { MaLop = obj.MaLop, TenLop = obj.TenLop };
            dgvDSLOP.DataSource = dsLop.ToList();
            dgvDSLOP.Show();
            //Danh sách khối
            var dsKhoi = from obj in dtb.KHOIs
                         where obj.TenKhoi != null
                         select new { MaKhoi = obj.MaKhoi, TenKhoi = obj.TenKhoi };
            dgvDSKHOI.DataSource = dsKhoi.ToList();
            dgvDSKHOI.Show();
            //Danh sách môn học
            var dsMonhoc = from obj in dtb.MONHOCs
                           where obj.TenMonHoc != null
                           select new { MaMonHoc = obj.MaMonHoc, TenMonHoc = obj.TenMonHoc };
            dgvDSMONHOC.DataSource = dsMonhoc.ToList();
            dgvDSMONHOC.Show();
            //Danh sách điểm thành phần
            var dsDiemTP = from obj in dtb.THANHPHANs
                           where obj.TenThanhPhan != null
                           select new { MaThanhPhan = obj.MaThanhPhan, TenThanhPhan = obj.TenThanhPhan, TrongSo = obj.TrongSo };
            dgvDiemthanhphan.DataSource = dsDiemTP.ToList();
            dgvDiemthanhphan.Show();
            //Danh sách xếp loại
            var dsXeploai = from obj in dtb.XEPLOAIs
                            where obj.TenXepLoai != null
                            select new { MaXepLoai = obj.MaXepLoai, TenXepLoai = obj.TenXepLoai, DiemToiThieu = obj.DiemToiThieu, DiemToiDa = obj.DiemToiDa, DiemKhongChe = obj.DiemKhongChe };
            dgvXepLoai.DataSource = dsXeploai.ToList();
            dgvXepLoai.Show();
            //Danh sách điểm học kỳ
            var dsDiemHK = from obj in dtb.HOCKies
                           where obj.HocKy1 != null
                           select new { MaHocKy = obj.MaHocKy, HocKy1 = obj.HocKy1, TrongSo = obj.TrongSo };
            dgvDiemHK.DataSource = dsDiemHK.ToList();
            dgvDiemHK.Show();
            //Load quy định tuổi tiếp nhận học sinh
            var min_Tuoi = from obj in dtb.THAMSOes
                           select obj.TuoiToiThieu;
            TuoiToiThieutxtbox.Text = min_Tuoi.First().ToString();
            var max_Tuoi = from obj in dtb.THAMSOes
                           select obj.TuoiToiDa;
            TuoiToiDatxtbox.Text = max_Tuoi.First().ToString();
            //Load sĩ số tối đa của lớp
            var max_Siso = from obj in dtb.THAMSOes
                           select obj.SiSoToiDa;
            Sisotextbox.Text = max_Siso.First().ToString();
            
        }
        private void dgvDSLOP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TenLoptextbox.Text = dgvDSLOP.CurrentRow.Cells[1].Value.ToString();

        }

        private void dgvDSKHOI_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TenKhoitextbox.Text = dgvDSKHOI.CurrentRow.Cells[1].Value.ToString();

        }

        private void dgvDSMONHOC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Tenmhtextbox.Text = dgvDSMONHOC.CurrentRow.Cells[1].Value.ToString();

        }
        private void dgvDiemthanhphan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TenTPtextbox.Text = dgvDiemthanhphan.CurrentRow.Cells[1].Value.ToString();
            TrongsoTPtextbox.Text = dgvDiemthanhphan.CurrentRow.Cells[2].Value.ToString();
        }
        private void dgvXepLoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Tenxeploaitextbox.Text = dgvXepLoai.CurrentRow.Cells[1].Value.ToString();
            minDiemtextbox.Text = dgvXepLoai.CurrentRow.Cells[2].Value.ToString();
            maxDiemtextbox.Text = dgvXepLoai.CurrentRow.Cells[3].Value.ToString();
            DiemKCtextbox.Text = dgvXepLoai.CurrentRow.Cells[4].Value.ToString();
        }
        private void dgvDiemHK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HocKytextbox.Text = dgvDiemHK.CurrentRow.Cells[1].Value.ToString();
            TrongSoHKtextbox.Text = dgvDiemHK.CurrentRow.Cells[2].Value.ToString();
        }
        //Thay đổi quy định tiếp nhận học sinh
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
        //Thay đổi quy định lập danh sách lớp
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

        //Thay đổi danh sách lớp
        private void AddLop_button_Click(object sender, EventArgs e)
        {
            string year = Convert.ToString(DateTime.Now.Year - 1 - 2000);
            string tenlop = TenLoptextbox.Text;
            string malop = year + TenLoptextbox.Text;
            string makhoi = year + tenlop[0] + tenlop[1];
            string namhoc = "NH" + Convert.ToString(DateTime.Now.Year - 1 - 2000) + Convert.ToString(DateTime.Now.Year - 2000);
            using (var dtb = new dataEntities())
            {
                var ds_malop = dtb.LOPs.Select(r=>r.MaLop).ToList();
                var ds_tenlop = dtb.LOPs.Select(r => r.TenLop).ToList();
                bool check_tenlop = true;
                bool check_malop = true;
                for(int i = 0;i < ds_malop.Count;i++)
                {
                    if (ds_malop[i] == malop) { check_malop = false;}
                    if (ds_tenlop[i] == tenlop) { check_tenlop = false;}
                }
                if (check_tenlop && check_malop)
                {
                    LOP new_item = new LOP();
                    new_item.MaLop = malop;
                    new_item.TenLop = tenlop;
                    new_item.MaKhoi = makhoi;
                    new_item.MaNamHoc = namhoc;
                    dtb.LOPs.Add(new_item);
                    dtb.SaveChanges();
                }
                else if (!check_tenlop) MessageBox.Show("Tên lớp đã tồn tại!");
                else if (!check_malop)
                {
                    var std = dtb.LOPs.Where(r => r.MaLop == malop).First();
                    std.TenLop = tenlop;
                    dtb.SaveChanges();
                    MessageBox.Show("Cập nhật quy định thành công!");
                }
                var dsLop = from obj in dtb.LOPs
                            where obj.TenLop != null
                            select new { MaLop = obj.MaLop, TenLop = obj.TenLop };
                dgvDSLOP.DataSource = dsLop.ToList();
                dgvDSLOP.Show();
            }
        }
        private void DeleteLop_button_Click(object sender, EventArgs e)
        {
            string malop = dgvDSLOP.CurrentRow.Cells[0].Value.ToString();
            using (var dtb = new dataEntities())
            {
                var std = dtb.LOPs.Where(r => r.MaLop == malop).First();
                std.TenLop = null;
                dtb.SaveChanges();
                var dsLop = from obj in dtb.LOPs
                            where obj.TenLop != null
                            select new { MaLop = obj.MaLop, TenLop = obj.TenLop };
                dgvDSLOP.DataSource = dsLop.ToList();
                dgvDSLOP.Show();
            }
            MessageBox.Show("Cập nhật quy định thành công!");
        }
        private void EditLop_button_Click(object sender, EventArgs e)
        {
            string malop = dgvDSLOP.CurrentRow.Cells[0].Value.ToString();
            using (var dtb = new dataEntities())
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

        //Thay đổi danh sách khối
        private void AddKhoi_button_Click(object sender, EventArgs e)
        {
            string year = Convert.ToString(DateTime.Now.Year - 1 - 2000);
            string tenkhoi = TenKhoitextbox.Text;
            string makhoi = year + tenkhoi;
            using (var dtb = new dataEntities())
            {
                var ds_makhoi = dtb.KHOIs.Select(r => r.MaKhoi).ToList();
                var ds_tenkhoi = dtb.KHOIs.Select(r => r.TenKhoi).ToList();
                bool check_tenkhoi = true;
                bool check_makhoi = true;
                for (int i = 0; i < ds_makhoi.Count; i++)
                {
                    if (ds_makhoi[i] == makhoi) { check_makhoi = false; }
                    if (ds_tenkhoi[i] == tenkhoi) { check_tenkhoi = false; }
                }
                if (check_tenkhoi && check_makhoi)
                {
                    KHOI new_item = new KHOI();
                    new_item.TenKhoi = tenkhoi;
                    new_item.MaKhoi = makhoi;
                    dtb.KHOIs.Add(new_item);
                    dtb.SaveChanges();
                    MessageBox.Show("Cập nhật quy định thành công!");

                }
                else if (!check_tenkhoi) MessageBox.Show("Tên khối đã tồn tại!");
                else if (!check_makhoi)
                {
                    var std = dtb.KHOIs.Where(r => r.MaKhoi == makhoi).First();
                    std.TenKhoi = tenkhoi;
                    dtb.SaveChanges();
                    MessageBox.Show("Cập nhật quy định thành công!");
                }
                var dsKhoi = from obj in dtb.KHOIs
                            where obj.TenKhoi != null
                            select new { MaKhoi = obj.MaKhoi, TenKhoi = obj.TenKhoi };
                dgvDSKHOI.DataSource = dsKhoi.ToList();
                dgvDSKHOI.Show();
            }
        }
        private void EditKhoi_button_Click(object sender, EventArgs e)
        {
            string makhoi = dgvDSKHOI.CurrentRow.Cells[0].Value.ToString();
            string tenkhoi = TenKhoitextbox.Text;
            using (var dtb = new dataEntities())
            {
                var ds_tenkhoi = dtb.KHOIs.Select(r => r.TenKhoi).ToList();
                bool check_tenkhoi = true;
                for (int i = 0; i < ds_tenkhoi.Count; i++)
                {
                    if (ds_tenkhoi[i] == tenkhoi) { check_tenkhoi = false; break; }
                }
                if (check_tenkhoi)
                {
                    var std = dtb.KHOIs.Where(r => r.MaKhoi == makhoi).First();
                    std.TenKhoi = TenKhoitextbox.Text;
                    dtb.SaveChanges();
                    MessageBox.Show("Cập nhật quy định thành công!");
                }
                else MessageBox.Show("Tên khối đã tồn tại!");
                var dsKhoi = from obj in dtb.KHOIs
                             where obj.TenKhoi != null
                             select new { MaKhoi = obj.MaKhoi, TenKhoi = obj.TenKhoi };
                dgvDSKHOI.DataSource = dsKhoi.ToList();
                dgvDSKHOI.Show();
            }
        }
        private void DeleteKhoi_button_Click(object sender, EventArgs e)
        {
            string makhoi = dgvDSKHOI.CurrentRow.Cells[0].Value.ToString();
            using (var dtb = new dataEntities())
            {
                var std = dtb.KHOIs.Where(r => r.MaKhoi == makhoi).First();
                std.TenKhoi = null;
                dtb.SaveChanges();
                var dsKhoi = from obj in dtb.KHOIs
                             where obj.TenKhoi != null
                             select new { MaKhoi = obj.MaKhoi, TenKhoi = obj.TenKhoi };
                dgvDSKHOI.DataSource = dsKhoi.ToList();
                dgvDSKHOI.Show();
            }
            MessageBox.Show("Cập nhật quy định thành công!");
        }

        //Thay đổi danh sách môn học

        private void AddMonhoc_button_Click(object sender, EventArgs e)
        {

        }



        //Giao diện
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
