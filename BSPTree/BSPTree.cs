using BSPTree.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSPTree
{
    public class BSPTree
    {
        public SplitNode Root { get; set; }

        public BSPTree()
        {
            this.Root = new SplitNode(null, null, null);

        }

    }
}
