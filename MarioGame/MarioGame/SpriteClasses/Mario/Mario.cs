using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public abstract class Mario : ISprite
    {
        public Vector2 spriteSpeed { get; set; }
        public Vector2 spritePosition;
        public Vector2 Position
        {
            get
            {
                return spritePosition;
            }
            set
            {
                float x = value.X - (spriteTexture.Width / (2 * FrameCountX));
                float y = value.Y - (spriteTexture.Height / (2 * FrameCountY));
                spritePosition = new Vector2(x, y);
            }
        }
        public float timePerFrame { get; set; }
        public Direction direction { get; set; }

        public Texture2D spriteTexture { get; set; }
        public int FrameCountX { get; set; }
        public int FrameCountY { get; set; }
        public int frameX { get; set; }
        public int frameY { get; set; }
        public float totalElapsedTime { get; set; }
        public int framesElapsed { get; set; }

        public Mario()
        {
            spriteSpeed = Vector2.Zero;
            spritePosition = Vector2.Zero;
            timePerFrame = (float)0.5 / Constants.FRAMES_PER_SECOND;
            direction = Direction.RIGHT;

            frameX = 0;
            frameY = 0;

            FrameCountX = 0;
            FrameCountY = 0;

            totalElapsedTime = 0;
            framesElapsed = 0;

        }

        abstract public void updateSprite(float elapsed);

        public void drawSprite(SpriteBatch batch)
        {
            // Get the size of a single frame in the texture
            int FrameWidth = this.spriteTexture.Width / this.FrameCountX;
            int FrameHeight = this.spriteTexture.Height / this.FrameCountY;

            // Draw the sprite
            Rectangle sourcerect = new Rectangle(FrameWidth * this.frameX, FrameHeight * this.frameY,
                FrameWidth, FrameHeight);
            batch.Draw(this.spriteTexture, this.spritePosition, sourcerect, Color.White);
        }

    }
}
