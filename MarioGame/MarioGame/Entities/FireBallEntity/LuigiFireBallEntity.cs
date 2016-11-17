using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class LuigiFireBallEntity : AbstractFireBallEntity
    {
        public LuigiFireBallEntity(LuigiFactory factory, Vector2 position)
        {
            FireBall = (Mario1)factory.getSprite((int)MarioTypes.FIREBALL);
            Vector2 vel = new Vector2(20f, 0f);
            FireBall.Velocity = vel;
            FireBall.Position = position;
        }

        public override void Update(float elapsed)
        { 
            Vector2 acc = new Vector2(0f, 5f);
            FireBall.Update(elapsed);
            FireBall.Velocity += acc;
            base.Update(elapsed);
        }

        public override void Draw(SpriteBatch batch)
        {
            FireBall.Draw(batch);
            base.Draw(batch);
        }

        public override void HandleCollision(Vector2 vector, AABB collision, Entity collider)
        {
            if (!(collider is PlayerChar)) { this.Removed = true; }
            base.HandleCollision(vector, collision, collider);
        }
    }
}
