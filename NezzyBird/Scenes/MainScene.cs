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

            var initialEntities = new Entity[]
            {
                new Background(textureAtlas),
                new Foreground(textureAtlas),
                new Bird(textureAtlas),
                new PipePairSpawner(textureAtlas, emitter),
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
                new GravitySystem(),
                new BirdSpriteRotationSystem(),
                new ScrollingSystem(),
                new LifeDependentActionOnIntervalSystem(emitter),
                new JumpSystem(emitter),
                new ScoreZoneCollisionSystem(emitter),
                new DeathCollisionSystem(emitter),
                new ScoreDisplaySystem(textureAtlas)
            };

            foreach (var system in initialSystems)
            {
                this.addEntityProcessor(system);
            }

            Nez.Core.debugRenderEnabled = true;
        }
    }
}
