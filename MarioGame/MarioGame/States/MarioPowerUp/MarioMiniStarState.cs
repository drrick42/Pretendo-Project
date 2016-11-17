using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    public class MarioMiniStarState : AbstractPowerUpState
    {
        public MarioMiniStarState(MarioPowerUpStateMachine sm, PlayerChar player) : base(sm,player)
        {
            TypeEnum = MarioTypes.STARMINI;
        }

        public override void SuperTransition()
        {
            this.Enter(StateMachine.Super);
            this.Enter(StateMachine.StarBig);
        }

        public override void FireTransition()
        {
            this.Enter(StateMachine.Fire);
            this.Enter(StateMachine.StarBig);
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
            StarTimer = (StarTimer + elapsed);
            if (StarTimer > Constants.STAR_TIME)
            {
                this.Enter(previousState);
                StarTimer = 0;
            }

            base.Update(elapsed);
        }
    }
}
