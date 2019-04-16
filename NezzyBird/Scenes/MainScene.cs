﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Nez;
using Nez.TextureAtlases;
using NezzyBird.Components;
using NezzyBird.Entities;
using NezzyBird.Systems;

namespace NezzyBird.Scenes
{
    public class MainScene : Scene
    {
        public MainScene(ContentManager content)
        {
            var textureAtlas = content.Load<TextureAtlas>("Textures/TextureAtlas");

            var background = new Background(textureAtlas);
            var foreground = new Foreground(textureAtlas);

            var hasScore = new HasScore();
            var bird = new Bird(textureAtlas, hasScore);
            var scoreDisplay = new ScoreDisplay(textureAtlas, hasScore);

            this.addEntity(background);
            this.addEntity(foreground);
            this.addEntity(bird);
            this.addEntity(scoreDisplay);

            var renderer = new DefaultRenderer { renderTargetClearColor = Color.CornflowerBlue };

            this.addRenderer(new DefaultRenderer());

            this.addEntityProcessor(new GravitySystem());
            this.addEntityProcessor(new BirdSpriteRotationSystem());
            this.addEntityProcessor(new ScrollingSystem());
            this.addEntityProcessor(new ActionOnIntervalSystem());
            this.addEntityProcessor(new JumpSystem());
            this.addEntityProcessor(new ScoreZoneCollisionSystem());
            this.addEntityProcessor(new ScoreDisplaySystem(textureAtlas));

            addEntity(new PipePairSpawner(textureAtlas));
            Nez.Core.debugRenderEnabled = true;
        }
    }
}
