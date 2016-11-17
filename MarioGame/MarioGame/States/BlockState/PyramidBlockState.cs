using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    class PyramidBlockState : AbstractBlockState
    {
        public PyramidBlockState(BlockStateMachine sm, BlockForm block)
            : base(sm, block)
        { }

        public override void ResetTransition()
        {
            block.ChangeBlockState(stateMachine.PyramidBlock);
            block.ChangeSprite();
        }
    }
}