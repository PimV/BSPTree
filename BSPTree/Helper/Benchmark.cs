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
        public MyStopwatch stopWatch { get; set; }

        public Benchmark()
        {
            stopWatch = new MyStopwatch();

            five = new GameObject[5];
            fifty = new GameObject[50];
            fivehundred = new GameObject[500];

            Random r = new Random();
            for (int i = 0; i < five.Length; i++)
            {
                five[i] = new GameObject(r.Next(1000), r.Next(1000));
            }

            for (int i = 0; i < fifty.Length; i++)
            {
                fifty[i] = new GameObject(r.Next(1000), r.Next(1000));
            }

            for (int i = 0; i < fivehundred.Length; i++)
            {
                fivehundred[i] = new GameObject(r.Next(1000), r.Next(1000));
            }

            existingTree5 = new QuickSort(five);
            existingTree50 = new QuickSort(fifty);
            existingTree500 = new QuickSort(fivehundred);
        }

        public void benchMark1a()
        {
            stopWatch.Reset();
            stopWatch.Start();

            for (int i = 0; i < five.Length; i++)
            {
                existingTree5.search2(five[i].getX(), five[i].getY(), existingTree5.BspTree.Root);
            }

            stopWatch.Stop();

        }

        public void benchMark1b()
        {
            stopWatch.Reset();
            stopWatch.Start();

            for (int i = 0; i < fifty.Length; i++)
            {
                existingTree50.search2(fifty[i].getX(), fifty[i].getY(), existingTree50.BspTree.Root);
            }

            stopWatch.Stop();
        }

        public void benchMark1c()
        {
            stopWatch.Reset();
            stopWatch.Start();

            for (int i = 0; i < fivehundred.Length; i++)
            {
                existingTree500.search2(fivehundred[i].getX(), fivehundred[i].getY(), existingTree500.BspTree.Root);
            }

            stopWatch.Stop();
        }

        public void benchMark2a()
        {
            stopWatch.Reset();
            stopWatch.Start();

            QuickSort newTree5 = new QuickSort(five);
            for (int i = 0; i < five.Length; i++)
            {
                newTree5.search2(five[i].getX(), five[i].getY(), newTree5.BspTree.Root);
            }

            stopWatch.Stop();
        }
        public void benchMark2b() 
        {
            stopWatch.Reset();
            stopWatch.Start();

            QuickSort newTree50 = new QuickSort(fifty);
            for (int i = 0; i < fifty.Length; i++)
            {
                newTree50.search2(fifty[i].getX(), fifty[i].getY(), newTree50.BspTree.Root);
            }

            stopWatch.Stop();
        }
        public void benchMark2c() 
        {
            stopWatch.Reset();
            stopWatch.Start();

            QuickSort newTree500 = new QuickSort(fivehundred);
            for (int i = 0; i < fivehundred.Length; i++)
            {
                newTree500.search2(fivehundred[i].getX(), fivehundred[i].getY(), newTree500.BspTree.Root);
            }

            stopWatch.Stop();
        }


        public void benchMark3a()
        {
            stopWatch.Reset();
            stopWatch.Start();



            stopWatch.Stop();
        }
        public void benchMark3b()
        {
            stopWatch.Reset();
            stopWatch.Start();



            stopWatch.Stop();
        }
        public void benchMark3c()
        {
            stopWatch.Reset();
            stopWatch.Start();



            stopWatch.Stop();
        }

        public void benchMark4a() { }
        public void benchMark4b() { }
        public void benchMark4c() { }
        public void benchMark4d() { }

    }


}
