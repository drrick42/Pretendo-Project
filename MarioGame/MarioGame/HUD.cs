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
    public class HUD
    {
        public Sprite MarioCharDisp;
        public Sprite LuigiCharDisp;
        public Sprite MarioLivesDisp;
        public Sprite LuigiLivesDisp;
        public Sprite TimeDisp;
        public Sprite PointsDisp;
        public List<Sprite> MarioLivesNum;
        public List<Sprite> LuigiLivesNum;
        public List<Sprite> TimeNum;
        public List<Sprite> PointsNum;
        public List<Sprite> CoinsNum;
        private int HUDFrameCountX;
        private int HUDFrameCountY;
        private int numbersFrameCountX;
        private int numbersFrameCountY;
        private int HUDFrameWidth;
        private int HUDFrameHeight;
        private int numbersFrameWidth;
        private int numbersFrameHeight;
        private Vector2 LivesPos;
        private Vector2 TimePos;
        private Vector2 PointsPos;

        public int MarioLives
        {
            get
            {
                return MarioLifeTracker.Lives;
            }
            private set { }
        }
        public int LuigiLives
        {
            get
            {
                return LuigiLifeTracker.Lives;
            }
            private set { }
        }
        public int Points { get
            {
                return PointTracker.Points;
            }
            private set { }
        }
        public int Coins
        {
            get { return CoinTracker.Coins; }
            private set { }
        }
        public int Time
        {
            get { return TimeLimit.Timer; }
            private set { }
        }
        Scene scene;
        public static TimeLimit TimeLimit { get; set; }
        public static PointTracker PointTracker { get; set; }
        public static LifeTracker MarioLifeTracker { get; set; }
        public static LifeTracker LuigiLifeTracker { get; set; }
        public static CoinTracker CoinTracker { get; set; }
        public HUD(Scene scene, ContentManager Content, Vector2 livesPos, Vector2 timePos, Vector2 pointsPos)
        {
            this.scene = scene;
            TimeLimit = new TimeLimit(Constants.GAME_TIME_LIMIT);
            PointTracker = new PointTracker();
            MarioLifeTracker = new LifeTracker(scene);
            if (!scene.Single) LuigiLifeTracker = new LifeTracker(scene);
            else LuigiLifeTracker = null;
            CoinTracker = new CoinTracker();

            HUDFrameCountX = 4;
            HUDFrameCountY = 2;
            numbersFrameCountX = 16;
            numbersFrameCountY = 2;

            LivesPos = livesPos;
            TimePos = timePos;
            PointsPos = pointsPos;

            MarioLives = 0;
            LuigiLives = 0;
            Points = 0;

            Texture2D HUDTex = Content.Load<Texture2D>("HUD");
            HUDFrameWidth = HUDTex.Width / HUDFrameCountX;
            HUDFrameHeight = HUDTex.Height / HUDFrameCountY;

            Texture2D numbersTex = Content.Load<Texture2D>("numbers");
            numbersFrameWidth = numbersTex.Width / numbersFrameCountX;
            numbersFrameHeight = numbersTex.Height / numbersFrameCountY;


            MarioCharDisp = new Sprite { Texture = HUDTex, Entity = null, Position = LivesPos, rect = new Rectangle(HUDFrameWidth * 0, HUDFrameHeight * 0, HUDFrameWidth, HUDFrameHeight) };
            MarioLivesDisp = new Sprite { Texture = HUDTex, Entity = null, Position = LivesPos, rect = new Rectangle(HUDFrameWidth * 1, HUDFrameHeight * 0, HUDFrameWidth, HUDFrameHeight) };
            if (!scene.Single)
            {
                LuigiCharDisp = new Sprite { Texture = HUDTex, Entity = null, Position = new Vector2(LivesPos.X, LivesPos.Y + 34), rect = new Rectangle(HUDFrameWidth * 0, HUDFrameHeight * 1, HUDFrameWidth, HUDFrameHeight) };
                LuigiLivesDisp = new Sprite { Texture = HUDTex, Entity = null, Position = new Vector2(LivesPos.X, LivesPos.Y + 34), rect = new Rectangle(HUDFrameWidth * 1, HUDFrameHeight * 0, HUDFrameWidth, HUDFrameHeight) };
                LuigiLivesNum = new List<Sprite>
                {
                    new Sprite {  Texture = numbersTex, Entity = null, Position = (new Vector2(LivesPos.X + 48, LivesPos.Y + 48)), rect = new Rectangle(numbersFrameWidth * 0, numbersFrameHeight * 0, numbersFrameWidth, numbersFrameHeight)  },
                    new Sprite {  Texture = numbersTex, Entity = null, Position = (new Vector2(LivesPos.X + 32, LivesPos.Y + 48)), rect = new Rectangle(numbersFrameWidth * 0, numbersFrameHeight * 0, numbersFrameWidth, numbersFrameHeight) }
                };
            }
            TimeDisp = new Sprite { Texture = HUDTex, Entity = null, Position = TimePos, rect = new Rectangle(HUDFrameWidth * 2, HUDFrameHeight * 0, HUDFrameWidth, HUDFrameHeight) };
            PointsDisp = new Sprite { Texture = HUDTex, Entity = null, Position = PointsPos, rect = new Rectangle(HUDFrameWidth * 3, HUDFrameHeight * 0, HUDFrameWidth, HUDFrameHeight) };

            MarioLivesNum = new List<Sprite>
            {
                new Sprite {  Texture = numbersTex, Entity = null, Position = (new Vector2(LivesPos.X + 48, LivesPos.Y + 16)), rect = new Rectangle(numbersFrameWidth * 0, numbersFrameHeight * 0, numbersFrameWidth, numbersFrameHeight)  },
                new Sprite {  Texture = numbersTex, Entity = null, Position = (new Vector2(LivesPos.X + 32, LivesPos.Y + 16)), rect = new Rectangle(numbersFrameWidth * 0, numbersFrameHeight * 0, numbersFrameWidth, numbersFrameHeight) }
            };
            
            TimeNum = new List<Sprite>
            {
                new Sprite {  Texture = Content.Load<Texture2D>("numbers"), Entity = null, Position = (new Vector2(TimePos.X + 32, TimePos.Y + 16)), rect = new Rectangle(numbersFrameWidth * 0, numbersFrameHeight * 1, numbersFrameWidth, numbersFrameHeight)  },
                new Sprite {  Texture = Content.Load<Texture2D>("numbers"), Entity = null, Position = (new Vector2(TimePos.X + 16, TimePos.Y + 16)), rect = new Rectangle(numbersFrameWidth * 0, numbersFrameHeight * 1, numbersFrameWidth, numbersFrameHeight)  },
                new Sprite {  Texture = Content.Load<Texture2D>("numbers"), Entity = null, Position = (new Vector2(TimePos.X, TimePos.Y + 16)), rect = new Rectangle(numbersFrameWidth * 0, numbersFrameHeight * 1, numbersFrameWidth, numbersFrameHeight)  }

            };
            
            PointsNum = new List<Sprite>
            {
                new Sprite {  Texture = Content.Load<Texture2D>("numbers"), Entity = null, Position = (new Vector2(PointsPos.X + 112, PointsPos.Y + 16)), rect = new Rectangle(numbersFrameWidth * 0, numbersFrameHeight * 0, numbersFrameWidth, numbersFrameHeight)  },
                new Sprite {  Texture = Content.Load<Texture2D>("numbers"), Entity = null, Position = (new Vector2(PointsPos.X + 96, PointsPos.Y + 16)), rect = new Rectangle(numbersFrameWidth * 0, numbersFrameHeight * 0, numbersFrameWidth, numbersFrameHeight)  },
                new Sprite {  Texture = Content.Load<Texture2D>("numbers"), Entity = null, Position = (new Vector2(PointsPos.X + 80, PointsPos.Y + 16)), rect = new Rectangle(numbersFrameWidth * 0, numbersFrameHeight * 0, numbersFrameWidth, numbersFrameHeight)  },
                new Sprite {  Texture = Content.Load<Texture2D>("numbers"), Entity = null, Position = (new Vector2(PointsPos.X + 64, PointsPos.Y + 16)), rect = new Rectangle(numbersFrameWidth * 0, numbersFrameHeight * 0, numbersFrameWidth, numbersFrameHeight)  },
                new Sprite {  Texture = Content.Load<Texture2D>("numbers"), Entity = null, Position = (new Vector2(PointsPos.X + 48, PointsPos.Y + 16)), rect = new Rectangle(numbersFrameWidth * 0, numbersFrameHeight * 0, numbersFrameWidth, numbersFrameHeight)  },
                new Sprite {  Texture = Content.Load<Texture2D>("numbers"), Entity = null, Position = (new Vector2(PointsPos.X + 32, PointsPos.Y + 16)), rect = new Rectangle(numbersFrameWidth * 0, numbersFrameHeight * 0, numbersFrameWidth, numbersFrameHeight)  },
                new Sprite {  Texture = Content.Load<Texture2D>("numbers"), Entity = null, Position = (new Vector2(PointsPos.X + 16, PointsPos.Y + 16)), rect = new Rectangle(numbersFrameWidth * 0, numbersFrameHeight * 0, numbersFrameWidth, numbersFrameHeight) },
                
            };

            CoinsNum = new List<Sprite>
            {
                new Sprite {  Texture = Content.Load<Texture2D>("numbers"), Entity = null, Position = (new Vector2(PointsPos.X + 112, PointsPos.Y)), rect = new Rectangle(numbersFrameWidth * 0, numbersFrameHeight * 0, numbersFrameWidth, numbersFrameHeight)  },
                new Sprite {  Texture = Content.Load<Texture2D>("numbers"), Entity = null, Position = (new Vector2(PointsPos.X + 96, PointsPos.Y)), rect = new Rectangle(numbersFrameWidth * 0, numbersFrameHeight * 0, numbersFrameWidth, numbersFrameHeight)  },
                new Sprite {  Texture = Content.Load<Texture2D>("numbers"), Entity = null, Position = (new Vector2(PointsPos.X + 80, PointsPos.Y)), rect = new Rectangle(numbersFrameWidth * 0, numbersFrameHeight * 0, numbersFrameWidth, numbersFrameHeight)  },
                new Sprite {  Texture = Content.Load<Texture2D>("numbers"), Entity = null, Position = (new Vector2(PointsPos.X + 64, PointsPos.Y)), rect = new Rectangle(numbersFrameWidth * 0, numbersFrameHeight * 0, numbersFrameWidth, numbersFrameHeight)  }
            };

        }

        public void Update(float elapsed)
        {
            if (MarioLifeTracker.Dead && ((LuigiLifeTracker != null) && (LuigiLifeTracker.Dead)))
            {
                scene.SoftReset();
                MarioLifeTracker.Dead = false;
                if (LuigiLifeTracker != null) LuigiLifeTracker.Dead = false;
            }
            else
            {
                // set LivesNum Frames based on number of Lives
                int num;
                int Temp;
                num = (MarioLives % 10);
                MarioLivesNum[0].rect = new Rectangle(numbersFrameWidth * num, numbersFrameHeight * 0, numbersFrameWidth, numbersFrameHeight);
                num = (MarioLives / 10) % 10;
                MarioLivesNum[1].rect = new Rectangle(numbersFrameWidth * num, numbersFrameHeight * 0, numbersFrameWidth, numbersFrameHeight);
                if (!scene.Single)
                {
                    num = (LuigiLives % 10);
                    LuigiLivesNum[0].rect = new Rectangle(numbersFrameWidth * num, numbersFrameHeight * 0, numbersFrameWidth, numbersFrameHeight);
                    num = (LuigiLives / 10) % 10;
                    LuigiLivesNum[1].rect = new Rectangle(numbersFrameWidth * num, numbersFrameHeight * 0, numbersFrameWidth, numbersFrameHeight);
                }

                TimeLimit.Update(elapsed);
                // set TimeNum Frames based on amount of Time remaining
                Temp = TimeLimit.Timer;
                foreach (Sprite sprite in TimeNum)
                {
                    num = (Temp % 10);
                    sprite.rect = new Rectangle(numbersFrameWidth * num, numbersFrameHeight * 1, numbersFrameWidth, numbersFrameHeight);
                    Temp = Temp / 10;

                }

                // set PointsNum Frames based on number of Points
                Temp = Points;
                // set TimeNum Frames based on amount of Time remaining
                foreach (Sprite sprite in PointsNum)
                {
                    num = (Temp % 10);
                    sprite.rect = new Rectangle(numbersFrameWidth * num, numbersFrameHeight * 0, numbersFrameWidth, numbersFrameHeight);
                    Temp = Temp / 10;
                }

                // set PointsNum Frames based on number of Points
                Temp = Coins;
                // set TimeNum Frames based on amount of Time remaining
                foreach (Sprite sprite in CoinsNum)
                {
                    num = (Temp % 10);
                    sprite.rect = new Rectangle(numbersFrameWidth * num, numbersFrameHeight * 0, numbersFrameWidth, numbersFrameHeight);
                    Temp = Temp / 10;
                }
            }
            

        }
        public void resetTime()
        {
            TimeLimit = new TimeLimit(Constants.GAME_TIME_LIMIT);
        }

    }

}
