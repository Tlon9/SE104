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
    public partial class BangDiemMonHocCuaLopTrongNam : Form
    {
        public BangDiemMonHocCuaLopTrongNam()
        {
            InitializeComponent();
            dataEntities data = new dataEntities();
            var ComboBoxSubjectsSource = from obj in data.MONHOCs select obj;
            comboBoxSubject.DataSource = ComboBoxSubjectsSource.ToList();
            comboBoxSubject.DisplayMember = "TenMonHoc";
            comboBoxSubject.ValueMember = "MaMonHoc";
            var comboxClassSource = from obj in data.LOPs select obj;
            comboBoxClass.DataSource = comboxClassSource.ToList();
            comboBoxClass.DisplayMember = "TenLop";
            comboBoxClass.ValueMember = "MaLop";
            var comBoxYear = from obj in data.NAMHOCs select obj;
            comboBoxYear.DataSource = comBoxYear.ToList();
            comboBoxYear.DisplayMember = "NamHoc1";
            comboBoxYear.ValueMember = "MaNamHoc";
            panelPrint.Hide();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
        struct HSformat
        {
            private int stt;
            private string MaHocSinh;
            private string Hoten;
            private List<string> list_scoreAverage;
            private string DiemTBCanam;
            private string Xeploai;

            public List<string> List_scoreAverage
            {
                get { return list_scoreAverage; }
                set { list_scoreAverage = value; }
            }
            public int STT { get { return stt; } set { stt = value; } }
            public string MHS { get { return MaHocSinh; } set { MaHocSinh = value; } }
            public string HOTEN { get { return Hoten; } set { Hoten = value; } }

            public string DIEMTBCANAM { get { return DiemTBCanam; } set { DiemTBCanam = value; } }
            public string XEPLOAI { get { return Xeploai; } set { Xeploai = value; } }
        }
        double getTS_DiemTB(string a)
        {
            dataEntities dtb = new dataEntities();
            foreach (var item in dtb.HOCKies)
            {
                if (item.MaHocKy == a)
                {
                    return Convert.ToDouble(item.TrongSo);
                }
            }
            return 0;
        }
        string funcXepLoai(string t)
        {
            dataEntities data = new dataEntities();
            var reSource = from r in data.XEPLOAIs
                           select r;
            double a;
            if (t != string.Empty)
                a = Convert.ToDouble(t);
            else
                return "HSR";
            foreach (var item in reSource)
            {
                if (a >= Convert.ToDouble(item.DiemToiThieu) && a <= Convert.ToDouble(item.DiemToiDa))
                {
                    return item.MaXepLoai;
                }
            }
            return "HSR";
        }
        string funcTenXeploai(string t)
        {
            dataEntities data = new dataEntities();
            var reSource = from r in data.XEPLOAIs
                           select r;
            double a;
            string result = "Không";
            if (t != string.Empty)
            {
                a = Convert.ToDouble(t);
                foreach (var item in reSource)
                {
                    if (a >= Convert.ToDouble(item.DiemToiThieu) && a <= Convert.ToDouble(item.DiemToiDa))
                    {
                        result = item.TenXepLoai;
                    }
                }
            }
            else
                result = "Không";
            result = (result == "Không") ? null : result;
            return result;

        }

        Dictionary<string, int> keyValuePairs2 = new Dictionary<string, int>();
        List<TextBox> list_txb_xeploai = new List<TextBox>();
        List<TextBox> list_txb_ratio = new List<TextBox>();
        private void BangDiemMonHocCuaLopTrongNamHoc_Load(object sender, EventArgs e)
        {
            dataEntities dtb = new dataEntities();
            int index_ = 0;
            int x = 0;
            int y = 0;
            foreach (var i in dtb.XEPLOAIs)
            {
                if (i.MaXepLoai != "HSR")
                {
                    Label lb = new Label();
                    Label lb_ratio = new Label();
                    lb.Text = "Số học sinh xếp loại " + i.TenXepLoai;
                    lb.Location = new System.Drawing.Point(x, y);
                    lb.AutoSize = true;
                    lb_ratio.Text = "Tỉ lệ học sinh xếp loại " + i.TenXepLoai;
                    lb_ratio.Location = new System.Drawing.Point(x + 400, y);
                    lb_ratio.AutoSize = true;
                    TextBox txb = new TextBox();
                    txb.ReadOnly = true;
                    txb.Name = i.MaXepLoai;
                    txb.Location = new System.Drawing.Point(x + 200, y);
                    txb.AutoSize = true;
                    list_txb_xeploai.Add(txb);
                    TextBox txb_ratio = new TextBox();
                    txb_ratio.ReadOnly = true;
                    txb_ratio.Name = i.MaXepLoai;
                    txb_ratio.Location = new System.Drawing.Point(x + 600, y);
                    txb_ratio.AutoSize = true;
                    list_txb_ratio.Add(txb_ratio);
                    panelClassifyYear.Controls.Add(txb);
                    panelClassifyYear.Controls.Add(txb_ratio);
                    panelClassifyYear.Controls.Add(lb);
                    panelClassifyYear.Controls.Add(lb_ratio);
                    y += 40;
                }
                //list_xeploai.Add(0);
                keyValuePairs2.Add(i.MaXepLoai, index_);
                index_++;
            }
        }
        private void buttonPrint_Click(object sender, EventArgs e)
        {
            dataEntities dtb = new dataEntities();
            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
            int t = 0;
            foreach (var i in dtb.HOCKies)
            {
                keyValuePairs.Add(i.MaHocKy, t);
                t++;
            }
            var reSource = from scr in dtb.KETQUA_MONHOC_HOCSINH
                           join cls in dtb.CTLOPs on scr.MaHocSinh equals cls.MaHocSinh
                           join cls1 in dtb.HOCSINHs on cls.MaHocSinh equals cls1.MaHocSinh
                           where scr.MaMonHoc == comboBoxSubject.SelectedValue.ToString() && scr.MaNamHoc == comboBoxYear.SelectedValue.ToString() && cls.MaLop == comboBoxClass.SelectedValue.ToString() && scr.DiemTB != null
                           group new { scr, cls, cls1 }
                           by new { scr.MaHocSinh, cls1.HoTen, scr.MaHocKy, scr.DiemTB, scr.MaXepLoai }
                           into g
                           select new { g.Key.MaHocSinh, g.Key.HoTen, g.Key.MaHocKy, g.Key.DiemTB, g.Key.MaXepLoai };
            int index = -1;
            List<HSformat> HS_list = new List<HSformat>();
            HSformat temp = new HSformat();
            int numberSemester = dtb.HOCKies.Count();
            double temp_DiemTB = 0;
            double SumTS = 0;
            foreach (var i in dtb.HOCKies)
            {
                SumTS += Convert.ToDouble(i.TrongSo);
            }
            int count = 0;
            foreach (var item in reSource)
            {
                if (index == -1 || (index != -1 && HS_list[index].MHS != item.MaHocSinh))
                {
                    List<string> list_temp = new List<string>();
                    for (int j = 0; j < numberSemester; j++)
                        list_temp.Add(null);
                    index += 1;
                    temp.STT = index + 1;
                    temp.MHS = item.MaHocSinh;
                    temp.HOTEN = item.HoTen;
                    temp.List_scoreAverage = list_temp;
                    HS_list.Add(temp);
                    count = 0;
                    temp_DiemTB = 0;
                }
                temp.List_scoreAverage[keyValuePairs[item.MaHocKy]] = item.DiemTB.ToString();
                temp_DiemTB += Convert.ToDouble(item.DiemTB) * getTS_DiemTB(item.MaHocKy);
                count++;
                if (count == numberSemester)
                {
                    temp_DiemTB = temp_DiemTB / SumTS;
                    temp.DIEMTBCANAM = temp_DiemTB.ToString();
                    temp.XEPLOAI = funcTenXeploai(temp_DiemTB.ToString());
                    temp_DiemTB = 0;
                    count = 0;
                }
                else
                {
                    if ((index + 1 == HS_list.Count()) || (index + 1 != -1 && HS_list[index + 1].MHS != item.MaHocSinh))
                    {
                        temp.DIEMTBCANAM = null;
                        temp.XEPLOAI = null;
                    }
                }
                HS_list[index] = temp;
            }
            if (reSource.Count() == 0)
            {
                MessageBox.Show("Không tìm thấy dữ liệu phù hợp", "Error", MessageBoxButtons.OK);
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("STT", typeof(int));
                dt.Columns.Add("Ma hoc sinh", typeof(string));
                dt.Columns.Add("Ho ten", typeof(string));
                foreach (var ktem in dtb.HOCKies)
                {
                    dt.Columns.Add(ktem.HocKy1, typeof(string));
                }
                dt.Columns.Add("TB ca nam", typeof(string));
                dt.Columns.Add("Xep loai", typeof(string));
                for (int i = 0; i < HS_list.Count; i++)
                {
                    DataRow row1 = dt.NewRow();
                    row1["STT"] = HS_list[i].STT;
                    row1["Ma hoc sinh"] = HS_list[i].MHS;
                    row1["Ho ten"] = HS_list[i].HOTEN;
                    int i_temp = 0;
                    foreach (var ktem in dtb.HOCKies)
                    {
                        row1[ktem.HocKy1] = HS_list[i].List_scoreAverage[i_temp];
                        i_temp++;
                    }
                    row1["TB ca nam"] = HS_list[i].DIEMTBCANAM;
                    row1["Xep loai"] = HS_list[i].XEPLOAI;
                    dt.Rows.Add(row1);
                }
                string nameofgrid;
                nameofgrid = "Bảng điểm môn " + comboBoxSubject.Text.ToString() + " của lớp " + comboBoxClass.Text.ToString() + " năm học " + comboBoxYear.Text.ToString();
                labelNameOfGrid1.Text = nameofgrid;
                int x = dataGridView1.Location.X + (dataGridView1.Width / 2);
                x -= labelNameOfGrid1.Width / 2;
                int y = dataGridView1.Location.Y + dataGridView1.Height + 20;
                labelNameOfGrid1.Location = new System.Drawing.Point(x, y);
                dataGridView1.DataSource = dt;
                dataGridView1.Show();
            }
            List<int> list_xeploai = new List<int>();
            foreach (var i in dtb.XEPLOAIs)
            {
                list_xeploai.Add(0);
            }
            int numberofClass = HS_list.Count;
            if (numberofClass > 0)
            {
                foreach (var i in HS_list)
                {
                    foreach (var j in dtb.XEPLOAIs)
                    {
                        if (i.XEPLOAI == j.TenXepLoai)
                        {
                            list_xeploai[keyValuePairs2[j.MaXepLoai]]++;
                        }
                    }
                }
                foreach (var i in list_txb_xeploai)
                {
                    i.Text = list_xeploai[keyValuePairs2[i.Name]].ToString();
                }
                foreach (var i in list_txb_ratio)
                {
                    i.Text = (list_xeploai[keyValuePairs2[i.Name]] * 100 / numberofClass).ToString() + "%";
                }
            }
            //dataGridView1.Show();
            panelClassifyYear.Show();
            panelPrint.Show();
        }
    }
}