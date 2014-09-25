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
        public int ChildCount
        {
            get
            {
                int count = 0;
                if (LeftChild != null)
                {
                    count++;
                }
                if (RightChild != null)
                {
                    count++;
                }
                return count;
            }
        }

        public SplitNode(Node parent, Node leftChild, Node rightChild)
            : base(parent)
        {
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        //public override string ToString()
        //{
        //    String returnString = "SplitNode with [";
        //    if (LeftChild != null)
        //    {
        //        returnString += " left child: " + LeftChild + " |";
        //    }
        //    if (RightChild != null)
        //    {
        //        returnString += "| right child: " + RightChild;
        //    }
        //    returnString += "] as children.";
        //    return returnString;
        //}


    }
}
