using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class GreenKoopa1 : Enemy1
    {
        public GreenKoopa1(ContentManager content): base(content)
        {

            FrameCountX = 14;
            FrameCountY = 1;

            SpriteTexture = content.Load<Texture2D>("koopa");

            FrameWidth = this.SpriteTexture.Width / this.FrameCountX;
            FrameHeight = this.SpriteTexture.Height / this.FrameCountY;
            this.Position = Vector2.Zero;
            Origin = new Vector2(0f, FrameHeight);

            Animation = new GreenKoopaWalking();
        }
    }
}
