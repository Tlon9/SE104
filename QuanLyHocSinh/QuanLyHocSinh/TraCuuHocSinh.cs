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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace QuanLyHocSinh
{
    public partial class TraCuuHocSinh : Form
    {
        public TrangChu formTraCuu { get; set; }

        public TraCuuHocSinh(TrangChu mainform)
        {
            InitializeComponent();
            this.formTraCuu = mainform;
            tbFindName.Text = "";
            tbStudentID.Text = "";
            tbFindEmail.Text = "";
            tbFindPhoneNum.Text = "";
            pnStudent_info.Hide();
            pnDadofStudent_Info.Hide();
            pnMomOfStudent_Info.Hide();
            lbThongTinPhuHuynh.Hide();
            cbGrade.Text = "----- Chọn khối -----";
            cbClass.Text = "----- Chọn lớp -----";

            dataEntities data = new dataEntities();
            var CBKhoi = from obj in data.KHOIs
                         select obj;
            cbGrade.DataSource = CBKhoi.ToList();
            cbGrade.DisplayMember = "TenKhoi";
            cbGrade.ValueMember = "TenKhoi";
            cbGrade.ResetText();
            cbClass.ResetText();
            cbGrade.SelectedIndex = -1;
            cbClass.SelectedIndex = -1;
        }

        void TraCuuHS ()
        {
            dataEntities db = new dataEntities();

            if (tbStudentID.Text != "" && tbFindName.Text != "")
            {
                if (cbGrade.SelectedIndex != -1 && cbClass.SelectedIndex != -1 && tbFindEmail.Text != "" && tbFindPhoneNum.Text != "")
                {
                    var case1 = from iter1 in db.HOCSINHs
                                join iter2 in db.CTLOPs on iter1.MaHocSinh equals iter2.MaHocSinh
                                join iter3 in db.LOPs on iter2.MaLop equals iter3.MaLop
                                where iter1.MaHocSinh == tbStudentID.Text && iter1.HoTen == tbFindName.Text && iter3.TenLop == cbClass.SelectedValue.ToString() && iter1.Email == tbFindEmail.Text && iter1.SDT == tbFindPhoneNum.Text
                                select iter1.MaHocSinh;
                    if (case1.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }     
                else if (cbGrade.SelectedIndex != -1 && cbClass.SelectedIndex != -1 && tbFindEmail.Text != "")
                {
                    var case2 = from iter1 in db.HOCSINHs
                                join iter2 in db.CTLOPs on iter1.MaHocSinh equals iter2.MaHocSinh
                                join iter3 in db.LOPs on iter2.MaLop equals iter3.MaLop
                                where iter1.MaHocSinh == tbStudentID.Text && iter1.HoTen == tbFindName.Text && iter3.TenLop == cbClass.SelectedValue.ToString() && iter1.Email == tbFindEmail.Text
                                select iter1.MaHocSinh;
                    if (case2.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }   
                else if (cbGrade.SelectedIndex != -1 && cbClass.SelectedIndex != -1 && tbFindPhoneNum.Text != "")
                {
                    var case3 = from iter1 in db.HOCSINHs
                                join iter2 in db.CTLOPs on iter1.MaHocSinh equals iter2.MaHocSinh
                                join iter3 in db.LOPs on iter2.MaLop equals iter3.MaLop
                                where iter1.MaHocSinh == tbStudentID.Text && iter1.HoTen == tbFindName.Text && iter3.TenLop == cbClass.SelectedValue.ToString() && iter1.SDT == tbFindPhoneNum.Text
                                select iter1.MaHocSinh;
                    if (case3.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }      
                else if (tbFindEmail.Text != "" && tbFindPhoneNum.Text != "")
                {
                    var case4 = from iter in db.HOCSINHs
                                where iter.MaHocSinh == tbStudentID.Text && iter.HoTen == tbFindName.Text && iter.SDT == tbFindPhoneNum.Text && iter.Email == tbFindEmail.Text
                                select iter.MaHocSinh;
                    if (case4.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }   
                else if (cbGrade.SelectedIndex != -1 && cbClass.SelectedIndex != -1)
                {
                    var case5 = from iter1 in db.HOCSINHs
                                join iter2 in db.CTLOPs on iter1.MaHocSinh equals iter2.MaHocSinh
                                join iter3 in db.LOPs on iter2.MaLop equals iter3.MaLop
                                where iter1.MaHocSinh == tbStudentID.Text && iter1.HoTen == tbFindName.Text && iter3.TenLop == cbClass.SelectedValue.ToString()
                                select iter1.MaHocSinh;
                    if (case5.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }    
                else if (tbFindPhoneNum.Text != "")
                {
                    var case6 = from iter in db.HOCSINHs
                                where iter.MaHocSinh == tbStudentID.Text && iter.HoTen == tbFindName.Text && iter.SDT == tbFindPhoneNum.Text
                                select iter.MaHocSinh;
                    if (case6.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (tbFindEmail.Text != "")
                {
                    var case7 = from iter in db.HOCSINHs
                                where iter.MaHocSinh == tbStudentID.Text && iter.HoTen == tbFindName.Text && iter.Email == tbFindEmail.Text
                                select iter.MaHocSinh;
                    if (case7.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else 
                {
                    var case8 = from iter in db.HOCSINHs
                                where iter.MaHocSinh == tbStudentID.Text && iter.HoTen == tbFindName.Text
                                select iter.MaHocSinh;
                    if (case8.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }    
            }  
            else 
            {
                if (tbStudentID.Text == "" && tbFindEmail.Text == "" && tbFindName.Text == "" && tbFindPhoneNum.Text == "")
                {
                    MessageBox.Show("Không có thông tin để tra cứu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (tbStudentID.Text == "")
                {
                    MessageBox.Show("Cần nhập thông tin mã số học sinh để tra cứu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (tbFindName.Text == "")
                {
                    MessageBox.Show("Cần nhập thông tin họ tên học sinh để tra cứu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Sau khi kiểm tra đúng thì lấy thông tin của học sinh được tìm thấy
            tbFindName.ReadOnly = true;
            tbStudentID.ReadOnly = true;
            cbGrade.Enabled = false;
            cbClass.Enabled = false;
            tbFindEmail.ReadOnly = true;
            tbFindPhoneNum.ReadOnly = true;
            var result1 = from iter1 in db.HOCSINHs
                          join iter2 in db.CTLOPs on iter1.MaHocSinh equals iter2.MaHocSinh
                          join iter3 in db.LOPs on iter2.MaLop equals iter3.MaLop
                          where iter1.MaHocSinh == tbStudentID.Text && iter1.HoTen == tbFindName.Text
                          select new
                          {
                                 name = iter1.HoTen,
                                 idStudent = iter1.MaHocSinh,
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
                    tbMaSoHS.Text = item.idStudent;
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
                    if (item.name_dad != null)  tbHoTenCha.Text = item.name_dad;
                    else tbHoTenCha.Text = "Không có thông tin";

                    if (item.id_dad != null)    tbCCCD_Cha.Text = item.id_dad;
                    else tbCCCD_Cha.Text = "Không có thông tin";

                    if (item.phonenum_dad != null)     tbSDT_Cha.Text = item.phonenum_dad;
                    else tbSDT_Cha.Text = "Không có thông tin";

                    if (item.job_dad != null) tbNgheNghiep_Cha.Text = item.job_dad;
                    else tbNgheNghiep_Cha.Text = "Không có thông tin";

                    if (item.yearbirth_dad != null)     tbNamSinh_Cha.Text = item.yearbirth_dad.ToString();
                    else tbNamSinh_Cha.Text = "Không có thông tin";

                //Thông tin của mẹ của học sinh
                    if (item.name_mom != null)     tbHoTenMe.Text = item.name_mom;
                    else tbHoTenMe.Text = "Không có thông tin";

                    if (item.id_mom != null)    tbCCCD_Me.Text = item.id_mom;
                    else tbCCCD_Me.Text = "Không có thông tin";

                    if (item.phonenum_mom != null)  tbSDT_Me.Text = item.phonenum_mom;
                    else  tbSDT_Me.Text = "Không có thông tin";

                    if (item.job_mom != null)   tbNgheNghiepMe.Text = item.job_mom;
                    else tbNgheNghiepMe.Text = "Không có thông tin";

                    if ( item.yearbirth_mom != null)    tbNamSinhMe.Text = item.yearbirth_mom.ToString();
                    else tbNamSinhMe.Text = "Không có thông tin";                    
                }

                pnStudent_info.Show();
                lbThongTinPhuHuynh.Show();
                pnDadofStudent_Info.Show();
                pnMomOfStudent_Info.Show();
            }

        private void BtnFindInfoStu_Click(object sender, EventArgs e)
        {
            TraCuuHS();
        }

        private void cbGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox cb = sender as System.Windows.Forms.ComboBox;
            if (cb.SelectedValue != null)
            {
                var temp = cb.SelectedValue.ToString();
                dataEntities db = new dataEntities();

                var CBLop = from iter1 in db.LOPs
                            join iter2 in db.KHOIs on iter1.MaKhoi equals iter2.MaKhoi
                            where iter2.TenKhoi.ToString() == temp
                            select iter1.TenLop;

                cbClass.DataSource = CBLop.ToList();
                cbClass.DisplayMember = "TenLop";
            }
        }

        private void BtnRefresh1_Click(object sender, EventArgs e)
        {
            tbStudentID.Clear();
            tbStudentID.ReadOnly = false;
            tbStudentID.Text = "";

            tbFindName.Clear();
            tbFindName.ReadOnly = false;
            tbFindName.Text = "";

            tbFindEmail.Clear();
            tbFindEmail.ReadOnly = false;
            tbFindEmail.Text = "";

            tbFindPhoneNum.Clear();
            tbFindPhoneNum.ReadOnly = false;
            tbFindPhoneNum.Text = "";

            cbGrade.ResetText();
            cbGrade.SelectedIndex = -1;
            cbClass.ResetText();
            cbClass.SelectedIndex = -1;
            cbGrade.Enabled = true;
            cbClass.Enabled = true;

            pnStudent_info.Hide();
            lbThongTinPhuHuynh.Hide();
            pnDadofStudent_Info.Hide();
            pnMomOfStudent_Info.Hide();
        }


        private void guna2ImageButtonHome_Click(object sender, EventArgs e)
        {
            (this.formTraCuu as TrangChu).Show();
            this.Close();
        }

        private void Btn_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnProfileAccount_Click(object sender, EventArgs e)
        {
            TrangCaNhan newform = new TrangCaNhan();
            this.Hide();
            newform.ShowDialog();
            this.Show();
        }
    }
}