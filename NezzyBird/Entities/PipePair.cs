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

        public PipePair(TextureAtlas textureAtlas)
        {
            // TODO: Update starting Y
            _mouthUpPipe = new Pipe(textureAtlas, VerticalDirection.MouthOpens.Up);
            _mouthUpPipe.position = new Vector2(_mouthUpPipe.position.X, 700);
            _mouthDownPipe = new Pipe(textureAtlas, VerticalDirection.MouthOpens.Down);
            _mouthDownPipe.position = new Vector2(_mouthDownPipe.position.X, 50);
        }

        public override void onAddedToScene()
        {
            scene.addEntity(_mouthUpPipe);
            scene.addEntity(_mouthDownPipe);
        }
    }
}
