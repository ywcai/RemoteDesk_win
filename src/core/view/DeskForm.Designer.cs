namespace ywcai.core.veiw
{
    partial class DeskForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeskForm));
            this.panel_desk = new CCWin.SkinControl.SkinPanel();
            this.pannel_ctrlmenu = new CCWin.SkinControl.SkinPanel();
            this.bt_hide = new CCWin.SkinControl.SkinButton();
            this.bt_normal = new CCWin.SkinControl.SkinButton();
            this.bt_shutdown = new CCWin.SkinControl.SkinButton();
            this.bt_min = new CCWin.SkinControl.SkinButton();
            this.picbox_desk = new CCWin.SkinControl.SkinPictureBox();
            this.panel_desk.SuspendLayout();
            this.pannel_ctrlmenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbox_desk)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_desk
            // 
            this.panel_desk.AutoScroll = true;
            this.panel_desk.BackColor = System.Drawing.Color.Gainsboro;
            this.panel_desk.Controls.Add(this.pannel_ctrlmenu);
            this.panel_desk.Controls.Add(this.picbox_desk);
            this.panel_desk.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panel_desk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_desk.DownBack = null;
            this.panel_desk.Location = new System.Drawing.Point(0, 0);
            this.panel_desk.MouseBack = null;
            this.panel_desk.Name = "panel_desk";
            this.panel_desk.NormlBack = null;
            this.panel_desk.Size = new System.Drawing.Size(655, 451);
            this.panel_desk.TabIndex = 0;
            // 
            // pannel_ctrlmenu
            // 
            this.pannel_ctrlmenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pannel_ctrlmenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(154)))), ((int)(((byte)(218)))));
            this.pannel_ctrlmenu.Controls.Add(this.bt_hide);
            this.pannel_ctrlmenu.Controls.Add(this.bt_normal);
            this.pannel_ctrlmenu.Controls.Add(this.bt_shutdown);
            this.pannel_ctrlmenu.Controls.Add(this.bt_min);
            this.pannel_ctrlmenu.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.pannel_ctrlmenu.DownBack = null;
            this.pannel_ctrlmenu.Location = new System.Drawing.Point(316, 0);
            this.pannel_ctrlmenu.Margin = new System.Windows.Forms.Padding(0);
            this.pannel_ctrlmenu.MouseBack = null;
            this.pannel_ctrlmenu.Name = "pannel_ctrlmenu";
            this.pannel_ctrlmenu.NormlBack = null;
            this.pannel_ctrlmenu.Radius = 15;
            this.pannel_ctrlmenu.RoundStyle = CCWin.SkinClass.RoundStyle.BottomLeft;
            this.pannel_ctrlmenu.Size = new System.Drawing.Size(339, 35);
            this.pannel_ctrlmenu.TabIndex = 1;
            // 
            // bt_hide
            // 
            this.bt_hide.BackColor = System.Drawing.Color.Transparent;
            this.bt_hide.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.bt_hide.DownBack = null;
            this.bt_hide.ForeColor = System.Drawing.Color.White;
            this.bt_hide.Location = new System.Drawing.Point(13, 6);
            this.bt_hide.MouseBack = null;
            this.bt_hide.Name = "bt_hide";
            this.bt_hide.NormlBack = null;
            this.bt_hide.Size = new System.Drawing.Size(75, 23);
            this.bt_hide.TabIndex = 3;
            this.bt_hide.Text = "隐藏菜单";
            this.bt_hide.UseVisualStyleBackColor = false;
            this.bt_hide.Click += new System.EventHandler(this.bt_hide_Click);
            // 
            // bt_normal
            // 
            this.bt_normal.BackColor = System.Drawing.Color.Transparent;
            this.bt_normal.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.bt_normal.DownBack = null;
            this.bt_normal.ForeColor = System.Drawing.Color.White;
            this.bt_normal.Location = new System.Drawing.Point(175, 6);
            this.bt_normal.MouseBack = null;
            this.bt_normal.Name = "bt_normal";
            this.bt_normal.NormlBack = null;
            this.bt_normal.Size = new System.Drawing.Size(75, 23);
            this.bt_normal.TabIndex = 2;
            this.bt_normal.Text = "窗口模式";
            this.bt_normal.UseVisualStyleBackColor = false;
            this.bt_normal.Click += new System.EventHandler(this.bt_normal_Click);
            // 
            // bt_shutdown
            // 
            this.bt_shutdown.BackColor = System.Drawing.Color.Transparent;
            this.bt_shutdown.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.bt_shutdown.DownBack = null;
            this.bt_shutdown.ForeColor = System.Drawing.Color.White;
            this.bt_shutdown.Location = new System.Drawing.Point(256, 6);
            this.bt_shutdown.MouseBack = null;
            this.bt_shutdown.Name = "bt_shutdown";
            this.bt_shutdown.NormlBack = null;
            this.bt_shutdown.Size = new System.Drawing.Size(75, 23);
            this.bt_shutdown.TabIndex = 1;
            this.bt_shutdown.Text = "断开";
            this.bt_shutdown.UseVisualStyleBackColor = false;
            this.bt_shutdown.Click += new System.EventHandler(this.bt_shutdown_Click);
            // 
            // bt_min
            // 
            this.bt_min.BackColor = System.Drawing.Color.Transparent;
            this.bt_min.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.bt_min.DownBack = null;
            this.bt_min.ForeColor = System.Drawing.Color.White;
            this.bt_min.Location = new System.Drawing.Point(94, 6);
            this.bt_min.MouseBack = null;
            this.bt_min.Name = "bt_min";
            this.bt_min.NormlBack = null;
            this.bt_min.Size = new System.Drawing.Size(75, 23);
            this.bt_min.TabIndex = 0;
            this.bt_min.Text = "最小化";
            this.bt_min.UseVisualStyleBackColor = false;
            this.bt_min.Click += new System.EventHandler(this.bt_min_Click);
            // 
            // picbox_desk
            // 
            this.picbox_desk.BackColor = System.Drawing.Color.Transparent;
            this.picbox_desk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picbox_desk.Location = new System.Drawing.Point(0, 0);
            this.picbox_desk.Margin = new System.Windows.Forms.Padding(0);
            this.picbox_desk.Name = "picbox_desk";
            this.picbox_desk.Size = new System.Drawing.Size(655, 451);
            this.picbox_desk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picbox_desk.TabIndex = 0;
            this.picbox_desk.TabStop = false;
            this.picbox_desk.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picbox_desk_MouseDown);
            this.picbox_desk.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbox_desk_MouseMove);
            this.picbox_desk.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picbox_desk_MouseUp);
            // 
            // DeskForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(154)))), ((int)(((byte)(218)))));
            this.ClientSize = new System.Drawing.Size(655, 451);
            this.Controls.Add(this.panel_desk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DeskForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DeskForm";
            this.TopMost = true;
            this.panel_desk.ResumeLayout(false);
            this.pannel_ctrlmenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picbox_desk)).EndInit();
            this.ResumeLayout(false);

        }

      

        #endregion

        private CCWin.SkinControl.SkinPanel panel_desk;
        private CCWin.SkinControl.SkinPictureBox picbox_desk;
        private CCWin.SkinControl.SkinPanel pannel_ctrlmenu;
        private CCWin.SkinControl.SkinButton bt_normal;
        private CCWin.SkinControl.SkinButton bt_shutdown;
        private CCWin.SkinControl.SkinButton bt_min;
        private CCWin.SkinControl.SkinButton bt_hide;
    }
}