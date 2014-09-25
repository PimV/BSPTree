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
        public Node Root { get; set; }

        public BSPTree()
        {
            //this.Root = new SplitNode(null, null, null);
        }

        public void printBspTree()
        {
        }

        public void inOrder(Node node)
        {
            //if (node != null)
            //{
            //    if (node.GetType() == typeof(SplitNode))
            //    {
            //        inOrder(node.LeftChild);
            //        Console.WriteLine(node);
            //        inOrder(node.RightChild);
            //    }
            //}
        }

    }
}
