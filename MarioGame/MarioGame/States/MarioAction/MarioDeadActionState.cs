using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class MarioDeadActionState : AbstractActionState
    {
        private float timer;
        protected override Vector2 stateAccel
        {
            get { return new Vector2(0f, Constants.GRAVITY); }
        }
        public MarioDeadActionState(MarioActionStateMachine sm, PlayerChar player) : base(sm,player)
        {
            Animation = new MarioDeadAnimation();
            timer = 0;
        }

        public override void LeftTransition()
        {
        }

        public override void RightTransition()
        {
        }

        public override void UpTransition()
        {
        }

        public override void DownTransition()
        {
        }

        public override void DeathActionTransition()
        {
        }

        public override void Update(float elapsed)
        {
            Velocity += Acceleration * elapsed;

            timer += elapsed;
            if (timer > Constants.MARIO_DEAD_TIME)
            {
                PlayerChar.OnLifeEvent(new DecEvent());
            }
        }
    }
}
