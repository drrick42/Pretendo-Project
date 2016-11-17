using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class BigLuigi : Luigi
    {
        public BigLuigi(ContentManager content) : base()
        {
            this.SpriteTexture = content.Load<Texture2D>("big luigi");
            this.FrameCountX = 10;
            this.FrameCountY = 1;
        } 

    }
}
