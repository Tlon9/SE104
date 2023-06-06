
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
            this.MenuItemSubjectScore = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSubjectScore1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSubjectScoreYear = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemFinalReport = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemClassReport = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemFinalReport = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuQuanLyQuyDinh = new System.Windows.Forms.ToolStripMenuItem();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2ImageButtonClose1 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2ImageButtonMinimize1 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.MenuItemListCreate = new System.Windows.Forms.ToolStripMenuItem();
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
            this.MenuItemListCreate,
            this.MenuItemSearch,
            this.MenuItemSubjectScore,
            this.MenuItemFinalReport,
            this.MenuQuanLyQuyDinh});
            this.menuStrip1.Location = new System.Drawing.Point(8, 135);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1251, 50);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuItemAddStudent
            // 
            this.MenuItemAddStudent.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuItemAddStudent.ForeColor = System.Drawing.SystemColors.Window;
            this.MenuItemAddStudent.Name = "MenuItemAddStudent";
            this.MenuItemAddStudent.Size = new System.Drawing.Size(205, 46);
            this.MenuItemAddStudent.Text = "Tiếp nhận học sinh";
            this.MenuItemAddStudent.Visible = false;
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
            this.MenuItemSearch.Size = new System.Drawing.Size(96, 46);
            this.MenuItemSearch.Text = "Tra cứu";
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
            this.MenuItemSubjectScore.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemSubjectScore1,
            this.MenuItemSubjectScoreYear});
            this.MenuItemSubjectScore.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuItemSubjectScore.ForeColor = System.Drawing.SystemColors.Window;
            this.MenuItemSubjectScore.Name = "MenuItemSubjectScore";
            this.MenuItemSubjectScore.Size = new System.Drawing.Size(128, 46);
            this.MenuItemSubjectScore.Text = "Bảng điểm";
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
            this.MenuItemFinalReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemClassReport,
            this.ToolStripMenuItemFinalReport});
            this.MenuItemFinalReport.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuItemFinalReport.ForeColor = System.Drawing.SystemColors.Window;
            this.MenuItemFinalReport.Name = "MenuItemFinalReport";
            this.MenuItemFinalReport.Size = new System.Drawing.Size(187, 46);
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
            this.MenuQuanLyQuyDinh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuQuanLyQuyDinh.ForeColor = System.Drawing.Color.White;
            this.MenuQuanLyQuyDinh.Name = "MenuQuanLyQuyDinh";
            this.MenuQuanLyQuyDinh.Size = new System.Drawing.Size(189, 46);
            this.MenuQuanLyQuyDinh.Text = "Quản lý quy định";
            this.MenuQuanLyQuyDinh.Visible = false;
            this.MenuQuanLyQuyDinh.Click += new System.EventHandler(this.MenuQuanLyQuyDinh_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.guna2Panel1.Controls.Add(this.guna2ImageButtonClose1);
            this.guna2Panel1.Controls.Add(this.guna2ImageButtonMinimize1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1232, 53);
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
            this.guna2ImageButtonClose1.Location = new System.Drawing.Point(1181, 4);
            this.guna2ImageButtonClose1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2ImageButtonClose1.Name = "guna2ImageButtonClose1";
            this.guna2ImageButtonClose1.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButtonClose1.Size = new System.Drawing.Size(47, 43);
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
            this.guna2ImageButtonMinimize1.Location = new System.Drawing.Point(1127, 4);
            this.guna2ImageButtonMinimize1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2ImageButtonMinimize1.Name = "guna2ImageButtonMinimize1";
            this.guna2ImageButtonMinimize1.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButtonMinimize1.Size = new System.Drawing.Size(47, 43);
            this.guna2ImageButtonMinimize1.TabIndex = 0;
            this.guna2ImageButtonMinimize1.Click += new System.EventHandler(this.guna2ImageButtonMinimize1_Click);
            // 
            // MenuItemListCreate
            // 
            this.MenuItemListCreate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuItemListCreate.ForeColor = System.Drawing.Color.White;
            this.MenuItemListCreate.Name = "MenuItemListCreate";
            this.MenuItemListCreate.Size = new System.Drawing.Size(197, 46);
            this.MenuItemListCreate.Text = "Lập danh sách lớp";
            this.MenuItemListCreate.Visible = false;
            this.MenuItemListCreate.Click += new System.EventHandler(this.MenuItemListCreate_Click);
            // 
            // TrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1232, 540);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private System.Windows.Forms.ToolStripMenuItem MenuItemSearch;
        private System.Windows.Forms.ToolStripMenuItem MenuItemFindStudent;
        private System.Windows.Forms.ToolStripMenuItem MenuItemScoreBoard;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSubjectScore;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSubjectScore1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSubjectScoreYear;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButtonClose1;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButtonMinimize1;
        private System.Windows.Forms.ToolStripMenuItem MenuQuanLyQuyDinh;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemClassReport;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemFinalReport;
        private System.Windows.Forms.ToolStripMenuItem MenuItemListCreate;
    }
}