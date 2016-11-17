using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class ActiveGoombaState : ActiveEnemyState
    {
        public ActiveGoombaState(GoombaStateMachine sm, EnemyEntity enemy)
            : base(sm, enemy)
        {
            Animation = new GoombaWalking();
        }
        public override void ActiveTransition()
        {
            // already active
        }
        public override void HitTransition()
        {
            base.HitTransition();
        }
        public override void TurnTransition()
        {
            if (Direction == Direction.LEFT) Direction = Direction.RIGHT;
            else Direction = Direction.LEFT;
        }
        public override void Update(float elapsed)
        {
            base.Update(elapsed);
            if (Direction == Direction.LEFT) Enemy.Velocity = new Vector2(-20f, Velocity.Y);
            else Enemy.Velocity = new Vector2(20f, Velocity.Y);
        }

    }
}