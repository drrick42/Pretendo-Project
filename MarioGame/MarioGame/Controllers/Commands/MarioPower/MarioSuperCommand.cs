using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    class MarioSuperCommand : MarioPowerUpCommand
    {
        public MarioSuperCommand(PlayerChar character)
            : base(character)
        { }

        public override void Execute()
        {
            receiver.SuperTransition();
        }
    }
}
