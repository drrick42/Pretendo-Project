using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    class MushroomEntity : ItemEntity
    {

        public MushroomEntity(ItemFactory factory, Vector2 position) : base(factory)
        {
            item = (Mushroom)spriteFactory.getSprite((int)itemTypes.SUPERSHROOM);
            item.Position = position;
            item.Velocity = Vector2.Zero;
            item.Acceleration = Vector2.Zero;
            ItemSM = new ItemStateMachine(this);
            ActiveTransition();
            
            
        }

        
        public override void ActiveTransition()
        {
            Vector2 PlayerPos = Vector2.Zero;
            if(Scene.luigi==null && Scene.mario!=null) PlayerPos = Scene.mario.Position;
            else if (Scene.luigi!=null && Scene.mario!=null)
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
                Velocity = new Vector2(Constants.ITEM_SPEED, 0.0f);
            else Velocity = new Vector2(((-1)*Constants.ITEM_SPEED), 0.0f);
        }


        public override void HandleCollision(Vector2 vector, AABB collisionArea, Entity collider)
        {
            base.HandleCollision(vector, collisionArea, collider);
            
        }

    }

}
