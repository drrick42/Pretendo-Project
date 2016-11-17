using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    public class StartSingleCommand : GameCommand
    {
        public StartSingleCommand(Scene scene) : base(scene)
        { }


        public override void Execute()
        {
            receiver.StartSingle();
        }
    }
}
