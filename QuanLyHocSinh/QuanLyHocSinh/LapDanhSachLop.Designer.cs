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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbClass = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbGrade = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbSchoolYear = new Guna.UI2.WinForms.Guna2ComboBox();
            this.tbStdNum = new System.Windows.Forms.TextBox();
            this.lbStdNum = new System.Windows.Forms.Label();
            this.lbClass = new System.Windows.Forms.Label();
            this.lbGrade = new System.Windows.Forms.Label();
            this.lbSchoolYear = new System.Windows.Forms.Label();
            this.mainLbClassDetail = new System.Windows.Forms.Label();
            this.duLieu = new QuanLyHocSinh.DuLieu();
            this.lOPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lOPTableAdapter = new QuanLyHocSinh.DuLieuTableAdapters.LOPTableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.duLieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOPBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbClass);
            this.panel1.Controls.Add(this.cbGrade);
            this.panel1.Controls.Add(this.cbSchoolYear);
            this.panel1.Controls.Add(this.tbStdNum);
            this.panel1.Controls.Add(this.lbStdNum);
            this.panel1.Controls.Add(this.lbClass);
            this.panel1.Controls.Add(this.lbGrade);
            this.panel1.Controls.Add(this.lbSchoolYear);
            this.panel1.Location = new System.Drawing.Point(13, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1204, 118);
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
            this.cbClass.Location = new System.Drawing.Point(480, 60);
            this.cbClass.Name = "cbClass";
            this.cbClass.Size = new System.Drawing.Size(221, 36);
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
            this.cbGrade.Location = new System.Drawing.Point(147, 59);
            this.cbGrade.Name = "cbGrade";
            this.cbGrade.Size = new System.Drawing.Size(214, 36);
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
            this.cbSchoolYear.Location = new System.Drawing.Point(147, 9);
            this.cbSchoolYear.Name = "cbSchoolYear";
            this.cbSchoolYear.Size = new System.Drawing.Size(214, 36);
            this.cbSchoolYear.TabIndex = 8;
            this.cbSchoolYear.SelectedIndexChanged += new System.EventHandler(this.cbSchoolYear_SelectedIndexChanged);
            // 
            // tbStdNum
            // 
            this.tbStdNum.Location = new System.Drawing.Point(884, 66);
            this.tbStdNum.Name = "tbStdNum";
            this.tbStdNum.Size = new System.Drawing.Size(67, 26);
            this.tbStdNum.TabIndex = 7;
            // 
            // lbStdNum
            // 
            this.lbStdNum.AutoSize = true;
            this.lbStdNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbStdNum.Location = new System.Drawing.Point(811, 64);
            this.lbStdNum.Name = "lbStdNum";
            this.lbStdNum.Size = new System.Drawing.Size(67, 29);
            this.lbStdNum.TabIndex = 3;
            this.lbStdNum.Text = "Sĩ số";
            // 
            // lbClass
            // 
            this.lbClass.AutoSize = true;
            this.lbClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbClass.Location = new System.Drawing.Point(411, 64);
            this.lbClass.Name = "lbClass";
            this.lbClass.Size = new System.Drawing.Size(54, 29);
            this.lbClass.TabIndex = 2;
            this.lbClass.Text = "Lớp";
            // 
            // lbGrade
            // 
            this.lbGrade.AutoSize = true;
            this.lbGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbGrade.Location = new System.Drawing.Point(21, 64);
            this.lbGrade.Name = "lbGrade";
            this.lbGrade.Size = new System.Drawing.Size(62, 29);
            this.lbGrade.TabIndex = 1;
            this.lbGrade.Text = "Khối";
            // 
            // lbSchoolYear
            // 
            this.lbSchoolYear.AutoSize = true;
            this.lbSchoolYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbSchoolYear.Location = new System.Drawing.Point(21, 14);
            this.lbSchoolYear.Name = "lbSchoolYear";
            this.lbSchoolYear.Size = new System.Drawing.Size(109, 29);
            this.lbSchoolYear.TabIndex = 0;
            this.lbSchoolYear.Text = "Năm học";
            // 
            // mainLbClassDetail
            // 
            this.mainLbClassDetail.AutoSize = true;
            this.mainLbClassDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.mainLbClassDetail.Location = new System.Drawing.Point(485, 9);
            this.mainLbClassDetail.Name = "mainLbClassDetail";
            this.mainLbClassDetail.Size = new System.Drawing.Size(276, 46);
            this.mainLbClassDetail.TabIndex = 1;
            this.mainLbClassDetail.Text = "Danh sách lớp";
            // 
            // duLieu
            // 
            this.duLieu.DataSetName = "DuLieu";
            this.duLieu.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lOPTableAdapter
            // 
            this.lOPTableAdapter.ClearBeforeFill = true;
            // 
            // LapDanhSachLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 648);
            this.Controls.Add(this.mainLbClassDetail);
            this.Controls.Add(this.panel1);
            this.Name = "LapDanhSachLop";
            this.Text = "LapDanhSachLop";
            this.Load += new System.EventHandler(this.LapDanhSachLop_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.duLieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOPBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbStdNum;
        private System.Windows.Forms.Label lbStdNum;
        private System.Windows.Forms.Label lbClass;
        private System.Windows.Forms.Label lbGrade;
        private System.Windows.Forms.Label lbSchoolYear;
        private System.Windows.Forms.Label mainLbClassDetail;
        private DuLieu duLieu;
        private System.Windows.Forms.BindingSource lOPBindingSource;
        private DuLieuTableAdapters.LOPTableAdapter lOPTableAdapter;
        private Guna.UI2.WinForms.Guna2ComboBox cbClass;
        private Guna.UI2.WinForms.Guna2ComboBox cbGrade;
        private Guna.UI2.WinForms.Guna2ComboBox cbSchoolYear;
    }
}