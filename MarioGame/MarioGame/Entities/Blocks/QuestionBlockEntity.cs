using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class QuestionBlockEntity : BlockForm
    {
        public QuestionBlockEntity(ObstacleFactory factory, Vector2 position, Entity ItemEnt)
            : base(factory, ItemEnt)
        {
            Block = (AbstractObstacle)SpriteFactory.getSprite((int)obstacleTypes.QUESTIONBLOCK);
            Block.Position = position;
            BlockSM = new BlockStateMachine(this);
            CurrentBlockState = new QuestionBlockState(BlockSM, this);
        }

    }
}