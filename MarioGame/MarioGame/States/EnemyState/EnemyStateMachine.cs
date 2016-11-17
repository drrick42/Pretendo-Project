using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    public class EnemyStateMachine
    {
        public ActiveEnemyState Active { get; set; }
        public InactiveEnemyState Inactive { get; set; }
        public DeadEnemyState Dead { get; set; }
        public ShellState Shell { get; set; }
        public SpinningShellState Shell2 { get; set; }


        public EnemyStateMachine(EnemyEntity enemy)
        {

        }

    }
}
