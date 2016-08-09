using CCWin.SkinControl;
using System;
using System.Drawing;
using System.Windows.Forms;
using ywcai.core.sokcet;
using ywcai.global.config;

namespace ywcai.core.veiw
{
    partial class RemoteDesk
    {
        private DeskForm deskForm;
        private MySocket mySocket = MySocket.GetInstance();
        private delegate void UiEventsHandler(String mes, Int32 method); //普通UI更新委托
        private delegate void DeskEventsHandler(Bitmap img); //持续渲染屏幕
        private void registerDelegate()
        {
            mySocket.updateInfo += showInfo;
            ctrlCenter.updateInfo += showInfo;
            ctrlCenter.updateDesk += drawDesk;
        }
        //桌面渲染委托
        private void drawDesk(Bitmap img)
        {
            if (InvokeRequired)
            {
                DeskEventsHandler uImg = draw;
                object[] pList = { img };
                BeginInvoke(uImg, pList);//异步执行了，不用加同步锁
            }
            else
            {
                draw(img);
            }
        }
        private void draw(Bitmap img)
        {
            if(deskForm!=null)
            { 
            deskForm.draw(img);
            }
        }
        //信息显示委托
        private void showInfo(Object pMes, Int32 method)
        {
            if (InvokeRequired)
            {
                UiEventsHandler mh = print;
                object[] pList = { pMes.ToString(), method };
                Invoke(mh, pList);//同步执行了
            }
            else
            {
                print(pMes.ToString(), method);
            }
        }
        private void print(String mes, Int32 method)
        {
            switch (method)
            {
                case MyConfig.INT_CLEAR_LIST:
                    clearListItems();
                    break;
                case MyConfig.INT_UPDATEUI_LIST:
                    updateUserList(mes);
                    break;
                case MyConfig.INT_UPDATEUI_TXBOX:
                    infoLabel.Text = mes;
                    break;
                case MyConfig.INT_CREATE_DESK_CONTAINER:
                    addDesk();
                    break;
                case MyConfig.INT_DELETE_DESK_CONTAINER:
                    removeDesk();
                    break;
                case MyConfig.INT_INIT_CLIENT_LIST:
                    initRemoteLists(mes);
                    break;
                case MyConfig.INT_CHANGE_OUT:
                    turnOffLine();
                    break;

                default:
                    //do nothing;
                    break;
            }
        }

        private void turnOffLine()
        {
            ctrlCenter.isCtrl = false;
            ctrlCenter.isLogining = false;
            removeDesk();
            clearListItems();
        }

        private void initRemoteLists(String mes)
        {
            String[] list = mes.Split('|');
            for(Int32 i=0; i<list.Length; i++)
            {
                if(!list[i].Equals(""))
                { 
                String[] str = list[i].Split(',');
                String displayname = str[0];
                String ip = str[1].Remove(0, 1);
                Int32 dreviceType = Int32.Parse(str[4]);
                String tag = str[5];
                Boolean isOnline = str[2].Equals("true") ? true : false;
                Boolean isVip = str[3].Equals("true") ? true : false;
                ChatListSubItem newClient = new ChatListSubItem();
                newClient.HeadImage = global::ywcai.core.veiw.Properties.Resources.remote;
                newClient.DisplayName = displayname;
                newClient.NicName = tag;
                newClient.Tag = tag;
                newClient.IpAddress = ip;
                newClient.PersonalMsg = ip;
                newClient.Status = (isOnline ? ChatListSubItem.UserStatus.Online : ChatListSubItem.UserStatus.OffLine);
                newClient.IsVip = isVip;
                newClient.PlatformTypes = (dreviceType == MyConfig.INT_CLIENT_TYPE_PC ? PlatformType.PC : PlatformType.Iphone);
                newClient.OwnerListItem = listbox_clients.Items[1];
                listbox_clients.Items[1].SubItems.Add(newClient);
                }
            }
        }


        private void clearListItems()
        {
            listbox_clients.Items[0].SubItems[0].Status = ChatListSubItem.UserStatus.OffLine;
            listbox_clients.Items[0].SubItems[0].PersonalMsg = "0.0.0.0";
            listbox_clients.Items[0].SubItems[0].IpAddress= "0.0.0.0";
            listbox_clients.Items[0].SubItems[0].NicName = "0" ;
            listbox_clients.Items[0].SubItems[0].Tag= "0";
            listbox_clients.Items[0].SubItems[0].IsVip = false;
            if (listbox_clients.Items[1].SubItems.Count != 0)
            { 
            listbox_clients.Items[1].SubItems.Clear();
            }
        }

        private void updateUserList(String mes)
        {
            String[] str = mes.Split(',');
            String displayname = str[0];
            String ip = str[1].Remove(0, 1);
            Int32 dreviceType = Int32.Parse(str[4]);
            String tag = str[5];
            Boolean isOnline = str[2].Equals("true") ? true : false;
            Boolean isVip = str[3].Equals("true") ? true : false;
            if (listbox_clients.Items[0].SubItems[0].DisplayName.Equals(displayname))
            {
                listbox_clients.Items[0].SubItems[0].NicName = tag;
                listbox_clients.Items[0].SubItems[0].Tag = tag;
                listbox_clients.Items[0].SubItems[0].IpAddress = ip;
                listbox_clients.Items[0].SubItems[0].PersonalMsg = ip;
                listbox_clients.Items[0].SubItems[0].Status =( isOnline? ChatListSubItem.UserStatus.Online: ChatListSubItem.UserStatus.OffLine) ;
                listbox_clients.Items[0].SubItems[0].IsVip = isVip;
                listbox_clients.Items[0].SubItems[0].PlatformTypes = (dreviceType == MyConfig.INT_CLIENT_TYPE_PC ? PlatformType.PC : PlatformType.Iphone);
                return;
            }
            foreach (ChatListSubItem remote in listbox_clients.Items[1].SubItems)
            {
                if (remote.DisplayName.Equals(displayname))
                {
                    remote.NicName = tag;
                    remote.Tag = tag;
                    remote.IpAddress = ip;
                    remote.PersonalMsg = ip;
                    remote.Status = (isOnline ? ChatListSubItem.UserStatus.Online : ChatListSubItem.UserStatus.OffLine);
                    remote.IsVip = isVip;
                    remote.PlatformTypes = (dreviceType == MyConfig.INT_CLIENT_TYPE_PC ? PlatformType.PC : PlatformType.Iphone);
                    return;
                }
            }
            ChatListSubItem  newClient= new ChatListSubItem();
            newClient.HeadImage=global::ywcai.core.veiw.Properties.Resources.remote;
            newClient.DisplayName = displayname;
            newClient.NicName = tag;
            newClient.Tag = tag;
            newClient.IpAddress = ip;
            newClient.PersonalMsg = ip;
            newClient.Status = (isOnline ? ChatListSubItem.UserStatus.Online : ChatListSubItem.UserStatus.OffLine);
            newClient.IsVip = isVip;
            newClient.PlatformTypes = (dreviceType == MyConfig.INT_CLIENT_TYPE_PC ? PlatformType.PC : PlatformType.Iphone);
            newClient.OwnerListItem = listbox_clients.Items[1];
            listbox_clients.Items[1].SubItems.Add(newClient); 
        }

        private void addDesk()
        {
            deskForm = new DeskForm(ctrlCenter);
            deskForm.Show();
            deskForm.setFullScreen();
            //deskTop.Dock = DockStyle.Left | DockStyle.Top;
            //panel.BackColor = Color.AliceBlue;
            //this.Controls.Add(panel);
            //panel.BringToFront();
            //setMaxScreen();
        }
        private void removeDesk()
        {
            //this.Controls.Remove(panel);
            if(!deskForm.IsNull())
            { 
            deskForm.Close();
            }
            //setNormalScreen();
        }

    }
}
