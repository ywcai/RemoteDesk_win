using CCWin.SkinControl;
using System;
using System.Windows.Forms;
using ywcai.global.config;
using ywcai.util.draw;

namespace ywcai.core.veiw
{

    public partial class RemoteDesk : CCWin.CCSkinMain
    {
        public RemoteDesk(String username, String token)
        {
            InitializeComponent();
            registerDelegate();
            //初始化本端设备信息
            this.lable_username.Text ="SERVER MODE";
            this.label_token.Text = token;
            this.label_nickname.Text = Environment.MachineName;

            StartLocalService();
        }

        private void icon_task_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }


        private void menu_login_Click(object sender, System.EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }


        private void menu_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listbox_clients_DoubleClickSubItem(object sender, ChatListEventArgs e, MouseEventArgs es)
        {

        }

        private void userPic_Click(object sender, EventArgs e)
        {

        }
    }
}
