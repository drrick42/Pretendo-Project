using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    public class InvulnerableState : AbstractPowerUpState
    {
        private float timer;
        public InvulnerableState(MarioPowerUpStateMachine sm, PlayerChar player) : base(sm,player)
        {
            TypeEnum = MarioTypes.STARMINI;
        }

        public override void SuperTransition()
        {
            // Fire has priority over super
        }

        public override void FireTransition()
        {
            // No effect, already in fire mode
        }

        public override void StarTransition()
        {
            // Already in star mode
        }

        public override void DamageTransition()
        {
            // Can't take damage
        }

        public override void Update(float elapsed)
        {
            timer = (timer + elapsed);
            if (timer > Constants.INVUL_TIME)
            {
                this.Enter(StateMachine.Standard);
                timer = 0;
            }

            base.Update(elapsed);
        }
    }
}
