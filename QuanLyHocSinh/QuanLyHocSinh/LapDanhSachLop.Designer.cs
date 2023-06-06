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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbClass = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbGrade = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbSchoolYear = new Guna.UI2.WinForms.Guna2ComboBox();
            this.tbStdNum = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.duLieu = new QuanLyHocSinh.DuLieu();
            this.duLieuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lOPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lOPTableAdapter = new QuanLyHocSinh.DuLieuTableAdapters.LOPTableAdapter();
            this.duLieuBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.mainLabelStdInfo = new System.Windows.Forms.Label();
            this.Btn_Minimize = new Guna.UI2.WinForms.Guna2ImageButton();
            this.Btn_Close = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnHomeScreen = new Guna.UI2.WinForms.Guna2Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.duLieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.duLieuBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.duLieuBindingSource1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbClass);
            this.panel1.Controls.Add(this.cbGrade);
            this.panel1.Controls.Add(this.cbSchoolYear);
            this.panel1.Controls.Add(this.tbStdNum);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(178, 103);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1039, 109);
            this.panel1.TabIndex = 0;
            // 
            // cbClass
            // 
            this.cbClass.BackColor = System.Drawing.Color.Transparent;
            this.cbClass.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClass.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbClass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbClass.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbClass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbClass.ItemHeight = 30;
            this.cbClass.Location = new System.Drawing.Point(487, 58);
            this.cbClass.Name = "cbClass";
            this.cbClass.Size = new System.Drawing.Size(185, 36);
            this.cbClass.TabIndex = 10;
            this.cbClass.SelectedIndexChanged += new System.EventHandler(this.cbClass_SelectedIndexChanged);
            // 
            // cbGrade
            // 
            this.cbGrade.BackColor = System.Drawing.Color.Transparent;
            this.cbGrade.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGrade.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbGrade.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbGrade.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbGrade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbGrade.ItemHeight = 30;
            this.cbGrade.Location = new System.Drawing.Point(157, 58);
            this.cbGrade.Name = "cbGrade";
            this.cbGrade.Size = new System.Drawing.Size(209, 36);
            this.cbGrade.TabIndex = 9;
            this.cbGrade.SelectedIndexChanged += new System.EventHandler(this.cbGrade_SelectedIndexChanged);
            // 
            // cbSchoolYear
            // 
            this.cbSchoolYear.BackColor = System.Drawing.Color.Transparent;
            this.cbSchoolYear.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSchoolYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSchoolYear.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbSchoolYear.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbSchoolYear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbSchoolYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbSchoolYear.ItemHeight = 30;
            this.cbSchoolYear.Location = new System.Drawing.Point(157, 7);
            this.cbSchoolYear.Name = "cbSchoolYear";
            this.cbSchoolYear.Size = new System.Drawing.Size(209, 36);
            this.cbSchoolYear.TabIndex = 8;
            this.cbSchoolYear.SelectedIndexChanged += new System.EventHandler(this.cbSchoolYear_SelectedIndexChanged);
            // 
            // tbStdNum
            // 
            this.tbStdNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbStdNum.Location = new System.Drawing.Point(884, 62);
            this.tbStdNum.Name = "tbStdNum";
            this.tbStdNum.Size = new System.Drawing.Size(88, 30);
            this.tbStdNum.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(811, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 29);
            this.label4.TabIndex = 3;
            this.label4.Text = "Sĩ số";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(411, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Lớp";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(21, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Khối";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(21, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Năm học";
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
            this.panel2.Controls.Add(this.Btn_Minimize);
            this.panel2.Controls.Add(this.Btn_Close);
            this.panel2.Location = new System.Drawing.Point(-4, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1236, 76);
            this.panel2.TabIndex = 7;
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
            // 
            // Btn_Minimize
            // 
            this.Btn_Minimize.BackColor = System.Drawing.SystemColors.Highlight;
            this.Btn_Minimize.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.Btn_Minimize.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.Btn_Minimize.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Minimize.Image")));
            this.Btn_Minimize.ImageOffset = new System.Drawing.Point(0, 0);
            this.Btn_Minimize.ImageRotate = 0F;
            this.Btn_Minimize.ImageSize = new System.Drawing.Size(30, 30);
            this.Btn_Minimize.Location = new System.Drawing.Point(1119, 14);
            this.Btn_Minimize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Btn_Minimize.Name = "Btn_Minimize";
            this.Btn_Minimize.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.Btn_Minimize.Size = new System.Drawing.Size(53, 54);
            this.Btn_Minimize.TabIndex = 4;
            this.Btn_Minimize.Click += new System.EventHandler(this.Btn_Minimize_Click);
            // 
            // Btn_Close
            // 
            this.Btn_Close.BackColor = System.Drawing.SystemColors.Highlight;
            this.Btn_Close.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.Btn_Close.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.Btn_Close.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Close.Image")));
            this.Btn_Close.ImageOffset = new System.Drawing.Point(0, 0);
            this.Btn_Close.ImageRotate = 0F;
            this.Btn_Close.ImageSize = new System.Drawing.Size(30, 30);
            this.Btn_Close.Location = new System.Drawing.Point(1180, 14);
            this.Btn_Close.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Btn_Close.Name = "Btn_Close";
            this.Btn_Close.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.Btn_Close.Size = new System.Drawing.Size(53, 54);
            this.Btn_Close.TabIndex = 5;
            this.Btn_Close.Click += new System.EventHandler(this.Btn_Close_Click);
            // 
            // btnHomeScreen
            // 
            this.btnHomeScreen.BorderColor = System.Drawing.Color.White;
            this.btnHomeScreen.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHomeScreen.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHomeScreen.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHomeScreen.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHomeScreen.FillColor = System.Drawing.Color.White;
            this.btnHomeScreen.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnHomeScreen.ForeColor = System.Drawing.Color.White;
            this.btnHomeScreen.Image = ((System.Drawing.Image)(resources.GetObject("btnHomeScreen.Image")));
            this.btnHomeScreen.ImageSize = new System.Drawing.Size(50, 50);
            this.btnHomeScreen.Location = new System.Drawing.Point(60, 136);
            this.btnHomeScreen.Name = "btnHomeScreen";
            this.btnHomeScreen.Size = new System.Drawing.Size(49, 45);
            this.btnHomeScreen.TabIndex = 8;
            this.btnHomeScreen.Click += new System.EventHandler(this.btnHomeScreen_Click);
            // 
            // LapDanhSachLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1229, 648);
            this.Controls.Add(this.btnHomeScreen);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LapDanhSachLop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LapDanhSachLop";
            this.Load += new System.EventHandler(this.LapDanhSachLop_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.duLieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.duLieuBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.duLieuBindingSource1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbStdNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource duLieuBindingSource;
        private DuLieu duLieu;
        private System.Windows.Forms.BindingSource lOPBindingSource;
        private DuLieuTableAdapters.LOPTableAdapter lOPTableAdapter;
        private System.Windows.Forms.BindingSource duLieuBindingSource1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label mainLabelStdInfo;
        private Guna.UI2.WinForms.Guna2ImageButton Btn_Minimize;
        private Guna.UI2.WinForms.Guna2ImageButton Btn_Close;
        private Guna.UI2.WinForms.Guna2Button btnHomeScreen;
        private Guna.UI2.WinForms.Guna2ComboBox cbClass;
        private Guna.UI2.WinForms.Guna2ComboBox cbGrade;
        private Guna.UI2.WinForms.Guna2ComboBox cbSchoolYear;
    }
}