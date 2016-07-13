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
            this.label2 = new System.Windows.Forms.Label();
            this.lable_status = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.loginOut = new System.Windows.Forms.Button();
            this.tx_info = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.list_clients = new System.Windows.Forms.ListView();
            this.createLink = new System.Windows.Forms.Button();
            this.disconnect = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tx_username
            // 
            this.tx_username.Location = new System.Drawing.Point(109, 9);
            this.tx_username.Name = "tx_username";
            this.tx_username.Size = new System.Drawing.Size(135, 21);
            this.tx_username.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "username";
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(250, 7);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(54, 23);
            this.login.TabIndex = 3;
            this.login.Text = "login";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Status";
            // 
            // lable_status
            // 
            this.lable_status.AutoSize = true;
            this.lable_status.Location = new System.Drawing.Point(107, 43);
            this.lable_status.Name = "lable_status";
            this.lable_status.Size = new System.Drawing.Size(35, 12);
            this.lable_status.TabIndex = 5;
            this.lable_status.Text = "false";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "ClientList";
            // 
            // loginOut
            // 
            this.loginOut.Location = new System.Drawing.Point(310, 7);
            this.loginOut.Name = "loginOut";
            this.loginOut.Size = new System.Drawing.Size(51, 23);
            this.loginOut.TabIndex = 10;
            this.loginOut.Text = "out";
            this.loginOut.UseVisualStyleBackColor = true;
            this.loginOut.Click += new System.EventHandler(this.loginout_Click);
            // 
            // tx_info
            // 
            this.tx_info.Location = new System.Drawing.Point(109, 217);
            this.tx_info.Multiline = true;
            this.tx_info.Name = "tx_info";
            this.tx_info.Size = new System.Drawing.Size(440, 141);
            this.tx_info.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "Recive";
            // 
            // list_clients
            // 
            this.list_clients.AllowColumnReorder = true;
            this.list_clients.Location = new System.Drawing.Point(109, 74);
            this.list_clients.Name = "list_clients";
            this.list_clients.Size = new System.Drawing.Size(440, 113);
            this.list_clients.TabIndex = 14;
            this.list_clients.UseCompatibleStateImageBehavior = false;
            this.list_clients.View = System.Windows.Forms.View.List;
            this.list_clients.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.list_clients_MouseDoubleClick);
            // 
            // createLink
            // 
            this.createLink.Location = new System.Drawing.Point(367, 7);
            this.createLink.Name = "createLink";
            this.createLink.Size = new System.Drawing.Size(51, 23);
            this.createLink.TabIndex = 15;
            this.createLink.Text = "link";
            this.createLink.UseVisualStyleBackColor = true;
            this.createLink.Click += new System.EventHandler(this.createLink_Click);
            // 
            // disconnect
            // 
            this.disconnect.Location = new System.Drawing.Point(424, 7);
            this.disconnect.Name = "disconnect";
            this.disconnect.Size = new System.Drawing.Size(59, 23);
            this.disconnect.TabIndex = 16;
            this.disconnect.Text = "disconn";
            this.disconnect.UseVisualStyleBackColor = true;
            this.disconnect.Click += new System.EventHandler(this.disConnect_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(424, 43);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(104, 23);
            this.button5.TabIndex = 17;
            this.button5.Text = "catch test";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 486);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.disconnect);
            this.Controls.Add(this.createLink);
            this.Controls.Add(this.list_clients);
            this.Controls.Add(this.tx_info);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.loginOut);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lable_status);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.login);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tx_username);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tx_username;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lable_status;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button loginOut;
        private System.Windows.Forms.TextBox tx_info;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView list_clients;
        private System.Windows.Forms.Button createLink;
        private System.Windows.Forms.Button disconnect;
        private System.Windows.Forms.Button button5;
    }
}

