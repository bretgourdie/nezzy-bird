using Microsoft.Xna.Framework;

namespace NezzyBird
{
    public static class GameConstants
    {
        public const int SPRITE_SCALE_FACTOR = 3;
        public const string GAME_NAME = "Nezzy Bird";
        public const int SOURCE_SCREEN_WIDTH = 144;
        public const int SOURCE_SCREEN_HEIGHT = 256;

       public static Vector2 GetGameScale() =>
            new Vector2(SPRITE_SCALE_FACTOR, SPRITE_SCALE_FACTOR);

        public static Vector2 GetScreenBounds() =>
            new Vector2(
                SOURCE_SCREEN_WIDTH * SPRITE_SCALE_FACTOR,
                SOURCE_SCREEN_HEIGHT * SPRITE_SCALE_FACTOR);
    }
}
