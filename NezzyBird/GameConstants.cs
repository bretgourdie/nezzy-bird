using Microsoft.Xna.Framework;

namespace NezzyBird
{
    public static class GameConstants
    {
        public const int SPRITE_SCALE_FACTOR = 3;
        public const string GAME_NAME = "Nezzy Bird";
        public const int SOURCE_SCREEN_WIDTH = 144;
        public const int SOURCE_SCREEN_HEIGHT = 256;

        public const int SCREEN_WIDTH = SOURCE_SCREEN_WIDTH * SPRITE_SCALE_FACTOR;
        public const int SCREEN_HEIGHT = SOURCE_SCREEN_HEIGHT * SPRITE_SCALE_FACTOR;

        public const float PIPE_SCROLL_SPEED = 1f;

        public static Vector2 GetGameScale() =>
            new Vector2(SPRITE_SCALE_FACTOR, SPRITE_SCALE_FACTOR);

        public static Vector2 GetScreenBounds() =>
            new Vector2(
                SCREEN_WIDTH,
                SCREEN_HEIGHT);

        public static class RenderingLevels
        {
            public const int Background = 100;
            public const int Foreground = 50;
            public const int Pipes = 75;
            public const int Bird = 25;
            public const int HUD = 1;
        }
    }
}
