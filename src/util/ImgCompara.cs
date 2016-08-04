using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ywcai.util.draw
{
    class ImgCompara
    {
        private List<ImgEntity> old = null;
        public List<ImgEntity> compara(List<ImgEntity> now)
        {
            List<ImgEntity> changes = new List<ImgEntity>();
            if (old == null)
            {
                Console.WriteLine("old is null");
                old = now;
                return now;
            }
            for (int i = 0; i < now.Count; i++)
            {
                if(comparaByte(old[i].body,now[i].body))
                {
                    //不处理
                   // Console.WriteLine("没有变换的区域: " +i);
                }
                else
                {
                    changes.Add(now[i]);
                }
                //Console.WriteLine("old i="+i +"  lenth = "+ old[i].body.Length);
                //Console.WriteLine("now i=" + i + "  lenth = " + now[i].body.Length);
            }
            old = now;
            return changes;
        }
        private Boolean comparaByte(byte[] a,byte[] b)
        {
            if (a.Length!=b.Length)
            {
                return false;
            }
           for(int i=0;i<a.Length;i++)
            {
                if ((a[i] ^ b[i]) == 1)
                {
                    return false;
                }
            }
            return true;
        }
     }
}
