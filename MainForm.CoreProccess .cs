using System;
using ywcai.core.control;
using ywcai.global.config;

namespace ywcai.core.veiw
{
    partial class RemoteDesk
    {
        private ControlCenter ctrlCenter = new ControlCenter();
        private void doLogin()
        {
            if (ctrlCenter.isLogining)
            {
                showInfo("您已经在线", MyConfig.INT_UPDATEUI_TXBOX);
                return;
            }
            ctrlCenter.loginIn(label_token.Text, label_nickname.Text+",0");
        }
        private void doLoginOut()
        {
            if (!ctrlCenter.isLogining)
            {
                showInfo("您还未上线", MyConfig.INT_UPDATEUI_TXBOX);
                return;
            }
            ctrlCenter.loginOut(label_nickname.Text);
        }

        private void connect(String index)
        {
            if (ctrlCenter.isCtrl)
            {
                showInfo("已经进行远程控制", MyConfig.INT_UPDATEUI_TXBOX);
                return;
            }
            //if (list_clients.SelectedItems.Count <= 0)
            //{
            //    showInfo("需要先选定要连接的主机", MyConfig.INT_UPDATEUI_TXBOX);
            //    return;
            //}
            //Int32 index = list_clients.SelectedIndices[0];
            //String order = list_clients.Items[index].Tag.ToString();
            showInfo("正在连接远端桌面", MyConfig.INT_UPDATEUI_TXBOX);
            ctrlCenter.createLink(index.ToString());
        }


        private void cacalConn()
        {
            if (!ctrlCenter.isCtrl)
            {
                showInfo("未和任何远程主机连接", MyConfig.INT_UPDATEUI_TXBOX);
                return;
            }
            ctrlCenter.disconnectLink();
        }
    }
}
