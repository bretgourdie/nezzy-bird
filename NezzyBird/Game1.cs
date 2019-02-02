using Nez;
using NezzyBird.Scenes;

namespace NezzyBird
{
    public class Game1 : Nez.Core
    {
        public Game1() : base(
            width: (int)GameConstants.GetScreenBounds().X,
            height: (int)GameConstants.GetScreenBounds().Y,
            windowTitle: GameConstants.GAME_NAME) { }

        protected override void Initialize()
        {
            base.Initialize();

            var mainScene = new MainScene(Content);

            Core.scene = mainScene;
        }

    }
}
