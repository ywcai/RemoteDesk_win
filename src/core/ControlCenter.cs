using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using ywcai.core.veiw.src.config;
using ywcai.core.veiw.src.util;
using ywcai.global.config;
using ywcai.normal.socket;
using ywcai.util.draw;
using ywcai.core.veiw.src.core;

namespace ywcai.core.control
{
    public class ControlCenter
    {
        private String myPsw;
        public event Action<Object, Int32> updateInfo;
        public event Action<Bitmap> updateDesk;
        private LSocket mySocket;
        public Dictionary<String, WorkSocket> sessions = new Dictionary<String, WorkSocket>();
        private int deskWidth=600,deskHeight=1000;
        private int serverWorkStatus=MyConfig.SERVER_WORK_STATUS_FREE;
        private String activeId="";
        private WorkSocket activeSocket=null;

        public ControlCenter()
        {
            mySocket = new LSocket();
            mySocket.healthCheckTime = 5000;
            mySocket.ServerStart += socket_ServerStart;
            mySocket.AcceptClient += mySocket_AcceptClient;
            mySocket.sessionClosed += socket_sessionClosed;
            mySocket.ReceiveMessage += socket_ReceiveMessage;
            mySocket.ErrLog += mySocket_ErrLog;
        }
        public void setPsw(String password)
        {
            myPsw = password;
        }

        void socket_ServerStart(bool obj)
        {
            if (obj)
            {
                serverWorkStatus = MyConfig.SERVER_WORK_STATUS_FREE;
                updateInfo("服务端启动成功", MyConfig.INT_UPDATEUI_TXBOX);
                updateInfo("", MyConfig.INT_SERVER_SUCCESS);

            }
            else
            {
                serverWorkStatus = MyConfig.SERVER_WORK_STATUS_NONE;
                updateInfo("服务端启动失败", MyConfig.INT_UPDATEUI_TXBOX);
                updateInfo("", MyConfig.INT_SERVER_FAIL);
            }
        }
        void mySocket_AcceptClient(WorkSocket workSocke)
        {
            updateInfo("新的连接:" + workSocke.session.RemoteEndPoint.ToString(), MyConfig.INT_UPDATEUI_TXBOX);
        }

        void socket_ReceiveMessage(WorkSocket workSocke, byte[] pToken, byte[] obj)
        {
            byte[] serverToken = mySocket.getToken();
            for (int i = 0; i < serverToken.Length; i++)
            {
                if (serverToken[i] != pToken[i])
                {
                    updateInfo("密钥异常，关闭连接:" + workSocke.session.RemoteEndPoint.ToString(), MyConfig.INT_UPDATEUI_TXBOX);
                    return;
                }
            }
            dataProccess(workSocke, obj);
        }

        void socket_sessionClosed(WorkSocket workSocket)
        {
            String key = workSocket.remoteDeviceId;
            sessions.Remove(key);
            if(key.Equals(activeId))
            {
                closeShadowForm(workSocket);
                closeMouseSession(workSocket);
            }
            updateInfo(key, MyConfig.INT_CLIENT_OFFLINE);
            updateInfo("close:" + workSocket.remoteIp + ":" + workSocket.remotePort, MyConfig.INT_UPDATEUI_TXBOX);
        }
        void mySocket_ErrLog(WorkSocket workSocket,int code,string obj)
        {
            switch(code)
            {
                case AppProtocol.ERR_CODE_FLAG:
                    updateInfo(workSocket.remoteIp + ":" + workSocket.remotePort + "," + code + "," + obj, MyConfig.INT_UPDATEUI_TXBOX);
                    break;
                case AppProtocol.ERR_CODE_RECEIVE_DATA:
                    updateInfo(workSocket.remoteIp + ":" + workSocket.remotePort + "," + code + "," + obj, MyConfig.INT_UPDATEUI_TXBOX);
                    break;
                case AppProtocol.ERR_CODE_HEALTH_CHECKED:
                    updateInfo(workSocket.remoteIp+":"+workSocket.remotePort+"," + code + "," + obj, MyConfig.INT_UPDATEUI_TXBOX);
                    break;
            }
        }
        public void StartServer()
        {
            Thread thread = new Thread(new ThreadStart(startService));
            thread.IsBackground = true;
            thread.Start();
        }
        private void startService()
        {
            mySocket.CreateServer(MyConfig.INT_SERVER_PORT);
        }
        private void dataProccess(WorkSocket workSocket, byte[] obj)
        {
            byte[] payLoad = new byte[obj.Length - 1];
            System.Array.Copy(obj, 1, payLoad, 0, payLoad.Length);
            switch (obj[0])
            { 
            case  MyConfig.INT_APP_PROTOCOL_JSON:
                    ProccessJson(workSocket, payLoad);
                    break;
            case  MyConfig.INT_APP_PROTOCOL_BYTE:
                    ProccessByte(workSocket, payLoad);
                    break;
             }
        }
        private void ProccessJson(WorkSocket workSocket, byte[] payLoad)
        {
            ApplicationProtocol ap=MakeJson.getApplicationProtocol(payLoad);
            updateInfo(ap.type+":"+ap.content, MyConfig.INT_UPDATEUI_TXBOX);
            switch (ap.type)
            {
                case AppProtocol.json_type_req_local_check:
                    CheckPsw(workSocket, ap.content);
                    break;
                case AppProtocol.json_type_req_local_repeat:
                    //repeatConn(workSocket, ap.content);
                    break;
                //case "move":
                //    MoveMouse(workSocket, jobject);
                //    break;
                //case "click":
                //    ClickMouse(workSocket, jobject);
                //    break;
                case AppProtocol.json_type_req_local_open_shadow:
                    CreateShadowContainer(workSocket, ap.content);
                    break;
                case AppProtocol.json_type_req_local_close_shadow:
                    closeShadowForm(workSocket);
                    break;
                case AppProtocol.json_type_req_local_open_mouse:
                    startMouseMode(workSocket);
                    break;
                case AppProtocol.json_type_req_local_close_mouse:
                    closeMouseMode(workSocket);
                    break;
            }
        }

        private void closeMouseSession(WorkSocket workSocket)
        {
            if(workSocket==activeSocket&&serverWorkStatus==MyConfig.SERVER_WORK_STATUS_MOUSE)
            {
                updateInfo(activeId, MyConfig.INT_CLIENT_OFFLINE);
                serverWorkStatus = MyConfig.SERVER_WORK_STATUS_FREE;
                activeSocket = null;
                activeId = "";
                Console.WriteLine(activeId);
            }
        }


        private void startMouseMode(WorkSocket workSocket)
        {
            if(serverWorkStatus==MyConfig.SERVER_WORK_STATUS_FREE)
            {
                serverWorkStatus = MyConfig.SERVER_WORK_STATUS_MOUSE;
                activeId = workSocket.remoteDeviceId;
                activeSocket = workSocket;
                updateInfo(activeId, MyConfig.INT_CLIENT_BUSY);
                SendMsgToClient(workSocket, AppProtocol.json_type_notify_back_mouse_open_ok, "连接成功!");
            }
            else
            {
                SendMsgToClient(workSocket, AppProtocol.json_type_notify_back_mouse_open_fail, "连接失败!");
            }
        }
        private void closeMouseMode(WorkSocket workSocket)
        {
            if (workSocket == activeSocket && serverWorkStatus == MyConfig.SERVER_WORK_STATUS_MOUSE)
            {
                updateInfo(activeId, MyConfig.INT_CLIENT_FREE);
                serverWorkStatus = MyConfig.SERVER_WORK_STATUS_FREE;
                activeSocket = null;
                activeId = "";
            }
        }

        private void ProccessByte(WorkSocket workSocket, byte[] payLoad)
        {
            if (activeId.Equals(workSocket.remoteDeviceId)&&(workSocket==activeSocket))
            {
                 UpdateShadowContainer(payLoad);
            }
        }
        void UpdateShadowContainer(byte[] desk)
        {
            updateInfo("正常收到投影数据：" + desk.Length + " byte", MyConfig.INT_UPDATEUI_TXBOX);
            using (MemoryStream ms = new MemoryStream(desk))
            {
                Image img = Image.FromStream(ms);
                Bitmap deskImg = new Bitmap(deskWidth, deskHeight);
                Graphics g = Graphics.FromImage(deskImg);
                g.DrawImage(img, 0, 0);
                DrawShadow(deskImg);
            }
        }

        private void DrawShadow(Bitmap desk)
        {
            updateDesk(desk);
        }

        void CreateShadowContainer(WorkSocket workSocket,String content)
        {
            if (serverWorkStatus==MyConfig.SERVER_WORK_STATUS_FREE)
            {
                deskWidth = Int32.Parse(content.Split('|')[0]);
                deskHeight = Int32.Parse(content.Split('|')[1]);
                activeId = workSocket.remoteDeviceId;
                serverWorkStatus = MyConfig.SERVER_WORK_STATUS_SHADOW;
                activeSocket = workSocket;
                updateInfo(workSocket.remoteDeviceId, MyConfig.INT_CLIENT_BUSY);//更新设备列表
                updateInfo("Start shadow container!", MyConfig.INT_CREATE_DESK_CONTAINER);//创建容器
                SendMsgToClient(workSocket, AppProtocol.json_type_notify_back_shadow_open_ok, "连接成功");
            }
            else
            {
                SendMsgToClient(workSocket, AppProtocol.json_type_notify_back_shadow_open_fail, "服务端被占用");
            }
        }

        void clearActiveStatus()
        {
            updateInfo(activeId, MyConfig.INT_CLIENT_FREE);
            serverWorkStatus = MyConfig.SERVER_WORK_STATUS_FREE;
            activeSocket = null;
            activeId = "";

        }
        private void closeShadowForm(WorkSocket workSocket)
        {
            if (activeSocket == workSocket && activeId.Equals(workSocket.remoteDeviceId) && serverWorkStatus == MyConfig.SERVER_WORK_STATUS_SHADOW)
            {
            clearActiveStatus();
            updateInfo("Close shadow container!", MyConfig.INT_DELETE_DESK_CONTAINER);
            }
        }

        public void notifyCloseShadow()
        {
            //如果是服务端手动点击关闭窗口，该代码会执行
            if(activeSocket!=null&&!activeId.Equals("")&&serverWorkStatus==MyConfig.SERVER_WORK_STATUS_SHADOW)
            {
                Thread thread = new Thread(new ThreadStart(sendToActiveCloseShadow));
                thread.IsBackground = true;
                thread.Start();
            }
        }
        void sendToActiveCloseShadow()
        {
            SendMsgToClient(activeSocket, AppProtocol.json_type_notify_back_shadow_close, "");
            clearActiveStatus();
        }
 
        void ClickMouse(WorkSocket workSocket, JObject jobject)
        {
            //String cmd = jobject[AppProtocol.STR_JSON_CONTENT].ToString();
            //ResponseEvent.ReponseClick(cmd);
        }
        private void MoveMouse(WorkSocket workSocket, JObject jobject)
        {
            //String[] postion = jobject[AppProtocol.STR_JSON_CONTENT].ToString().Split('_');
            //int x = Int32.Parse(postion[1]);
            //int y = Int32.Parse(postion[0]);
            //ResponseEvent.ReponseMove(x, y);
        }
        private void CheckPsw(WorkSocket workSocket, String content)
        {
            DeviceInfo device = (DeviceInfo)JsonConvert.DeserializeObject(content,typeof(DeviceInfo));
            device.remoteIp = workSocket.remoteIp;
            workSocket.remoteDeviceId = device.deviceId;
            String key = device.deviceId;
            if (sessions.ContainsKey(key))
            {
                SendMsgToClient(workSocket, AppProtocol.json_type_notify_back_check_fail,"连接失败，您已经连接！");
                return ;
            }
            if (device.accessCode.Equals(myPsw))
            {
                sessions.Add(key, workSocket);
                updateInfo(device, MyConfig.INT_CLIENT_ONLINE);
                SendMsgToClient(workSocket, AppProtocol.json_type_notify_back_check_success, "连接成功!");
            }
            else
            {
                updateInfo(device, MyConfig.INT_CLIENT_ADD_TEMP);
                SendMsgToClient(workSocket, AppProtocol.json_type_notify_back_check_fail, "密码校验失败!");
            }
        }

        public void SendMsgToClient(WorkSocket workSocket, int type, String content)
        {
            byte[] data = MakeJson.getJsonByte(type, content);
            mySocket.sent(workSocket, data);
        }
    }
}
