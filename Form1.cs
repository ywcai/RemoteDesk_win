using System;

using System.Drawing;
using System.IO;

using System.Windows.Forms;
using ywcai.core.control;
using ywcai.core.sokcet;
using ywcai.global.config;

namespace ywcai.core.veiw
{
    public partial class Form1 : Form
    {
        private ControlCenter ctrlCenter = new ControlCenter();
        private MySocket mySocket = MySocket.GetInstance();
        private delegate void UiEventsHandler(String mes, Int32 method);//普通UI更新委托
        private delegate void DeskEventsHandler(byte[] imgBuffer);//持续渲染屏幕
        private Panel panel = new Panel();
        private PictureBox deskTop = new PictureBox();
        public Form1()
        {
            InitializeComponent();
            mySocket.updateInfo += updateInfo;
            ctrlCenter.updateInfo += updateInfo;
            ctrlCenter.updateDesk += updateDesk;
            //Thread thread= new Thread(new ThreadStart(waitSessionList));
            //thread.IsBackground = true;
            //thread.Start();
        }
        private void updateDesk(byte[] imgbuffer)
        {
            if (InvokeRequired)
            {
                DeskEventsHandler uImg = setDeskTop;
                object[] pList = { imgbuffer };
                BeginInvoke(uImg, pList);//异步执行了，不用加同步锁
            }
            else
            {
                setDeskTop(imgbuffer);
            }
        }
        private void updateInfo(Object pMes, Int32 method)
        {
            if (InvokeRequired)
            {
                UiEventsHandler mh = setInfo;
                object[] pList = { pMes.ToString(), method };
                BeginInvoke(mh, pList);//异步执行了，不用加同步锁
            }
            else
            {
                setInfo(pMes.ToString(), method);
            }
        }
        private void setDeskTop(byte[] imgBuffer)
        {
            MemoryStream ms = new MemoryStream(imgBuffer);
            Image image = System.Drawing.Image.FromStream(ms);
            setDeskTop(image);
        }
        private void setDeskTop(Image img)
        {
            deskTop.Image = img;
        }
        private void setInfo(String mes, Int32 method)
        {
            switch (method)
            {
                case MyConfig.INT_CLEAR_LIST:
                    list_clients.Clear();
                    break;
                case MyConfig.INT_UPDATEUI_LIST:
                    list_clients.Clear();
                    String[] clientList = mes.Split(new char[] { ',' });
                    list_clients.BeginUpdate();
                    for (int i = 0; i < clientList.Length; i++)
                    {
                        String[] clientInfo = clientList[i].Split(new char[] { '|' });
                        if (!clientInfo[1].Equals(tx_username.Text))
                        {
                            ListViewItem lvi = new ListViewItem();
                            lvi.Text = clientInfo[0] + "|别名：" + clientInfo[1] + " 地址:" + clientInfo[2];
                            lvi.Tag = clientInfo[0];
                            list_clients.Items.Add(lvi);
                        }
                    }
                    list_clients.EndUpdate();
                    break;
                case MyConfig.INT_UPDATEUI_TXBOX:
                    tx_info.Text = mes;
                    break;
                case MyConfig.INT_UPDATEUI_LABLE_STATUS:
                    lable_status.Text = mes;
                    break;
                case MyConfig.INT_CREATE_DESK_CONTAINER:
                    createVartualDesk(mes);
                    break;
                case MyConfig.INT_DELETE_DESK_CONTAINER:
                    deleteDesk();
                    break;
                default:
                    //do nothing;
                    break;
            }
        }
        private void connect(String index)
        {
            ctrlCenter.createLink(index);
        }
        private void cacalConn()
        {
            ctrlCenter.disconnectLink();
        }
        private void createVartualDesk(String size)
        {
            panel.Visible =true;
            deskTop.Visible = true;
            panel.AutoScroll = true;
            panel.Top = 0;
            panel.Left = 0;
            panel.AutoSize = true;
            panel.Parent = this;
            panel.Dock = DockStyle.Fill;
            deskTop.Width = 1024;
            deskTop.Height = 786;
            deskTop.Parent = panel;
            deskTop.Dock = DockStyle.Left|DockStyle.Top;
        }
        private void deleteDesk()
        {
            panel.Visible = false;
            deskTop.Visible = false;
        }
        private void login_Click(object sender, EventArgs e)
        {
            if (ctrlCenter.isLogining)
            {
                updateInfo("已经登录", MyConfig.INT_UPDATEUI_TXBOX);
                return;
            }
            String nickname = tx_username.Text;
            ctrlCenter.loginIn("ywcai", nickname);
        }
        private void loginout_Click(object sender, EventArgs e)
        {
            if (!ctrlCenter.isLogining)
            {
                updateInfo("还未登录", MyConfig.INT_UPDATEUI_TXBOX);
                return ;
            }
            String nickname = tx_username.Text;
            ctrlCenter.loginOut(nickname);
        }
        private void list_clients_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ctrlCenter.isCtrl)
            {
                updateInfo("已经进行远程控制", MyConfig.INT_UPDATEUI_TXBOX);
                return;
            }
            if (list_clients.SelectedItems.Count <= 0)
            {
                updateInfo("需要先选定要连接的主机", MyConfig.INT_UPDATEUI_TXBOX);
                return;
            }
            Int32 index = list_clients.SelectedIndices[0];
            String order = list_clients.Items[index].Tag.ToString();
            updateInfo("正在与salve: " + order + " | " + list_clients.Items[index].Text + "建立连接", MyConfig.INT_UPDATEUI_TXBOX);
            connect(order);
        }
        private void createLink_Click(object sender, EventArgs e)
        {
            if (ctrlCenter.isCtrl)
            {
                updateInfo("已经进行远程控制", MyConfig.INT_UPDATEUI_TXBOX);
                return;
            }
            if (list_clients.SelectedItems.Count <= 0)
            {
                updateInfo("需要先选定要连接的主机", MyConfig.INT_UPDATEUI_TXBOX);
                return;
            }
            Int32 index = list_clients.SelectedIndices[0];
            String order = list_clients.Items[index].Tag.ToString();
            updateInfo("正在与salve: " + order + " , " + list_clients.Items[index].Text + "建立连接", MyConfig.INT_UPDATEUI_TXBOX);
            connect(order);
        }

        private void disConnect_Click(object sender, EventArgs e)
        {
            if(!ctrlCenter.isCtrl)
            {
                updateInfo("未和任何远程主机连接", MyConfig.INT_UPDATEUI_TXBOX);
                return ;
            }
            cacalConn();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //CatchScreen cs = new CatchScreen();
            // byte[] b=cs.catDeskTop();
            // Console.WriteLine(b.Length+":"+b.Last());
        }
    }
}
