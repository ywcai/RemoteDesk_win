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
        public List<ImgEntity> oldList = null;
        private Graphics g = null;
        public Bitmap recovery(List<ImgEntity> nowList)
        {
            if (nowList.Count == 0||nowList==null)
            {
                Console.WriteLine("接收数据为空，不处理数据");
                return null;
            }
            if (oldList == null)
            {
                initDeskTop(nowList);
                //oldList = nowList;
            }
            else
            {
                //解压缩

                unCompress(nowList);
                //解异或
                decodeByte(nowList);
                //Console.WriteLine("本次传递压缩后数据分块数量： " + nowList.Count);
            }

            //绘制桌面
            for (Int32 i = 0; i < nowList.Count; i++)
            {
                //Console.WriteLine("还原后数据 : 第 " + nowList[i].posX+"-"+nowList[i].posY + "组 ： 长度  "+nowList[i].body.Length + "  , 3：" + nowList[i].body[nowList[i].body.Length - 3] + "  , 2：" + nowList[i].body[nowList[i].body.Length - 2] + "  , 1：" + nowList[i].body[nowList[i].body.Length - 1]);
                using (MemoryStream ms = new MemoryStream(nowList[i].body))
                {
                    Image temp = Image.FromStream(ms);
                    g.DrawImage(temp, nowList[i].posX, nowList[i].posY);
                }
            }
            return prevDesk;
        }

        private void initDeskTop(List<ImgEntity> nowList)
        {
            Int32 bitmapX, bitmapY;
            bitmapX = nowList[0].width * (MyConfig.INT_BLOCK_X_COUNT - 1) + nowList[nowList.Count - 1].width;
            bitmapY = nowList[0].height * (MyConfig.INT_BLOCK_Y_COUNT - 1) + nowList[nowList.Count - 1].height;
            prevDesk = new Bitmap(bitmapX, bitmapY);
            g = Graphics.FromImage(prevDesk);
            oldList = nowList;
        }

        //解压缩
        private void unCompress(List<ImgEntity> nowList)
        {
            for (Int32 i = 0; i < nowList.Count; i++)
            {
                //Console.WriteLine("解压缩前前前前前 : 第" + nowList[i].posX + "-" + nowList[i].posY + "组 ： 数据长度 " + nowList[i].body.Length + "  , 3：" + nowList[i].body[nowList[i].body.Length - 3] +"  , 2：" + nowList[i].body[nowList[i].body.Length - 2] + "  , 1：" + nowList[i].body[nowList[i].body.Length - 1]);
                byte[] recovery = new byte[nowList[i].realLenth];
                Int32 pos = 0;
                for (Int32 n = 0; n < nowList[i].body.Length; n++)
                {
                    if (nowList[i].body[n] == 0)
                    {
                        short result = BitConverter.ToInt16(nowList[i].body, n+1);
                        for (int k = 0; k < result; k++)
                        {
                            recovery[pos] = 0;
                            pos++;
                        }
                        n = n + 2;
                    }
                    else
                    {
                        recovery[pos] = nowList[i].body[n];
                        pos++;
                    }
                }
                nowList[i].body = recovery;
                //Console.WriteLine("解压缩后后后后后 : 第" + nowList[i].posX + "-" + nowList[i].posY + "组 ： 数据长度 " + nowList[i].body.Length + "  , 3：" + nowList[i].body[nowList[i].body.Length - 3] + "  , 2：" + nowList[i].body[nowList[i].body.Length - 2] + "  , 1：" + nowList[i].body[nowList[i].body.Length - 1]);
            }
        }

        //解异或
        private void decodeByte(List<ImgEntity> nowList)
        {
            for (Int32 i = 0; i < nowList.Count; i++)
            {
                for (Int32 l = 0; l < oldList.Count; l++)
                {
                    if (oldList[l].posX == nowList[i].posX && oldList[l].posY == nowList[i].posY)
                    {
                        Int32 minLen = oldList[l].realLenth < nowList[i].realLenth ? oldList[l].realLenth : nowList[i].realLenth;
                        //Console.WriteLine("解码对比的老数据 : 第" + oldList[l].posX + "-" + oldList[l].posY + "组 ： 数据长度 " + oldList[l].body.Length + "  , 3：" + oldList[l].body[oldList[l].body.Length - 3] + "  , 2：" + oldList[l].body[oldList[l].body.Length - 2] + "  , 1：" + oldList[l].body[oldList[l].body.Length - 1]);
                        //Console.WriteLine("解码对比的新数据 : 第" + nowList[i].posX + "-" + nowList[i].posY + "组 ： 数据长度 " + nowList[i].body.Length + "  , 3：" + nowList[i].body[nowList[i].body.Length - 3] + "  , 2：" + nowList[i].body[nowList[i].body.Length - 2] + "  , 1：" + nowList[i].body[nowList[i].body.Length - 1]);
                        for (Int32 k = 0; k < minLen; k++)
                        {
                            nowList[i].body[k] = (byte)(nowList[i].body[k] ^ oldList[l].body[k]);
                        }
                        oldList[l] = nowList[i];
                        break;
                    }
                }

            }

        }

    }
}
