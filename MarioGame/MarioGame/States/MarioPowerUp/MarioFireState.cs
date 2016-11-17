using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    public class MarioFireState : AbstractPowerUpState
    {
        public MarioFireState(MarioPowerUpStateMachine sm, PlayerChar player) : base(sm,player)
        {
            TypeEnum = MarioTypes.FIRE;
        }

        public override void SuperTransition()
        {
            // Fire has priority over super
        }

        public override void FireTransition()
        {
            // No effect, already in fire mode
        }

        public override void DamageTransition()
        {
            this.Enter(StateMachine.Invul);
        }
    }
}
