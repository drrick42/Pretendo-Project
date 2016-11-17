using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class MiniFallingMario : FallingMario
    {
        public MiniFallingMario(ContentManager content)
            : base()
        {
            this.spriteTexture = content.Load<Texture2D>("mini mario");
            this.FrameCountX = 12;
            this.FrameCountY = 1;
        }

    }
}