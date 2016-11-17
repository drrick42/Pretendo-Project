namespace MarioGame
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Sprite
    {
        public Entity Entity { get; set; }

        public Texture2D Texture { get; set; }

        public Vector2 Position { get; set; }
        public Rectangle rect { get; set; }
        public float Dim { get; set; }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (Entity == null)
            {
                if (Texture != null)
                    spriteBatch.Draw(Texture, Position, rect, Color.White * (1-Dim));
            }
            else
            {
                Entity.Draw(spriteBatch);
            }
        }
    }
}
