using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    class LeftCommand : MarioActionCommand
    {
        public LeftCommand(PlayerChar character)
            : base(character)
        { }

        public override void Execute()
        {
            receiver.LeftTransition();
        }
    }
}
