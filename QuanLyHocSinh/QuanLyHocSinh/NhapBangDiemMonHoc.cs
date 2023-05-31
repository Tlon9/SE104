
//using QuanLyHocSinh.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
//using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyHocSinh
{   public partial class LapBangDiemMonHoc : Form
    {
        dataEntities data = new dataEntities();
        public LapBangDiemMonHoc()
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
            var comboxClassSemester = from obj in data.HOCKies select obj;
            comboBoxSemester.DataSource = comboxClassSemester.ToList();
            comboBoxSemester.DisplayMember = "HocKy1";
            comboBoxSemester.ValueMember = "MaHocKy";
            panelInput.Hide();
            panelPrint.Hide();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

        }
        private void textBoxScore_TextChanged(object sender, EventArgs e)
        {
            TextBox txb = (TextBox)sender;
            if (Double.TryParse(txb.Text, out double score))
            {
                if (score < 0 || score > 10)
                {
                    MessageBox.Show("Điểm phải là một số thực không bé hơn 0 và không lớn hơn 10", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (txb.Text != string.Empty)
            {
                MessageBox.Show("Điểm phải là một số thực không bé hơn 0 và không lớn hơn 10", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        List<TextBox> list = new List<TextBox>();
        private void LapBangDiemMonHoc_Load(object sender, EventArgs e)
        {
            var Score = from scr in data.THANHPHANs
                        select new { scr.MaThanhPhan, scr.TenThanhPhan };

            int x = 100;
            int y = 0;
            panelScores.AutoSize = true;
            foreach (var i in Score)
            {
                TextBox textBox = new TextBox();
                Label lb = new Label();
                lb.Text = i.TenThanhPhan.ToString();
                textBox.Name = i.MaThanhPhan.ToString();
                textBox.Location = new Point(x, y);
                lb.Location = new Point(x - 100, y+5);
                textBox.TextChanged += textBoxScore_TextChanged;
                panelScores.Controls.Add(textBox);
                panelScores.Controls.Add(lb);
                list.Add(textBox);
                y += 40;
            }
            /*int index = 0;
            x = 100;
            y = 0;
            panelNumberOfClassify.AutoSize = true;
            foreach (var i in data.XEPLOAIs)
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
                    panelNumberOfClassify.Controls.Add(txb);
                    panelNumberOfClassify.Controls.Add(txb_ratio);
                    panelNumberOfClassify.Controls.Add(lb);
                    panelNumberOfClassify.Controls.Add(lb_ratio);
                    y += 40;
                    keyValuePairs.Add(i.MaXepLoai, index);
                    index++;
                }
                else continue;
            }*/
        }
        int getNumberofThanhPhan()
        {
            var re = from obj in data.THANHPHANs select obj;
            return re.Count();
        }
        struct DIEMformat
        {
            private int stt;
            private string MaHocSinh;
            private string Hoten;
            private List<string> list_score;
            private string DiemTB;
            private string Xeploai;

            public List<string> List_score
            {
                get { return list_score; }
                set { list_score = value; }
            }
            public int STT { get { return stt; } set { stt = value; } }
            public string MHS { get { return MaHocSinh; } set { MaHocSinh = value; } }
            public string HOTEN { get { return Hoten; } set { Hoten = value; } }
            public string DIEMTB { get { return DiemTB; } set { DiemTB = value; } }
            public string XEPLOAI { get { return Xeploai; } set { Xeploai = value; } }
        }
        private string ConvertListToString(List<string> myList)
        {
            return string.Join(" ", myList);
        }

        void ShowGrid(string i_o)
        {
            Dictionary<string, int> ScoreDict = new Dictionary<string, int>();
            int k = 0;
            foreach (var item in data.THANHPHANs)
            {
                ScoreDict.Add(item.MaThanhPhan.ToString(), k++);
            }
            var reSource1 = from scr1 in data.KETQUA_MONHOC_HOCSINH.AsEnumerable()
                           join scr in data.DIEMs.AsEnumerable() on scr1.MaKetQua equals scr.MaKetQua
                           join cls in data.CTLOPs.AsEnumerable() on scr1.MaHocSinh equals cls.MaHocSinh    
                           join cls1 in data.HOCSINHs.AsEnumerable() on cls.MaHocSinh equals cls1.MaHocSinh
                           where (comboBoxSubject.SelectedValue.ToString() == scr1.MaMonHoc && comboBoxYear.SelectedValue.ToString() == scr1.MaNamHoc && cls.MaLop == comboBoxClass.SelectedValue.ToString() && scr1.MaHocKy == comboBoxSemester.SelectedValue.ToString())      
                           group new {scr, scr1, cls}
                           by new { scr1.MaKetQua,Hoten = cls1.HoTen, scr1.MaHocSinh, scr.MaThanhPhan, scr.Diem1, scr1.DiemTB, scr1.MaXepLoai }
                           into g
                           select new { MaKQ = g.Key.MaKetQua, Hoten = g.Key.Hoten,MaHocSinh = g.Key.MaHocSinh, MaThanhPhan = g.Key.MaThanhPhan, Diem = g.Key.Diem1, DiemTB = g.Key.DiemTB, Xeploai = g.Key.MaXepLoai };
            var reSource = from scr in reSource1
                     join cls1 in data.XEPLOAIs.AsEnumerable() on scr.Xeploai equals cls1.MaXepLoai.ToString()
                     select new { MaKQ = scr.MaKQ, Hoten = scr.Hoten, MaHocSinh = scr.MaHocSinh, MaThanhPhan = scr.MaThanhPhan, Diem = scr.Diem, DiemTB = scr.DiemTB, Xeploai = (cls1.TenXepLoai == "Không") ? string.Empty : cls1.TenXepLoai };
            int count = getNumberofThanhPhan();
            List<DIEMformat> reS = new List<DIEMformat> { };
            DIEMformat temp = new DIEMformat();
            int index = -1;

            foreach (var i in reSource)
            {
                if (index == -1 || (index != -1 && reS[index].MHS != i.MaHocSinh))
                {
                    List<string> list_temp = new List<string>();
                    for (int j = 0; j < count; j++)
                        list_temp.Add(null);
                    index += 1;
                    temp.STT = index + 1;
                    temp.MHS = i.MaHocSinh;
                    temp.HOTEN = i.Hoten;
                    temp.DIEMTB = i.DiemTB.ToString();
                    temp.XEPLOAI = i.Xeploai.ToString();
                    temp.List_score = list_temp;
                    reS.Add(temp);
                }
                temp.List_score[ScoreDict[i.MaThanhPhan]] = i.Diem.ToString();
                reS[index] = temp;
            }
            //if (reS.Count() == 0) MessageBox.Show("Không tìm thấy dữ liệu phù hợp", "Error", MessageBoxButtons.OK);
            //else
            //{
                DataTable dt = new DataTable();
                dt.Columns.Add("STT", typeof(int));
                dt.Columns.Add("Ma hoc sinh", typeof(string));
                dt.Columns.Add("Ho ten", typeof(string));
                foreach (var ktem in data.THANHPHANs)
                {
                    dt.Columns.Add(ktem.TenThanhPhan, typeof(string));
                }    
                dt.Columns.Add("Diem TB", typeof(string));
                dt.Columns.Add("Xep loai", typeof(string));
                
                for (int i = 0; i< reS.Count(); i++)
                {
                    DataRow row1 = dt.NewRow();
                    row1["STT"] = reS[i].STT;
                    row1["Ma hoc sinh"] = reS[i].MHS;
                    row1["Ho ten"] = reS[i].HOTEN;
                    string listDiem = ConvertListToString(reS[i].List_score);
                    int i_temp = 0;
                    foreach (var ktem in data.THANHPHANs)
                    {
                        row1[ktem.TenThanhPhan] = reS[i].List_score[i_temp];
                        i_temp++;
                    }
                    row1["Diem TB"] = reS[i].DIEMTB;
                    row1["Xep loai"] = reS[i].XEPLOAI;
                    dt.Rows.Add(row1);
                }
                if (i_o == "1")
                { 
                    dataGridView1.DataSource = dt;
                    dataGridView1.Show(); 
                }
                else
                {
                    dataGridView2.DataSource = dt;
                    dataGridView2.Show();
                }
            //}

        }
        private void buttonInput_Click(object sender, EventArgs e)
        {
            if (panelPrint.Visible) { panelPrint.Hide(); }
            if (panelInput.Visible) { panelInput.Hide(); }
            var comboxID = from obj in data.CTLOPs where obj.MaLop == comboBoxClass.SelectedValue.ToString() select obj.MaHocSinh;
            comboBoxID.DataSource = comboxID.ToList();

            var reSource1 = from scr1 in data.KETQUA_MONHOC_HOCSINH
                           join cls in data.CTLOPs on scr1.MaHocSinh equals cls.MaHocSinh
                           join cls1 in data.HOCSINHs on cls.MaHocSinh equals cls1.MaHocSinh
                           where comboBoxSubject.SelectedValue == scr1.MaMonHoc && comboBoxYear.SelectedValue == scr1.MaNamHoc && cls.MaLop == comboBoxClass.SelectedValue && scr1.MaHocKy == comboBoxSemester.SelectedValue
                            select new { MaKQ = scr1.MaKetQua };

            string nameofgrid;
            nameofgrid = "Bảng điểm môn " + comboBoxSubject.Text.ToString() + " của lớp " + comboBoxClass.Text.ToString() + " học kỳ " + comboBoxSemester.Text.ToString() + " năm học " + comboBoxYear.Text.ToString();
            labelNameOfGrid1.Text = nameofgrid;
            int x = dataGridView1.Location.X + (dataGridView1.Width / 2);
            x -= labelNameOfGrid1.Width / 2;
            int y = dataGridView1.Location.Y + dataGridView1.Height + 20;
            labelNameOfGrid1.Location = new System.Drawing.Point(x, y);
            ShowGrid("1");
            panelInput.Show();
            
        }
        private void comboBoxID_SelectedValueChanged(object sender, EventArgs e)
        {
            if (list.Count() == 0) return;
            var a = from obj in data.HOCSINHs where obj.MaHocSinh == comboBoxID.Text select obj.HoTen;
            textBoxName.Text = a.ToList().SingleOrDefault();
            var reSource1 = from scr in data.KETQUA_MONHOC_HOCSINH
                            join cls in data.CTLOPs on scr.MaHocSinh equals cls.MaHocSinh
                            join cls1 in data.XEPLOAIs on scr.MaXepLoai equals cls1.MaXepLoai
                            where comboBoxID.Text == scr.MaHocSinh && comboBoxSubject.SelectedValue == scr.MaMonHoc && comboBoxYear.SelectedValue == scr.MaNamHoc && comboBoxSemester.SelectedValue == scr.MaHocKy && cls.MaLop == comboBoxClass.SelectedValue
                            select new {MaKQ = scr.MaKetQua,  DiemTB = scr.DiemTB.ToString(), Xeploai = (cls1.TenXepLoai == "Không" ? string.Empty : cls1.TenXepLoai) };

            if (reSource1.Count() != 0)
            {
                string maKQ = reSource1.ToList().SingleOrDefault().MaKQ;
                var re = from scr in data.DIEMs
                         where scr.MaKetQua == maKQ
                         select new { scr.MaThanhPhan, scr.Diem1 };
                foreach (var j in list)
                {
                    int check = 1;
                    foreach (var i in re)
                    {
                        if (j.Name == i.MaThanhPhan)
                        {
                            j.Text = i.Diem1.ToString();
                            check = 0;
                        }
                    }
                    if(check == 1)
                    {
                        j.Text = null;
                    }    
                }
                textBoxAverageScore.Text = reSource1.ToList().SingleOrDefault().DiemTB;
                textBoxClassify.Text = reSource1.ToList().SingleOrDefault().Xeploai.ToString();
            }
            else
            {
                foreach (var j in list)
                {
                        j.Text = null;
                }
                textBoxAverageScore.Text = null;
                textBoxClassify.Text = null;
            }
        }
        private void buttonLook_Click(object sender, EventArgs e)
        {
            ShowGrid("1");
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string name;
            if (e.RowIndex > -1 && dataGridView1.Rows[e.RowIndex].Cells[1].Value != null)
            {
                name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                comboBoxID.Text = name;
            }

        }
        string funcXepLoai(string t)
        {
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
        double getTrongSo(string a)
        {
            foreach (var item in data.THANHPHANs)
            {
                if (item.MaThanhPhan == a)
                {
                    return Convert.ToDouble(item.TrongSo);
                }
            }
            return 0;
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            var reSource1 = from scr in data.KETQUA_MONHOC_HOCSINH
                            join cls in data.CTLOPs on scr.MaHocSinh equals cls.MaHocSinh
                            where comboBoxID.Text == scr.MaHocSinh && comboBoxSubject.SelectedValue == scr.MaMonHoc && comboBoxYear.SelectedValue == scr.MaNamHoc && comboBoxSemester.SelectedValue == scr.MaHocKy && cls.MaLop == comboBoxClass.SelectedValue
                            select scr.MaKetQua;
            var temp = from scr in data.DIEMs
                       select scr.MaDiem;
            var temp_kq = data.KETQUA_MONHOC_HOCSINH.OrderByDescending(row => row.MaKetQua).Select(row=>row.MaKetQua).FirstOrDefault();
            var temp_index = data.DIEMs.OrderByDescending(row => row.MaDiem).Select(row => row.MaDiem).FirstOrDefault();
            string temp2_kq = temp_kq.ToString();
            string temp2_index = temp_index.ToString();
            //int index = temp.Select(int.Parse).ToList().Max();
            int index_kq = Convert.ToInt32(temp2_kq.Substring(temp2_kq.Length - 2));
            string stringWithoutLastTwo = temp2_kq.Substring(0, temp2_kq.Length - 2);
            int index = Convert.ToInt32(temp2_index.Substring(temp2_index.Length - 4));
            string stringWithoutLastTwo_index = temp2_index.Substring(0, temp2_index.Length - 4);
            KETQUA_MONHOC_HOCSINH new_hs;
            double DIEMTB = 0;
            int check = 0;
            if (reSource1.Count() == 0)
            {
                new_hs = new KETQUA_MONHOC_HOCSINH() { MaKetQua = stringWithoutLastTwo + (index_kq + 1).ToString(), MaMonHoc = comboBoxSubject.SelectedValue.ToString(), MaHocSinh = comboBoxID.SelectedValue.ToString(), MaNamHoc = comboBoxYear.SelectedValue.ToString(), MaHocKy = comboBoxSemester.SelectedValue.ToString() };
                foreach (TextBox txb in list)
                {
                    DIEM diemTP = new DIEM();
                    diemTP.MaDiem = stringWithoutLastTwo_index + (++index).ToString() ;
                    diemTP.MaKetQua = new_hs.MaKetQua;
                    diemTP.MaThanhPhan = txb.Name;
                    if (txb.Text != string.Empty)
                    {
                        diemTP.Diem1 = Convert.ToDouble(txb.Text);
                        DIEMTB += Convert.ToDouble(txb.Text) * getTrongSo(txb.Name);
                    }
                    else
                    {
                        diemTP.Diem1 = null;
                        check = 1;
                    }
                    data.DIEMs.Add(diemTP);
                }
                data.KETQUA_MONHOC_HOCSINH.Add(new_hs);
            }
            else
            {
                string ID = reSource1.ToList().SingleOrDefault();
                new_hs = data.KETQUA_MONHOC_HOCSINH.Where(p => p.MaKetQua == ID).FirstOrDefault();
                var check_E = from scr in data.DIEMs
                              where scr.MaKetQua == ID
                              select new { MaThanhPhan = scr.MaThanhPhan };
                foreach (var tb in data.THANHPHANs)
                {
                    int isE = 0;
                    foreach (var t in check_E)
                    {
                        if (tb.MaThanhPhan == t.MaThanhPhan)
                            isE = 1;
                    }
                    if (isE == 0)
                    {
                        DIEM diemTP = new DIEM();
                        diemTP.MaDiem = stringWithoutLastTwo_index + (++index).ToString();
                        diemTP.MaKetQua = new_hs.MaKetQua;
                        diemTP.MaThanhPhan = tb.MaThanhPhan;
                        TextBox txb_temp = list.FirstOrDefault(b => b.Name == tb.MaThanhPhan);
                        if (txb_temp.Text != string.Empty)
                        {
                            diemTP.Diem1 = Convert.ToDouble(txb_temp.Text);
                            DIEMTB += Convert.ToDouble(txb_temp.Text)*getTrongSo(tb.MaThanhPhan);
                        }
                        else
                        { 
                            check = 1;
                            diemTP.Diem1 = null;
                        }
                        data.DIEMs.Add(diemTP);
                    }
                }
                foreach (TextBox txb in list)
                {
                    foreach (var k in data.DIEMs)
                    {
                        if (k.MaKetQua == ID && k.MaThanhPhan == txb.Name)
                        {
                            if (txb.Text != string.Empty)
                            {
                                k.Diem1 = Convert.ToDouble(txb.Text);
                                DIEMTB += Convert.ToDouble(txb.Text) * getTrongSo(txb.Name);
                            }
                            else
                            {
                                k.Diem1 = null;
                                check = 1;
                            }
                        }           
                    }
                }
            }
            if (check == 1)
            {
                new_hs.DiemTB = null;
                textBoxAverageScore.Text = string.Empty;
            }
            else
            {
                DIEMTB = Math.Round(DIEMTB, 1);
                new_hs.DiemTB = DIEMTB;
            }
            textBoxAverageScore.Text = new_hs.DiemTB.ToString();
            new_hs.MaXepLoai = funcXepLoai(new_hs.DiemTB.ToString());
            
            try
            {
                data.SaveChanges();
            }
            catch (DbEntityValidationException e1)
            {
                Console.WriteLine(e1);
            }
            string tenxl = data.XEPLOAIs.Where(p => p.MaXepLoai == new_hs.MaXepLoai).Select(p => p.TenXepLoai).SingleOrDefault().ToString();
            if (tenxl != "Không")
                textBoxClassify.Text = tenxl;
            else
                textBoxClassify.Text = string.Empty;
            ShowGrid("1");
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var reSource1 = from scr in data.KETQUA_MONHOC_HOCSINH
                            join cls in data.CTLOPs on scr.MaHocSinh equals cls.MaHocSinh
                            where comboBoxID.Text == scr.MaHocSinh && comboBoxSubject.SelectedValue == scr.MaMonHoc && comboBoxYear.SelectedValue == scr.MaNamHoc && comboBoxSemester.SelectedValue == scr.MaHocKy && cls.MaLop == comboBoxClass.SelectedValue
                            select scr.MaKetQua;
            string ID = reSource1.ToList().SingleOrDefault();
            var reSource_diem = data.DIEMs.Where(p => p.MaKetQua == ID);
            foreach (var i in reSource_diem)
            {
                DIEM temp = i as DIEM;
                data.DIEMs.Remove(temp);
            }
            KETQUA_MONHOC_HOCSINH hs = data.KETQUA_MONHOC_HOCSINH.Where(p => p.MaKetQua == ID).FirstOrDefault();
            data.KETQUA_MONHOC_HOCSINH.Remove(hs);
            data.SaveChanges();
            comboBoxID.Text = string.Empty;
            textBoxName.Text = string.Empty;
            foreach (TextBox i in list)
            {
                i.Text = null;
            }
            textBoxAverageScore.Text = string.Empty;
            textBoxClassify.Text = string.Empty;
            ShowGrid("1");
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            panelNumberOfClassify.Controls.Clear();
            if (panelInput.Visible) { panelInput.Hide(); }
            if (panelPrint.Visible) { panelPrint.Hide(); }
            var reSource = from scr in data.KETQUA_MONHOC_HOCSINH
                            join cls in data.CTLOPs on scr.MaHocSinh equals cls.MaHocSinh
                            where comboBoxSubject.SelectedValue == scr.MaMonHoc && comboBoxYear.SelectedValue == scr.MaNamHoc && comboBoxSemester.SelectedValue == scr.MaHocKy && cls.MaLop == comboBoxClass.SelectedValue
                            select new  { MaKQ = scr.MaKetQua, MaHS = scr.MaHocSinh, DiemTB = scr.DiemTB, Xeploai = scr.MaXepLoai};
            List<int> list_xeploai = new List<int>();
            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
            List<TextBox> list_txb_xeploai = new List<TextBox>();
            List<TextBox> list_txb_ratio = new List<TextBox>();
            int index = 0;
            int x = 100;
            int y = 0;
            foreach (var i in data.XEPLOAIs)
            {
                panelNumberOfClassify.AutoSize = true;
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
                    panelNumberOfClassify.Controls.Add(txb);
                    panelNumberOfClassify.Controls.Add(txb_ratio);
                    panelNumberOfClassify.Controls.Add(lb);
                    panelNumberOfClassify.Controls.Add(lb_ratio);
                    y += 40;
                }
                keyValuePairs.Add(i.MaXepLoai, index);
                index++;
                list_xeploai.Add(0);  
            }
            
            int numberofClass = reSource.Count();
            if (numberofClass > 0)
            {
                foreach (var i in reSource)
                {
                    foreach (var j in data.XEPLOAIs)
                    {
                        if (i.Xeploai == j.MaXepLoai)
                        {
                            list_xeploai[keyValuePairs[j.MaXepLoai]]++;
                        }
                    }
                }
                foreach (var i in list_txb_xeploai)
                {
                    i.Text = list_xeploai[keyValuePairs[i.Name]].ToString();
                }
                foreach (var i in list_txb_ratio)
                {
                    i.Text = (list_xeploai[keyValuePairs[i.Name]] * 100 / numberofClass).ToString() + "%";
                }
            }
            string nameofgrid;
            nameofgrid = "Bảng điểm môn " + comboBoxSubject.Text.ToString() + " của lớp " + comboBoxClass.Text.ToString() + " học kỳ " + comboBoxSemester.Text.ToString() + " năm học " + comboBoxYear.Text.ToString();
            labelNameOfGrid2.Text = nameofgrid;
            int x_ = dataGridView2.Location.X + (dataGridView2.Width / 2);
            x_ -= labelNameOfGrid2.Width / 2;
            int y_ = dataGridView2.Location.Y + dataGridView2.Height + 20;
            labelNameOfGrid2.Location = new System.Drawing.Point(x_, y_);
            panelPrint.Show();
            ShowGrid("2");
        }
    }
}
