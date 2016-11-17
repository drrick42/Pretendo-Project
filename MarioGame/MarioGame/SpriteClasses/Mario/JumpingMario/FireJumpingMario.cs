using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class FireJumpingMario : JumpingMario
    {

        public FireJumpingMario(ContentManager content)
            : base()
        {
            this.spriteTexture = content.Load<Texture2D>("fire mario");
            this.FrameCountX = 10;
            this.FrameCountY = 1;
        }
       
    }
}