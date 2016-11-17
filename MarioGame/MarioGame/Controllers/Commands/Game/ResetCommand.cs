using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    public class ResetCommand : GameCommand
    {

        public ResetCommand(Scene scene) : base(scene)
        {
        }

        public override void Execute()
        {
            receiver.HardReset();
        }
    }
}
