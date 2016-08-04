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
        public event Action<byte, string, byte[]> coreProccessing;

        private static MySocket instance = null;
        private static object _lock = new object();
        //private Boolean isLogining = false;
        private Socket client = null;
        private String remoteIP = MyConfig.STR_SERVER_IP;
        private Int32 remotePort = MyConfig.INT_SERVER_PORT;
        public Boolean isConn = false;
        public String token = "";
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
            updateInfo("中断连接，重置UI", MyConfig.INT_CHANGE_OUT);
            if (!isConn)
            {
                updateInfo("Sokect已断开", MyConfig.INT_UPDATEUI_TXBOX);
                return;
            }
            try
            {
                client.Close();
                isConn = false;
                updateInfo("Sokect连接断开成功", MyConfig.INT_UPDATEUI_TXBOX);
            }
            catch (Exception)
            {
                isConn = false;
                updateInfo("断开socket出现异常,可能是已经退出登录,", MyConfig.INT_UPDATEUI_TXBOX);
            }
        }

        public void sent(byte pReqType,byte hasToken,String pToken, Object data)
        {
            if (!isConn)
            {
                updateInfo("您还没有连接网络", MyConfig.INT_UPDATEUI_TXBOX);
                return;
            }
            byte[] buf = null;
            Encode encode = new Encode();
            if (pReqType == MyConfig.REQ_TYPE_DESKTOP_SWITCH)
            {
                buf = encode.enImg(pReqType, hasToken, pToken, (byte[])data);
            }
            else
            {
                buf = encode.enString(pReqType, hasToken,pToken, data.ToString());
            }
            try
            {
                client.Send(buf);
            }
            catch
            {
                disConnect();
                updateInfo("发送数据异常，退出Socket连接", MyConfig.INT_UPDATEUI_TXBOX);
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
            Console.WriteLine("您的网络已断开，退出数据接收线程");
            updateInfo("您的网络已断开，退出数据接收线程", MyConfig.INT_UPDATEUI_TXBOX);
        }
        private void assembleData(BufferState bufState)
        {
            //do

            if (!bufState.hasRemaing)
            {
                try
                {
                    //Console.WriteLine("开始接收数据，");
                    bufState.remaining = client.Receive(bufState.buf);
                    //Console.WriteLine("接收数据完成");
                    //Console.WriteLine("remaining: "+bufState.remaining);
                    bufState.hasRemaing = true;
                }
                catch
                {
                    disConnect();
                    updateInfo("接收数据异常，退出Socket连接", MyConfig.INT_UPDATEUI_TXBOX);
                    bufState.init();
                    return;
                }
            }
            if (bufState.hasHead)
            {
                //Console.WriteLine("remaining : " + bufState.remaining);
                while (bufState.remaining < MyConfig.INT_PACKAGE_HEAD_LEN)
                {
                    //复制下一个buf的头部;
                    MyUtil.copyArray(bufState.buf, bufState.bufPos, bufState.buf, 0, bufState.remaining);
                    //接收数据组合正常头部包;
                    Int32 size = client.Receive(bufState.buf, bufState.remaining, MyConfig.INT_SOCKET_BUFFER_SIZE - bufState.remaining, SocketFlags.None);
                    bufState.remaining = bufState.remaining + size;
                    bufState.bufPos = 0;
                    bufState.tempPos = 0;
                }
                byte headFlag = decode.getHeadFlag(bufState.buf, bufState.bufPos);
                byte dataType = decode.getDataType(bufState.buf, bufState.bufPos);
                byte reqType = decode.getReqType(bufState.buf, bufState.bufPos);
                if (headFlag == MyConfig.PROTOCOL_HEAD_FLAG && reqType > 0 && reqType < 8)
                {
                    bufState.target = decode.getPackLen(bufState.buf, bufState.bufPos);
                    if (bufState.target < MyConfig.INT_PACKAGE_HEAD_LEN || bufState.target >= Int32.MaxValue)
                    {
                        Console.WriteLine("bufState.target err : " + bufState.target);
                        bufState.drop();
                    }
                    else
                    {
                        bufState.isRightPackage = true;
                        bufState.pending = bufState.target;
                        bufState.temp = new byte[bufState.target];
                    }
                }
                else
                {
                    Console.WriteLine("dataType err : " + dataType);
                    bufState.drop();
                }
            }

            if (bufState.pending == bufState.remaining && bufState.isRightPackage == true)
            {
                MyUtil.copyArray(bufState.buf, bufState.bufPos, bufState.temp, bufState.tempPos, bufState.remaining);
                byte reqType = decode.getReqType(bufState.temp, 0);
                String token = decode.getToken(bufState.temp);
                byte[] result = decode.getData(bufState.temp);
                //Console.WriteLine("temp: " + bufState.temp.Length);
                coreProccessing(reqType, token, result);
                bufState.init();
            }

            if (bufState.pending < bufState.remaining && bufState.isRightPackage == true)
            {
                MyUtil.copyArray(bufState.buf, bufState.bufPos, bufState.temp, bufState.tempPos, bufState.pending);
                byte reqType = decode.getReqType(bufState.temp, 0);
                String token = decode.getToken(bufState.temp);
                byte[] result = decode.getData(bufState.temp);
                //Console.WriteLine("temp:  " + bufState.temp.Length);
                coreProccessing(reqType, token, result);
                bufState.skip();
            }
            if (bufState.pending > bufState.remaining && bufState.isRightPackage == true)
            {
                MyUtil.copyArray(bufState.buf, bufState.bufPos, bufState.temp, bufState.tempPos, bufState.remaining);
                //数据没有接收完整，重新接收数据
                //Console.WriteLine("temp: " + bufState.temp.Length);
                bufState.connect();
            }
        }
  
    }
}
