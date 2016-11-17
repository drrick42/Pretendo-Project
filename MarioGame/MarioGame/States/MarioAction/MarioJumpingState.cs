using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class MarioJumpingState : AbstractActionState
    {
        protected override Vector2 stateAccel
        {
            get { return new Vector2(0f, Constants.GRAVITY); }
        }

        public MarioJumpingState(MarioActionStateMachine sm, PlayerChar player)
            : base(sm, player)
        {
            Animation = new MarioJumpingAnimation();
        }

        public override void UpTransition()
        {
        }

        public override void DownTransition()
        {
            // Can't crouch
        }

        public override void RightTransition()
        {
            if (Direction == Direction.LEFT)
            {
                Direction = Direction.RIGHT;
            }
            Velocity = new Vector2(Velocity.X + Constants.MARIO_FALL_SPEED, Velocity.Y);
        }

        public override void LeftTransition()
        {
            if (Direction == Direction.RIGHT)
            {
                Direction = Direction.LEFT;
            }
            Velocity = new Vector2(Velocity.X - Constants.MARIO_FALL_SPEED, Velocity.Y);
        }

        public override void Update(float elapsed)
        {
            if (Velocity.Y > 0)
            {
                this.Enter(StateMachine.Fall);
            }
            else
            {
                base.Update(elapsed);

                float x;
                float y = Velocity.Y;

                // Clamp velocity
                if (Direction == Direction.LEFT)
                {
                    x = MathHelper.Clamp(Velocity.X, Constants.MARIO_MAX_FALL_SPEED * -1, 0f);
                }
                else
                {
                    x = MathHelper.Clamp(Velocity.X, 0f, Constants.MARIO_MAX_FALL_SPEED);
                }

                Velocity = new Vector2(x, y);
            }
            

        }
    }
}
