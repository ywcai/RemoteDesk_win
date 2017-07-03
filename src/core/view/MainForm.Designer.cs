using CCWin.SkinControl;

namespace ywcai.core.veiw
{
    partial class RemoteDesk
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            CCWin.SkinControl.ChatListItem chatListItem1 = new CCWin.SkinControl.ChatListItem();
            CCWin.SkinControl.ChatListSubItem chatListSubItem1 = new CCWin.SkinControl.ChatListSubItem();
            CCWin.SkinControl.ChatListItem chatListItem2 = new CCWin.SkinControl.ChatListItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoteDesk));
            this.listbox_clients = new CCWin.SkinControl.ChatListBox();
            this.statusPanel = new CCWin.SkinControl.SkinPanel();
            this.skinLabel3 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.label_token = new CCWin.SkinControl.SkinLabel();
            this.lable_username = new CCWin.SkinControl.SkinLabel();
            this.label_nickname = new CCWin.SkinControl.SkinLabel();
            this.userPic = new CCWin.SkinControl.SkinPictureBox();
            this.infoPanel = new CCWin.SkinControl.SkinPanel();
            this.infoLabel = new CCWin.SkinControl.SkinLabel();
            this.skinLine1 = new CCWin.SkinControl.SkinLine();
            this.icon_task = new System.Windows.Forms.NotifyIcon(this.components);
            this.menu_task = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menu_show = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_close = new System.Windows.Forms.ToolStripMenuItem();
            this.statusPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userPic)).BeginInit();
            this.infoPanel.SuspendLayout();
            this.menu_task.SuspendLayout();
            this.SuspendLayout();
            // 
            // listbox_clients
            // 
            this.listbox_clients.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listbox_clients.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(252)))));
            this.listbox_clients.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listbox_clients.ForeColor = System.Drawing.Color.Black;
            this.listbox_clients.FriendsMobile = true;
            this.listbox_clients.IconSizeMode = CCWin.SkinControl.ChatListItemIcon.Small;
            chatListItem1.Bounds = new System.Drawing.Rectangle(0, 1, 300, 53);
            chatListItem1.IsOpen = true;
            chatListItem1.IsTwinkleHide = false;
            chatListItem1.OwnerChatListBox = this.listbox_clients;
            chatListSubItem1.Bounds = new System.Drawing.Rectangle(0, 27, 300, 27);
            chatListSubItem1.DisplayName = "null";
            chatListSubItem1.HeadImage = global::ywcai.core.veiw.Properties.Resources.local;
            chatListSubItem1.HeadRect = new System.Drawing.Rectangle(5, 30, 20, 20);
            chatListSubItem1.ID = ((uint)(0u));
            chatListSubItem1.IpAddress = null;
            chatListSubItem1.IsTwinkle = false;
            chatListSubItem1.IsTwinkleHide = false;
            chatListSubItem1.IsVip = false;
            chatListSubItem1.NicName = "null";
            chatListSubItem1.OwnerListItem = chatListItem1;
            chatListSubItem1.PersonalMsg = "null";
            chatListSubItem1.PlatformTypes = CCWin.SkinControl.PlatformType.PC;
            chatListSubItem1.QQShow = null;
            chatListSubItem1.Status = CCWin.SkinControl.ChatListSubItem.UserStatus.Online;
            chatListSubItem1.Tag = null;
            chatListSubItem1.TcpPort = 0;
            chatListSubItem1.UpdPort = 0;
            chatListItem1.SubItems.AddRange(new CCWin.SkinControl.ChatListSubItem[] {
            chatListSubItem1});
            chatListItem1.Tag = null;
            chatListItem1.Text = "服务端状态";
            chatListItem1.TwinkleSubItemNumber = 0;
            chatListItem2.Bounds = new System.Drawing.Rectangle(0, 55, 300, 25);
            chatListItem2.IsTwinkleHide = false;
            chatListItem2.OwnerChatListBox = this.listbox_clients;
            chatListItem2.Tag = null;
            chatListItem2.Text = "远端连接";
            chatListItem2.TwinkleSubItemNumber = 0;
            this.listbox_clients.Items.AddRange(new CCWin.SkinControl.ChatListItem[] {
            chatListItem1,
            chatListItem2});
            this.listbox_clients.ListSubItemMenu = null;
            this.listbox_clients.Location = new System.Drawing.Point(0, 111);
            this.listbox_clients.Margin = new System.Windows.Forms.Padding(0);
            this.listbox_clients.Name = "listbox_clients";
            this.listbox_clients.SelectSubItem = null;
            this.listbox_clients.Size = new System.Drawing.Size(300, 340);
            this.listbox_clients.SubItemMenu = null;
            this.listbox_clients.TabIndex = 25;
            this.listbox_clients.DoubleClickSubItem += new CCWin.SkinControl.ChatListBox.ChatListEventHandler(this.listbox_clients_DoubleClickSubItem);
            // 
            // statusPanel
            // 
            this.statusPanel.AllowDrop = true;
            this.statusPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusPanel.BackColor = System.Drawing.Color.Transparent;
            this.statusPanel.BackRectangle = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.statusPanel.Controls.Add(this.skinLabel3);
            this.statusPanel.Controls.Add(this.skinLabel2);
            this.statusPanel.Controls.Add(this.skinLabel1);
            this.statusPanel.Controls.Add(this.label_token);
            this.statusPanel.Controls.Add(this.lable_username);
            this.statusPanel.Controls.Add(this.label_nickname);
            this.statusPanel.Controls.Add(this.userPic);
            this.statusPanel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.statusPanel.DownBack = null;
            this.statusPanel.ForeColor = System.Drawing.Color.Transparent;
            this.statusPanel.Location = new System.Drawing.Point(0, 21);
            this.statusPanel.Margin = new System.Windows.Forms.Padding(0);
            this.statusPanel.MouseBack = null;
            this.statusPanel.Name = "statusPanel";
            this.statusPanel.NormlBack = null;
            this.statusPanel.Padding = new System.Windows.Forms.Padding(5);
            this.statusPanel.Radius = 4;
            this.statusPanel.Size = new System.Drawing.Size(300, 90);
            this.statusPanel.TabIndex = 20;
            // 
            // skinLabel3
            // 
            this.skinLabel3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.skinLabel3.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel3.AutoEllipsis = true;
            this.skinLabel3.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel3.BorderColor = System.Drawing.Color.White;
            this.skinLabel3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel3.ForeColor = System.Drawing.Color.White;
            this.skinLabel3.Location = new System.Drawing.Point(69, 62);
            this.skinLabel3.Margin = new System.Windows.Forms.Padding(0);
            this.skinLabel3.Name = "skinLabel3";
            this.skinLabel3.Size = new System.Drawing.Size(64, 23);
            this.skinLabel3.TabIndex = 8;
            this.skinLabel3.Text = "计算机名";
            // 
            // skinLabel2
            // 
            this.skinLabel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.skinLabel2.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel2.AutoEllipsis = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.ForeColor = System.Drawing.Color.White;
            this.skinLabel2.Location = new System.Drawing.Point(69, 39);
            this.skinLabel2.Margin = new System.Windows.Forms.Padding(0);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(64, 26);
            this.skinLabel2.TabIndex = 7;
            this.skinLabel2.Text = "连接令牌";
            // 
            // skinLabel1
            // 
            this.skinLabel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.skinLabel1.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel1.AutoEllipsis = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.ForeColor = System.Drawing.Color.White;
            this.skinLabel1.Location = new System.Drawing.Point(69, 15);
            this.skinLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(61, 23);
            this.skinLabel1.TabIndex = 6;
            this.skinLabel1.Text = "连接模式";
            // 
            // label_token
            // 
            this.label_token.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_token.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label_token.AutoEllipsis = true;
            this.label_token.BackColor = System.Drawing.Color.Transparent;
            this.label_token.BorderColor = System.Drawing.Color.White;
            this.label_token.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_token.ForeColor = System.Drawing.Color.Gainsboro;
            this.label_token.Location = new System.Drawing.Point(130, 39);
            this.label_token.Margin = new System.Windows.Forms.Padding(0);
            this.label_token.Name = "label_token";
            this.label_token.Size = new System.Drawing.Size(153, 26);
            this.label_token.TabIndex = 5;
            this.label_token.Text = "null";
            // 
            // lable_username
            // 
            this.lable_username.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lable_username.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.lable_username.AutoEllipsis = true;
            this.lable_username.BackColor = System.Drawing.Color.Transparent;
            this.lable_username.BorderColor = System.Drawing.Color.White;
            this.lable_username.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lable_username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lable_username.Location = new System.Drawing.Point(130, 15);
            this.lable_username.Margin = new System.Windows.Forms.Padding(0);
            this.lable_username.Name = "lable_username";
            this.lable_username.Size = new System.Drawing.Size(152, 23);
            this.lable_username.TabIndex = 4;
            this.lable_username.Text = "null";
            // 
            // label_nickname
            // 
            this.label_nickname.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_nickname.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label_nickname.AutoEllipsis = true;
            this.label_nickname.BackColor = System.Drawing.Color.Transparent;
            this.label_nickname.BorderColor = System.Drawing.Color.White;
            this.label_nickname.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_nickname.ForeColor = System.Drawing.Color.Gainsboro;
            this.label_nickname.Location = new System.Drawing.Point(129, 62);
            this.label_nickname.Margin = new System.Windows.Forms.Padding(0);
            this.label_nickname.Name = "label_nickname";
            this.label_nickname.Size = new System.Drawing.Size(149, 23);
            this.label_nickname.TabIndex = 2;
            this.label_nickname.Text = "null";
            // 
            // userPic
            // 
            this.userPic.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.userPic.BackColor = System.Drawing.Color.Transparent;
            this.userPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.userPic.Image = global::ywcai.core.veiw.Properties.Resources.head;
            this.userPic.Location = new System.Drawing.Point(5, 16);
            this.userPic.Margin = new System.Windows.Forms.Padding(0);
            this.userPic.Name = "userPic";
            this.userPic.Size = new System.Drawing.Size(60, 60);
            this.userPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userPic.TabIndex = 0;
            this.userPic.TabStop = false;
            this.userPic.Click += new System.EventHandler(this.userPic_Click);
            // 
            // infoPanel
            // 
            this.infoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.infoPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(233)))), ((int)(((byte)(231)))));
            this.infoPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.infoPanel.BackRectangle = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.infoPanel.Controls.Add(this.infoLabel);
            this.infoPanel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.infoPanel.DownBack = null;
            this.infoPanel.Location = new System.Drawing.Point(0, 454);
            this.infoPanel.Margin = new System.Windows.Forms.Padding(0);
            this.infoPanel.MouseBack = null;
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.NormlBack = null;
            this.infoPanel.Padding = new System.Windows.Forms.Padding(5);
            this.infoPanel.Radius = 4;
            this.infoPanel.Size = new System.Drawing.Size(300, 54);
            this.infoPanel.TabIndex = 21;
            // 
            // infoLabel
            // 
            this.infoLabel.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.infoLabel.AutoEllipsis = true;
            this.infoLabel.AutoSize = true;
            this.infoLabel.BackColor = System.Drawing.Color.Transparent;
            this.infoLabel.BorderColor = System.Drawing.Color.Transparent;
            this.infoLabel.BorderSize = 0;
            this.infoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.infoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.infoLabel.Location = new System.Drawing.Point(5, 5);
            this.infoLabel.Margin = new System.Windows.Forms.Padding(0);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(30, 17);
            this.infoLabel.TabIndex = 6;
            this.infoLabel.Text = "info";
            this.infoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // skinLine1
            // 
            this.skinLine1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.skinLine1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(205)))), ((int)(((byte)(237)))));
            this.skinLine1.Font = new System.Drawing.Font("宋体", 1F);
            this.skinLine1.LineColor = System.Drawing.Color.Transparent;
            this.skinLine1.LineHeight = 1;
            this.skinLine1.Location = new System.Drawing.Point(0, 451);
            this.skinLine1.Margin = new System.Windows.Forms.Padding(0);
            this.skinLine1.Name = "skinLine1";
            this.skinLine1.Size = new System.Drawing.Size(300, 3);
            this.skinLine1.TabIndex = 23;
            this.skinLine1.Text = "skinLine1";
            // 
            // icon_task
            // 
            this.icon_task.ContextMenuStrip = this.menu_task;
            this.icon_task.Icon = ((System.Drawing.Icon)(resources.GetObject("icon_task.Icon")));
            this.icon_task.Text = "RemoteDesk";
            this.icon_task.Visible = true;
            this.icon_task.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.icon_task_MouseDoubleClick);
            // 
            // menu_task
            // 
            this.menu_task.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_show,
            this.menu_close});
            this.menu_task.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.menu_task.Name = "menu_task";
            this.menu_task.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menu_task.ShowImageMargin = false;
            this.menu_task.Size = new System.Drawing.Size(128, 70);
            this.menu_task.Text = "操作菜单";
            // 
            // menu_show
            // 
            this.menu_show.Name = "menu_show";
            this.menu_show.Size = new System.Drawing.Size(127, 22);
            this.menu_show.Text = "显示";
            this.menu_show.Click += new System.EventHandler(this.menu_login_Click);
            // 
            // menu_close
            // 
            this.menu_close.Name = "menu_close";
            this.menu_close.Size = new System.Drawing.Size(127, 22);
            this.menu_close.Text = "退出";
            this.menu_close.Click += new System.EventHandler(this.menu_close_Click);
            // 
            // RemoteDesk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(154)))), ((int)(((byte)(218)))));
            this.BackRectangle = new System.Drawing.Rectangle(5, 5, 5, 5);
            this.BackShade = false;
            this.BackToColor = false;
            this.BorderColor = System.Drawing.Color.Transparent;
            this.BorderRectangle = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.CaptionFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.CaptionHeight = 20;
            this.ClientSize = new System.Drawing.Size(300, 508);
            this.CloseBoxSize = new System.Drawing.Size(20, 20);
            this.ControlBoxOffset = new System.Drawing.Point(5, 0);
            this.ControlBoxSpace = 5;
            this.Controls.Add(this.listbox_clients);
            this.Controls.Add(this.skinLine1);
            this.Controls.Add(this.infoPanel);
            this.Controls.Add(this.statusPanel);
            this.DropBack = false;
            this.EffectCaption = CCWin.TitleType.Title;
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ICoOffset = new System.Drawing.Point(5, 0);
            this.InnerBorderColor = System.Drawing.Color.Transparent;
            this.Location = new System.Drawing.Point(1000, 100);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(447, 600);
            this.MaxSize = new System.Drawing.Size(20, 20);
            this.MdiAutoScroll = false;
            this.MdiBackColor = System.Drawing.Color.Transparent;
            this.MdiBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(300, 400);
            this.MiniSize = new System.Drawing.Size(20, 20);
            this.Mobile = CCWin.MobileStyle.TitleMobile;
            this.Name = "RemoteDesk";
            this.Radius = 3;
            this.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ShadowRectangle = new System.Drawing.Rectangle(5, 5, 5, 5);
            this.ShadowWidth = 5;
            this.ShowBorder = false;
            this.ShowDrawIcon = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Special = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "RmoteDesk";
            this.TitleColor = System.Drawing.Color.White;
            this.statusPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userPic)).EndInit();
            this.infoPanel.ResumeLayout(false);
            this.infoPanel.PerformLayout();
            this.menu_task.ResumeLayout(false);
            this.ResumeLayout(false);

        }

  

        #endregion
        private CCWin.SkinControl.SkinPanel statusPanel;
        private CCWin.SkinControl.SkinPictureBox userPic;
        private CCWin.SkinControl.SkinPanel infoPanel;
        private CCWin.SkinControl.SkinLabel infoLabel;
        private CCWin.SkinControl.SkinLine skinLine1;
        private CCWin.SkinControl.ChatListBox listbox_clients;
        private CCWin.SkinControl.SkinLabel lable_username;
        private CCWin.SkinControl.SkinLabel label_token;
        private CCWin.SkinControl.SkinLabel label_nickname;
        private SkinLabel skinLabel3;
        private SkinLabel skinLabel2;
        private SkinLabel skinLabel1;
        private System.Windows.Forms.NotifyIcon icon_task;
        private System.Windows.Forms.ContextMenuStrip menu_task;
        private System.Windows.Forms.ToolStripMenuItem menu_show;
        private System.Windows.Forms.ToolStripMenuItem menu_close;
    }
}

