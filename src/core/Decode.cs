using System;
using ywcai.global.config;

namespace ywcai.core.protocol
{
    class Decode
    {
        public byte getHeadFlag(byte[] inStream, Int32 pos)
        {
            return (byte)inStream[pos+MyConfig.PROTOCOL_HEAD_POS_FLAG];
        }
        public byte getTokenType(byte[] inStream, Int32 pos)
        {
            return (byte)inStream[pos+MyConfig.PROTOCOL_HEAD_POS_TOKENTYPE];
        }
        public byte getDataType(byte[] inStream, Int32 pos)
        {
            return (byte)inStream[pos + MyConfig.PROTOCOL_HEAD_POS_DATATYPE];
        }
        public byte getReqType(byte[] inStream,Int32 pos)
        {
            return (byte)inStream[pos+MyConfig.PROTOCOL_HEAD_POS_REQTYPE];
        }
        public String getToken(byte[] inStream)
        {
            String token = System.Text.Encoding.UTF8.GetString(inStream,MyConfig.PROTOCOL_HEAD_POS_TOKEN,MyConfig.PROTOCOL_HEAD_SIZE_TOKEN);    
            return token;
        }
        public Int32 getDataLen(byte[] inStream)
        {
            Int32 len;
            byte[] dtemp = new byte[4];
            dtemp[0] = inStream[MyConfig.PROTOCOL_HEAD_POS_DATALEN + 3];
            dtemp[1] = inStream[MyConfig.PROTOCOL_HEAD_POS_DATALEN + 2];
            dtemp[2] = inStream[MyConfig.PROTOCOL_HEAD_POS_DATALEN + 1];
            dtemp[3] = inStream[MyConfig.PROTOCOL_HEAD_POS_DATALEN + 0];
            len = BitConverter.ToInt32(dtemp, 0);
            return len;
        }
        private void getReserve(byte[] inStream)
        {
            ;
        }
        public Int32 getPackLen(byte[] inStream,Int32 pos)
        {
            Int32 len;
            byte[] dtemp = new byte[4];
            dtemp[0] = inStream[MyConfig.PROTOCOL_HEAD_POS_DATALEN + 3 + pos];
            dtemp[1] = inStream[MyConfig.PROTOCOL_HEAD_POS_DATALEN + 2 + pos];
            dtemp[2] = inStream[MyConfig.PROTOCOL_HEAD_POS_DATALEN + 1 + pos];
            dtemp[3] = inStream[MyConfig.PROTOCOL_HEAD_POS_DATALEN + 0 + pos];
            Int32 dlenth = BitConverter.ToInt32(dtemp, 0);
            len = dlenth + MyConfig.INT_PACKAGE_HEAD_LEN;
            return len;
        }


        public byte[] getData(byte[] inStream)
        {
            Int32 dataLen = getDataLen(inStream);
            byte[] data = new byte[dataLen];
            MyUtil.copyArray(inStream, MyConfig.INT_PACKAGE_HEAD_LEN, data, 0, dataLen);
            return data;
        }
    }
}
