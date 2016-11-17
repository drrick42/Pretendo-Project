using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    public abstract class GameCommand : ICommand
    {
        protected Scene receiver;

        protected GameCommand(Scene scene)
        {
            receiver = scene;
        }

        abstract public void Execute();
    }
}
