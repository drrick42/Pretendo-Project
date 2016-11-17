using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    static class ControllerSetup
    {

        public static List<IController> LoadMenuControllers(Menu menu, Scene scene)
        {
            List<IController> controllers = new List<IController>();

            controllers.Add(SetupMenuKeyboard(menu, scene));

            controllers.Add(SetupMenuGamepad(PlayerIndex.One, menu, scene));

            return controllers;
        }

        public static KeyboardController SetupMenuKeyboard(Menu menu, Scene scene)
        {
            KeyboardController keyboard = new KeyboardController();

            // Add system commands here
            keyboard.AddSystemCommand((int)Keys.Q, new QuitCommand(scene));

            // Add player commands here
            keyboard.AddSystemCommand((int)Keys.Up, new ScrollUpCommand(menu));
            keyboard.AddSystemCommand((int)Keys.Down, new ScrollDownCommand(menu));

            keyboard.AddSystemCommand((int)Keys.W, new ScrollUpCommand(menu));
            keyboard.AddSystemCommand((int)Keys.S, new ScrollDownCommand(menu));

            keyboard.AddSystemCommand((int)Keys.Enter, new SelectCommand(menu));

            return keyboard;
        }

        public static GamePadController SetupMenuGamepad(PlayerIndex player, Menu menu, Scene scene)
        {
            GamePadController gamepad = new GamePadController(player);

            // Add commands here
            gamepad.AddSystemCommand((int)Buttons.DPadUp, new ScrollUpCommand(menu));
            gamepad.AddSystemCommand((int)Buttons.DPadDown, new ScrollDownCommand(menu));

            return gamepad;
        }

        public static List<IController> LoadLevelControllers1P(PlayerChar mario, Scene scene)
        {
            List<IController> controllers = new List<IController>();

            // Add keyboard to list
            controllers.Add(SetupLevelKeyboard1P(mario, scene));

            controllers.Add(SetupLevelGamepad(PlayerIndex.One, mario, scene));

            return controllers;
        }

        public static List<IController> LoadLevelControllers2P(PlayerChar mario, PlayerChar luigi, Scene scene)
        {
            List<IController> controllers = new List<IController>();

            // Add keyboard to list
            controllers.Add(SetupLevelKeyboard2P(mario,luigi,scene));


            controllers.Add(SetupLevelGamepad(PlayerIndex.One, mario,scene));
            controllers.Add(SetupLevelGamepad(PlayerIndex.Two, luigi, scene));

            return controllers;
        }

        public static KeyboardController SetupLevelKeyboard1P(PlayerChar mario, Scene scene)
        {
            KeyboardController keyboard = new KeyboardController();

            // Add system commands here
            keyboard.AddSystemCommand((int)Keys.Q, new QuitCommand(scene));
            keyboard.AddSystemCommand((int)Keys.Space, new ResetCommand(scene));
            keyboard.AddSystemCommand((int)Keys.P, new PauseCommand(scene));

            keyboard.AddPlayerCommand((int)Keys.W, new UpCommand(mario));
            keyboard.AddPlayerCommand((int)Keys.S, new DownCommand(mario));
            keyboard.AddPlayerCommand((int)Keys.A, new LeftCommand(mario));
            keyboard.AddPlayerCommand((int)Keys.D, new RightCommand(mario));


            keyboard.AddPlayerCommand((int)Keys.U, new MarioSuperCommand(mario));
            keyboard.AddPlayerCommand((int)Keys.I, new MarioFireCommand(mario));
            keyboard.AddPlayerCommand((int)Keys.O, new MarioDamageCommand(mario));
            keyboard.AddPlayerCommand((int)Keys.Y, new MarioResetCommand(mario));

            keyboard.AddPlayerCommand((int)Keys.F, new MarioFireBallCommand(mario));
            return keyboard;
        }

        public static KeyboardController SetupLevelKeyboard2P(PlayerChar mario, PlayerChar luigi, Scene scene)
        {
            KeyboardController keyboard = new KeyboardController();

            // Add system commands here
            keyboard.AddSystemCommand((int)Keys.Q, new QuitCommand(scene));
            keyboard.AddSystemCommand((int)Keys.Space, new ResetCommand(scene));
            keyboard.AddSystemCommand((int)Keys.P, new PauseCommand(scene));

            // Add player commands here
            keyboard.AddPlayerCommand((int)Keys.Up, new UpCommand(luigi));
            keyboard.AddPlayerCommand((int)Keys.Down, new DownCommand(luigi));
            keyboard.AddPlayerCommand((int)Keys.Left, new LeftCommand(luigi));
            keyboard.AddPlayerCommand((int)Keys.Right, new RightCommand(luigi));

            keyboard.AddPlayerCommand((int)Keys.W, new UpCommand(mario));
            keyboard.AddPlayerCommand((int)Keys.S, new DownCommand(mario));
            keyboard.AddPlayerCommand((int)Keys.A, new LeftCommand(mario));
            keyboard.AddPlayerCommand((int)Keys.D, new RightCommand(mario));

            keyboard.AddPlayerCommand((int)Keys.F, new MarioFireBallCommand(mario));
            keyboard.AddPlayerCommand((int)Keys.L, new MarioFireBallCommand(luigi));
            return keyboard;
        }

        public static GamePadController SetupLevelGamepad(PlayerIndex player, PlayerChar playerChar, Scene scene)
        {
            GamePadController gamepad = new GamePadController(player);

            // Add commands here
            gamepad.AddPlayerCommand((int)Buttons.DPadUp, new UpCommand(playerChar));
            gamepad.AddPlayerCommand((int)Buttons.DPadDown, new DownCommand(playerChar));
            gamepad.AddPlayerCommand((int)Buttons.DPadLeft, new LeftCommand(playerChar));
            gamepad.AddPlayerCommand((int)Buttons.DPadRight, new RightCommand(playerChar));

            return gamepad;
        }
    }
}
