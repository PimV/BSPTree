using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSPTree
{
    public class GameObject
    {
        public static int DIMENSION = 2;
        private double[] position = new double[DIMENSION];

        public GameObject(double x, double y)
        {
            this.position[0] = x;
            this.position[1] = y;
        }

        public double getX()
        {
            return this.position[0];
        }

        public double getY()
        {
            return this.position[1];
        }

        public double getPosition(int index)
        {
            return position[index];
        }

    }
}
