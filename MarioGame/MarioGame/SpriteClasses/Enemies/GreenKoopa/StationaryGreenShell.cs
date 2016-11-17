using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class StationaryGreenShell : AbstractEnemy
    {

        public StationaryGreenShell(ContentManager content)
            : base(content)
        {
        }
        public override void updateSprite(float elapsed)
        {
            // set enemies sprite sheet row to green koopa
            this.frameY = 0;
            // stationary shell frame
            this.frameX = 6;

            // update sprite position
            this.spritePosition += this.spriteSpeed * elapsed;
        }
    }
}