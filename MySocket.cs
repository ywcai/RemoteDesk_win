using System;
using System.Net.Sockets;
using ywcai.core.protocol;
using ywcai.global.config;
using ywcai.util.buf;

namespace ywcai.core.sokcet
{
    class MySocket
    {
        public event Action<Object, Int32> updateInfo;
        public event Action<byte,string,byte[]> coreProccessing;

        private static MySocket instance = null;
        private static object _lock = new object();
        //private Boolean isLogining = false;
        private Socket client = null;
        private String remoteIP = MyConfig.STR_SERVER_IP;
        private Int32 remotePort = MyConfig.INT_SERVER_PORT;
        public Boolean isConn = false;
        public String user = "";
        private Decode decode = new Decode();
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
                    client.Close();
                    isConn = false;
                    updateInfo("退出登录成功", MyConfig.INT_UPDATEUI_TXBOX);
                }
                catch (Exception)
                {
                    isConn = false;
                    updateInfo("断开socket出现异常,可能是已经退出登录,", MyConfig.INT_UPDATEUI_TXBOX);
                }
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
                disConnect();
                updateInfo("发送数据异常，退出线程", MyConfig.INT_UPDATEUI_TXBOX);
                return;
            }
        }
 
        public void startRecive()
        {
            BufferState bufferState = new BufferState();
            bufferState.init();
            while (isConn)
            {
                assembleData(bufferState);
            }
            bufferState.init();
            updateInfo("您的网络已断开，退出数据接收线程", MyConfig.INT_UPDATEUI_TXBOX);
        }
        private void assembleData(BufferState bufState)
        {
            if(!bufState.hasRemaing)
            {
                try
                { 
                bufState.remaining = client.Receive(bufState.buf);
                bufState.hasRemaing = true;
                }
                catch
                {
                    disConnect();
                    updateInfo("接收数据异常，退出线程", MyConfig.INT_UPDATEUI_TXBOX);
                    return ;
                }
            }
            if(bufState.hasHead)
            {
                bufState.target = decode.getPackLen(bufState.buf, bufState.bufPos);
                bufState.pending = bufState.target;
                bufState.temp= new byte[bufState.target];
            }
            if(bufState.pending == bufState.remaining)
            {
                bufState.temp = copyArray(bufState.buf, bufState.bufPos, bufState.temp, bufState.tempPos, bufState.remaining);

                byte tag = decode.getTag(bufState.temp);
                String usernmae = decode.getUsername(bufState.temp);
                byte[] result = decode.getData(bufState.temp);
                coreProccessing(tag,usernmae,result);

                bufState.init();
            }

            if (bufState.pending < bufState.remaining)
            {
                bufState.temp = copyArray(bufState.buf, bufState.bufPos, bufState.temp, bufState.tempPos, bufState.pending);

                byte tag = decode.getTag(bufState.temp);
                String usernmae = decode.getUsername(bufState.temp);
                byte[] result = decode.getData(bufState.temp);
                coreProccessing(tag, usernmae, result);

                bufState.skip();
            }

            if (bufState.pending > bufState.remaining)
            {
                bufState.temp = copyArray(bufState.buf, bufState.bufPos, bufState.temp, bufState.tempPos, bufState.remaining);
                //数据没有接收完整，重新接收数据

                bufState.connect();
            }

        }

        private byte[] copyArray(byte[] src,Int32 srcIndex,byte[] dest,Int32 destPos,Int32 copyLen)
        {
            for(int i=0; i<copyLen;i++)
            {
                dest[destPos+i] = src[srcIndex + i];
            }
            return dest;
        }
    }
}
