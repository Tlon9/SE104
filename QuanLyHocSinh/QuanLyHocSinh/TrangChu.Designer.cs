
namespace QuanLyHocSinh
{
    partial class TrangChu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrangChu));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.MenuItemAddStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemListCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemFindStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemScoreBoard = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSubjectScore = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSubjectScore1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSubjectScoreYear = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemFinalReport = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemClassReport = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemFinalReport = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuQuanLyQuyDinh = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelForm = new Guna.UI2.WinForms.Guna2Panel();
            this.ButtonClose = new Guna.UI2.WinForms.Guna2ImageButton();
            this.ButtonMinimize = new Guna.UI2.WinForms.Guna2ImageButton();
            this.MonthCalendar = new System.Windows.Forms.MonthCalendar();
            this.DataGridViewInfo = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.LabelYear = new System.Windows.Forms.Label();
            this.ComboBoxYear = new Guna.UI2.WinForms.Guna2ComboBox();
            this.ButtonSubject = new Guna.UI2.WinForms.Guna2Button();
            this.ButtonClass = new Guna.UI2.WinForms.Guna2Button();
            this.ButtonAccount = new Guna.UI2.WinForms.Guna2ImageButton();
            this.TextBoxUser = new Guna.UI2.WinForms.Guna2TextBox();
            this.PanelBackground = new System.Windows.Forms.Panel();
            this.MenuStrip.SuspendLayout();
            this.PanelForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewInfo)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.AutoSize = false;
            this.MenuStrip.BackColor = System.Drawing.SystemColors.HotTrack;
            this.MenuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemAddStudent,
            this.MenuItemListCreate,
            this.MenuItemSearch,
            this.MenuItemSubjectScore,
            this.MenuItemFinalReport,
            this.MenuQuanLyQuyDinh,
            this.ToolStripMenuItemAccount});
            this.MenuStrip.Location = new System.Drawing.Point(0, 208);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.MenuStrip.Size = new System.Drawing.Size(1312, 50);
            this.MenuStrip.TabIndex = 2;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // MenuItemAddStudent
            // 
            this.MenuItemAddStudent.AutoSize = false;
            this.MenuItemAddStudent.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuItemAddStudent.ForeColor = System.Drawing.SystemColors.Window;
            this.MenuItemAddStudent.Name = "MenuItemAddStudent";
            this.MenuItemAddStudent.Size = new System.Drawing.Size(200, 50);
            this.MenuItemAddStudent.Text = "Tiếp nhận học sinh";
            this.MenuItemAddStudent.Visible = false;
            this.MenuItemAddStudent.Click += new System.EventHandler(this.MenuItemAddStudent_Click);
            // 
            // MenuItemListCreate
            // 
            this.MenuItemListCreate.AutoSize = false;
            this.MenuItemListCreate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuItemListCreate.ForeColor = System.Drawing.Color.White;
            this.MenuItemListCreate.Name = "MenuItemListCreate";
            this.MenuItemListCreate.Size = new System.Drawing.Size(200, 50);
            this.MenuItemListCreate.Text = "Lập danh sách lớp";
            this.MenuItemListCreate.Visible = false;
            this.MenuItemListCreate.Click += new System.EventHandler(this.MenuItemListCreate_Click);
            // 
            // MenuItemSearch
            // 
            this.MenuItemSearch.AutoSize = false;
            this.MenuItemSearch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemFindStudent,
            this.MenuItemScoreBoard});
            this.MenuItemSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuItemSearch.ForeColor = System.Drawing.SystemColors.Window;
            this.MenuItemSearch.Name = "MenuItemSearch";
            this.MenuItemSearch.Size = new System.Drawing.Size(180, 50);
            this.MenuItemSearch.Text = "Tra cứu học sinh";
            this.MenuItemSearch.Visible = false;
            // 
            // MenuItemFindStudent
            // 
            this.MenuItemFindStudent.Name = "MenuItemFindStudent";
            this.MenuItemFindStudent.Size = new System.Drawing.Size(275, 32);
            this.MenuItemFindStudent.Text = "Tra cứu thông tin";
            this.MenuItemFindStudent.Click += new System.EventHandler(this.MenuItemFindStudent_Click);
            // 
            // MenuItemScoreBoard
            // 
            this.MenuItemScoreBoard.Name = "MenuItemScoreBoard";
            this.MenuItemScoreBoard.Size = new System.Drawing.Size(275, 32);
            this.MenuItemScoreBoard.Text = "Tra cứu bảng điểm";
            this.MenuItemScoreBoard.Click += new System.EventHandler(this.MenuItemScoreBoard_Click);
            // 
            // MenuItemSubjectScore
            // 
            this.MenuItemSubjectScore.AutoSize = false;
            this.MenuItemSubjectScore.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemSubjectScore1,
            this.MenuItemSubjectScoreYear});
            this.MenuItemSubjectScore.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuItemSubjectScore.ForeColor = System.Drawing.SystemColors.Window;
            this.MenuItemSubjectScore.Name = "MenuItemSubjectScore";
            this.MenuItemSubjectScore.Size = new System.Drawing.Size(200, 50);
            this.MenuItemSubjectScore.Text = "Bảng điểm môn học";
            this.MenuItemSubjectScore.Visible = false;
            // 
            // MenuItemSubjectScore1
            // 
            this.MenuItemSubjectScore1.Name = "MenuItemSubjectScore1";
            this.MenuItemSubjectScore1.Size = new System.Drawing.Size(344, 32);
            this.MenuItemSubjectScore1.Text = "Nhập bảng điểm môn học";
            this.MenuItemSubjectScore1.Click += new System.EventHandler(this.MenuItemSubjectScore_Click);
            // 
            // MenuItemSubjectScoreYear
            // 
            this.MenuItemSubjectScoreYear.Name = "MenuItemSubjectScoreYear";
            this.MenuItemSubjectScoreYear.Size = new System.Drawing.Size(344, 32);
            this.MenuItemSubjectScoreYear.Text = "Xuất bảng điểm môn học";
            this.MenuItemSubjectScoreYear.Click += new System.EventHandler(this.MenuItemSubjectScoreYear_Click);
            // 
            // MenuItemFinalReport
            // 
            this.MenuItemFinalReport.AutoSize = false;
            this.MenuItemFinalReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemClassReport,
            this.ToolStripMenuItemFinalReport});
            this.MenuItemFinalReport.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuItemFinalReport.ForeColor = System.Drawing.SystemColors.Window;
            this.MenuItemFinalReport.Name = "MenuItemFinalReport";
            this.MenuItemFinalReport.Size = new System.Drawing.Size(200, 50);
            this.MenuItemFinalReport.Text = "Báo cáo tổng kết";
            this.MenuItemFinalReport.Visible = false;
            // 
            // ToolStripMenuItemClassReport
            // 
            this.ToolStripMenuItemClassReport.Name = "ToolStripMenuItemClassReport";
            this.ToolStripMenuItemClassReport.Size = new System.Drawing.Size(254, 32);
            this.ToolStripMenuItemClassReport.Text = "Tổng kết lớp";
            this.ToolStripMenuItemClassReport.Click += new System.EventHandler(this.MenuItemClassScore_Click);
            // 
            // ToolStripMenuItemFinalReport
            // 
            this.ToolStripMenuItemFinalReport.Name = "ToolStripMenuItemFinalReport";
            this.ToolStripMenuItemFinalReport.Size = new System.Drawing.Size(254, 32);
            this.ToolStripMenuItemFinalReport.Text = "Tổng kết trường";
            this.ToolStripMenuItemFinalReport.Click += new System.EventHandler(this.MenuItemFinalReport_Click);
            // 
            // MenuQuanLyQuyDinh
            // 
            this.MenuQuanLyQuyDinh.AutoSize = false;
            this.MenuQuanLyQuyDinh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuQuanLyQuyDinh.ForeColor = System.Drawing.Color.White;
            this.MenuQuanLyQuyDinh.Name = "MenuQuanLyQuyDinh";
            this.MenuQuanLyQuyDinh.Size = new System.Drawing.Size(200, 50);
            this.MenuQuanLyQuyDinh.Text = "Quản lý quy định";
            this.MenuQuanLyQuyDinh.Visible = false;
            this.MenuQuanLyQuyDinh.Click += new System.EventHandler(this.MenuQuanLyQuyDinh_Click);
            // 
            // ToolStripMenuItemAccount
            // 
            this.ToolStripMenuItemAccount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripMenuItemAccount.ForeColor = System.Drawing.Color.White;
            this.ToolStripMenuItemAccount.Name = "ToolStripMenuItemAccount";
            this.ToolStripMenuItemAccount.Size = new System.Drawing.Size(156, 46);
            this.ToolStripMenuItemAccount.Text = "Tạo tài khoản";
            this.ToolStripMenuItemAccount.Visible = false;
            this.ToolStripMenuItemAccount.Click += new System.EventHandler(this.taojToolStripMenuItem_Click);
            // 
            // PanelForm
            // 
            this.PanelForm.BackColor = System.Drawing.SystemColors.Highlight;
            this.PanelForm.Controls.Add(this.ButtonClose);
            this.PanelForm.Controls.Add(this.ButtonMinimize);
            this.PanelForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelForm.Location = new System.Drawing.Point(0, 0);
            this.PanelForm.Margin = new System.Windows.Forms.Padding(4);
            this.PanelForm.Name = "PanelForm";
            this.PanelForm.Size = new System.Drawing.Size(1312, 53);
            this.PanelForm.TabIndex = 17;
            this.PanelForm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.guna2Panel1_MouseDown);
            // 
            // ButtonClose
            // 
            this.ButtonClose.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.ButtonClose.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.ButtonClose.Image = ((System.Drawing.Image)(resources.GetObject("ButtonClose.Image")));
            this.ButtonClose.ImageOffset = new System.Drawing.Point(0, 0);
            this.ButtonClose.ImageRotate = 0F;
            this.ButtonClose.ImageSize = new System.Drawing.Size(30, 30);
            this.ButtonClose.Location = new System.Drawing.Point(1261, 6);
            this.ButtonClose.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.ButtonClose.Size = new System.Drawing.Size(47, 43);
            this.ButtonClose.TabIndex = 1;
            this.ButtonClose.Click += new System.EventHandler(this.guna2ImageButtonClose1_Click);
            // 
            // ButtonMinimize
            // 
            this.ButtonMinimize.BackColor = System.Drawing.SystemColors.Highlight;
            this.ButtonMinimize.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.ButtonMinimize.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.ButtonMinimize.Image = ((System.Drawing.Image)(resources.GetObject("ButtonMinimize.Image")));
            this.ButtonMinimize.ImageOffset = new System.Drawing.Point(0, 0);
            this.ButtonMinimize.ImageRotate = 0F;
            this.ButtonMinimize.ImageSize = new System.Drawing.Size(30, 30);
            this.ButtonMinimize.Location = new System.Drawing.Point(1219, 6);
            this.ButtonMinimize.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonMinimize.Name = "ButtonMinimize";
            this.ButtonMinimize.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.ButtonMinimize.Size = new System.Drawing.Size(47, 43);
            this.ButtonMinimize.TabIndex = 0;
            this.ButtonMinimize.Click += new System.EventHandler(this.guna2ImageButtonMinimize1_Click);
            // 
            // MonthCalendar
            // 
            this.MonthCalendar.Location = new System.Drawing.Point(32, 35);
            this.MonthCalendar.Name = "MonthCalendar";
            this.MonthCalendar.TabIndex = 18;
            // 
            // DataGridViewInfo
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.DataGridViewInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridViewInfo.ColumnHeadersHeight = 40;
            this.DataGridViewInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridViewInfo.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridViewInfo.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGridViewInfo.Location = new System.Drawing.Point(243, 23);
            this.DataGridViewInfo.Name = "DataGridViewInfo";
            this.DataGridViewInfo.RowHeadersVisible = false;
            this.DataGridViewInfo.RowHeadersWidth = 51;
            this.DataGridViewInfo.RowTemplate.Height = 24;
            this.DataGridViewInfo.Size = new System.Drawing.Size(576, 341);
            this.DataGridViewInfo.TabIndex = 19;
            this.DataGridViewInfo.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DataGridViewInfo.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DataGridViewInfo.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DataGridViewInfo.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DataGridViewInfo.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DataGridViewInfo.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DataGridViewInfo.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGridViewInfo.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.DataGridViewInfo.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataGridViewInfo.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGridViewInfo.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DataGridViewInfo.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DataGridViewInfo.ThemeStyle.HeaderStyle.Height = 40;
            this.DataGridViewInfo.ThemeStyle.ReadOnly = false;
            this.DataGridViewInfo.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DataGridViewInfo.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DataGridViewInfo.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGridViewInfo.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DataGridViewInfo.ThemeStyle.RowsStyle.Height = 24;
            this.DataGridViewInfo.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGridViewInfo.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.MonthCalendar);
            this.guna2Panel2.CustomBorderColor = System.Drawing.SystemColors.HotTrack;
            this.guna2Panel2.CustomBorderThickness = new System.Windows.Forms.Padding(5, 3, 5, 5);
            this.guna2Panel2.Location = new System.Drawing.Point(26, 348);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(370, 289);
            this.guna2Panel2.TabIndex = 20;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.Controls.Add(this.LabelYear);
            this.guna2Panel3.Controls.Add(this.ComboBoxYear);
            this.guna2Panel3.Controls.Add(this.ButtonSubject);
            this.guna2Panel3.Controls.Add(this.ButtonClass);
            this.guna2Panel3.Controls.Add(this.DataGridViewInfo);
            this.guna2Panel3.CustomBorderColor = System.Drawing.SystemColors.HotTrack;
            this.guna2Panel3.CustomBorderThickness = new System.Windows.Forms.Padding(5, 3, 5, 5);
            this.guna2Panel3.Location = new System.Drawing.Point(433, 348);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(847, 405);
            this.guna2Panel3.TabIndex = 21;
            // 
            // LabelYear
            // 
            this.LabelYear.AutoSize = true;
            this.LabelYear.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelYear.Location = new System.Drawing.Point(30, 35);
            this.LabelYear.Name = "LabelYear";
            this.LabelYear.Size = new System.Drawing.Size(91, 28);
            this.LabelYear.TabIndex = 23;
            this.LabelYear.Text = "Năm học";
            // 
            // ComboBoxYear
            // 
            this.ComboBoxYear.BackColor = System.Drawing.Color.Transparent;
            this.ComboBoxYear.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ComboBoxYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxYear.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboBoxYear.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboBoxYear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ComboBoxYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.ComboBoxYear.ItemHeight = 30;
            this.ComboBoxYear.Location = new System.Drawing.Point(35, 70);
            this.ComboBoxYear.Name = "ComboBoxYear";
            this.ComboBoxYear.Size = new System.Drawing.Size(166, 36);
            this.ComboBoxYear.TabIndex = 22;
            // 
            // ButtonSubject
            // 
            this.ButtonSubject.AutoRoundedCorners = true;
            this.ButtonSubject.BorderRadius = 22;
            this.ButtonSubject.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ButtonSubject.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ButtonSubject.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ButtonSubject.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ButtonSubject.FillColor = System.Drawing.SystemColors.HotTrack;
            this.ButtonSubject.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ButtonSubject.ForeColor = System.Drawing.Color.White;
            this.ButtonSubject.Location = new System.Drawing.Point(35, 225);
            this.ButtonSubject.Name = "ButtonSubject";
            this.ButtonSubject.Size = new System.Drawing.Size(153, 47);
            this.ButtonSubject.TabIndex = 21;
            this.ButtonSubject.Text = "Danh sách môn";
            this.ButtonSubject.Click += new System.EventHandler(this.guna2ButtonSubject_Click);
            // 
            // ButtonClass
            // 
            this.ButtonClass.AutoRoundedCorners = true;
            this.ButtonClass.BorderRadius = 22;
            this.ButtonClass.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ButtonClass.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ButtonClass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ButtonClass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ButtonClass.FillColor = System.Drawing.SystemColors.HotTrack;
            this.ButtonClass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ButtonClass.ForeColor = System.Drawing.Color.White;
            this.ButtonClass.Location = new System.Drawing.Point(35, 145);
            this.ButtonClass.Name = "ButtonClass";
            this.ButtonClass.Size = new System.Drawing.Size(153, 47);
            this.ButtonClass.TabIndex = 20;
            this.ButtonClass.Text = "Danh sách lớp";
            this.ButtonClass.Click += new System.EventHandler(this.guna2ButtonClass_Click);
            // 
            // ButtonAccount
            // 
            this.ButtonAccount.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.ButtonAccount.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.ButtonAccount.Image = ((System.Drawing.Image)(resources.GetObject("ButtonAccount.Image")));
            this.ButtonAccount.ImageOffset = new System.Drawing.Point(0, 0);
            this.ButtonAccount.ImageRotate = 0F;
            this.ButtonAccount.ImageSize = new System.Drawing.Size(60, 60);
            this.ButtonAccount.Location = new System.Drawing.Point(1207, 264);
            this.ButtonAccount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ButtonAccount.Name = "ButtonAccount";
            this.ButtonAccount.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.ButtonAccount.Size = new System.Drawing.Size(73, 68);
            this.ButtonAccount.TabIndex = 22;
            this.ButtonAccount.Click += new System.EventHandler(this.guna2ImageButtonUser_Click);
            // 
            // TextBoxUser
            // 
            this.TextBoxUser.AutoRoundedCorners = true;
            this.TextBoxUser.BorderRadius = 27;
            this.TextBoxUser.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBoxUser.DefaultText = "";
            this.TextBoxUser.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TextBoxUser.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TextBoxUser.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TextBoxUser.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TextBoxUser.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TextBoxUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxUser.ForeColor = System.Drawing.Color.Black;
            this.TextBoxUser.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TextBoxUser.Location = new System.Drawing.Point(926, 275);
            this.TextBoxUser.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.TextBoxUser.Name = "TextBoxUser";
            this.TextBoxUser.PasswordChar = '\0';
            this.TextBoxUser.PlaceholderForeColor = System.Drawing.Color.Black;
            this.TextBoxUser.PlaceholderText = "";
            this.TextBoxUser.ReadOnly = true;
            this.TextBoxUser.SelectedText = "";
            this.TextBoxUser.Size = new System.Drawing.Size(274, 57);
            this.TextBoxUser.TabIndex = 23;
            this.TextBoxUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PanelBackground
            // 
            this.PanelBackground.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PanelBackground.BackgroundImage")));
            this.PanelBackground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PanelBackground.Location = new System.Drawing.Point(0, 56);
            this.PanelBackground.Name = "PanelBackground";
            this.PanelBackground.Size = new System.Drawing.Size(1312, 149);
            this.PanelBackground.TabIndex = 24;
            // 
            // TrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1312, 783);
            this.Controls.Add(this.PanelBackground);
            this.Controls.Add(this.TextBoxUser);
            this.Controls.Add(this.ButtonAccount);
            this.Controls.Add(this.guna2Panel3);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.PanelForm);
            this.Controls.Add(this.MenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.MenuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "TrangChu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.PanelForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewInfo)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem MenuItemFinalReport;
        private System.Windows.Forms.ToolStripMenuItem MenuItemAddStudent;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSearch;
        private System.Windows.Forms.ToolStripMenuItem MenuItemFindStudent;
        private System.Windows.Forms.ToolStripMenuItem MenuItemScoreBoard;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSubjectScore;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSubjectScore1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSubjectScoreYear;
        private Guna.UI2.WinForms.Guna2Panel PanelForm;
        private Guna.UI2.WinForms.Guna2ImageButton ButtonClose;
        private Guna.UI2.WinForms.Guna2ImageButton ButtonMinimize;
        private System.Windows.Forms.ToolStripMenuItem MenuQuanLyQuyDinh;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemClassReport;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemFinalReport;
        private System.Windows.Forms.ToolStripMenuItem MenuItemListCreate;
        private System.Windows.Forms.MonthCalendar MonthCalendar;
        private Guna.UI2.WinForms.Guna2DataGridView DataGridViewInfo;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2Button ButtonSubject;
        private Guna.UI2.WinForms.Guna2Button ButtonClass;
        private Guna.UI2.WinForms.Guna2ComboBox ComboBoxYear;
        private System.Windows.Forms.Label LabelYear;
        private Guna.UI2.WinForms.Guna2ImageButton ButtonAccount;
        private Guna.UI2.WinForms.Guna2TextBox TextBoxUser;
        private System.Windows.Forms.Panel PanelBackground;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAccount;
    }
}