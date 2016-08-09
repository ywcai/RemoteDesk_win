using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ywcai.util.draw
{
[Serializable]
    class ImgEntity
    {
        public short posX, posY,width, height;
        public Int32 realLenth;
        public byte[] body;
    }
}
