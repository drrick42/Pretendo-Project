using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class Bound
    {
        private Rectangle bound;

        public Rectangle Rectangle
        {
            get { return bound; }
        }

        public int Width
        { 
            get { return bound.Width; } 
        }

        public int Height
        {
            get { return bound.Height; }
        }

        public Vector2 TopLeft
        {
            get { return new Vector2(bound.Left, bound.Top); }
        }

        public Vector2 TopRight
        {
            get { return new Vector2(bound.Right, bound.Top); }
        }

        public Vector2 BottomLeft
        {
            get { return new Vector2(bound.Left, bound.Bottom); }
        }

        public Vector2 BottomRight
        {
            get { return new Vector2(bound.Right, bound.Bottom); }
        }

        public Bound(Rectangle screen)
        {
            this.bound = screen;
        }
    }
}
