using System;
using System.Drawing;
using System.Windows.Forms;
using ywcai.core.control;
using ywcai.core.sokcet;
using ywcai.global.config;

using ywcai.util.draw;

namespace ywcai.core.veiw
{
    public partial class Form1 : Form  
    {
        private Boolean maxScreen=false;
        private ImgCompara imgCompara = new ImgCompara();
        private ControlCenter ctrlCenter = new ControlCenter();
        private MySocket mySocket = MySocket.GetInstance();
        private delegate void UiEventsHandler(String mes, Int32 method);//普通UI更新委托
        private delegate void DeskEventsHandler(Bitmap img);//持续渲染屏幕
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



        private void updateDesk(Bitmap img)
        {
            if (InvokeRequired)
            {
                DeskEventsHandler uImg = setDeskTop;
                object[] pList = { img };
                BeginInvoke(uImg, pList);//异步执行了，不用加同步锁
            }
            else
            {
                setDeskTop(img);
            }
        }

        private void updateInfo(Object pMes, Int32 method)
        {
            if (InvokeRequired)
            {
                UiEventsHandler mh = setInfo;
                object[] pList = { pMes.ToString(), method };
                //BeginInvoke(mh, pList);//异步执行了，不用加同步锁
                Invoke(mh, pList);//同步执行了
            }
            else
            {
                setInfo(pMes.ToString(), method);
            }
        }
        private void setDeskTop(Bitmap img)
        {
            deskTop.Width = img.Width;
            deskTop.Height = img.Height;
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
                case MyConfig.INT_CREATE_DESK_CONTAINER:
                    createVartualDesk();
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
        private void createVartualDesk()
        {
            panel.Visible =true;
            deskTop.Visible = true;
            panel.AutoScroll = true;
            panel.Top = 0;
            panel.Left = 0;
            panel.AutoSize = false;
            panel.Parent = this;
            panel.Dock = DockStyle.Fill;

            deskTop.Parent = panel;
            deskTop.Dock = DockStyle.Left|DockStyle.Top;
            //deskTop.BackColor = Color.AliceBlue;
            regMouseEvent();

            panel.BringToFront();
            toMaxScreen();

        }
        private void regMouseEvent()
        {
            deskTop.MouseClick += vClick;
            deskTop.MouseDoubleClick += vDoubleClick;
            deskTop.MouseDown += vDown;
            deskTop.MouseUp += vUp;
            deskTop.MouseWheel += vWheel;
            deskTop.MouseMove += vMove;
        }
        private void unRegMouseEvent()
        {
            deskTop.MouseClick -= vClick;
            deskTop.MouseDoubleClick -= vDoubleClick;
            deskTop.MouseDown -= vDown;
            deskTop.MouseUp -= vUp;
            deskTop.MouseWheel -= vWheel;
            deskTop.MouseMove -= vMove;
        }

        private void vClick(object sender, MouseEventArgs e)
        {
            String cmd = "mouse:click:"+e.Button+","+e.X+","+e.Y;
            sendEvent(cmd);
        }

        private void vDoubleClick(object sender, MouseEventArgs e)
        {
            String cmd = "mouse:dclick:" + e.Button + "," + e.X + "," + e.Y;
            sendEvent(cmd);
        }

        private void vDown(object sender, MouseEventArgs e)
        {
            String cmd = "mouse:down:" + e.Button + "," + e.X + "," + e.Y;
            sendEvent(cmd);
        }

        private void vUp(object sender, MouseEventArgs e)
        {
            String cmd = "mouse:up:" + e.Button + "," + e.X + "," + e.Y;
            sendEvent(cmd);
        }

        private void vWheel(object sender, MouseEventArgs e)
        {
            String cmd = "mouse:wheel:" + e.Delta;
            sendEvent(cmd);
        }

        private void vMove(object sender, MouseEventArgs e)
        {
            
            String cmd = "mouse:move:"+ e.X + "," + e.Y;
            sendEvent(cmd);
        }
        private void sendEvent(String cmd)
        {
            
            ctrlCenter.sendCmd(cmd);
        }

        private void toMaxScreen()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.menu.Visible = true;
            this.menu.BringToFront();
            this.menu.Top = -this.menu.Height+1;

            
            this.menu.MouseHover += showMenu;
            maxScreen = true;
            
        }

        private void showMenu(object sender, EventArgs e)
        {
            this.menu.MouseHover -= showMenu;
            this.menu.Top = 0;
            this.menu.MouseLeave += hideMenu;
        }

        private void hideMenu(object sender, EventArgs e)
        {
            if(Control.MousePosition.X<menu.Left|| Control.MousePosition.X>( menu.Left+menu.Width)||Control.MousePosition.Y>(menu.Top+menu.Height))
            {
            //Console.WriteLine(Control.MousePosition.X+":"+ menu.Left);
            this.menu.MouseLeave -= hideMenu;
            this.menu.Top = -this.menu.Height+1;
            this.menu.MouseHover += showMenu;
            }
        }

        private void toNormalScreen()
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Normal;
            this.menu.Visible = false;
            maxScreen = false;
            this.deskTop.MouseDoubleClick += changMaxScreen;
        }

        private void changMaxScreen(object sender, MouseEventArgs e)
        {
            toMaxScreen();
            this.deskTop.MouseDoubleClick -= changMaxScreen;
        }

        private void toMinScreen()
        {
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.WindowState = FormWindowState.Minimized;
            //this.menu.Visible = false;
           // maxScreen = false;
        }

        private void deleteDesk()
        {
            unRegMouseEvent();
            panel.Visible = false;
            deskTop.Visible = false;
            toNormalScreen();
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
            //byte字节中涉及了255个不同字符，且几乎呈均匀分布，赫夫曼编码压缩无效果。
            //CatchScreen cs = new CatchScreen();
            //List<ImgEntity> desks = cs.getImgs();
            //using (MemoryStream ms = new MemoryStream())
            //{
            //    BinaryFormatter bf = new BinaryFormatter();
            //    bf.Serialize(ms, desks);
            //    Byte[] imgBuffer = new Byte[ms.Length];
            //    ms.Seek(0, SeekOrigin.Begin);
            //    ms.Read(imgBuffer, 0, (Int32)ms.Length);
            //    //Console.WriteLine(imgBuffer.Length);
            //    // updateInfo(byteToString(imgBuffer),MyConfig.INT_UPDATEUI_TXBOX);
            //    Frequency(imgBuffer);
            //}
            if(!maxScreen)
            {
                toMaxScreen();
            }
            else        
            {
                toNormalScreen();
            }


        }

        private void normal_Click(object sender, EventArgs e)
        {
            toNormalScreen();
        }

        private void min_Click(object sender, EventArgs e)
        {
            toMinScreen();
        }
        //private void Frequency(Byte[] s)
        //{
        //    TimeSpan ts1 = new TimeSpan(DateTime.Now.Ticks);
        //    //计算每个字节出现的频率。
        //    Int32[] frequency = new Int32[256];
        //    for (int i = 0; i < s.Length; i++)
        //    {
        //      //  if(s[i]<5)
        //      //  { 
        //        frequency[s[i]]++;
        //     //   }
        //    }

        //    //向上构建二叉树
        //    HfmanTree hf = new HfmanTree();
        //    Node hfman = hf.buildTree(frequency);
        //    //loop through遍历二叉树，得到重1开始的编码字典。
        //    preLoop(hfman);
        //    TimeSpan ts2 = new TimeSpan(DateTime.Now.Ticks);
        //    //Console.WriteLine(arr[255] + " | " + arr[0]);
        //    //查看构建耗时
        //    Console.WriteLine(ts2.TotalMilliseconds - ts1.TotalMilliseconds);
        //}
        //前序遍历
        //private void preLoop(Node hfman)
        //{

        //    //Dictionary<byte, String> map = new Dictionary<byte,String>();



        //    if (!hfman.native)
        //    {
        //        hfman.left.code = (hfman.code <<1) | hfman.left.code;
        //        hfman.right.code = (hfman.code << 1) | hfman.right.code;
        //        preLoop(hfman.left);
        //        preLoop(hfman.right);
        //    }
        //    else
        //    {
        //        Console.WriteLine(hfman.key+"|"+ hfman.weight+"|"+ Convert.ToString(hfman.code,2));
        //    }

        //}

    }
}
