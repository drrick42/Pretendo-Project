using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    public interface IGameState
    {
        void Update(float elapsed);

        void Load();

        void Draw();
    }
}
