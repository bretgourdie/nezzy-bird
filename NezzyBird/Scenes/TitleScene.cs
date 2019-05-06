using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Nez;
using Nez.TextureAtlases;
using NezzyBird.Entities;

namespace NezzyBird.Scenes
{
    public class TitleScene : Scene
    {
        public TitleScene(ContentManager content)
        {
            var textureAtlas = content.Load<TextureAtlas>("Textures/TextureAtlas");

            var renderer = new DefaultRenderer { renderTargetClearColor = Color.CornflowerBlue };

            var initialEntities = new Entity[]
            {
                new TitleSceneUI(textureAtlas)
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
