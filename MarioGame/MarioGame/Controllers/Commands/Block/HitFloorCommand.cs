using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    class HitFloorCommand : BlockCommand
    {
        public HitFloorCommand(BlockForm block)
            : base(block)
        { }

        public override void Execute()
        {
            if (receiver.CurrentBlockState is FloorBlockState)
            {
                receiver.CurrentBlockState.HitTransition();
            }
        }
    }
}