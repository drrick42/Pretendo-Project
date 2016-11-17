using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    public delegate void SoundEffectHandler(SoundEvent e);

    public enum SoundType { BGM, SFX }

    public abstract class SoundEvent : EventArgs
    {
        public string Name { get; private set; }

        public SoundEvent(String assetName)
        {
            Name = assetName;
        }
    }
    public class SFXEvent : SoundEvent
    {
        public SFXEvent(String assetName) : base(assetName)
        { }
    }

    public class BGMEvent : SoundEvent
    {
        public BGMEvent(String assetName)
            : base(assetName)
        { }
    }
}
