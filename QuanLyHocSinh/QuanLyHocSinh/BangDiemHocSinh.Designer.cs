namespace QuanLyHocSinh
{
    partial class BangDiemHocSinh
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
            this.TraCuuHKButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.HocKyCbb = new System.Windows.Forms.ComboBox();
            this.NamHocCbb = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.HoTenTextBox = new System.Windows.Forms.TextBox();
            this.LopTextBox = new System.Windows.Forms.TextBox();
            this.DTBHKTextBox = new System.Windows.Forms.TextBox();
            this.XepLoaiTextBox = new System.Windows.Forms.TextBox();
            this.PanelDHK = new System.Windows.Forms.Panel();
            this.panelDNH = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.TraCuuNHButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.PanelDHK.SuspendLayout();
            this.panelDNH.SuspendLayout();
            this.SuspendLayout();
            // 
            // TraCuuHKButton
            // 
            this.TraCuuHKButton.Location = new System.Drawing.Point(878, 36);
            this.TraCuuHKButton.Name = "TraCuuHKButton";
            this.TraCuuHKButton.Size = new System.Drawing.Size(123, 22);
            this.TraCuuHKButton.TabIndex = 0;
            this.TraCuuHKButton.Text = "Tra cứu điểm học kỳ";
            this.TraCuuHKButton.UseVisualStyleBackColor = true;
            this.TraCuuHKButton.Click += new System.EventHandler(this.TraCuuButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(415, 36);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(196, 20);
            this.textBox1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(40, 264);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1329, 373);
            this.dataGridView1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(372, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tra cứu bảng điểm học sinh";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(412, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mã số học sinh";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(632, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Học kỳ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(755, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Năm học";
            // 
            // HocKyCbb
            // 
            this.HocKyCbb.FormattingEnabled = true;
            this.HocKyCbb.Items.AddRange(new object[] {
            "1",
            "2"});
            this.HocKyCbb.Location = new System.Drawing.Point(635, 36);
            this.HocKyCbb.Name = "HocKyCbb";
            this.HocKyCbb.Size = new System.Drawing.Size(85, 21);
            this.HocKyCbb.TabIndex = 9;
            // 
            // NamHocCbb
            // 
            this.NamHocCbb.FormattingEnabled = true;
            this.NamHocCbb.Items.AddRange(new object[] {
            "2021-2022",
            "2022-2023",
            "2023-2024"});
            this.NamHocCbb.Location = new System.Drawing.Point(758, 38);
            this.NamHocCbb.Name = "NamHocCbb";
            this.NamHocCbb.Size = new System.Drawing.Size(85, 21);
            this.NamHocCbb.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(117, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Họ và tên";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(162, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Lớp";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(28, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(162, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Điểm trung bình học kỳ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(126, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 16);
            this.label8.TabIndex = 14;
            this.label8.Text = "Xếp loại";
            // 
            // HoTenTextBox
            // 
            this.HoTenTextBox.Location = new System.Drawing.Point(216, 0);
            this.HoTenTextBox.Name = "HoTenTextBox";
            this.HoTenTextBox.Size = new System.Drawing.Size(125, 20);
            this.HoTenTextBox.TabIndex = 15;
            // 
            // LopTextBox
            // 
            this.LopTextBox.Location = new System.Drawing.Point(216, 32);
            this.LopTextBox.Name = "LopTextBox";
            this.LopTextBox.Size = new System.Drawing.Size(125, 20);
            this.LopTextBox.TabIndex = 16;
            // 
            // DTBHKTextBox
            // 
            this.DTBHKTextBox.Location = new System.Drawing.Point(216, 68);
            this.DTBHKTextBox.Name = "DTBHKTextBox";
            this.DTBHKTextBox.Size = new System.Drawing.Size(100, 20);
            this.DTBHKTextBox.TabIndex = 17;
            // 
            // XepLoaiTextBox
            // 
            this.XepLoaiTextBox.Location = new System.Drawing.Point(216, 105);
            this.XepLoaiTextBox.Name = "XepLoaiTextBox";
            this.XepLoaiTextBox.Size = new System.Drawing.Size(100, 20);
            this.XepLoaiTextBox.TabIndex = 18;
            // 
            // PanelDHK
            // 
            this.PanelDHK.Controls.Add(this.XepLoaiTextBox);
            this.PanelDHK.Controls.Add(this.DTBHKTextBox);
            this.PanelDHK.Controls.Add(this.LopTextBox);
            this.PanelDHK.Controls.Add(this.HoTenTextBox);
            this.PanelDHK.Controls.Add(this.label8);
            this.PanelDHK.Controls.Add(this.label7);
            this.PanelDHK.Controls.Add(this.label6);
            this.PanelDHK.Controls.Add(this.label5);
            this.PanelDHK.Location = new System.Drawing.Point(170, 87);
            this.PanelDHK.Name = "PanelDHK";
            this.PanelDHK.Size = new System.Drawing.Size(533, 144);
            this.PanelDHK.TabIndex = 19;
            // 
            // panelDNH
            // 
            this.panelDNH.Controls.Add(this.textBox2);
            this.panelDNH.Controls.Add(this.textBox3);
            this.panelDNH.Controls.Add(this.textBox4);
            this.panelDNH.Controls.Add(this.textBox5);
            this.panelDNH.Controls.Add(this.label9);
            this.panelDNH.Controls.Add(this.label10);
            this.panelDNH.Controls.Add(this.label11);
            this.panelDNH.Controls.Add(this.label12);
            this.panelDNH.Location = new System.Drawing.Point(170, 87);
            this.panelDNH.Name = "panelDNH";
            this.panelDNH.Size = new System.Drawing.Size(533, 144);
            this.panelDNH.TabIndex = 20;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(216, 105);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 18;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(216, 68);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 17;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(216, 32);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(125, 20);
            this.textBox4.TabIndex = 16;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(216, 6);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(125, 20);
            this.textBox5.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(126, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 16);
            this.label9.TabIndex = 14;
            this.label9.Text = "Xếp loại";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(28, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(175, 16);
            this.label10.TabIndex = 13;
            this.label10.Text = "Điểm trung bình năm học";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(162, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Lớp";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(117, 4);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 16);
            this.label12.TabIndex = 11;
            this.label12.Text = "Họ và tên";
            // 
            // TraCuuNHButton
            // 
            this.TraCuuNHButton.Location = new System.Drawing.Point(1024, 37);
            this.TraCuuNHButton.Name = "TraCuuNHButton";
            this.TraCuuNHButton.Size = new System.Drawing.Size(140, 22);
            this.TraCuuNHButton.TabIndex = 21;
            this.TraCuuNHButton.Text = "Tra cứu điểm năm học";
            this.TraCuuNHButton.UseVisualStyleBackColor = true;
            this.TraCuuNHButton.Click += new System.EventHandler(this.TraCuuNHButton_Click);
            // 
            // BangDiemHocSinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1421, 666);
            this.Controls.Add(this.TraCuuNHButton);
            this.Controls.Add(this.panelDNH);
            this.Controls.Add(this.PanelDHK);
            this.Controls.Add(this.NamHocCbb);
            this.Controls.Add(this.HocKyCbb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.TraCuuHKButton);
            this.Name = "BangDiemHocSinh";
            this.Text = "BangDiemHocSinh";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.PanelDHK.ResumeLayout(false);
            this.PanelDHK.PerformLayout();
            this.panelDNH.ResumeLayout(false);
            this.panelDNH.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button TraCuuHKButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox HocKyCbb;
        private System.Windows.Forms.ComboBox NamHocCbb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox HoTenTextBox;
        private System.Windows.Forms.TextBox LopTextBox;
        private System.Windows.Forms.TextBox DTBHKTextBox;
        private System.Windows.Forms.TextBox XepLoaiTextBox;
        private System.Windows.Forms.Panel PanelDHK;
        private System.Windows.Forms.Panel panelDNH;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button TraCuuNHButton;
    }
}