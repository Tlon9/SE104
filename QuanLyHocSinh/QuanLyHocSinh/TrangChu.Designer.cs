
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
            this.MenuItemFinalReport = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelTitle.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelNameProject
            // 
            this.LabelNameProject.AutoSize = true;
            this.LabelNameProject.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelNameProject.Location = new System.Drawing.Point(34, 19);
            this.LabelNameProject.Name = "LabelNameProject";
            this.LabelNameProject.Size = new System.Drawing.Size(561, 68);
            this.LabelNameProject.TabIndex = 0;
            this.LabelNameProject.Text = "QUẢN LÍ HỌC SINH";
            // 
            // PanelTitle
            // 
            this.PanelTitle.Controls.Add(this.LabelNameProject);
            this.PanelTitle.Location = new System.Drawing.Point(8, 9);
            this.PanelTitle.Name = "PanelTitle";
            this.PanelTitle.Size = new System.Drawing.Size(747, 107);
            this.PanelTitle.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemHome,
            this.MenuItemFinalReport});
            this.menuStrip1.Location = new System.Drawing.Point(8, 135);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(385, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuItemHome
            // 
            this.MenuItemHome.Name = "MenuItemHome";
            this.MenuItemHome.Size = new System.Drawing.Size(91, 24);
            this.MenuItemHome.Text = "Trang chủ ";
            // 
            // MenuItemFinalReport
            // 
            this.MenuItemFinalReport.Name = "MenuItemFinalReport";
            this.MenuItemFinalReport.Size = new System.Drawing.Size(136, 24);
            this.MenuItemFinalReport.Text = "Báo cáo tổng kết";
            this.MenuItemFinalReport.Click += new System.EventHandler(this.MenuItemFinalReport_Click);
            // 
            // TrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PanelTitle);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
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
    }
}