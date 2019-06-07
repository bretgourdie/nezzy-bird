using Microsoft.Xna.Framework;
using Nez;
using Nez.Systems;
using Nez.TextureAtlases;
using NezzyBird.Entities;
using NezzyBird.Systems;

namespace NezzyBird.Scenes
{
    public class MainScene : Scene
    {
        public MainScene()
        {
            var textureAtlas = content.Load<TextureAtlas>("Textures/TextureAtlas");
            var emitter = new Emitter<NezzyEvents>();

            var foreground = new Foreground(textureAtlas);

            var initialEntities = new Entity[]
            {
                new Background(textureAtlas),
                foreground,
                new Bird(textureAtlas),
                new PipePairSpawner(),
                new ScoreDisplay(textureAtlas, emitter)
            };

            foreach (var entity in initialEntities)
            {
                this.addEntity(entity);
            }

            var renderer = new DefaultRenderer { renderTargetClearColor = Color.CornflowerBlue };

            this.addRenderer(renderer);

            var initialSystems = new EntitySystem[]
            {
                new GravitySystem(foreground),
                new BirdSpriteRotationSystem(emitter),
                new ScrollingSystem(new ScrollingMovement(), emitter),
                new PipePairSpawningSystem(emitter, textureAtlas),
                new JumpSystem(emitter),
                new ScoreZoneCollisionSystem(emitter),
                new DeathCollisionSystem(emitter),
                new ScoreDisplaySystem(textureAtlas),
                new ParallaxScrollingSystem(),
                new ScreenFlashSystem(),
                new PausingSystem(),
                new GameOverSystem(),
                new GameOverTriggeringSystem(emitter, textureAtlas),
            };

            foreach (var system in initialSystems)
            {
                this.addEntityProcessor(system);
            }
        }
    }
}
