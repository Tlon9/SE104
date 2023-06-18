using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyHocSinh
{
    public partial class UC_XemThongTinHocSinh : UserControl
    {
        // Student Info
        protected String    strStdID;
        protected String    strStdName;
        protected String    strStdGender;
        protected DateTime  dtStdBirthday;
        protected String    strStdAddress;
        protected String    strStdOrigin;
        protected String    strStdEthnicity;
        protected String    strStdReligion;
        protected String    strStdPhoneNum;
        protected String    strStdEmail;

        // Dad Info
        protected String    strDadName;
        protected String    strDadID;
        protected String    strDadBirthyear;
        protected String    strDadPhoneNum;
        protected String    strDadJob;

        // Mom Info
        protected String    strMomName;
        protected String    strMomID;
        protected String    strMomBirthyear;
        protected String    strMomPhoneNum;
        protected String    strMomJob;

        public UC_XemThongTinHocSinh()
        {
            InitializeComponent();
            this.TextBoxStudentID.Text = "";
            this.TextBoxStudentID.ReadOnly = false;
            this.pnStudentInfo.Visible = false;
            this.pnDadInfo.Visible = false;
            this.pnMomInfo.Visible = false;
            this.ButtonSave.Visible = false;
            this.ButtonCancel.Visible = false;
            this.ButtonDelete.Visible = false;

            this.dtpBirthday.CustomFormat = "dd/MM/yyyy";
            this.dtpBirthday.Format = DateTimePickerFormat.Custom;
        }

        private void SearchStudentInfo()
        {
            dataEntities db = new dataEntities();
            var listSearch = from obj in db.HOCSINHs
                             where obj.MaHocSinh == this.TextBoxStudentID.Text
                             select obj;
            if (listSearch.Count() > 0)
            {
                foreach (var std in listSearch)
                {
                    if(std.HoTen == null)
                    {
                        MessageBox.Show("Thông tin của học sinh này không còn tồn tại trong hệ thống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                    else
                    {
                        // Student Info
                        this.strStdID = std.MaHocSinh;
                        this.TextBoxName.Text = strStdName = std.HoTen;
                        this.ComboBoxGender.Text = strStdGender = std.GioiTinh;
                        this.dtpBirthday.Value = dtStdBirthday = std.NgaySinh.Value;
                        this.TextBoxOrigin.Text = strStdOrigin = std.QueQuan;
                        this.TextBoxAddress.Text = strStdAddress = std.DiaChi;
                        this.TextBoxEthnicity.Text = strStdEthnicity = std.DanToc;
                        this.TextBoxReligion.Text = strStdReligion = std.TonGiao;
                        this.TextBoxNumPhone.Text = strStdPhoneNum = std.SDT;
                        this.TextBoxEmail.Text = strStdEmail = std.Email;
                        this.pnStudentInfo.Visible = true;

                        // Dad Info
                        this.TextBoxDadName.Text = strDadName = std.HoTenCha;
                        this.TextBoxDadID.Text = strDadID = std.CCCD_Cha;
                        this.TextBoxDadBirthyear.Text = strDadBirthyear = std.NamSinh_Cha.ToString();
                        this.TextBoxDadPhoneNum.Text = strDadPhoneNum = std.SDT_Cha;
                        this.TextBoxDadJob.Text = strDadJob = std.NgheNghiep_Cha;
                        this.pnDadInfo.Visible = true;

                        // Mom Info
                        this.TextBoxMomName.Text = strMomName = std.HoTenMe;
                        this.TextBoxMomID.Text = strMomID = std.CCCD_Me;
                        this.TextBoxMomBirthyear.Text = strMomBirthyear = std.NamSinh_Me.ToString();
                        this.TextBoxMomPhoneNum.Text = strMomPhoneNum = std.SDT_Me;
                        this.TextBoxMomJob.Text = strMomJob = std.NgheNghiep_Me;
                        this.pnMomInfo.Visible = true;

                        // Buttons
                        this.ButtonSave.Visible = true;
                        this.ButtonCancel.Visible = true;
                        this.ButtonDelete.Visible = true;
                    }                   
                }
            }
            else
            {
                MessageBox.Show("Mã số học sinh không tồn tại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsOnlySpace(String str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != ' ')
                {
                    return false;
                }
            }
            return true;
        }

        private void SaveStudentInfo()
        {
            this.TextBoxName.Text.Trim();
            this.TextBoxOrigin.Text.Trim();
            this.TextBoxAddress.Text.Trim();
            this.TextBoxNumPhone.Text.Trim();

            if (TextBoxName.Text.Length > 0
                && TextBoxOrigin.Text.Length > 0
                && TextBoxAddress.Text.Length > 0
                && TextBoxNumPhone.Text.Length > 0
                && !IsOnlySpace(TextBoxName.Text)
                && !IsOnlySpace(TextBoxOrigin.Text)
                && !IsOnlySpace(TextBoxAddress.Text)
                && !IsOnlySpace(TextBoxNumPhone.Text))
            {
                try
                {
                    short sNamSinhCha = 0;
                    short sNamSinhMe = 0;
                    if (this.TextBoxDadBirthyear.Text != "")
                    {
                        sNamSinhCha = short.Parse(this.TextBoxDadBirthyear.Text);
                        
                    }
                    if(this.TextBoxMomBirthyear.Text != "")
                    {
                        sNamSinhMe = short.Parse(this.TextBoxMomBirthyear.Text);
                    }

                    DialogResult choose = MessageBox.Show("Lưu thay đổi?", "Lưu", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (choose == DialogResult.OK)
                    {
                        dataEntities db = new dataEntities();
                        // Save Student Info code
                        byte sTuoiToiThieu = (byte)(from obj in db.THAMSOes
                                                    select obj.TuoiToiThieu).ToList().First();
                        byte sTuoiToiDa = (byte)(from obj in db.THAMSOes
                                                 select obj.TuoiToiDa).ToList().First();
                        byte sTuoi = (byte)(DateTime.Now.Year - dtpBirthday.Value.Year);

                        if (sTuoi >= sTuoiToiThieu && sTuoi <= sTuoiToiDa)
                        {
                            HOCSINH hs = new HOCSINH();

                            hs.MaHocSinh = this.strStdID = this.TextBoxStudentID.Text;
                            hs.HoTen = strStdName = this.TextBoxName.Text;
                            hs.GioiTinh = strStdGender = this.ComboBoxGender.Text;
                            hs.NgaySinh = dtStdBirthday = this.dtpBirthday.Value;
                            hs.DiaChi = strStdAddress = this.TextBoxAddress.Text;
                            hs.QueQuan = strStdOrigin = this.TextBoxOrigin.Text;
                            hs.DanToc = strStdEthnicity = this.TextBoxEthnicity.Text;
                            hs.TonGiao = strStdReligion = this.TextBoxReligion.Text;
                            hs.SDT = strStdPhoneNum = this.TextBoxNumPhone.Text;
                            hs.Email = strStdEmail = this.TextBoxEmail.Text;

                            hs.HoTenCha = strDadName = this.TextBoxDadName.Text;
                            hs.CCCD_Cha = strDadID = this.TextBoxDadID.Text;
                            strDadBirthyear = this.TextBoxDadBirthyear.Text;
                            if(strDadBirthyear != "")
                            {
                                hs.NamSinh_Cha = short.Parse(this.TextBoxDadBirthyear.Text);
                            }
                            hs.SDT_Cha = strDadPhoneNum = this.TextBoxDadPhoneNum.Text;
                            hs.NgheNghiep_Cha = strDadJob = this.TextBoxDadJob.Text;

                            hs.HoTenMe = strMomName = this.TextBoxMomName.Text;
                            hs.CCCD_Me = strMomID = this.TextBoxMomID.Text;
                            strMomBirthyear = this.TextBoxMomBirthyear.Text;
                            if(strMomBirthyear != "")
                            {
                                hs.NamSinh_Me = short.Parse(this.TextBoxMomBirthyear.Text);
                            }                            
                            hs.SDT_Me = strMomPhoneNum = this.TextBoxMomPhoneNum.Text;
                            hs.NgheNghiep_Me = strMomJob = this.TextBoxMomJob.Text;

                            db.HOCSINHs.AddOrUpdate(hs);
                            db.SaveChanges();
                            MessageBox.Show("Lưu thay đổi thành công",
                                            "Lưu thành công",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Tuổi học sinh phải từ " + sTuoiToiThieu + " đến " + sTuoiToiDa + " tuổi.\n" +
                                            "Lưu thay đổi không thành công.",
                                            "Lỗi",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                        }
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Giá trị nhập vào cho năm sinh không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (OverflowException)
                {
                    MessageBox.Show("Giá trị nhập vào cho năm sinh vượt quá giới hạn lưu trữ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Các trường bắt buộc không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CancelChanges()
        {
            this.TextBoxStudentID.Text = strStdID;
            this.TextBoxName.Text = strStdName;
            this.ComboBoxGender.Text = strStdGender;
            this.dtpBirthday.Value = dtStdBirthday;
            this.TextBoxAddress.Text = strStdAddress;
            this.TextBoxOrigin.Text = strStdOrigin;
            this.TextBoxEthnicity.Text = strStdEthnicity;
            this.TextBoxReligion.Text = strStdReligion;
            this.TextBoxNumPhone.Text = strStdPhoneNum;
            this.TextBoxEmail.Text = strStdEmail;

            this.TextBoxDadName.Text = strDadName;
            this.TextBoxDadID.Text = strDadID;
            this.TextBoxDadBirthyear.Text = strDadBirthyear;
            this.TextBoxDadPhoneNum.Text = strDadPhoneNum;
            this.TextBoxDadJob.Text = strDadJob;

            this.TextBoxMomName.Text = strMomName;
            this.TextBoxMomID.Text = strMomID;
            this.TextBoxMomBirthyear.Text = strMomBirthyear;
            this.TextBoxMomPhoneNum.Text = strMomPhoneNum;
            this.TextBoxMomJob.Text = strMomJob;
        }

        private void DeleteStudent()
        {
            dataEntities db = new dataEntities();
            // Check if the student is in a class
            var listStdID = (from obj in db.CTLOPs
                             where this.TextBoxStudentID.Text == obj.MaHocSinh
                             select obj);
            if(listStdID.Count() > 0)
            {                
                MessageBox.Show("Học sinh này đã được xếp lớp, không thể xoá",
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            else
            {
                DialogResult choose = MessageBox.Show("Xoá thông tin của học sinh này? Tác vụ này không thể hoàn tác",
                                                "Xoá",
                                                MessageBoxButtons.OKCancel,
                                                MessageBoxIcon.Warning);

                if (choose == DialogResult.OK)
                {
                    // Delete Student
                    HOCSINH hs = new HOCSINH();
                    hs.MaHocSinh = this.TextBoxStudentID.Text;
                    db.HOCSINHs.AddOrUpdate(hs);
                    db.SaveChanges();
                    // Delete Student

                    MessageBox.Show("Xoá học sinh thành công",
                                    "Xoá thành công",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    this.TextBoxStudentID.Text = "";
                    this.pnStudentInfo.Visible = false;
                    this.pnDadInfo.Visible = false;
                    this.pnMomInfo.Visible = false;
                    this.ButtonSave.Visible = false;
                    this.ButtonCancel.Visible = false;
                    this.ButtonDelete.Visible = false;
                }
            }

            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SearchStudentInfo();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            SaveStudentInfo();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            CancelChanges();
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            DeleteStudent();
        }
    }
}