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
        private short sIndex;
        private DataTable dt;

        public LapDanhSachLop()
        {
            InitializeComponent();

            
            this.dgvClassDetail.Hide();
            this.dgvClassDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClassDetail.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dt = new DataTable();
            dt.Columns.Add("STT", typeof(byte)).ReadOnly = true;
            dt.Columns.Add("MSHS", typeof(String)).ReadOnly = false;
            dt.Columns.Add("Họ tên", typeof(String)).ReadOnly = true;
            dt.Columns.Add("Giới tính", typeof(String)).ReadOnly = true;
            dt.Columns.Add("Ngày sinh", typeof(DateTime)).ReadOnly = true;
            dt.Columns.Add("Địa chỉ", typeof(String)).ReadOnly = true;
            dt.Columns.Add("SĐT", typeof(String)).ReadOnly = true;
        }

        private void LapDanhSachLop_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'duLieu.LOP' table. You can move, or remove it, as needed.
            this.lOPTableAdapter.Fill(this.duLieu.LOP);

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
                                     where nh.NamHoc1 == this.cbSchoolYear.Text
                                     select hs;
                    if (stdIdNowDb.Count() == 0)
                    {
                        // Thêm học sinh vào lớp

                        // Thêm học sinh vào lớp

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
            //dataEntities db = new dataEntities();
            
            try
            {
                if (short.Parse(this.tbStdIDDel.Text) < 1)
                {
                    MessageBox.Show("Giá trị nhập vào không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (short.Parse(this.tbStdIDDel.Text) >= sIndex)
                {
                    MessageBox.Show("Số thứ tự lớn hơn sĩ số lớp", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Xoá học sinh khỏi lớp

                    // Xoá học sinh khỏi lớp

                    MessageBox.Show("Xoá học sinh khỏi lớp thành công", "Xoá thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void HienThiDanhSachLop()
        {
            dataEntities db = new dataEntities();
            var dataSource = from ctl in db.CTLOPs.AsEnumerable()
                             join hs in db.HOCSINHs.AsEnumerable() on ctl.MaHocSinh equals hs.MaHocSinh
                             join l in db.LOPs.AsEnumerable() on ctl.MaLop equals l.MaLop
                             where l.MaLop == this.cbClass.Text
                             group new { ctl, hs, l }
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

            sIndex = 1;
            foreach (var std in dataSource)
            {
                DataRow row = dt.NewRow();
                row["STT"] = sIndex;
                row["MSHS"] = std.MaHocSinh;
                row["Họ tên"] = std.HoTen;
                row["Giới tính"] = std.GioiTinh;
                row["Ngày sinh"] = std.NgaySinh;
                row["Địa chỉ"] = std.DiaChi;
                row["SĐT"] = std.SDT;

                dt.Rows.Add(row);
                sIndex++;
            }

            this.tbStdNum.Text = sIndex.ToString();
            this.dgvClassDetail.DataSource = dt;
            this.dgvClassDetail.Show();
        }

        private void cbSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dgvClassDetail.Hide();
            dataEntities db = new dataEntities();
            this.cbClass.DataSource = from l in db.LOPs
                                      join nh in db.NAMHOCs on l.MaNamHoc equals nh.MaNamHoc
                                      join k in db.KHOIs on l.MaKhoi equals k.MaKhoi
                                      where nh.NamHoc1 == this.cbSchoolYear.Text
                                      && k.TenKhoi == this.cbGrade.Text
                                      orderby l.MaLop ascending
                                      select l.TenLop;
        }

        private void cbGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dgvClassDetail.Hide();
            dataEntities db = new dataEntities();
            this.cbClass.DataSource = from l in db.LOPs
                                      join nh in db.NAMHOCs on l.MaNamHoc equals nh.MaNamHoc
                                      join k in db.KHOIs on l.MaKhoi equals k.MaKhoi
                                      where nh.NamHoc1 == this.cbSchoolYear.Text
                                      && k.TenKhoi == this.cbGrade.Text
                                      orderby l.MaLop ascending
                                      select l.TenLop;
        }

        private void cbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            HienThiDanhSachLop();
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
            TrangChu newform = new TrangChu();
            this.Hide();
            newform.ShowDialog();
            this.Show();
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
