using BSPTree.Nodes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSPTree
{
    class Program
    {
        static void Main(string[] args)
        {
            QuickSort tree = new QuickSort();

            tree.printTree();

            tree.bsp(0, 7, 0, tree.BspTree.Root);

            tree.printTree();



            Console.Read();

        }
    }
}
