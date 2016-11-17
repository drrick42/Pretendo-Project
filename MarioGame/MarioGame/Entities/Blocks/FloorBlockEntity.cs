using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class FloorBlockEntity : BlockForm
    {
        public FloorBlockEntity(ObstacleFactory factory, Vector2 position, Entity ItemEnt, int floorType)
            : base(factory, ItemEnt)
        {
            Block = (AbstractObstacle)SpriteFactory.getFloor(floorType);
            Block.Position = position;
            BlockSM = new BlockStateMachine(this);
            CurrentBlockState = new FloorBlockState(BlockSM, this);
        }

    }
}