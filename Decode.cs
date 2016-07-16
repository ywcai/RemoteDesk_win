using System;


namespace ywcai.core.protocol
{
    class Decode
    {
        public byte getTag(byte[] inStream,Int32 pos)
        {
            return (byte)inStream[pos];
        }
        public Int32 getNameLen(byte[] inStream)
        {
            byte[] ntemp = new byte[4];
            ntemp[0] = inStream[4];
            ntemp[1] = inStream[3];
            ntemp[2] = inStream[2];
            ntemp[3] = inStream[1];
            Int32 nlenth = BitConverter.ToInt32(ntemp, 0);
            return nlenth;
        }
        public Int32 getDataLen(byte[] inStream)
        {
            byte[] dtemp = new byte[4];
            dtemp[0] = inStream[8];
            dtemp[1] = inStream[7];
            dtemp[2] = inStream[6];
            dtemp[3] = inStream[5];
            Int32 dlenth = BitConverter.ToInt32(dtemp, 0);
            Console.WriteLine("消息体长度:" + dlenth);
            return dlenth;
        }
        public byte[] getData(byte[] inStream)
        {

            Int32 nlenth = getNameLen(inStream);
            Int32 dlenth = getDataLen(inStream);
            byte[] temp = new byte[dlenth];
            for (int i = 0; i < dlenth; i++)
            {
                temp[i] = inStream[9 + nlenth + i];
            }
            return temp;
        }
        public String getUsername(byte[] inStream)
        {
            Int32 nameLen = getNameLen(inStream);
            String username = System.Text.Encoding.UTF8.GetString(inStream, 9, nameLen);    
            return username;
        }
        public Int32 getPackLen(byte[] inStream,Int32 pos)
        {
            Int32 len;

            byte[] ntemp = new byte[4];
            ntemp[0] = inStream[4+  pos];
            ntemp[1] = inStream[3 + pos];
            ntemp[2] = inStream[2 + pos];
            ntemp[3] = inStream[1 + pos];
            Int32 nlenth = BitConverter.ToInt32(ntemp, 0);

            byte[] dtemp = new byte[4];
            dtemp[0] = inStream[8 + pos];
            dtemp[1] = inStream[7 + pos];
            dtemp[2] = inStream[6 + pos];
            dtemp[3] = inStream[5 + pos];
            Int32 dlenth = BitConverter.ToInt32(dtemp, 0);
            len = nlenth + dlenth + 9;
            return len;
        }
    }
}
