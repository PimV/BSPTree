using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSPTree
{
    public class TheTree
    {
        private GameObject[] gameObjects;
        private int amountOfGameObjects = 8;
        public int Length { get { return gameObjects.Length; } }

        //COmment to commit

        public TheTree()
        {
            this.gameObjects = new GameObject[this.amountOfGameObjects];
            this.populateTheTree();
            this.determinePivot();
        }

        public void quickSort(int start, int end, int index)
        {
            if (start < end)
            {
                double pivot = this.gameObjects[end].getPosition(index);
                int middle = partition(start, end, pivot, index);
                quickSort(start, middle - 1, index);
                quickSort(middle + 1, end, index);
            }
        }

        public void printTree()
        {
            for (int i = 0; i < gameObjects.Length; i++)
            {
                double x = gameObjects[i].getPosition(0);
                double y = gameObjects[i].getPosition(1);

                Console.WriteLine((i + 1) + ": (" + x + ", " + y + ")");
            }
        }

        private void populateTheTree()
        {
            GameObject go1 = new GameObject(40, 800);
            GameObject go2 = new GameObject(60, 800);
            GameObject go3 = new GameObject(700, 850);
            GameObject go4 = new GameObject(50, 750);
            GameObject go6 = new GameObject(100, 100);
            GameObject go7 = new GameObject(110, 90);
            GameObject go8 = new GameObject(900, 100);
            GameObject go9 = new GameObject(950, 50);

            this.gameObjects[0] = go8;
            this.gameObjects[1] = go6;
            this.gameObjects[2] = go9;
            this.gameObjects[3] = go4;
            this.gameObjects[4] = go7;
            this.gameObjects[5] = go2;
            this.gameObjects[6] = go1;
            this.gameObjects[7] = go3;
        }

        private int partition(int left, int right, double pivot, int index)
        {
            int leftMark = left - 1;
            int rightMark = right;
            while (leftMark < rightMark)
            {
                while (this.gameObjects[++leftMark].getPosition(index) < pivot) ;

                while (rightMark > 0
                    && this.gameObjects[--rightMark].getPosition(index) > pivot) ;

                if (leftMark < rightMark)
                    swap(leftMark, rightMark);

            }
            swap(leftMark, right);
            return leftMark;
        }

        private void swap(int index1, int index2)
        {
            GameObject tmp = this.gameObjects[index1];
            this.gameObjects[index1] = this.gameObjects[index2];
            this.gameObjects[index2] = tmp;
        }

        private double determinePivot()
        {
            GameObject lowest = this.gameObjects[0];
            GameObject middle = this.gameObjects[(this.gameObjects.Length / 2)];
            GameObject highest = this.gameObjects[this.gameObjects.Length - 1];

            double lowestXValue = lowest.getPosition(0);
            if (lowestXValue > middle.getPosition(0))
            {
                lowestXValue = middle.getPosition(0);
            }
            if (lowestXValue > highest.getPosition(0))
            {
                lowestXValue = highest.getPosition(0);
            }
            //JO

            double highestXValue = highest.getPosition(0);
            if (highestXValue < middle.getPosition(0))
            {
                highestXValue = middle.getPosition(0);
            }
            if (highestXValue < lowest.getPosition(0))
            {
                highestXValue = lowest.getPosition(0);
            }

            
            Console.WriteLine(highestXValue);
            Console.WriteLine(lowestXValue);


            return -1;
        }
    }
}
