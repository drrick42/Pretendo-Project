using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class BigFallingMario : FallingMario
    {

        public BigFallingMario(ContentManager content)
            : base()
        {
            this.spriteTexture = content.Load<Texture2D>("big mario");
            this.FrameCountX = 10;
            this.FrameCountY = 1;
        }
        
    }
}