
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuItemAddStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemFindStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemScoreBoard = new System.Windows.Forms.ToolStripMenuItem();
            this.bảngĐiểmToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSubjectScore = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSubjectScoreYear = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemFinalReport = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemClassScore = new System.Windows.Forms.ToolStripMenuItem();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2ImageButtonClose1 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2ImageButtonMinimize1 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.MenuQuanLyQuyDinh = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemAddStudent,
            this.MenuItemSearch,
            this.bảngĐiểmToolStripMenuItem1,
            this.MenuItemFinalReport,
            this.MenuItemClassScore,
            this.MenuQuanLyQuyDinh});
            this.menuStrip1.Location = new System.Drawing.Point(6, 110);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(938, 41);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuItemAddStudent
            // 
            this.MenuItemAddStudent.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuItemAddStudent.ForeColor = System.Drawing.SystemColors.Window;
            this.MenuItemAddStudent.Name = "MenuItemAddStudent";
            this.MenuItemAddStudent.Size = new System.Drawing.Size(166, 37);
            this.MenuItemAddStudent.Text = "Tiếp nhận học sinh";
            this.MenuItemAddStudent.Click += new System.EventHandler(this.MenuItemAddStudent_Click);
            // 
            // MenuItemSearch
            // 
            this.MenuItemSearch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemFindStudent,
            this.MenuItemScoreBoard});
            this.MenuItemSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuItemSearch.ForeColor = System.Drawing.SystemColors.Window;
            this.MenuItemSearch.Name = "MenuItemSearch";
            this.MenuItemSearch.Size = new System.Drawing.Size(78, 37);
            this.MenuItemSearch.Text = "Tra cứu";
            // 
            // MenuItemFindStudent
            // 
            this.MenuItemFindStudent.Name = "MenuItemFindStudent";
            this.MenuItemFindStudent.Size = new System.Drawing.Size(222, 26);
            this.MenuItemFindStudent.Text = "Tra cứu thông tin";
            this.MenuItemFindStudent.Click += new System.EventHandler(this.MenuItemFindStudent_Click);
            // 
            // MenuItemScoreBoard
            // 
            this.MenuItemScoreBoard.Name = "MenuItemScoreBoard";
            this.MenuItemScoreBoard.Size = new System.Drawing.Size(222, 26);
            this.MenuItemScoreBoard.Text = "Tra cứu bảng điểm";
            this.MenuItemScoreBoard.Click += new System.EventHandler(this.MenuItemScoreBoard_Click);
            // 
            // bảngĐiểmToolStripMenuItem1
            // 
            this.bảngĐiểmToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemSubjectScore,
            this.MenuItemSubjectScoreYear});
            this.bảngĐiểmToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bảngĐiểmToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.Window;
            this.bảngĐiểmToolStripMenuItem1.Name = "bảngĐiểmToolStripMenuItem1";
            this.bảngĐiểmToolStripMenuItem1.Size = new System.Drawing.Size(104, 37);
            this.bảngĐiểmToolStripMenuItem1.Text = "Bảng điểm";
            // 
            // MenuItemSubjectScore
            // 
            this.MenuItemSubjectScore.Name = "MenuItemSubjectScore";
            this.MenuItemSubjectScore.Size = new System.Drawing.Size(279, 26);
            this.MenuItemSubjectScore.Text = "Nhập bảng điểm môn học";
            this.MenuItemSubjectScore.Click += new System.EventHandler(this.MenuItemSubjectScore_Click);
            // 
            // MenuItemSubjectScoreYear
            // 
            this.MenuItemSubjectScoreYear.Name = "MenuItemSubjectScoreYear";
            this.MenuItemSubjectScoreYear.Size = new System.Drawing.Size(279, 26);
            this.MenuItemSubjectScoreYear.Text = "Xuất bảng điểm môn học";
            this.MenuItemSubjectScoreYear.Click += new System.EventHandler(this.MenuItemSubjectScoreYear_Click);
            // 
            // MenuItemFinalReport
            // 
            this.MenuItemFinalReport.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuItemFinalReport.ForeColor = System.Drawing.SystemColors.Window;
            this.MenuItemFinalReport.Name = "MenuItemFinalReport";
            this.MenuItemFinalReport.Size = new System.Drawing.Size(150, 37);
            this.MenuItemFinalReport.Text = "Báo cáo tổng kết";
            this.MenuItemFinalReport.Click += new System.EventHandler(this.MenuItemFinalReport_Click);
            // 
            // MenuItemClassScore
            // 
            this.MenuItemClassScore.AutoSize = false;
            this.MenuItemClassScore.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuItemClassScore.ForeColor = System.Drawing.SystemColors.Window;
            this.MenuItemClassScore.Name = "MenuItemClassScore";
            this.MenuItemClassScore.Size = new System.Drawing.Size(250, 50);
            this.MenuItemClassScore.Text = "Bảng điểm tổng kết lớp";
            this.MenuItemClassScore.Click += new System.EventHandler(this.MenuItemClassScore_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.guna2Panel1.Controls.Add(this.guna2ImageButtonClose1);
            this.guna2Panel1.Controls.Add(this.guna2ImageButtonMinimize1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(924, 43);
            this.guna2Panel1.TabIndex = 17;
            this.guna2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.guna2Panel1_MouseDown);
            // 
            // guna2ImageButtonClose1
            // 
            this.guna2ImageButtonClose1.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButtonClose1.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButtonClose1.Image = ((System.Drawing.Image)(resources.GetObject("guna2ImageButtonClose1.Image")));
            this.guna2ImageButtonClose1.ImageOffset = new System.Drawing.Point(0, 0);
            this.guna2ImageButtonClose1.ImageRotate = 0F;
            this.guna2ImageButtonClose1.ImageSize = new System.Drawing.Size(30, 30);
            this.guna2ImageButtonClose1.Location = new System.Drawing.Point(886, 3);
            this.guna2ImageButtonClose1.Name = "guna2ImageButtonClose1";
            this.guna2ImageButtonClose1.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButtonClose1.Size = new System.Drawing.Size(35, 35);
            this.guna2ImageButtonClose1.TabIndex = 1;
            this.guna2ImageButtonClose1.Click += new System.EventHandler(this.guna2ImageButtonClose1_Click);
            // 
            // guna2ImageButtonMinimize1
            // 
            this.guna2ImageButtonMinimize1.BackColor = System.Drawing.SystemColors.Highlight;
            this.guna2ImageButtonMinimize1.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButtonMinimize1.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButtonMinimize1.Image = ((System.Drawing.Image)(resources.GetObject("guna2ImageButtonMinimize1.Image")));
            this.guna2ImageButtonMinimize1.ImageOffset = new System.Drawing.Point(0, 0);
            this.guna2ImageButtonMinimize1.ImageRotate = 0F;
            this.guna2ImageButtonMinimize1.ImageSize = new System.Drawing.Size(30, 30);
            this.guna2ImageButtonMinimize1.Location = new System.Drawing.Point(845, 3);
            this.guna2ImageButtonMinimize1.Name = "guna2ImageButtonMinimize1";
            this.guna2ImageButtonMinimize1.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButtonMinimize1.Size = new System.Drawing.Size(35, 35);
            this.guna2ImageButtonMinimize1.TabIndex = 0;
            this.guna2ImageButtonMinimize1.Click += new System.EventHandler(this.guna2ImageButtonMinimize1_Click);
            // 
            // MenuQuanLyQuyDinh
            // 
            this.MenuQuanLyQuyDinh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuQuanLyQuyDinh.ForeColor = System.Drawing.Color.White;
            this.MenuQuanLyQuyDinh.Name = "MenuQuanLyQuyDinh";
            this.MenuQuanLyQuyDinh.Size = new System.Drawing.Size(153, 37);
            this.MenuQuanLyQuyDinh.Text = "Quản lý quy định";
            this.MenuQuanLyQuyDinh.Click += new System.EventHandler(this.MenuQuanLyQuyDinh_Click);
            // 
            // TrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(924, 439);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "TrangChu";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemFinalReport;
        private System.Windows.Forms.ToolStripMenuItem MenuItemAddStudent;
        private System.Windows.Forms.ToolStripMenuItem MenuItemClassScore;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSearch;
        private System.Windows.Forms.ToolStripMenuItem MenuItemFindStudent;
        private System.Windows.Forms.ToolStripMenuItem MenuItemScoreBoard;
        private System.Windows.Forms.ToolStripMenuItem bảngĐiểmToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSubjectScore;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSubjectScoreYear;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButtonClose1;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButtonMinimize1;
        private System.Windows.Forms.ToolStripMenuItem MenuQuanLyQuyDinh;
    }
}