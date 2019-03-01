using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Nez;
using Nez.TextureAtlases;
using NezzyBird.Entities;
using NezzyBird.Systems;

namespace NezzyBird.Scenes
{
    public class MainScene : Scene
    {
        public MainScene(ContentManager content)
        {
            var textureAtlas = content.Load<TextureAtlas>("Textures/TextureAtlas");

            var background = new Background(textureAtlas);
            var foreground = new Foreground(textureAtlas);
            var bird = new Bird(textureAtlas);

            this.addEntity(background);
            this.addEntity(foreground);
            this.addEntity(bird);

            var renderer = new DefaultRenderer { renderTargetClearColor = Color.CornflowerBlue };

            this.addRenderer(new DefaultRenderer());

            this.addEntityProcessor(new GravitySystem());
            this.addEntityProcessor(new BirdSpriteRotationSystem());
            this.addEntityProcessor(new ScrollingSystem());

            addEntity(new PipePairSpawner(textureAtlas));
        }
    }
}
