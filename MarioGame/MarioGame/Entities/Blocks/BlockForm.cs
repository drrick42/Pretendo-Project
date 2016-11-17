using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public abstract class BlockForm : Entity, IBlockState
    {
        public float Start = 0f;
        public float Finish = 0f;
        public float Speed = 0f;
        public ItemEntity item { get; set; }
        public int DrawCheck = 0;
        public AbstractObstacle Block { get; set; }
        public AbstractObstacle[] B { get; set; }
        
        public override Vector2 Velocity { get; set; }
        public override Vector2 Acceleration { get; set; }
        public override Vector2 Position
        {
            get { return Block.Position; }
            set 
            {
                Block.Position = value;
                Sprite.Position = value;
            }
        }
        public Direction Direction { get; set; }

        public IAnimation Animation { get; set; }

        public ObstacleFactory Factory { get; set; }

        protected BlockForm(ObstacleFactory factory, Entity ItemEnt) : base()
        {
            item = (ItemEntity)ItemEnt;
            if (item != null)
            {
                item.ChangeItemState(item.ItemSM.Inactive);
            }
            SpriteFactory = factory;
        }

        public IBlockState CurrentBlockState { get; protected set; }

        public BlockStateMachine BlockSM { get; set; }
        public ObstacleFactory SpriteFactory { get; set; }

        public override int Width
        {
            get { return Block.Width; }
            set { }
        }

        public override int Height
        {
            get { return Block.Height; }
            set { }
        }
 
        public virtual void HitTransition()
        {
            CurrentBlockState.HitTransition();
        }
        public virtual void BigHitTransition()
        {
            CurrentBlockState.BigHitTransition();
        }
        public void ResetTransition()
        {
            CurrentBlockState.ResetTransition();
        }

        public override void HandleCollision(Vector2 vector, AABB collision, Entity collider)
        {
            Side side = AABB.SideHit(BoundingBox, collision);

            if (side == Side.BOTTOM && collider is PlayerChar)
            {
                if (item != null)
                {
                    item.EmergingTransition();
                    item = null;
                }
                PlayerChar colliderChar = (PlayerChar)collider;
                if ((colliderChar.IsSmall() && Velocity.Equals(Vector2.Zero)))
                {
                    this.HitTransition();
                }
                else if (!colliderChar.IsSmall())
                {

                    this.BigHitTransition();
                }
            }
            // Bounce any entities off except for an emerging or inactive item
            if (collider is ItemEntity)
            {
                if( !(((ItemEntity)collider).CurrentItemState is InactiveItemState) && !(((ItemEntity)collider).CurrentItemState is EmergingItemState) )
                Bounce(side, collision, collider);
            }
            else if ((collider is EnemyEntity) || (collider is PlayerChar && Velocity.Y == 0))
                Bounce(side, collision, collider);

            
        }

        public override void Update(float elapsed)
        {
            Block.Update(elapsed);
            if (DrawCheck == 1)
            {
                for (int i = 0; i < 4; i++)
                {
                    B[i].Update(elapsed);
                }
            }
            CurrentBlockState.Update(elapsed);

            Sprite.Position = Block.Position;
            base.Update(elapsed);
        }

        public override void Draw(SpriteBatch batch)
        {
            if (DrawCheck == 0)
            {
                Block.Draw(batch);
            }
            else if(DrawCheck == 1)
            {
                B[0].Draw(batch);
                B[1].Draw(batch);
                B[2].Draw(batch);
                B[3].Draw(batch);
            }
            base.Draw(batch);
        }

        public void ChangeSprite()
        {
            Vector2 position = Block.Position;
            if (CurrentBlockState is BrickBlockState)
            {
                Block = (AbstractObstacle)SpriteFactory.getSprite((int)obstacleTypes.BRICKBLOCK);
            }
            else if (CurrentBlockState is PyramidBlockState)
            {
                Block = (AbstractObstacle)SpriteFactory.getSprite((int)obstacleTypes.PYRAMID);
            }
            else if (CurrentBlockState is QuestionBlockState)
            {
                Block = (AbstractObstacle)SpriteFactory.getSprite((int)obstacleTypes.QUESTIONBLOCK);
            }
            else if (CurrentBlockState is UsedBlockState)
            {
                Block = (AbstractObstacle)SpriteFactory.getSprite((int)obstacleTypes.USEDBLOCK);
            }
            else if (CurrentBlockState is HiddenBlockState)
            {
                Block = (AbstractObstacle)SpriteFactory.getSprite((int)obstacleTypes.HIDDENBLOCK);
            }
            Block.Position = position;
        }
        
        public void ChangeBlockState(IBlockState newState)
        {
            CurrentBlockState = newState;
        }
        
    }
}
