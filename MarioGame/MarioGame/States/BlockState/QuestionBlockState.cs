using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    class QuestionBlockState : AbstractBlockState
    {
        public QuestionBlockState(BlockStateMachine sm, BlockForm block)
            : base(sm, block)
        { }

        public override void HitTransition()
        {
            block.ChangeBlockState(stateMachine.UsedBlock);
            block.ChangeSprite();
        }

        public override void BigHitTransition()
        {
            block.ChangeBlockState(stateMachine.UsedBlock);
            block.ChangeSprite();
        }

        public override void ResetTransition()
        {
            block.ChangeBlockState(stateMachine.QuestionBlock);
            block.ChangeSprite();
        }
    }
}
