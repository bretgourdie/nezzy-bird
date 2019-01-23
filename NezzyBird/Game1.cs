using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using NezzyBird.Components;

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

            var birdTexture = this.Content.Load<Texture2D>("Textures/birdflap1");
            var bird = new Entity();
            bird.addComponent(new AffectedByGravity());
            bird.addComponent(new JumpsOnTap());

            scene.addEntity(bird);

            Core.scene = scene;
        }

    }
}
