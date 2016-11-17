using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    public class MarioBigStarState : AbstractPowerUpState
    {

        public MarioBigStarState(MarioPowerUpStateMachine sm, PlayerChar player) : base(sm,player)
        {
            TypeEnum = MarioTypes.STARBIG;
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
