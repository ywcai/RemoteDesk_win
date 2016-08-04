using CCWin.SkinControl;
using System;
using System.Windows.Forms;
using ywcai.global.config;

namespace ywcai.core.veiw
{

    public partial class RemoteDesk : CCWin.CCSkinMain
    {
        public RemoteDesk(String username, String token)
        {
            InitializeComponent();
            registerDelegate();
            //初始化本端设备信息
            this.lable_username.Text = username;
            this.label_token.Text = token;
            this.label_nickname.Text = Environment.MachineName;
            listbox_clients.Items[0].SubItems[0].NicName = "null";
            listbox_clients.Items[0].SubItems[0].DisplayName = label_nickname.Text;
            listbox_clients.Items[0].SubItems[0].PlatformTypes = PlatformType.PC;
            listbox_clients.Items[0].SubItems[0].Status = ChatListSubItem.UserStatus.OffLine;

            doLogin();
        }

        private void icon_task_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void menu_login_Click(object sender, EventArgs e)
        {
            doLogin();
        }

        private void menu_loginout_Click(object sender, EventArgs e)
        {
            doLoginOut();
        }

        private void menu_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listbox_clients_DoubleClickSubItem(object sender, ChatListEventArgs e, MouseEventArgs es)
        {
            if (listbox_clients.Items[0].SubItems[0].Status== ChatListSubItem.UserStatus.OffLine)
            {
                showInfo("你处于离线状态", MyConfig.INT_UPDATEUI_TXBOX);
                return;
            }
            if (listbox_clients.Items[0].SubItems[0].IsVip)
            {
                showInfo("你处于远程控制状态", MyConfig.INT_UPDATEUI_TXBOX);
                return;
            }
            if (e.SelectSubItem.DisplayName.Equals(label_nickname.Text))
            {
                showInfo("设备不能连接自身", MyConfig.INT_UPDATEUI_TXBOX);
                //return;
            }
            if (e.SelectSubItem.Status==ChatListSubItem.UserStatus.OffLine)
            {
                showInfo("你连接的远端设备不在线", MyConfig.INT_UPDATEUI_TXBOX);
                return;
            }
            if (e.SelectSubItem.IsVip)
            {
                showInfo("你连接的远端设备处于控制状态", MyConfig.INT_UPDATEUI_TXBOX);
                return;
            }
            connect(e.SelectSubItem.Tag.ToString());
        }
    }
}
