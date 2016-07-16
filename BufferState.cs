using System;
using ywcai.global.config;

namespace ywcai.util.buf
{
    class BufferState
    {
        public byte[] buf =new byte[MyConfig.INT_SOCKET_BUFFER_SIZE];//只需要保留BUFF状态，不用做任何处理
        public byte[] temp;
        public Boolean hasHead, hasRemaing;
        public Int32 remaining, target, pending,bufPos,tempPos;
        public void init()
        {
            temp = null;
            hasHead = true;
            hasRemaing = false;
            remaining = 0;
            bufPos = 0;
            tempPos = 0;
            target = 0;
            pending = 0;
        }
        public void skip()
        {
            temp = null;
            hasHead = true;
            hasRemaing = true;
            remaining = remaining-pending;
            bufPos = bufPos + pending;
            tempPos = 0;
            target = 0;
            pending = 0;

        }
        public void connect()
        {
            //temp不处理，保留之前读取为输出的数据
            hasHead = false;
            hasRemaing = false;
            pending = pending - remaining;//组成完整包总共还需要多少数据
            tempPos = tempPos + remaining;//之前的长度加上这次复制的数据为当前temp的真实长度，也就是tempos
            remaining = 0;//这次数据全都被读取，因此设置为0
            //target = 0;目标长度，因为下一次没报头，所以target保持不变
            bufPos = 0 ;//重新接收数据，因此bufPos置为0

        }
    }
}
