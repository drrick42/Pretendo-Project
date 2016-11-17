using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    class UpCommand : MarioActionCommand
    {
        public UpCommand(PlayerChar character)
            : base(character)
        { }

        public override void Execute()
        {
            receiver.UpTransition();
        }
    }
}
