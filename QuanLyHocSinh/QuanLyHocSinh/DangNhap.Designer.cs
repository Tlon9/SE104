
namespace QuanLyHocSinh
{
    partial class DangNhap
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DangNhap));
            this.panel3 = new System.Windows.Forms.Panel();
            this.LabelWrong = new System.Windows.Forms.Label();
            this.TextBoxUsername = new Guna.UI2.WinForms.Guna2TextBox();
            this.TextBoxPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.PanelForm = new Guna.UI2.WinForms.Guna2Panel();
            this.ButtonMinimize = new Guna.UI2.WinForms.Guna2ImageButton();
            this.ButtonClose = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.ButtonLogin = new Guna.UI2.WinForms.Guna2Button();
            this.PanelLogin = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.PanelForm.SuspendLayout();
            this.PanelLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Highlight;
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // LabelWrong
            // 
            resources.ApplyResources(this.LabelWrong, "LabelWrong");
            this.LabelWrong.ForeColor = System.Drawing.Color.Red;
            this.LabelWrong.Name = "LabelWrong";
            // 
            // TextBoxUsername
            // 
            this.TextBoxUsername.BorderRadius = 18;
            this.TextBoxUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBoxUsername.DefaultText = "";
            this.TextBoxUsername.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TextBoxUsername.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TextBoxUsername.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TextBoxUsername.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TextBoxUsername.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this.TextBoxUsername, "TextBoxUsername");
            this.TextBoxUsername.ForeColor = System.Drawing.Color.Black;
            this.TextBoxUsername.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TextBoxUsername.IconLeft = ((System.Drawing.Image)(resources.GetObject("TextBoxUsername.IconLeft")));
            this.TextBoxUsername.IconLeftSize = new System.Drawing.Size(30, 30);
            this.TextBoxUsername.Name = "TextBoxUsername";
            this.TextBoxUsername.PasswordChar = '\0';
            this.TextBoxUsername.PlaceholderText = "Tên đăng nhập";
            this.TextBoxUsername.SelectedText = "";
            // 
            // TextBoxPassword
            // 
            this.TextBoxPassword.BorderRadius = 18;
            this.TextBoxPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBoxPassword.DefaultText = "";
            this.TextBoxPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TextBoxPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TextBoxPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TextBoxPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TextBoxPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this.TextBoxPassword, "TextBoxPassword");
            this.TextBoxPassword.ForeColor = System.Drawing.Color.Black;
            this.TextBoxPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TextBoxPassword.IconLeft = ((System.Drawing.Image)(resources.GetObject("TextBoxPassword.IconLeft")));
            this.TextBoxPassword.IconLeftSize = new System.Drawing.Size(30, 30);
            this.TextBoxPassword.Name = "TextBoxPassword";
            this.TextBoxPassword.PasswordChar = '●';
            this.TextBoxPassword.PlaceholderText = "Mật khẩu";
            this.TextBoxPassword.SelectedText = "";
            this.TextBoxPassword.UseSystemPasswordChar = true;
            // 
            // PanelForm
            // 
            this.PanelForm.BackColor = System.Drawing.SystemColors.Highlight;
            this.PanelForm.Controls.Add(this.ButtonMinimize);
            this.PanelForm.Controls.Add(this.ButtonClose);
            resources.ApplyResources(this.PanelForm, "PanelForm");
            this.PanelForm.Name = "PanelForm";
            this.PanelForm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.guna2Panel1_MouseDown);
            // 
            // ButtonMinimize
            // 
            this.ButtonMinimize.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            resources.ApplyResources(this.ButtonMinimize, "ButtonMinimize");
            this.ButtonMinimize.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.ButtonMinimize.Image = ((System.Drawing.Image)(resources.GetObject("ButtonMinimize.Image")));
            this.ButtonMinimize.ImageOffset = new System.Drawing.Point(0, 0);
            this.ButtonMinimize.ImageRotate = 0F;
            this.ButtonMinimize.ImageSize = new System.Drawing.Size(30, 30);
            this.ButtonMinimize.Name = "ButtonMinimize";
            this.ButtonMinimize.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.ButtonMinimize.Click += new System.EventHandler(this.guna2ImageButton2_Click);
            // 
            // ButtonClose
            // 
            this.ButtonClose.BackColor = System.Drawing.SystemColors.Highlight;
            this.ButtonClose.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            resources.ApplyResources(this.ButtonClose, "ButtonClose");
            this.ButtonClose.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.ButtonClose.Image = ((System.Drawing.Image)(resources.GetObject("ButtonClose.Image")));
            this.ButtonClose.ImageOffset = new System.Drawing.Point(0, 0);
            this.ButtonClose.ImageRotate = 0F;
            this.ButtonClose.ImageSize = new System.Drawing.Size(30, 30);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.ButtonClose.Click += new System.EventHandler(this.guna2ImageButton1_Click);
            // 
            // ButtonLogin
            // 
            this.ButtonLogin.AutoRoundedCorners = true;
            this.ButtonLogin.BorderRadius = 31;
            this.ButtonLogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ButtonLogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ButtonLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ButtonLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ButtonLogin.FillColor = System.Drawing.SystemColors.MenuHighlight;
            resources.ApplyResources(this.ButtonLogin, "ButtonLogin");
            this.ButtonLogin.ForeColor = System.Drawing.Color.White;
            this.ButtonLogin.Name = "ButtonLogin";
            this.ButtonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // PanelLogin
            // 
            this.PanelLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(201)))));
            this.PanelLogin.Controls.Add(this.TextBoxUsername);
            this.PanelLogin.Controls.Add(this.ButtonLogin);
            this.PanelLogin.Controls.Add(this.panel4);
            this.PanelLogin.Controls.Add(this.TextBoxPassword);
            this.PanelLogin.Controls.Add(this.panel3);
            this.PanelLogin.Controls.Add(this.LabelWrong);
            this.PanelLogin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(201)))));
            this.PanelLogin.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(201)))));
            this.PanelLogin.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(201)))));
            this.PanelLogin.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(201)))));
            resources.ApplyResources(this.PanelLogin, "PanelLogin");
            this.PanelLogin.Name = "PanelLogin";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Highlight;
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            // 
            // DangNhap
            // 
            this.AcceptButton = this.ButtonLogin;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.PanelLogin);
            this.Controls.Add(this.PanelForm);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DangNhap";
            this.TopMost = true;
            this.PanelForm.ResumeLayout(false);
            this.PanelLogin.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LabelWrong;
        private Guna.UI2.WinForms.Guna2TextBox TextBoxUsername;
        private Guna.UI2.WinForms.Guna2TextBox TextBoxPassword;
        private Guna.UI2.WinForms.Guna2Panel PanelForm;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private Guna.UI2.WinForms.Guna2ImageButton ButtonClose;
        private Guna.UI2.WinForms.Guna2ImageButton ButtonMinimize;
        private Guna.UI2.WinForms.Guna2Button ButtonLogin;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel PanelLogin;
        private System.Windows.Forms.Panel panel4;
    }
}