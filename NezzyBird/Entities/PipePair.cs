using Microsoft.Xna.Framework;
using Nez;
using Nez.TextureAtlases;
using NezzyBird.Components;

namespace NezzyBird.Entities
{
    public class PipePair : Entity
    {
        private readonly Pipe _mouthUpPipe;
        private readonly Pipe _mouthDownPipe;

        public PipePair(
            TextureAtlas textureAtlas,
            float startingYCenter)
        {
            var spaceFromStartingYCenter = 10 * GameConstants.SPRITE_SCALE_FACTOR;

            var spaceAboveStartingY = startingYCenter - spaceFromStartingYCenter;
            var spaceBelowStartingY = startingYCenter + spaceFromStartingYCenter;

            _mouthUpPipe = new Pipe(textureAtlas, VerticalDirection.MouthOpens.Up);
            var mouthUpPipeStartingY = spaceBelowStartingY;
            _mouthUpPipe.setLocalPosition(new Vector2(_mouthUpPipe.position.X, mouthUpPipeStartingY));

            _mouthDownPipe = new Pipe(textureAtlas, VerticalDirection.MouthOpens.Down);
            var pipeHeight = 200 * GameConstants.SPRITE_SCALE_FACTOR;
            var mouthDownPipeStartingY = spaceAboveStartingY - pipeHeight;
            _mouthDownPipe.setLocalPosition(new Vector2(_mouthDownPipe.position.X, mouthDownPipeStartingY));
        }

        public override void onAddedToScene()
        {
            scene.addEntity(_mouthUpPipe);
            scene.addEntity(_mouthDownPipe);
        }
    }
}
