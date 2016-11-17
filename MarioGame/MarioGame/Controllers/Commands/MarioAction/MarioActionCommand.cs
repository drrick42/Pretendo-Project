using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    abstract class MarioActionCommand : ICommand
    {
        protected PlayerChar receiver;

        protected MarioActionCommand(PlayerChar character)
        {
            receiver = character;
        }

        abstract public void Execute();

    }

}
