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
            TheTree tree = new TheTree();

            tree.printTree();

            tree.quickSort(0, 7, 0);

            tree.printTree();



            Console.Read();

        }
    }
}
