using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    public class PauseCommand : GameCommand
    {
        public PauseCommand(Scene scene) : base(scene)
        {
        }

        public override void Execute()
        {
            receiver.Pause();
        }
    }
}
