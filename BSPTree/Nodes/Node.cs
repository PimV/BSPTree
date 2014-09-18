using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSPTree.Nodes
{
    public class Node
    {
        public Node Parent { get; set; }

        public Node(Node parent)
        {
            this.Parent = parent;
        }


    }
}
