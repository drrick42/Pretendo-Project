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
    public class TitleState : AbstractGameState
    {
        private StaticText Title;
        private Menu menu;
        public SpriteFont Font
        {
            get { return scene.Font; }
            set { scene.Font = value; }
        }

        public TitleState(Scene scene) : base(scene)
        {}

        public override void Load()
        {
            Title = new StaticText(Content, "SMW_title");
            Title.Position = new Vector2(112.5f, 10f);

            Scene.AudioHandler.PlayBGM("Audio/title_bgm", true);
            
            menu = new Menu(Font);
            menu.Position = new Vector2(200f, 150f);
            menu.AddOption(new StartSingleCommand(scene), "1 Player");
            menu.AddOption(new StartMultiCommand(scene), "2 Player");

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
            scene.GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            Title.Draw(spriteBatch);
            menu.Draw(spriteBatch);

            spriteBatch.DrawString(Font, "© 2015 Pretendo", new Vector2(175f, 230f), Color.White);

            scene.spriteBatch.End();
        }
    }
}
