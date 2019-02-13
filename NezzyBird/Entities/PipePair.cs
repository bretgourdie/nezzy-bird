using Nez;
using Nez.TextureAtlases;
using NezzyBird.Components;

namespace NezzyBird.Entities
{
    public class PipePair : Entity
    {
        public Pipe MouthUpPipe { get; private set; }
        public Pipe MouthDownPipe { get; private set; }

        public PipePair(TextureAtlas textureAtlas)
        {
            MouthUpPipe = new Pipe(textureAtlas, VerticalDirection.MouthOpens.Up);
            MouthDownPipe = new Pipe(textureAtlas, VerticalDirection.MouthOpens.Down);
        }
    }
}
