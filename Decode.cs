using System;
using ywcai.util.buf;

namespace ywcai.core.protocol
{
    class Decode
    {
        public String deString(byte[] inStream)
        {
            String data = "";
            byte[] ntemp = new byte[4];
            byte[] dtemp = new byte[4];
            ntemp[0] = inStream[4];
            ntemp[1] = inStream[3];
            ntemp[2] = inStream[2];
            ntemp[3] = inStream[1];
            dtemp[0] = inStream[8];
            dtemp[1] = inStream[7];
            dtemp[2] = inStream[6];
            dtemp[3] = inStream[5];
            Int32 nlenth = BitConverter.ToInt32(ntemp, 0);
            Int32 dlenth = BitConverter.ToInt32(dtemp, 0);
            String username = System.Text.Encoding.UTF8.GetString(inStream, 9, nlenth);
            data = System.Text.Encoding.UTF8.GetString(inStream, 9 + nlenth, dlenth);
            return data;
        }
        public byte[] deImg(byte[] inStream)
        {
            byte[] ntemp = new byte[4];
            byte[] dtemp = new byte[4];
            ntemp[0] = inStream[4];
            ntemp[1] = inStream[3];
            ntemp[2] = inStream[2];
            ntemp[3] = inStream[1];
            dtemp[0] = inStream[8];
            dtemp[1] = inStream[7];
            dtemp[2] = inStream[6];
            dtemp[3] = inStream[5];
            Int32 nlenth = BitConverter.ToInt32(ntemp, 0);
            Int32 dlenth = BitConverter.ToInt32(dtemp, 0);
            String username = System.Text.Encoding.UTF8.GetString(inStream, 9, nlenth);
            byte[] temp = new byte[dlenth];
            for (int i = 0; i < dlenth; i++)
            {
                temp[i] = inStream[9 + nlenth + i];
            }
            return temp;
        }
        public String getUsername(byte[] inStream)
        {
            byte[] ntemp = new byte[4];
            ntemp[0] = inStream[4];
            ntemp[1] = inStream[3];
            ntemp[2] = inStream[2];
            ntemp[3] = inStream[1];
            Int32 nlenth = BitConverter.ToInt32(ntemp, 0);
            String username = System.Text.Encoding.UTF8.GetString(inStream, 9, nlenth);    
            return username;
        }
        public BufferState assembleBuf(byte[] buffer,BufferState bufferState)
        {
            BufferState bufState = bufferState;
            //Boolean hasRemaining = true;
           // Boolean isHead = true;
            return bufferState;
        }
    }
}
