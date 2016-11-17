using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    public class StartMultiCommand : GameCommand
    {
        public StartMultiCommand(Scene scene) : base(scene)
        { }


        public override void Execute()
        {
            receiver.StartMulti();
        }
    }
}
