using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    class RightCommand : MarioActionCommand
    {
        public RightCommand(PlayerChar character)
            : base(character)
        { }

        public override void Execute()
        {
            receiver.RightTransition();
        }
    }
}
