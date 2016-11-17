using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    public class TimeLimit : ISoundPublisher
    {
        public int Timer { get; private set; }

        public static bool TimeOut {get; private set;}

        private int initialLimit;

        private int timePerIncrement;

        private float totalElapsedTime;

        private float dangerLimit;

        private bool warningSounded;

        public TimeLimit(int totalTime)
        {
            Timer = totalTime;
            TimeOut = false;
            initialLimit = totalTime;
            timePerIncrement = Constants.GAME_TIME_FACTOR;
            totalElapsedTime = 0;
            dangerLimit = Constants.GAME_TIME_DANGER;
            warningSounded = false;

            Scene.AudioHandler.Subscribe(this);
        }

        public event SoundEffectHandler SoundHandler;

        public void Update(float elapsed)
        {
            totalElapsedTime += elapsed;
            if (totalElapsedTime > timePerIncrement)
            {
                Timer -= (int)(totalElapsedTime / timePerIncrement);

                totalElapsedTime -= timePerIncrement;
            }

            if (Timer == 0)
            {
                TimeOut = true;
            }
            else
            {
                float timeRatio = ((float)Timer) / initialLimit;
                if (!warningSounded && timeRatio < dangerLimit)
                {
                    PlaySFX("time_warning");
                    warningSounded = true;
                }
            }
        }

        public void OnSoundEvent(SoundEvent e)
        {
            if (SoundHandler != null) SoundHandler(e);
        }

        public void PlaySFX(string assetName)
        {
             SFXEvent e = new SFXEvent(assetName);
             OnSoundEvent(e);
        }

        public void PlayBGM(string assetName) { }
    }
}
