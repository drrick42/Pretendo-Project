using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public abstract class Enemy1 : ISprite
    {
        public Vector2 Velocity { get; set;}
        public Vector2 Acceleration { get; set; }
        public Vector2 Position { get; set; }
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
        public IAnimation Animation { get; set; }

        protected Enemy1(ContentManager content)
        {
            Velocity = Vector2.Zero;
            Acceleration = Vector2.Zero;

            TimePerFrame = 1/(float)Constants.FRAMES_PER_SECOND;
            Direction = Direction.LEFT;
            FrameX = 0;
            FrameY = 0;

            TotalElapsedTime = 0;
            FramesElapsed = 0;
        }

        public virtual void Update(float elapsed)
        {
            // Check if a frame has passed
            this.TotalElapsedTime += elapsed;
            if (this.TotalElapsedTime > this.TimePerFrame)
            {
                this.FramesElapsed++;

                // Update animation after a certain amount of frames
                if (this.FramesElapsed % 6 == 0)
                {
                    this.FrameX = Animation.GetNextFrame(this.FrameX);
                    this.FramesElapsed = 0;
                }

                this.TotalElapsedTime -= this.TimePerFrame;
            }

            if (Direction == Direction.LEFT && Velocity.X > 0)
            {
                this.Velocity = new Vector2(Velocity.X * -1, Velocity.Y);
            }
            this.Position += this.Velocity * elapsed;
        }

        public virtual void Draw(SpriteBatch batch)
        {
            // Get mirrored sprite if facing left
            int directionalFrame = this.FrameX;
            if (this.Direction == Direction.RIGHT) directionalFrame = (FrameCountX - 1) - this.FrameX;

            // Draw the sprite
            Rectangle sourcerect = new Rectangle(FrameWidth * directionalFrame, FrameHeight * this.FrameY,
                FrameWidth, FrameHeight);
            batch.Draw(this.SpriteTexture, this.Position, sourcerect, Color.White, 0, Origin, 1, SpriteEffects.None, 0);
        }
    }
}
