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

        public const float FOREGROUND_SCROLL_SPEED = 2f;

        public static Vector2 GetGameScale() =>
            new Vector2(SPRITE_SCALE_FACTOR, SPRITE_SCALE_FACTOR);

        public static Vector2 GetScreenBounds() =>
            new Vector2(
                SCREEN_WIDTH,
                SCREEN_HEIGHT);

        public static class RenderingLevels
        {
            public const int Background = 100;
            public const int Pipe = 90;
            public const int Foreground = 80;
            public const int Bird = 70;
            public const int MedalBoard = 60;
            public const int Number = 50;
            public const int Medal = 40;
            public const int Sparkle = 30;
            public const int Graphic = 20;
            public const int Flash = 10;
        }
    }
}
