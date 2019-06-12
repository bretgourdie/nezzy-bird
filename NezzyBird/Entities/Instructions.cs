﻿using Microsoft.Xna.Framework;
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

            addComponent(sprite);
            addComponent(new FadesOut());

            this.position = new Vector2(
                GameConstants.SCREEN_WIDTH / 2,
                GameConstants.SCREEN_HEIGHT / 2);
        }
    }
}