﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics
{
    class Circle
    {
        public Vector2 origin;
        public float radius;
        public Circle(Vector2 origin, float radius)
        {
            this.origin = origin;
            this.radius = radius;
          
        }
    }
}
