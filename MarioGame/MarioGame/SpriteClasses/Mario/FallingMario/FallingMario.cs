using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public abstract class FallingMario : Mario
    {
        protected FallingMario() : base()
        {

        }
        public override void updateSprite(float elapsed)
        {
            if (this.direction == Direction.RIGHT)
            {
                this.frameX = 3;
            }
            else if (this.direction == Direction.LEFT)
            {
                this.frameX = (this.FrameCountX - 1) - 3;
            }
            // update sprite position
            this.spritePosition += this.spriteSpeed * elapsed;

        }

    }
}