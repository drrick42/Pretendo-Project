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
    public class WinningState : AbstractGameState
    {
        private float timer;

        public WinningState(Scene scene) : base(scene)
        {
            timer = 0;
        }

        public override void Load()
        {
        }

        public override void Update(float elapsed)
        {
            timer += elapsed;
            Sprite fader = Layers[8].Sprites[0];
            if (fader.Dim > 0)
            {
                fader.Dim -= .005f;
                Console.WriteLine(fader.Dim);
            }
            if (timer > 10) scene.NextLevel();
        }

        public override void Draw()
        {
            scene.GraphicsDevice.Clear(Color.CornflowerBlue);

            foreach (Layer layer in Layers)
            {
                layer.Draw(spriteBatch);
            }
            if (timer > 5)
            {
                spriteBatch.Begin();
                spriteBatch.DrawString(scene.Font, "Points: " + scene.hud.Points.ToString(), new Vector2(100f, 100f), Color.White);
                spriteBatch.DrawString(scene.Font, "Time: " + scene.hud.Time.ToString(), new Vector2(100f, 130f), Color.White);
                spriteBatch.End();
            }
        }
    }
}
