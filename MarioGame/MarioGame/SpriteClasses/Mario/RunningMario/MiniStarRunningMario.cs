using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class MiniStarRunningMario : RunningMario
    {
        public MiniStarRunningMario(ContentManager content)
            : base()
        {
            this.spriteTexture = content.Load<Texture2D>("mini star mario");
            this.FrameCountX = 10;
            this.FrameCountY = 4;
        }

        public override void updateSprite(float elapsed)
        {
            // Check if a frame has elapsed
            this.totalElapsedTime += elapsed;
            if (this.totalElapsedTime > this.timePerFrame)
            {
                this.framesElapsed++;

                // running logic
                if (this.framesElapsed % 2 == 0)
                {
                    if (this.direction == Direction.RIGHT)
                    {
                        if (this.frameX == 0)
                        {
                            this.frameX = 2;
                        }
                        else
                        {
                            this.frameX = 0;
                        }
                    }
                    else if (this.direction == Direction.LEFT)
                    {
                        if (this.frameX == (this.FrameCountX - 1))
                        {
                            this.frameX = (this.FrameCountX - 1) - 2;
                        }
                        else
                        {
                            this.frameX = (this.FrameCountX - 1);
                        }
                    }
                }
                // star animation logic
                if (this.framesElapsed % 4 == 0)
                {
                    this.framesElapsed = 0;
                    this.frameY++;
                    if (this.frameY >= this.FrameCountY)
                    {
                        this.frameY = 0;
                    }
                }

                this.totalElapsedTime -= this.timePerFrame;
            }

            // update sprite position
            this.spritePosition += this.spriteSpeed * elapsed;
        }
    }
}