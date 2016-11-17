using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    public class GKoopaStateMachine : EnemyStateMachine
    {

        public GKoopaStateMachine(EnemyEntity enemy)
            : base(enemy)
        {
            Active = new ActiveGKoopaState(this, enemy);
            Inactive = new InactiveGKoopaState(this, enemy);
            Shell = new ShellState(this, enemy);
            Shell2 = new SpinningShellState(this, enemy);
        }

    }
}