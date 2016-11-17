using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace MarioGame
{
    public class AudioHandler
    {
        ContentManager content;

        private bool Mute;
        private bool Paused;

        private SoundEffectInstance BGM;

        private Dictionary<String, SoundEffect> soundEffects;

        public AudioHandler(ContentManager content)
        {
            this.content = content;
            Mute = false;
            Paused = false;

            soundEffects = new Dictionary<string, SoundEffect>();
        }

        public void PlayBGM(String assetName, bool looped)
        {
            if (BGM != null) BGM.Dispose();
            SoundEffect bgm;
            if (!(soundEffects.TryGetValue(assetName, out bgm)))
            {
                bgm = content.Load<SoundEffect>(assetName);
                soundEffects.Add(assetName, bgm);
            }

            BGM = bgm.CreateInstance();
            BGM.IsLooped = looped;
            BGM.Play();
        }

        public void PauseBGM() 
        {
            Paused = !Paused;
            if (Paused) BGM.Pause();
            else BGM.Play();
       }

        public void PlaySound(SoundEvent e)
        {
            string assetName = "Audio/" + e.Name;
            if (e is SFXEvent)
            {
                PlaySoundEffect(assetName);
            }
            else
            {
                PlayBGM(assetName, false);
            }
        }

        public void PlaySoundEffect(String assetName)
        {
            SoundEffect effect;
            if (!(soundEffects.TryGetValue(assetName, out effect)))
            {
                effect = content.Load<SoundEffect>(assetName);
                soundEffects.Add(assetName, effect);
            }

            effect.Play();
        }

        public void MuteAction()
        {
            Mute = !Mute;

            float volume = Convert.ToInt16(Mute);
            BGM.Volume = volume;

        }

        public void Subscribe(ISoundPublisher publisher)
        {
            publisher.SoundHandler += new SoundEffectHandler(PlaySound);
        }
    }
}
