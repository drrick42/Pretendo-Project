using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class MarioStandardState : AbstractPowerUpState
    {
        public MarioStandardState(MarioPowerUpStateMachine sm, PlayerChar player) : base(sm,player)
        {
            TypeEnum = MarioTypes.NORMAL;
        }

        public override void StarTransition()
        {
            this.Enter(StateMachine.StarMini);
        }

        public override void DamageTransition()
        {
            this.Enter(StateMachine.Dead);
        }

        public override void ResetTransition()
        {
            // Do nothing, already in standard mode
        }
    }
}
