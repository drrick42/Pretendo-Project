using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    class StarEntity : ItemEntity
    {
        public StarEntity(ItemFactory factory, Vector2 position) : base(factory)
        {
            item = (Star)spriteFactory.getSprite((int)itemTypes.ITEMSTAR);
            item.Position = position;
            Velocity = Vector2.Zero;
            item.Velocity = Velocity;
            ItemSM = new ItemStateMachine(this);
            ActiveTransition();

        }

        public override void ActiveTransition()
        {
            Vector2 PlayerPos = Vector2.Zero;
            if (Scene.luigi == null && Scene.mario != null) PlayerPos = Scene.mario.Position;
            else if (Scene.luigi != null && Scene.mario != null)
            {
                if (Math.Abs(Position.X - Scene.mario.Position.X) <= Math.Abs(Position.X - Scene.luigi.Position.X))
                {
                    PlayerPos = Scene.mario.Position;
                }
                else
                {
                    PlayerPos = Scene.luigi.Position;
                }

            }
            base.ActiveTransition();
            if (PlayerPos.X > Position.X)
                Velocity = new Vector2((Constants.ITEM_SPEED), Constants.STAR_SPEED);
            else item.Velocity = new Vector2(((-1) * Constants.ITEM_SPEED), Constants.STAR_SPEED);
        }
        public override void HandleCollision(Vector2 vector, AABB collisionArea, Entity collider)
        {
            Side result = AABB.SideHit(BoundingBox, collisionArea);
            if (collider is PlayerChar)
            {
                Removed = true;
            }
                  
            base.HandleCollision(vector, collisionArea, collider);
            if(result == Side.BOTTOM)
            {
                Velocity = new Vector2(Velocity.X, Constants.STAR_SPEED);
            }

        }
    
    }

}
