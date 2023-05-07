
namespace QuanLyHocSinh
{
    partial class BaoCaoTongKet
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
            this.PanelTitle = new System.Windows.Forms.Panel();
            this.LabelNameProject = new System.Windows.Forms.Label();
            this.MenuReport = new System.Windows.Forms.MenuStrip();
            this.tổngKếtMônNămHọcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tổngKếtMônHọcKìToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tổngKếtHọcKìToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tổngKếtNămHọcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.ButtonReport = new System.Windows.Forms.Button();
            this.ComboBoxSemesters = new System.Windows.Forms.ComboBox();
            this.ComboBoxYears = new System.Windows.Forms.ComboBox();
            this.ComboBoxSubjects = new System.Windows.Forms.ComboBox();
            this.PanelTitle.SuspendLayout();
            this.MenuReport.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelTitle
            // 
            this.PanelTitle.Controls.Add(this.LabelNameProject);
            this.PanelTitle.Location = new System.Drawing.Point(9, 10);
            this.PanelTitle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PanelTitle.Name = "PanelTitle";
            this.PanelTitle.Size = new System.Drawing.Size(788, 107);
            this.PanelTitle.TabIndex = 0;
            // 
            // LabelNameProject
            // 
            this.LabelNameProject.AutoSize = true;
            this.LabelNameProject.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelNameProject.Location = new System.Drawing.Point(319, 23);
            this.LabelNameProject.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelNameProject.Name = "LabelNameProject";
            this.LabelNameProject.Size = new System.Drawing.Size(301, 36);
            this.LabelNameProject.TabIndex = 0;
            this.LabelNameProject.Text = "QUẢN LÍ HỌC SINH";
            // 
            // MenuReport
            // 
            this.MenuReport.Dock = System.Windows.Forms.DockStyle.None;
            this.MenuReport.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuReport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tổngKếtMônNămHọcToolStripMenuItem,
            this.tổngKếtMônHọcKìToolStripMenuItem,
            this.tổngKếtHọcKìToolStripMenuItem,
            this.tổngKếtNămHọcToolStripMenuItem});
            this.MenuReport.Location = new System.Drawing.Point(16, 119);
            this.MenuReport.Name = "MenuReport";
            this.MenuReport.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.MenuReport.Size = new System.Drawing.Size(492, 24);
            this.MenuReport.TabIndex = 1;
            this.MenuReport.Text = "menuStrip1";
            // 
            // tổngKếtMônNămHọcToolStripMenuItem
            // 
            this.tổngKếtMônNămHọcToolStripMenuItem.Name = "tổngKếtMônNămHọcToolStripMenuItem";
            this.tổngKếtMônNămHọcToolStripMenuItem.Size = new System.Drawing.Size(143, 20);
            this.tổngKếtMônNămHọcToolStripMenuItem.Text = "Tổng kết môn năm học";
            this.tổngKếtMônNămHọcToolStripMenuItem.Click += new System.EventHandler(this.tổngKếtMônNămHọcToolStripMenuItem_Click);
            // 
            // tổngKếtMônHọcKìToolStripMenuItem
            // 
            this.tổngKếtMônHọcKìToolStripMenuItem.Name = "tổngKếtMônHọcKìToolStripMenuItem";
            this.tổngKếtMônHọcKìToolStripMenuItem.Size = new System.Drawing.Size(128, 20);
            this.tổngKếtMônHọcKìToolStripMenuItem.Text = "Tổng kết môn học kì";
            // 
            // tổngKếtHọcKìToolStripMenuItem
            // 
            this.tổngKếtHọcKìToolStripMenuItem.Name = "tổngKếtHọcKìToolStripMenuItem";
            this.tổngKếtHọcKìToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.tổngKếtHọcKìToolStripMenuItem.Text = "Tổng kết học kì";
            // 
            // tổngKếtNămHọcToolStripMenuItem
            // 
            this.tổngKếtNămHọcToolStripMenuItem.Name = "tổngKếtNămHọcToolStripMenuItem";
            this.tổngKếtNămHọcToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.tổngKếtNămHọcToolStripMenuItem.Text = "Tổng kết năm học";
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.ButtonReport);
            this.Panel1.Controls.Add(this.ComboBoxSemesters);
            this.Panel1.Controls.Add(this.ComboBoxYears);
            this.Panel1.Controls.Add(this.ComboBoxSubjects);
            this.Panel1.Location = new System.Drawing.Point(16, 145);
            this.Panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(490, 46);
            this.Panel1.TabIndex = 2;
            // 
            // ButtonReport
            // 
            this.ButtonReport.Location = new System.Drawing.Point(369, 16);
            this.ButtonReport.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ButtonReport.Name = "ButtonReport";
            this.ButtonReport.Size = new System.Drawing.Size(56, 19);
            this.ButtonReport.TabIndex = 3;
            this.ButtonReport.Text = "Xuất";
            this.ButtonReport.UseVisualStyleBackColor = true;
            // 
            // ComboBoxSemesters
            // 
            this.ComboBoxSemesters.FormattingEnabled = true;
            this.ComboBoxSemesters.Items.AddRange(new object[] {
            "1",
            "2"});
            this.ComboBoxSemesters.Location = new System.Drawing.Point(253, 15);
            this.ComboBoxSemesters.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ComboBoxSemesters.Name = "ComboBoxSemesters";
            this.ComboBoxSemesters.Size = new System.Drawing.Size(92, 21);
            this.ComboBoxSemesters.TabIndex = 2;
            this.ComboBoxSemesters.Text = "Học kì";
            // 
            // ComboBoxYears
            // 
            this.ComboBoxYears.FormattingEnabled = true;
            this.ComboBoxYears.Items.AddRange(new object[] {
            "2021-2022",
            "2022-2023",
            "2023-2024"});
            this.ComboBoxYears.Location = new System.Drawing.Point(124, 15);
            this.ComboBoxYears.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ComboBoxYears.Name = "ComboBoxYears";
            this.ComboBoxYears.Size = new System.Drawing.Size(112, 21);
            this.ComboBoxYears.TabIndex = 1;
            this.ComboBoxYears.Text = "Năm học";
            // 
            // ComboBoxSubjects
            // 
            this.ComboBoxSubjects.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.ComboBoxSubjects.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ComboBoxSubjects.FormattingEnabled = true;
            this.ComboBoxSubjects.Items.AddRange(new object[] {
            "Toán",
            "Ngữ Văn ",
            "Anh văn ",
            "Vật lí ",
            "Hóa học",
            "Sinh học",
            "Lịch sử, ",
            "Địa lí ",
            "Tin học ",
            "Công Nghệ",
            "GDQP",
            "GDCD ",
            "Thể Dục "});
            this.ComboBoxSubjects.Location = new System.Drawing.Point(2, 15);
            this.ComboBoxSubjects.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ComboBoxSubjects.Name = "ComboBoxSubjects";
            this.ComboBoxSubjects.Size = new System.Drawing.Size(105, 21);
            this.ComboBoxSubjects.TabIndex = 0;
            this.ComboBoxSubjects.Text = "Môn học";
            this.ComboBoxSubjects.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSubjects_SelectedIndexChanged);
            this.ComboBoxSubjects.SelectedValueChanged += new System.EventHandler(this.ComboBoxSubjects_SelectedValueChanged);
            // 
            // BaoCaoTongKet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 541);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.PanelTitle);
            this.Controls.Add(this.MenuReport);
            this.MainMenuStrip = this.MenuReport;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "BaoCaoTongKet";
            this.Text = "BaoCaoTongKet";
            this.PanelTitle.ResumeLayout(false);
            this.PanelTitle.PerformLayout();
            this.MenuReport.ResumeLayout(false);
            this.MenuReport.PerformLayout();
            this.Panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelTitle;
        private System.Windows.Forms.Label LabelNameProject;
        private System.Windows.Forms.MenuStrip MenuReport;
        private System.Windows.Forms.ToolStripMenuItem tổngKếtMônNămHọcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tổngKếtMônHọcKìToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tổngKếtHọcKìToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tổngKếtNămHọcToolStripMenuItem;
        private System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.ComboBox ComboBoxSubjects;
        private System.Windows.Forms.ComboBox ComboBoxYears;
        private System.Windows.Forms.Button ButtonReport;
        private System.Windows.Forms.ComboBox ComboBoxSemesters;
    }
}