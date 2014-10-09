using BSPTreeGUI.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BSPTreeGUI.Helper
{
    // Benchmark 1: search in exisiting BSP tree.
    //  a. 5 game objects
    //  b. 50 game objects
    //  c. 500 game objects
    // Benchmark 2: create BSPTree and search.
    //  a. 5 game objects
    //  b. 50 game objects
    //  c. 500 game objects
    // Benchmark 3: search through array to find which object has been clicked on.
    //  a. 5 game objects
    //  b. 50 game objects
    //  c. 500 game objects
    // Benchmark 4: click on multiple objects at once
    // I. 0 objecten
    // II. 1 object
    // III. 2 objecten
    // IIII. 3 objecten

    public class Benchmark
    {
        public GameObject[] five { get; set; }
        public GameObject[] fifty { get; set; }
        public GameObject[] fivehundred { get; set; }

        public QuickSort existingTree5 { get; set; }
        public QuickSort existingTree50 { get; set; }
        public QuickSort existingTree500 { get; set; }

        public double target1X { get; set; }
        public double target1Y { get; set; }
        public double target2X { get; set; }
        public double target2Y { get; set; }

        public MyStopwatch stopWatch { get; set; }

        public Benchmark()
        {
            //First Index
            target1X = 50;
            target1Y = 50;

            //Last Index
            target2X = 1000;
            target2Y = 1000;


            stopWatch = new MyStopwatch();

            five = new GameObject[5];
            fifty = new GameObject[50];
            fivehundred = new GameObject[500];

            Random r = new Random();
            for (int i = 0; i < five.Length; i++)
            {
                five[i] = new GameObject(r.Next(1000), r.Next(1000));
            }
            five[five.Length - 1] = new GameObject(target1X, target1Y);
            five[0] = new GameObject(target2X, target2Y);

            for (int i = 0; i < fifty.Length; i++)
            {
                fifty[i] = new GameObject(r.Next(1000), r.Next(1000));
            }
            fifty[fifty.Length - 1] = new GameObject(target1X, target1Y);
            fifty[0] = new GameObject(target2X, target2Y);

            for (int i = 0; i < fivehundred.Length; i++)
            {
                fivehundred[i] = new GameObject(r.Next(1000), r.Next(1000));
            }
            fivehundred[fivehundred.Length - 1] = new GameObject(target1X, target1Y);
            fivehundred[0] = new GameObject(target2X, target2Y);

            existingTree5 = new QuickSort(five);
            existingTree50 = new QuickSort(fifty);
            existingTree500 = new QuickSort(fivehundred);
        }

        public void benchMark1a()
        {
            stopWatch.Reset();
            stopWatch.Start();

            //for (int i = 0; i < five.Length; i++)
            //{
            existingTree5.search2(target1X, target1Y, existingTree5.BspTree.Root, new List<Node>());
            existingTree5.search2(target2X, target2Y, existingTree5.BspTree.Root, new List<Node>());
            //existingTree5.search2(five[i].getX(), five[i].getY(), existingTree5.BspTree.Root);
            //}

            stopWatch.Stop();

        }

        public void benchMark1b()
        {
            stopWatch.Reset();
            stopWatch.Start();

            //for (int i = 0; i < fifty.Length; i++)
            //{
            existingTree50.search2(target1X, target1Y, existingTree50.BspTree.Root, new List<Node>());
            existingTree50.search2(target2X, target2Y, existingTree50.BspTree.Root, new List<Node>());
            //existingTree50.search2(fifty[i].getX(), fifty[i].getY(), existingTree50.BspTree.Root);
            //}

            stopWatch.Stop();
        }

        public void benchMark1c()
        {
            stopWatch.Reset();
            stopWatch.Start();

            //for (int i = 0; i < fivehundred.Length; i++)
            //{
            existingTree500.search2(target1X, target1Y, existingTree500.BspTree.Root, new List<Node>());
            existingTree500.search2(target2X, target2Y, existingTree500.BspTree.Root, new List<Node>());
            //existingTree500.search2(fivehundred[i].getX(), fivehundred[i].getY(), existingTree500.BspTree.Root);
            //}

            stopWatch.Stop();
        }

        public void benchMark2a()
        {
            stopWatch.Reset();
            stopWatch.Start();

            QuickSort newTree5 = new QuickSort(five);
            //for (int i = 0; i < five.Length; i++)
            //{
            newTree5.search2(target1X, target1Y, newTree5.BspTree.Root, new List<Node>());
            newTree5.search2(target2X, target2Y, newTree5.BspTree.Root, new List<Node>());
            //newTree5.search2(five[i].getX(), five[i].getY(), newTree5.BspTree.Root);
            //}

            stopWatch.Stop();
        }
        public void benchMark2b()
        {
            stopWatch.Reset();
            stopWatch.Start();

            QuickSort newTree50 = new QuickSort(fifty);
            //for (int i = 0; i < fifty.Length; i++)
            //{
            newTree50.search2(target1X, target1Y, newTree50.BspTree.Root, new List<Node>());
            newTree50.search2(target2X, target2Y, newTree50.BspTree.Root, new List<Node>());
            //newTree50.search2(fifty[i].getX(), fifty[i].getY(), newTree50.BspTree.Root);
            //}

            stopWatch.Stop();
        }
        public void benchMark2c()
        {
            stopWatch.Reset();
            stopWatch.Start();

            QuickSort newTree500 = new QuickSort(fivehundred);
            //for (int i = 0; i < fivehundred.Length; i++)
            //{
            newTree500.search2(target1X, target1Y, newTree500.BspTree.Root, new List<Node>());
            newTree500.search2(target2X, target2Y, newTree500.BspTree.Root, new List<Node>());
            //newTree500.search2(fivehundred[i].getX(), fivehundred[i].getY(), newTree500.BspTree.Root);
            //}

            stopWatch.Stop();
        }


        public void benchMark3a()
        {
            stopWatch.Reset();
            stopWatch.Start();

            QuickSort newTree5 = new QuickSort(five);
            for (int i = 0; i < five.Length; i++)
            {
                if (newTree5.GameObjects[i].getX() == target1X && newTree5.GameObjects[i].getY() == target1Y)
                {
                    break;
                    //FOund
                }
            }

            for (int i = 0; i < five.Length; i++)
            {
                if (newTree5.GameObjects[i].getX() == target2X && newTree5.GameObjects[i].getY() == target2Y)
                {
                    break;
                    //FOund
                }
            }


            stopWatch.Stop();
        }
        public void benchMark3b()
        {
            stopWatch.Reset();
            stopWatch.Start();

            QuickSort newTree50 = new QuickSort(fifty);
            for (int i = 0; i < fifty.Length; i++)
            {
                if (newTree50.GameObjects[i].getX() == target1X && newTree50.GameObjects[i].getY() == target1Y)
                {
                    break;
                    //FOund
                }
            }

            for (int i = 0; i < fifty.Length; i++)
            {
                if (newTree50.GameObjects[i].getX() == target2X && newTree50.GameObjects[i].getY() == target2Y)
                {
                    break;
                    //FOund
                }
            }


            stopWatch.Stop();
        }
        public void benchMark3c()
        {
            stopWatch.Reset();
            stopWatch.Start();
            QuickSort newTree500 = new QuickSort(fivehundred);
            for (int i = 0; i < fivehundred.Length; i++)
            {
                if (newTree500.GameObjects[i].getX() == target1X && newTree500.GameObjects[i].getY() == target1Y)
                {
                    break;
                    //FOund
                }
            }

            for (int i = 0; i < fivehundred.Length; i++)
            {
                if (newTree500.GameObjects[i].getX() == target2X && newTree500.GameObjects[i].getY() == target2Y)
                {
                    break;
                    //FOund
                }
            }


            stopWatch.Stop();
        }

        public void benchMark4a() { }
        public void benchMark4b() { }
        public void benchMark4c() { }
        public void benchMark4d() { }

    }


}
