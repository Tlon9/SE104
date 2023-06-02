namespace QuanLyHocSinh
{
    partial class TiepNhanHocSinh
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnInteractStudentInfo = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddNewStudent = new Guna.UI2.WinForms.Guna2Button();
            this.btnHomeScreen = new Guna.UI2.WinForms.Guna2Button();
            this.uC_ThemHocSinhMoi1 = new QuanLyHocSinh.UC_ThemHocSinhMoi();
            this.uC_XemThongTinHocSinh1 = new QuanLyHocSinh.UC_XemThongTinHocSinh();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnInteractStudentInfo);
            this.panel1.Controls.Add(this.btnAddNewStudent);
            this.panel1.Location = new System.Drawing.Point(246, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1212, 98);
            this.panel1.TabIndex = 0;
            // 
            // btnInteractStudentInfo
            // 
            this.btnInteractStudentInfo.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnInteractStudentInfo.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnInteractStudentInfo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnInteractStudentInfo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnInteractStudentInfo.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnInteractStudentInfo.ForeColor = System.Drawing.Color.White;
            this.btnInteractStudentInfo.Location = new System.Drawing.Point(681, 19);
            this.btnInteractStudentInfo.Name = "btnInteractStudentInfo";
            this.btnInteractStudentInfo.Size = new System.Drawing.Size(346, 57);
            this.btnInteractStudentInfo.TabIndex = 1;
            this.btnInteractStudentInfo.Text = "Xem thông tin học sinh";
            this.btnInteractStudentInfo.Click += new System.EventHandler(this.btnInteractStudentInfo_Click);
            // 
            // btnAddNewStudent
            // 
            this.btnAddNewStudent.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewStudent.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewStudent.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddNewStudent.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddNewStudent.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnAddNewStudent.ForeColor = System.Drawing.Color.White;
            this.btnAddNewStudent.Location = new System.Drawing.Point(167, 19);
            this.btnAddNewStudent.Name = "btnAddNewStudent";
            this.btnAddNewStudent.Size = new System.Drawing.Size(280, 57);
            this.btnAddNewStudent.TabIndex = 0;
            this.btnAddNewStudent.Text = "Thêm học sinh mới";
            this.btnAddNewStudent.Click += new System.EventHandler(this.btnAddNewStudent_Click);
            // 
            // btnHomeScreen
            // 
            this.btnHomeScreen.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHomeScreen.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHomeScreen.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHomeScreen.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHomeScreen.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnHomeScreen.ForeColor = System.Drawing.Color.White;
            this.btnHomeScreen.Location = new System.Drawing.Point(25, 43);
            this.btnHomeScreen.Name = "btnHomeScreen";
            this.btnHomeScreen.Size = new System.Drawing.Size(180, 45);
            this.btnHomeScreen.TabIndex = 1;
            this.btnHomeScreen.Text = "Trang chủ";
            this.btnHomeScreen.Click += new System.EventHandler(this.btnHomeScreen_Click);
            // 
            // uC_ThemHocSinhMoi1
            // 
            this.uC_ThemHocSinhMoi1.Location = new System.Drawing.Point(126, 127);
            this.uC_ThemHocSinhMoi1.Name = "uC_ThemHocSinhMoi1";
            this.uC_ThemHocSinhMoi1.Size = new System.Drawing.Size(1257, 811);
            this.uC_ThemHocSinhMoi1.TabIndex = 2;
            // 
            // uC_XemThongTinHocSinh1
            // 
            this.uC_XemThongTinHocSinh1.Location = new System.Drawing.Point(117, 121);
            this.uC_XemThongTinHocSinh1.Name = "uC_XemThongTinHocSinh1";
            this.uC_XemThongTinHocSinh1.Size = new System.Drawing.Size(1257, 811);
            this.uC_XemThongTinHocSinh1.TabIndex = 3;
            // 
            // TiepNhanHocSinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1478, 944);
            this.Controls.Add(this.uC_XemThongTinHocSinh1);
            this.Controls.Add(this.uC_ThemHocSinhMoi1);
            this.Controls.Add(this.btnHomeScreen);
            this.Controls.Add(this.panel1);
            this.Name = "TiepNhanHocSinh";
            this.Text = "TiepNhanHocSinh";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button btnInteractStudentInfo;
        private Guna.UI2.WinForms.Guna2Button btnAddNewStudent;
        private Guna.UI2.WinForms.Guna2Button btnHomeScreen;
        private UC_ThemHocSinhMoi uC_ThemHocSinhMoi1;
        private UC_XemThongTinHocSinh uC_XemThongTinHocSinh1;
    }
}