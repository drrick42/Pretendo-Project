using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    public class MarioSuperState : AbstractPowerUpState
    {
        public MarioSuperState(MarioPowerUpStateMachine sm, PlayerChar player) : base(sm,player)
        {
            TypeEnum = MarioTypes.SUPER;
        }

        public override void SuperTransition()
        {
            // Already in super mode
        }

        public override void DamageTransition()
        {
            this.Enter(StateMachine.Invul);
        }
    }
}
