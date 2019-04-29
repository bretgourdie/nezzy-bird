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

            var initialEntities = new Entity[]
            {
                new Background(textureAtlas),
                new Foreground(textureAtlas),
                new TitleDisplay(textureAtlas),
                new TitleScreenBird(textureAtlas),
                new StartButton(textureAtlas),
                new RankingButton(textureAtlas)
            };

            foreach (var entity in initialEntities)
            {
                this.addEntity(entity);
            }

            var renderer = new DefaultRenderer { renderTargetClearColor = Color.CornflowerBlue };

            this.addRenderer(renderer);
        }
    }
}
