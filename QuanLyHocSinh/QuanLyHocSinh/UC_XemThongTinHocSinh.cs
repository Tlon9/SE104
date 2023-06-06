using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
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
            this.tbStudentID.Text = "";
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
                    this.cbGender.Text      = strStdGender      = std.GioiTinh;
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
                dataEntities db = new dataEntities();
                // Save Student Info code
                byte sTuoiToiThieu = (byte)(from obj in db.THAMSOes
                                            select obj.TuoiToiThieu).ToList().First();
                byte sTuoiToiDa = (byte)(from obj in db.THAMSOes
                                         select obj.TuoiToiDa).ToList().First();
                byte sTuoi = (byte)(DateTime.Now.Year - dtpBirthday.Value.Year);

                if (sTuoi >= sTuoiToiThieu && sTuoi <= sTuoiToiDa)
                {
                    //db.SuaHocSinh(this.tbStudentID.Text,
                    //            this.tbName.Text,
                    //            this.cbGender.Text,
                    //            this.dtpBirthday.Value,
                    //            this.tbAddress.Text,
                    //            this.tbOrigin.Text,
                    //            this.tbEthnicity.Text,
                    //            this.tbReligion.Text,
                    //            this.tbNumPhone.Text,
                    //            this.tbEmail.Text,
                    //            this.tbDadName.Text,
                    //            short.Parse(this.tbDadBirthyear.Text),
                    //            this.tbDadID.Text,
                    //            this.tbDadPhoneNum.Text,
                    //            this.tbDadJob.Text,
                    //            this.tbMomName.Text,
                    //            short.Parse(this.tbMomBirthyear.Text),
                    //            this.tbMomID.Text,
                    //            this.tbMomPhoneNum.Text,
                    //            this.tbMomJob.Text);
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
                // Save Student Info code
            }
        }

        private void CancelChanges()
        {
            this.tbStudentID.Text = strStdID;
            this.tbName.Text = strStdName;
            this.cbGender.Text = strStdGender;
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
            dataEntities db = new dataEntities();
            // Check if the student is in a class
            var listStdID = (from obj in db.CTLOPs
                             where this.tbStudentID.Text == obj.MaHocSinh
                             select obj);
            if(listStdID.Count() > 0)
            {
                DialogResult choose = MessageBox.Show("Xoá thông tin của học sinh này? Tác vụ này không thể hoàn tác",
                                                "Xoá",
                                                MessageBoxButtons.OKCancel,
                                                MessageBoxIcon.Warning);

                if (choose == DialogResult.OK)
                {
                    // Delete Student
                    //db.SuaHocSinh(this.tbStudentID.Text);
                    db.SaveChanges();
                    // Delete Student

                    MessageBox.Show("Xoá học sinh thành công",
                                    "Xoá thành công",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    this.tbStudentID.Text = "";
                    this.pnStudentInfo.Visible = false;
                    this.pnDadInfo.Visible = false;
                    this.pnMomInfo.Visible = false;
                    this.btnSave.Visible = false;
                    this.btnCancel.Visible = false;
                    this.btnDelete.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Học sinh này đã được xếp lớp, không thể xoá",
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
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