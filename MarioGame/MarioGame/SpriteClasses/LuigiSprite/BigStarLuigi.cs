using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class BigStarLuigi : Mario1
    {
        public BigStarLuigi(ContentManager content) : base()
        {
            this.SpriteTexture = content.Load<Texture2D>("big star luigi");
            this.FrameCountX = 10;
            this.FrameCountY = 4;
        } 
        
    }
}
