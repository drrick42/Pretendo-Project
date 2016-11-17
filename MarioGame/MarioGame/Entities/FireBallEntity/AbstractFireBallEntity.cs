using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public abstract class AbstractFireBallEntity : Entity
    {
        public Mario1 FireBall { get; set; }
        public override Vector2 Velocity 
        {
            get { return FireBall.Velocity; }
            set { FireBall.Velocity = value; }
        }
        public override Vector2 Position 
        {
            get { return FireBall.Position; }
            set { FireBall.Position = value; } 
        }

        public override int Width
        {
            get
            {
                return FireBall.Width;
            }
            set
            {
                FireBall.Width = value;
            }
        }

        public override Vector2 Acceleration
        {
            get
            {
                return new Vector2(0f,0f);
            }
            set
            {   
            }
        }

        public override int Height
        {
            get
            {
                return FireBall.Height;
            }
            set
            {
                FireBall.Height = value;
            }
        }

        public override void Update(float elapsed)
        {
            Console.WriteLine("updateAbstr");
            Console.WriteLine(Velocity);
            FireBall.Update(elapsed);
            base.Update(elapsed);
        }
        public override void Draw(SpriteBatch batch) 
        {
            FireBall.Draw(batch);
            base.Draw(batch);
        }

        public override void HandleCollision(Vector2 pos, AABB collision, Entity collider) { }
    }
}
