using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public abstract class AbstractObstacle : ISprite
    {
        public Vector2 Position { get; set; }
        protected Vector2 Origin { get; set; }
        protected Texture2D SpriteTexture { get; set; }
        protected int FrameCountX { get; set; }
        protected int FrameCountY { get; set; }
        protected int FrameX { get; set; }
        protected int FrameY { get; set; }

        protected int FrameWidth { get; set; }
        protected int FrameHeight { get; set; }

        public int Width
        {
            get { return FrameWidth; }
            set { FrameWidth = value; }
        }
        public int Height
        {
            get { return FrameHeight; }
            set { FrameHeight = value; }
        }

        public Vector2 Velocity { get; set; }

        public Vector2 Acceleration { get; set; }
        public IAnimation Animation { get; set; }

        protected AbstractObstacle(ContentManager content)
        {
            this.SpriteTexture = content.Load<Texture2D>("block");
            this.FrameX = 0;
            this.FrameY = 0;
            this.FrameCountX = 9;
            this.FrameCountY = 3;

            FrameWidth = this.SpriteTexture.Width / this.FrameCountX;
            FrameHeight = this.SpriteTexture.Height / this.FrameCountY;
            this.Position = Vector2.Zero;
            Origin = new Vector2(0f, FrameHeight);

           // Animation = new BrickSmooshAnimation();
        }

        abstract public void Update(float elapsed);

        public void Draw(SpriteBatch batch)
        {

            // Draw the sprite
            Rectangle sourcerect = new Rectangle(FrameWidth * this.FrameX, FrameHeight * this.FrameY,
                FrameWidth, FrameHeight);
            batch.Draw(this.SpriteTexture, this.Position, sourcerect, Color.White, 0, Origin, 1, SpriteEffects.None, 0);
        }

    }
}
