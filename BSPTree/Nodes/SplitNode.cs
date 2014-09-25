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

        private int DIMENSION = 2;
        public virtual double[] lowerArray { get; set; }
        public virtual double[] upperArray { get; set; }

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
            
            this.lowerArray = new double[DIMENSION];
            this.upperArray = new double[DIMENSION];

        }

        public override double lowerBound(int index)
        {
            if (this.LeftChild != null && this.RightChild != null)
            {
                if (this.LeftChild.lowerBound(index) < this.RightChild.lowerBound(index))
                {
                    return this.LeftChild.lowerBound(index);
                }
                else
                {
                    return this.RightChild.lowerBound(index);
                }
            }
            return 0;
        }

        public override double upperBound(int index)
        {
            if (this.LeftChild != null && this.RightChild != null)
            {
                if (this.LeftChild.upperBound(index) > this.RightChild.upperBound(index))
                {
                    return this.LeftChild.upperBound(index);
                }
                else
                {
                    return this.RightChild.upperBound(index);
                }
            }
            return 0;
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
