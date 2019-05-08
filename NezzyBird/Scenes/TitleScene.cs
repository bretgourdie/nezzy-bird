using Microsoft.Xna.Framework;
using Nez;
using Nez.TextureAtlases;
using NezzyBird.Entities;

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
                new Foreground(textureAtlas)
            };

            foreach (var entity in initialEntities)
            {
                this.addEntity(entity);
            }

            this.addRenderer(renderer);

            Nez.Core.debugRenderEnabled = true;
        }
    }
}
