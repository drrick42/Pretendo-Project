using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    class HitQuestionCommand : BlockCommand
    {
        public HitQuestionCommand(BlockForm block)
            : base(block)
        { }

        public override void Execute()
        {
            if (receiver.CurrentBlockState is QuestionBlockState)
            { 
                receiver.CurrentBlockState.HitTransition();
            }
        }
    }
}