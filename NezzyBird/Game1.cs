using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

            var bird = new Bird(textureAtlas);
            scene.addEntity(bird);

            Core.scene = scene;
        }

    }
}
