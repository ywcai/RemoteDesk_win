using System;

namespace ywcai.global.config
{
    class MyUtil
    {
        public static void copyArray(byte[] src, Int32 srcIndex, byte[] dest, Int32 destPos, Int32 copyLen)
        {
            for (int i = 0; i < copyLen; i++)
            {
                dest[destPos + i] = src[srcIndex + i];
            }
        }

    }
}
