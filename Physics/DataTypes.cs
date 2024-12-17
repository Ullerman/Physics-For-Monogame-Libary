using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Physics
{
    struct Circle
    {
        public Vector2 origin;
        public float radius;
        public float mass;
        public float force;
        
        public Circle(Vector2 origin, float radius)
        {
            this.origin = origin;
            this.radius = radius;
        }
    }
}
