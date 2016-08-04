using System;
using System.Collections.Generic;

namespace ywcai.util.hfman
{
    class HfmanTree
    {
        public Node buildTree(Int32 [] src)
        {
            List<Node> lists = initNodes(src);
            lists.Sort(new SortWeight());

            while(lists.Count>1)
            {
                lists.Sort(new SortWeight());
                Node l = lists[0];
                Node r = lists[1];
                l.code = 0;
                r.code = 1;
                Node p = new Node();
                p.left = l;
                p.right = r;
                p.code = 1;
                p.weight = l.weight + r.weight;
                p.native = false;
                p.num =(l.num >= r.num ? l.num : r.num)+1;//取层次大的加1
                //Console.WriteLine(p.num+" r: " + r.num+" l: "+l.num+" r:weight "+r.weight+" l:weight "+l.weight);
                lists.Remove(l);
                lists.Remove(r);
                lists.Add(p);
            }
            return lists[0];
        }
        public List<Node> initNodes(Int32[] src)
        {
            List<Node> lists = new List<Node>();
            for (Int32 i = 0; i < src.Length; i++)
            {
                Node node = new Node();
                node.num = 0;//节点深度；
                node.left = null;
                node.right = null;
                node.weight = src[i];
                node.native = true;
                node.key = (byte) i;
                lists.Add(node);
            }
            return lists;
        }
    }
}
