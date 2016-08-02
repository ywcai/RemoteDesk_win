using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using ywcai.core.sokcet;
using ywcai.global.config;
using ywcai.util.draw;

namespace ywcai.core.control
{
    class ControlCenter : BothClientInf ,MasterInf , SlaveInf
    {
        public event Action<Object, Int32> updateInfo;
        public event Action<Bitmap> updateDesk;
        public Boolean isLogining=false;
        public Boolean isCtrl = false;
        private MySocket mySocket=null;
        private Thread desksentThread = null;
        private String role ="normal";
        private BinaryFormatter bf = new BinaryFormatter();
        private ImgRecovery ir = new ImgRecovery();
        private Object _lock = new Object();
        public ControlCenter()
        {
            if(mySocket==null)
            { 
                lock(_lock)
                { 
                mySocket = MySocket.GetInstance();
                mySocket.coreProccessing += dataProccess;
                }
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
        public void dataProccess(byte reqType,string token,byte[] buf)
        {
            String msg = "";
            if (reqType != MyConfig.REQ_TYPE_DESKTOP_SWITCH)
            {
                msg = System.Text.Encoding.UTF8.GetString(buf);
                //Console.WriteLine("revice data is " + msg);
            }
            switch (reqType)
                {
                    case MyConfig.REQ_TYPE_USER_LOGIN_IN:
                        loginEnd(token, msg);
                        break;
                    case MyConfig.REQ_TYPE_USER_LOGIN_OUT:
                        loginOutEnd(msg);
                        break;
                    case MyConfig.REQ_TYPE_DESK_LINK_OPEN:
                        createEnd(msg);
                        break;
                    case MyConfig.REQ_TYPE_DESK_SHOWDOWN:
                        disconnectEnd(msg);
                        break;
                    case MyConfig.REQ_TYPE_CONTROL_CMD:
                        responseCmd(msg);
                        break;
                    case MyConfig.REQ_TYPE_DESKTOP_SWITCH:
                        drawDeskTop(buf);
                        break;
                    case MyConfig.REQ_TYPE_CLIENT_LIST_UPDATE:
                        updateLists(msg);
                        break;
                default:
                        //do nothing
                        break;
            }
        }

        public void loginIn(string token, string content)
        {
            if (!isLogining)
            {
                mySocket.Conn();
            }
            if(mySocket.isConn)
            { 
            mySocket.sent((byte)MyConfig.REQ_TYPE_USER_LOGIN_IN,MyConfig.PROTOCOL_HEAD_NOT_TOKEN,token, content);
            newThread();
            }
        }

        public void loginOut(string nickname)
        {
            if(isLogining)
            { 
            mySocket.sent((byte)MyConfig.REQ_TYPE_USER_LOGIN_OUT, MyConfig.PROTOCOL_HEAD_HAS_TOKEN,mySocket.token, nickname);
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
            mySocket.sent((byte)MyConfig.REQ_TYPE_DESK_LINK_OPEN, MyConfig.PROTOCOL_HEAD_HAS_TOKEN, mySocket.token, index);
            }
        }
        public void disconnectLink()
        {
            if(isCtrl)
            { 
            mySocket.sent((byte)MyConfig.REQ_TYPE_DESK_SHOWDOWN, MyConfig.PROTOCOL_HEAD_HAS_TOKEN, mySocket.token, "disconnect");
            }
        }
        public void loginEnd(string pToken,string result)
        {
            if (result.Contains("login_ok"))
            {

                mySocket.token = pToken;
                isLogining = true;
                updateInfo("登录成功", MyConfig.INT_UPDATEUI_TXBOX);

                String[] str = result.Split('#');
                if(str.Length>0&&!str[1].Equals(""))
                { 
                updateInfo(str[1], MyConfig.INT_INIT_CLIENT_LIST);
                }
                return ;
            }
                mySocket.token = "";
                isLogining = false;
                mySocket.disConnect();
                updateInfo("登录验证令牌失败", MyConfig.INT_UPDATEUI_TXBOX);
        }

        public void loginOutEnd(string result)
        {
            if (result.Equals("login_out_ok"))
            {
                mySocket.token = "";
                isLogining = false;
                mySocket.disConnect();
                updateInfo("离线", MyConfig.INT_CLEAR_LIST);
                //updateInfo("清除桌面容器", MyConfig.INT_DELETE_DESK_CONTAINER);
                //disconnectEnd("clear");
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
            if (result.Contains("slave"))
            {
                isCtrl = true;
                setSlave();
                //开始发送桌面数据
                return;
            }
            if (result.Contains("has_link"))
            {
                isCtrl = false;
                updateInfo("创建远程桌面连接失败，原因是该用户已经在线上", MyConfig.INT_UPDATEUI_TXBOX);
                return;
            }
            isCtrl = false;
            updateInfo("创建远程桌面连接失败，原因未知 : "+result, MyConfig.INT_UPDATEUI_TXBOX);
        }
        private void setMaster( )
        {
            updateInfo("连接成功，初始化容器，切换为Master", MyConfig.INT_UPDATEUI_TXBOX);

            updateInfo("add desk container", MyConfig.INT_CREATE_DESK_CONTAINER);


        }

        private void setSlave( )
        {
            //添加对cmd的响应
            //都是耗时操作，分别开两个线程；
            updateInfo("连接成功，初始化容器，切换为Slave", MyConfig.INT_UPDATEUI_TXBOX);

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
                    desksentThread.Abort();
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
        public void sendCmd(String cmd)
        {
            if (!isCtrl)
            {
                role = "normal";
                updateInfo("当前没有连接,切换为normal模式", MyConfig.INT_UPDATEUI_TXBOX);
                return;
            }
            mySocket.sent((byte)MyConfig.REQ_TYPE_CONTROL_CMD, MyConfig.PROTOCOL_HEAD_HAS_TOKEN, mySocket.token, cmd);
        }


        public void drawDeskTop(byte[] deskTop)
        {
            //反序列化
            Bitmap deskImg = null;
            using (MemoryStream ms = new MemoryStream(deskTop))
            {
                List<ImgEntity> imgs = (List<ImgEntity>)bf.Deserialize(ms);
                deskImg = ir.recovery(imgs);
            }
            if(deskImg==null)
            {
                updateInfo("接收初始化数据错误",MyConfig.INT_UPDATEUI_TXBOX);
            }
            else
            {
                //开始渲染desk
                updateDesk(deskImg);
            }

        }

        //slave
        public void responseCmd(string cmd)
        {
            updateInfo("收到指令 : "+cmd, MyConfig.INT_UPDATEUI_TXBOX);
            ResponseEvent.exeEvent(cmd);
        }

        public void sendDesktop()
        {
               List<ImgEntity> deskList = null;
               CatchScreen cs = new CatchScreen();
               List<ImgEntity> changes = null;
               ImgCompara imgCompara = new ImgCompara();
              //新开线程处理被控端的桌面数据;
              while (isCtrl&&isLogining&&mySocket.isConn)
              {
                deskList = cs.getImgs();
                changes = imgCompara.compara(deskList);
                if(changes.Count>0)
                { 
                    using (MemoryStream ms = new MemoryStream())
                    {
                       BinaryFormatter bf = new BinaryFormatter();
                       bf.Serialize(ms, changes);
                       Byte[] imgBuffer = new Byte[ms.Length];
                       ms.Seek(0, SeekOrigin.Begin);
                       ms.Read(imgBuffer, 0, (Int32)ms.Length);
                       mySocket.sent((byte)MyConfig.REQ_TYPE_DESKTOP_SWITCH, MyConfig.PROTOCOL_HEAD_HAS_TOKEN, mySocket.token, imgBuffer);
                       //Console.WriteLine(ms.Length);
                    }
                    if(changes.Count>=(MyConfig.INT_BLOCK_X_COUNT*MyConfig.INT_BLOCK_Y_COUNT*2/3))
                    {
                        //超过2/3的时候，切换低频率
                        Thread.Sleep(MyConfig.INT_DESKTOP_REFLUSH_FREQUENCY_LOW);
                    }
                    else if(changes.Count >= (MyConfig.INT_BLOCK_X_COUNT * MyConfig.INT_BLOCK_Y_COUNT * 1 / 3))
                    {
                        //数据变化1/3到2/3之间，则切换为中频
                        Thread.Sleep(MyConfig.INT_DESKTOP_REFLUSH_FREQUENCY_NORMAL);
                    }
                    else
                    {
                        //低于1/3数据变换，则切换为高频
                        Thread.Sleep(MyConfig.INT_DESKTOP_REFLUSH_FREQUENCY_HIGHT);
                    }
                }
                else
                {
                    //没有数据变换，则休眠1秒
                    Thread.Sleep(MyConfig.INT_DESKTOP_REFLUSH_FREQUENCY_SLEEP);
                }
             }
             Console.WriteLine("退出数据发送, isctrl:"+isCtrl +" isLogin:"+isLogining+" isconn:"+mySocket.isConn);
        }
    }
}
