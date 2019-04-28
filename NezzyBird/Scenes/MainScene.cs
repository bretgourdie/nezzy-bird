using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Nez;
using Nez.Systems;
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

            this.addRenderer(new DefaultRenderer());

            this.addEntityProcessor(new GravitySystem());
            this.addEntityProcessor(new BirdSpriteRotationSystem());
            this.addEntityProcessor(new ScrollingSystem());
            this.addEntityProcessor(new LifeDependentActionOnIntervalSystem());
            this.addEntityProcessor(new JumpSystem(emitter));
            this.addEntityProcessor(new ScoreZoneCollisionSystem(emitter));
            this.addEntityProcessor(new DeathCollisionSystem(emitter));
            this.addEntityProcessor(new ScoreDisplaySystem(textureAtlas));

            Nez.Core.debugRenderEnabled = true;
        }
    }
}
