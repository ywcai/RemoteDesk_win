using System;


namespace ywcai.util.buf
{
    class BufferState
    {
        public byte tag;
        public byte[] data;
        public Boolean isEnd,isHead,hasRemaing;
        public Int32 dLenth,dReading,dPending;
    }
}
