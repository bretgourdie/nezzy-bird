using Microsoft.Xna.Framework.Audio;
using Nez;
using Nez.Systems;
using System.Collections.Generic;

namespace NezzyBird.Systems
{
    public class SoundSystem : PassiveSystem
    {
        private readonly IDictionary<SoundEffect, SoundEffectInstance> _soundToInstance;

        private SoundEffect _jumpSound;

        public SoundSystem(Emitter<NezzyEvents> emitter)
        {
            _soundToInstance = new Dictionary<SoundEffect, SoundEffectInstance>();
            _registerEvents(emitter);
        }

        public override void onAddedToScene()
        {
            _loadSounds();
        }

        private void _loadSounds()
        {
            _jumpSound = scene.content.Load<SoundEffect>(@"Sounds\jump");
        }

        private void _registerEvents(Emitter<NezzyEvents> emitter)
        {
            emitter.addObserver(NezzyEvents.BirdJumped, _playJumpSound);
        }

        private void _playJumpSound()
        {
            _playSound(_jumpSound);
        }

        private void _playSound(SoundEffect soundEffect)
        {
            SoundEffectInstance instance;
            if (!_soundToInstance.ContainsKey(soundEffect))
            {
                instance = soundEffect.CreateInstance();
                _soundToInstance[soundEffect] = instance;
            }
            else
            {
                instance = _soundToInstance[soundEffect];
            }

            if (instance.State == SoundState.Playing)
            {
                instance.Stop();
            }

            instance.Play();
        }
    }
}
