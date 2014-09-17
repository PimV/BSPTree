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
        public GameObject[] GameObjects { get { return gameObjects; } set { gameObjects = value; } }
        public List<GameObject> GameObjectList { get; set; }

        public TheTree()
        {
            this.gameObjects = new GameObject[this.amountOfGameObjects];
            this.populateTheTree();
        }

        public void printTree()
        {
            printArray(this.gameObjects);
        }

        public void printArray(GameObject[] gameObjectArray)
        {
            for (int i = 0; i < gameObjectArray.Length; i++)
            {
                if (gameObjectArray[i] != null)
                {
                    double x = gameObjectArray[i].getPosition(0);
                    double y = gameObjectArray[i].getPosition(1);

                    Console.WriteLine((i) + ": (" + x + ", " + y + ")");
                }

            }
            Console.WriteLine("-----------");
        }



        private void populateTheTree()
        {
            GameObject go1 = new GameObject(900, 100);
            GameObject go2 = new GameObject(100, 100);
            GameObject go3 = new GameObject(950, 50);
            GameObject go4 = new GameObject(50, 750);
            GameObject go5 = new GameObject(110, 90);
            GameObject go6 = new GameObject(60, 800);
            GameObject go7 = new GameObject(40, 800);
            GameObject go8 = new GameObject(700, 850);

            this.gameObjects[0] = go1;
            this.gameObjects[1] = go2;
            this.gameObjects[2] = go3;
            this.gameObjects[3] = go4;
            this.gameObjects[4] = go5;
            this.gameObjects[5] = go6;
            this.gameObjects[6] = go7;
            this.gameObjects[7] = go8;
        }

        public void quickSort(int begin, int end, int index)
        {
            int size = (end - begin) + 1;
            if (size == 2)
            {
                if (this.gameObjects[begin].getPosition(index) > this.gameObjects[end].getPosition(index))
                {
                    swap(begin, end);
                }
            }
            else if (size > 2)
            {
                double pivot = medianOfThree(begin, end, index);
                int middle = partition(begin, end, pivot, index);

                index++;
                if (index == GameObject.DIMENSION)
                {
                    index = 0;
                }
                quickSort(begin, middle - 1, index);
                quickSort(middle + 1, end, index);
            }
        }

        public void swap(int index1, int index2)
        {
            if (index1 != index2)
            {
                GameObject temp = this.gameObjects[index1];
                this.gameObjects[index1] = this.gameObjects[index2];
                this.gameObjects[index2] = temp;
            }
        }
        public double medianOfThree(int left, int right, int index)
        {
            int center = (left + right) / 2;

            if (this.gameObjects[left].getPosition(index) > this.gameObjects[center].getPosition(index))
            {
                swap(left, center);
            }

            if (this.gameObjects[left].getPosition(index) > this.gameObjects[right].getPosition(index))
            {
                swap(left, right);
            }

            if (this.gameObjects[center].getPosition(index) > this.gameObjects[right].getPosition(index))
            {
                swap(center, right);
            }

            swap(center, right - 1);

            return this.gameObjects[right - 1].getPosition(index);
        }

        public int partition(int left, int right, double pivot, int index)
        {
            int leftMark = left;
            int rightMark = right - 1;

            while (true)
            {

                while (this.gameObjects[++leftMark].getPosition(index) < pivot) ;
                while (this.gameObjects[--rightMark].getPosition(index) > pivot) ;



                if (leftMark >= rightMark)
                {
                    break;
                }
                else
                {
                    swap(leftMark, rightMark);
                }
            }

            swap(leftMark, right - 1);

            return leftMark;
        }




    }
}
