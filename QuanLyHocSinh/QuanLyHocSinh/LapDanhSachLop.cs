﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        private String strMaLop;

        public LapDanhSachLop(TrangChu mainform)
        {
            InitializeComponent();
            this.mainform = mainform;

            dt = new DataTable();
            dt.Columns.Add("STT", typeof(byte)).ReadOnly = true;
            dt.Columns.Add("MSHS", typeof(String)).ReadOnly = false;
            dt.Columns.Add("Họ tên", typeof(String)).ReadOnly = true;
            dt.Columns.Add("Giới tính", typeof(String)).ReadOnly = true;
            dt.Columns.Add("Ngày sinh", typeof(DateTime)).ReadOnly = true;
            dt.Columns.Add("Địa chỉ", typeof(String)).ReadOnly = true;
            dt.Columns.Add("SĐT", typeof(String)).ReadOnly = true;

            dataEntities db = new dataEntities();
            cbSchoolYear.DataSource = (from obj in db.NAMHOCs.AsEnumerable()
                                       orderby obj.MaNamHoc descending
                                       select obj).ToList();
            cbSchoolYear.DisplayMember = "NamHoc1";
            cbSchoolYear.ValueMember = "MaNamHoc";

            cbGrade.DataSource = (from obj in db.KHOIs.AsEnumerable() select obj).ToList();
            cbGrade.DisplayMember = "TenKhoi";
            cbGrade.ValueMember = "MaKhoi";

            CapNhatDanhSachLop(db);
            HienThiDanhSachHocSinh(db);

            this.cbSchoolYear.SelectedIndexChanged += new System.EventHandler(this.cbSchoolYear_SelectedIndexChanged);
            this.cbGrade.SelectedIndexChanged += new System.EventHandler(this.cbGrade_SelectedIndexChanged);
            this.cbClass.SelectedIndexChanged += new System.EventHandler(this.cbClass_SelectedIndexChanged);
 
            this.dgvClassDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClassDetail.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        //private void LapDanhSachLop_Load(object sender, EventArgs e)
        //{
        //    // TODO: This line of code loads data into the 'duLieu.LOP' table. You can move, or remove it, as needed.
        //    this.lOPTableAdapter.Fill(this.duLieu.LOP);

    //}

        private void CapNhatDanhSachLop(dataEntities db)
        {
            this.cbClass.DataSource = (from l in db.LOPs.AsEnumerable()
                                       where l.MaNamHoc == this.cbSchoolYear.SelectedValue.ToString()
                                       && l.MaKhoi == this.cbGrade.SelectedValue.ToString()
                                       orderby l.MaLop ascending
                                       select l).ToList();
            this.cbClass.DisplayMember = "TenLop";
            this.cbClass.ValueMember = "MaLop";
        }

        private void ThemHocSinhVaoLop()
        {
            if(this.tbStdIdAdd.Text == "")
            {
                MessageBox.Show("Hãy nhập mã số học sinh", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dataEntities db = new dataEntities();
                var stdIdDb = from hs in db.HOCSINHs
                              where hs.MaHocSinh == this.tbStdIdAdd.Text
                              select hs;
                if (stdIdDb.Count() > 0)
                {
                    var stdIdNowDb = from hs in stdIdDb
                                     join ctl in db.CTLOPs on hs.MaHocSinh equals ctl.MaHocSinh
                                     join l in db.LOPs on ctl.MaLop equals l.MaLop
                                     join nh in db.NAMHOCs on l.MaNamHoc equals nh.MaNamHoc
                                     where nh.MaNamHoc == this.cbSchoolYear.SelectedValue.ToString()
                                     select hs;
                    if (stdIdNowDb.Count() == 0)
                    {
                        // Thêm học sinh vào lớp
                        CTLOP cTLOP = new CTLOP();
                        cTLOP.MaHocSinh = this.tbStdIdAdd.Text;
                        cTLOP.MaLop = this.cbClass.SelectedValue.ToString();
                        cTLOP.MaCTL = this.cbClass.SelectedValue.ToString() + "_" + this.tbStdIdAdd.Text;
                        db.CTLOPs.Add(cTLOP);
                        db.SaveChanges();
                        // Thêm học sinh vào lớp

                        HienThiDanhSachHocSinh(db);
                        this.tbStdIdAdd.Text = "";
                        MessageBox.Show("Thêm học sinh vào lớp thành công", "Thêm thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Học sinh này đã được xếp lớp ở năm học này, không thể thêm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Mã số học sinh không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                
            }            
        }

        private void XoaHocSinhKhoiLop()
        {
            try
            {
                if (short.Parse(this.tbStdIDDel.Text) < 1)
                {
                    MessageBox.Show("Giá trị nhập vào không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (short.Parse(this.tbStdIDDel.Text) > sStdNum)
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
                        CTLOP cTLOP = new CTLOP();
                        cTLOP.MaHocSinh = dt.Rows[short.Parse(this.tbStdIDDel.Text) - 1]["MSHS"].ToString();
                        cTLOP.MaLop = this.cbClass.SelectedValue.ToString();
                        MessageBox.Show(cTLOP.MaHocSinh + "\n" + cTLOP.MaLop);
                        //db.CTLOPs.Remove(db.CTLOPs.Where(p => p.MaHocSinh == dt.Rows[short.Parse(this.tbStdIDDel.Text) - 1]["MSHS"].ToString()
                        //    && p.MaLop == this.cbClass.SelectedValue.ToString());
                        //db.SaveChanges();
                        // Xoá học sinh khỏi lớp

                        HienThiDanhSachHocSinh(db);
                        this.tbStdIDDel.Text = string.Empty;
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
            var dataSource = from ctl in db.CTLOPs.AsEnumerable()
                             join hs in db.HOCSINHs.AsEnumerable() on ctl.MaHocSinh equals hs.MaHocSinh
                             where ctl.MaLop == this.cbClass.SelectedValue.ToString()
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

            this.tbStdNum.Text = sStdNum.ToString();
            this.dgvClassDetail.DataSource = dt;
            this.dgvClassDetail.Show();
        }

        private void cbSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataEntities db = new dataEntities();
            CapNhatDanhSachLop(db);
        }

        private void cbGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataEntities db = new dataEntities();
            CapNhatDanhSachLop(db);
        }

        private void cbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataEntities db = new dataEntities();
            HienThiDanhSachHocSinh(db);
        }

        private void Btn_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnHomeScreen_Click(object sender, EventArgs e)
        {
            (this.mainform as TrangChu).Show();
            this.Hide();
        }

        private void btnAddStdToClass_Click(object sender, EventArgs e)
        {
            ThemHocSinhVaoLop();
        }

        private void btnDelStdOutClass_Click(object sender, EventArgs e)
        {
            XoaHocSinhKhoiLop();
        }
    }
}
