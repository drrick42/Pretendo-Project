using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class MiniLuigi : Luigi
    {
        public MiniLuigi(ContentManager content) : base()
        {
            this.SpriteTexture = content.Load<Texture2D>("mini luigi");
            this.FrameCountX = 12;
            this.FrameCountY = 1;
        } 
    }
}
