namespace ywcai.global.config
{ 
    class MyConfig
    {
        //协议

        public const int INT_PACKAGE_HEAD_LEN = 28;
        public const int PROTOCOL_HEAD_FLAG = 0x7E;
        public const int PROTOCOL_HEAD_HAS_TOKEN = 0x01;
        public const int PROTOCOL_HEAD_NOT_TOKEN = 0x00;

        public const int PROTOCOL_HEAD_TYPE_JSON = 0x01;
        public const int PROTOCOL_HEAD_TYPE_IMG = 0x02;

        public const int REQ_TYPE_USER_LOGIN_IN = 0x01;
        public const int REQ_TYPE_USER_LOGIN_OUT = 0x02;
        public const int REQ_TYPE_DESK_LINK_OPEN = 0x03;
        public const int REQ_TYPE_DESK_SHOWDOWN = 0x04;
        public const int REQ_TYPE_CONTROL_CMD = 0x05;
        public const int REQ_TYPE_DESKTOP_SWITCH = 0x06;
        public const int REQ_TYPE_CLIENT_LIST_UPDATE = 0x07;
        //public const int REQ_TYPE_LINK_STATUS_ON = 0x08;
        //public const int REQ_TYPE_LINK_STATUS_OFF = 0x09;
        public const int PROTOCOL_HEAD_RESERVE = 0x7F;//预留



        //协议起始位置，大小
        public const int PROTOCOL_HEAD_POS_FLAG = 0;
        public const int PROTOCOL_HEAD_POS_TOKENTYPE = 1;
        public const int PROTOCOL_HEAD_POS_DATATYPE = 2;
        public const int PROTOCOL_HEAD_POS_REQTYPE = 3;
        public const int PROTOCOL_HEAD_POS_TOKEN = 4;
        public const int PROTOCOL_HEAD_SIZE_TOKEN = 16;
        public const int PROTOCOL_HEAD_POS_DATALEN = 20;
        public const int PROTOCOL_HEAD_POS_RESERVE = 24;//预留
        public const int PROTOCOL_HEAD_SIZE_RESERVE = 4;//预留

        //更新前端UI方法选择
        public const int INT_CLEAR_LIST = 0;
        public const int INT_UPDATEUI_LIST = 1;
        public const int INT_UPDATEUI_TXBOX = 2;
       // public const int INT_UPDATEUI_LIST_SUB = 3;
        public const int INT_CREATE_DESK_CONTAINER = 4;
        public const int INT_DELETE_DESK_CONTAINER = 5;
        public const int INT_INIT_CLIENT_LIST = 6;
        public const int INT_CHANGE_OUT = 7;
        //public const int INT_TURN_ON=8;
        //public const int INT_TURN_OFF=9;

        //相关网络配置选项
        public const string STR_SERVER_IP = "119.6.204.54" ;
        public const int INT_SERVER_PORT =7772;
        public const int INT_SOCKET_TIMEOUT = 100;
        public const int INT_SOCKET_BUFFER_SIZE = 2048 * 16;

        //图片压缩选项

        //图片差分的数量
        public const int INT_BLOCK_X_COUNT = 10;
        public const int INT_BLOCK_Y_COUNT = 9;
        //图片压缩的质量
        public const long INT_DESKTOP_QA = 100L;
        public const int INT_DESKTOP_REFLUSH_FREQUENCY_HIGHT = 100;//数据传输帧率，每秒，高频
        public const int INT_DESKTOP_REFLUSH_FREQUENCY_NORMAL = 200;//数据传输帧率，每秒，普通
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
    }
}
