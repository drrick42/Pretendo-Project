using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    public interface ISoundPublisher
    {
        event SoundEffectHandler SoundHandler;

        void OnSoundEvent(SoundEvent e);

        void PlaySFX(string assetName);

        void PlayBGM(string assetName);
    }
}
