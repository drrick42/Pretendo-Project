using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    public abstract class MenuCommand : ICommand
    {
        protected Menu receiver;

        protected MenuCommand(Menu menu)
        {
            receiver = menu;
        }

        abstract public void Execute();
    }
}
