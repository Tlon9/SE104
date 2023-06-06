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
                               where obj.MaHocSinh == "2252*"
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
                db.ThemHocSinh(strID,
                            this.tbName.Text,
                            this.cbGender.Text,
                            this.dtpBirthday.Value,
                            this.tbAddress.Text,
                            this.tbOrigin.Text,
                            this.tbEthnicity.Text,
                            this.tbReligion.Text,
                            this.tbNumPhone.Text,
                            this.tbEmail.Text,
                            this.tbDadName.Text,
                            short.Parse(this.tbDadBirthyear.Text),
                            this.tbDadID.Text,
                            this.tbDadPhoneNum.Text,
                            this.tbDadJob.Text,
                            this.tbMomName.Text,
                            short.Parse(this.tbMomBirthyear.Text),
                            this.tbMomID.Text,
                            this.tbMomPhoneNum.Text,
                            this.tbMomJob.Text);
                db.SaveChanges();
                MessageBox.Show("Thêm học sinh thành công",
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
