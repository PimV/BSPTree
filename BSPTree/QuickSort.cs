using BSPTreeGUI.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSPTreeGUI
{
    public class QuickSort
    {
        private GameObject[] gameObjects;
        private int amountOfGameObjects = 8;
        public int Length { get { return gameObjects.Length; } }
        public GameObject[] GameObjects { get { return gameObjects; } set { gameObjects = value; } }
        public List<GameObject> GameObjectList { get; set; }
        public BSPTree BspTree { get; set; }

        public QuickSort()
        {
            this.gameObjects = new GameObject[this.amountOfGameObjects];
            this.BspTree = new BSPTree();

            this.populateTheTree();
            this.BspTree.Root = bsp(0, 7, 0, null);
            updateXY(this.BspTree.Root);
            search2(900, 100, this.BspTree.Root, null, false);
            search2(100, 100, this.BspTree.Root, null, false);
            search2(950, 50, this.BspTree.Root, null, false);
            search2(50, 750, this.BspTree.Root, null, false);
            search2(110, 90, this.BspTree.Root, null, false);
            search2(60, 800, this.BspTree.Root, null, false);
            search2(40, 800, this.BspTree.Root, null, false);
            search2(700, 850, this.BspTree.Root, null, false);

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

        public Node bsp(int left, int right, int index, Node parent)
        {
            Node node;

            int size = (right - left) + 1;
            if (size == 2)
            {
                node = new SplitNode(parent, null, null);

                EndNode rightNode = new EndNode(node, this.gameObjects[right]);
                EndNode leftNode = new EndNode(node, this.gameObjects[left]);
                if (this.gameObjects[left].getPosition(index) > this.gameObjects[right].getPosition(index))
                {
                    leftNode.GameObject = this.gameObjects[right];
                    rightNode.GameObject = this.gameObjects[left];
                    swap(left, right);
                }

                ((SplitNode)node).RightChild = rightNode;
                ((SplitNode)node).LeftChild = leftNode;
            }
            else if (size > 2)
            {
                node = new SplitNode(parent, null, null);

                double pivot = medianOfThree(left, right, index);
                int partition = partitionIt(left, right, pivot, index);

                index++;
                if (index == GameObject.DIMENSION)
                {
                    index = 0;
                }
                Node leftChild = bsp(left, partition, index, node);
                Node rightChild = bsp(partition + 1, right, index, node);
                //                leftChild.Parent = node;
                //                rightChild.Parent = node;
                ((SplitNode)node).RightChild = rightChild;
                ((SplitNode)node).LeftChild = leftChild;
            }
            else // (if size == 1)
            {
                node = new EndNode(parent, this.gameObjects[left]);
                // EndNode leftEndNode = new EndNode(splitNode, this.gameObjects[left]);
                // splitNode.LeftChild = leftEndNode;
            }


            return node;
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

        public int partitionIt(int left, int right, double pivot, int index)
        {
            int leftMark = left;
            int rightMark = right - 1;

            while (true)
            {

                while (this.gameObjects[++leftMark].getPosition(index) < pivot)
                {

                }
                while (this.gameObjects[--rightMark].getPosition(index) > pivot)
                {

                }



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

        private void updateXY(Node node)
        {
            if (node is SplitNode)
            {
                SplitNode sn = ((SplitNode)node);

                sn.lowerArray[0] = sn.lowerBound(0);
                sn.lowerArray[1] = sn.lowerBound(1);

                sn.upperArray[0] = sn.upperBound(0);
                sn.upperArray[1] = sn.upperBound(1);

                if (sn.LeftChild != null)
                {
                    updateXY(sn.LeftChild);
                }

                if (sn.RightChild != null)
                {
                    updateXY(sn.RightChild);
                }
            }
        }

        public void search2(double x, double y, Node currentNode, SplitNode lastLeftNode, Boolean walkBack)
        {
            if (lastLeftNode == null && walkBack == true)
            {
                return;
            }
            if (currentNode is EndNode)
            {
                EndNode currentEndNode = (EndNode)currentNode;

                if (currentEndNode.GameObject.getX() == x && currentEndNode.GameObject.getY() == y)
                {
                    Console.WriteLine("Game Object found");


                }
                else
                {

                    search2(x, y, lastLeftNode, null, true);

                }
            }

            if (currentNode is SplitNode)
            {
                SplitNode currentSplitNode = (SplitNode)currentNode;
                if (walkBack == true)
                {
                    if (currentSplitNode.RightChild is SplitNode)
                    {
                        SplitNode currentRightSplitNode = (SplitNode)currentSplitNode.RightChild;
                        if (x >= currentRightSplitNode.lowerArray[0] &&
                       x <= currentRightSplitNode.upperArray[0] &&
                       y >= currentRightSplitNode.lowerArray[1] &&
                       y <= currentRightSplitNode.upperArray[1])
                        {
                            search2(x, y, currentSplitNode.RightChild, lastLeftNode, walkBack);
                        }
                        else
                        {
                            search2(x, y, currentSplitNode.LeftChild, currentSplitNode, walkBack);
                        }
                    }
                    else if (currentSplitNode.RightChild is EndNode)
                    {
                        EndNode currentRightEndNode = (EndNode)currentSplitNode.LeftChild;
                        if (x >= currentRightEndNode.lowerBound(0) &&
                      x <= currentRightEndNode.upperBound(0) &&
                      y >= currentRightEndNode.lowerBound(1) &&
                      y <= currentRightEndNode.upperBound(1))
                        {
                            search2(x, y, currentSplitNode.RightChild, lastLeftNode, walkBack);
                        }
                        else
                        {
                            search2(x, y, currentSplitNode.LeftChild, currentSplitNode, walkBack);
                        }
                    }
                }
                else
                {
                    if (currentSplitNode.LeftChild is SplitNode)
                    {
                        SplitNode currentLeftSplitNode = (SplitNode)currentSplitNode.LeftChild;
                        if (x >= currentLeftSplitNode.lowerArray[0] &&
                       x <= currentLeftSplitNode.upperArray[0] &&
                       y >= currentLeftSplitNode.lowerArray[1] &&
                       y <= currentLeftSplitNode.upperArray[1])
                        {
                            search2(x, y, currentSplitNode.LeftChild, currentSplitNode, walkBack);
                        }
                        else
                        {
                            search2(x, y, currentSplitNode.RightChild, lastLeftNode, walkBack);
                        }
                    }
                    else if (currentSplitNode.LeftChild is EndNode)
                    {
                        EndNode currentLeftEndNode = (EndNode)currentSplitNode.LeftChild;
                        if (x >= currentLeftEndNode.lowerBound(0) &&
                      x <= currentLeftEndNode.upperBound(0) &&
                      y >= currentLeftEndNode.lowerBound(1) &&
                      y <= currentLeftEndNode.upperBound(1))
                        {
                            search2(x, y, currentSplitNode.LeftChild, currentSplitNode, walkBack);
                        }
                        else
                        {
                            search2(x, y, currentSplitNode.RightChild, lastLeftNode, walkBack);
                        }
                    }
                }



                //if (x >= currentSplitNode.LeftChild.lowerBound(0) &&
                //    x <= currentSplitNode.LeftChild.upperBound(0) &&
                //    y >= currentSplitNode.LeftChild.lowerBound(1) &&
                //    y <= currentSplitNode.LeftChild.upperBound(1))
                //{
                //    search2(x, y, currentSplitNode.LeftChild, currentSplitNode);
                //}
                //else
                //{
                //    search2(x, y, currentSplitNode.RightChild, lastLeftNode);
                //}
            }
        }

        public void search(double x, double y, Node currentNode, SplitNode lastLeftNode)
        {

            //Console.WriteLine(currentNode);
            if (currentNode is EndNode)
            {
                // Console.WriteLine(x + ":" + y + ":" + ((EndNode)currentNode).GameObject.getX() + ":" + ((EndNode)currentNode).GameObject.getY());
                // Console.WriteLine(((EndNode)currentNode).GameObject.getX() + ":" + ((EndNode)currentNode).GameObject.getY());
                if (((EndNode)currentNode).GameObject.getX() == x &&
                    ((EndNode)currentNode).GameObject.getY() == y)
                {
                    Console.WriteLine("Object is FOUND! (" + x + "," + y + ")");
                    //Console.WriteLine(((EndNode)currentNode).GameObject.getX() + ":" + ((EndNode)currentNode).GameObject.getY());
                }
                else
                {

                    //search(x, y, lastLeftNode.RightChild, null);
                    //Console.WriteLine("Object is NOT FOUND! (" + x + "," + y + ")");
                }
            }

            if (currentNode is SplitNode)
            {
                //  Console.WriteLine(((SplitNode)currentNode).lowerArray[0] + ":" + ((SplitNode)currentNode).upperArray[0] + ":" + ((SplitNode)currentNode).lowerArray[1] + ":" + ((SplitNode)currentNode).upperArray[1]);
                if (x >= ((SplitNode)currentNode).lowerArray[0] &&
                    x <= ((SplitNode)currentNode).upperArray[0] &&
                    y >= ((SplitNode)currentNode).lowerArray[1] &&
                    y <= ((SplitNode)currentNode).upperArray[1])
                {
                    Console.WriteLine(lastLeftNode);
                    //  Console.WriteLine("Left!");
                    search(x, y, ((SplitNode)currentNode).LeftChild, ((SplitNode)currentNode));
                }
                else
                {
                    // Console.WriteLine("Right!");
                    search(x, y, ((SplitNode)currentNode).RightChild, lastLeftNode);
                }
            }
        }
    }
}
