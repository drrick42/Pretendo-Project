using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    class FloorBlockState : AbstractBlockState
    {
        public FloorBlockState(BlockStateMachine sm, BlockForm block)
            : base(sm, block)
        { }

        public override void ResetTransition()
        {
            block.ChangeBlockState(stateMachine.FloorBlock);
            block.ChangeSprite();
        }
    }
}