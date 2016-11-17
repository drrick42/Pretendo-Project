using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class Flower : AbstractItem
    {
        public Flower(ContentManager content)
            : base(content)
        {
            
        }

        public override void Update(float elapsed)
        {
            this.FrameX = 2;
            base.Update(elapsed);

        }

    }
}
