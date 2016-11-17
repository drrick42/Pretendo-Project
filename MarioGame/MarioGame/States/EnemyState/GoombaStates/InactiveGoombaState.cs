using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class InactiveGoombaState : InactiveEnemyState
    {
        public InactiveGoombaState(GoombaStateMachine sm, EnemyEntity enemy)
            : base(sm, enemy)
        {
            Animation = new GoombaDead();
        }

        public override void ActiveTransition()
        {
            base.ActiveTransition();
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
            if (Scene.camera.InCamera(Enemy.Position))
            {
                this.ActiveTransition();
            }
        }


    }
}