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
        public BSPTree tree { get; set; }

        public Benchmark() 
        {
            five = new GameObject[5];
            fifty = new GameObject[50];
            fivehundred = new GameObject[500];

            Random r = new Random();

            // add gameobjects to array
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

            // tree
        }

        public void benchMark1()
        {

        }

        public void benchMark2()
        {

        }

        public void benchMark3()
        {

        }

        public void benchMark4()
        {

        }

    }


}
