using System;
using ywcai.global.config;

namespace ywcai.core.protocol
{
    class Encode
    {
        public  byte[] enString(byte pReqType,byte pHasToken,String pToken,String pData)
        {
            byte[] data=System.Text.Encoding.UTF8.GetBytes(pData);
            byte pDataType = MyConfig.PROTOCOL_HEAD_TYPE_JSON;
            byte[] msg = bulidMsg(pDataType, pReqType, pHasToken, pToken, data);
            return msg;
        }

        public byte[] enImg(byte pReqType, byte pHasToken,String pToken, byte[] pData)
        {
            byte[] data = pData;
            byte pDataType = MyConfig.PROTOCOL_HEAD_TYPE_IMG;
            byte[] msg = bulidMsg(pDataType, pReqType, pHasToken , pToken, data);
            return msg;
        }

        private byte[] bulidMsg(byte pDataType,byte pReqType, byte pHasToken,String pToken, byte[] pData)
        {
            byte[] tokentemp = System.Text.Encoding.UTF8.GetBytes(pToken);
            byte[] token = new byte[MyConfig.PROTOCOL_HEAD_SIZE_TOKEN];
            tokentemp.CopyTo(token, 0);
            byte reqType = pReqType;
            Int32 intDataLen = pData.Length;

            byte[] bDataLen = new byte[4];
            bDataLen[3] = (byte)(intDataLen & 0xFF);
            bDataLen[2] = (byte)((intDataLen & 0xFF00) >> 8);
            bDataLen[1] = (byte)((intDataLen & 0xFF0000) >> 16);
            bDataLen[0] = (byte)((intDataLen >> 24) & 0xFF);
            byte[] temp = new byte[MyConfig.INT_PACKAGE_HEAD_LEN+intDataLen];

            temp[MyConfig.PROTOCOL_HEAD_POS_FLAG] = MyConfig.PROTOCOL_HEAD_FLAG;
            temp[MyConfig.PROTOCOL_HEAD_POS_TOKENTYPE] = pHasToken;
            temp[MyConfig.PROTOCOL_HEAD_POS_DATATYPE] = pDataType;
            temp[MyConfig.PROTOCOL_HEAD_POS_REQTYPE] = pReqType;
            token.CopyTo(temp, MyConfig.PROTOCOL_HEAD_POS_TOKEN);
            bDataLen.CopyTo(temp, MyConfig.PROTOCOL_HEAD_POS_DATALEN);
            bDataLen.CopyTo(temp, MyConfig.PROTOCOL_HEAD_POS_RESERVE);//预留位不解析。
            pData.CopyTo(temp, MyConfig.INT_PACKAGE_HEAD_LEN);
            return temp;
        }
    }
}
