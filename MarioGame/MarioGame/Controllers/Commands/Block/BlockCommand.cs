using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    abstract class BlockCommand : ICommand
    {
        protected BlockForm receiver;

        protected BlockCommand(BlockForm block)
        {
            receiver = block;
        }

        abstract public void Execute();

    }

}
