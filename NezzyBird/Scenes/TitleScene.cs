using Microsoft.Xna.Framework;
using Nez;
using Nez.Systems;
using Nez.TextureAtlases;
using NezzyBird.Entities;
using NezzyBird.Systems;

namespace NezzyBird.Scenes
{
    public class TitleScene : Scene
    {
        public TitleScene()
        {
            var textureAtlas = content.Load<TextureAtlas>("Textures/TextureAtlas");

            var renderer = new DefaultRenderer { renderTargetClearColor = Color.CornflowerBlue };

            var initialEntities = new Entity[]
            {
                new Background(textureAtlas),
                new TitleSceneUI(textureAtlas),
                new Foreground(textureAtlas),
                new TitleScreenBird().GetBird(textureAtlas)
            };

            foreach (var entity in initialEntities)
            {
                this.addEntity(entity);
            }

            var scrollingMovement = new ScrollingMovement();
            var emitter = new Emitter<NezzyEvents>();

            var initialSystems = new EntitySystem[]
            {
                new ParallaxScrollingSystem(),
                new ScrollingSystem(scrollingMovement, emitter)
            };

            foreach (var system in initialSystems)
            {
                this.addEntityProcessor(system);
            }

            this.addRenderer(renderer);
        }
    }
}
