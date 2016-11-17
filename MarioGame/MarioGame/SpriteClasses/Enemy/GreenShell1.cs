using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class GreenShell1 : Enemy1
    {
        public GreenShell1(ContentManager content)
            : base(content)
        {

            FrameCountX = 5;
            FrameCountY = 2;

            SpriteTexture = content.Load<Texture2D>("shell");

            FrameWidth = this.SpriteTexture.Width / this.FrameCountX;
            FrameHeight = this.SpriteTexture.Height / this.FrameCountY;
            this.Position = Vector2.Zero;
            Origin = new Vector2(0f, FrameHeight);

            Animation = new GreenShell();
        }
        public override void Draw(SpriteBatch batch)
        {
            // Draw the sprite
            Rectangle sourcerect = new Rectangle(FrameWidth, FrameHeight * this.FrameY,
                FrameWidth, FrameHeight);
            batch.Draw(this.SpriteTexture, this.Position, sourcerect, Color.White, 0, Origin, 1, SpriteEffects.None, 0);
        }
    }
}