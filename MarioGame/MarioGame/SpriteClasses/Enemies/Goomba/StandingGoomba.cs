using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class StandingGoomba : AbstractEnemy
    {
        public StandingGoomba(ContentManager content)
            : base(content)
        {
        }
        public override void updateSprite(float elapsed)
        {
            // set enemies sprite sheet row to goomba
            this.frameY = 2;
            // standing frame
            if (this.direction == Direction.RIGHT)
            {
                this.frameX = 2;
            }
            else if(this.direction == Direction.LEFT)
            {
                this.frameX = 3;
            }
            // update sprite position
            this.spritePosition += this.spriteSpeed * elapsed;
        }
    }
}