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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TiepNhanHocSinh));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ButtonInteractStudentInfo = new Guna.UI2.WinForms.Guna2Button();
            this.ButtonAddNewStudent = new Guna.UI2.WinForms.Guna2Button();
            this.ButtonHomeScreen = new Guna.UI2.WinForms.Guna2Button();
            this.Button_Minimize = new Guna.UI2.WinForms.Guna2ImageButton();
            this.Button_Close = new Guna.UI2.WinForms.Guna2ImageButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.mainLabelStdInfo = new System.Windows.Forms.Label();
            this.uC_XemThongTinHocSinh1 = new QuanLyHocSinh.UC_XemThongTinHocSinh();
            this.uC_ThemHocSinhMoi1 = new QuanLyHocSinh.UC_ThemHocSinhMoi();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightCyan;
            this.panel1.Controls.Add(this.ButtonInteractStudentInfo);
            this.panel1.Controls.Add(this.ButtonAddNewStudent);
            this.panel1.Location = new System.Drawing.Point(186, 63);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1077, 78);
            this.panel1.TabIndex = 0;
            // 
            // ButtonInteractStudentInfo
            // 
            this.ButtonInteractStudentInfo.AutoRoundedCorners = true;
            this.ButtonInteractStudentInfo.BorderRadius = 20;
            this.ButtonInteractStudentInfo.DefaultAutoSize = true;
            this.ButtonInteractStudentInfo.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ButtonInteractStudentInfo.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ButtonInteractStudentInfo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ButtonInteractStudentInfo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ButtonInteractStudentInfo.FillColor = System.Drawing.SystemColors.Highlight;
            this.ButtonInteractStudentInfo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonInteractStudentInfo.ForeColor = System.Drawing.Color.White;
            this.ButtonInteractStudentInfo.Location = new System.Drawing.Point(605, 15);
            this.ButtonInteractStudentInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ButtonInteractStudentInfo.Name = "ButtonInteractStudentInfo";
            this.ButtonInteractStudentInfo.Size = new System.Drawing.Size(296, 43);
            this.ButtonInteractStudentInfo.TabIndex = 1;
            this.ButtonInteractStudentInfo.Text = "Xem thông tin học sinh";
            this.ButtonInteractStudentInfo.Click += new System.EventHandler(this.ButtonInteractStudentInfo_Click);
            // 
            // ButtonAddNewStudent
            // 
            this.ButtonAddNewStudent.AutoRoundedCorners = true;
            this.ButtonAddNewStudent.BorderRadius = 20;
            this.ButtonAddNewStudent.DefaultAutoSize = true;
            this.ButtonAddNewStudent.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ButtonAddNewStudent.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ButtonAddNewStudent.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ButtonAddNewStudent.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ButtonAddNewStudent.FillColor = System.Drawing.SystemColors.Highlight;
            this.ButtonAddNewStudent.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonAddNewStudent.ForeColor = System.Drawing.Color.White;
            this.ButtonAddNewStudent.Location = new System.Drawing.Point(148, 15);
            this.ButtonAddNewStudent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ButtonAddNewStudent.Name = "ButtonAddNewStudent";
            this.ButtonAddNewStudent.Size = new System.Drawing.Size(248, 43);
            this.ButtonAddNewStudent.TabIndex = 0;
            this.ButtonAddNewStudent.Text = "Thêm học sinh mới";
            this.ButtonAddNewStudent.Click += new System.EventHandler(this.ButtonAddNewStudent_Click);
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
            this.ButtonHomeScreen.ImageSize = new System.Drawing.Size(40, 40);
            this.ButtonHomeScreen.Location = new System.Drawing.Point(68, 63);
            this.ButtonHomeScreen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ButtonHomeScreen.Name = "ButtonHomeScreen";
            this.ButtonHomeScreen.Size = new System.Drawing.Size(62, 67);
            this.ButtonHomeScreen.TabIndex = 1;
            this.ButtonHomeScreen.Click += new System.EventHandler(this.ButtonHomeScreen_Click);
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
            this.Button_Minimize.Location = new System.Drawing.Point(1164, 11);
            this.Button_Minimize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Button_Minimize.Name = "Button_Minimize";
            this.Button_Minimize.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.Button_Minimize.Size = new System.Drawing.Size(47, 43);
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
            this.Button_Close.Location = new System.Drawing.Point(1218, 11);
            this.Button_Close.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Button_Close.Name = "Button_Close";
            this.Button_Close.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.Button_Close.Size = new System.Drawing.Size(47, 43);
            this.Button_Close.TabIndex = 5;
            this.Button_Close.Click += new System.EventHandler(this.Button_Close_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel2.Controls.Add(this.mainLabelStdInfo);
            this.panel2.Controls.Add(this.Button_Minimize);
            this.panel2.Controls.Add(this.Button_Close);
            this.panel2.Location = new System.Drawing.Point(-2, -2);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1316, 61);
            this.panel2.TabIndex = 6;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            // 
            // mainLabelStdInfo
            // 
            this.mainLabelStdInfo.AutoSize = true;
            this.mainLabelStdInfo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainLabelStdInfo.ForeColor = System.Drawing.Color.White;
            this.mainLabelStdInfo.Location = new System.Drawing.Point(52, 14);
            this.mainLabelStdInfo.Name = "mainLabelStdInfo";
            this.mainLabelStdInfo.Size = new System.Drawing.Size(203, 37);
            this.mainLabelStdInfo.TabIndex = 6;
            this.mainLabelStdInfo.Text = "Hồ sơ học sinh";
            this.mainLabelStdInfo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainLabelStdInfo_MouseDown);
            // 
            // uC_XemThongTinHocSinh1
            // 
            this.uC_XemThongTinHocSinh1.AutoSize = true;
            this.uC_XemThongTinHocSinh1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.uC_XemThongTinHocSinh1.Location = new System.Drawing.Point(71, 150);
            this.uC_XemThongTinHocSinh1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.uC_XemThongTinHocSinh1.Name = "uC_XemThongTinHocSinh1";
            this.uC_XemThongTinHocSinh1.Size = new System.Drawing.Size(663, 80);
            this.uC_XemThongTinHocSinh1.TabIndex = 3;
            // 
            // uC_ThemHocSinhMoi1
            // 
            this.uC_ThemHocSinhMoi1.Location = new System.Drawing.Point(68, 155);
            this.uC_ThemHocSinhMoi1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.uC_ThemHocSinhMoi1.Name = "uC_ThemHocSinhMoi1";
            this.uC_ThemHocSinhMoi1.Size = new System.Drawing.Size(1117, 649);
            this.uC_ThemHocSinhMoi1.TabIndex = 2;
            // 
            // TiepNhanHocSinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1383, 776);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.uC_XemThongTinHocSinh1);
            this.Controls.Add(this.uC_ThemHocSinhMoi1);
            this.Controls.Add(this.ButtonHomeScreen);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "TiepNhanHocSinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TiepNhanHocSinh";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button ButtonInteractStudentInfo;
        private Guna.UI2.WinForms.Guna2Button ButtonAddNewStudent;
        private Guna.UI2.WinForms.Guna2Button ButtonHomeScreen;
        private UC_ThemHocSinhMoi uC_ThemHocSinhMoi1;
        private UC_XemThongTinHocSinh uC_XemThongTinHocSinh1;
        private Guna.UI2.WinForms.Guna2ImageButton Button_Minimize;
        private Guna.UI2.WinForms.Guna2ImageButton Button_Close;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label mainLabelStdInfo;
    }
}