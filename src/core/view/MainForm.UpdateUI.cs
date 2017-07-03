using CCWin.SkinControl;
using System;
using System.Drawing;
using System.Windows.Forms;
using ywcai.core.veiw.src.core;
using ywcai.global.config;

namespace ywcai.core.veiw
{
    partial class RemoteDesk
    {
        private DeskForm deskForm=null;
        private delegate void UiEventsHandler(Object mes, Int32 method); //普通UI更新委托
        private delegate void DeskEventsHandler(Bitmap img); //持续渲染屏幕
        private void registerDelegate()
        {
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
                object[] pList = { pMes, method };
                Invoke(mh, pList);//同步执行了
            }
            else
            {
                print(pMes, method);
            }
        }
        private void print(Object mes, Int32 method)
        {
            switch (method)
            {
                case MyConfig.INT_UPDATEUI_TXBOX:
                    infoLabel.Text = mes.ToString();
                    break;
                case MyConfig.INT_CREATE_DESK_CONTAINER:
                    addDesk();
                    break;
                case MyConfig.INT_DELETE_DESK_CONTAINER:
                    removeDesk();
                    break;
                case MyConfig.INT_SERVER_SUCCESS:
                    startServer(true);
                    break;
                case MyConfig.INT_SERVER_FAIL:
                    startServer(false);
                    break;
                case MyConfig.INT_CLIENT_ONLINE:
                    addOnlineClient(mes);
                    break;
                case MyConfig.INT_CLIENT_OFFLINE:
                    turnOffline(mes);
                    break;
                case MyConfig.INT_CLIENT_BUSY:
                    turnBusy(mes);
                    break;
                case MyConfig.INT_CLIENT_FREE:
                    turnFree(mes);
                    break;
                case MyConfig.INT_CLIENT_ADD_TEMP:
                    addTempClient(mes);
                    break;
                default:
                    //do nothing;
                    break;
            }
        }

        private void addTempClient(object mes)
        {
            DeviceInfo deviceInfo = (DeviceInfo)mes;
            foreach (ChatListSubItem remote in listbox_clients.Items[1].SubItems)
            {
                if (remote.DisplayName.Equals(deviceInfo.deviceId))
                {
                    remote.IpAddress = deviceInfo.remoteIp;
                    remote.PersonalMsg = deviceInfo.remoteIp;
                    remote.Status = ChatListSubItem.UserStatus.OffLine;
                    remote.IsVip = false;
                    return;
                }
            }
            ChatListSubItem newClient = new ChatListSubItem();
            newClient.HeadImage = global::ywcai.core.veiw.Properties.Resources.remote;
            newClient.DisplayName = deviceInfo.deviceId;
            newClient.NicName = deviceInfo.deviceName;
            newClient.Tag = deviceInfo.deviceMode;
            newClient.IpAddress = deviceInfo.remoteIp;
            newClient.PersonalMsg = deviceInfo.remoteIp;
            newClient.Status = ChatListSubItem.UserStatus.OffLine;
            newClient.IsVip = false;
            newClient.PlatformTypes = PlatformType.Iphone;
            newClient.OwnerListItem = listbox_clients.Items[1];
            listbox_clients.Items[1].SubItems.Add(newClient); 
        }
        private void addOnlineClient(Object mes)
        {
            DeviceInfo deviceInfo = (DeviceInfo)mes;
            //String port = mes.Split(':')[1];
            foreach (ChatListSubItem remote in listbox_clients.Items[1].SubItems)
            {
                if (remote.DisplayName.Equals(deviceInfo.deviceId))
                {
                    remote.NicName = deviceInfo.deviceName;
                    remote.Tag = deviceInfo.deviceMode;
                    remote.IpAddress = deviceInfo.remoteIp;
                    remote.PersonalMsg = deviceInfo.remoteIp;
                    remote.Status = ChatListSubItem.UserStatus.Online;
                    return;
                }
            }
            ChatListSubItem newClient = new ChatListSubItem();
            newClient.HeadImage = global::ywcai.core.veiw.Properties.Resources.remote;
            newClient.DisplayName = deviceInfo.deviceId;
            newClient.NicName = deviceInfo.deviceName;
            newClient.Tag = deviceInfo.deviceMode;
            newClient.IpAddress = deviceInfo.remoteIp;
            newClient.PersonalMsg = deviceInfo.remoteIp;
            newClient.Status = ChatListSubItem.UserStatus.Online;
            newClient.IsVip = false;
            newClient.PlatformTypes = PlatformType.Iphone;
            newClient.OwnerListItem = listbox_clients.Items[1];
            listbox_clients.Items[1].SubItems.Add(newClient);
        }

        private void turnBusy(Object mes)
        {
            
            foreach (ChatListSubItem remote in listbox_clients.Items[1].SubItems)
            {
                if (mes.ToString().Equals(remote.DisplayName))
                {
                    remote.IsVip = true;
                    remote.Status = ChatListSubItem.UserStatus.OffLine;
                    remote.Status = ChatListSubItem.UserStatus.Online;
                    return;
                }
            }
        }

        private void turnOffline(Object mes)
        {
            String deviceId = mes.ToString();
            foreach (ChatListSubItem remote in listbox_clients.Items[1].SubItems)
            {
                if (remote.DisplayName.Equals(deviceId))
                {
                    remote.IsVip = false;
                    remote.Status = ChatListSubItem.UserStatus.OffLine;
                    return;
                }
            }
        }
        private void turnFree(Object mes)
        {
            String deviceId = mes.ToString();
            foreach (ChatListSubItem remote in listbox_clients.Items[1].SubItems)
            {
                if (remote.DisplayName.Equals(deviceId))
                {
                    remote.IsVip = false;
                    remote.Status = ChatListSubItem.UserStatus.OffLine;
                    remote.Status = ChatListSubItem.UserStatus.Online;
                    return;
                }
            }
        }

      
        private void startServer(bool p)
        {
          if(p)
          {
              listbox_clients.Items[0].SubItems[0].NicName = MyConfig.INT_SERVER_PORT.ToString(); 
              listbox_clients.Items[0].SubItems[0].DisplayName = label_nickname.Text;
              listbox_clients.Items[0].SubItems[0].PlatformTypes = PlatformType.PC;
              listbox_clients.Items[0].SubItems[0].PersonalMsg = "启动正常";
              listbox_clients.Items[0].SubItems[0].Status = ChatListSubItem.UserStatus.Online;
              listbox_clients.Items[0].SubItems[0].IsVip = true;
          }
          else
          {
              listbox_clients.Items[0].SubItems[0].NicName = MyConfig.INT_SERVER_PORT.ToString();
              listbox_clients.Items[0].SubItems[0].DisplayName = label_nickname.Text;
              listbox_clients.Items[0].SubItems[0].PlatformTypes = PlatformType.PC;
              listbox_clients.Items[0].SubItems[0].PersonalMsg = "启动失败";
              listbox_clients.Items[0].SubItems[0].Status = ChatListSubItem.UserStatus.OffLine;
              listbox_clients.Items[0].SubItems[0].IsVip = false;
          }
        }

        private void addDesk()
        {
            if(deskForm==null)
            { 
                deskForm = new DeskForm(ctrlCenter);
                deskForm.Show();
                deskForm.setFullScreen();
                return ;
            }
            if(deskForm.IsDisposed)
            {
                deskForm = new DeskForm(ctrlCenter);
                deskForm.Show();
                deskForm.setFullScreen();
            }
        }
        private void removeDesk()
        {
            if(deskForm!=null)
            { 
                if(!deskForm.IsDisposed)
                { 
                deskForm.Close();
                }
            }
        }
    }
}
