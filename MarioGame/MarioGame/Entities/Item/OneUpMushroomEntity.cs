using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    class OneUpMushroomEntity : ItemEntity
    {

        public OneUpMushroomEntity(ItemFactory factory, Vector2 position)
            : base(factory)
        {
            item = (OneUpMushroom)spriteFactory.getSprite((int)itemTypes.ONEUPSHROOM);
            item.Position = position;
            item.Velocity = Vector2.Zero;
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
                Velocity = new Vector2(((-1) * Constants.ITEM_SPEED), 0.0f);
            else item.Velocity = new Vector2(Constants.ITEM_SPEED, 0.0f);
        }

        }
}
