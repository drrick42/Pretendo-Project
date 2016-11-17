using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class BrickEntity : BlockForm
    {
        public BrickEntity(ObstacleFactory factory, Vector2 position, Entity ItemEnt)
            : base(factory, ItemEnt)
        {
            Block = (AbstractObstacle)SpriteFactory.getSprite((int)obstacleTypes.BRICKBLOCK);
            Block.Position = position;
            Block.Position = Vector2.Clamp(this.Position, new Vector2(0f, Position.Y - 2f), new Vector2(1000000f, Position.Y));
            B = new AbstractObstacle[4];
            for (int i = 0; i < 4; i++)
            {
                B[i] = (AbstractObstacle)SpriteFactory.getSprite((int)obstacleTypes.BRICKSHARD);
                B[i].Position = Block.Position;
                B[i].Velocity = Vector2.Zero;
                
            }
            Sprite.Position = position;
            Block.Velocity = Vector2.Zero;
            float originalPos = Block.Position.Y;
            BlockSM = new BlockStateMachine(this);
            CurrentBlockState = new BrickBlockState(BlockSM, this);
        }

        public override void HitTransition()
        {
            PlaySFX("brick_bounce");
            base.HitTransition();
        }

        public override void BigHitTransition()
        {
            DrawCheck = 1;
            PlaySFX("break_block");
            base.BigHitTransition();
        }
        
    }
}