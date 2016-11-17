using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    class FlowerEntity : ItemEntity
    {
            
        public FlowerEntity(ItemFactory factory, Vector2 position) : base(factory)
        {
            item = (Flower)spriteFactory.getSprite((int)itemTypes.FIREFLOWER);
            Velocity = Vector2.Zero;
            ItemSM = new ItemStateMachine(this);
            ActiveTransition();

        }
        public override void HandleCollision(Vector2 vector, AABB collisionArea, Entity collider)
        {
            base.HandleCollision(vector, collisionArea, collider);

        }
    }

}
