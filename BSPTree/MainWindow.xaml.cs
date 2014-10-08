using BSPTreeGUI.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BSPTreeGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        QuickSort tree;

        public MainWindow()
        {
            InitializeComponent();

            this.MouseLeftButtonDown += Canvas_MouseLeftButtonDown;

            Benchmark bm = new Benchmark();

            Console.WriteLine("Benchmark 1: ");
            bm.benchMark1a();
            Console.WriteLine("1a: 5 Game objects. Time elapsed: " + bm.stopWatch.ElapsedNanoSeconds + " nanoseconds");

            bm.benchMark1b();
            Console.WriteLine("1b: 50 Game objects. Time elapsed: " + bm.stopWatch.ElapsedNanoSeconds + " nanoseconds");

            bm.benchMark1c();
            Console.WriteLine("1c: 500 Game objects. Time elapsed: " + bm.stopWatch.ElapsedNanoSeconds + " nanoseconds");

            Console.WriteLine("Benchmark 2: ");
            bm.benchMark2a();
            Console.WriteLine("2a: 5 Game objects. Time elapsed: " + bm.stopWatch.ElapsedNanoSeconds + " nanoseconds");
            
            bm.benchMark2b();
            Console.WriteLine("2b: 50 Game objects. Time elapsed: " + bm.stopWatch.ElapsedNanoSeconds + " nanoseconds");
            
            bm.benchMark2c();
            Console.WriteLine("2c: 500 Game objects. Time elapsed: " + bm.stopWatch.ElapsedNanoSeconds + " nanoseconds");

            bm.benchMark3a();
            bm.benchMark3b();
            bm.benchMark3c();

            bm.benchMark4a();
            bm.benchMark4b();
            bm.benchMark4c();
            bm.benchMark4d();

            tree = new QuickSort();
            //tree.search(100, 100, tree.BspTree.Root);


            foreach (GameObject go in tree.GameObjects)
            {
                Console.WriteLine("X: " + go.getX() + " - Y: " + go.getY());
            }
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point point = e.GetPosition(this);

            Console.WriteLine("Clicked on X: " + point.X + " Y: " + point.Y);
            //tree.search(point.X, point.Y, tree.BspTree.Root, null);
            tree.search2(point.X, point.Y, tree.BspTree.Root);//, null, false);
        }
    }
}
