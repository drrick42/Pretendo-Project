using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    public class QuitCommand : GameCommand
    {
        public QuitCommand(Scene scene) : base(scene)
        { }

        public override void Execute()
        {
            receiver.Exit();
        }
    }
}
