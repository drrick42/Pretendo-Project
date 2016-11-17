using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace MarioGame
{
    class KeyboardController : IController
    {
        private Dictionary<int, ICommand> systemCommandInterface;
        private Dictionary<int, ICommand> playerCommandInterface;

        float totalElapsed;
        float timePerInput;

        KeyboardState oldState;
        KeyboardState newState;
        Keys[] pressed;

        public KeyboardController()
        {
            systemCommandInterface = new Dictionary<int, ICommand>();
            playerCommandInterface = new Dictionary<int, ICommand>();

            totalElapsed = 0;
            timePerInput = (float)Constants.INPUT_TIME_FACTOR / Constants.FRAMES_PER_SECOND;

            oldState = Keyboard.GetState();
        }

        public void AddSystemCommand(int key, ICommand command)
        {
            systemCommandInterface.Add(key, command);
        }
        public void AddPlayerCommand(int key, ICommand command)
        {
            playerCommandInterface.Add(key, command);
        }

        public void UpdatePlayerCommands(float elapsed)
        {
            totalElapsed += elapsed;
            if (totalElapsed >= timePerInput)
            {
                // Holder for the command that will be executed
                ICommand command;

                // Check each key that is currently being pressed
                foreach (Keys key in pressed)
                {
                    // Check if there is a corresponding command
                    if (playerCommandInterface.TryGetValue((int)key, out command))
                    {
                        command.Execute();
                    }
                }

                totalElapsed -= timePerInput;
            }
        }

        public void UpdateSystemCommands(float elapsed)
        {
            // Get the keys that are currently being pressed
            newState = Keyboard.GetState();
            pressed = newState.GetPressedKeys();

            // Holder for the command that will be executed
            ICommand command;

            // Check each key that is currently being pressed
            foreach (Keys key in pressed)
            {
                // Check if there is a corresponding command
                if (oldState.IsKeyUp(key) && systemCommandInterface.TryGetValue((int)key, out command))
                {
                    command.Execute();
                }
            }

            oldState = newState;
            
        }
    }
}
