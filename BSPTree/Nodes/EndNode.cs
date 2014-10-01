using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSPTreeGUI.Nodes
{
    public class EndNode : Node
    {
        public GameObject GameObject { get; set; }
        public EndNode(Node parent, GameObject gameObject)
            : base(parent)
        {
            this.GameObject = gameObject;
        }

        public override string ToString()
        {
            return GameObject.getX() + ":" + GameObject.getY();
        }

        public override double lowerBound(int index)
        {
            return GameObject.getPosition(index);
        }

        public override double upperBound(int index)
        {
            return GameObject.getPosition(index);
        }
    }
}
