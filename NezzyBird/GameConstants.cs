using Microsoft.Xna.Framework;

namespace NezzyBird
{
    public static class GameConstants
    {
        public const int SPRITE_SCALE_FACTOR = 3;
        public const string GAME_NAME = "Nezzy Bird";

       public static Vector2 GetGameScale() =>
            new Vector2(SPRITE_SCALE_FACTOR, SPRITE_SCALE_FACTOR);
    }
}
