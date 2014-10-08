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

            tree = new QuickSort();
          //  tree.search(100, 100, tree.BspTree.Root);
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
