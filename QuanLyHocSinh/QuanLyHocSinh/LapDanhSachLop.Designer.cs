namespace QuanLyHocSinh
{
    partial class LapDanhSachLop
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LapDanhSachLop));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ComboBoxClass = new Guna.UI2.WinForms.Guna2ComboBox();
            this.ComboBoxGrade = new Guna.UI2.WinForms.Guna2ComboBox();
            this.ComboBoxSchoolYear = new Guna.UI2.WinForms.Guna2ComboBox();
            this.TextBoxStdNum = new System.Windows.Forms.TextBox();
            this.lbStdNum = new System.Windows.Forms.Label();
            this.lbClass = new System.Windows.Forms.Label();
            this.lbGrade = new System.Windows.Forms.Label();
            this.lbSchoolYear = new System.Windows.Forms.Label();
            this.duLieu = new QuanLyHocSinh.DuLieu();
            this.duLieuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lOPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lOPTableAdapter = new QuanLyHocSinh.DuLieuTableAdapters.LOPTableAdapter();
            this.duLieuBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.mainLabelStdInfo = new System.Windows.Forms.Label();
            this.Button_Minimize = new Guna.UI2.WinForms.Guna2ImageButton();
            this.Button_Close = new Guna.UI2.WinForms.Guna2ImageButton();
            this.ButtonHomeScreen = new Guna.UI2.WinForms.Guna2Button();
            this.DataGridViewClassDetail = new Guna.UI2.WinForms.Guna2DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ButtonAddStdToClass = new Guna.UI2.WinForms.Guna2Button();
            this.TextBoxStdIdAdd = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbInputStdID = new System.Windows.Forms.Label();
            this.lbAddStdToClass = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ButtonDelStdOutClass = new Guna.UI2.WinForms.Guna2Button();
            this.TextBoxStdIDDel = new Guna.UI2.WinForms.Guna2TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.duLieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.duLieuBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.duLieuBindingSource1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewClassDetail)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightCyan;
            this.panel1.Controls.Add(this.ComboBoxClass);
            this.panel1.Controls.Add(this.ComboBoxGrade);
            this.panel1.Controls.Add(this.ComboBoxSchoolYear);
            this.panel1.Controls.Add(this.TextBoxStdNum);
            this.panel1.Controls.Add(this.lbStdNum);
            this.panel1.Controls.Add(this.lbClass);
            this.panel1.Controls.Add(this.lbGrade);
            this.panel1.Controls.Add(this.lbSchoolYear);
            this.panel1.Location = new System.Drawing.Point(177, 96);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1390, 123);
            this.panel1.TabIndex = 0;
            // 
            // ComboBoxClass
            // 
            this.ComboBoxClass.BackColor = System.Drawing.Color.Transparent;
            this.ComboBoxClass.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ComboBoxClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxClass.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboBoxClass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboBoxClass.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ComboBoxClass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.ComboBoxClass.ItemHeight = 30;
            this.ComboBoxClass.Location = new System.Drawing.Point(907, 29);
            this.ComboBoxClass.Name = "ComboBoxClass";
            this.ComboBoxClass.Size = new System.Drawing.Size(185, 36);
            this.ComboBoxClass.TabIndex = 10;
            // 
            // ComboBoxGrade
            // 
            this.ComboBoxGrade.BackColor = System.Drawing.Color.Transparent;
            this.ComboBoxGrade.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ComboBoxGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxGrade.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboBoxGrade.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboBoxGrade.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ComboBoxGrade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.ComboBoxGrade.ItemHeight = 30;
            this.ComboBoxGrade.Location = new System.Drawing.Point(529, 29);
            this.ComboBoxGrade.Name = "ComboBoxGrade";
            this.ComboBoxGrade.Size = new System.Drawing.Size(209, 36);
            this.ComboBoxGrade.TabIndex = 9;
            // 
            // ComboBoxSchoolYear
            // 
            this.ComboBoxSchoolYear.BackColor = System.Drawing.Color.Transparent;
            this.ComboBoxSchoolYear.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ComboBoxSchoolYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxSchoolYear.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboBoxSchoolYear.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboBoxSchoolYear.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ComboBoxSchoolYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.ComboBoxSchoolYear.ItemHeight = 30;
            this.ComboBoxSchoolYear.Location = new System.Drawing.Point(157, 28);
            this.ComboBoxSchoolYear.Name = "ComboBoxSchoolYear";
            this.ComboBoxSchoolYear.Size = new System.Drawing.Size(209, 36);
            this.ComboBoxSchoolYear.TabIndex = 8;
            // 
            // TextBoxStdNum
            // 
            this.TextBoxStdNum.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxStdNum.Location = new System.Drawing.Point(1222, 40);
            this.TextBoxStdNum.Name = "TextBoxStdNum";
            this.TextBoxStdNum.ReadOnly = true;
            this.TextBoxStdNum.Size = new System.Drawing.Size(88, 39);
            this.TextBoxStdNum.TabIndex = 7;
            // 
            // lbStdNum
            // 
            this.lbStdNum.AutoSize = true;
            this.lbStdNum.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStdNum.Location = new System.Drawing.Point(1149, 43);
            this.lbStdNum.Name = "lbStdNum";
            this.lbStdNum.Size = new System.Drawing.Size(67, 32);
            this.lbStdNum.TabIndex = 3;
            this.lbStdNum.Text = "Sĩ số";
            // 
            // lbClass
            // 
            this.lbClass.AutoSize = true;
            this.lbClass.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClass.Location = new System.Drawing.Point(831, 43);
            this.lbClass.Name = "lbClass";
            this.lbClass.Size = new System.Drawing.Size(56, 32);
            this.lbClass.TabIndex = 2;
            this.lbClass.Text = "Lớp";
            // 
            // lbGrade
            // 
            this.lbGrade.AutoSize = true;
            this.lbGrade.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGrade.Location = new System.Drawing.Point(441, 43);
            this.lbGrade.Name = "lbGrade";
            this.lbGrade.Size = new System.Drawing.Size(66, 32);
            this.lbGrade.TabIndex = 1;
            this.lbGrade.Text = "Khối";
            // 
            // lbSchoolYear
            // 
            this.lbSchoolYear.AutoSize = true;
            this.lbSchoolYear.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSchoolYear.Location = new System.Drawing.Point(21, 43);
            this.lbSchoolYear.Name = "lbSchoolYear";
            this.lbSchoolYear.Size = new System.Drawing.Size(116, 32);
            this.lbSchoolYear.TabIndex = 0;
            this.lbSchoolYear.Text = "Năm học";
            // 
            // duLieu
            // 
            this.duLieu.DataSetName = "DuLieu";
            this.duLieu.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // duLieuBindingSource
            // 
            this.duLieuBindingSource.DataSource = this.duLieu;
            this.duLieuBindingSource.Position = 0;
            // 
            // lOPBindingSource
            // 
            this.lOPBindingSource.DataMember = "LOP";
            this.lOPBindingSource.DataSource = this.duLieuBindingSource;
            // 
            // lOPTableAdapter
            // 
            this.lOPTableAdapter.ClearBeforeFill = true;
            // 
            // duLieuBindingSource1
            // 
            this.duLieuBindingSource1.DataSource = this.duLieu;
            this.duLieuBindingSource1.Position = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel2.Controls.Add(this.mainLabelStdInfo);
            this.panel2.Controls.Add(this.Button_Minimize);
            this.panel2.Controls.Add(this.Button_Close);
            this.panel2.Location = new System.Drawing.Point(-4, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1605, 76);
            this.panel2.TabIndex = 7;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            // 
            // mainLabelStdInfo
            // 
            this.mainLabelStdInfo.AutoSize = true;
            this.mainLabelStdInfo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainLabelStdInfo.ForeColor = System.Drawing.Color.White;
            this.mainLabelStdInfo.Location = new System.Drawing.Point(18, 17);
            this.mainLabelStdInfo.Name = "mainLabelStdInfo";
            this.mainLabelStdInfo.Size = new System.Drawing.Size(231, 45);
            this.mainLabelStdInfo.TabIndex = 6;
            this.mainLabelStdInfo.Text = "Danh sách lớp";
            this.mainLabelStdInfo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainLabelStdInfo_MouseDown);
            // 
            // Button_Minimize
            // 
            this.Button_Minimize.BackColor = System.Drawing.SystemColors.Highlight;
            this.Button_Minimize.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.Button_Minimize.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.Button_Minimize.Image = ((System.Drawing.Image)(resources.GetObject("Button_Minimize.Image")));
            this.Button_Minimize.ImageOffset = new System.Drawing.Point(0, 0);
            this.Button_Minimize.ImageRotate = 0F;
            this.Button_Minimize.ImageSize = new System.Drawing.Size(30, 30);
            this.Button_Minimize.Location = new System.Drawing.Point(1473, 14);
            this.Button_Minimize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Button_Minimize.Name = "Button_Minimize";
            this.Button_Minimize.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.Button_Minimize.Size = new System.Drawing.Size(53, 54);
            this.Button_Minimize.TabIndex = 4;
            this.Button_Minimize.Click += new System.EventHandler(this.Button_Minimize_Click);
            // 
            // Button_Close
            // 
            this.Button_Close.BackColor = System.Drawing.SystemColors.Highlight;
            this.Button_Close.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.Button_Close.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.Button_Close.Image = ((System.Drawing.Image)(resources.GetObject("Button_Close.Image")));
            this.Button_Close.ImageOffset = new System.Drawing.Point(0, 0);
            this.Button_Close.ImageRotate = 0F;
            this.Button_Close.ImageSize = new System.Drawing.Size(30, 30);
            this.Button_Close.Location = new System.Drawing.Point(1534, 14);
            this.Button_Close.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Button_Close.Name = "Button_Close";
            this.Button_Close.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.Button_Close.Size = new System.Drawing.Size(53, 54);
            this.Button_Close.TabIndex = 5;
            this.Button_Close.Click += new System.EventHandler(this.Button_Close_Click);
            // 
            // ButtonHomeScreen
            // 
            this.ButtonHomeScreen.BorderColor = System.Drawing.Color.White;
            this.ButtonHomeScreen.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ButtonHomeScreen.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ButtonHomeScreen.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ButtonHomeScreen.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ButtonHomeScreen.FillColor = System.Drawing.Color.White;
            this.ButtonHomeScreen.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.ButtonHomeScreen.ForeColor = System.Drawing.Color.White;
            this.ButtonHomeScreen.Image = ((System.Drawing.Image)(resources.GetObject("ButtonHomeScreen.Image")));
            this.ButtonHomeScreen.ImageSize = new System.Drawing.Size(30, 30);
            this.ButtonHomeScreen.Location = new System.Drawing.Point(60, 136);
            this.ButtonHomeScreen.Name = "ButtonHomeScreen";
            this.ButtonHomeScreen.Size = new System.Drawing.Size(60, 60);
            this.ButtonHomeScreen.TabIndex = 8;
            this.ButtonHomeScreen.Click += new System.EventHandler(this.ButtonHomeScreen_Click);
            // 
            // DataGridViewClassDetail
            // 
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.White;
            this.DataGridViewClassDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle19;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewClassDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.DataGridViewClassDetail.ColumnHeadersHeight = 40;
            this.DataGridViewClassDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridViewClassDetail.DefaultCellStyle = dataGridViewCellStyle21;
            this.DataGridViewClassDetail.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGridViewClassDetail.Location = new System.Drawing.Point(22, 366);
            this.DataGridViewClassDetail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DataGridViewClassDetail.Name = "DataGridViewClassDetail";
            this.DataGridViewClassDetail.ReadOnly = true;
            this.DataGridViewClassDetail.RowHeadersVisible = false;
            this.DataGridViewClassDetail.RowHeadersWidth = 62;
            this.DataGridViewClassDetail.RowTemplate.Height = 24;
            this.DataGridViewClassDetail.Size = new System.Drawing.Size(1545, 300);
            this.DataGridViewClassDetail.TabIndex = 9;
            this.DataGridViewClassDetail.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DataGridViewClassDetail.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DataGridViewClassDetail.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DataGridViewClassDetail.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DataGridViewClassDetail.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DataGridViewClassDetail.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DataGridViewClassDetail.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGridViewClassDetail.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.DataGridViewClassDetail.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataGridViewClassDetail.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGridViewClassDetail.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DataGridViewClassDetail.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DataGridViewClassDetail.ThemeStyle.HeaderStyle.Height = 40;
            this.DataGridViewClassDetail.ThemeStyle.ReadOnly = true;
            this.DataGridViewClassDetail.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DataGridViewClassDetail.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DataGridViewClassDetail.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGridViewClassDetail.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DataGridViewClassDetail.ThemeStyle.RowsStyle.Height = 24;
            this.DataGridViewClassDetail.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGridViewClassDetail.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ButtonAddStdToClass);
            this.panel3.Controls.Add(this.TextBoxStdIdAdd);
            this.panel3.Controls.Add(this.lbInputStdID);
            this.panel3.Controls.Add(this.lbAddStdToClass);
            this.panel3.Location = new System.Drawing.Point(22, 219);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1042, 141);
            this.panel3.TabIndex = 10;
            // 
            // ButtonAddStdToClass
            // 
            this.ButtonAddStdToClass.AutoRoundedCorners = true;
            this.ButtonAddStdToClass.BackColor = System.Drawing.Color.White;
            this.ButtonAddStdToClass.BorderRadius = 21;
            this.ButtonAddStdToClass.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            this.ButtonAddStdToClass.DefaultAutoSize = true;
            this.ButtonAddStdToClass.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ButtonAddStdToClass.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ButtonAddStdToClass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ButtonAddStdToClass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ButtonAddStdToClass.FillColor = System.Drawing.Color.LightCyan;
            this.ButtonAddStdToClass.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ButtonAddStdToClass.ForeColor = System.Drawing.Color.Black;
            this.ButtonAddStdToClass.Image = ((System.Drawing.Image)(resources.GetObject("ButtonAddStdToClass.Image")));
            this.ButtonAddStdToClass.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ButtonAddStdToClass.ImageSize = new System.Drawing.Size(30, 30);
            this.ButtonAddStdToClass.Location = new System.Drawing.Point(811, 65);
            this.ButtonAddStdToClass.Name = "ButtonAddStdToClass";
            this.ButtonAddStdToClass.Size = new System.Drawing.Size(125, 44);
            this.ButtonAddStdToClass.TabIndex = 3;
            this.ButtonAddStdToClass.Text = "Thêm";
            this.ButtonAddStdToClass.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ButtonAddStdToClass.Click += new System.EventHandler(this.ButtonAddStdToClass_Click);
            // 
            // TextBoxStdIdAdd
            // 
            this.TextBoxStdIdAdd.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBoxStdIdAdd.DefaultText = "";
            this.TextBoxStdIdAdd.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TextBoxStdIdAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TextBoxStdIdAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TextBoxStdIdAdd.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TextBoxStdIdAdd.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TextBoxStdIdAdd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TextBoxStdIdAdd.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TextBoxStdIdAdd.Location = new System.Drawing.Point(192, 62);
            this.TextBoxStdIdAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextBoxStdIdAdd.Name = "TextBoxStdIdAdd";
            this.TextBoxStdIdAdd.PasswordChar = '\0';
            this.TextBoxStdIdAdd.PlaceholderText = "";
            this.TextBoxStdIdAdd.SelectedText = "";
            this.TextBoxStdIdAdd.Size = new System.Drawing.Size(592, 60);
            this.TextBoxStdIdAdd.TabIndex = 2;
            // 
            // lbInputStdID
            // 
            this.lbInputStdID.AutoSize = true;
            this.lbInputStdID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInputStdID.Location = new System.Drawing.Point(21, 78);
            this.lbInputStdID.Name = "lbInputStdID";
            this.lbInputStdID.Size = new System.Drawing.Size(144, 32);
            this.lbInputStdID.TabIndex = 1;
            this.lbInputStdID.Text = "Nhập MSHS";
            // 
            // lbAddStdToClass
            // 
            this.lbAddStdToClass.AutoSize = true;
            this.lbAddStdToClass.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAddStdToClass.Location = new System.Drawing.Point(21, 18);
            this.lbAddStdToClass.Name = "lbAddStdToClass";
            this.lbAddStdToClass.Size = new System.Drawing.Size(271, 32);
            this.lbAddStdToClass.TabIndex = 0;
            this.lbAddStdToClass.Text = "Thêm học sinh vào lớp";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.ButtonDelStdOutClass);
            this.panel4.Controls.Add(this.TextBoxStdIDDel);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Location = new System.Drawing.Point(1091, 219);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(476, 141);
            this.panel4.TabIndex = 11;
            // 
            // ButtonDelStdOutClass
            // 
            this.ButtonDelStdOutClass.AutoRoundedCorners = true;
            this.ButtonDelStdOutClass.BorderRadius = 21;
            this.ButtonDelStdOutClass.DefaultAutoSize = true;
            this.ButtonDelStdOutClass.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ButtonDelStdOutClass.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ButtonDelStdOutClass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ButtonDelStdOutClass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ButtonDelStdOutClass.FillColor = System.Drawing.Color.LightCyan;
            this.ButtonDelStdOutClass.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonDelStdOutClass.ForeColor = System.Drawing.Color.Black;
            this.ButtonDelStdOutClass.Image = ((System.Drawing.Image)(resources.GetObject("ButtonDelStdOutClass.Image")));
            this.ButtonDelStdOutClass.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ButtonDelStdOutClass.ImageSize = new System.Drawing.Size(30, 30);
            this.ButtonDelStdOutClass.Location = new System.Drawing.Point(329, 65);
            this.ButtonDelStdOutClass.Name = "ButtonDelStdOutClass";
            this.ButtonDelStdOutClass.Size = new System.Drawing.Size(105, 44);
            this.ButtonDelStdOutClass.TabIndex = 4;
            this.ButtonDelStdOutClass.Text = "Xoá";
            this.ButtonDelStdOutClass.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ButtonDelStdOutClass.Click += new System.EventHandler(this.ButtonDelStdOutClass_Click);
            // 
            // TextBoxStdIDDel
            // 
            this.TextBoxStdIDDel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBoxStdIDDel.DefaultText = "";
            this.TextBoxStdIDDel.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TextBoxStdIDDel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TextBoxStdIDDel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TextBoxStdIDDel.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TextBoxStdIDDel.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TextBoxStdIDDel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TextBoxStdIDDel.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TextBoxStdIDDel.Location = new System.Drawing.Point(185, 61);
            this.TextBoxStdIDDel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextBoxStdIDDel.Name = "TextBoxStdIDDel";
            this.TextBoxStdIDDel.PasswordChar = '\0';
            this.TextBoxStdIDDel.PlaceholderText = "";
            this.TextBoxStdIDDel.SelectedText = "";
            this.TextBoxStdIDDel.Size = new System.Drawing.Size(118, 60);
            this.TextBoxStdIDDel.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(25, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 32);
            this.label8.TabIndex = 2;
            this.label8.Text = "Nhập STT";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(25, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(260, 32);
            this.label6.TabIndex = 1;
            this.label6.Text = "Xoá học sinh khỏi lớp";
            // 
            // LapDanhSachLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1900, 850);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.DataGridViewClassDetail);
            this.Controls.Add(this.ButtonHomeScreen);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LapDanhSachLop";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LapDanhSachLop";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.duLieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.duLieuBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.duLieuBindingSource1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewClassDetail)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TextBoxStdNum;
        private System.Windows.Forms.Label lbStdNum;
        private System.Windows.Forms.Label lbClass;
        private System.Windows.Forms.Label lbGrade;
        private System.Windows.Forms.Label lbSchoolYear;
        private System.Windows.Forms.BindingSource duLieuBindingSource;
        private DuLieu duLieu;
        private System.Windows.Forms.BindingSource lOPBindingSource;
        private DuLieuTableAdapters.LOPTableAdapter lOPTableAdapter;
        private System.Windows.Forms.BindingSource duLieuBindingSource1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label mainLabelStdInfo;
        private Guna.UI2.WinForms.Guna2ImageButton Button_Minimize;
        private Guna.UI2.WinForms.Guna2ImageButton Button_Close;
        private Guna.UI2.WinForms.Guna2Button ButtonHomeScreen;
        private Guna.UI2.WinForms.Guna2ComboBox ComboBoxClass;
        private Guna.UI2.WinForms.Guna2ComboBox ComboBoxGrade;
        private Guna.UI2.WinForms.Guna2ComboBox ComboBoxSchoolYear;
        private Guna.UI2.WinForms.Guna2DataGridView DataGridViewClassDetail;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbAddStdToClass;
        private Guna.UI2.WinForms.Guna2Button ButtonAddStdToClass;
        private Guna.UI2.WinForms.Guna2TextBox TextBoxStdIdAdd;
        private System.Windows.Forms.Label lbInputStdID;
        private Guna.UI2.WinForms.Guna2TextBox TextBoxStdIDDel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2Button ButtonDelStdOutClass;
    }
}