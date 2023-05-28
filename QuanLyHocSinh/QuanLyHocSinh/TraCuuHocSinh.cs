using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Cryptography;

namespace QuanLyHocSinh
{
    public partial class TraCuuHocSinh : Form
    {
        public TraCuuHocSinh()
        {
            InitializeComponent();
            pnStudent_info.Hide();
            pnDadofStudent_Info.Hide();
            pnMomOfStudent_Info.Hide();
            lbThongTinPhuHuynh.Hide();
            cbKhoi.Text = "----- Chọn khối -----";
            cbLop.Text = "----- Chọn lớp -----";

            dataEntities data = new dataEntities();
            var CBKhoi = from obj in data.KHOIs
                         select obj;
            cbKhoi.DataSource = CBKhoi.ToList();
            cbKhoi.DisplayMember = "TenKhoi";
            cbKhoi.ValueMember = "TenKhoi";

        }

        void TraCuuHS ()
        {
            dataEntities db = new dataEntities();

            if (tbStudentID == null && tbFindEmail == null && tbFindName == null && tbFindPhoneNum == null && cbKhoi == null)
            {
                MessageBox.Show("Không có dữ liệu để tra cứu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (tbStudentID == null)
            {
                MessageBox.Show("Cần nhập trường dữ liệu mã số học sinh để tra cứu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (tbFindName == null)
            {
                MessageBox.Show("Cần nhập trường dữ liệu họ tên học sinh để tra cứu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cbLop == null)
            {
                MessageBox.Show("Cần nhập trường dữ liệu khối và lớp học sinh để tra cứu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (tbStudentID != null && tbFindName != null && cbLop != null)
            {
                var result = from iter1 in db.HOCSINHs
                             join iter2 in db.CTLOPs on iter1.MaHocSinh equals iter2.MaHocSinh
                             join iter3 in db.LOPs on iter2.MaLop equals iter3.MaLop
                             where iter1.MaHocSinh == tbStudentID.Text && iter1.HoTen == tbFindName.Text && iter3.TenLop == cbLop.SelectedValue.ToString()
                             select iter1.MaHocSinh;

                if (result.Count() == 0)
                {
                    MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (tbStudentID != null && tbFindName != null && cbLop != null && tbFindEmail != null)
            {
                var result = from iter1 in db.HOCSINHs
                             join iter2 in db.CTLOPs on iter1.MaHocSinh equals iter2.MaHocSinh
                             join iter3 in db.LOPs on iter2.MaLop equals iter3.MaLop
                             where iter1.MaHocSinh == tbStudentID.Text && iter1.HoTen == tbFindName.Text && iter3.TenLop == cbLop.SelectedValue.ToString() && iter1.Email == tbFindEmail.Text
                             select iter1.MaHocSinh;
                if (result.Count() == 0)
                {
                    MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (tbStudentID != null && tbFindName != null && cbLop != null && tbFindPhoneNum != null)
            {
                var result = from iter1 in db.HOCSINHs
                             join iter2 in db.CTLOPs on iter1.MaHocSinh equals iter2.MaHocSinh
                             join iter3 in db.LOPs on iter2.MaLop equals iter3.MaLop
                             where iter1.MaHocSinh == tbStudentID.Text && iter1.HoTen == tbFindName.Text && iter3.TenLop == cbLop.SelectedValue.ToString() && iter1.SDT == tbFindPhoneNum.Text
                             select iter1.MaHocSinh;
                if (result.Count() == 0)
                {
                    MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (tbStudentID != null && tbFindName != null && cbLop != null && tbFindEmail != null && tbFindPhoneNum != null)
            {
                var result = from iter1 in db.HOCSINHs
                             join iter2 in db.CTLOPs on iter1.MaHocSinh equals iter2.MaHocSinh
                             join iter3 in db.LOPs on iter2.MaLop equals iter3.MaLop
                             where iter1.MaHocSinh == tbStudentID.Text && iter1.HoTen == tbFindName.Text && iter3.TenLop == cbLop.SelectedValue.ToString() && iter1.Email == tbFindEmail.Text && iter1.SDT == tbFindPhoneNum.Text
                             select iter1.MaHocSinh;
                if (result.Count() == 0)
                {
                    MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
                
             var result1 = from iter1 in db.HOCSINHs
                          join iter2 in db.CTLOPs on iter1.MaHocSinh equals iter2.MaHocSinh
                          join iter3 in db.LOPs on iter2.MaLop equals iter3.MaLop
                          where iter1.MaHocSinh == tbStudentID.Text
                          select new
                          {
                                 name = iter1.HoTen,
                                 class_name = iter3.TenLop,
                                 sex = iter1.GioiTinh,
                                 dob = iter1.NgaySinh,
                                 ethnic = iter1.DanToc,
                                 religion = iter1.TonGiao,
                                 hometown = iter1.QueQuan,
                                 address = iter1.DiaChi,
                                 phone_num = iter1.SDT,
                                 email = iter1.Email,

                                 name_dad = iter1.HoTenCha,
                                 phonenum_dad = iter1.SDT_Cha,
                                 yearbirth_dad = iter1.NamSinh_Cha,
                                 job_dad = iter1.NgheNghiep_Cha,
                                 id_dad = iter1.CCCD_Cha,

                                 name_mom = iter1.HoTenMe,
                                 phonenum_mom = iter1.SDT_Me,
                                 yearbirth_mom = iter1.NamSinh_Me,
                                 job_mom = iter1.NgheNghiep_Me,
                                 id_mom = iter1.CCCD_Me,
                          };

                foreach (var item in result1)
                {
                    //Thông tin cá nhân của học sinh
                    tbHoTen.Text = item.name;
                    tbLop.Text = item.class_name;
                    tbGioiTinh.Text = item.sex;

                    //Xử lý ngày tháng năm trong chuỗi có kiểu dữ liệu Datetime
                    string temp = item.dob.ToString();
                    Regex re = new Regex(@"[^ ]*"); 
                    Match m = re.Match(temp);
                    tbNgaySinh.Text = m.Groups[0].Value;

                    tbDanToc.Text = item.ethnic;
                    tbTonGiao.Text = item.religion;
                    tbQueQuan.Text = item.hometown;
                    tbDiaChi.Text = item.address;
                    tbSDT.Text = item.phone_num;
                    tbEmail.Text = item.email;

                    //Thông tin của cha của học sinh
                    if (item.name_dad != null)
                    {
                        tbHoTenCha.Text = item.name_dad;
                        tbCCCD_Cha.Text = item.id_dad;
                        tbSDT_Cha.Text = item.phonenum_dad;
                        tbNgheNghiep_Cha.Text = item.job_dad;
                        tbNamSinh_Cha.Text = item.yearbirth_dad.ToString();
                    }
                    else
                    {
                        tbHoTenCha.Text = "Không có thông tin";
                        tbCCCD_Cha.Text = "Không có thông tin";
                        tbSDT_Cha.Text = "Không có thông tin";
                        tbNgheNghiep_Cha.Text = "Không có thông tin";
                        tbNamSinh_Cha.Text = "Không có thông tin";
                    }

                    //Thông tin của mẹ của học sinh
                    if (item.name_mom != null) 
                    {
                        tbHoTenMe.Text = item.name_mom;
                        tbCCCD_Me.Text = item.id_mom;
                        tbSDT_Me.Text = item.phonenum_mom;
                        tbNgheNghiepMe.Text = item.job_mom; 
                        tbNamSinhMe.Text = item.yearbirth_mom.ToString();
                    }
                    else
                    {
                        tbHoTenMe.Text = "Không có thông tin";
                        tbCCCD_Me.Text = "Không có thông tin";
                        tbSDT_Me.Text = "Không có thông tin";
                        tbNgheNghiepMe.Text = "Không có thông tin";
                        tbNamSinhMe.Text = "Không có thông tin";
                    }                       
                }

                pnStudent_info.Show();
                lbThongTinPhuHuynh.Show();
                pnDadofStudent_Info.Show();
                pnMomOfStudent_Info.Show();
            }

        private void BtnFindInfoStudent_Click(object sender, EventArgs e)
        {
            TraCuuHS();
        }

        private void cbKhoi_SelectedValueChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox cb = sender as System.Windows.Forms.ComboBox;
            if (cb.SelectedValue != null)
            {
                dataEntities db = new dataEntities();
                var CBLop = from iter1 in db.KHOIs
                            join iter2 in db.LOPs on iter1.MaKhoi equals iter2.MaKhoi
                             select iter2.TenLop;
                cbLop.DataSource = CBLop.ToList();
            }    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbStudentID.Clear();
            tbFindName.Clear();
            tbFindEmail.Clear();
            tbFindPhoneNum.Clear();
            cbKhoi.ResetText();
            cbLop.ResetText();
        }
    }
}
