using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using Nez.TextureAtlases;
using NezzyBird.Components;

namespace NezzyBird.Entities
{
    public class Bird : Entity
    {
        public Bird(TextureAtlas textureAtlas)
        {
            var birdAnimation = textureAtlas.getSpriteAnimation("BirdAnimation");
            var birdIdleSubtexture = textureAtlas.getSubtexture("BirdAnimation/birdflap1_2");
            addComponent(new Sprite(birdIdleSubtexture.texture2D));
            addComponent(new AffectedByGravity());
            addComponent(new JumpsOnTap());

            this.scale = new Vector2(3, 3);

            this.position = new Vector2(200, 200);
        }
    }
}
