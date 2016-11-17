using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class MovingBlockEntity : BlockForm
    {
        bool isHMovement;
        public MovingBlockEntity(ObstacleFactory factory, Vector2 position, Entity ItemEnt, float speed, bool hMovement, float start, float finish)
            : base(factory, ItemEnt)
        {
            Start = start;
            Finish = finish;
            Speed = speed;
            isHMovement = hMovement;
            Block = (AbstractObstacle)SpriteFactory.getSprite((int)obstacleTypes.USEDBLOCK);
            Block.Position = position;
            Sprite.Position = position;
            Block.Velocity = Vector2.Zero;
            BlockSM = new BlockStateMachine(this);
            if (hMovement) 
            CurrentBlockState = new HMovingBlockState(BlockSM, this);
            else CurrentBlockState = new VMovingBlockState(BlockSM, this);
        }
        public override void HandleCollision(Vector2 vector, AABB collision, Entity collider)
        {
            Side side = AABB.SideHit(BoundingBox, collision);
            if (collider is PlayerChar && !isHMovement) Bounce(side, collision, collider);
            base.HandleCollision(vector, collision, collider);
        }


    }
}
