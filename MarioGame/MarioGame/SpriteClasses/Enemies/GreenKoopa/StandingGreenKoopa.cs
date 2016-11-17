using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class StandingGreenKoopa : AbstractEnemy
    {
        public StandingGreenKoopa(ContentManager content)
            : base(content)
        {
        }
        public override void updateSprite(float elapsed)
        {
            // set enemies sprite sheet row to green koopa
            this.frameY = 0;
            // standing frame
            if (this.direction == Direction.RIGHT)
            {
                this.frameX = 2;
            }
            else if (this.direction == Direction.LEFT)
            {
                this.frameX = 3;
            }

            // update sprite position
            this.spritePosition += this.spriteSpeed * elapsed;
        }
    }
}