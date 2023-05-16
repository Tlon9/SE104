namespace QuanLyHocSinh
{

    partial class LapBangDiemMonHoc
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
            this.labelSemester = new System.Windows.Forms.Label();
            this.labelClass = new System.Windows.Forms.Label();
            this.labelYear = new System.Windows.Forms.Label();
            this.labelSubject = new System.Windows.Forms.Label();
            this.comboBoxSemester = new System.Windows.Forms.ComboBox();
            this.comboBoxSubject = new System.Windows.Forms.ComboBox();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.buttonInput = new System.Windows.Forms.Button();
            this.panelInput = new System.Windows.Forms.Panel();
            this.textBoxScore_3 = new System.Windows.Forms.TextBox();
            this.textBoxScore_2 = new System.Windows.Forms.TextBox();
            this.textBoxScore_1 = new System.Windows.Forms.TextBox();
            this.comboBoxID = new System.Windows.Forms.ComboBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonLook = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBoxAverageScore = new System.Windows.Forms.TextBox();
            this.textBoxClassify = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelClassify = new System.Windows.Forms.Label();
            this.labelAverageScore = new System.Windows.Forms.Label();
            this.labelScore_3 = new System.Windows.Forms.Label();
            this.labelScore_2 = new System.Windows.Forms.Label();
            this.labelScore_1 = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.panelPrint = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.textBoxRatioOfPoor = new System.Windows.Forms.TextBox();
            this.textBoxRatioOfB_Average = new System.Windows.Forms.TextBox();
            this.textBoxRatioOfAverage = new System.Windows.Forms.TextBox();
            this.textBoxRatioOfGood = new System.Windows.Forms.TextBox();
            this.labelRatioOfPoor = new System.Windows.Forms.Label();
            this.labelRatioOfB_Average = new System.Windows.Forms.Label();
            this.labelRatioOfAverage = new System.Windows.Forms.Label();
            this.labelRatioOfGood = new System.Windows.Forms.Label();
            this.textBoxNumberOfPoor = new System.Windows.Forms.TextBox();
            this.textBoxNumberOfB_Average = new System.Windows.Forms.TextBox();
            this.textBoxNumberOfAverage = new System.Windows.Forms.TextBox();
            this.textBoxNumberOfGood = new System.Windows.Forms.TextBox();
            this.labelNumberOfPoor = new System.Windows.Forms.Label();
            this.labelNumberOfB_Average = new System.Windows.Forms.Label();
            this.labelNumberOfAverage = new System.Windows.Forms.Label();
            this.labelNumberOfGood = new System.Windows.Forms.Label();
            this.textBoxRatioOfExcellent = new System.Windows.Forms.TextBox();
            this.textBoxNumberOfExcellent = new System.Windows.Forms.TextBox();
            this.labelRatioOfExcellent = new System.Windows.Forms.Label();
            this.labelNumberOfExcellent = new System.Windows.Forms.Label();
            this.comboBoxYear = new System.Windows.Forms.ComboBox();
            this.comboBoxClass = new System.Windows.Forms.ComboBox();
            this.panelInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelPrint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // labelSemester
            // 
            this.labelSemester.AutoSize = true;
            this.labelSemester.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSemester.Location = new System.Drawing.Point(81, 79);
            this.labelSemester.Name = "labelSemester";
            this.labelSemester.Size = new System.Drawing.Size(55, 18);
            this.labelSemester.TabIndex = 1;
            this.labelSemester.Text = "Học kỳ";
            // 
            // labelClass
            // 
            this.labelClass.AutoSize = true;
            this.labelClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClass.Location = new System.Drawing.Point(100, 30);
            this.labelClass.Name = "labelClass";
            this.labelClass.Size = new System.Drawing.Size(33, 18);
            this.labelClass.TabIndex = 3;
            this.labelClass.Text = "Lớp";
            // 
            // labelYear
            // 
            this.labelYear.AutoSize = true;
            this.labelYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelYear.Location = new System.Drawing.Point(448, 79);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(69, 18);
            this.labelYear.TabIndex = 4;
            this.labelYear.Text = "Năm học";
            // 
            // labelSubject
            // 
            this.labelSubject.AutoSize = true;
            this.labelSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubject.Location = new System.Drawing.Point(448, 30);
            this.labelSubject.Name = "labelSubject";
            this.labelSubject.Size = new System.Drawing.Size(67, 18);
            this.labelSubject.TabIndex = 12;
            this.labelSubject.Text = "Môn học";
            // 
            // comboBoxSemester
            // 
            this.comboBoxSemester.FormattingEnabled = true;
            this.comboBoxSemester.Items.AddRange(new object[] {
            "1",
            "2"});
            this.comboBoxSemester.Location = new System.Drawing.Point(159, 76);
            this.comboBoxSemester.Name = "comboBoxSemester";
            this.comboBoxSemester.Size = new System.Drawing.Size(231, 24);
            this.comboBoxSemester.TabIndex = 30;
            // 
            // comboBoxSubject
            // 
            this.comboBoxSubject.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.comboBoxSubject.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxSubject.DisplayMember = "TenLop";
            this.comboBoxSubject.FormattingEnabled = true;
            this.comboBoxSubject.ImeMode = System.Windows.Forms.ImeMode.On;
            this.comboBoxSubject.Location = new System.Drawing.Point(529, 24);
            this.comboBoxSubject.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxSubject.MaxDropDownItems = 4;
            this.comboBoxSubject.Name = "comboBoxSubject";
            this.comboBoxSubject.Size = new System.Drawing.Size(231, 24);
            this.comboBoxSubject.TabIndex = 0;
            this.comboBoxSubject.Tag = "";
            this.comboBoxSubject.ValueMember = "MaLop";
            // 
            // buttonPrint
            // 
            this.buttonPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPrint.Location = new System.Drawing.Point(444, 140);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(130, 44);
            this.buttonPrint.TabIndex = 47;
            this.buttonPrint.Text = "Xuất";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // buttonInput
            // 
            this.buttonInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInput.Location = new System.Drawing.Point(317, 140);
            this.buttonInput.Name = "buttonInput";
            this.buttonInput.Size = new System.Drawing.Size(130, 44);
            this.buttonInput.TabIndex = 48;
            this.buttonInput.Text = "Nhập";
            this.buttonInput.UseVisualStyleBackColor = true;
            this.buttonInput.Click += new System.EventHandler(this.buttonInput_Click);
            // 
            // panelInput
            // 
            this.panelInput.Controls.Add(this.textBoxScore_3);
            this.panelInput.Controls.Add(this.textBoxScore_2);
            this.panelInput.Controls.Add(this.textBoxScore_1);
            this.panelInput.Controls.Add(this.comboBoxID);
            this.panelInput.Controls.Add(this.buttonDelete);
            this.panelInput.Controls.Add(this.buttonLook);
            this.panelInput.Controls.Add(this.dataGridView1);
            this.panelInput.Controls.Add(this.textBoxAverageScore);
            this.panelInput.Controls.Add(this.textBoxClassify);
            this.panelInput.Controls.Add(this.textBoxName);
            this.panelInput.Controls.Add(this.labelClassify);
            this.panelInput.Controls.Add(this.labelAverageScore);
            this.panelInput.Controls.Add(this.labelScore_3);
            this.panelInput.Controls.Add(this.labelScore_2);
            this.panelInput.Controls.Add(this.labelScore_1);
            this.panelInput.Controls.Add(this.labelName);
            this.panelInput.Controls.Add(this.labelID);
            this.panelInput.Controls.Add(this.buttonSave);
            this.panelInput.Location = new System.Drawing.Point(84, 203);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(1167, 307);
            this.panelInput.TabIndex = 49;
            // 
            // textBoxScore_3
            // 
            this.textBoxScore_3.Location = new System.Drawing.Point(692, 51);
            this.textBoxScore_3.Name = "textBoxScore_3";
            this.textBoxScore_3.Size = new System.Drawing.Size(100, 22);
            this.textBoxScore_3.TabIndex = 128;
            this.textBoxScore_3.TextChanged += new System.EventHandler(this.textBoxScore_3_TextChanged);
            // 
            // textBoxScore_2
            // 
            this.textBoxScore_2.Location = new System.Drawing.Point(567, 51);
            this.textBoxScore_2.Name = "textBoxScore_2";
            this.textBoxScore_2.Size = new System.Drawing.Size(100, 22);
            this.textBoxScore_2.TabIndex = 127;
            this.textBoxScore_2.TextChanged += new System.EventHandler(this.textBoxScore_2_TextChanged);
            // 
            // textBoxScore_1
            // 
            this.textBoxScore_1.Location = new System.Drawing.Point(445, 51);
            this.textBoxScore_1.Name = "textBoxScore_1";
            this.textBoxScore_1.Size = new System.Drawing.Size(100, 22);
            this.textBoxScore_1.TabIndex = 126;
            this.textBoxScore_1.TextChanged += new System.EventHandler(this.textBoxScore_1_TextChanged);
            // 
            // comboBoxID
            // 
            this.comboBoxID.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.comboBoxID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxID.FormattingEnabled = true;
            this.comboBoxID.ImeMode = System.Windows.Forms.ImeMode.On;
            this.comboBoxID.Location = new System.Drawing.Point(3, 49);
            this.comboBoxID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxID.MaxDropDownItems = 4;
            this.comboBoxID.Name = "comboBoxID";
            this.comboBoxID.Size = new System.Drawing.Size(183, 26);
            this.comboBoxID.TabIndex = 53;
            this.comboBoxID.Tag = "";
            this.comboBoxID.SelectedValueChanged += new System.EventHandler(this.comboBoxID_SelectedValueChanged);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.Location = new System.Drawing.Point(1060, 172);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(94, 44);
            this.buttonDelete.TabIndex = 125;
            this.buttonDelete.Text = "Xóa";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonLook
            // 
            this.buttonLook.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLook.Location = new System.Drawing.Point(1060, 102);
            this.buttonLook.Name = "buttonLook";
            this.buttonLook.Size = new System.Drawing.Size(94, 44);
            this.buttonLook.TabIndex = 124;
            this.buttonLook.Text = "Xem";
            this.buttonLook.UseVisualStyleBackColor = true;
            this.buttonLook.Click += new System.EventHandler(this.buttonLook_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 102);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(921, 189);
            this.dataGridView1.TabIndex = 123;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // textBoxAverageScore
            // 
            this.textBoxAverageScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAverageScore.Location = new System.Drawing.Point(817, 47);
            this.textBoxAverageScore.Name = "textBoxAverageScore";
            this.textBoxAverageScore.ReadOnly = true;
            this.textBoxAverageScore.Size = new System.Drawing.Size(104, 24);
            this.textBoxAverageScore.TabIndex = 122;
            // 
            // textBoxClassify
            // 
            this.textBoxClassify.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxClassify.Location = new System.Drawing.Point(937, 47);
            this.textBoxClassify.Name = "textBoxClassify";
            this.textBoxClassify.ReadOnly = true;
            this.textBoxClassify.Size = new System.Drawing.Size(104, 24);
            this.textBoxClassify.TabIndex = 66;
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxName.Location = new System.Drawing.Point(201, 49);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(183, 24);
            this.textBoxName.TabIndex = 56;
            // 
            // labelClassify
            // 
            this.labelClassify.AutoSize = true;
            this.labelClassify.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClassify.Location = new System.Drawing.Point(964, 19);
            this.labelClassify.Name = "labelClassify";
            this.labelClassify.Size = new System.Drawing.Size(61, 18);
            this.labelClassify.TabIndex = 54;
            this.labelClassify.Text = "Xếp loại";
            // 
            // labelAverageScore
            // 
            this.labelAverageScore.AutoSize = true;
            this.labelAverageScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAverageScore.Location = new System.Drawing.Point(834, 19);
            this.labelAverageScore.Name = "labelAverageScore";
            this.labelAverageScore.Size = new System.Drawing.Size(66, 18);
            this.labelAverageScore.TabIndex = 53;
            this.labelAverageScore.Text = "Điểm TB";
            // 
            // labelScore_3
            // 
            this.labelScore_3.AutoSize = true;
            this.labelScore_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScore_3.Location = new System.Drawing.Point(708, 19);
            this.labelScore_3.Name = "labelScore_3";
            this.labelScore_3.Size = new System.Drawing.Size(68, 18);
            this.labelScore_3.TabIndex = 52;
            this.labelScore_3.Text = "Điểm CK";
            // 
            // labelScore_2
            // 
            this.labelScore_2.AutoSize = true;
            this.labelScore_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScore_2.Location = new System.Drawing.Point(587, 19);
            this.labelScore_2.Name = "labelScore_2";
            this.labelScore_2.Size = new System.Drawing.Size(69, 18);
            this.labelScore_2.TabIndex = 51;
            this.labelScore_2.Text = "Điểm GK";
            // 
            // labelScore_1
            // 
            this.labelScore_1.AutoSize = true;
            this.labelScore_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScore_1.Location = new System.Drawing.Point(464, 19);
            this.labelScore_1.Name = "labelScore_1";
            this.labelScore_1.Size = new System.Drawing.Size(66, 18);
            this.labelScore_1.TabIndex = 50;
            this.labelScore_1.Text = "Điểm TX";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(272, 19);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(52, 18);
            this.labelName.TabIndex = 49;
            this.labelName.Text = "Họ tên";
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelID.Location = new System.Drawing.Point(61, 19);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(89, 18);
            this.labelID.TabIndex = 48;
            this.labelID.Text = "Mã học sinh";
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.Location = new System.Drawing.Point(1060, 27);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(94, 44);
            this.buttonSave.TabIndex = 47;
            this.buttonSave.Text = "Lưu";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // panelPrint
            // 
            this.panelPrint.Controls.Add(this.dataGridView2);
            this.panelPrint.Controls.Add(this.textBoxRatioOfPoor);
            this.panelPrint.Controls.Add(this.textBoxRatioOfB_Average);
            this.panelPrint.Controls.Add(this.textBoxRatioOfAverage);
            this.panelPrint.Controls.Add(this.textBoxRatioOfGood);
            this.panelPrint.Controls.Add(this.labelRatioOfPoor);
            this.panelPrint.Controls.Add(this.labelRatioOfB_Average);
            this.panelPrint.Controls.Add(this.labelRatioOfAverage);
            this.panelPrint.Controls.Add(this.labelRatioOfGood);
            this.panelPrint.Controls.Add(this.textBoxNumberOfPoor);
            this.panelPrint.Controls.Add(this.textBoxNumberOfB_Average);
            this.panelPrint.Controls.Add(this.textBoxNumberOfAverage);
            this.panelPrint.Controls.Add(this.textBoxNumberOfGood);
            this.panelPrint.Controls.Add(this.labelNumberOfPoor);
            this.panelPrint.Controls.Add(this.labelNumberOfB_Average);
            this.panelPrint.Controls.Add(this.labelNumberOfAverage);
            this.panelPrint.Controls.Add(this.labelNumberOfGood);
            this.panelPrint.Controls.Add(this.textBoxRatioOfExcellent);
            this.panelPrint.Controls.Add(this.textBoxNumberOfExcellent);
            this.panelPrint.Controls.Add(this.labelRatioOfExcellent);
            this.panelPrint.Controls.Add(this.labelNumberOfExcellent);
            this.panelPrint.Location = new System.Drawing.Point(81, 203);
            this.panelPrint.Name = "panelPrint";
            this.panelPrint.Size = new System.Drawing.Size(1167, 455);
            this.panelPrint.TabIndex = 50;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToOrderColumns = true;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(98, 263);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(871, 189);
            this.dataGridView2.TabIndex = 124;
            // 
            // textBoxRatioOfPoor
            // 
            this.textBoxRatioOfPoor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRatioOfPoor.Location = new System.Drawing.Point(632, 218);
            this.textBoxRatioOfPoor.Name = "textBoxRatioOfPoor";
            this.textBoxRatioOfPoor.ReadOnly = true;
            this.textBoxRatioOfPoor.Size = new System.Drawing.Size(231, 24);
            this.textBoxRatioOfPoor.TabIndex = 108;
            // 
            // textBoxRatioOfB_Average
            // 
            this.textBoxRatioOfB_Average.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRatioOfB_Average.Location = new System.Drawing.Point(632, 165);
            this.textBoxRatioOfB_Average.Name = "textBoxRatioOfB_Average";
            this.textBoxRatioOfB_Average.ReadOnly = true;
            this.textBoxRatioOfB_Average.Size = new System.Drawing.Size(231, 24);
            this.textBoxRatioOfB_Average.TabIndex = 107;
            // 
            // textBoxRatioOfAverage
            // 
            this.textBoxRatioOfAverage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRatioOfAverage.Location = new System.Drawing.Point(632, 116);
            this.textBoxRatioOfAverage.Name = "textBoxRatioOfAverage";
            this.textBoxRatioOfAverage.ReadOnly = true;
            this.textBoxRatioOfAverage.Size = new System.Drawing.Size(231, 24);
            this.textBoxRatioOfAverage.TabIndex = 106;
            // 
            // textBoxRatioOfGood
            // 
            this.textBoxRatioOfGood.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRatioOfGood.Location = new System.Drawing.Point(632, 68);
            this.textBoxRatioOfGood.Name = "textBoxRatioOfGood";
            this.textBoxRatioOfGood.ReadOnly = true;
            this.textBoxRatioOfGood.Size = new System.Drawing.Size(231, 24);
            this.textBoxRatioOfGood.TabIndex = 105;
            // 
            // labelRatioOfPoor
            // 
            this.labelRatioOfPoor.AutoSize = true;
            this.labelRatioOfPoor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRatioOfPoor.Location = new System.Drawing.Point(551, 221);
            this.labelRatioOfPoor.Name = "labelRatioOfPoor";
            this.labelRatioOfPoor.Size = new System.Drawing.Size(35, 18);
            this.labelRatioOfPoor.TabIndex = 104;
            this.labelRatioOfPoor.Text = "Tỉ lệ";
            // 
            // labelRatioOfB_Average
            // 
            this.labelRatioOfB_Average.AutoSize = true;
            this.labelRatioOfB_Average.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRatioOfB_Average.Location = new System.Drawing.Point(551, 171);
            this.labelRatioOfB_Average.Name = "labelRatioOfB_Average";
            this.labelRatioOfB_Average.Size = new System.Drawing.Size(35, 18);
            this.labelRatioOfB_Average.TabIndex = 103;
            this.labelRatioOfB_Average.Text = "Tỉ lệ";
            // 
            // labelRatioOfAverage
            // 
            this.labelRatioOfAverage.AutoSize = true;
            this.labelRatioOfAverage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRatioOfAverage.Location = new System.Drawing.Point(551, 122);
            this.labelRatioOfAverage.Name = "labelRatioOfAverage";
            this.labelRatioOfAverage.Size = new System.Drawing.Size(35, 18);
            this.labelRatioOfAverage.TabIndex = 102;
            this.labelRatioOfAverage.Text = "Tỉ lệ";
            // 
            // labelRatioOfGood
            // 
            this.labelRatioOfGood.AutoSize = true;
            this.labelRatioOfGood.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRatioOfGood.Location = new System.Drawing.Point(551, 71);
            this.labelRatioOfGood.Name = "labelRatioOfGood";
            this.labelRatioOfGood.Size = new System.Drawing.Size(35, 18);
            this.labelRatioOfGood.TabIndex = 101;
            this.labelRatioOfGood.Text = "Tỉ lệ";
            // 
            // textBoxNumberOfPoor
            // 
            this.textBoxNumberOfPoor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNumberOfPoor.Location = new System.Drawing.Point(262, 215);
            this.textBoxNumberOfPoor.Name = "textBoxNumberOfPoor";
            this.textBoxNumberOfPoor.ReadOnly = true;
            this.textBoxNumberOfPoor.Size = new System.Drawing.Size(231, 24);
            this.textBoxNumberOfPoor.TabIndex = 100;
            // 
            // textBoxNumberOfB_Average
            // 
            this.textBoxNumberOfB_Average.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNumberOfB_Average.Location = new System.Drawing.Point(262, 165);
            this.textBoxNumberOfB_Average.Name = "textBoxNumberOfB_Average";
            this.textBoxNumberOfB_Average.ReadOnly = true;
            this.textBoxNumberOfB_Average.Size = new System.Drawing.Size(231, 24);
            this.textBoxNumberOfB_Average.TabIndex = 99;
            // 
            // textBoxNumberOfAverage
            // 
            this.textBoxNumberOfAverage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNumberOfAverage.Location = new System.Drawing.Point(262, 116);
            this.textBoxNumberOfAverage.Name = "textBoxNumberOfAverage";
            this.textBoxNumberOfAverage.ReadOnly = true;
            this.textBoxNumberOfAverage.Size = new System.Drawing.Size(231, 24);
            this.textBoxNumberOfAverage.TabIndex = 98;
            // 
            // textBoxNumberOfGood
            // 
            this.textBoxNumberOfGood.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNumberOfGood.Location = new System.Drawing.Point(262, 65);
            this.textBoxNumberOfGood.Name = "textBoxNumberOfGood";
            this.textBoxNumberOfGood.ReadOnly = true;
            this.textBoxNumberOfGood.Size = new System.Drawing.Size(231, 24);
            this.textBoxNumberOfGood.TabIndex = 97;
            // 
            // labelNumberOfPoor
            // 
            this.labelNumberOfPoor.AutoSize = true;
            this.labelNumberOfPoor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumberOfPoor.Location = new System.Drawing.Point(126, 221);
            this.labelNumberOfPoor.Name = "labelNumberOfPoor";
            this.labelNumberOfPoor.Size = new System.Drawing.Size(125, 18);
            this.labelNumberOfPoor.TabIndex = 96;
            this.labelNumberOfPoor.Text = "Số lượng HS kém";
            // 
            // labelNumberOfB_Average
            // 
            this.labelNumberOfB_Average.AutoSize = true;
            this.labelNumberOfB_Average.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumberOfB_Average.Location = new System.Drawing.Point(126, 171);
            this.labelNumberOfB_Average.Name = "labelNumberOfB_Average";
            this.labelNumberOfB_Average.Size = new System.Drawing.Size(119, 18);
            this.labelNumberOfB_Average.TabIndex = 95;
            this.labelNumberOfB_Average.Text = "Số lượng HS yếu";
            // 
            // labelNumberOfAverage
            // 
            this.labelNumberOfAverage.AutoSize = true;
            this.labelNumberOfAverage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumberOfAverage.Location = new System.Drawing.Point(126, 122);
            this.labelNumberOfAverage.Name = "labelNumberOfAverage";
            this.labelNumberOfAverage.Size = new System.Drawing.Size(115, 18);
            this.labelNumberOfAverage.TabIndex = 94;
            this.labelNumberOfAverage.Text = "Số lượng HS TB";
            // 
            // labelNumberOfGood
            // 
            this.labelNumberOfGood.AutoSize = true;
            this.labelNumberOfGood.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumberOfGood.Location = new System.Drawing.Point(126, 71);
            this.labelNumberOfGood.Name = "labelNumberOfGood";
            this.labelNumberOfGood.Size = new System.Drawing.Size(120, 18);
            this.labelNumberOfGood.TabIndex = 93;
            this.labelNumberOfGood.Text = "Số lượng HS khá";
            // 
            // textBoxRatioOfExcellent
            // 
            this.textBoxRatioOfExcellent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRatioOfExcellent.Location = new System.Drawing.Point(632, 13);
            this.textBoxRatioOfExcellent.Name = "textBoxRatioOfExcellent";
            this.textBoxRatioOfExcellent.ReadOnly = true;
            this.textBoxRatioOfExcellent.Size = new System.Drawing.Size(231, 24);
            this.textBoxRatioOfExcellent.TabIndex = 92;
            // 
            // textBoxNumberOfExcellent
            // 
            this.textBoxNumberOfExcellent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNumberOfExcellent.Location = new System.Drawing.Point(262, 13);
            this.textBoxNumberOfExcellent.Name = "textBoxNumberOfExcellent";
            this.textBoxNumberOfExcellent.ReadOnly = true;
            this.textBoxNumberOfExcellent.Size = new System.Drawing.Size(231, 24);
            this.textBoxNumberOfExcellent.TabIndex = 91;
            // 
            // labelRatioOfExcellent
            // 
            this.labelRatioOfExcellent.AutoSize = true;
            this.labelRatioOfExcellent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRatioOfExcellent.Location = new System.Drawing.Point(551, 19);
            this.labelRatioOfExcellent.Name = "labelRatioOfExcellent";
            this.labelRatioOfExcellent.Size = new System.Drawing.Size(35, 18);
            this.labelRatioOfExcellent.TabIndex = 90;
            this.labelRatioOfExcellent.Text = "Tỉ lệ";
            // 
            // labelNumberOfExcellent
            // 
            this.labelNumberOfExcellent.AutoSize = true;
            this.labelNumberOfExcellent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumberOfExcellent.Location = new System.Drawing.Point(126, 19);
            this.labelNumberOfExcellent.Name = "labelNumberOfExcellent";
            this.labelNumberOfExcellent.Size = new System.Drawing.Size(119, 18);
            this.labelNumberOfExcellent.TabIndex = 89;
            this.labelNumberOfExcellent.Text = "Số lượng HS giỏi";
            // 
            // comboBoxYear
            // 
            this.comboBoxYear.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxYear.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxYear.FormattingEnabled = true;
            this.comboBoxYear.Items.AddRange(new object[] {
            "2019-2020",
            "2020-2021",
            "2021-2022",
            "2022-2023"});
            this.comboBoxYear.Location = new System.Drawing.Point(529, 76);
            this.comboBoxYear.Name = "comboBoxYear";
            this.comboBoxYear.Size = new System.Drawing.Size(231, 24);
            this.comboBoxYear.TabIndex = 51;
            // 
            // comboBoxClass
            // 
            this.comboBoxClass.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.comboBoxClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxClass.FormattingEnabled = true;
            this.comboBoxClass.ImeMode = System.Windows.Forms.ImeMode.On;
            this.comboBoxClass.Location = new System.Drawing.Point(159, 27);
            this.comboBoxClass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxClass.MaxDropDownItems = 4;
            this.comboBoxClass.Name = "comboBoxClass";
            this.comboBoxClass.Size = new System.Drawing.Size(231, 24);
            this.comboBoxClass.TabIndex = 52;
            this.comboBoxClass.Tag = "";
            // 
            // LapBangDiemMonHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 997);
            this.Controls.Add(this.comboBoxClass);
            this.Controls.Add(this.comboBoxYear);
            this.Controls.Add(this.panelPrint);
            this.Controls.Add(this.panelInput);
            this.Controls.Add(this.buttonInput);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.comboBoxSubject);
            this.Controls.Add(this.comboBoxSemester);
            this.Controls.Add(this.labelSubject);
            this.Controls.Add(this.labelYear);
            this.Controls.Add(this.labelClass);
            this.Controls.Add(this.labelSemester);
            this.Name = "LapBangDiemMonHoc";
            this.Text = "NhapBangDiemMonHocLop/HK";
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelPrint.ResumeLayout(false);
            this.panelPrint.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSemester;
        private System.Windows.Forms.Label labelClass;
        private System.Windows.Forms.Label labelYear;
        private System.Windows.Forms.Label labelSubject;
        private System.Windows.Forms.ComboBox comboBoxSemester;
        private System.Windows.Forms.ComboBox comboBoxSubject;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Button buttonInput;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelClassify;
        private System.Windows.Forms.Label labelAverageScore;
        private System.Windows.Forms.Label labelScore_3;
        private System.Windows.Forms.Label labelScore_2;
        private System.Windows.Forms.Label labelScore_1;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Panel panelPrint;
        private System.Windows.Forms.TextBox textBoxRatioOfPoor;
        private System.Windows.Forms.TextBox textBoxRatioOfB_Average;
        private System.Windows.Forms.TextBox textBoxRatioOfAverage;
        private System.Windows.Forms.TextBox textBoxRatioOfGood;
        private System.Windows.Forms.Label labelRatioOfPoor;
        private System.Windows.Forms.Label labelRatioOfB_Average;
        private System.Windows.Forms.Label labelRatioOfAverage;
        private System.Windows.Forms.Label labelRatioOfGood;
        private System.Windows.Forms.TextBox textBoxNumberOfPoor;
        private System.Windows.Forms.TextBox textBoxNumberOfB_Average;
        private System.Windows.Forms.TextBox textBoxNumberOfAverage;
        private System.Windows.Forms.TextBox textBoxNumberOfGood;
        private System.Windows.Forms.Label labelNumberOfPoor;
        private System.Windows.Forms.Label labelNumberOfB_Average;
        private System.Windows.Forms.Label labelNumberOfAverage;
        private System.Windows.Forms.Label labelNumberOfGood;
        private System.Windows.Forms.TextBox textBoxRatioOfExcellent;
        private System.Windows.Forms.TextBox textBoxNumberOfExcellent;
        private System.Windows.Forms.Label labelRatioOfExcellent;
        private System.Windows.Forms.Label labelNumberOfExcellent;
        private System.Windows.Forms.TextBox textBoxClassify;
        private System.Windows.Forms.TextBox textBoxAverageScore;
        private System.Windows.Forms.ComboBox comboBoxYear;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonLook;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ComboBox comboBoxClass;
        private System.Windows.Forms.ComboBox comboBoxID;
        private System.Windows.Forms.TextBox textBoxScore_3;
        private System.Windows.Forms.TextBox textBoxScore_2;
        private System.Windows.Forms.TextBox textBoxScore_1;
    }
    
    /*partial class LapBangDiemMonHoc
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
    }*/
}

