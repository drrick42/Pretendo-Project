using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class BigStarStandingMario : StandingMario
    {
        public BigStarStandingMario(ContentManager content)
            : base()
        {
            this.spriteTexture = content.Load<Texture2D>("big star mario");
            this.FrameCountX = 10;
            this.FrameCountY = 4;
        }

        public override void updateSprite(float elapsed)
        {
            this.frameX = 0;

            // Check if a frame has elapsed
            this.totalElapsedTime += elapsed;
            if (this.totalElapsedTime > this.timePerFrame)
            {
                this.framesElapsed++;
                if(this.framesElapsed % 4 == 0)
                {
                    this.framesElapsed = 0;
                    this.frameY++;
                    if(this.frameY >= this.FrameCountY)
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