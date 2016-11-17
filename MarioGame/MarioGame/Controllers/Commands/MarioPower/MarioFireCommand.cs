using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    class MarioFireCommand :MarioPowerUpCommand
    {
        public MarioFireCommand(PlayerChar character)
            : base(character)
        { }

        public override void Execute()
        {
            receiver.FireTransition();
        }
    }
}
