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
    public class GameplayState : AbstractGameState
    {
        private string level;

        public GameplayState(Scene scene, string level) : base(scene)
        {
            this.level = level;
            Scene.Checkpoint = Vector2.Zero;
        }

        public override void Load()
        {
            Scene.AudioHandler.PlayBGM("Audio/bgm", true);

            Vector2 startPos = new Vector2();
            Entities = MapSetup.LoadEntities(level, ref startPos, Content,scene);

            if (Scene.Checkpoint.X > startPos.X) startPos = Scene.Checkpoint;
            Scene.mario = new MarioEntity(new MarioFactory(Content), startPos);
            Scene.luigi = new LuigiEntity(new LuigiFactory(Content), new Vector2(startPos.X - 20, startPos.Y));

            if (scene.Single) Controllers = ControllerSetup.LoadLevelControllers1P(Scene.mario, scene);
            else Controllers = ControllerSetup.LoadLevelControllers2P(Scene.mario, Scene.luigi, scene);

            Entities.Add(Scene.mario);
            if (!scene.Single) Entities.Add(Scene.luigi);

            // Create a camera instance and limit its moving range
            Scene.camera = new Camera(scene.graphics.GraphicsDevice.Viewport) { Limits = Scene.Bound.Rectangle };

            // Create 9 layers with parallax ranging from 0% to 100% (only horizontal)
            Layers = new List<Layer>
            {
                
                new Layer(Scene.camera) { Parallax = new Vector2(0.0f, 0.0f) }, //background layers
                new Layer(Scene.camera) { Parallax = new Vector2(0.1f, 0.1f) },
                new Layer(Scene.camera) { Parallax = new Vector2(0.2f, 0.2f) },
                new Layer(Scene.camera) { Parallax = new Vector2(0.5f, 0.4f) },
                new Layer(Scene.camera) { Parallax = new Vector2(0.8f, 0.8f) },
                new Layer(Scene.camera) { Parallax = new Vector2(1.0f, 1.0f) },
                new Layer(Scene.camera) { Parallax = new Vector2(1.0f, 1.0f) },
                new Layer(Scene.camera) { Parallax = new Vector2(1.0f, 1.0f) }, 
                new Layer(Scene.camera) { Parallax = new Vector2(1.0f, 1.0f) }, // item
                new Layer(Scene.camera) { Parallax = new Vector2(1.0f, 1.0f) }, // blocks/char
                new Layer(Scene.camera) { Parallax = new Vector2(0.0f, 0.0f) }  // HUD
            };

            Rectangle limits = new Rectangle(0, 0, (int)Scene.camera.Limits.Value.Width, (int)Scene.camera.Limits.Value.Height);
            // Add one sprite to each background layer
            for (int i = 0; i < 6; i++ )
            {
                Layers[i].Sprites.Add(new Sprite { Texture = Content.Load<Texture2D>("Layer" + (i+1)), Entity = null, rect = limits });
            }
            Sprite dimLayer = new Sprite { Texture = Scene.Pixel, Entity = null, rect = limits };
            dimLayer.Dim = 1f;
            Layers[8].Sprites.Add(dimLayer);

            // Add a few duplicates in different positions
            //Layers[7].Sprites.Add(new Sprite { Texture = Content.Load<Texture2D>("Layer8"), Position = new Vector2(900, 0), Entity = null, rect = limits });
            //Layers[8].Sprites.Add(new Sprite { Texture = Content.Load<Texture2D>("Layer9"), Position = new Vector2(1600, 0), Entity = null, rect = limits });

            // add items to layer 9, everything else in layer 10
            foreach (Entity entity in Entities)
            {
                if (entity is ItemEntity) Layers[6].Sprites.Add(entity.Sprite);
                else if (entity is PlayerChar) Layers[9].Sprites.Add(entity.Sprite);
                else Layers[7].Sprites.Add(entity.Sprite);
            }

            // add HUD elements to Layer 11
            Layers[10].Sprites.Add(hud.MarioLivesDisp);
            Layers[10].Sprites.Add(hud.MarioCharDisp);
            Layers[10].Sprites.Add(hud.TimeDisp);
            Layers[10].Sprites.Add(hud.PointsDisp);
            if (!scene.Single)
            {
                Layers[10].Sprites.Add(hud.LuigiCharDisp);
                Layers[10].Sprites.Add(hud.LuigiLivesDisp);
                foreach (Sprite sprite in hud.LuigiLivesNum)
                {
                    Layers[10].Sprites.Add(sprite);
                }
            }
            foreach (Sprite sprite in hud.MarioLivesNum)
            {
                Layers[10].Sprites.Add(sprite);
            }
            foreach (Sprite sprite in hud.TimeNum)
            {
                Layers[10].Sprites.Add(sprite);
            }
            foreach (Sprite sprite in hud.PointsNum)
            {
                Layers[10].Sprites.Add(sprite);
            }
            foreach (Sprite sprite in hud.CoinsNum)
            {
                Layers[10].Sprites.Add(sprite);
            }
        }

        public override void Update(float elapsed)
        {
            foreach (IController controller in Controllers)
            {
                controller.UpdateSystemCommands(elapsed);
            }
            if (!isPaused)
            {
                if (Scene.mario.CurrentPowerState is MarioDeadState)
                {
                    Scene.mario.Update(elapsed);
                }
                else
                {
                    hud.Update(elapsed);
                    foreach (IController controller in Controllers)
                    {
                        controller.UpdatePlayerCommands(elapsed);
                    }
                    SpatialGrid collisionGrid = new SpatialGrid(Scene.Bound);

                    foreach (Entity entity in Entities)
                    {
                        if (entity.Removed)
                        {
                            Removed.Add(entity);
                        }
                        else
                        {
                            entity.Update(elapsed);
                            if (entity.Collidable) collisionGrid.Add(entity);
                        }
                    }

                    scene.RemoveEntities();
                    scene.UpdateCamera();

                    collisionGrid.CheckCollisions();

                }
            }

        }

        public override void Draw()
        {
            scene.GraphicsDevice.Clear(Color.CornflowerBlue);

            foreach (Layer layer in Layers)
            {
                layer.Draw(spriteBatch);
            }       
        }
    }
}
