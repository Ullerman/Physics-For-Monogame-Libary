using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Physics
{
    struct ball
    {
        public Vector2 origin;
        public float radius;
        public float mass;
        public Vector2 force;
        public Vector2 velocity;
        
        public ball(Vector2 origin, float radius,float mass,vector2 force,Vector2 velocity)
        {
            this.origin = origin;
            this.radius = radius;
            this.mass = mass;
            this.force = force;
            this.velocity = velocity;
        }
    }
}
