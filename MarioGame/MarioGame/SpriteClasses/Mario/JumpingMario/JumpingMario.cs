using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public abstract class JumpingMario : Mario
    {
        
        protected JumpingMario() : base()
        {
        }

        public override void updateSprite(float elapsed)
        {
            this.frameX = 4;
            if (this.direction == Direction.RIGHT)
            {
                this.frameX = 4;
            }
            else if (this.direction == Direction.LEFT)
            {
                this.frameX = (this.FrameCountX-1)-4;
            }

            // update sprite position
            this.spritePosition += this.spriteSpeed * elapsed;

        }

    }
}