using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocSinh
{
    public partial class UC_ThemHocSinhMoi : UserControl
    {
        public UC_ThemHocSinhMoi()
        {
            InitializeComponent();
            this.ComboBoxGender.SelectedIndex = 0;
            this.dtpBirthday.CustomFormat = "dd/MM/yyyy";
            this.dtpBirthday.Format = DateTimePickerFormat.Custom;
        }

        private bool IsOnlySpace(String str)
        {
            for (int i = 0; i < str.Length; i++) {
                if (str[i] != ' ')
                {
                    return false;
                }
            }
            return true;
        }

        private void AddNewStudent()
        {
            this.TextBoxName.Text.Trim();
            this.TextBoxOrigin.Text.Trim();
            this.TextBoxAddress.Text.Trim();
            this.TextBoxNumPhone.Text.Trim();

            if(TextBoxName.Text.Length > 0
                && TextBoxOrigin.Text.Length > 0
                && TextBoxAddress.Text.Length > 0
                && TextBoxNumPhone.Text.Length > 0
                && !IsOnlySpace(TextBoxName.Text)
                && !IsOnlySpace(TextBoxOrigin.Text)
                && !IsOnlySpace(TextBoxAddress.Text)
                && !IsOnlySpace(TextBoxNumPhone.Text))
            {
                try {
                    short sNamSinhCha = 0;
                    short sNamSinhMe = 0;
                    if (this.TextBoxDadBirthyear.Text != "")
                    {
                        sNamSinhCha = short.Parse(this.TextBoxDadBirthyear.Text);

                    }
                    if (this.TextBoxMomBirthyear.Text != "")
                    {
                        sNamSinhMe = short.Parse(this.TextBoxMomBirthyear.Text);
                    }

                    dataEntities db = new dataEntities();
                    List<String> listID = (from obj in db.HOCSINHs
                                           where obj.MaHocSinh.Substring(0, 4) == "2252"
                                           orderby obj.MaHocSinh descending
                                           select obj.MaHocSinh).ToList();

                    String strID = "2252";
                    if (listID.Count > 0)
                    {
                        short sIndex = short.Parse(listID.First().Substring(4));
                        sIndex++;
                        String strIndex = sIndex.ToString();
                        for (int i = 0; i < 4 - strIndex.Length; i++)
                        {
                            strID += "0";
                        }
                        strID += strIndex;
                    }
                    else
                    {
                        strID = "22520001";
                    }

                    byte sTuoiToiThieu = (byte)(from obj in db.THAMSOes
                                                select obj.TuoiToiThieu).ToList().First();
                    byte sTuoiToiDa = (byte)(from obj in db.THAMSOes
                                             select obj.TuoiToiDa).ToList().First();
                    byte sTuoi = (byte)(DateTime.Now.Year - dtpBirthday.Value.Year);

                    if (sTuoi >= sTuoiToiThieu && sTuoi <= sTuoiToiDa)
                    {
                        HOCSINH hs = new HOCSINH();
                        hs.MaHocSinh = strID;
                        hs.HoTen = this.TextBoxName.Text;
                        hs.GioiTinh = this.ComboBoxGender.Text;

                        // Birthday
                        DateTime dateTime = new DateTime();
                        dateTime = dateTime.AddDays(this.dtpBirthday.Value.Day);
                        dateTime = dateTime.AddMonths(this.dtpBirthday.Value.Month);
                        dateTime = dateTime.AddYears(this.dtpBirthday.Value.Year);
                        hs.NgaySinh = dateTime;

                        hs.DiaChi = this.TextBoxAddress.Text;
                        hs.QueQuan = this.TextBoxOrigin.Text;
                        hs.DanToc = this.TextBoxEthnicity.Text;
                        hs.TonGiao = this.TextBoxReligion.Text;
                        hs.SDT = this.TextBoxNumPhone.Text;
                        hs.Email = this.TextBoxEmail.Text;
                        hs.HoTenCha = this.TextBoxDadName.Text;
                        if(this.TextBoxDadBirthyear.Text != "")
                        {
                            hs.NamSinh_Cha = sNamSinhCha;
                        }
                        hs.CCCD_Cha = this.TextBoxDadID.Text;
                        hs.SDT_Cha = this.TextBoxDadPhoneNum.Text;
                        hs.NgheNghiep_Cha = this.TextBoxDadJob.Text;
                        hs.HoTenMe = this.TextBoxMomName.Text;
                        if (this.TextBoxMomBirthyear.Text != "")
                        {
                            hs.NamSinh_Me = sNamSinhMe;
                        }
                        hs.CCCD_Me = this.TextBoxMomID.Text;
                        hs.SDT_Me = this.TextBoxMomPhoneNum.Text;
                        hs.NgheNghiep_Me = this.TextBoxMomJob.Text;

                        db.HOCSINHs.Add(hs);
                        db.SaveChanges();
                        MessageBox.Show("Thêm học sinh thành công\nMSHS là " + strID,
                                        "Thêm thành công",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Tuổi học sinh phải từ " + sTuoiToiThieu + " đến " + sTuoiToiDa + " tuổi.\n" +
                                        "Thêm học sinh không thành công.",
                                        "Lỗi",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
                catch(FormatException) {
                    MessageBox.Show("Giá trị nhập vào cho năm sinh không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch(OverflowException)
                {
                    MessageBox.Show("Giá trị nhập vào cho năm sinh vượt quá giới hạn lưu trữ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                
            }
            else
            {
                MessageBox.Show("Các trường bắt buộc không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void ButtonAddStudent_Click(object sender, EventArgs e)
        {
            AddNewStudent();
        }

    
    }
}
