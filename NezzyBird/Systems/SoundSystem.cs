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
        private SoundEffect _deathSound;
        private SoundEffect _transitionSwoosh;

        private readonly Emitter<NezzyEvents> _emitter;

        public SoundSystem(Emitter<NezzyEvents> emitter)
        {
            _emitter = emitter;
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
            _deathSound = scene.content.Load<SoundEffect>(@"Sounds\death");
            _transitionSwoosh = scene.content.Load<SoundEffect>(@"Sounds\transition swoosh");
        }

        private void _registerEvents(Emitter<NezzyEvents> emitter)
        {
            emitter.addObserver(NezzyEvents.BirdJumped, _playJumpSound);
            emitter.addObserver(NezzyEvents.BirdDied, _playDeathSound);
            emitter.addObserver(NezzyEvents.Transition, _playTransitionSwoosh);
        }

        private void _playTransitionSwoosh()
        {
            _playSound(_transitionSwoosh);
        }

        private void _playJumpSound()
        {
            _playSound(_jumpSound);
        }

        private void _playDeathSound()
        {
            // BirdDied sent every frame, only play death once
            _emitter.removeObserver(NezzyEvents.BirdDied, _playDeathSound);

            _playSound(_deathSound);
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
