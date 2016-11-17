using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class MarioFallingState : AbstractActionState
    {
        protected override Vector2 stateAccel
        {
            get { return new Vector2(0f, Constants.GRAVITY); }
        }
        public MarioFallingState(MarioActionStateMachine sm, PlayerChar player)
            : base(sm, player)
        {
            Animation = new MarioFallingAnimation();
        }

        public override void UpTransition()
        {
            // Can't fall
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

        public override void DownTransition()
        {
            // Can't crouch
        }

        public override void Update(float elapsed)
        {
            if (Velocity.Y <= 0f)
            {
                if (Velocity.X == 0) this.Enter(StateMachine.Idle);
                else this.Enter(StateMachine.Run);
            }
            else
            {
                Velocity += Acceleration * elapsed;
                float x;

                // Clamp velocity
                if (Direction == Direction.LEFT)
                {
                    x = MathHelper.Clamp(Velocity.X, Constants.MARIO_MAX_FALL_SPEED * -1, 0f);
                }
                else
                {
                    x = MathHelper.Clamp(Velocity.X, 0f, Constants.MARIO_MAX_FALL_SPEED);
                }
                Velocity = new Vector2(x, Velocity.Y);

                BoundPosition();
            }

        }
    }
}
