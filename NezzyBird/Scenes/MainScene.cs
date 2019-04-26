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

            var scoreDisplay = new ScoreDisplay(textureAtlas);
            var initialEntities = new Entity[]
            {
                new Background(textureAtlas),
                new Foreground(textureAtlas),
                new Bird(textureAtlas),
                new PipePairSpawner(textureAtlas),
                scoreDisplay
            };

            var emitter = new Emitter<NezzyEvents>();
            emitter.addObserver(NezzyEvents.BirdScored, scoreDisplay.OnScoreUpdated);

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
            this.addEntityProcessor(new JumpSystem());
            this.addEntityProcessor(new ScoreZoneCollisionSystem(emitter));
            this.addEntityProcessor(new DeathCollisionSystem(emitter));
            this.addEntityProcessor(new ScoreDisplaySystem(textureAtlas));

            Nez.Core.debugRenderEnabled = true;
        }
    }
}
