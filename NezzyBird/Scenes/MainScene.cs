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
            var bird = new Bird(textureAtlas);

            this.addEntity(background);
            this.addEntity(bird);

            var renderer = new DefaultRenderer();
            renderer.renderTargetClearColor = Color.CornflowerBlue;

            this.addRenderer(new DefaultRenderer());

            var gravitySystem = new GravitySystem();
            this.addEntityProcessor(gravitySystem);
            var birdSpriteRotationSystem = new BirdSpriteRotationSystem();
            this.addEntityProcessor(birdSpriteRotationSystem);
        }
    }
}
