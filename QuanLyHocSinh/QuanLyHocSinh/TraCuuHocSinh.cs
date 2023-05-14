﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyHocSinh
{
    public partial class TraCuuHocSinh : Form
    {
        public TraCuuHocSinh()
        {
            InitializeComponent();
            pnStudent_info.Hide();
            pnDadofStudent_Info.Hide();
            pnMomOfStudent_Info.Hide();
            lbThongTinPhuHuynh.Hide();
        }

        void TraCuuHS ()
        {
            dataEntities db = new dataEntities();
            var result1 = from iter in db.HOCSINHs
                          where iter.MaHocSinh == tbStudentID.Text
                          select iter.HoTen;

            //Ko tim duoc HocSinh
            if (result1.Count() == 0) MessageBox.Show("Không tìm thấy học sinh phù hợp với mã số sinh viên đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                var result = from iter1 in db.HOCSINHs
                             join iter2 in db.CTLOPs on iter1.MaHocSinh equals iter2.MaHocSinh
                             join iter3 in db.LOPs on iter2.MaLop equals iter3.MaLop
                             where iter1.MaHocSinh == tbStudentID.Text
                             select new
                             {
                                 name = iter1.HoTen,
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

                foreach (var item in result)
                {
                    //Thông tin cá nhân của học sinh
                    tbHoTen.Text = item.name;
                    tbLop.Text = item.class_name;
                    tbGioiTinh.Text = item.sex;
                    tbNgaySinh.Text = item.dob.ToString();
                    tbDanToc.Text = item.ethnic;
                    tbTonGiao.Text = item.religion;
                    tbQueQuan.Text = item.hometown;
                    tbDiaChi.Text = item.address;
                    tbSDT.Text = item.phone_num;
                    tbEmail.Text = item.email;

                    //Thông tin của cha của học sinh
                    if (item.name_dad != null)
                    {
                        tbHoTenCha.Text = item.name_dad;
                        tbCCCD_Cha.Text = item.id_dad;
                        tbSDT_Cha.Text = item.phonenum_dad;
                        tbNgheNghiep_Cha.Text = item.job_dad;
                        tbNamSinh_Cha.Text = item.yearbirth_dad.ToString();
                    }
                    else
                    {
                        tbHoTenCha.Text = "Không có thông tin";
                        tbCCCD_Cha.Text = "Không có thông tin";
                        tbSDT_Cha.Text = "Không có thông tin";
                        tbNgheNghiep_Cha.Text = "Không có thông tin";
                        tbNamSinh_Cha.Text = "Không có thông tin";
                    }

                    //Thông tin của mẹ của học sinh
                    if (item.name_mom != null) 
                    {
                        tbHoTenMe.Text = item.name_mom;
                        tbCCCD_Me.Text = item.id_mom;
                        tbSDT_Me.Text = item.phonenum_mom;
                        tbNgheNghiepMe.Text = item.job_mom; 
                        tbNamSinhMe.Text = item.yearbirth_mom.ToString();
                    }
                    else
                    {
                        tbHoTenMe.Text = "Không có thông tin";
                        tbCCCD_Me.Text = "Không có thông tin";
                        tbSDT_Me.Text = "Không có thông tin";
                        tbNgheNghiepMe.Text = "Không có thông tin";
                        tbNamSinhMe.Text = "Không có thông tin";
                    }                       
                }

                pnStudent_info.Show();
                lbThongTinPhuHuynh.Show();
                pnDadofStudent_Info.Show();
                pnMomOfStudent_Info.Show();
            }
        }

        private void BtnFindInfoStudent_Click(object sender, EventArgs e)
        {
            TraCuuHS();
        }
    }
}
