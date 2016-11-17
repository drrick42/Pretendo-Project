using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MarioGame
{
    class GamePadController : IController
    {
        private Dictionary<int, ICommand> systemCommandInterface;
        private Dictionary<int, ICommand> playerCommandInterface;
        private PlayerIndex player;

        GamePadState newState;
        GamePadState oldState;
        Buttons[] buttons;

        float totalElapsed;
        float timePerInput;

        public GamePadController(PlayerIndex playerIndex)
        {
            systemCommandInterface = new Dictionary<int, ICommand>();
            playerCommandInterface = new Dictionary<int, ICommand>();
            player = playerIndex;

            totalElapsed = 0;
            timePerInput = (float)Constants.INPUT_TIME_FACTOR / Constants.FRAMES_PER_SECOND;

            buttons = (Buttons[])Enum.GetValues(typeof(Buttons));
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
            if (newState.IsConnected && totalElapsed >= timePerInput)
            {
                ICommand command;

                // Check each button that is currently being pressed
                foreach (Buttons button in buttons)
                {
                    // Check if there is a corresponding command
                    if (newState.IsButtonDown(button) && playerCommandInterface.TryGetValue((int)button, out command))
                    {
                        command.Execute();
                    }
                }
                
                totalElapsed -= timePerInput;
            }
        }

        public void UpdateSystemCommands(float elapsed)
        {
            newState = GamePad.GetState(player);
            if (newState.IsConnected)
            {
                ICommand command;

                // Check each button that is currently being pressed
                foreach (Buttons button in buttons)
                {
                    bool newPress = newState.IsButtonDown(button) && oldState.IsButtonUp(button); 
                    // Check if there is a corresponding command
                    if (newPress && systemCommandInterface.TryGetValue((int)button, out command))
                    {
                        command.Execute();
                    }
                }

                oldState = newState;
            }
        }
    }
}
