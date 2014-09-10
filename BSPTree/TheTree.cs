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

        //COmment to commit

        public TheTree()
        {
            GameObjectList = new List<GameObject>();
            this.gameObjects = new GameObject[this.amountOfGameObjects];
            this.populateTheTree();
        }

        public void quickSort(int start, int end, int index)
        {
            if (start < end)
            {
                double pivot = determinePivot(this.gameObjects, amountOfGameObjects, index);
                Console.WriteLine(pivot);
                int middle = partition(start, end, pivot, index);
                quickSort(start, middle - 1, index);
                quickSort(middle + 1, end, index);
            }
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

            //this.gameObjects[0] = go8;
            //this.gameObjects[1] = go6;
            //this.gameObjects[2] = go9;
            //this.gameObjects[3] = go4;
            //this.gameObjects[4] = go7;
            //this.gameObjects[5] = go2;
            //this.gameObjects[6] = go1;
            //this.gameObjects[7] = go3;

            this.gameObjects[7] = go8;
            this.gameObjects[6] = go6;
            this.gameObjects[5] = go9;
            this.gameObjects[4] = go4;
            this.gameObjects[3] = go7;
            this.gameObjects[2] = go2;
            this.gameObjects[1] = go1;
            this.gameObjects[0] = go3;
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

        public void splitArray(GameObject[] gameData, double pivot, int index)
        {
            

            if (gameData[0] == null || gameData[1] == null)
            {
                Console.WriteLine("STARTING ARRAY (PIVOT = " + pivot + "): ");
                printArray(gameData);
                Console.WriteLine("");
                return;
            }
            GameObject[] upperHalf = new GameObject[gameData.Length];
            GameObject[] lowerHalf = new GameObject[gameData.Length];
            int upperHalfElements = 0;
            int lowerHalfElements = 0;
            for (int i = 0; i < gameData.Length; i++)
            {
                if (gameData[i] != null)
                {
                    double value = gameData[i].getPosition(index);
                    if (value >= pivot)
                    {
                        upperHalf[upperHalfElements++] = gameData[i];
                    }
                    else
                    {
                        lowerHalf[lowerHalfElements++] = gameData[i];
                    }
                }
            }
            //Console.WriteLine("UPPER HALF: ");
            //printArray(upperHalf);
            //Console.WriteLine("");
            //Console.WriteLine("LOWER HALF: ");
            //printArray(lowerHalf);
            //Console.WriteLine("");
            if (index == 0)
            {
                index = 1;
            }
            else
            {
                index = 0;
            }
            splitArray(upperHalf, determinePivot(upperHalf, upperHalfElements, index), index);
            splitArray(lowerHalf, determinePivot(lowerHalf, lowerHalfElements, index), index);
        }

        public double determinePivot(GameObject[] gameData, int sizeOfArray, int index)
        {
            int lowestIndex = 0;
            int middleIndex = (int)Math.Round((double)(sizeOfArray / 2));
            int highestIndex = sizeOfArray - 1;

            GameObject lowest = gameData[lowestIndex];
            GameObject middle = gameData[middleIndex];
            GameObject highest = gameData[highestIndex];

            double lowestX = lowest.getPosition(index);
            double middleX = middle.getPosition(index);
            double highestX = highest.getPosition(index);

            int trueLowest = 0;
            int pivotIndex = 0;
            int trueHighest = 0;

            if (lowestX > middleX && lowestX > highestX)
            {
                trueHighest = lowestIndex;
            }
            else if (middleX > lowestX && middleX > highestX)
            {
                trueHighest = middleIndex;
            }
            else if (highestX > lowestX && highestX > middleX)
            {
                trueHighest = highestIndex;

            }

            if (lowestX < middleX && lowestX < highestX)
            {
                trueLowest = lowestIndex;
                if (trueHighest != middleIndex)
                {
                    pivotIndex = middleIndex;
                }
                else
                {
                    pivotIndex = highestIndex;
                }
            }
            else if (middleX < lowestX && middleX < highestX)
            {
                trueLowest = middleIndex;
                if (trueHighest != lowestIndex)
                {
                    pivotIndex = lowestIndex;
                }
                else
                {
                    pivotIndex = highestIndex;
                }
            }
            else if (highestX < lowestX && highestX < middleX)
            {
                trueLowest = highestIndex;
                if (trueHighest != middleIndex)
                {
                    pivotIndex = middleIndex;
                }
                else
                {
                    pivotIndex = lowestIndex;
                }
            }
            //Console.WriteLine("True Highest vs Initial Highest: " + trueHighest + "vs" + highestIndex);
            //Console.WriteLine("True Lowest vs Initial Lowest: " + trueLowest + "vs" + lowestIndex);

            swap(trueHighest, highestIndex);
            swap(trueLowest, lowestIndex);

            return gameData[pivotIndex].getPosition(index);
        }
    }
}
