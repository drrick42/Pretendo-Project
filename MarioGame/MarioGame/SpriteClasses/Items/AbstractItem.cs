using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public abstract class AbstractItem : ISprite
    {
        public Vector2 Velocity { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Acceleration { get; set; }
        protected Vector2 Origin { get; set; }
        protected Texture2D SpriteTexture { get; set; }

        protected int FrameCountX { get; set; }
        protected int FrameCountY { get; set; }
        protected int FrameX { get; set; }
        protected int FrameY { get; set; }
        protected int FrameWidth { get; set; }
        protected int FrameHeight { get; set; }

        protected float TimePerFrame { get; set; }
        protected float TotalElapsedTime { get; set; }
        protected int FramesElapsed { get; set; }
        public int Width
        {
            get
            {
                if (FrameWidth == 0)
                {
                    FrameWidth = this.SpriteTexture.Width / this.FrameCountX;
                }
                return FrameWidth;
            }
            set { FrameWidth = value; }
        }
        public int Height
        {
            get
            {
                if (FrameHeight == 0)
                {
                    FrameHeight = this.SpriteTexture.Height / this.FrameCountY;
                }
                return FrameHeight;
            }
            set { FrameHeight = value; }
        }
        public Direction Direction { get; set; }
        protected AbstractItem(ContentManager content)
        {
            Direction = Direction.LEFT;
            this.SpriteTexture = content.Load<Texture2D>("items sprite sheet");
            this.FrameX = 0;
            this.FrameY = 0;
            this.FrameCountX = 5;
            this.FrameCountY = 1;
            this.TotalElapsedTime = 0;
            this.FramesElapsed = 0;
            this.TimePerFrame = 0;

            FrameWidth = this.SpriteTexture.Width / this.FrameCountX;
            FrameHeight = this.SpriteTexture.Height / this.FrameCountY;
            this.Position = Vector2.Zero;
            Origin = new Vector2(0f, FrameHeight);
        }

        public virtual void Update(float elapsed)
        {
            if ((Direction == Direction.LEFT && Velocity.X > 0) || (Direction == Direction.RIGHT && Velocity.X < 0))
            {
                this.Velocity = new Vector2(Velocity.X * -1, Velocity.Y);
            }
            this.Position += this.Velocity * elapsed;
        }

        public void Draw(SpriteBatch batch)
        {
            // Draw the sprite
            Rectangle sourcerect = new Rectangle(FrameWidth * this.FrameX, FrameHeight * this.FrameY,
                FrameWidth, FrameHeight);
            batch.Draw(this.SpriteTexture, this.Position, sourcerect, Color.White, 0, Origin, 1, SpriteEffects.None, 0);
        }

    }
}
