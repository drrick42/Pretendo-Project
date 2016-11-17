using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    abstract class MarioPowerUpCommand : ICommand
    {
        protected PlayerChar receiver;

        protected MarioPowerUpCommand(PlayerChar character)
        {
            receiver = character;
        }

        abstract public void Execute();
    }

}
