using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public abstract class CrouchingMario : Mario
    {

        protected CrouchingMario() : base()
        {
        }
        public override void updateSprite(float elapsed)
        {
            if (this.direction == Direction.RIGHT)
            {
                this.frameX = 1;
            }
            else if (this.direction == Direction.LEFT)
            {
                this.frameX = (this.FrameCountX-1)-1;
            }
            this.spritePosition += this.spriteSpeed * elapsed;
        }

    }
}