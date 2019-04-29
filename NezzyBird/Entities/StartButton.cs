using Microsoft.Xna.Framework.Content;
using Nez;
using Nez.TextureAtlases;
using NezzyBird.Components;
using NezzyBird.Scenes;

namespace NezzyBird.Entities
{
    public class StartButton : Entity
    {
        public StartButton(
            TextureAtlas textureAtlas,
            ContentManager contentManager)
        {
            var changeSceneOnTap = new ChangeSceneOnTap(new MainScene(contentManager));

            addComponent(
                new ReactsToTap(
                    changeSceneOnTap,
                    changeSceneOnTap.RequestSceneChange
                )
            );
        }
    }
}
