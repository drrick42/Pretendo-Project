using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    class HitBrickCommand : BlockCommand
    {
        public HitBrickCommand(BlockForm block)
            : base(block)
        { }

        public override void Execute()
        {
            if (receiver.CurrentBlockState is BrickBlockState)
            {
                receiver.CurrentBlockState.HitTransition();
            }
        }
    }
}