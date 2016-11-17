using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    class HitUsedCommand : BlockCommand
    {
        public HitUsedCommand(BlockForm block)
            : base(block)
        { }

        public override void Execute()
        {
            if (receiver.CurrentBlockState is UsedBlockState)
            {
                receiver.CurrentBlockState.HitTransition();
            }
        }
    }
}