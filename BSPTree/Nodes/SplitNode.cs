using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSPTreeGUI.Nodes
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
            if (lowerArray[index] != null)
            {
                return lowerArray[index];
            }
            if (this.LeftChild.lowerBound(index) < this.RightChild.lowerBound(index))
            {
                return this.LeftChild.lowerBound(index);
            }
            else
            {
                return this.RightChild.lowerBound(index);
            }
        }

        public override double upperBound(int index)
        {
            if (upperArray[index] != null)
            {
                return upperArray[index];
            }
            if (this.LeftChild.upperBound(index) > this.RightChild.upperBound(index))
            {
                return this.LeftChild.upperBound(index);
            }
            else
            {
                return this.RightChild.upperBound(index);
            }
        }

        //public override string ToString()
        //{
        //    String returnString = "";
        //    if (LeftChild != null && LeftChild is EndNode)
        //    {
        //        returnString += "left" + LeftChild + " |";
        //    }
        //    if (RightChild != null && RightChild is EndNode)
        //    {
        //        returnString += "| right child: " + RightChild;
        //    }
        //    return returnString;
        //}

    }
}
