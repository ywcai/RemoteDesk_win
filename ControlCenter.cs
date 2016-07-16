using System;
using System.Threading;
using ywcai.core.sokcet;
using ywcai.global.config;
using ywcai.util.draw;

namespace ywcai.core.control
{
    class ControlCenter : BothClientInf ,MasterInf , SlaveInf
    {
        public event Action<Object, Int32> updateInfo;
        public event Action<byte[]> updateDesk;
        public Boolean isLogining=false;
        public Boolean isCtrl = false;
        private MySocket mySocket=null;
        private Thread desksentThread = null;
        private String role ="normal";
        private CatchScreen cs = null;
 

        public ControlCenter()
        {
            if(mySocket==null)
            { 
            mySocket = MySocket.GetInstance();
            mySocket.coreProccessing += dataProccess;
            }
        }
        //both
        private void newThread()
        {
            Thread thread = new Thread(new ThreadStart(startRecive));
            thread.IsBackground = true;
            thread.Start();
        }
        private void startRecive()
        {
            mySocket.startRecive();
        }
        public void dataProccess(byte tag,string username,byte[] buf)
        {
            String msg = "";
            if (tag!=0x06)
            {
                msg = System.Text.Encoding.UTF8.GetString(buf);
                Console.WriteLine("revice data is " + msg);
            }
            switch (tag)
                {
                    case 0x01:
                        loginEnd(username, msg);
                        break;
                    case 0x02:
                        loginOutEnd(msg);
                        break;
                    case 0x03:
                        createEnd(msg);
                        break;
                    case 0x04:
                        disconnectEnd(msg);
                        break;
                    case 0x05:
                        responseCmd(msg);
                        break;
                    case 0x06:
                        drawDeskTop(buf);
                        break;
                    case 0x07:
                        updateLists(msg);
                        break;
                    default:
                        //do nothing
                        break;
            }
        }

        public void loginIn(string username, string nickname)
        {
            if (!isLogining)
            {
                mySocket.Conn();
            }
            if(mySocket.isConn)
            { 
            mySocket.sent((byte)0x01, username, nickname);
            newThread();
            }
        }

        public void loginOut(string nickname)
        {
            if(isLogining)
            { 
            mySocket.sent((byte)0x02,mySocket.user, nickname);
            }
        }
        public void updateLists(string lists)
        {
            updateInfo(lists, MyConfig.INT_UPDATEUI_LIST);
        }
        public void createLink(string index)
        {
            if(!isCtrl)
            { 
            mySocket.sent((byte)0x03, mySocket.user, index);
            }
        }
        public void disconnectLink()
        {
            if(isCtrl)
            { 
            mySocket.sent((byte)0x04, mySocket.user, "disconnect");
            }
        }
        public void loginEnd(string username,string result)
        {
            if (result.Equals("login_ok"))
            {
                mySocket.user = "ywcai";
                isLogining = true;
                updateInfo("登录成功", MyConfig.INT_UPDATEUI_TXBOX);
                return ;
            }
                mySocket.user = "";
                isLogining = false;
                mySocket.disConnect();
                updateInfo("登录失败", MyConfig.INT_UPDATEUI_TXBOX);
        }

        public void loginOutEnd(string result)
        {
            if (result.Equals("login_out_ok"))
            {
                mySocket.user = "";
                isLogining = false;
                mySocket.disConnect();
                updateInfo("清空列表", MyConfig.INT_CLEAR_LIST);
                updateInfo("清除桌面容器", MyConfig.INT_DELETE_DESK_CONTAINER);
                disconnectEnd("clear");
                return ;
            }
                updateInfo("未能正常退出，是否强制退出系统", MyConfig.INT_UPDATEUI_TXBOX);  
        }

        public void createEnd(string result)
        {

            if (result.Contains("master"))
            {
                isCtrl = true;
                setMaster();
                return ;
                //添加鼠标键盘事件;
                //对PIC容器进行初始化 
            }
            if (result.Equals("slave"))
            {
                isCtrl = true;
                setSlave();
                //开始发送桌面数据
                return;
            }
            if (result.Equals("has_link"))
            {
                isCtrl = false;
                updateInfo("创建远程桌面连接失败，原因是该用户已经在线上", MyConfig.INT_UPDATEUI_TXBOX);
                //开始发送桌面数据
                return;
            }
            isCtrl = false;
            updateInfo("创建远程桌面连接失败，原因未知 : "+result, MyConfig.INT_UPDATEUI_TXBOX);
        }
        private void setMaster()
        {
            role = "master";
            updateInfo("连接成功，初始化容器，切换为Master", MyConfig.INT_UPDATEUI_TXBOX);
            updateInfo("初始化容器", MyConfig.INT_CREATE_DESK_CONTAINER);
            sendCmd();
        }

        private void setSlave()
        {
            role = "slave";
            //添加对cmd的响应
            //都是耗时操作，分别开两个线程；
            updateInfo("连接成功，初始化容器，切换为Slave", MyConfig.INT_UPDATEUI_TXBOX);
            cs = new CatchScreen();
            desksentThread =new Thread(new ThreadStart(sendDesktop));
            desksentThread.IsBackground = true;
            desksentThread.Start();
        }
        public void disconnectEnd(string result)
        {
            //断开连接；
            //停止发送IMG和CMD数据。等待停止发送数据的方法
            isCtrl = false;
            if (result.Equals("not_link"))
            {
                role = "normal";
                updateInfo("该客户端没有建立远程控制连接", MyConfig.INT_UPDATEUI_TXBOX);
                return;
            }
            if(role.Equals("master"))
            {
                role = "normal";
                updateInfo(result, MyConfig.INT_DELETE_DESK_CONTAINER);
                updateInfo("master退出远程连接成功,切换为normal", MyConfig.INT_UPDATEUI_TXBOX);
                return ;
            }
            if (role.Equals("slave"))
            {
                try
                {
                    //desksentThread.Abort();
                }
                catch
                {
                    updateInfo("中断图形数据传输线程时发生异常", MyConfig.INT_UPDATEUI_TXBOX);
                }
                role = "normal";
                updateInfo("slave退出远程连接成功,切换为normal", MyConfig.INT_UPDATEUI_TXBOX);
                return ;
            }
        }
        //master
        public void sendCmd()
        {
            if (!isCtrl)
            {
                return;
            }

            mySocket.sent((byte)0x05, mySocket.user, "this is cmd data ");
        }

        public void drawDeskTop(byte[] deskTop)
        {
            //开始渲染desk
            updateDesk(deskTop);
        }


        //slave
        public void responseCmd(string cmd)
        {
           //处理控制端传送的键盘鼠标事件;
        }
        public void sendDesktop()
        {
            //新开线程处理被控端的桌面数据;
                if(!isCtrl)
                {
                return ;
                }
                Byte[] desktop = cs.catDeskTop();
                mySocket.sent((byte)0x06, mySocket.user, desktop);
               Thread.Sleep(100);
               sendDesktop();
        }
    }
}
