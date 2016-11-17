using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class ActiveGKoopaState : ActiveEnemyState
    {
        public ActiveGKoopaState(GKoopaStateMachine sm, EnemyEntity enemy)
            : base(sm, enemy)
        {
            Animation = new GreenKoopaWalking();
        }
        public override void ActiveTransition()
        {
            // already active
        }
        public override void HitTransition()
        {
            if (Direction == Direction.LEFT) Direction = Direction.RIGHT;
            else Direction = Direction.LEFT;
            base.HitTransition();
        }
        public override void TurnTransition()
        {
            base.TurnTransition();
        }
        public override void Update(float elapsed)
        {
            base.Update(elapsed);
            if (Direction == Direction.LEFT) Enemy.Velocity = new Vector2(-20f, Velocity.Y);
            else Enemy.Velocity = new Vector2(20f, Velocity.Y);
        }

    }
}