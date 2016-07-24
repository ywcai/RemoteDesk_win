using System.Collections.Generic;


namespace ywcai.util.compress
{
    class SortWeight : IComparer<Node>
    {
        public int Compare(Node x, Node y)
        {
            if(x.weight==y.weight)
            {
                return x.num.CompareTo(y.num);
            }
           return x.weight.CompareTo(y.weight);

        }
    }
}
