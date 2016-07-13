using System;


namespace ywcai.core.protocol
{
    class Encode
    {
        public  byte[] enString(byte ptag,String username,String data)
        {
            byte[] body = System.Text.Encoding.UTF8.GetBytes(data);
            byte[] user = System.Text.Encoding.UTF8.GetBytes(username);
            byte tag = ptag;
            Int32 lenth = body.Length;
            Int32 nlenth = user.Length;
            byte[] narry = new byte[4];
            narry[3] = (byte)(nlenth & 0xFF);
            narry[2] = (byte)((nlenth & 0xFF00) >> 8);
            narry[1] = (byte)((nlenth & 0xFF0000) >> 16);
            narry[0] = (byte)((nlenth >> 24) & 0xFF);
            byte[] arry = new byte[4];
            arry[3] = (byte)(lenth & 0xFF);
            arry[2] = (byte)((lenth & 0xFF00) >> 8);
            arry[1] = (byte)((lenth & 0xFF0000) >> 16);
            arry[0] = (byte)((lenth >> 24) & 0xFF);
            byte[] temp = new byte[9 + nlenth + lenth];
            temp[0] = tag;
            narry.CopyTo(temp, 1);
            arry.CopyTo(temp, 5);
            user.CopyTo(temp, 9);
            body.CopyTo(temp, 9 + nlenth);
            return temp;
        }
        public byte[] enImg(byte ptag, String username, byte[] data)
        {
            byte[] user = System.Text.Encoding.UTF8.GetBytes(username);

            Int32 lenth = data.Length;
            Int32 nlenth = user.Length;
            byte[] temp = new byte[9 + nlenth + lenth];
            byte[] narry = new byte[4];
            narry[3] = (byte)(nlenth & 0xFF);
            narry[2] = (byte)((nlenth & 0xFF00) >> 8);
            narry[1] = (byte)((nlenth & 0xFF0000) >> 16);
            narry[0] = (byte)((nlenth >> 24) & 0xFF);
            byte[] arry = new byte[4];
            arry[3] = (byte)(lenth & 0xFF);
            arry[2] = (byte)((lenth & 0xFF00) >> 8);
            arry[1] = (byte)((lenth & 0xFF0000) >> 16);
            arry[0] = (byte)((lenth >> 24) & 0xFF);

            temp[0] = ptag;
            narry.CopyTo(temp, 1);
            arry.CopyTo(temp, 5);
            user.CopyTo(temp, 9);
            data.CopyTo(temp, 9 + nlenth);
            return temp;
        }
    }
}
