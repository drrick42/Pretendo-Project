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
    public class GameOverState : AbstractGameState
    {
        private StaticText Title;
        private Menu menu;
        public SpriteFont Font
        {
            get { return scene.Font; }
            set { scene.Font = value; }
        }

        public GameOverState(Scene scene) : base(scene)
        {}

        public override void Load()
        {
            Title = new StaticText(Content, "gameover");
            Title.Position = new Vector2(150f, 75f);

            Scene.AudioHandler.PlayBGM("Audio/game_over", false);
            
            menu = new Menu(Font);
            menu.Position = new Vector2(175f, 150f);
            menu.AddOption(new ResetCommand(scene), "Restart");
            menu.AddOption(new QuitCommand(scene), "Quit");

            Controllers = ControllerSetup.LoadMenuControllers(menu, scene);
        }

        public override void Update(float elapsed)
        {
            foreach (IController controller in Controllers)
            {
                controller.UpdateSystemCommands(elapsed);
            }
        }

        public override void Draw()
        {
            scene.GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            Title.Draw(spriteBatch);
            menu.Draw(spriteBatch);
            scene.spriteBatch.End();
            scene.Layers[10].Draw(spriteBatch);

            
        }
    }
}
