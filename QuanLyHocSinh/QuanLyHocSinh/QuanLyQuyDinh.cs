using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocSinh
{
    public partial class QuanLyQuyDinh : Form
    {
        public QuanLyQuyDinh()
        {
            InitializeComponent();
            PanelDsQuydinh.Hide();
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
                         select new {MaKhoi = obj.MaKhoi, TenKhoi = obj.TenKhoi };
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
        //Thêm năm học mới
        private void AddNamhoc_button_Click(object sender, EventArgs e)
        {
            string namhoc = Namhoctextbox.Text;
            string pattern = @"^20\d{2}-20\d{2}$";
            bool isMatch = Regex.IsMatch(namhoc, pattern);
            string manamhoc = "";
            if (namhoc.Length == 9 && isMatch)
            {
                manamhoc = "NH" + namhoc[2] + namhoc[3] + namhoc[7] + namhoc[8];
                using (var dtb = new dataEntities())
                {
                    bool check_namhoc = true;
                    var ds_namhoc = dtb.NAMHOCs.Select(r => r.NamHoc1).ToList();
                    for (int i = 0; i < ds_namhoc.Count; i++)
                    {
                        if (ds_namhoc[i] == namhoc) { check_namhoc = false; break; }
                    }
                    if (check_namhoc)
                    {
                        NAMHOC new_item = new NAMHOC();
                        new_item.MaNamHoc = manamhoc;
                        new_item.NamHoc1 = namhoc;
                        dtb.NAMHOCs.Add(new_item);
                        dtb.SaveChanges();
                        MessageBox.Show("Thêm năm học thành công!");
                        PanelDsQuydinh.Show();
                    }
                    else MessageBox.Show("Năm học đã tồn tại!");
                };
            }
            else MessageBox.Show("Năm học không hợp lệ!");
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
            string year = Namhoctextbox.Text;
            string tenlop = TenLoptextbox.Text;
            string malop = "22" + TenLoptextbox.Text;
            if(tenlop.Length != 4)
            {
                MessageBox.Show("Tên lớp không hợp lệ!");
                return;
            }
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
                    var makhoi = dtb.KHOIs.Where(r => r.TenKhoi == tenlop.Substring(0, 2)).First();
                    var namhoc = dtb.NAMHOCs.Where(r => r.NamHoc1 == year).First();
                    new_item.MaLop = malop;
                    new_item.TenLop = tenlop;
                    new_item.MaKhoi = makhoi.MaKhoi;
                    new_item.MaNamHoc = namhoc.MaNamHoc;
                    dtb.LOPs.Add(new_item);
                    dtb.SaveChanges();
                    MessageBox.Show("Cập nhật danh sách lớp thành công!");
                }
                else if (!check_tenlop) MessageBox.Show("Tên lớp đã tồn tại!");
                else if (!check_malop)
                {
                    var std = dtb.LOPs.Where(r => r.MaLop == malop).First();
                    std.TenLop = tenlop;
                    dtb.SaveChanges();
                    MessageBox.Show("Cập nhật danh sách lớp thành công!");
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
                MessageBox.Show("Cập nhật danh sách lớp thành công!");

                var dsLop = from obj in dtb.LOPs
                            where obj.TenLop != null
                            select new { MaLop = obj.MaLop, TenLop = obj.TenLop };
                dgvDSLOP.DataSource = dsLop.ToList();
                dgvDSLOP.Show();
            }
        }
        private void EditLop_button_Click(object sender, EventArgs e)
        {
            string malop = dgvDSLOP.CurrentRow.Cells[0].Value.ToString();
            string tenlop = TenLoptextbox.Text;
            if (tenlop.Length != 4)
            {
                MessageBox.Show("Tên lớp không hợp lệ!");
                return;
            }
            using (var dtb = new dataEntities())
            {
                bool check_tenlop = true;
                var ds_tenlop = dtb.LOPs.Select(r => r.TenLop).ToList();
                for (int i = 0; i < ds_tenlop.Count;i++)
                {
                    if (ds_tenlop[i] == tenlop) { check_tenlop = false; break;}
                }
                if (check_tenlop)
                {
                    var std = dtb.LOPs.Where(r => r.MaLop == malop).First();
                    std.TenLop = TenLoptextbox.Text;
                    dtb.SaveChanges();
                    MessageBox.Show("Cập nhật danh sách lớp thành công!");
                }
                else MessageBox.Show("Tên lớp đã tồn tại!");
                var dsLop = from obj in dtb.LOPs
                            where obj.TenLop != null
                            select new { MaLop = obj.MaLop, TenLop = obj.TenLop };
                dgvDSLOP.DataSource = dsLop.ToList();
                dgvDSLOP.Show();
            }
        }

        //Thay đổi danh sách khối

        private void AddKhoi_button_Click(object sender, EventArgs e)
        {
            string tenkhoi = TenKhoitextbox.Text;
            string makhoi = "22" + tenkhoi;
            if(tenkhoi.Length==0)
            {
                MessageBox.Show("Tên khối không hợp lệ!");
                return;
            }
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
                    MessageBox.Show("Cập nhật danh sách khối thành công!");

                }
                else if (!check_tenkhoi) MessageBox.Show("Tên khối đã tồn tại!");
                else if (!check_makhoi)
                {
                    var std = dtb.KHOIs.Where(r => r.MaKhoi == makhoi).First();
                    std.TenKhoi = tenkhoi;
                    dtb.SaveChanges();
                    MessageBox.Show("Cập nhật danh sách khối thành công!");
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
            if (tenkhoi.Length == 0)
            {
                MessageBox.Show("Tên khối không hợp lệ!");
                return;
            }
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
                    MessageBox.Show("Cập nhật danh sách khối thành công!");
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
            MessageBox.Show("Cập nhật danh sách khối thành công!");
        }

        //Thay đổi danh sách môn học

        private void AddMonhoc_button_Click(object sender, EventArgs e)
        {
            string tenmh = Tenmhtextbox.Text;
            if(tenmh.Length == 0)
            {
                MessageBox.Show("Tên môn học không hợp lệ!");
                return;
            }
            string[] words = tenmh.Split(' ');
            string mamh = "";
            if (words.Length > 2) mamh = words[0].Substring(0, 1).ToUpper() + words[1].Substring(0, 1).ToUpper() + words[words.Length-1];
            else if (words.Length == 2) mamh = words[0].Substring(0, 2) + words[words.Length -1];
            using (var dtb = new dataEntities())
            {
                var ds_mamh = dtb.MONHOCs.Select(r => r.MaMonHoc).ToList();
                var ds_tenmh = dtb.MONHOCs.Select(r => r.TenMonHoc).ToList();
                bool check_tenmh = true;
                bool check_mamh = true;
                for (int i = 0; i < ds_mamh.Count; i++)
                {
                    if (ds_mamh[i] == mamh) { check_mamh = false; }
                    if (ds_tenmh[i] == tenmh) { check_tenmh = false; }
                }
                if (check_tenmh && check_mamh)
                {
                    MONHOC new_item = new MONHOC();
                    new_item.TenMonHoc = tenmh;
                    new_item.MaMonHoc = mamh;
                    dtb.MONHOCs.Add(new_item);
                    dtb.SaveChanges();
                    MessageBox.Show("Cập nhật danh sách môn học thành công!");
                }
                else if (!check_tenmh) MessageBox.Show("Tên khối đã tồn tại!");
                else if (!check_mamh)
                {
                    var std = dtb.MONHOCs.Where(r => r.MaMonHoc == mamh).First();
                    std.TenMonHoc = tenmh;
                    dtb.SaveChanges();
                    MessageBox.Show("Cập nhật danh sách môn học thành công!");
                }
                var dsMonhoc = from obj in dtb.MONHOCs
                             where obj.TenMonHoc != null
                             select new { MaMonHoc = obj.MaMonHoc, TenMonHoc = obj.TenMonHoc };
                dgvDSMONHOC.DataSource = dsMonhoc.ToList();
                dgvDSMONHOC.Show();
            }
        }
        private void EditMonhoc_button_Click(object sender, EventArgs e)
        {
            string mamh = dgvDSMONHOC.CurrentRow.Cells[0].Value.ToString();
            string tenmh = Tenmhtextbox.Text;
            if (tenmh.Length == 0)
            {
                MessageBox.Show("Tên môn học không hợp lệ!");
                return;
            }
            using (var dtb = new dataEntities())
            {
                var ds_tenmh = dtb.MONHOCs.Select(r => r.TenMonHoc).ToList();
                bool check_tenmh = true;
                for (int i = 0; i < ds_tenmh.Count; i++)
                {
                    if (ds_tenmh[i] == tenmh) { check_tenmh = false; break; }
                }
                if (check_tenmh)
                {
                    var std = dtb.MONHOCs.Where(r => r.MaMonHoc == mamh).First();
                    std.TenMonHoc = Tenmhtextbox.Text;
                    dtb.SaveChanges();
                    MessageBox.Show("Cập nhật danh sách môn học thành công!");
                }
                else MessageBox.Show("Môn học đã tồn tại!");
                var dsMonhoc = from obj in dtb.MONHOCs
                               where obj.TenMonHoc != null
                               select new { MaMonHoc = obj.MaMonHoc, TenMonHoc = obj.TenMonHoc };
                dgvDSMONHOC.DataSource = dsMonhoc.ToList();
                dgvDSMONHOC.Show();
            }
        }
        private void DeleteMonhoc_button_Click(object sender, EventArgs e)
        {
            string mamh = dgvDSMONHOC.CurrentRow.Cells[0].Value.ToString();
            using (var dtb = new dataEntities())
            {
                var std = dtb.MONHOCs.Where(r => r.MaMonHoc == mamh).First();
                std.TenMonHoc = null;
                dtb.SaveChanges();
                var dsMonhoc = from obj in dtb.MONHOCs
                             where obj.TenMonHoc != null
                             select new { MaKhoi = obj.MaMonHoc, TenKhoi = obj.TenMonHoc };
                dgvDSMONHOC.DataSource = dsMonhoc.ToList();
                dgvDSMONHOC.Show();
            }
            MessageBox.Show("Cập nhật danh sách môn học thành công!");
        }
        //Thay đổi danh sách điểm thành phần
        private void AddDiemTP_button_Click(object sender, EventArgs e)
        {
            string tentp = TenTPtextbox.Text;
            string[] words = tentp.Split(' ');
            string matp = "";
            double trongso = Convert.ToDouble(TrongsoTPtextbox.Text);
            if(trongso < 0.1 || trongso > 1)
            {
                MessageBox.Show("Trọng số không hợp lệ!");
                return;
            }
            if (words.Length >= 1)
            {
                for (int i = 0; i < words.Length; i++)
                    matp += words[i].Substring(0, 1).ToUpper();
            }
            else if (words.Length == 1) matp = words[0];
            else
            {
                MessageBox.Show("Tên thành phần không hợp lệ!");
                return;
            }
            using (var dtb = new dataEntities())
            {
                var ds_matp = dtb.THANHPHANs.Select(r => r.MaThanhPhan).ToList();
                var ds_tentp = dtb.THANHPHANs.Select(r => r.TenThanhPhan).ToList();
                bool check_tentp = true;
                bool check_matp = true;
                for (int i = 0; i < ds_matp.Count; i++)
                {
                    if (ds_matp[i] == matp) { check_matp = false; }
                    if (ds_tentp[i] == tentp) { check_tentp = false; }
                }
                if (check_tentp && check_matp)
                {
                    THANHPHAN new_item = new THANHPHAN();
                    new_item.TenThanhPhan = tentp;
                    new_item.MaThanhPhan = matp;
                    new_item.TrongSo = trongso;
                    dtb.THANHPHANs.Add(new_item);
                    dtb.SaveChanges();
                    MessageBox.Show("Cập nhật danh sách điểm thành phần thành công!");
                }
                else if (!check_tentp) MessageBox.Show("Tên khối đã tồn tại!");
                else if (!check_matp)
                {
                    var std = dtb.THANHPHANs.Where(r => r.MaThanhPhan == matp).First();
                    std.TenThanhPhan = tentp;
                    dtb.SaveChanges();
                    MessageBox.Show("Cập nhật danh sách điểm thành phần thành công!");
                }
                var dsDiemTP = from obj in dtb.THANHPHANs
                               where obj.TenThanhPhan != null
                               select new { MaThanhPhan = obj.MaThanhPhan, TenThanhPhan = obj.TenThanhPhan, TrongSo = obj.TrongSo };
                dgvDiemthanhphan.DataSource = dsDiemTP.ToList();
                dgvDiemthanhphan.Show();
            }
        }
        private void EditDiemTP_button_Click(object sender, EventArgs e)
        {
            string tentp = TenTPtextbox.Text;
            string matp = dgvDiemthanhphan.CurrentRow.Cells[0].Value.ToString();
            double trongso = Convert.ToDouble(TrongsoTPtextbox.Text);
            if (trongso < 0.1 || trongso > 1)
            {
                MessageBox.Show("Trọng số không hợp lệ!");
                return;
            }
            if(tentp == "")
            {
                MessageBox.Show("Tên thành phần không hợp lệ!");
                return;
            }
            using (var dtb = new dataEntities())
            {
                var ds_tentp = dtb.THANHPHANs.Select(r => r.TenThanhPhan).ToList();

                if (tentp == dgvDiemthanhphan.CurrentRow.Cells[1].Value.ToString())
                {
                    var std = dtb.THANHPHANs.Where(r => r.MaThanhPhan == matp).First();
                    std.TenThanhPhan = TenTPtextbox.Text;
                    std.TrongSo = trongso;
                    dtb.SaveChanges();
                    MessageBox.Show("Cập nhật danh sách điểm thành phần thành công!");
                }
                else MessageBox.Show("Không thể thay đổi tên thành phần.");
                var dsDiemTP = from obj in dtb.THANHPHANs
                               where obj.TenThanhPhan != null
                               select new { MaThanhPhan = obj.MaThanhPhan, TenThanhPhan = obj.TenThanhPhan, TrongSo = obj.TrongSo };
                dgvDiemthanhphan.DataSource = dsDiemTP.ToList();
                dgvDiemthanhphan.Show();
            }
        }
        private void DeleteDiemTP_button_Click(object sender, EventArgs e)
        {
            string matp = dgvDiemthanhphan.CurrentRow.Cells[0].Value.ToString();
            using (var dtb = new dataEntities())
            {
                var std = dtb.THANHPHANs.Where(r => r.MaThanhPhan == matp).First();
                std.TenThanhPhan = null;
                std.TrongSo = 0;
                dtb.SaveChanges();
                var dsDiemTP = from obj in dtb.THANHPHANs
                               where obj.TenThanhPhan != null
                               select new { MaThanhPhan = obj.MaThanhPhan, TenThanhPhan = obj.TenThanhPhan, TrongSo = obj.TrongSo };
                dgvDiemthanhphan.DataSource = dsDiemTP.ToList();
                dgvDiemthanhphan.Show();
            }
            MessageBox.Show("Cập nhật danh sách môn học thành công!");
        }
        //Thay đổi danh sách xếp loại
        private void AddXeploai_button_Click(object sender, EventArgs e)
        {
            string tenxl = Tenxeploaitextbox.Text;
            string[] words = tenxl.Split(' ');
            string maxl = "";
            double DiemToiThieu = Convert.ToDouble(minDiemtextbox.Text);
            double DiemToiDa = Convert.ToDouble(maxDiemtextbox.Text);
            double DiemKC = Convert.ToDouble(DiemKCtextbox.Text);
            string namhoc = Namhoctextbox.Text;
            if (DiemToiThieu < 0 || DiemToiThieu > 10 || DiemToiDa < 0 || DiemToiDa > 10 || DiemKC < 0 || DiemKC > 10)
            {
                MessageBox.Show("Gía trị điểm không hợp lệ");
                return;
            }
            if (words.Length >= 1)
            {
                for (int i = 0; i < words.Length; i++)
                    maxl += words[i].Substring(0,1).ToUpper();
            }
            else
            {
                MessageBox.Show("Tên thành phần không hợp lệ!");
                return;
            }
            using (var dtb = new dataEntities())
            {
                var ds_maxl = dtb.XEPLOAIs.Select(r => r.MaXepLoai).ToList();
                var ds_tenxl = dtb.XEPLOAIs.Select(r => r.TenXepLoai).ToList();
                bool check_tenxl = true;
                bool check_maxl = true;
                for (int i = 0; i < ds_maxl.Count; i++)
                {
                    if (ds_maxl[i] == maxl) { check_maxl = false; }
                    if (ds_tenxl[i] == tenxl) { check_tenxl = false; }
                }
                if (check_tenxl && check_maxl)
                {
                    XEPLOAI new_item = new XEPLOAI();
                    new_item.TenXepLoai = tenxl;
                    new_item.MaXepLoai = maxl;
                    new_item.DiemToiThieu = DiemToiThieu;
                    new_item.DiemToiDa = DiemToiDa;
                    new_item.DiemKhongChe = DiemKC;
                    new_item.NamApDung = "NH" + namhoc[2] + namhoc[3] + namhoc[7] + namhoc[8];
                    dtb.XEPLOAIs.Add(new_item);
                    dtb.SaveChanges();
                    MessageBox.Show("Cập nhật danh sách học lực thành công!");
                }
                else if (!check_tenxl) MessageBox.Show("Tên học lực đã tồn tại!");
                else if (!check_maxl)
                {
                    var std = dtb.XEPLOAIs.Where(r => r.MaXepLoai == maxl).First();
                    std.TenXepLoai = tenxl;
                    dtb.SaveChanges();
                    MessageBox.Show("Cập nhật danh sách học lực thành công!");
                }
                var dsXeploai = from obj in dtb.XEPLOAIs
                                where obj.TenXepLoai != null
                                select new { MaXepLoai = obj.MaXepLoai, TenXepLoai = obj.TenXepLoai, DiemToiThieu = obj.DiemToiThieu, DiemToiDa = obj.DiemToiDa, DiemKhongChe = obj.DiemKhongChe };
                dgvXepLoai.DataSource = dsXeploai.ToList();
                dgvXepLoai.Show();
            }
        }
        private void EditXeploai_button_Click(object sender, EventArgs e)
        {
            string tenxl = Tenxeploaitextbox.Text;
            string maxl = dgvXepLoai.CurrentRow.Cells[0].Value.ToString();
            double DiemToiThieu = Convert.ToDouble(minDiemtextbox.Text);
            double DiemToiDa = Convert.ToDouble(maxDiemtextbox.Text);
            double DiemKC = Convert.ToDouble(DiemKCtextbox.Text);
            string namhoc = Namhoctextbox.Text;
            if (DiemToiThieu < 0 || DiemToiThieu > 10 || DiemToiDa < 0 || DiemToiDa > 10 || DiemKC < 0 || DiemKC > 10)
            {
                MessageBox.Show("Gía trị điểm không hợp lệ");
                return;
            }
            if (tenxl == "")
            {
                MessageBox.Show("Tên thành phần không hợp lệ!");
                return;
            }
            using (var dtb = new dataEntities())
            {
                var ds_tenxl = dtb.XEPLOAIs.Select(r => r.TenXepLoai).ToList();
                if(tenxl == dgvXepLoai.CurrentRow.Cells[1].Value.ToString())
                {
                    var std = dtb.XEPLOAIs.Where(r => r.MaXepLoai == maxl).First();
                    std.TenXepLoai = Tenxeploaitextbox.Text;
                    std.MaXepLoai = maxl;
                    std.DiemToiThieu = DiemToiThieu;
                    std.DiemToiDa = DiemToiDa;
                    std.DiemKhongChe = DiemKC;
                    dtb.SaveChanges();
                    MessageBox.Show("Cập nhật danh sách học lực thành công!");
                }
                else MessageBox.Show("Không thể thay đổi tên loại học lực.");
                var dsXeploai = from obj in dtb.XEPLOAIs
                                where obj.TenXepLoai != null
                                select new { MaXepLoai = obj.MaXepLoai, TenXepLoai = obj.TenXepLoai, DiemToiThieu = obj.DiemToiThieu, DiemToiDa = obj.DiemToiDa, DiemKhongChe = obj.DiemKhongChe };
                dgvXepLoai.DataSource = dsXeploai.ToList();
                dgvXepLoai.Show();
            }
        }
        private void DeleteXeploai_button_Click(object sender, EventArgs e)
        {
            string maxl = dgvXepLoai.CurrentRow.Cells[0].Value.ToString();
            using (var dtb = new dataEntities())
            {
                var std = dtb.XEPLOAIs.Where(r => r.MaXepLoai == maxl).First();
                std.TenXepLoai = null;
                dtb.SaveChanges();
                var dsXeploai = from obj in dtb.XEPLOAIs
                                where obj.TenXepLoai != null
                                select new { MaXepLoai = obj.MaXepLoai, TenXepLoai = obj.TenXepLoai, DiemToiThieu = obj.DiemToiThieu, DiemToiDa = obj.DiemToiDa, DiemKhongChe = obj.DiemKhongChe };
                dgvXepLoai.DataSource = dsXeploai.ToList();
                dgvXepLoai.Show();
            }
            MessageBox.Show("Cập nhật danh sách học lực thành công!");
        }
        //Thay đổi danh sách học kỳ
        private void AddHocky_button_Click(object sender, EventArgs e)
        {
            string tenhk = HocKytextbox.Text;
            double trongso = Convert.ToDouble(TrongSoHKtextbox.Text);
            if (trongso < 1)
            {
                MessageBox.Show("Trọng số không hợp lệ!");
                return;
            }
            else if (tenhk == "")
            {
                MessageBox.Show("Tên thành phần không hợp lệ!");
                return;
            }
            using (var dtb = new dataEntities())
            {
                var mahk = dtb.HOCKies.Select(r => r).ToList().Count() + 1;
                var ds_tenhk = dtb.HOCKies.Select(r => r.HocKy1).ToList();
                bool check_tentp = true;
                for (int i = 0; i < ds_tenhk.Count; i++)
                {
                    if (ds_tenhk[i] == tenhk) { check_tentp = false; }
                }
                if (check_tentp)
                {
                    HOCKY new_item = new HOCKY();
                    new_item.HocKy1 = tenhk;
                    new_item.MaHocKy = mahk.ToString();
                    new_item.TrongSo = trongso;
                    dtb.HOCKies.Add(new_item);
                    dtb.SaveChanges();
                    MessageBox.Show("Cập nhật danh sách học kỳ thành công!");
                }
                else if (!check_tentp) MessageBox.Show("Tên học kỳ đã tồn tại!");
                var dsDiemHK = from obj in dtb.HOCKies
                               where obj.HocKy1 != null
                               select new { MaHocKy = obj.MaHocKy, HocKy1 = obj.HocKy1, TrongSo = obj.TrongSo };
                dgvDiemHK.DataSource = dsDiemHK.ToList();
                dgvDiemHK.Show();
            }
        }
        private void EditHocky_button_Click(object sender, EventArgs e)
        {
            string tenhk = HocKytextbox.Text;
            string mahk = dgvDiemHK.CurrentRow.Cells[0].Value.ToString();
            double trongso = Convert.ToDouble(TrongSoHKtextbox.Text);
            if (trongso < 1)
            {
                MessageBox.Show("Trọng số không hợp lệ!");
                return;
            }
            if (tenhk == "")
            {
                MessageBox.Show("Tên học kỳ không hợp lệ!");
                return;
            }
            using (var dtb = new dataEntities())
            {
                var ds_tenhk = dtb.HOCKies.Select(r => r.HocKy1).ToList();

                if (tenhk == dgvDiemHK.CurrentRow.Cells[1].Value.ToString())
                {
                    var std = dtb.HOCKies.Where(r => r.MaHocKy == mahk).First();
                    std.HocKy1 = HocKytextbox.Text;
                    std.TrongSo = trongso;
                    dtb.SaveChanges();
                    MessageBox.Show("Cập nhật danh sách học kỳ thành công!");
                }
                else MessageBox.Show("Không thể thay đổi tên học kỳ.");
                var dsDiemHK = from obj in dtb.HOCKies
                               where obj.HocKy1 != null
                               select new { MaHocKy = obj.MaHocKy, HocKy1 = obj.HocKy1, TrongSo = obj.TrongSo };
                dgvDiemHK.DataSource = dsDiemHK.ToList();
                dgvDiemHK.Show();
            }
        }
        private void DeleteHocky_button_Click(object sender, EventArgs e)
        {
            string mahk = dgvDiemHK.CurrentRow.Cells[0].Value.ToString();
            using (var dtb = new dataEntities())
            {
                var std = dtb.HOCKies.Where(r => r.MaHocKy == mahk).First();
                std.HocKy1 = null;
                dtb.SaveChanges();
                var dsDiemHK = from obj in dtb.HOCKies
                               where obj.HocKy1 != null
                               select new { MaHocKy = obj.MaHocKy, HocKy1 = obj.HocKy1, TrongSo = obj.TrongSo };
                dgvDiemHK.DataSource = dsDiemHK.ToList();
                dgvDiemHK.Show();
            }
            MessageBox.Show("Cập nhật danh sách học kỳ thành công!");
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
        private void guna2ImageButtonHome_Click(object sender, EventArgs e)
        {
            this.Close();
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
