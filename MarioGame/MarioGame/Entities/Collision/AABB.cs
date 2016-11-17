using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public enum Side
    {
        TOP, LEFT, RIGHT, BOTTOM
    }

    public class AABB
    {
        public float X { get; set; }
        public float Y { get; set; }

        public float Width { get; set; }
        public float Height { get; set; }

        public Rectangle Rectangle
        {
            get { return new Rectangle((int)X,(int)Y,(int)Width,(int)Height); }
        }

        public Vector2 TopLeft
        {
            get { return new Vector2(X, Y); }
        }

        public Vector2 TopRight
        {
            get { return new Vector2(X + Width, Y); }
        }

        public Vector2 BottomLeft
        {
            get { return new Vector2(X, Y + Height); }
        }

        public Vector2 BottomRight
        {
            get { return new Vector2(X + Width, Y + Height); }
        }

        public Vector2 Center
        {
            get { return new Vector2(X + (Width / 2), Y + (Height / 2)); }
        }

        public AABB(Vector2 pos, float width, float height)
        {
            // Create rectangle by adjusting it to be created via bottom left corner
            X = pos.X;
            Y = pos.Y - height;

            this.Width = width;
            this.Height = height;
        }

        public AABB Intersect(AABB aabb)
        {
            Vector2 aMin = TopLeft;
            Vector2 aMax = BottomRight;
            Vector2 bMin = aabb.TopLeft;
            Vector2 bMax = aabb.BottomRight;

            float x1 = Math.Max(aMin.X, bMin.X);
            float x2 = Math.Min(aMax.X, bMax.X);

            float y1 = Math.Max(aMin.Y, bMin.Y);
            float y2 = Math.Min(aMax.Y, bMax.Y);

            Vector2 newPos = new Vector2(x1, y2);
            float width = Math.Abs(x2 - x1);
            float height = Math.Abs(y2 - y1);

            return new AABB(newPos, width, height);
        }

        public bool Collide(AABB box)
        {
            Vector2 aMin = TopLeft;
            Vector2 aMax = BottomRight;
            Vector2 bMin = box.TopLeft;
            Vector2 bMax = box.BottomRight;

            if (aMax.X < bMin.X || aMin.X > bMax.X) return false;

            if (aMax.Y < bMin.Y || aMin.Y > bMax.Y) return false;

            return true;
        }

        
        public static Side SideHit(AABB collided, AABB intersect)
        {
            Side result = Side.TOP;
            if (intersect.Height <= intersect.Width)
            {
                if (intersect.Center.Y > collided.Center.Y) result = Side.BOTTOM;
            }
            else
            {
                if (intersect.Center.X <= collided.Center.X) result = Side.LEFT;
                else result = Side.RIGHT;
            }

            return result;
        }
         

        /// <summary>
        /// Returns whether the point resides within this AABB 
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool Contains(Vector2 point)
        {
            bool xTrue = (point.X >= X && point.X <= X + Width);
            bool yTrue = (point.Y >= Y && point.Y <= Y + Height);

            return xTrue & yTrue;
        }

    }
}
