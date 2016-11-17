using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public abstract class StandingMario  : Mario
    {
        
        protected StandingMario() : base()
        {
        }

        public override void updateSprite(float elapsed)
        {
            this.frameX = 0;

            // update sprite position
            this.spritePosition += this.spriteSpeed * elapsed;

        }

    }
}