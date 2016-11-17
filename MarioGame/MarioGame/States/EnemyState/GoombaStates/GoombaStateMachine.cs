using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    public class GoombaStateMachine : EnemyStateMachine
    {
        public GoombaStateMachine(EnemyEntity enemy)
            : base(enemy)
        {
            Active = new ActiveGoombaState(this, enemy);
            Inactive = new InactiveGoombaState(this, enemy);
            Dead = new DeadGoombaState(this, enemy);
        }

    }
}
