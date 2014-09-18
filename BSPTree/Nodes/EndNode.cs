using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSPTree.Nodes
{
    public class EndNode : Node
    {
        public GameObject GameObject { get; set; }

        public EndNode(Node parent, GameObject gameObject)
            : base(parent)
        {
            this.GameObject = gameObject;
        }
    }
}
