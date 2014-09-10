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
            tree.splitArray(tree.GameObjects, tree.determinePivot(tree.GameObjects, 8, 0), 0);
            foreach (GameObject go in tree.GameObjectList)
            {
                double x = go.getPosition(0);
                double y = go.getPosition(1);

                Console.WriteLine("(" + x + ", " + y + ")");
            }
            Console.Read();

        }
    }
}
