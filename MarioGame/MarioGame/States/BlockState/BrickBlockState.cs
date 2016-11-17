using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace MarioGame 
{
    class BrickBlockState : AbstractBlockState
    {
        public float originalPos;
        public int delete = 0;
        public BrickBlockState(BlockStateMachine sm, BlockForm block)
            : base(sm, block)
        { }

        public override void HitTransition()
        {
                originalPos = block.Position.Y;
                Vector2 vel = new Vector2(0f, -10f);
                Vector2 acc = new Vector2(0f, 40f);
                block.Velocity = vel;
                block.Acceleration = acc; 
        }

        public override void BigHitTransition() 
        {
                for (int i = 0; i < 4; i++)
                {
                    block.B[i].Acceleration = new Vector2(0f, .5f);
                }
                block.B[0].Velocity = new Vector2(3f, -2f);
                block.B[1].Velocity = new Vector2(3f, -1f);
                block.B[2].Velocity = new Vector2(-3f, -2f);
                block.B[3].Velocity = new Vector2(-3f, -1f);
                delete = 1;
        }

        public override void ResetTransition()
        {
            block.ChangeBlockState(stateMachine.BrickBlock);
            block.ChangeSprite();
        }

        public override void Update(float elapsed)
        {
            if (delete == 1) 
            {
                for(int i = 0; i < 4; i++)
                {
                    block.B[i].Position += block.B[i].Velocity;
                    block.B[i].Velocity += block.B[i].Acceleration;
                }
                if(block.B[1].Position.Y > Scene.Bound.Height)
                {
                    block.Removed = true;
                }
            }
            block.Position += block.Velocity * elapsed;
            block.Velocity += block.Acceleration * elapsed;
            
            if (block.Position.Y > originalPos)
            {
                block.Velocity = Vector2.Zero;
                block.Acceleration = Vector2.Zero;
                block.Position = new Vector2(block.Position.X, block.Position.Y);
            }
        }
    }
}
