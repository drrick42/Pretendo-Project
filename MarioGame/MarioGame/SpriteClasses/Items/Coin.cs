using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class Coin : AbstractItem
    {
        public Coin(ContentManager content)
            : base(content)
        {
        }

        public override void Update(float elapsed)
        {
            this.FrameX = 0;
            base.Update(elapsed);

        }

    }
}
