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
            _mouthUpPipe = new Pipe(textureAtlas, VerticalDirection.MouthOpens.Up);
            var mouthUpPipeStartingY = startingYCenter;
            _mouthUpPipe.position = new Vector2(_mouthUpPipe.position.X, mouthUpPipeStartingY);

            _mouthDownPipe = new Pipe(textureAtlas, VerticalDirection.MouthOpens.Down);
            var mouthDownPipeStartingY = startingYCenter;
            _mouthDownPipe.position = new Vector2(_mouthDownPipe.position.X, mouthDownPipeStartingY);
        }

        public override void onAddedToScene()
        {
            scene.addEntity(_mouthUpPipe);
            scene.addEntity(_mouthDownPipe);
        }
    }
}
