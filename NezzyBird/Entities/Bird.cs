using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using NezzyBird.Components;

namespace NezzyBird.Entities
{
    public class Bird : Entity
    {
        public Bird(Texture2D birdTexture)
        {
            var sprite = new Sprite(birdTexture);
            addComponent(sprite);
            addComponent(new AffectedByGravity());
            addComponent(new JumpsOnTap());

            this.position = new Vector2(200, 200);
        }
    }
}
