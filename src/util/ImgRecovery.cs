using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using ywcai.global.config;

namespace ywcai.util.draw
{
    class ImgRecovery
    {
        private Bitmap prevDesk = null;
        private Graphics g = null;
        public Bitmap recovery(List<ImgEntity> imgs)
        { 
            if (imgs.Count == (MyConfig.INT_BLOCK_X_COUNT * MyConfig.INT_BLOCK_Y_COUNT))
            {
                //计算客户端的分辨率大小
                Int32 bitmapX, bitmapY;
                bitmapX = imgs[0].width *( MyConfig.INT_BLOCK_X_COUNT-1 )+ imgs[imgs.Count - 1].width;
                bitmapY = imgs[0].height * (MyConfig.INT_BLOCK_Y_COUNT-1) + imgs[imgs.Count - 1].height;
                prevDesk = new Bitmap(bitmapX, bitmapY);
                g = Graphics.FromImage(prevDesk);
            }

            if (prevDesk == null || g == null)
            {
                Console.WriteLine("接收数据初始化失败，未接收到关键帧");
                return null;
            }
            else
            {
                for (Int32 i = 0; i < imgs.Count; i++)
                {
                    using (MemoryStream ms = new MemoryStream(imgs[i].body))
                    {
                        Image temp = Image.FromStream(ms);
                        g.DrawImage(temp, imgs[i].posX, imgs[i].posY);
                    }
                }
            }

            return prevDesk;
        }
    }
}
