using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocSinh
{
    public partial class UC_XemThongTinHocSinh : UserControl
    {
        // Student Info
        protected String    strStdID;
        protected String    strStdName;
        protected String    strStdGender;
        protected DateTime  dtStdBirthday;
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
            this.pnStudentInfo.Visible = false;
            this.pnDadInfo.Visible = false;
            this.pnMomInfo.Visible = false;
            this.btnSave.Visible = false;
            this.btnCancel.Visible = false;
            this.btnDelete.Visible = false;
        }

        private void SearchStudentInfo()
        {
            dataEntities db = new dataEntities();
            var listSearch = from obj in db.HOCSINHs
                             where obj.MaHocSinh == this.tbStudentID.Text
                             select obj;
            if (listSearch.Count() > 0)
            {
                foreach (var std in listSearch)
                {
                    // Student Info
                    this.strStdID           = std.MaHocSinh;
                    this.tbName.Text        = strStdName        = std.HoTen;
                    this.tbGender.Text      = strStdGender      = std.GioiTinh;
                    this.dtpBirthday.Value  = dtStdBirthday     = std.NgaySinh.Value;
                    this.tbEthnicity.Text   = strStdEthnicity   = std.DanToc;
                    this.tbReligion.Text    = strStdReligion    = std.TonGiao;
                    this.tbNumPhone.Text    = strStdPhoneNum    = std.SDT;
                    this.tbEmail.Text       = strStdEmail       = std.Email;
                    this.pnStudentInfo.Visible = true;

                    // Dad Info
                    this.tbDadName.Text         = strDadName        = std.HoTenCha;
                    this.tbDadID.Text           = strDadID          = std.CCCD_Cha;
                    this.tbDadBirthyear.Text    = strDadBirthyear   = std.NamSinh_Cha.ToString();
                    this.tbDadPhoneNum.Text     = strDadPhoneNum    = std.SDT_Cha;
                    this.tbDadJob.Text          = strDadJob         = std.NgheNghiep_Cha;
                    this.pnDadInfo.Visible = true;

                    // Mom Info
                    this.tbMomName.Text         = strMomName        = std.HoTenMe;
                    this.tbMomID.Text           = strMomID          = std.CCCD_Me;
                    this.tbMomBirthyear.Text    = strMomBirthyear   = std.NamSinh_Me.ToString();
                    this.tbMomPhoneNum.Text     = strMomPhoneNum    = std.SDT_Me;
                    this.tbMomJob.Text          = strMomJob         = std.NgheNghiep_Me;
                    this.pnMomInfo.Visible = true;

                    // Buttons
                    this.btnSave.Visible = true;
                    this.btnCancel.Visible = true;
                    this.btnDelete.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Mã số học sinh không tồn tại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveStudentInfo()
        {
            DialogResult choose = MessageBox.Show("Lưu thay đổi?", "Lưu", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if(choose == DialogResult.OK)
            {
                // Save Student Info code

                // Save Student Info code
            }
        }

        private void CancelChanges()
        {
            this.tbStudentID.Text = strStdID;
            this.tbName.Text = strStdName;
            this.tbGender.Text = strStdGender;
            this.dtpBirthday.Value = dtStdBirthday;
            this.tbEthnicity.Text = strStdEthnicity;
            this.tbReligion.Text = strStdReligion;
            this.tbNumPhone.Text = strStdPhoneNum;
            this.tbEmail.Text = strStdEmail;

            this.tbDadName.Text = strDadName;
            this.tbDadID.Text = strDadID;
            this.tbDadBirthyear.Text = strDadBirthyear;
            this.tbDadPhoneNum.Text = strDadPhoneNum;
            this.tbDadJob.Text = strDadJob;

            this.tbMomName.Text = strMomName;
            this.tbMomID.Text = strMomID;
            this.tbMomBirthyear.Text = strMomBirthyear;
            this.tbMomPhoneNum.Text = strMomPhoneNum;
            this.tbMomJob.Text = strMomJob;
        }

        private void DeleteStudent()
        {
            // Check if the student is in a class or has grade result

            // Check if the student is in a class or has grade result

            DialogResult choose = MessageBox.Show("Xoá thông tin của học sinh này? Tác vụ này không thể hoàn tác",
                                                "Xoá",
                                                MessageBoxButtons.OKCancel,
                                                MessageBoxIcon.Warning);
            
            if(choose == DialogResult.OK)
            {
                // Delete Student

                // Delete Student

                this.tbStudentID.Text = "";
                this.pnStudentInfo.Visible = false;
                this.pnDadInfo.Visible = false;
                this.pnMomInfo.Visible = false;
                this.btnSave.Visible = false;
                this.btnCancel.Visible = false;
                this.btnDelete.Visible = false;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SearchStudentInfo();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveStudentInfo();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelChanges();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteStudent();
        }
    }
}