using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    abstract class AbstractBlockState : IBlockState
    {
        protected BlockStateMachine stateMachine;

        protected BlockForm block;

        protected AbstractBlockState(BlockStateMachine sm, BlockForm blockForm)
        {
            stateMachine = sm;
            block = blockForm;
        }

        public virtual void HitTransition()
        {
            // normally does nothing upon being hit
        }

        public virtual void BigHitTransition()
        { }

        public virtual void ResetTransition()
        {
            // needs to be given a reset state
        }

        public virtual void Update(float elapsed)
        {

        }
    }
}
