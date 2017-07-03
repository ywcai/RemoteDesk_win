namespace ywcai.global.config
{ 
    class MyConfig
    {
    
        //更新前端UI方法选择
        public const int INT_CLEAR_LIST = 0;
        public const int INT_UPDATEUI_LIST = 1;
        public const int INT_UPDATEUI_TXBOX = 2;
        public const int INT_CREATE_DESK_CONTAINER = 4;
        public const int INT_DELETE_DESK_CONTAINER = 5;
        public const int INT_INIT_CLIENT_LIST = 6;
        public const int INT_CHANGE_OUT = 7;
        public const int INT_SERVER_SUCCESS=8;
        public const int INT_SERVER_FAIL = 9;
        public const int INT_CLIENT_ONLINE = 10;
        public const int INT_CLIENT_OFFLINE = 11;
        public const int INT_CLIENT_BUSY = 12;
        public const int INT_CLIENT_ADD_TEMP = 13;
        public const int INT_CLIENT_FREE= 14;        

        //相关网络配置选项
        public const int INT_SERVER_PORT =7772;
        public const int INT_SOCKET_TIMEOUT = 1000;
        public const byte INT_APP_PROTOCOL_JSON = 0xa;
        public const byte INT_APP_PROTOCOL_BYTE = 0xb;

        //图片压缩选项

        //图片差分的数量
        public const int INT_BLOCK_X_COUNT = 10;
        public const int INT_BLOCK_Y_COUNT = 10;
        //图片压缩的质量
        public const long INT_DESKTOP_QA = 50L;
        public const int INT_DESKTOP_REFLUSH_FREQUENCY_HIGHT = 200;//数据传输帧率，每秒，高频
        public const int INT_DESKTOP_REFLUSH_FREQUENCY_NORMAL = 400;//数据传输帧率，每秒，普通
        public const int INT_DESKTOP_REFLUSH_FREQUENCY_LOW=500;//数据传输帧率，每秒，低频
        public const int INT_DESKTOP_REFLUSH_FREQUENCY_SLEEP = 1000;//数据传输帧率，每秒，休眠

        //终端类型
        public const int INT_CLIENT_TYPE_PC = 0;
        public const int INT_CLIENT_TYPE_PHONE = 1;


        //控制命令对应数据传输值
        public const string MOUSE_LEFT_DOWN = "1-1-3";
        public const string MOUSE_RIGHT_DOWN = "1-2-3";
        public const string MOUSE_LEFT_UP= "1-1-4";
        public const string MOUSE_RIGHT_UP = "1-2-4";
        public const string MOUSE_MID_SCROLL = "1-0-5";
        public const string MOUSE_MOVE = "1-0-6";

        //应用层协议约定内容
        public const string STR_LOGIN_RESULT_OK = "login_ok";
        public const string STR_OUT_RESULT_OK = "login_out_ok";
        public const string STR_OPEN_DESK_MASTER = "master";
        public const string STR_OPEN_DESK_SLAVE = "slave";
        public const string STR_OPEN_DESK_NORMAL = "normal";
        public const string STR_OPEN_DESK_FAIL = "has_a_link";
        public const string STR_OPEN_DESK_FAIL1 = "not_link_self";
        public const string STR_SHUTDOWN_DESK_FAIL = "has_no_link";
        public const string STR_SHUTDOWN_DESK_OK = "disconnect_ok";



        public const int SERVER_WORK_STATUS_SHADOW = 30001;
        public const int SERVER_WORK_STATUS_MOUSE = 30002;
        public const int SERVER_WORK_STATUS_FREE= 30003;
        public const int SERVER_WORK_STATUS_NONE = 30004;
    }
}
