using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    class HMovingBlockState : AbstractBlockState
    {
        public float HStart;
        public float HFinish;
        public float Speed;
        public HMovingBlockState(BlockStateMachine sm, BlockForm block)
            : base(sm, block)
        {
            HStart = block.Start;
            HFinish = block.Finish;
            Speed = block.Speed; 
            block.Velocity = new Vector2(Speed, 0f);
            block.Direction = Direction.RIGHT;
        }

        public override void HitTransition()
        {
            block.ChangeBlockState(stateMachine.HMovingBlock);
            block.ChangeSprite();
        }

        public override void BigHitTransition()
        {
            block.ChangeBlockState(stateMachine.HMovingBlock);
            block.ChangeSprite();
        }

        public override void ResetTransition()
        {
            block.ChangeBlockState(stateMachine.HMovingBlock);
            block.ChangeSprite();
        }

        public override void Update(float elapsed)
        {
            if ((block.Direction == Direction.LEFT) && (block.Position.X <= HStart))
            {
                block.Velocity = new Vector2(Speed, 0f);
                block.Direction = Direction.RIGHT;
                
            }
            else if ((block.Direction == Direction.RIGHT) && (block.Position.X >= HFinish))
            {
                block.Velocity = new Vector2(Speed * -1f, 0f);
                block.Direction = Direction.LEFT;
            }
            block.Position += block.Velocity * elapsed;
        }
    }
}
