using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ywcai.util.draw
{
[Serializable]
    class ImgEntity
    {
        public Int32 posX, posY, width, height;
        public byte[] body;
    }
}
