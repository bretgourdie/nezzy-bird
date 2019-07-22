using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using Nez.TextureAtlases;
using NezzyBird.Components;

namespace NezzyBird.Entities
{
    public class GetReady : Entity
    {
        public GetReady(TextureAtlas textureAtlas)
        {
            var subtexture = textureAtlas.getSubtexture("GetReady");
            var sprite = new Sprite(subtexture);
            sprite.setRenderLayer(GameConstants.RenderingLevels.Graphic);
            addComponent(sprite);

            addComponent(new Fades(FadeDirection.In, 1f));

            addComponent(
                new FadesOnFirstJump(
                    new Fades(FadeDirection.Out, 1.5f)
                )
            );

            this.scale = GameConstants.GetGameScale();

            this.position = new Vector2(
                GameConstants.SCREEN_WIDTH / 2,
                GameConstants.SCREEN_HEIGHT / 4);

            this.name = this.GetType().Name;
        }
    }
}
