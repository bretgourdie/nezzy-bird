using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using Nez.TextureAtlases;
using NezzyBird.Components;

namespace NezzyBird.Entities
{
    public class Instructions : Entity
    {

        public Instructions(TextureAtlas textureAtlas)
        {
            var instructionsSubtexture = textureAtlas.getSubtexture("Instructions");
            var sprite = new Sprite(instructionsSubtexture);
            sprite.setMaterial(Material.defaultMaterial);

            addComponent(sprite);
            addComponent(new Fades(FadeDirection.In, 14.5f));

            this.position = new Vector2(
                GameConstants.SCREEN_WIDTH / 2,
                GameConstants.SCREEN_HEIGHT / 2);
        }
    }
}
