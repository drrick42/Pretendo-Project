using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    public interface IController
    {
        void AddSystemCommand(int key, ICommand command);
        void AddPlayerCommand(int key, ICommand command);
        void UpdateSystemCommands(float elapsed);
        void UpdatePlayerCommands(float elapsed);
    }
}
