using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ywcai.core.veiw.src.config
{
    class AppProtocol
    {

        public const int ERR_CODE_START_SERVER = 0;
        public const int ERR_CODE_START_CLIENT = 1;
        public const int ERR_CODE_SEND_DATA = 2;
        public const int ERR_CODE_RECEIVE_DATA = 3;
        public const int ERR_CODE_FLAG = 4;
        public const int ERR_CODE_CLOSE = 5;
        public const int ERR_CODE_HEALTH_CHECKED = 6;


       public  const int json_type_req_local_check = 43001;
       public  const int json_type_req_local_close_shadow = 43002;
       public  const int json_type_req_local_open_shadow = 43003;
       public  const int json_type_req_local_open_mouse = 43004;
       public  const int json_type_req_local_close_mouse = 43005;
       public  const int json_type_req_local_deviceInfo = 43006;
       public  const int json_type_req_local_repeat = 43007;

       public const int json_type_notify_back_check_success = 43101;
       public const int json_type_notify_back_check_fail = 43102;
       public const int json_type_notify_back_shadow_open_ok = 43202;
       public const int json_type_notify_back_shadow_open_fail = 43203;
       public const int json_type_notify_back_mouse_open_ok = 43301;
       public const int json_type_notify_back_mouse_open_fail = 43302;
       public const int json_type_notify_back_shadow_close = 43303;

    }
}
