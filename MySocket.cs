using System;
using System.Net.Sockets;
using ywcai.core.protocol;
using ywcai.global.config;


namespace ywcai.core.sokcet
{
    class MySocket
    {
        public event Action<Object, Int32> updateInfo;
        //public event Action<byte[]> updateDesk;

        private static MySocket instance = null;
        private static object _lock = new object();
        //private Boolean isLogining = false;
        private Socket client = null;
        private String remoteIP = MyConfig.STR_SERVER_IP;
        private Int32 remotePort = MyConfig.INT_SERVER_PORT;
        public Boolean isConn = false;
        public String user = "";

        private MySocket()
        {

        }
        public static MySocket GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new MySocket();
                    }
                }
            }
            return instance;
        }

        public void Conn()
        {
            if (!isConn)
            {
                try
                {
                    client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    client.Connect(remoteIP, remotePort);
                    client.ReceiveBufferSize = MyConfig.INT_SOCKET_BUFFER_SIZE;
                    client.SendBufferSize = MyConfig.INT_SOCKET_BUFFER_SIZE;
                    isConn = true;
                    updateInfo("socket连接成功", MyConfig.INT_UPDATEUI_TXBOX);
                }
                catch (Exception)
                {
                    updateInfo("创建socket出现异常", MyConfig.INT_UPDATEUI_TXBOX);
                }
            }
            else
            {
                updateInfo("socket已经连接", MyConfig.INT_UPDATEUI_TXBOX);
            }
        }
        public void disConnect()
        {
            if (!isConn)
            {
                updateInfo("已退出登录", MyConfig.INT_UPDATEUI_TXBOX);
                return;
            }
                try
                {
                    client.Close(MyConfig.INT_SOCKET_TIMEOUT);
                    isConn = false;
                }
                catch (Exception)
                {
                    updateInfo("断开socket出现异常", MyConfig.INT_UPDATEUI_TXBOX);
                }
            updateInfo("退出登录成功", MyConfig.INT_UPDATEUI_TXBOX);
        }

        public void sent(byte tag, String username, Object data)
        {
            if (!isConn)
            {
                updateInfo("您还没有连接网络", MyConfig.INT_UPDATEUI_TXBOX);
                return ;
            }
            byte[] buf = null;
            Encode encode = new Encode();
            if (tag == 0x06)
            {
                buf = encode.enImg(tag, username, (byte[])data);
            }
            else
            {
                buf = encode.enString(tag, username, data.ToString());
            }
            try
            {
                client.Send(buf);
            }
            catch
            {
                updateInfo("数据发送异常", MyConfig.INT_UPDATEUI_TXBOX);
            }
        }

        public byte[] reviced()
        {
            byte[] buffer = new byte[MyConfig.INT_SOCKET_BUFFER_SIZE];
            if (isConn)
            {
                try
                {
                    client.Receive(buffer);
                }
                catch
                {
                    updateInfo("数据接收异常", MyConfig.INT_UPDATEUI_TXBOX);
                }
            }
            else
            {
                updateInfo("socket未连接，无法接收数据", MyConfig.INT_UPDATEUI_TXBOX);
            }
            
            return buffer;
        }
    }
}
