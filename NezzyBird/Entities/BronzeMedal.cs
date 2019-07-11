﻿using Nez;
using Nez.Sprites;
using Nez.TextureAtlases;

namespace NezzyBird.Entities
{
    public class BronzeMedal : Entity
    {
        public BronzeMedal(TextureAtlas textureAtlas)
        {
            var subtexture = textureAtlas.getSubtexture("BronzeMedal");
            addComponent(new Sprite(subtexture));

            this.scale = GameConstants.GetGameScale();

            this.name = this.GetType().Name;
        }
    }
}
