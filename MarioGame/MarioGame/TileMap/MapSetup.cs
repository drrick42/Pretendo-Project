using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace MarioGame
{
    static class MapSetup
    {

        public static List<Entity> LoadEntities(String level, ref Vector2 playerPos, ContentManager Content, Scene scene)
        {
            List<Entity> entities = new List<Entity>();
            float tileMod = 16;

            using (XmlReader xmlReader = XmlReader.Create(level))
            {
                while (xmlReader.Read())
                {
                    // first collects the level parameters
                    if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "level"))
                    {
                        int xVal = int.Parse(xmlReader.GetAttribute("x")) * (int)tileMod;
                        int yVal = int.Parse(xmlReader.GetAttribute("y")) * (int)tileMod - 1;
                        Scene.Bound = new Bound(new Rectangle(0, 0, xVal, yVal));
                    }
                    // collects the player position
                    else if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "player"))
                    {
                        float xVal = float.Parse(xmlReader.GetAttribute("x")) * tileMod;
                        float yVal = float.Parse(xmlReader.GetAttribute("y")) * tileMod - 1f;
                        playerPos = new Vector2(xVal, yVal);
                    }
                    // creates block that can contain an item and adds to list of entities
                    else if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "block"))
                    {
                        if (xmlReader.HasAttributes)
                        {
                            String id = xmlReader.GetAttribute("id");
                            float xVal = float.Parse(xmlReader.GetAttribute("x")) * tileMod;
                            float yVal = float.Parse(xmlReader.GetAttribute("y")) * tileMod - 1f;
                            int repeat = int.Parse(xmlReader.GetAttribute("repeat"));
                            String value = xmlReader.GetAttribute("value");
                            Entity itemEnt = null;
                            if (id.CompareTo("FloorBlock") != 0)
                            {
                                if (value.CompareTo("null") != 0 && value.CompareTo("VRepeat") != 0)
                                {
                                    itemEnt = LoadItem(value, xVal, yVal, Content);
                                    ((ItemEntity)itemEnt).InactiveTransition();
                                    entities.Add(itemEnt);
                                }
                            }
                            for (int i = 0; i < repeat; i++)
                            {
                                float offset = (float)(16 * i);
                                if (value.CompareTo("VRepeat") == 0)
                                    entities.Add(LoadBlock(id, xVal, yVal + offset, itemEnt, value, Content));
                                else entities.Add(LoadBlock(id, xVal + offset, yVal, itemEnt, value, Content));
                            }
                        }
                    }
                    // creates block that can move vertically or horizontally
                    else if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "mblock"))
                    {
                        if (xmlReader.HasAttributes)
                        {
                            String movement = xmlReader.GetAttribute("id");
                            bool hMovement = true;
                            float xVal = float.Parse(xmlReader.GetAttribute("x")) * tileMod;
                            float yVal = float.Parse(xmlReader.GetAttribute("y")) * tileMod - 1f;
                            int repeat = int.Parse(xmlReader.GetAttribute("repeat"));
                            float speed = float.Parse(xmlReader.GetAttribute("speed"));
                            float start = float.Parse(xmlReader.GetAttribute("start")) * tileMod;
                            float finish = float.Parse(xmlReader.GetAttribute("finish")) * tileMod;
                            if (movement.CompareTo("Horizontal") != 0)
                            {
                                hMovement = false; 
                                start = start - 1f;
                                finish = finish -1f;
                            }
                            for (int i = 0; i < repeat; i++)
                            {
                                float offset = (float)(16 * i);
                                if (hMovement)
                                    entities.Add(LoadMBlock(xVal + offset, yVal, speed, hMovement, start + offset, finish + offset, Content));
                                else entities.Add(LoadMBlock(xVal + offset, yVal, speed, hMovement, start, finish, Content));

                            }
                        }
                    }
                    // creates enemy and adds to list of entities
                    else if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "enemy"))
                    {
                        if (xmlReader.HasAttributes)
                        {
                            String id = xmlReader.GetAttribute("id");
                            float xVal = float.Parse(xmlReader.GetAttribute("x")) * tileMod;
                            float yVal = float.Parse(xmlReader.GetAttribute("y")) * tileMod - 1f;
                            entities.Add(LoadEnemy(id, xVal, yVal, Content));
                        }
                    }
                    // creates item and adds to list of entities
                    else if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "pow"))
                    {
                        if (xmlReader.HasAttributes)
                        {
                            String id = xmlReader.GetAttribute("id");
                            float xVal = float.Parse(xmlReader.GetAttribute("x")) * tileMod;
                            float yVal = float.Parse(xmlReader.GetAttribute("y")) * tileMod - 1f;
                            if (id.CompareTo("Coin") == 0) yVal = yVal - 1f;
                            entities.Add(LoadItem(id, xVal, yVal, Content));
                        }
                    }
                    else if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "check"))
                    {
                        if (xmlReader.HasAttributes)
                        {
                            float xVal = float.Parse(xmlReader.GetAttribute("x")) * tileMod;
                            float yVal = float.Parse(xmlReader.GetAttribute("y")) * tileMod - 1f;
                            int uID = int.Parse(xmlReader.GetAttribute("uid"));
                            entities.Add(LoadCheckpoint(xVal, yVal, uID, Content,scene));
                        }
                    }
                    else if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "flag"))
                    {
                        if (xmlReader.HasAttributes)
                        {
                            float xVal = float.Parse(xmlReader.GetAttribute("x")) * tileMod;
                            float yVal = float.Parse(xmlReader.GetAttribute("y")) * tileMod - 1f;
                            entities.Add(LoadFlag(xVal, yVal, Content,scene));
                        }
                    }
                }
            }

            return entities;
        }

        public static Entity LoadBlock(String id, float xVal, float yVal, Entity item, String value, ContentManager Content)
        {
            Entity entity = null;
            int floorVal;

            if (id.Equals("FloorBlock"))
            {
                floorVal = GetFloor.GetFloorKind(value);
                entity = new FloorBlockEntity(new ObstacleFactory(Content), new Vector2(xVal, yVal), item, floorVal);
            }
            else if (id.Equals("BrickBlock"))
            {
                if (item == null)
                {
                    entity = new BrickEntity(new ObstacleFactory(Content), new Vector2(xVal, yVal), item);
                }
                else
                {
                    entity = new BrickItemBlockEntity(new ObstacleFactory(Content), new Vector2(xVal, yVal), item);
                }
            }
            else if (id.Equals("QuestionBlock"))
            {
                entity = new QuestionBlockEntity(new ObstacleFactory(Content), new Vector2(xVal, yVal), item);
            }
            else if (id.Equals("PyramidBlock"))
            {
                entity = new PyramidEntity(new ObstacleFactory(Content), new Vector2(xVal, yVal), item);
            }
            else if (id.Equals("HiddenBlock"))
            {
                entity = new HiddenBlockEntity(new ObstacleFactory(Content), new Vector2(xVal, yVal), item);
            }
            else if (id.Equals("UsedBlock"))
            {
                entity = new UsedBlockEntity(new ObstacleFactory(Content), new Vector2(xVal, yVal), item);
            }

            return entity;
        }

        public static Entity LoadMBlock(float xVal, float yVal, float speed, bool hMovement, float start, float finish, ContentManager Content)
        {

            return new MovingBlockEntity(new ObstacleFactory(Content), new Vector2(xVal, yVal), null, speed, hMovement, start, finish);
        }

        public static Entity LoadEnemy(String id, float xVal, float yVal, ContentManager Content)
        {
            Entity entity = null;

            if (id.Equals("Goomba"))
            {
                entity = new GoombaChar(new EnemyFactory(Content), new Vector2(xVal, yVal));
            }
            else if (id.Equals("GreenKoopa"))
            {
                entity = new GreenKoopaChar(new EnemyFactory(Content), new Vector2(xVal, yVal));
            }

            return entity;
        }

        public static Entity LoadItem(String id, float xVal, float yVal, ContentManager Content)
        {
            Entity entity = null;

            if (id.Equals("Coin"))
            {
                entity = new CoinEntity(new ItemFactory(Content), new Vector2(xVal, yVal));
            }
            else if (id.Equals("Flower"))
            {
                entity = new FlowerEntity(new ItemFactory(Content), new Vector2(xVal, yVal));
            }
            else if (id.Equals("Mushroom"))
            {
                entity = new MushroomEntity(new ItemFactory(Content), new Vector2(xVal, yVal));
            }
            else if (id.Equals("OneUp"))
            {
                entity = new OneUpMushroomEntity(new ItemFactory(Content), new Vector2(xVal, yVal));
            }
            else if (id.Equals("Star"))
            {
                entity = new StarEntity(new ItemFactory(Content), new Vector2(xVal, yVal));
            }
            return entity;
        }

        public static Entity LoadCheckpoint(float xVal, float yVal, int uID, ContentManager Content, Scene scene)
        {
            LevelCheckpointEntity entity = new LevelCheckpointEntity(scene,new ObstacleFactory(Content), new Vector2(xVal, yVal), uID);
            if (uID <= Scene.LastCheckpoint) entity.Collidable = false;
            return entity;
        }
        public static Entity LoadFlag(float xVal, float yVal, ContentManager Content, Scene scene)
        {
            return new LevelFlagEntity(scene,new ObstacleFactory(Content), new Vector2(xVal, yVal));
        }
    }
}
