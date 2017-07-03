using System;
using System.Collections.Generic;
using ywcai.global.config;

namespace ywcai.util.draw
{
    class ImgCompara
    {
        private List<ImgEntity> old = null;
        public List<ImgEntity> compress(List<ImgEntity> now)
        {
            List<ImgEntity> changes = new List<ImgEntity>();
            if (old == null)
            {
                Console.WriteLine("初始化桌面数据");
                old = now;
                return now;
            }

            for (int i = 0; i < now.Count; i++)
            {
                byte[] chang = compara(old[i].body, now[i].body);
                if (chang != null)
                {
                    //Console.WriteLine("比较后数据 : 第" + now[i].posX + "-" + now[i].posY + "组 ： 数据长度 " + chang.Length + "  , 3:" + chang[chang.Length - 3] + " , 2: " + chang[chang.Length - 2] + " , 1: " + chang[chang.Length - 1]);
                    ImgEntity changEntity = new ImgEntity();
                    changEntity.posX = now[i].posX;
                    changEntity.posY = now[i].posY;
                    changEntity.width = now[i].width;
                    changEntity.height = now[i].height;
                    changEntity.realLenth = now[i].realLenth;
                    changEntity.body = compressByte(chang);
                    changes.Add(changEntity);
                    //Console.WriteLine("压缩后数据 : 第" + changEntity.posX + "-" + changEntity.posY + "组 ： 数据长度 " + changEntity.body.Length + "  , 3:" + changEntity.body[changEntity.body.Length - 3] + " , 2: " + changEntity.body[changEntity.body.Length - 2] + " , 1: " + changEntity.body[changEntity.body.Length - 1 ]);
                }
            }
            //Console.WriteLine("本次传递压缩后数据分块数量： " + changes.Count);
            old = now;
            return changes;
        }
        private byte[] compara(byte[] oldbody, byte[] nowbody)
        {
            byte[] compara = new byte[nowbody.Length];
            Int32 minLenth = (oldbody.Length < nowbody.Length ? oldbody.Length : nowbody.Length);
            Boolean isIdentical = true;
            if (oldbody.Length != nowbody.Length)
            {
                isIdentical = false;
            }
            for (Int32 j = 0; j < minLenth; j++)
            {
                compara[j] = (byte)(oldbody[j] ^ nowbody[j]);
                if (compara[j] != 0)
                {
                    isIdentical = false;
                }
            }
            if(oldbody.Length < nowbody.Length)
            {
                for (Int32 j= oldbody.Length; j<nowbody.Length;j++)
                {
                    compara[j] = nowbody[j];
                }
            }
            if (isIdentical)
            {
                return null;
            }
            return compara;
        }

        private byte[] compressByte(byte[] b)
        {
            Boolean firstFlag = true;
            Int32 zeroCount = 0;
            Int32 pos = 0;
            byte[] temp = new byte[(Int32)(b.Length * 1.5)];
            for (Int32 i = 0; i < b.Length; i++)
            {
                //如果是0位置
                if (b[i] == 0)
                {
                    if (firstFlag)
                    {
                        temp[pos] = 0x0;
                        firstFlag = false;
                        pos++;
                    }
                    zeroCount++;
                    if(i==b.Length-1)
                    {
                        //                       
                        temp[pos] = (byte)(zeroCount & 0xFF);
                        pos++;
                        temp[pos] = (byte)((zeroCount & 0xFF00) >> 8);
                        pos++;
                    }
                }
                else
                {
                    if (!firstFlag)
                    {
                        temp[pos] = (byte)(zeroCount & 0xFF);
                        pos++;
                        temp[pos] = (byte)((zeroCount & 0xFF00) >> 8);
                        pos++;
                    }
                    temp[pos] = b[i];
                    zeroCount = 0;
                    firstFlag = true;
                    pos++;
                }
            }
            byte[] compress = new byte[pos];
            temp.CopyTo(compress, 0);
            return compress;
        }
    }
}
