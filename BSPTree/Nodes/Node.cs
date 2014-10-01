using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSPTreeGUI.Nodes
{
    public abstract class Node
    {
        public Node Parent { get; set; }

        public Node(Node parent)
        {
            this.Parent = parent;
        }

        public abstract double lowerBound(int index);
        public abstract double upperBound(int index);
    }
}
