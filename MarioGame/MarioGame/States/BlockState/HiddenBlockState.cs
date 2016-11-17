using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    class HiddenBlockState : AbstractBlockState
    {
        public HiddenBlockState(BlockStateMachine sm, BlockForm block)
            : base(sm, block)
        { }

        public override void HitTransition()
        {
            block.ChangeBlockState(stateMachine.UsedBlock);
            block.ChangeSprite();
        }

        public override void ResetTransition()
        {
            block.ChangeBlockState(stateMachine.HiddenBlock);
            block.ChangeSprite();
        }
    }
}