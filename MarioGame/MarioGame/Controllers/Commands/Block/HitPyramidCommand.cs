using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    class HitPyramidCommand : BlockCommand
    {
        public HitPyramidCommand(BlockForm block)
            : base(block)
        { }

        public override void Execute()
        {
            if (receiver.CurrentBlockState is PyramidBlockState)
            {
                receiver.CurrentBlockState.HitTransition();
            }
        }
    }
}