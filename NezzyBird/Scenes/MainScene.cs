using Microsoft.Xna.Framework.Content;
using Nez;
using Nez.TextureAtlases;
using NezzyBird.Entities;

namespace NezzyBird.Scenes
{
    public class MainScene : Scene
    {
        public MainScene(ContentManager content)
        {
            var textureAtlas = content.Load<TextureAtlas>("Textures/TextureAtlas");

            var background = new Background(textureAtlas);
            var bird = new Bird(textureAtlas);

            this.addEntity(background);
            this.addEntity(bird);

            this.addRenderer(new DefaultRenderer());
        }
    }
}
