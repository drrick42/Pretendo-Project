using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    class ResetCommand : BlockCommand
    {
        public ResetCommand(BlockForm block)
            : base(block)
        { }

        public override void Execute()
        {
            receiver.CurrentBlockState.ResetTransition();
        }
    }
}