using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MarioGame
{

    public class MarioCrouchingState : AbstractActionState
    {
        float timer;
        public MarioCrouchingState(MarioActionStateMachine sm, PlayerChar player)
            : base(sm, player)
        {
            Animation = new MarioCrouchingAnimation();
            timer = 0;
        }

        public override void UpTransition()
        {
            this.Enter(StateMachine.Idle);
        }

        public override void DownTransition()
        {
            // Already crouching
        }

        public override void Update(float elapsed)
        {
            timer = (timer + elapsed);
            if (timer > Constants.CROUCH_TIME)
            {
                this.Enter(StateMachine.Idle);
                timer = 0;
            }
            else if (Velocity.Y > 0)
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
