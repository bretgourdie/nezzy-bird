﻿using Microsoft.Xna.Framework;
using Nez;
using Nez.TextureAtlases;
using NezzyBird.Entities;

namespace NezzyBird
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Nez.Core
    {
        public Game1() : base(
            width: (int)GameConstants.GetScreenBounds().X,
            height: (int)GameConstants.GetScreenBounds().Y,
            windowTitle: GameConstants.GAME_NAME) { }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            var scene = Scene.createWithDefaultRenderer(Color.CornflowerBlue);

            var textureAtlas = Content.Load<TextureAtlas>("Textures/TextureAtlas");

            var background = new Background(textureAtlas);
            var bird = new Bird(textureAtlas);

            scene.addEntity(background);
            scene.addEntity(bird);

            Core.scene = scene;
        }

    }
}
