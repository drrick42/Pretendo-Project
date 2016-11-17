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
    /// This is the main type for your game
    /// </summary>
    public class Scene : Microsoft.Xna.Framework.Game
    {
        public GraphicsDeviceManager graphics { get; set; }
        public static Bound Bound;
        private IGameState state;
        private List<string> levelList;
        private int levelID;

        public SpriteBatch spriteBatch { get; set; }

        public bool isPaused { get; set; }
        public static Texture2D Pixel { get; private set; }
        public static AudioHandler AudioHandler { get; private set; }

        public List<IController> Controllers { get; set; }

        public bool Single;
        public List<Entity> Entities { get; set; }
        public List<Entity> removed { get; set; }
        public List<Entity> added { get; set; }

        public static PlayerChar mario;
        public static PlayerChar luigi;
        public static Vector2 AvgPosition;

        public static Vector2 Checkpoint;
        public static int LastCheckpoint;

        public static Camera camera;

        public List<Layer> Layers { get; set;}

        public HUD hud { get; set; }
        public SpriteFont Font { get; set; }

        public Scene()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 512;
            graphics.PreferredBackBufferHeight = 256;
           
            Bound = null;
            Content.RootDirectory = "Content";
            AudioHandler = new AudioHandler(Content);

            isPaused = false;

            Entities = new List<Entity>();
            removed = new List<Entity>();

            levelList = new List<string>();
            levelList.Add("level_1-2.xml");
            levelList.Add("level_1-3.xml");
            levelID = 0;
            added = new List<Entity>();
            LastCheckpoint = 0;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Pixel = new Texture2D(GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            Pixel.SetData(new[] { Color.Black });

            // create HUD and set display positions
            Vector2 livesPos = new Vector2(20, 10.0f);
            Vector2 timePos = new Vector2(GraphicsDevice.Viewport.Width/2-32, 10.0f);
            Vector2 pointsPos = new Vector2(GraphicsDevice.Viewport.Width - 148, 10.0f);
            hud = new HUD(this, Content, livesPos, timePos, pointsPos);

            Font = Content.Load<SpriteFont>("font");

            TitleScreen();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (!Single && mario != null && luigi != null)
            {
                AvgPosition = new Vector2(((mario.Position.X + luigi.Position.X) / 2), ((mario.Position.Y + luigi.Position.Y) / 2));
            }
            else if(mario != null) 
            {
                AvgPosition = mario.Position;
            }
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            state.Update(elapsed);

            base.Update(gameTime);
        }

        public void RemoveEntities()
        {
            foreach (Entity toRemove in removed)
            {
                Layers[6].Sprites.Remove(toRemove.Sprite);
                Layers[7].Sprites.Remove(toRemove.Sprite);
                Entities.Remove(toRemove);
            }
            removed.Clear();
        }

        public void AddedEntities()
        {
            foreach (Entity toAdd in added)
            {
                Entities.Add(toAdd);
                Layers[7].Sprites.Add(toAdd.Sprite);
            }
            added.Clear();
        }

        public void UpdateCamera()
        {
            if ((AvgPosition.X <= (Bound.Width - (graphics.GraphicsDevice.Viewport.Width) / 2)) || AvgPosition.Y <= (Bound.Height - (graphics.GraphicsDevice.Viewport.Height) / 2))
                {
                    camera.LookAt(AvgPosition);
                }
        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            state.Draw();
            
            base.Draw(gameTime);
        }

        public void Pause()
        {
            isPaused = !isPaused;
            AudioHandler.PauseBGM();
        }

        public void HardReset()
        {
            LoadContent();
            levelID = 0;
            isPaused = false;
        }

        public void SoftReset()
        {
            state.Load();
        }

        public void TitleScreen()
        {
            state = new TitleState(this);
            state.Load();
        }

        public void GameOver()
        {
            state = new GameOverState(this);
            state.Load();
        }

        public void StartSingle()
        {
            Single = true;
            NextLevel();
        }

        public void StartMulti()
        {
            Single = false;
            NextLevel();
        }

        public void WinLevel()
        {
            state = new WinningState(this);
        }

        public void NextLevel()
        {
            if (levelID >= levelList.Count) GameOver();
            else
            {
                state = new GameplayState(this, levelList[levelID]);
                LastCheckpoint = 0;

                levelID++;

                state.Load();
            }
        }
            
        
    }
}
