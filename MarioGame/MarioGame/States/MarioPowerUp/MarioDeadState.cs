using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    public class MarioDeadState : AbstractPowerUpState
    {
        public MarioDeadState(MarioPowerUpStateMachine sm, PlayerChar player) : base(sm,player)
        {
            TypeEnum = MarioTypes.DEAD;
        }

        public override void SuperTransition()
        {
        }

        public override void FireTransition()
        {
        }

        public override void StarTransition()
        {
        }

        public override void DamageTransition()
        {
        }

        public override void DeathPowerTransition()
        {
        }

        public override void ResetTransition()
        {
            this.Enter(StateMachine.Standard);
        }

        public override void Update(float elapsed)
        {
            base.Update(elapsed);
        }
    }
}
