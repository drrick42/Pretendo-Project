using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class FireBall : Mario1
    {
        public FireBall(ContentManager content)
            : base()
        {
            Console.WriteLine("loadtexture");
            this.SpriteTexture = content.Load<Texture2D>("fireball");
            this.FrameX = 0;
            this.FrameCountX = 1;
            this.FrameCountY = 1;
        }

        public override void Update(float elapsed)
        {
            
            base.Update(elapsed);

        }

    }
}
