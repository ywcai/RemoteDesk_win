namespace ywcai.core.veiw
{
    partial class Form1
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
            this.tx_username = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.login = new System.Windows.Forms.Button();
            this.loginOut = new System.Windows.Forms.Button();
            this.tx_info = new System.Windows.Forms.TextBox();
            this.list_clients = new System.Windows.Forms.ListView();
            this.disconnect = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.Panel();
            this.normal = new System.Windows.Forms.Button();
            this.min = new System.Windows.Forms.Button();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tx_username
            // 
            this.tx_username.Location = new System.Drawing.Point(93, 42);
            this.tx_username.Name = "tx_username";
            this.tx_username.Size = new System.Drawing.Size(135, 21);
            this.tx_username.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "别名 ： ";
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(245, 40);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(54, 23);
            this.login.TabIndex = 3;
            this.login.Text = "登录";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // loginOut
            // 
            this.loginOut.Location = new System.Drawing.Point(310, 40);
            this.loginOut.Name = "loginOut";
            this.loginOut.Size = new System.Drawing.Size(51, 23);
            this.loginOut.TabIndex = 10;
            this.loginOut.Text = "退出";
            this.loginOut.UseVisualStyleBackColor = true;
            this.loginOut.Click += new System.EventHandler(this.loginout_Click);
            // 
            // tx_info
            // 
            this.tx_info.Location = new System.Drawing.Point(37, 189);
            this.tx_info.Multiline = true;
            this.tx_info.Name = "tx_info";
            this.tx_info.Size = new System.Drawing.Size(602, 136);
            this.tx_info.TabIndex = 13;
            // 
            // list_clients
            // 
            this.list_clients.AllowColumnReorder = true;
            this.list_clients.Location = new System.Drawing.Point(37, 88);
            this.list_clients.Name = "list_clients";
            this.list_clients.Size = new System.Drawing.Size(190, 83);
            this.list_clients.TabIndex = 14;
            this.list_clients.UseCompatibleStateImageBehavior = false;
            this.list_clients.View = System.Windows.Forms.View.List;
            this.list_clients.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.list_clients_MouseDoubleClick);
            // 
            // disconnect
            // 
            this.disconnect.Location = new System.Drawing.Point(199, 12);
            this.disconnect.Name = "disconnect";
            this.disconnect.Size = new System.Drawing.Size(75, 23);
            this.disconnect.TabIndex = 16;
            this.disconnect.Text = "断开控制";
            this.disconnect.UseVisualStyleBackColor = true;
            this.disconnect.Click += new System.EventHandler(this.disConnect_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(379, 40);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(50, 23);
            this.button5.TabIndex = 17;
            this.button5.Text = "测试";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.menu.Controls.Add(this.normal);
            this.menu.Controls.Add(this.disconnect);
            this.menu.Controls.Add(this.min);
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(285, 49);
            this.menu.TabIndex = 18;
            this.menu.Visible = false;
            // 
            // normal
            // 
            this.normal.Location = new System.Drawing.Point(108, 12);
            this.normal.Name = "normal";
            this.normal.Size = new System.Drawing.Size(75, 23);
            this.normal.TabIndex = 1;
            this.normal.Text = "窗口化";
            this.normal.UseVisualStyleBackColor = true;
            this.normal.Click += new System.EventHandler(this.normal_Click);
            // 
            // min
            // 
            this.min.Location = new System.Drawing.Point(12, 12);
            this.min.Name = "min";
            this.min.Size = new System.Drawing.Size(75, 23);
            this.min.TabIndex = 0;
            this.min.Text = "最小化";
            this.min.UseVisualStyleBackColor = true;
            this.min.Click += new System.EventHandler(this.min_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(677, 365);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.list_clients);
            this.Controls.Add(this.tx_info);
            this.Controls.Add(this.loginOut);
            this.Controls.Add(this.login);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tx_username);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RDeskTop";
            this.menu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tx_username;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.Button loginOut;
        private System.Windows.Forms.TextBox tx_info;
        private System.Windows.Forms.ListView list_clients;
        private System.Windows.Forms.Button disconnect;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel menu;
        private System.Windows.Forms.Button normal;
        private System.Windows.Forms.Button min;
    }
}

