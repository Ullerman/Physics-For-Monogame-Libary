using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Physics
{
    internal class Physics
    {
        private float DistanceSquaredBetweenPointAndRect(Rectangle rectangle, Vector2 point)
        {
            float closestX = Math.Clamp(point.X, rectangle.Left, rectangle.Right);
            float closestY = Math.Clamp(point.Y, rectangle.Top, rectangle.Bottom);

            float distanceX = point.X - closestX;
            float distanceY = point.Y - closestY;

            float distance = distanceX * distanceX + distanceY * distanceY;
            return distance;
        }

        private float DistanceSquaredBetweenPoints(Vector2 point1, Vector2 point2)
        {
            return (point1.X * point1.X + point2.Y * point2.Y);
        }

        private float CalculateAngleBetweenPoints(Vector2 point1, Vector2 point2)
        {
            float deltaX = point2.X - point1.X;
            float deltaY = point2.Y - point1.Y;

            float angle = MathF.Atan2(deltaY, deltaX);

            return angle;
        }

        public Vector2 GetPointOnCircumference(Circle circle, float angle)
        {
            float x = circle.origin.X + circle.radius * MathF.Cos(angle);
            float y = circle.origin.Y + circle.radius * MathF.Sin(angle);
            return new Vector2(x, y);
        }

        public bool IsIntersecting(Circle circle, Rectangle rectangle)
        {
            float distance = DistanceSquaredBetweenPointAndRect(rectangle, circle.origin);
            return distance <= (circle.radius * circle.radius);
        }

        public bool IsIntersecting(Circle circle, Circle circle2)
        {
            float angle = CalculateAngleBetweenPoints(circle.origin, circle2.origin);
            Vector2 nearestPoint = GetPointOnCircumference(circle, angle);
            float distance = DistanceSquaredBetweenPoints(nearestPoint, circle2.origin);
            return (distance <= (circle.radius * circle.radius));
        }
    }
}
