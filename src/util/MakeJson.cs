using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ywcai.core.veiw.src.config;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ywcai.global.config;

namespace ywcai.core.veiw.src.util
{
    class MakeJson
    {
        public static byte[] getJsonByte(int type,String content)
        {
            ApplicationProtocol ap = new ApplicationProtocol();
            ap.type = type;
            ap.content = content;

            String pullStr = JsonConvert.SerializeObject(ap);
            Console.WriteLine(pullStr);
            byte[] strTemp = System.Text.Encoding.UTF8.GetBytes(pullStr);
            byte[] data = new byte[strTemp.Length + 1];
            data[0] = MyConfig.INT_APP_PROTOCOL_JSON;
            strTemp.CopyTo(data, 1);
            Console.WriteLine(data[0]);
            return data;
        }

        public static byte[] getByteByte(byte[] payload)
        {

            byte[] data = new byte[payload.Length + 1];
            data[0] = MyConfig.INT_APP_PROTOCOL_BYTE;
            payload.CopyTo(data, 1);
            return data;
        }


        public static ApplicationProtocol getApplicationProtocol(byte[] payload)
        {
            String json = System.Text.Encoding.UTF8.GetString(payload);
            ApplicationProtocol ap = (ApplicationProtocol)JsonConvert.DeserializeObject(json, typeof(ApplicationProtocol));
            return ap;
        }


    }
}
