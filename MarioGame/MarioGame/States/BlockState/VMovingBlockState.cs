using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    class VMovingBlockState : AbstractBlockState
    {
        public float VStart;
        public float VFinish;
        public float VSpeed;
        public VMovingBlockState(BlockStateMachine sm, BlockForm block)
            : base(sm, block)
        {
            VStart = block.Start;
            VFinish = block.Finish;
            VSpeed = block.Speed;
            block.Velocity = new Vector2(0f, VSpeed);
            block.Direction = Direction.RIGHT; // RIGHT = DOWN
        }

        public override void HitTransition()
        {
            block.ChangeBlockState(stateMachine.VMovingBlock);
            block.ChangeSprite();
        }

        public override void BigHitTransition()
        {
            block.ChangeBlockState(stateMachine.VMovingBlock);
            block.ChangeSprite();
        }

        public override void ResetTransition()
        {
            block.ChangeBlockState(stateMachine.VMovingBlock);
            block.ChangeSprite();
        }

        public override void Update(float elapsed)
        {
            if ((block.Direction == Direction.LEFT) && (block.Position.Y <= VStart))
            {
                block.Velocity = new Vector2(0f, VSpeed);
                block.Direction = Direction.RIGHT; // RIGHT = DOWN
            }
            else if ((block.Direction == Direction.RIGHT) && (block.Position.Y >= VFinish))
            {
                block.Velocity = new Vector2(0f, VSpeed * -1f);
                block.Direction = Direction.LEFT; // LEFT = UP
            }
            block.Position += block.Velocity * elapsed;
        }
    }
}