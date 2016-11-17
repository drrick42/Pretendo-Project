using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace MarioGame
{
    public abstract class AbstractGameState : IGameState
    {
        protected Scene scene { get; set; }

        protected List<IController> Controllers
        {
            get { return scene.Controllers; }
            set { scene.Controllers = value;  }
        }

        protected List<Entity> Entities
        {
            get { return scene.Entities; }
            set { scene.Entities = value; }
        }

        protected List<Entity> Removed
        {
            get { return scene.removed; }
            set { scene.removed = value; }
        }

        protected List<Layer> Layers
        {
            get { return scene.Layers; }
            set { scene.Layers = value; }
        }

        protected HUD hud
        {
            get { return scene.hud; }
            set { scene.hud = value; }
        }

        protected bool isPaused
        {
            get { return scene.isPaused; }
            set { scene.isPaused = value; }
        }

        protected ContentManager Content
        {
            get { return scene.Content; }
            set { scene.Content = value; }
        }

        protected SpriteBatch spriteBatch
        {
            get { return scene.spriteBatch; }
            set { scene.spriteBatch = value; }
        }

        protected AbstractGameState(Scene scene)
        {
            this.scene = scene;
        }

        public abstract void Load();

        public abstract void Update(float elapsed);

        public abstract void Draw();
    }
    
}
