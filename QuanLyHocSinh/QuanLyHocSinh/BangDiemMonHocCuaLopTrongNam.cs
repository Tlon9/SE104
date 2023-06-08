using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyHocSinh
{
    public partial class BangDiemMonHocCuaLopTrongNam : Form
    {
        public TrangChu formTraCuu { get; set; }
        public BangDiemMonHocCuaLopTrongNam(TrangChu mainform)
        {
            InitializeComponent();
            this.formTraCuu = mainform;
            dataEntities data = new dataEntities();
            var comBoxYear = from obj in data.NAMHOCs select obj;
            var comBoxYear1 = comBoxYear.OrderByDescending(p => p.MaNamHoc);
            comboBoxYear.DataSource = comBoxYear1.ToList();
            comboBoxYear.DisplayMember = "NamHoc1";
            comboBoxYear.ValueMember = "MaNamHoc";
            var comboxClassSource = from obj in data.LOPs where obj.MaNamHoc == comboBoxYear.SelectedValue select obj;
            comboBoxClass.DataSource = comboxClassSource.ToList();
            comboBoxClass.DisplayMember = "TenLop";
            comboBoxClass.ValueMember = "MaLop";
            var ComboBoxSubjectsSource = from obj in data.MonHoc_NamApDung(comboBoxYear.SelectedValue.ToString()) select obj;
            comboBoxSubject.DataSource = ComboBoxSubjectsSource.ToList();
            comboBoxSubject.DisplayMember = "TenMonHoc";
            comboBoxSubject.ValueMember = "MaMonHoc";
            panelPrint.Hide();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
        private void comboBoxYear_SelectedValueChanged(object sender, EventArgs e)
        {
            dataEntities data = new dataEntities();
            var comboxClassSource = from obj in data.LOPs.AsEnumerable() where obj.MaNamHoc == comboBoxYear.SelectedValue.ToString() select obj;
            comboBoxClass.DataSource = comboxClassSource.ToList();
            comboBoxClass.DisplayMember = "TenLop";
            comboBoxClass.ValueMember = "MaLop";
            var ComboBoxSubjectsSource = from obj in data.MonHoc_NamApDung(comboBoxYear.SelectedValue.ToString()) select obj;
            comboBoxSubject.DataSource = ComboBoxSubjectsSource.ToList();
            comboBoxSubject.DisplayMember = "TenMonHoc";
            comboBoxSubject.ValueMember = "MaMonHoc";
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
            var reSource = from r in data.XepLoai_NamApDung(comboBoxYear.SelectedValue.ToString())
                           select r;
            double a;
            var str_K = reSource.Where(p => p.TenXepLoai == "Không");
            string str_Khong = str_K.SingleOrDefault().MaXepLoai.ToString();
            if (t != string.Empty)
                a = Convert.ToDouble(t);
            else
                return str_Khong;
            foreach (var item in reSource)
            {
                if (a >= Convert.ToDouble(item.DiemToiThieu) && a <= Convert.ToDouble(item.DiemToiDa))
                {
                    return item.MaXepLoai;
                }
            }
            return str_Khong;
        }
        string funcTenXeploai(string t)
        {
            dataEntities data = new dataEntities();
            var reSource = from r in data.XepLoai_NamApDung(comboBoxYear.SelectedValue.ToString())
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
        private void Load_Panel(List<TextBox> list_txb_ratio, List<TextBox> list_txb_xeploai)
        {
            dataEntities dtb = new dataEntities();
            int x = 0;
            int y = 0;
            panelClassifyYear.AutoSize = true;
            foreach (var i in dtb.XepLoai_NamApDung(comboBoxYear.SelectedValue.ToString()).OrderByDescending(r => r.DiemToiThieu))
            {
                if (i.TenXepLoai != "Không")
                {
                    Label lb = new Label();
                    Label lb_ratio = new Label();
                    lb.Text = "Số học sinh xếp loại " + i.TenXepLoai;
                    lb.Location = new System.Drawing.Point(x, y);
                    lb.AutoSize = true;
                    lb.Font = new Font("Segoe UI", 10);
                    lb_ratio.Font = new Font("Segoe UI", 10);
                    lb_ratio.Text = "Tỉ lệ học sinh xếp loại " + i.TenXepLoai;
                    lb_ratio.Location = new System.Drawing.Point(x + 500, y);
                    lb_ratio.AutoSize = true;
                    TextBox txb = new TextBox();
                    txb.ReadOnly = true;
                    txb.Name = i.TenXepLoai;
                    txb.Location = new System.Drawing.Point(x + 250, y);
                    txb.AutoSize = true;
                    list_txb_xeploai.Add(txb);
                    TextBox txb_ratio = new TextBox();
                    txb_ratio.ReadOnly = true;
                    txb_ratio.Name = i.TenXepLoai;
                    txb_ratio.Location = new System.Drawing.Point(x + 750, y);
                    txb_ratio.AutoSize = true;
                    list_txb_ratio.Add(txb_ratio);
                    txb.Font = new Font("Segoe UI", 10);
                    txb_ratio.Font = new Font("Segoe UI", 10);
                    panelClassifyYear.Controls.Add(txb);
                    panelClassifyYear.Controls.Add(txb_ratio);
                    panelClassifyYear.Controls.Add(lb);
                    panelClassifyYear.Controls.Add(lb_ratio);
                    y += 40;
                }
            }
        }
        DataTable ratio_Source;
        private void buttonPrint_Click(object sender, EventArgs e)
        {
            panelClassifyYear.Controls.Clear();
            List<TextBox> list_txb_xeploai = new List<TextBox>();
            List<TextBox> list_txb_ratio = new List<TextBox>();
            Load_Panel(list_txb_ratio, list_txb_xeploai);
            dataEntities dtb = new dataEntities();
            Dictionary<string, int> keyValuePairs2 = new Dictionary<string, int>();
            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
            if (comboBoxClass.Text.ToString() == string.Empty || comboBoxSubject.Text.ToString() == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập thông tin đầy đủ", "Error", MessageBoxButtons.OK);
                guna2ImageButton2.Enabled = false;
                //return;
            }
            int t = 0;
            int index_ = 0;
            foreach (var i in dtb.XepLoai_NamApDung(comboBoxYear.SelectedValue.ToString()))
            {
                if (i.TenXepLoai != "Không")
                {
                    keyValuePairs2.Add(i.TenXepLoai, index_);
                    index_++;
                }
            }
            double SumTS = 0;
            foreach (var i in dtb.HocKy_NamApDung(comboBoxYear.SelectedValue.ToString()))
            {
                keyValuePairs.Add(i.MaHocKy, t);
                t++;
                SumTS += Convert.ToDouble(i.TrongSo);
            }
            var reSource = from scr in dtb.KETQUA_MONHOC_HOCSINH
                           join cls in dtb.CTLOPs on scr.MaHocSinh equals cls.MaHocSinh
                           join cls1 in dtb.HOCSINHs on cls.MaHocSinh equals cls1.MaHocSinh
                           where scr.MaMonHoc == comboBoxSubject.SelectedValue && scr.MaNamHoc == comboBoxYear.SelectedValue && cls.MaLop == comboBoxClass.SelectedValue && scr.DiemTB != null
                           group new { scr, cls, cls1 }
                           by new { scr.MaHocSinh, cls1.HoTen, scr.MaHocKy, scr.DiemTB, scr.MaXepLoai }
                           into g
                           select new { g.Key.MaHocSinh, g.Key.HoTen, g.Key.MaHocKy, g.Key.DiemTB, g.Key.MaXepLoai };
            List<HSformat> HS_list = new List<HSformat>();
            if (reSource.Count() == 0)
            {
                MessageBox.Show("Không tìm thấy dữ liệu phù hợp", "Error", MessageBoxButtons.OK);
                guna2ImageButton2.Enabled = false;
            }
            else
            {
                guna2ImageButton2.Enabled = true;
                int index = -1; 
                HSformat temp = new HSformat();
                int numberSemester = dtb.HocKy_NamApDung(comboBoxYear.SelectedValue.ToString()).Count();
                double temp_DiemTB = 0;
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
                        temp.DIEMTBCANAM = Math.Round(temp_DiemTB,1).ToString();
                        temp.XEPLOAI = funcTenXeploai(Math.Round(temp_DiemTB, 1).ToString());
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
                DataTable dt = new DataTable();
                dt.Columns.Add("STT", typeof(int));
                dt.Columns.Add("Mã học sinh", typeof(string));
                dt.Columns.Add("Họ tên", typeof(string));
                foreach (var ktem in dtb.HocKy_NamApDung(comboBoxYear.SelectedValue.ToString()))
                {
                    dt.Columns.Add(ktem.HocKy, typeof(string));
                }
                dt.Columns.Add("TB cả năm", typeof(string));
                dt.Columns.Add("Xếp loại", typeof(string));
                for (int i = 0; i < HS_list.Count; i++)
                {
                    DataRow row1 = dt.NewRow();
                    row1["STT"] = HS_list[i].STT;
                    row1["Mã học sinh"] = HS_list[i].MHS;
                    row1["Họ tên"] = HS_list[i].HOTEN;
                    int i_temp = 0;
                    foreach (var ktem in dtb.HocKy_NamApDung(comboBoxYear.SelectedValue.ToString()))
                    {
                            row1[ktem.HocKy] = HS_list[i].List_scoreAverage[i_temp];
                            i_temp++; 
                    }
                    row1["TB cả năm"] = HS_list[i].DIEMTBCANAM;
                    row1["Xếp loại"] = HS_list[i].XEPLOAI;
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
            foreach (var i in dtb.XepLoai_NamApDung(comboBoxYear.SelectedValue.ToString()))
            {
                if (i.TenXepLoai != "Không")
                    list_xeploai.Add(0);
            }
            int numberofClass = 0;
            foreach (var i in HS_list)
            {
                if (i.XEPLOAI != null) numberofClass ++;
            }
            ratio_Source = new DataTable();
            if (numberofClass > 0)
            {
                foreach (var i in HS_list)
                {
                    foreach (var j in dtb.XepLoai_NamApDung(comboBoxYear.SelectedValue.ToString()))
                    {
                        if (i.XEPLOAI == j.TenXepLoai)
                        {
                            list_xeploai[keyValuePairs2[j.TenXepLoai]]++;
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
                ratio_Source.Columns.Add("Xếp loại", typeof(string));
                ratio_Source.Columns.Add("Số lượng", typeof(int));
                ratio_Source.Columns.Add("Tỉ lệ (%)", typeof(float));
                foreach (var item in list_txb_xeploai)
                {
                    if (list_xeploai[keyValuePairs2[item.Name]] > 0)
                    {
                        DataRow row_ratio = ratio_Source.NewRow();
                        row_ratio["Xếp loại"] = item.Name;
                        row_ratio["Số lượng"] = list_xeploai[keyValuePairs2[item.Name]].ToString();
                        row_ratio["Tỉ lệ (%)"] = (list_xeploai[keyValuePairs2[item.Name]] * 100 / numberofClass);
                        ratio_Source.Rows.Add(row_ratio);
                    }
                }
                chartRatio.DataSource = ratio_Source;
                chartRatio.Series[0].XValueMember = "Xếp loại";
                chartRatio.Series[0].YValueMembers = "Tỉ lệ (%)";
                chartRatio.Series[0].IsValueShownAsLabel = true;
                chartRatio.Show();
            }
            panelClassifyYear.Show();
            panelPrint.Show();
        }

        private void ButtonExportExcel_Click(object sender, EventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];
            worksheet.Name = "Bảng điểm";
            for (int i = 1; i <= dataGridView1.Columns.Count; i++)
            {
                worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                        worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                }
            }
            workbook.Sheets.Add(After: workbook.Sheets[workbook.Sheets.Count]);
            if (ratio_Source.Rows.Count > 0)
            {
                Excel.Worksheet worksheet2 = (Excel.Worksheet)workbook.Sheets[2];
                worksheet2.Name = "Tổng kết";
                worksheet2.Cells[1, 1] = "Xếp loại";
                worksheet2.Cells[1, 2] = "Số lượng";
                worksheet2.Cells[1, 3] = "Tỉ lệ (%)";
                for (int i = 0; i < ratio_Source.Rows.Count; i++)
                {
                    worksheet2.Cells[1][i + 2] = ratio_Source.Rows[i]["Xếp loại"];
                    worksheet2.Cells[2][i + 2] = ratio_Source.Rows[i]["Số lượng"];
                    worksheet2.Cells[3][i + 2] = ratio_Source.Rows[i]["Tỉ lệ (%)"];
                }
            }    
            workbook.Close();
            excel.Quit();
        }

        private void guna2ImageButtonClose1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2ImageButtonMinimize1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2ImageButtonHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            TrangCaNhan newform = new TrangCaNhan();
            this.Hide();
            newform.ShowDialog();
            this.Show();
        }

    }
}
