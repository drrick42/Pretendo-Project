using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class MiniStarMario1 : Mario1
    {
         public MiniStarMario1(ContentManager content) : base()
        {
            this.SpriteTexture = content.Load<Texture2D>("mini star mario");
            this.FrameCountX = 10;
            this.FrameCountY = 4;
        }   
    }
}
