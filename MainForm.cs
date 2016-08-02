using CCWin.SkinControl;
using System;
using System.Windows.Forms;
using ywcai.global.config;

namespace ywcai.core.veiw
{

    public partial class RemoteDesk : CCWin.CCSkinMain
    {
        private Int32 linkNum;
        public RemoteDesk(String username, String token)
        {
            InitializeComponent();
            registerDelegate();
            registerDeskListener();
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
            linkNum = Int32.Parse(e.SelectSubItem.Tag.ToString());
            //print("远程连接"+e.SelectSubItem.Tag.ToString(), MyConfig.INT_UPDATEUI_TXBOX);
            if (e.SelectSubItem.NicName.Equals(label_nickname.Text))
            {
                showInfo("你不能连接自己所在的终端", MyConfig.INT_UPDATEUI_TXBOX);
                return;
            }
            connect(e.SelectSubItem.Tag.ToString());
        }
    }
}
