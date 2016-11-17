using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class FlagEntity : Entity, IPointPublisher, ILifePublisher
    {
        public ItemEntity item { get; set; }
        public bool isHit;
        public bool Hit = false;
        protected Scene scene { get; set; }

        public AbstractObstacle Flag { get; set; }
        public override Vector2 Position
        {
            get { return Flag.Position; }
            set
            {
                Flag.Position = value;
                Sprite.Position = value;
            }
        }
        public override Vector2 Velocity
        {
            get { return Flag.Velocity; }
            set { Flag.Velocity = value; }
        }
        public override Vector2 Acceleration { get; set; }

        public ObstacleFactory Factory { get; set; }

        public FlagEntity(Scene scene, ObstacleFactory factory, Vector2 position)
            : base()
        {
            this.scene = scene;
            Factory = factory;
            isHit = false;
            HUD.PointTracker.Subscribe(this);
            HUD.MarioLifeTracker.Subscribe(this);
        }
        public ObstacleFactory SpriteFactory { get; set; }
        
        public override int Width
        {
            get { return Flag.Width; }
            set { }
        }

        public override int Height
        {
            get { return Flag.Height; }
            set { }
        }

        public virtual void SetHit()
        {
            isHit = true;
        }

        public override void HandleCollision(Vector2 vector, AABB collision, Entity collider)
        {
            if (collider is PlayerChar)
            {
                SetHit();
                if (this is LevelFlagEntity && Hit == false)
                { 
                    if (collision.BottomLeft.Y >= Flag.Position.Y - 17) { Points(100); }
                    else if (collision.BottomLeft.Y >= Flag.Position.Y - 57) { Points(400); }
                    else if (collision.BottomLeft.Y >= Flag.Position.Y - 81) { Points(800); }
                    else if (collision.BottomLeft.Y >= Flag.Position.Y - 127) { Points(2000); }
                    else if (collision.BottomLeft.Y >= Flag.Position.Y - 153) { Points(4000); }
                    else if (collision.BottomLeft.Y < Flag.Position.Y - 153) { OneUp(); }
                }
                Hit = true;
            }
        }

        public event PointCollector PointCollector;
        public event LifeCounter Lifecounter;

        public void OnPointEvent(PointEvent args)
        {
            PointCollector(args);
        }

        public void OnLifeEvent(LifeEvent args)
        {
            Lifecounter(args);
        }

        public void Points(int points)
        {
            PointEvent e = new PointEvent(points);
            OnPointEvent(e);
            e = new PointEvent(HUD.TimeLimit.Timer);
            OnPointEvent(e);
        }
        public void DecLife() { }
        public void OneUp()
        {
            LifeEvent e = new IncEvent();
            OnLifeEvent(e);
        }

        public override void Update(float elapsed)
        {
            Flag.Update(elapsed);
            Sprite.Position = Flag.Position; 
            if (Collidable)
            {
                BoundingBox = new AABB(new Vector2(Position.X + (float)((Flag.Width*2)/3), Position.Y), Flag.Width/3, Height);
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

        public override void Draw(SpriteBatch batch)
        {
            Flag.Draw(batch);
            base.Draw(batch);
        }
    }
}