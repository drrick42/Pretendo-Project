using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class Flag : AbstractObstacle
    {
        public Flag(ContentManager content)
            : base(content)
        {
            this.SpriteTexture = content.Load<Texture2D>("flag");
            this.FrameX = 0;
            this.FrameY = 0;

            FrameWidth = this.SpriteTexture.Width;
            FrameHeight = this.SpriteTexture.Height;
            this.Position = Vector2.Zero;
            Origin = new Vector2(0f, FrameHeight);
        }

        public override void Update(float elapsed)
        {
            this.FrameX = 0;
            this.FrameY = 0;
        }

    }
}