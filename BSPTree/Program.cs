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
            Stopwatch stopWatch = new Stopwatch();


            TheTree tree = new TheTree();
            //  tree.printTree();
            Console.WriteLine("------------");
            tree.quickSort(0, tree.Length - 1, 0);
            //  tree.printTree();
            Console.Read();

        }
    }
}
