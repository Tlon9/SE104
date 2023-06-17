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
using System.Runtime.InteropServices;

namespace QuanLyHocSinh
{
    public partial class TraCuuHocSinh : Form
    {
        public TrangChu formTraCuu { get; set; }

        public TraCuuHocSinh(TrangChu mainform)
        {
            InitializeComponent();
            this.formTraCuu = mainform;
            TextBoxFindName.Text = "";
            TextBoxFindStudentID.Text = "";
            TextBoxFindEmail.Text = "";
            TextBoxFindPhoneNum.Text = "";
            PanelStudentInfo.Hide();
            PanelParentInfo.Hide();

            dataEntities data = new dataEntities();
            var CBNamHoc = from obj in data.NAMHOCs
                           select obj;
            ComboBoxFindSchoolYear.DataSource = CBNamHoc.ToList();
            ComboBoxFindSchoolYear.ValueMember = "NamHoc1";

            ComboBoxFindGrade.ResetText();
            ComboBoxClass.ResetText();
            ComboBoxFindSchoolYear.SelectedIndex = -1;
            ComboBoxFindGrade.SelectedIndex = -1;
            ComboBoxClass.SelectedIndex = -1;
            ComboBoxFindStudenID.Hide();
            ComboBoxFindStudenID.SelectedIndex = -1;
            PanelInstruction.Hide();
        }
        void ThongTinHS_byID (string id = "")
        {
            dataEntities db = new dataEntities();
            // Sau khi kiểm tra đúng thì lấy thông tin của học sinh được tìm thấy
            TextBoxFindName.ReadOnly = true;
            TextBoxFindStudentID.ReadOnly = true;
            ComboBoxFindSchoolYear.Enabled = false;
            ComboBoxFindGrade.Enabled = false;
            ComboBoxClass.Enabled = false;
            TextBoxFindEmail.ReadOnly = true;
            TextBoxFindPhoneNum.ReadOnly = true;
            ComboBoxFindStudenID.Enabled = false;
            var result1 = from iter1 in db.HOCSINHs
                          join iter2 in db.CTLOPs on iter1.MaHocSinh equals iter2.MaHocSinh
                          join iter3 in db.LOPs on iter2.MaLop equals iter3.MaLop
                          where iter1.MaHocSinh == id
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
                TextBoxStudentID.Text = item.idStudent;
                TextBoxStudentName.Text = item.name;
                TextBoxStudentClass.Text = item.class_name;
                TextBoxStudentSex.Text = item.sex;
                TextBoxStudentAddress.Text = item.address;
                TextBoxStudentPhoneNumber.Text = item.phone_num;

                //Xử lý ngày tháng năm trong chuỗi có kiểu dữ liệu Datetime
                string temp = item.dob.ToString();
                Regex re = new Regex(@"[^ ]*");
                Match m = re.Match(temp);
                TextBoxStudentDOB.Text = m.Groups[0].Value;

                if (item.ethnic != null) TextBoxStudentEthnic.Text = item.ethnic;
                else TextBoxStudentEthnic.Text = "Không có thông tin";

                if (item.religion != null) TextBoxStudentReligion.Text = item.religion;
                else TextBoxStudentReligion.Text = "Không có thông tin";

                if (item.hometown != null) TextBoxStudentHometown.Text = item.hometown;
                else TextBoxStudentHometown.Text = "Không có thông tin";

                if (item.email != null) TextBoxStudentEmail.Text = item.email;
                else TextBoxStudentEmail.Text = "Không có thông tin";

                //Thông tin của cha của học sinh
                if (item.name_dad != null) TextBoxStudent_DadName.Text = item.name_dad;
                else TextBoxStudent_DadName.Text = "Không có thông tin";

                if (item.id_dad != null) TextBoxStudent_DadID.Text = item.id_dad;
                else TextBoxStudent_DadID.Text = "Không có thông tin";

                if (item.phonenum_dad != null) TextBoxStudent_DadPhoneNumber.Text = item.phonenum_dad;
                else TextBoxStudent_DadPhoneNumber.Text = "Không có thông tin";

                if (item.job_dad != null) TextBoxStudent_DadJob.Text = item.job_dad;
                else TextBoxStudent_DadJob.Text = "Không có thông tin";

                if (item.yearbirth_dad != null) TextBoxStudent_DadYOB.Text = item.yearbirth_dad.ToString();
                else TextBoxStudent_DadYOB.Text = "Không có thông tin";

                //Thông tin của mẹ của học sinh
                if (item.name_mom != null) TextBoxStudent_MomName.Text = item.name_mom;
                else TextBoxStudent_MomName.Text = "Không có thông tin";

                if (item.id_mom != null) TextBoxStudent_MomID.Text = item.id_mom;
                else TextBoxStudent_MomID.Text = "Không có thông tin";

                if (item.phonenum_mom != null) TextBoxStudent_MomPhoneNumber.Text = item.phonenum_mom;
                else TextBoxStudent_MomPhoneNumber.Text = "Không có thông tin";

                if (item.job_mom != null) TextBoxStudent_MomJob.Text = item.job_mom;
                else TextBoxStudent_MomJob.Text = "Không có thông tin";

                if (item.yearbirth_mom != null) TextBoxStudent_MomYOB.Text = item.yearbirth_mom.ToString();
                else TextBoxStudent_MomYOB.Text = "Không có thông tin";
            }
            PanelStudentInfo.Show();
            LabelNameStudentInfo.Show();
            PanelDadInfo.Show();
            PanelMomInfo.Show();
            PanelParentInfo.Show();
        }
        void ThongTinHS_byName (string name = "")
        {
            dataEntities db = new dataEntities();
            // Sau khi kiểm tra đúng thì lấy thông tin của học sinh được tìm thấy
            TextBoxFindName.ReadOnly = true;
            TextBoxFindStudentID.ReadOnly = true;
            ComboBoxFindSchoolYear.Enabled = false;
            ComboBoxFindGrade.Enabled = false;
            ComboBoxClass.Enabled = false;
            TextBoxFindEmail.ReadOnly = true;
            TextBoxFindPhoneNum.ReadOnly = true;
            ComboBoxFindStudenID.Enabled = false;
            var result1 = from iter1 in db.HOCSINHs
                          join iter2 in db.CTLOPs on iter1.MaHocSinh equals iter2.MaHocSinh
                          join iter3 in db.LOPs on iter2.MaLop equals iter3.MaLop
                          where iter1.HoTen == name
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
                TextBoxStudentID.Text = item.idStudent;
                TextBoxStudentName.Text = item.name;
                TextBoxStudentClass.Text = item.class_name;
                TextBoxStudentSex.Text = item.sex;
                TextBoxStudentAddress.Text = item.address;
                //tbSDT.Text = item.phone_num;
                TextBoxStudentEmail.Text = item.email;

                //Xử lý ngày tháng năm trong chuỗi có kiểu dữ liệu Datetime
                string temp = item.dob.ToString();
                Regex re = new Regex(@"[^ ]*");
                Match m = re.Match(temp);
                TextBoxStudentDOB.Text = m.Groups[0].Value;

                if (item.ethnic != null) TextBoxStudentEthnic.Text = item.ethnic;
                else TextBoxStudentEthnic.Text = "Không có thông tin";

                if (item.religion != null) TextBoxStudentReligion.Text = item.religion;
                else TextBoxStudentReligion.Text = "Không có thông tin";

                if (item.hometown != null) TextBoxStudentHometown.Text = item.hometown;
                else TextBoxStudentHometown.Text = "Không có thông tin";

                if (item.phone_num != null) TextBoxStudentPhoneNumber.Text = item.phone_num;
                else TextBoxStudentPhoneNumber.Text = "Không có thông tin";

                //Thông tin của cha của học sinh
                if (item.name_dad != null) TextBoxStudent_DadName.Text = item.name_dad;
                else TextBoxStudent_DadName.Text = "Không có thông tin";

                if (item.id_dad != null) TextBoxStudent_DadID.Text = item.id_dad;
                else TextBoxStudent_DadID.Text = "Không có thông tin";

                if (item.phonenum_dad != null) TextBoxStudent_DadPhoneNumber.Text = item.phonenum_dad;
                else TextBoxStudent_DadPhoneNumber.Text = "Không có thông tin";

                if (item.job_dad != null) TextBoxStudent_DadJob.Text = item.job_dad;
                else TextBoxStudent_DadJob.Text = "Không có thông tin";

                if (item.yearbirth_dad != null) TextBoxStudent_DadYOB.Text = item.yearbirth_dad.ToString();
                else TextBoxStudent_DadYOB.Text = "Không có thông tin";

                //Thông tin của mẹ của học sinh
                if (item.name_mom != null) TextBoxStudent_MomName.Text = item.name_mom;
                else TextBoxStudent_MomName.Text = "Không có thông tin";

                if (item.id_mom != null) TextBoxStudent_MomID.Text = item.id_mom;
                else TextBoxStudent_MomID.Text = "Không có thông tin";

                if (item.phonenum_mom != null) TextBoxStudent_MomPhoneNumber.Text = item.phonenum_mom;
                else TextBoxStudent_MomPhoneNumber.Text = "Không có thông tin";

                if (item.job_mom != null) TextBoxStudent_MomJob.Text = item.job_mom;
                else TextBoxStudent_MomJob.Text = "Không có thông tin";

                if (item.yearbirth_mom != null) TextBoxStudent_MomYOB.Text = item.yearbirth_mom.ToString();
                else TextBoxStudent_MomYOB.Text = "Không có thông tin";
            }
            PanelStudentInfo.Show();
            LabelNameStudentInfo.Show();
            PanelDadInfo.Show();
            PanelMomInfo.Show();
            PanelParentInfo.Show();
        }
        void TraCuuHS()
        {
            dataEntities db = new dataEntities();
            //Tra cứu theo mã số học sinh
            if (TextBoxFindStudentID.Text != "")
            {
                if (TextBoxFindName.Text != "" && ComboBoxFindGrade.SelectedIndex != -1 && ComboBoxClass.SelectedIndex != -1 && TextBoxFindEmail.Text != "" && TextBoxFindPhoneNum.Text != "")
                {
                    var case1 = from iter1 in db.HOCSINHs
                                join iter2 in db.CTLOPs on iter1.MaHocSinh equals iter2.MaHocSinh
                                join iter3 in db.LOPs on iter2.MaLop equals iter3.MaLop
                                where iter1.MaHocSinh == TextBoxFindStudentID.Text && iter1.HoTen == TextBoxFindName.Text && iter3.TenLop == ComboBoxClass.SelectedValue.ToString() && iter1.Email == TextBoxFindEmail.Text && iter1.SDT == TextBoxFindPhoneNum.Text
                                select iter1.MaHocSinh;
                    if (case1.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        ThongTinHS_byID(TextBoxFindStudentID.Text);
                    }
                }
                else if (TextBoxFindName.Text != "" && ComboBoxFindGrade.SelectedIndex != -1 && ComboBoxClass.SelectedIndex != -1 && TextBoxFindEmail.Text != "")
                {
                    var case2 = from iter1 in db.HOCSINHs
                                join iter2 in db.CTLOPs on iter1.MaHocSinh equals iter2.MaHocSinh
                                join iter3 in db.LOPs on iter2.MaLop equals iter3.MaLop
                                where iter1.MaHocSinh == TextBoxFindStudentID.Text && iter1.HoTen == TextBoxFindName.Text && iter3.TenLop == ComboBoxClass.SelectedValue.ToString() && iter1.Email == TextBoxFindEmail.Text
                                select iter1.MaHocSinh;
                    if (case2.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else { ThongTinHS_byID(TextBoxFindStudentID.Text); }

                }
                else if (TextBoxFindName.Text != "" && ComboBoxFindGrade.SelectedIndex != -1 && ComboBoxClass.SelectedIndex != -1 && TextBoxFindPhoneNum.Text != "")
                {
                    var case3 = from iter1 in db.HOCSINHs
                                join iter2 in db.CTLOPs on iter1.MaHocSinh equals iter2.MaHocSinh
                                join iter3 in db.LOPs on iter2.MaLop equals iter3.MaLop
                                where iter1.MaHocSinh == TextBoxFindStudentID.Text && iter1.HoTen == TextBoxFindName.Text && iter3.TenLop == ComboBoxClass.SelectedValue.ToString() && iter1.SDT == TextBoxFindPhoneNum.Text
                                select iter1.MaHocSinh;
                    if (case3.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else { ThongTinHS_byID(TextBoxFindStudentID.Text); }
                }
                else if (TextBoxFindName.Text != "" && TextBoxFindEmail.Text != "" && TextBoxFindPhoneNum.Text != "")
                {
                    var case4 = from iter in db.HOCSINHs
                                where iter.MaHocSinh == TextBoxFindStudentID.Text && iter.HoTen == TextBoxFindName.Text && iter.SDT == TextBoxFindPhoneNum.Text && iter.Email == TextBoxFindEmail.Text
                                select iter.MaHocSinh;
                    if (case4.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else { ThongTinHS_byID(TextBoxFindStudentID.Text); }
                }
                else if (TextBoxFindName.Text != "" && ComboBoxFindGrade.SelectedIndex != -1 && ComboBoxClass.SelectedIndex != -1)
                {
                    var case5 = from iter1 in db.HOCSINHs
                                join iter2 in db.CTLOPs on iter1.MaHocSinh equals iter2.MaHocSinh
                                join iter3 in db.LOPs on iter2.MaLop equals iter3.MaLop
                                where iter1.MaHocSinh == TextBoxFindStudentID.Text && iter1.HoTen == TextBoxFindName.Text && iter3.TenLop == ComboBoxClass.SelectedValue.ToString()
                                select iter1.MaHocSinh;
                    if (case5.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else { ThongTinHS_byID(TextBoxFindStudentID.Text); }
                }
                else if (TextBoxFindName.Text != "" && TextBoxFindPhoneNum.Text != "")
                {
                    var case6 = from iter in db.HOCSINHs
                                where iter.MaHocSinh == TextBoxFindStudentID.Text && iter.HoTen == TextBoxFindName.Text && iter.SDT == TextBoxFindPhoneNum.Text
                                select iter.MaHocSinh;
                    if (case6.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else { ThongTinHS_byID(TextBoxFindStudentID.Text); }
                }
                else if (TextBoxFindName.Text != "" && TextBoxFindEmail.Text != "")
                {
                    var case7 = from iter in db.HOCSINHs
                                where iter.MaHocSinh == TextBoxFindStudentID.Text && iter.HoTen == TextBoxFindName.Text && iter.Email == TextBoxFindEmail.Text
                                select iter.MaHocSinh;
                    if (case7.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else { ThongTinHS_byID(TextBoxFindStudentID.Text); }
                }
                else if (ComboBoxFindGrade.SelectedIndex != -1 && ComboBoxClass.SelectedIndex != -1 && TextBoxFindEmail.Text != "" && TextBoxFindPhoneNum.Text != "")
                {
                    var case8 = from iter1 in db.HOCSINHs
                                join iter2 in db.CTLOPs on iter1.MaHocSinh equals iter2.MaHocSinh
                                join iter3 in db.LOPs on iter2.MaLop equals iter3.MaLop
                                where iter1.MaHocSinh == TextBoxFindStudentID.Text && iter3.TenLop == ComboBoxClass.SelectedValue.ToString() && iter1.Email == TextBoxFindEmail.Text && iter1.SDT == TextBoxFindPhoneNum.Text
                                select iter1.MaHocSinh;
                    if (case8.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else { ThongTinHS_byID(TextBoxFindStudentID.Text); }
                }
                else if (ComboBoxFindGrade.SelectedIndex != -1 && ComboBoxClass.SelectedIndex != -1 && TextBoxFindEmail.Text != "")
                {
                    var case9 = from iter1 in db.HOCSINHs
                                join iter2 in db.CTLOPs on iter1.MaHocSinh equals iter2.MaHocSinh
                                join iter3 in db.LOPs on iter2.MaLop equals iter3.MaLop
                                where iter1.MaHocSinh == TextBoxFindStudentID.Text && iter3.TenLop == ComboBoxClass.SelectedValue.ToString() && iter1.Email == TextBoxFindEmail.Text
                                select iter1.MaHocSinh;
                    if (case9.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else { ThongTinHS_byID(TextBoxFindStudentID.Text); }
                }
                else if (ComboBoxFindGrade.SelectedIndex != -1 && ComboBoxClass.SelectedIndex != -1 && TextBoxFindPhoneNum.Text != "")
                {
                    var case10 = from iter1 in db.HOCSINHs
                                 join iter2 in db.CTLOPs on iter1.MaHocSinh equals iter2.MaHocSinh
                                 join iter3 in db.LOPs on iter2.MaLop equals iter3.MaLop
                                 where iter1.MaHocSinh == TextBoxFindStudentID.Text && iter3.TenLop == ComboBoxClass.SelectedValue.ToString() && iter1.SDT == TextBoxFindPhoneNum.Text
                                 select iter1.MaHocSinh;
                    if (case10.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else { ThongTinHS_byID(TextBoxFindStudentID.Text); }
                }
                else if (TextBoxFindEmail.Text != "" && TextBoxFindPhoneNum.Text != "")
                {
                    var case11 = from iter in db.HOCSINHs
                                 where iter.MaHocSinh == TextBoxFindStudentID.Text && iter.SDT == TextBoxFindPhoneNum.Text && iter.Email == TextBoxFindEmail.Text
                                 select iter.MaHocSinh;
                    if (case11.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else { ThongTinHS_byID(TextBoxFindStudentID.Text); }
                }
                else if (TextBoxFindEmail.Text != "")
                {
                    var case12 = from iter in db.HOCSINHs
                                 where iter.MaHocSinh == TextBoxFindStudentID.Text && iter.Email == TextBoxFindEmail.Text
                                 select iter.MaHocSinh;
                    if (case12.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else { ThongTinHS_byID(TextBoxFindStudentID.Text); }
                }
                else if (TextBoxFindPhoneNum.Text != "")
                {
                    var case13 = from iter in db.HOCSINHs
                                 where iter.MaHocSinh == TextBoxFindStudentID.Text && iter.SDT == TextBoxFindPhoneNum.Text
                                 select iter.MaHocSinh;
                    if (case13.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else { ThongTinHS_byID(TextBoxFindStudentID.Text); }
                }
                else if (ComboBoxFindGrade.SelectedIndex != -1 && ComboBoxClass.SelectedIndex != -1)
                {
                    var case14 = from iter1 in db.HOCSINHs
                                 join iter2 in db.CTLOPs on iter1.MaHocSinh equals iter2.MaHocSinh
                                 join iter3 in db.LOPs on iter2.MaLop equals iter3.MaLop
                                 where iter1.MaHocSinh == TextBoxFindStudentID.Text && iter3.TenLop == ComboBoxClass.SelectedValue.ToString()
                                 select iter1.MaHocSinh;
                    if (case14.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else { ThongTinHS_byID(TextBoxFindStudentID.Text); }
                }
                else if (TextBoxFindName.Text != "")
                {
                    var case15 = from iter in db.HOCSINHs
                                 where iter.MaHocSinh == TextBoxFindStudentID.Text && iter.HoTen == TextBoxFindName.Text
                                 select iter.MaHocSinh;
                    if (case15.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else { ThongTinHS_byID(TextBoxFindStudentID.Text); }
                }
                else
                {
                    var case16 = from iter in db.HOCSINHs
                                 where iter.MaHocSinh == TextBoxFindStudentID.Text
                                 select iter.MaHocSinh;
                    if (case16.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else { ThongTinHS_byID(TextBoxFindStudentID.Text); }
                }
            }
            //Tra cứu theo Họ tên + Lớp + SĐT/Email
            else if (ComboBoxFindStudenID.SelectedIndex == -1 && TextBoxFindName.Text != "" && ComboBoxFindGrade.SelectedIndex != -1 && ComboBoxClass.SelectedIndex != -1)
            {
                if (TextBoxFindEmail.Text != "" && TextBoxFindPhoneNum.Text != "")
                {
                    var case1 = from iter1 in db.HOCSINHs
                                join iter2 in db.CTLOPs on iter1.MaHocSinh equals iter2.MaHocSinh
                                join iter3 in db.LOPs on iter2.MaLop equals iter3.MaLop
                                where iter1.HoTen == TextBoxFindName.Text && iter3.TenLop == ComboBoxClass.SelectedValue.ToString() && iter1.Email == TextBoxFindEmail.Text && iter1.SDT == TextBoxFindPhoneNum.Text
                                select iter1.MaHocSinh;
                    if (case1.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (case1.Count() > 1)
                    {
                        MessageBox.Show("Có nhiều hơn 1 học sinh trùng với thông tin đã nhập. Hãy chọn mã số học sinh muốn tra cứu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TextBoxFindStudentID.Hide();
                        ComboBoxFindStudenID.Show();
                        ComboBoxFindStudenID.DataSource = case1.ToList();
                        ComboBoxFindStudenID.DisplayMember = "MaHocSinh";
                        ComboBoxFindStudenID.SelectedIndex = -1;
                    }
                    else
                    {
                        ThongTinHS_byName(TextBoxFindName.Text);
                    }

                }
                else if (TextBoxFindEmail.Text != "")
                {
                    var case2 = from iter1 in db.HOCSINHs
                                join iter2 in db.CTLOPs on iter1.MaHocSinh equals iter2.MaHocSinh
                                join iter3 in db.LOPs on iter2.MaLop equals iter3.MaLop
                                where iter1.HoTen == TextBoxFindName.Text && iter3.TenLop == ComboBoxClass.SelectedValue.ToString() && iter1.Email == TextBoxFindEmail.Text
                                select iter1.MaHocSinh;
                    if (case2.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (case2.Count() > 1)
                    {
                        MessageBox.Show("Có nhiều hơn 1 học sinh trùng với thông tin đã nhập. Hãy chọn mã số học sinh muốn tra cứu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TextBoxFindStudentID.Hide();
                        ComboBoxFindStudenID.Show();
                        ComboBoxFindStudenID.DataSource = case2.ToList();
                        ComboBoxFindStudenID.DisplayMember = "MaHocSinh"; 
                        ComboBoxFindStudenID.SelectedIndex = -1;
                    }
                    else
                    {
                        ThongTinHS_byName(TextBoxFindName.Text);
                    }
                }
                else if (TextBoxFindPhoneNum.Text != "")
                {
                    var case3 = from iter1 in db.HOCSINHs
                                join iter2 in db.CTLOPs on iter1.MaHocSinh equals iter2.MaHocSinh
                                join iter3 in db.LOPs on iter2.MaLop equals iter3.MaLop
                                where iter1.HoTen == TextBoxFindName.Text && iter3.TenLop == ComboBoxClass.SelectedValue.ToString() && iter1.SDT == TextBoxFindPhoneNum.Text
                                select iter1.MaHocSinh;
                    if (case3.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (case3.Count() > 1)
                    {
                        MessageBox.Show("Có nhiều hơn 1 học sinh trùng với thông tin đã nhập. Hãy chọn mã số học sinh muốn tra cứu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TextBoxFindStudentID.Hide();
                        ComboBoxFindStudenID.Show();
                        ComboBoxFindStudenID.DataSource = case3.ToList();
                        ComboBoxFindStudenID.DisplayMember = "MaHocSinh";
                        ComboBoxFindStudenID.SelectedIndex = -1;    
                    }
                    else
                    {
                        ThongTinHS_byName(TextBoxFindName.Text);
                    }
                }
                else
                {
                    var case4 = from iter1 in db.HOCSINHs
                                join iter2 in db.CTLOPs on iter1.MaHocSinh equals iter2.MaHocSinh
                                join iter3 in db.LOPs on iter2.MaLop equals iter3.MaLop
                                where iter1.HoTen == TextBoxFindName.Text && iter3.TenLop == ComboBoxClass.SelectedValue.ToString()
                                select iter1.MaHocSinh;
                    if (case4.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (case4.Count() > 1)
                    {
                        MessageBox.Show("Có nhiều hơn 1 học sinh trùng với thông tin đã nhập. Hãy chọn mã số học sinh muốn tra cứu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TextBoxFindStudentID.Hide();
                        ComboBoxFindStudenID.Show();
                        ComboBoxFindStudenID.DataSource = case4.ToList();
                        ComboBoxFindStudenID.DisplayMember = "MaHocSinh";
                        ComboBoxFindStudenID.SelectedIndex = -1;
                    }
                    else
                    {
                        ThongTinHS_byName(TextBoxFindName.Text);
                    }
                }                     
                return;   
            }
            else if (ComboBoxFindStudenID.SelectedIndex != -1 && TextBoxFindName.Text != "" && ComboBoxFindGrade.SelectedIndex != -1 && ComboBoxClass.SelectedIndex != -1)
            {
                ThongTinHS_byID(ComboBoxFindStudenID.SelectedValue.ToString());
            }    
            else if (TextBoxFindName.Text == "" || ComboBoxClass.SelectedIndex == -1)
            {
                MessageBox.Show("Cần nhập thêm thông tin để tra cứu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (TextBoxFindStudentID.Text == "" && TextBoxFindEmail.Text == "" && TextBoxFindName.Text == "" && TextBoxFindPhoneNum.Text == "" && ComboBoxClass.SelectedIndex == -1)
                {
                    MessageBox.Show("Không có thông tin để tra cứu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }   
        }
        private void ButtonFindStudentInformation_Click(object sender, EventArgs e)
        {
            TraCuuHS();
        }
        private void ComboBoxFindGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox cb = sender as System.Windows.Forms.ComboBox;
            if (cb.SelectedValue != null)
            {
                var temp1 = cb.SelectedValue.ToString();
                var temp2 = ComboBoxFindSchoolYear.SelectedValue.ToString();

                dataEntities db = new dataEntities();

                var CBLop = from iter1 in db.LOPs
                            join iter2 in db.KHOIs on iter1.MaKhoi equals iter2.MaKhoi
                            join iter3 in db.NAMHOCs on iter1.MaNamHoc equals iter3.MaNamHoc
                            where iter2.TenKhoi.ToString() == temp1 && iter3.NamHoc1 == temp2
                            select iter1.TenLop;

                ComboBoxClass.DataSource = CBLop.ToList();
                ComboBoxClass.DisplayMember = "TenLop";
            }
        }
        private void ComboBoxFindSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox cb1 = sender as System.Windows.Forms.ComboBox;
            if (cb1.SelectedValue != null)
            {
                var temp = cb1.SelectedValue.ToString();
                dataEntities db = new dataEntities();

                var CBKhoi = from iter1 in db.KHOIs
                             join iter2 in db.NAMHOCs on iter1.MaNamHoc equals iter2.MaNamHoc
                             where iter2.NamHoc1 == temp
                             select iter1.TenKhoi;

                ComboBoxFindGrade.DataSource = CBKhoi.ToList();
                ComboBoxFindGrade.DisplayMember = "TenKhoi";
            }
        }
        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            TextBoxFindStudentID.Clear();
            TextBoxFindStudentID.ReadOnly = false;
            TextBoxFindStudentID.Text = "";
            TextBoxFindStudentID.Show();

            TextBoxFindName.Clear();
            TextBoxFindName.ReadOnly = false;
            TextBoxFindName.Text = "";

            TextBoxFindEmail.Clear();
            TextBoxFindEmail.ReadOnly = false;
            TextBoxFindEmail.Text = "";

            TextBoxFindPhoneNum.Clear();
            TextBoxFindPhoneNum.ReadOnly = false;
            TextBoxFindPhoneNum.Text = "";

            ComboBoxFindSchoolYear.SelectedIndex = -1;
            ComboBoxFindGrade.SelectedIndex = -1;
            ComboBoxClass.SelectedIndex = -1;
            ComboBoxFindSchoolYear.Enabled = true;
            ComboBoxFindGrade.Enabled = true;
            ComboBoxClass.Enabled = true;
            ComboBoxFindStudenID.SelectedIndex = -1;
            ComboBoxFindStudenID.Hide();

            PanelStudentInfo.Hide();
            PanelParentInfo.Hide();
            //lbThongTinPhuHuynh.Hide();
            PanelDadInfo.Hide();
            PanelMomInfo.Hide();
        }
        private void ButtonHome_Click(object sender, EventArgs e)
        {
            (this.formTraCuu as TrangChu).Show();
            this.Close();
        }
        private void ButtonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void ButtonAccount_Click(object sender, EventArgs e)
        {
            TrangCaNhan newform = new TrangCaNhan();
            this.Hide();
            newform.ShowDialog();
            this.Show();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        private void FormTraCuuHocSinh_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
        private void ButtonInstruction_Click(object sender, EventArgs e)
        {
            PanelInstruction.Show();
            LabelInstruction.Text = "Hướng dẫn Tra cứu: Có 2 cách tra cứu" +
                "\n1.Tra cứu theo Mã số học sinh: Bạn cần nhập ít nhất thông tin Mã số học sinh để tra cứu" +
                "\n2.Tra cứu theo Họ tên (Không bắt buộc nhập Mã số học sinh): Bạn cần nhập ít nhất các thông tin sau: " +
                "\nHọ tên học sinh, Năm học hiện tại, Khối, Lớp hiện tại";    
        }
        private void ButtonCancel_Instruction_Click(object sender, EventArgs e)
        {
            PanelInstruction.Hide();
        }
    }
}