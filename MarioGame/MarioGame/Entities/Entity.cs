using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public abstract class Entity : ISprite, ISoundPublisher
    {
        // Collision
        public bool Collidable { get; set; }
        public AABB BoundingBox { get; protected set; }
        public List<Index> SpatialGridBoxes;
        public List<Entity> Seen { get; set; }

        public abstract int Width { get; set; }
        public abstract int Height { get; set; }

        // Parallax
        private Sprite sprite; 

        public Sprite Sprite
        {
            get { return sprite; }
            set { sprite = value; }
        }

        public bool Removed { get; set; }

        // Physics
        public virtual Vector2 Position { get; set; }
        public virtual Vector2 Velocity { get; set; }
        public abstract Vector2 Acceleration { get; set; }

        // Sound
        public event SoundEffectHandler SoundHandler;

        protected Entity()
        {
            Collidable = true;
            sprite = new Sprite();
            sprite.Entity = this;
            sprite.Texture = null;
            Scene.AudioHandler.Subscribe(this);
        }

        public void OnSoundEvent(SoundEvent args)
        {
            if (SoundHandler != null) SoundHandler(args);
        }

        public void PlaySFX(String assetName)
        {
            SFXEvent e = new SFXEvent(assetName);
            OnSoundEvent(e);
        }

        public void PlayBGM(String assetName)
        {
            BGMEvent e = new BGMEvent(assetName);
            OnSoundEvent(e);
        }

        public virtual void Update(float elapsed)
        {
            if (Collidable)
            {
                BoundingBox = new AABB(Position, Width, Height);
                SpatialGridBoxes = FindGridBoxes(BoundingBox);
                Seen = new List<Entity>();
                Seen.Add(this);
            }
            else
            {
                BoundingBox = null;
                SpatialGridBoxes = null;
                Seen = null;
            }
        }

        public virtual void Draw(SpriteBatch batch)
        {
           // if( BoundingBox != null ) DrawBorder(batch, BoundingBox.Rectangle, 1, Color.Red);
        }

        /// <summary>
        /// Performs a response to a collision occuring between this and another entity
        /// </summary>
        /// <param name="vector">A vector indicating what direction the collider came from</param>
        /// <param name="collision">Rectangle where the collider's AABB intersecting with this entity's AABB</param>
        /// <param name="collider">The entity that collided into this</param>
        public abstract void HandleCollision(Vector2 vector, AABB collision, Entity collider);

        public bool Collide(Entity entity, out AABB collision)
        {
            collision = this.BoundingBox.Intersect(entity.BoundingBox);
            return this.BoundingBox.Collide(entity.BoundingBox);
        }

        protected static List<Index> FindGridBoxes(AABB boundingBox)
        {
            List<Index> result = new List<Index>();

            // Check top and bottom corners
            Index topLeft = HashPosition(boundingBox.TopLeft);
            Index bottomRight = HashPosition(boundingBox.BottomRight);

            for (int row = topLeft.Row; row <= bottomRight.Row; row++)
            {
                for (int col = topLeft.Col; col <= bottomRight.Col; col++)
                {
                    result.Add(new Index(col, row));
                }
            }

            return result;
        }

        /// <summary>
        /// Given a position, determines which box in the spatial grid that position belongs to put's it in there
        /// </summary>
        /// <param name="position"></param>
        private static Index HashPosition(Vector2 position)
        {
            int col = (int)(position.X / (Constants.SPATIAL_GRID_SIZE));
            int row = (int)(position.Y / (Constants.SPATIAL_GRID_SIZE));

            return new Index(col, row);
        }

        protected static void Bounce(Side side, AABB collision, Entity collider)
        {
            float x = collider.Position.X;
            float y = collider.Position.Y;
            if (side == Side.TOP)
            {
                y -= collision.Height;
            }
            if (side == Side.BOTTOM)
            {
                y += collision.Height;
            }
            if (side == Side.LEFT)
            {
                x -= collision.Width;
            }
            if (side == Side.RIGHT)
            {
                x += collision.Width;
            }
            collider.Position = new Vector2(x, y);
        }

        public static void DrawBorder(SpriteBatch spriteBatch, Rectangle rectangleToDraw, int thicknessOfBorder, Color borderColor)
        {
            Texture2D pixel = Scene.Pixel;
            

            // Draw top line
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, rectangleToDraw.Width, thicknessOfBorder), borderColor);

            // Draw left line
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, thicknessOfBorder, rectangleToDraw.Height), borderColor);

            // Draw right line
            spriteBatch.Draw(pixel, new Rectangle((rectangleToDraw.X + rectangleToDraw.Width - thicknessOfBorder),
                                                    rectangleToDraw.Y,
                                                    thicknessOfBorder,
                                                    rectangleToDraw.Height), borderColor);
            // Draw bottom line
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X,
                                                    rectangleToDraw.Y + rectangleToDraw.Height - thicknessOfBorder,
                                                    rectangleToDraw.Width,
                                                    thicknessOfBorder), borderColor);
        }
    }
}