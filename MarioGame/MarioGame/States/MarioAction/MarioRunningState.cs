using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class MarioRunningState : AbstractActionState
    {
        public MarioRunningState(MarioActionStateMachine sm, PlayerChar player)
            : base(sm, player)
        {
            Animation = new MarioRunningAnimation();
        }

        public override void RightTransition()
        {
            if (PlayerChar.Direction == Direction.LEFT)
            {
                PlayerChar.Direction = Direction.RIGHT;
                this.Enter(StateMachine.Idle);
            }
            else
            {
                Velocity = new Vector2(Velocity.X + Constants.MARIO_RUN_SPEED, Velocity.Y);
            }
            
        }

        public override void LeftTransition()
        {
            if (PlayerChar.Direction == Direction.RIGHT)
            {
                PlayerChar.Direction = Direction.LEFT;
                this.Enter(StateMachine.Idle);
            }
            else
            {
                Velocity = new Vector2(Velocity.X - Constants.MARIO_RUN_SPEED, Velocity.Y);
            }
        }

        public override void Update(float elapsed)
        {
            if (Velocity.Y > 0)
            {
                this.Enter(StateMachine.Fall);
            }
            else if (Velocity.X == 0)
            {
                this.Enter(StateMachine.Idle);
            }
            else
            {
                base.Update(elapsed);
                float x;

                // Clamp velocity
                if (Direction == Direction.LEFT)
                {
                    x = MathHelper.Clamp(Velocity.X, Constants.MARIO_MAX_RUN_SPEED * -1, 0f);
                }
                else
                {
                    x = MathHelper.Clamp(Velocity.X, 0f, Constants.MARIO_MAX_RUN_SPEED);
                }
                Velocity = new Vector2(x, Velocity.Y);
            }
        }
    }
}
