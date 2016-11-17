using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class SpinningShellState : AbstractEnemyState
    {
        public SpinningShellState(GKoopaStateMachine sm, EnemyEntity enemy)
            : base(sm, enemy)
        {
            Animation = new SpinningGreenShell();
        }

        public override void ActiveTransition()
        {

        }
        public override void HitTransition()
        {
            this.Velocity = Vector2.Zero;
            this.Enter(StateMachine.Shell);
        }
        public override void TurnTransition()
        {
        }
        public override void Update(float elapsed)
        {
            this.Position += this.Velocity * elapsed;
            Vector2 acc = new Vector2(0f, 3f);
            this.Velocity += acc* elapsed;
            base.Update(elapsed);
        }
    }
}