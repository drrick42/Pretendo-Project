using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class DeadEnemyState : AbstractEnemyState
    {
        public DeadEnemyState(EnemyStateMachine sm, EnemyEntity enemy)
            : base(sm, enemy)
        {
        }

        public override void ActiveTransition()
        {
            base.ActiveTransition();
        }
        public override void HitTransition()
        {
            base.HitTransition();
        }
        public override void TurnTransition()
        {
            base.TurnTransition();
        }
        public override void Update(float elapsed)
        {
            base.Update(elapsed);
        }
     }
}