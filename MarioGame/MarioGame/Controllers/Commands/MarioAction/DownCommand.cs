using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    class DownCommand : MarioActionCommand
    {
        public DownCommand(PlayerChar character) : base(character)
        { }

        public override void Execute()
        {
            receiver.DownTransition();
        }
    }
}
