using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    class MarioResetCommand : MarioPowerUpCommand
    {
        public MarioResetCommand(PlayerChar character)
            : base(character)
        { }

        public override void Execute()
        {
            receiver.ResetTransition();
        }
    }
}
