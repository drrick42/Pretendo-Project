using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    class UsedBlockState : AbstractBlockState
    {
        public UsedBlockState(BlockStateMachine sm, BlockForm block)
            : base(sm, block)
        { }

        public override void ResetTransition()
        {
            block.ChangeBlockState(stateMachine.UsedBlock);
            block.ChangeSprite();
        }
    }
}