
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
            this.LabelNameProject = new System.Windows.Forms.Label();
            this.PanelTitle = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuItemHome = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemAddStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemFindStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSubjectScore = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemScoreBoard = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSubjectScoreYear = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemFinalReport = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemClassScore = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelTitle.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelNameProject
            // 
            this.LabelNameProject.AutoSize = true;
            this.LabelNameProject.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelNameProject.Location = new System.Drawing.Point(26, 15);
            this.LabelNameProject.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelNameProject.Name = "LabelNameProject";
            this.LabelNameProject.Size = new System.Drawing.Size(458, 55);
            this.LabelNameProject.TabIndex = 0;
            this.LabelNameProject.Text = "QUẢN LÍ HỌC SINH";
            // 
            // PanelTitle
            // 
            this.PanelTitle.Controls.Add(this.LabelNameProject);
            this.PanelTitle.Location = new System.Drawing.Point(6, 7);
            this.PanelTitle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PanelTitle.Name = "PanelTitle";
            this.PanelTitle.Size = new System.Drawing.Size(560, 87);
            this.PanelTitle.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemHome,
            this.MenuItemAddStudent,
            this.MenuItemFindStudent,
            this.MenuItemSubjectScore,
            this.MenuItemScoreBoard,
            this.MenuItemSubjectScoreYear,
            this.MenuItemFinalReport,
            this.MenuItemClassScore});
            this.menuStrip1.Location = new System.Drawing.Point(6, 110);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1191, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuItemHome
            // 
            this.MenuItemHome.Name = "MenuItemHome";
            this.MenuItemHome.Size = new System.Drawing.Size(74, 20);
            this.MenuItemHome.Text = "Trang chủ ";
            // 
            // MenuItemAddStudent
            // 
            this.MenuItemAddStudent.Name = "MenuItemAddStudent";
            this.MenuItemAddStudent.Size = new System.Drawing.Size(119, 20);
            this.MenuItemAddStudent.Text = "Tiếp nhận học sinh";
            this.MenuItemAddStudent.Click += new System.EventHandler(this.MenuItemAddStudent_Click);
            // 
            // MenuItemFindStudent
            // 
            this.MenuItemFindStudent.Name = "MenuItemFindStudent";
            this.MenuItemFindStudent.Size = new System.Drawing.Size(105, 20);
            this.MenuItemFindStudent.Text = "Tra cứu học sinh";
            this.MenuItemFindStudent.Click += new System.EventHandler(this.MenuItemFindStudent_Click);
            // 
            // MenuItemSubjectScore
            // 
            this.MenuItemSubjectScore.Name = "MenuItemSubjectScore";
            this.MenuItemSubjectScore.Size = new System.Drawing.Size(159, 20);
            this.MenuItemSubjectScore.Text = "Nhập bảng điểm môn học";
            this.MenuItemSubjectScore.Click += new System.EventHandler(this.MenuItemSubjectScore_Click);
            // 
            // MenuItemScoreBoard
            // 
            this.MenuItemScoreBoard.Name = "MenuItemScoreBoard";
            this.MenuItemScoreBoard.Size = new System.Drawing.Size(124, 20);
            this.MenuItemScoreBoard.Text = "Bảng điểm học sinh";
            this.MenuItemScoreBoard.Click += new System.EventHandler(this.MenuItemScoreBoard_Click);
            // 
            // MenuItemSubjectScoreYear
            // 
            this.MenuItemSubjectScoreYear.Name = "MenuItemSubjectScoreYear";
            this.MenuItemSubjectScoreYear.Size = new System.Drawing.Size(233, 20);
            this.MenuItemSubjectScoreYear.Text = "Lập bảng điểm môn học của lớp cả năm";
            this.MenuItemSubjectScoreYear.Click += new System.EventHandler(this.MenuItemSubjectScoreYear_Click);
            // 
            // MenuItemFinalReport
            // 
            this.MenuItemFinalReport.Name = "MenuItemFinalReport";
            this.MenuItemFinalReport.Size = new System.Drawing.Size(108, 20);
            this.MenuItemFinalReport.Text = "Báo cáo tổng kết";
            this.MenuItemFinalReport.Click += new System.EventHandler(this.MenuItemFinalReport_Click);
            // 
            // MenuItemClassScore
            // 
            this.MenuItemClassScore.Name = "MenuItemClassScore";
            this.MenuItemClassScore.Size = new System.Drawing.Size(143, 20);
            this.MenuItemClassScore.Text = "Bảng điểm tổng kết lớp";
            this.MenuItemClassScore.Click += new System.EventHandler(this.MenuItemClassScore_Click);
            // 
            // TrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 366);
            this.Controls.Add(this.PanelTitle);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "TrangChu";
            this.Text = "Form1";
            this.PanelTitle.ResumeLayout(false);
            this.PanelTitle.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelNameProject;
        private System.Windows.Forms.Panel PanelTitle;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemHome;
        private System.Windows.Forms.ToolStripMenuItem MenuItemFinalReport;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSubjectScore;
        private System.Windows.Forms.ToolStripMenuItem MenuItemScoreBoard;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSubjectScoreYear;
        private System.Windows.Forms.ToolStripMenuItem MenuItemAddStudent;
        private System.Windows.Forms.ToolStripMenuItem MenuItemFindStudent;
        private System.Windows.Forms.ToolStripMenuItem MenuItemClassScore;
    }
}