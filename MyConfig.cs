namespace ywcai.global.config
{ 
    class MyConfig
    {
        //更新前端UI方法选择
        public const int INT_CLEAR_LIST = 0;
        public const int INT_UPDATEUI_LIST = 1;
        public const int INT_UPDATEUI_TXBOX = 2;
        //public const int INT_UPDATEUI_LABLE_STATUS = 3;
        public const int INT_CREATE_DESK_CONTAINER = 4;
        public const int INT_DELETE_DESK_CONTAINER = 5;

        //相关网络配置选项
        public const string STR_SERVER_IP = "119.6.204.54" ;
        public const int INT_SERVER_PORT =7772;
        public const int INT_SOCKET_TIMEOUT = 100;
        public const int INT_SOCKET_BUFFER_SIZE = 2048 * 16;

        //图片压缩选项
        public const int INT_BLOCK_X_COUNT = 10;
        public const int INT_BLOCK_Y_COUNT = 9;
        public const long INT_DESKTOP_QA = 70L;
    }
}
