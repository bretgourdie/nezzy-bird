﻿using Microsoft.Xna.Framework;
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
            var lastSpriteName = textureAtlas.regionNames.lastItem();
            var birdIdleSprite = textureAtlas.getSubtexture(lastSpriteName);
            addComponent(new Sprite(birdIdleSprite));
            addComponent(new AffectedByGravity());
            addComponent(new JumpsOnTap());

            this.scale = new Vector2(3, 3);

            this.position = new Vector2(200, 200);
        }

        public Vector2 getBirdStart()
        {
            return new Vector2(150, 263);
        }

        public Vector2 getBirdSize()
        {
            return new Vector2(17, 12);
        }

        public Vector2 getBirdPadding()
        {
            return new Vector2(1, 1);
        }
    }
}
