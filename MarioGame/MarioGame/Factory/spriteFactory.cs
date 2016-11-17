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
    /// <summary>
    /// sprite factory
    /// </summary>
    
    public enum MarioTypes
    {
        NORMAL,
        SUPER,
        FIRE,
        STARMINI,
        STARBIG,
        DEAD,
        FIREBALL
    }
    public enum enemyTypes
    {
        GOOMBA,
        GREENKOOPA,
        GREENSHELL
    }
    public enum itemTypes
    {
        SUPERSHROOM,
        ONEUPSHROOM,
        ITEMSTAR,
        FIREFLOWER,
        COINS,
    }
    public enum obstacleTypes
    {
        BRICKBLOCK,
        USEDBLOCK,
        PYRAMID,
        QUESTIONBLOCK,
        HIDDENBLOCK,
        BRICKSHARD
    }

    public enum floorTypes
    {
        NFLOOR,
        NWFLOOR,
        WFLOOR,
        SWFLOOR,
        SFLOOR,
        SEFLOOR,
        EFLOOR,
        NEFLOOR,
        GROUND,
        LCEDGE,
        LEDGE,
        RCEDGE,
        REDGE
    }

    public enum flagTypes
    {
        FLAG,
        CHECKPOINT
    }
    
    public abstract class AbstractFactory : Factory
    {
        protected ContentManager Content { get; set; }

        protected AbstractFactory(ContentManager content)
        {
            this.Content = content;
        }

        public abstract ISprite getSprite(int type);
    }

   
    //implementation of the factory- creates objects
    public class MarioFactory: AbstractFactory
    {
        public MarioFactory(ContentManager content) : base(content)
        { }

        //Method to create mario objects
        public override ISprite getSprite(int type)
        {
            ISprite newMario = null;
            DateTime expiration = new DateTime(2033, 8, 16);
            switch(type)
            {
                case (int)MarioTypes.NORMAL:
                    newMario = new MiniMario1(Content);
                    break;
                case (int)MarioTypes.SUPER:
                    newMario = new BigMario1(Content);
                    break;
                case (int)MarioTypes.FIRE:
                    newMario = new FireMario1(Content);                    
                    break;
                case (int)MarioTypes.STARMINI:
                    newMario = new MiniStarMario1(Content);                 
                    break;
                case (int)MarioTypes.STARBIG:
                    newMario = new BigStarMario1(Content);                  
                    break;
                case (int)MarioTypes.FIREBALL:
                    newMario = new FireBall(Content);
                    break;
                default:
                    break;
            }
            return newMario;
        }
    }
    public class LuigiFactory : AbstractFactory
    {
        public LuigiFactory(ContentManager content)
            : base(content)
        { }

        //Method to create mario objects
        public override ISprite getSprite(int type)
        {
            ISprite newLuigi = null;
            DateTime expiration = new DateTime(2033, 8, 16);
            switch (type)
            {
                case (int)MarioTypes.NORMAL:
                    newLuigi = new MiniLuigi(Content);
                    break;
                case (int)MarioTypes.SUPER:
                    newLuigi = new BigLuigi(Content);
                    break;
                case (int)MarioTypes.FIRE:
                    newLuigi = new FireLuigi(Content);
                    break;
                case (int)MarioTypes.STARMINI:
                    newLuigi = new MiniStarLuigi(Content);
                    break;
                case (int)MarioTypes.STARBIG:
                    newLuigi = new BigStarLuigi(Content);
                    break;
                case (int)MarioTypes.FIREBALL:
                    //newLuigi = new FireBall(Content);
                    break;
                default:
                    break;
            }
            return newLuigi;
        }
    }
    public class EnemyFactory : AbstractFactory
    {
        public EnemyFactory(ContentManager content) : base(content)
        { }
        public override ISprite getSprite(int type)
        {
            ISprite newEnemy = null;
            DateTime expiration = new DateTime(2033, 8, 16);
            switch (type)
            {
                case (int)enemyTypes.GOOMBA:
                    newEnemy = new Goomba1(Content);
                    break;
                case (int)enemyTypes.GREENKOOPA:
                    newEnemy = new GreenKoopa1(Content);
                    break;
                default:
                    break;
            }
            return newEnemy;
        }
    }
    public class ItemFactory : AbstractFactory
    {
        public ItemFactory(ContentManager content) : base(content)
        { }
        public override ISprite getSprite(int type)
        {
            ISprite newItem = null;
            DateTime expiration = new DateTime(2033, 8, 16);
            switch (type)
            {
                case (int)itemTypes.COINS:
                    newItem = new Coin(Content);
                    break;
                case (int)itemTypes.SUPERSHROOM:
                    newItem = new Mushroom(Content);
                    break;
                case (int)itemTypes.ONEUPSHROOM:
                    newItem = new OneUpMushroom(Content);
                    break;
                case (int)itemTypes.FIREFLOWER:
                    newItem = new Flower(Content);
                    break;
                case (int)itemTypes.ITEMSTAR:
                    newItem = new Star(Content);
                    break;
                default:
                    break;
            }
            return newItem;
        }
    }
    public class ObstacleFactory : AbstractFactory
    {
        public ObstacleFactory(ContentManager content) : base(content)
        { }
        public override ISprite getSprite(int type)
        {
            ISprite newObstacle = null;
            DateTime expiration = new DateTime(2033, 8, 16);
            switch(type)
            {
                case (int)obstacleTypes.BRICKBLOCK:
                    newObstacle = new BrickBlock(Content);
                    break;
                case (int)obstacleTypes.PYRAMID:
                    newObstacle = new PyramidBlock(Content);                   
                    break;
                case (int)obstacleTypes.QUESTIONBLOCK:
                    newObstacle = new QuestionBlock(Content);
                    break;
                case (int)obstacleTypes.HIDDENBLOCK:
                    newObstacle = new HiddenBlock(Content);                   
                    break;
                case (int)obstacleTypes.USEDBLOCK:
                    newObstacle = new UsedBlock(Content);                  
                    break;
                case (int)obstacleTypes.BRICKSHARD:
                    newObstacle = new BrickShard(Content);
                    break;
                default:
                    break;
            }
            return newObstacle;
        }
        public ISprite getFloor(int floorType)
        {
            ISprite newObstacle = new FloorBlock(Content, floorType);
            return newObstacle;
        }
        public ISprite getFlag(int flagType)
        {
            ISprite newObstacle = null;
            DateTime expiration = new DateTime(2033, 8, 16);
            switch (flagType)
            {
                case (int)flagTypes.FLAG:
                    newObstacle = new Flag(Content);
                    break;
                case (int)flagTypes.CHECKPOINT:
                    newObstacle = new Checkpoint(Content);
                    break;
            }
            return newObstacle;
        }
    }


}

