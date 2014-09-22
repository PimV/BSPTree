using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSPTree.Nodes
{
    public class SplitNode : Node
    {
        public Node LeftChild { get; set; }
        public Node RightChild { get; set; }

        public SplitNode(Node parent, Node leftChild, Node rightChild)
            : base(parent)
        {
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }


    }
}
