using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocSinh
{
    public partial class LapDanhSachLop : Form
    {
        private TrangChu mainform { get; set; }
        private short sStdNum;
        private DataTable dt;
        private int iSchoolYear;
        private int iGrade;
        private int iClass;

        public LapDanhSachLop(TrangChu mainform)
        {
            InitializeComponent();
            this.mainform = mainform;

            this.DataGridViewClassDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridViewClassDetail.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dt = new DataTable();
            dt.Columns.Add("STT", typeof(byte)).ReadOnly = true;
            dt.Columns.Add("MSHS", typeof(String)).ReadOnly = true;
            dt.Columns.Add("Họ tên", typeof(String)).ReadOnly = true;
            dt.Columns.Add("Giới tính", typeof(String)).ReadOnly = true;
            dt.Columns.Add("Ngày sinh", typeof(DateTime)).ReadOnly = true;
            dt.Columns.Add("Địa chỉ", typeof(String)).ReadOnly = true;
            dt.Columns.Add("SĐT", typeof(String)).ReadOnly = true;

            dataEntities db = new dataEntities();
            CapNhatDanhSachNamHoc(db);
            CapNhatDanhSachKhoi(db);
            CapNhatDanhSachLop(db);
            HienThiDanhSachHocSinh(db);

            this.ComboBoxSchoolYear.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSchoolYear_SelectedIndexChanged);
            this.ComboBoxGrade.SelectedIndexChanged += new System.EventHandler(this.ComboBoxGrade_SelectedIndexChanged);
            this.ComboBoxClass.SelectedIndexChanged += new System.EventHandler(this.ComboBoxClass_SelectedIndexChanged);
        }

        private void CapNhatDanhSachNamHoc(dataEntities db)
        {
            List<NAMHOC> list = (from obj in db.NAMHOCs.AsEnumerable()
                                 orderby obj.MaNamHoc descending
                                 select obj).ToList();
            iSchoolYear = list.Count();
            ComboBoxSchoolYear.DataSource = list;
            ComboBoxSchoolYear.DisplayMember = "NamHoc1";
            ComboBoxSchoolYear.ValueMember = "MaNamHoc";            
        }

        private void CapNhatDanhSachKhoi(dataEntities db)
        {
            try
            {
                List<KHOI> list = (from obj in db.KHOIs.AsEnumerable()
                                   where obj.MaNamHoc == this.ComboBoxSchoolYear.SelectedValue.ToString()
                                   select obj).ToList();
                iGrade = list.Count();
                ComboBoxGrade.DataSource = list;
                ComboBoxGrade.DisplayMember = "TenKhoi";
                ComboBoxGrade.ValueMember = "MaKhoi";

                if (iGrade == 0)
                {
                    List<LOP> lop = new List<LOP>();
                    ComboBoxClass.DataSource = lop;
                    TextBoxStdNum.Text = "";
                    DataGridViewClassDetail.Hide();
                }
            }
            catch(InvalidOperationException)
            {
                List<KHOI> khoi = new List<KHOI>();
                ComboBoxGrade.DataSource = khoi;
                List<LOP> lop = new List<LOP>();
                ComboBoxClass.DataSource = lop;
                TextBoxStdNum.Text = "";
                DataGridViewClassDetail.Hide();
            }
        }

        private void CapNhatDanhSachLop(dataEntities db)
        {
            try
            {
                List<LOP> list = (from l in db.LOPs.AsEnumerable()
                                  where l.MaNamHoc == this.ComboBoxSchoolYear.SelectedValue.ToString()
                                  && l.MaKhoi == this.ComboBoxGrade.SelectedValue.ToString()
                                  orderby l.MaLop ascending
                                  select l).ToList();
                iClass = list.Count();
                this.ComboBoxClass.DataSource = list;
                this.ComboBoxClass.DisplayMember = "TenLop";
                this.ComboBoxClass.ValueMember = "MaLop";

                if (iClass == 0)
                {
                    TextBoxStdNum.Text = "";
                    DataGridViewClassDetail.Hide();
                }
            }
            catch(InvalidOperationException) 
            {
                List<LOP> lop = new List<LOP>();
                ComboBoxClass.DataSource = lop;
                TextBoxStdNum.Text = "";
                DataGridViewClassDetail.Hide();
            }           
        }

        private void ThemHocSinhVaoLop()
        {
            if(this.TextBoxStdIdAdd.Text == "")
            {
                MessageBox.Show("Hãy nhập mã số học sinh", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dataEntities db = new dataEntities();
                var stdIdDb = from hs in db.HOCSINHs
                              where hs.MaHocSinh == this.TextBoxStdIdAdd.Text
                              select hs;
                if (stdIdDb.Count() > 0)
                {
                    bool isAvailable = true;
                    foreach (var std in stdIdDb)
                    {
                        if (std.HoTen == null)
                        {
                            isAvailable = false;
                            MessageBox.Show("Thông tin của học sinh này không còn tồn tại trong hệ thống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    }
                    if(isAvailable)
                    {
                        var stdIdNowDb = from hs in stdIdDb
                                         join ctl in db.CTLOPs on hs.MaHocSinh equals ctl.MaHocSinh
                                         join l in db.LOPs on ctl.MaLop equals l.MaLop
                                         join nh in db.NAMHOCs on l.MaNamHoc equals nh.MaNamHoc
                                         where nh.MaNamHoc == this.ComboBoxSchoolYear.SelectedValue.ToString()
                                         select hs;
                        if (stdIdNowDb.Count() == 0)
                        {
                            short SiSoToiDa = (short)(from obj in db.THAMSOes
                                                      select obj.SiSoToiDa).ToList().First();
                            if (sStdNum < SiSoToiDa)
                            {
                                // Thêm học sinh vào lớp
                                CTLOP cTLOP = new CTLOP();
                                cTLOP.MaHocSinh = this.TextBoxStdIdAdd.Text;
                                cTLOP.MaLop = this.ComboBoxClass.SelectedValue.ToString();
                                cTLOP.MaCTL = this.ComboBoxClass.SelectedValue.ToString() + "_" + this.TextBoxStdIdAdd.Text;
                                db.CTLOPs.Add(cTLOP);
                                db.SaveChanges();
                                // Thêm học sinh vào lớp

                                HienThiDanhSachHocSinh(db);
                                this.TextBoxStdIdAdd.Text = "";
                                MessageBox.Show("Thêm học sinh vào lớp thành công", "Thêm thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Lớp đã đạt sĩ số tối đa, không thể thêm học sinh",
                                                "Lỗi",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Học sinh này đã được xếp lớp ở năm học này, không thể thêm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }    
                } 
                else
                {
                    MessageBox.Show("Mã số học sinh không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                
            }            
        }

        private void XoaHocSinhKhoiClass()
        {
            try
            {
                if (short.Parse(this.TextBoxStdIDDel.Text) < 1)
                {
                    MessageBox.Show("Giá trị nhập vào không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (short.Parse(this.TextBoxStdIDDel.Text) > sStdNum)
                {
                    MessageBox.Show("Số thứ tự lớn hơn sĩ số lớp", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Xoá học sinh khỏi lớp
                    DialogResult choose = MessageBox.Show(
                        "Xoá học sinh này khỏi lớp? Tác vụ này không thể hoàn tác",
                        "Xoá học sinh khỏi lớp",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Warning
                    );

                    if(choose == DialogResult.OK)
                    {
                        dataEntities db = new dataEntities();

                        String str1 = dt.Rows[short.Parse(this.TextBoxStdIDDel.Text) - 1]["MSHS"].ToString();
                        String str2 = this.ComboBoxClass.SelectedValue.ToString();

                        db.CTLOPs.Remove(
                            db.CTLOPs.Where(p => p.MaHocSinh == str1)
                                .Intersect(
                                    db.CTLOPs.Where(p => p.MaLop == str2)
                                )
                                .FirstOrDefault()
                        ) ;
                        db.SaveChanges();
                                             
                        // Xoá học sinh khỏi lớp

                        HienThiDanhSachHocSinh(db);
                        this.TextBoxStdIDDel.Text = string.Empty;
                        MessageBox.Show(
                            "Xoá học sinh khỏi lớp thành công",
                            "Xoá thành công",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                }
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Hãy nhập STT", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("Giá trị nhập vào không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (OverflowException)
            {
                MessageBox.Show("Giá trị nhập vào vượt quá giới hạn cho phép", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HienThiDanhSachHocSinh(dataEntities db)
        {
            try
            {
                var dataSource = from ctl in db.CTLOPs.AsEnumerable()
                                 join hs in db.HOCSINHs.AsEnumerable() on ctl.MaHocSinh equals hs.MaHocSinh
                                 where ctl.MaLop == this.ComboBoxClass.SelectedValue.ToString()
                                 group new { hs }
                                 by new { hs.MaHocSinh, hs.HoTen, hs.GioiTinh, hs.NgaySinh, hs.DiaChi, hs.SDT }
                             into g
                                 select new
                                 {
                                     MaHocSinh = g.Key.MaHocSinh,
                                     HoTen = g.Key.HoTen,
                                     GioiTinh = g.Key.GioiTinh,
                                     NgaySinh = g.Key.NgaySinh,
                                     DiaChi = g.Key.DiaChi,
                                     SDT = g.Key.SDT
                                 };

                dt.Clear();
                sStdNum = 0;
                foreach (var std in dataSource)
                {
                    DataRow row = dt.NewRow();
                    row["STT"] = ++sStdNum;
                    row["MSHS"] = std.MaHocSinh;
                    row["Họ tên"] = std.HoTen;
                    row["Giới tính"] = std.GioiTinh;
                    row["Ngày sinh"] = std.NgaySinh;
                    row["Địa chỉ"] = std.DiaChi;
                    row["SĐT"] = std.SDT;

                    dt.Rows.Add(row);
                }

                this.TextBoxStdNum.Text = sStdNum.ToString();
                this.DataGridViewClassDetail.DataSource = dt;
                this.DataGridViewClassDetail.AutoResizeColumns();
                this.DataGridViewClassDetail.Show();
            }
            catch(InvalidOperationException)
            {
                TextBoxStdNum.Text = "";
                DataGridViewClassDetail.Hide();
            }
            
        }

        private void ComboBoxSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataEntities db = new dataEntities();
            CapNhatDanhSachKhoi(db);
        }

        private void ComboBoxGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataEntities db = new dataEntities();
            CapNhatDanhSachLop(db);
        }

        private void ComboBoxClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataEntities db = new dataEntities();            
            HienThiDanhSachHocSinh(db);                    
        }

        private void Button_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Button_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ButtonHomeScreen_Click(object sender, EventArgs e)
        {
            (this.mainform as TrangChu).Show();
            this.Hide();
        }

        private void ButtonAddStdToClass_Click(object sender, EventArgs e)
        {
            ThemHocSinhVaoLop();
        }

        private void ButtonDelStdOutClass_Click(object sender, EventArgs e)
        {
            XoaHocSinhKhoiClass();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void mainLabelStdInfo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
    }
}
