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
        }

        private void AddNewStudent()
        {
            dataEntities db = new dataEntities();
            List<String> listID = (from obj in db.HOCSINHs
                               where obj.MaHocSinh.Substring(0, 4) == "2252"
                               orderby obj.MaHocSinh descending
                               select obj.MaHocSinh).ToList();

            String strID = "2252";
            if(listID.Count > 0)
            {
                short sIndex = short.Parse(listID.First().Substring(4));
                sIndex++;
                String strIndex = sIndex.ToString();
                for(int i = 0; i < 4 - strIndex.Length; i++)
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
            
            if(sTuoi >= sTuoiToiThieu && sTuoi <= sTuoiToiDa)
            {
                HOCSINH hs = new HOCSINH();
                hs.MaHocSinh        = strID;
                hs.HoTen            = this.tbName.Text;
                hs.GioiTinh         = this.cbGender.Text;
                hs.NgaySinh         = this.dtpBirthday.Value;
                hs.DiaChi           = this.tbAddress.Text;
                hs.QueQuan          = this.tbOrigin.Text;
                hs.DanToc           = this.tbEthnicity.Text;
                hs.TonGiao          = this.tbReligion.Text;
                hs.SDT              = this.tbNumPhone.Text;
                hs.Email            = this.tbEmail.Text;
                hs.HoTenCha         = this.tbDadName.Text;
                hs.NamSinh_Cha      = short.Parse(this.tbDadBirthyear.Text);
                hs.CCCD_Cha         = this.tbDadID.Text;
                hs.SDT_Cha          = this.tbDadPhoneNum.Text;
                hs.NgheNghiep_Cha   = this.tbDadJob.Text;
                hs.HoTenMe          = this.tbMomName.Text;
                hs.NamSinh_Me       = short.Parse(this.tbMomBirthyear.Text);
                hs.CCCD_Me          = this.tbMomID.Text;
                hs.SDT_Me           = this.tbMomPhoneNum.Text;
                hs.NgheNghiep_Me    = this.tbMomJob.Text;

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

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            AddNewStudent();
        }
    }
}
