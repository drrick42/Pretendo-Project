using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class ShellState : AbstractEnemyState
    {
        public int delay;
        public ShellState(GKoopaStateMachine sm, EnemyEntity enemy)
            : base(sm, enemy)
        {
            delay = 10;
            Velocity = Vector2.Zero;
            Animation = new GreenShell();
        }

        public override void ActiveTransition()
        {

        }
        public override void HitTransition()
        {
            this.Enter(StateMachine.Shell2);
            Vector2 vel = new Vector2(25f, 0f);
            this.Velocity = vel;
        }
        public override void TurnTransition()
        {

        }
        public override void Update(float elapsed)
        {   
            base.Update(elapsed);
        }
    }
}