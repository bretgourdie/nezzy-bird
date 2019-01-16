using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace NezzyBird.Components
{
    public class Bird : Component
    {
        private readonly Texture2D _texture;

        public Bird(Texture2D texture)
        {
            _texture = texture;
        }

        public override void onAddedToEntity()
        {
            base.onAddedToEntity();

            this.addComponent(new Sprite(_texture));
        }
    }
}
