using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MarioGame
{
    public class StaticText : ISprite
    {
        private Texture2D texture;
        public Vector2 Position { get; set; }

        public StaticText(ContentManager content, string assetName)
        {
            texture = content.Load<Texture2D>(assetName);
        }

        public void Update(float elapsed) { }

        public void Draw(SpriteBatch batch)
        {

            // Draw the sprite
            Rectangle sourcerect = new Rectangle(0, 0,
                texture.Width, texture.Height);
            batch.Draw(texture, Position, sourcerect, Color.White);
        }
    }
}
