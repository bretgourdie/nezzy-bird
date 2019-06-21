using Microsoft.Xna.Framework;
using Nez;
using Nez.Systems;
using Nez.TextureAtlases;
using NezzyBird.Components;
using NezzyBird.Systems;

namespace NezzyBird.Entities
{
    public class PipePair : Entity
    {
        private readonly Pipe _mouthUpPipe;
        private readonly Pipe _mouthDownPipe;
        private readonly ScoreZone _scoreZone;

        public PipePair(
            TextureAtlas textureAtlas,
            Emitter<NezzyEvents> emitter,
            float startingYCenter)
        {
            var spaceFromStartingYCenter = 6 * GameConstants.SPRITE_SCALE_FACTOR;

            var spaceAboveStartingY = startingYCenter - spaceFromStartingYCenter;
            var spaceBelowStartingY = startingYCenter + spaceFromStartingYCenter;

            _mouthUpPipe = new Pipe(textureAtlas, emitter, VerticalDirection.MouthOpens.Up);
            var mouthUpPipeStartingY = spaceBelowStartingY;
            _mouthUpPipe.setLocalPosition(new Vector2(_mouthUpPipe.position.X, mouthUpPipeStartingY));

            _mouthDownPipe = new Pipe(textureAtlas, emitter, VerticalDirection.MouthOpens.Down);
            var pipeHeight = 200 * GameConstants.SPRITE_SCALE_FACTOR;
            var mouthDownPipeStartingY = spaceAboveStartingY - pipeHeight;
            _mouthDownPipe.setLocalPosition(new Vector2(_mouthDownPipe.position.X, mouthDownPipeStartingY));

            _scoreZone = new ScoreZone(emitter);
            _scoreZone.setLocalPosition(new Vector2(_scoreZone.position.X, startingYCenter));

            this.name = $"{this.GetType().Name} {Time.timeSinceSceneLoad}";
        }

        public override void onAddedToScene()
        {
            scene.addEntity(_mouthUpPipe);
            scene.addEntity(_mouthDownPipe);
            scene.addEntity(_scoreZone);
        }
    }
}
