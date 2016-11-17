using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class WalkingGreenKoopa : AbstractEnemy
    {

        public WalkingGreenKoopa(ContentManager content)
            : base(content)
        {
        }
        public override void updateSprite(float elapsed)
        {
            // set enemies sprite sheet row to green koopa
            this.frameY = 0;

            // Check if a frame has elapsed
            this.totalElapsedTime += elapsed;
            if (this.totalElapsedTime > this.timePerFrame)
            {
                this.framesElapsed++;
                
                // Walking logic
                if (this.framesElapsed % 8 == 0)
                {
                    if(this.direction == Direction.RIGHT)
                    {
                        if (this.frameX == 1)
                        {
                            this.frameX = 2;
                        }
                        else
                        {
                            this.frameX = 1;
                        }
                    }
                    else if(this.direction == Direction.LEFT)
                    {
                        if (this.frameX == 4)
                        {
                            this.frameX = 3;
                        }
                        else
                        {
                            this.frameX = 4;
                        }
                    }
                    this.framesElapsed = 0;
                }
                this.totalElapsedTime -= this.timePerFrame;
            }

            // update sprite position
            this.spritePosition += this.spriteSpeed * elapsed;
        }
    }
}