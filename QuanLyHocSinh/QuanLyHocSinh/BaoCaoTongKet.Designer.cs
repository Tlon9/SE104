
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
            this.tổngKếtMônHọcKìToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tổngKếtMônNămHọcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tổngKếtHọcKìToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tổngKếtNămHọcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.ComboBoxSubjects = new System.Windows.Forms.ComboBox();
            this.ComboBoxYears = new System.Windows.Forms.ComboBox();
            this.ComboBoxSemesters = new System.Windows.Forms.ComboBox();
            this.ButtonReport = new System.Windows.Forms.Button();
            this.PanelTitle.SuspendLayout();
            this.MenuReport.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelTitle
            // 
            this.PanelTitle.Controls.Add(this.LabelNameProject);
            this.PanelTitle.Location = new System.Drawing.Point(12, 12);
            this.PanelTitle.Name = "PanelTitle";
            this.PanelTitle.Size = new System.Drawing.Size(1051, 132);
            this.PanelTitle.TabIndex = 0;
            // 
            // LabelNameProject
            // 
            this.LabelNameProject.AutoSize = true;
            this.LabelNameProject.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelNameProject.Location = new System.Drawing.Point(425, 28);
            this.LabelNameProject.Name = "LabelNameProject";
            this.LabelNameProject.Size = new System.Drawing.Size(378, 46);
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
            this.MenuReport.Location = new System.Drawing.Point(21, 147);
            this.MenuReport.Name = "MenuReport";
            this.MenuReport.Size = new System.Drawing.Size(608, 28);
            this.MenuReport.TabIndex = 1;
            this.MenuReport.Text = "menuStrip1";
            // 
            // tổngKếtMônHọcKìToolStripMenuItem
            // 
            this.tổngKếtMônHọcKìToolStripMenuItem.Name = "tổngKếtMônHọcKìToolStripMenuItem";
            this.tổngKếtMônHọcKìToolStripMenuItem.Size = new System.Drawing.Size(158, 24);
            this.tổngKếtMônHọcKìToolStripMenuItem.Text = "Tổng kết môn học kì";
            // 
            // tổngKếtMônNămHọcToolStripMenuItem
            // 
            this.tổngKếtMônNămHọcToolStripMenuItem.Name = "tổngKếtMônNămHọcToolStripMenuItem";
            this.tổngKếtMônNămHọcToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.tổngKếtMônNămHọcToolStripMenuItem.Text = "Tổng kết môn năm học";
            this.tổngKếtMônNămHọcToolStripMenuItem.Click += new System.EventHandler(this.tổngKếtMônNămHọcToolStripMenuItem_Click);
            // 
            // tổngKếtHọcKìToolStripMenuItem
            // 
            this.tổngKếtHọcKìToolStripMenuItem.Name = "tổngKếtHọcKìToolStripMenuItem";
            this.tổngKếtHọcKìToolStripMenuItem.Size = new System.Drawing.Size(124, 24);
            this.tổngKếtHọcKìToolStripMenuItem.Text = "Tổng kết học kì";
            // 
            // tổngKếtNămHọcToolStripMenuItem
            // 
            this.tổngKếtNămHọcToolStripMenuItem.Name = "tổngKếtNămHọcToolStripMenuItem";
            this.tổngKếtNămHọcToolStripMenuItem.Size = new System.Drawing.Size(142, 24);
            this.tổngKếtNămHọcToolStripMenuItem.Text = "Tổng kết năm học";
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.ButtonReport);
            this.Panel1.Controls.Add(this.ComboBoxSemesters);
            this.Panel1.Controls.Add(this.ComboBoxYears);
            this.Panel1.Controls.Add(this.ComboBoxSubjects);
            this.Panel1.Location = new System.Drawing.Point(21, 178);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(654, 57);
            this.Panel1.TabIndex = 2;
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
            this.ComboBoxSubjects.Location = new System.Drawing.Point(3, 19);
            this.ComboBoxSubjects.Name = "ComboBoxSubjects";
            this.ComboBoxSubjects.Size = new System.Drawing.Size(139, 24);
            this.ComboBoxSubjects.TabIndex = 0;
            this.ComboBoxSubjects.Text = "Môn học";
            this.ComboBoxSubjects.SelectedValueChanged += new System.EventHandler(this.ComboBoxSubjects_SelectedValueChanged);
            // 
            // ComboBoxYears
            // 
            this.ComboBoxYears.FormattingEnabled = true;
            this.ComboBoxYears.Items.AddRange(new object[] {
            "2021-2022",
            "2022-2023",
            "2023-2024"});
            this.ComboBoxYears.Location = new System.Drawing.Point(166, 19);
            this.ComboBoxYears.Name = "ComboBoxYears";
            this.ComboBoxYears.Size = new System.Drawing.Size(148, 24);
            this.ComboBoxYears.TabIndex = 1;
            this.ComboBoxYears.Text = "Năm học";
            // 
            // ComboBoxSemesters
            // 
            this.ComboBoxSemesters.FormattingEnabled = true;
            this.ComboBoxSemesters.Items.AddRange(new object[] {
            "1",
            "2"});
            this.ComboBoxSemesters.Location = new System.Drawing.Point(337, 19);
            this.ComboBoxSemesters.Name = "ComboBoxSemesters";
            this.ComboBoxSemesters.Size = new System.Drawing.Size(121, 24);
            this.ComboBoxSemesters.TabIndex = 2;
            this.ComboBoxSemesters.Text = "Học kì";
            // 
            // ButtonReport
            // 
            this.ButtonReport.Location = new System.Drawing.Point(492, 20);
            this.ButtonReport.Name = "ButtonReport";
            this.ButtonReport.Size = new System.Drawing.Size(75, 23);
            this.ButtonReport.TabIndex = 3;
            this.ButtonReport.Text = "Xuất";
            this.ButtonReport.UseVisualStyleBackColor = true;
            // 
            // BaoCaoTongKet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1335, 666);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.PanelTitle);
            this.Controls.Add(this.MenuReport);
            this.MainMenuStrip = this.MenuReport;
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