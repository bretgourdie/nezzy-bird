﻿using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using Nez.TextureAtlases;
using NezzyBird.Components;

namespace NezzyBird.Entities
{
    public class Bird : Entity
    {
        public static readonly float GRAVITY_WEIGHT = 0.25f;
        public static readonly float JUMP_HEIGHT = 4.5f;

        public Bird(TextureAtlas textureAtlas)
        {
            var randomBirdIndex = Random.choose(0, 1, 2);
            var birdFlapAnimation = textureAtlas.getSpriteAnimation($"Bird{randomBirdIndex}");
            var birdIdleSprite = birdFlapAnimation.frames.lastItem();
            addComponent(new Sprite(birdIdleSprite));
            addComponent(new AffectedByGravity(GRAVITY_WEIGHT));
            addComponent(new JumpsOnTap(JUMP_HEIGHT));
            addComponent(new Mover());
            addComponent(new HasVelocity());

            this.scale = GameConstants.GetGameScale();

            this.position = new Vector2(125, 400);
        }
    }
}
