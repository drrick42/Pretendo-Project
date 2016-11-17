using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class DeadGoombaState : DeadEnemyState
    {
        public DeadGoombaState(GoombaStateMachine sm, EnemyEntity enemy)
            : base(sm, enemy)
        {
            Animation = new GoombaDead();
        }

        public override void ActiveTransition()
        {

        }
        public override void HitTransition()
        {

        }
        public override void TurnTransition()
        {

        }
        public override void Update(float elapsed)
        {
            base.Update(elapsed);
            Velocity = new Vector2(0f, 60f);
        }
    }
}