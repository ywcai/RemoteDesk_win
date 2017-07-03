namespace ywcai.core.veiw

{
    partial class LoginForm
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
            this.skinPanel1 = new CCWin.SkinControl.SkinPanel();
            this.label_errinfo = new CCWin.SkinControl.SkinLabel();
            this.bt_login = new CCWin.SkinControl.SkinButton();
            this.tip = new CCWin.SkinControl.SkinLabel();
            this.tx_username = new CCWin.SkinControl.SkinTextBox();
            this.bar_loading = new CCWin.SkinControl.SkinProgressIndicator();
            this.skinPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinPanel1
            // 
            this.skinPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(252)))));
            this.skinPanel1.Controls.Add(this.label_errinfo);
            this.skinPanel1.Controls.Add(this.bt_login);
            this.skinPanel1.Controls.Add(this.tip);
            this.skinPanel1.Controls.Add(this.tx_username);
            this.skinPanel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel1.DownBack = null;
            this.skinPanel1.Location = new System.Drawing.Point(0, 121);
            this.skinPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.skinPanel1.MouseBack = null;
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.NormlBack = null;
            this.skinPanel1.Radius = 4;
            this.skinPanel1.RoundStyle = CCWin.SkinClass.RoundStyle.Bottom;
            this.skinPanel1.Size = new System.Drawing.Size(470, 212);
            this.skinPanel1.TabIndex = 0;
            // 
            // label_errinfo
            // 
            this.label_errinfo.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label_errinfo.AutoSize = true;
            this.label_errinfo.BackColor = System.Drawing.Color.Transparent;
            this.label_errinfo.BorderColor = System.Drawing.Color.White;
            this.label_errinfo.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.label_errinfo.ForeColor = System.Drawing.Color.Red;
            this.label_errinfo.Location = new System.Drawing.Point(86, 125);
            this.label_errinfo.Margin = new System.Windows.Forms.Padding(0);
            this.label_errinfo.MaximumSize = new System.Drawing.Size(280, 0);
            this.label_errinfo.Name = "label_errinfo";
            this.label_errinfo.Size = new System.Drawing.Size(0, 16);
            this.label_errinfo.TabIndex = 6;
            // 
            // bt_login
            // 
            this.bt_login.BackColor = System.Drawing.Color.Transparent;
            this.bt_login.BackRectangle = new System.Drawing.Rectangle(20, 20, 20, 20);
            this.bt_login.BorderColor = System.Drawing.Color.Transparent;
            this.bt_login.BorderInflate = new System.Drawing.Size(0, 0);
            this.bt_login.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.bt_login.DownBack = null;
            this.bt_login.FadeGlow = false;
            this.bt_login.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_login.ForeColor = System.Drawing.Color.White;
            this.bt_login.GlowColor = System.Drawing.Color.Transparent;
            this.bt_login.InnerBorderColor = System.Drawing.Color.Transparent;
            this.bt_login.IsDrawBorder = false;
            this.bt_login.IsDrawGlass = false;
            this.bt_login.Location = new System.Drawing.Point(89, 157);
            this.bt_login.Margin = new System.Windows.Forms.Padding(0);
            this.bt_login.MouseBack = null;
            this.bt_login.Name = "bt_login";
            this.bt_login.NormlBack = null;
            this.bt_login.Palace = true;
            this.bt_login.Radius = 5;
            this.bt_login.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.bt_login.Size = new System.Drawing.Size(185, 30);
            this.bt_login.TabIndex = 3;
            this.bt_login.Text = "创  建  服 务 端";
            this.bt_login.UseVisualStyleBackColor = false;
            this.bt_login.Click += new System.EventHandler(this.bt_login_Click);
            // 
            // tip
            // 
            this.tip.AutoSize = true;
            this.tip.BackColor = System.Drawing.Color.Transparent;
            this.tip.BorderColor = System.Drawing.Color.White;
            this.tip.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tip.Location = new System.Drawing.Point(86, 12);
            this.tip.Name = "tip";
            this.tip.Size = new System.Drawing.Size(300, 21);
            this.tip.TabIndex = 1;
            this.tip.Text = "请设置远端设备连接的密码，不超过16位";
            // 
            // tx_username
            // 
            this.tx_username.BackColor = System.Drawing.Color.Transparent;
            this.tx_username.DownBack = null;
            this.tx_username.Icon = null;
            this.tx_username.IconIsButton = false;
            this.tx_username.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.tx_username.IsPasswordChat = '\0';
            this.tx_username.IsSystemPasswordChar = false;
            this.tx_username.Lines = new string[] {
        "111111"};
            this.tx_username.Location = new System.Drawing.Point(89, 72);
            this.tx_username.Margin = new System.Windows.Forms.Padding(0);
            this.tx_username.MaxLength = 20;
            this.tx_username.MinimumSize = new System.Drawing.Size(28, 28);
            this.tx_username.MouseBack = null;
            this.tx_username.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.tx_username.Multiline = false;
            this.tx_username.Name = "tx_username";
            this.tx_username.NormlBack = null;
            this.tx_username.Padding = new System.Windows.Forms.Padding(5);
            this.tx_username.ReadOnly = false;
            this.tx_username.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tx_username.Size = new System.Drawing.Size(185, 28);
            // 
            // 
            // 
            this.tx_username.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tx_username.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tx_username.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.tx_username.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.tx_username.SkinTxt.MaxLength = 20;
            this.tx_username.SkinTxt.Name = "BaseText";
            this.tx_username.SkinTxt.Size = new System.Drawing.Size(175, 18);
            this.tx_username.SkinTxt.TabIndex = 0;
            this.tx_username.SkinTxt.Text = "111111";
            this.tx_username.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.tx_username.SkinTxt.WaterText = "";
            this.tx_username.SkinTxt.WordWrap = false;
            this.tx_username.TabIndex = 0;
            this.tx_username.Text = "111111";
            this.tx_username.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tx_username.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.tx_username.WaterText = "";
            this.tx_username.WordWrap = false;
            // 
            // bar_loading
            // 
            this.bar_loading.AutoStart = true;
            this.bar_loading.BackColor = System.Drawing.Color.Transparent;
            this.bar_loading.CircleColor = System.Drawing.Color.Black;
            this.bar_loading.CircleSize = 0.6F;
            this.bar_loading.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bar_loading.ForeColor = System.Drawing.Color.White;
            this.bar_loading.Location = new System.Drawing.Point(202, 38);
            this.bar_loading.Margin = new System.Windows.Forms.Padding(0);
            this.bar_loading.Name = "bar_loading";
            this.bar_loading.Percentage = 0F;
            this.bar_loading.ShowText = true;
            this.bar_loading.Size = new System.Drawing.Size(58, 58);
            this.bar_loading.TabIndex = 1;
            this.bar_loading.TextDisplay = CCWin.SkinControl.TextDisplayModes.Text;
            this.bar_loading.Visible = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(154)))), ((int)(((byte)(218)))));
            this.BackShade = false;
            this.BackToColor = false;
            this.CanResize = false;
            this.CaptionFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.CaptionHeight = 25;
            this.ClientSize = new System.Drawing.Size(470, 333);
            this.CloseBoxSize = new System.Drawing.Size(20, 20);
            this.ControlBoxOffset = new System.Drawing.Point(5, 5);
            this.ControlBoxSpace = 10;
            this.Controls.Add(this.bar_loading);
            this.Controls.Add(this.skinPanel1);
            this.EffectCaption = CCWin.TitleType.Title;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaxSize = new System.Drawing.Size(20, 20);
            this.MdiAutoScroll = false;
            this.MdiBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MiniSize = new System.Drawing.Size(20, 20);
            this.Name = "LoginForm";
            this.Radius = 4;
            this.ShowBorder = false;
            this.ShowDrawIcon = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SkinOpacity = 0.8D;
            this.Special = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome to use RemoteDesk !";
            this.TitleColor = System.Drawing.Color.White;
            this.TitleOffset = new System.Drawing.Point(5, 0);
            this.skinPanel1.ResumeLayout(false);
            this.skinPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinPanel skinPanel1;
        private CCWin.SkinControl.SkinTextBox tx_username;
        private CCWin.SkinControl.SkinLabel tip;
        private CCWin.SkinControl.SkinButton bt_login;
        private CCWin.SkinControl.SkinLabel label_errinfo;
        private CCWin.SkinControl.SkinProgressIndicator bar_loading;
    }
}