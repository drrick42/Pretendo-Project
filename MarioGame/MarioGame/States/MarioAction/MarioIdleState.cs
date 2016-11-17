using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class MarioIdleState : AbstractActionState
    {
        public MarioIdleState(MarioActionStateMachine sm, PlayerChar player) : base(sm,player)
        {
            Animation = new MarioStandingAnimation();
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
                this.Enter(StateMachine.Run);
                Velocity = new Vector2(Constants.MARIO_RUN_SPEED * -1, Velocity.Y);
            }
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
                this.Enter(StateMachine.Run);
                Velocity = new Vector2(Constants.MARIO_RUN_SPEED, Velocity.Y);
            }
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
