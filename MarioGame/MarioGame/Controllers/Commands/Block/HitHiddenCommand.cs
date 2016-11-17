using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    class HitHiddenCommand : BlockCommand
    {
        public HitHiddenCommand(BlockForm block)
            : base(block)
        { }

        public override void Execute()
        {
            if (receiver.CurrentBlockState is HiddenBlockState)
            {
                receiver.CurrentBlockState.HitTransition();
            }
        }
    }
}