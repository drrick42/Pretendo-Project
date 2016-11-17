using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class DyingMario : Mario
    {

        public DyingMario(ContentManager content) : base()
        {
            this.spriteTexture = content.Load<Texture2D>("mini mario");

            this.FrameCountX = 12;
            this.FrameCountY = 1;
        }

        public override void updateSprite(float elapsed)
        {
            if (this.direction == Direction.RIGHT)
            {
                this.frameX = 5;
            }
            else if (this.direction == Direction.LEFT)
            {
                this.frameX = 6;
            }
            // update sprite position
            this.spritePosition += this.spriteSpeed * elapsed;
        }

    }
}