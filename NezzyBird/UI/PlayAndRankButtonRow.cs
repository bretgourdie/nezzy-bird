using Nez;
using Nez.Systems;
using Nez.TextureAtlases;
using Nez.UI;
using NezzyBird.Systems;

namespace NezzyBird.UI
{
    public class PlayAndRankButtonRow<T> where T : Scene, new()
    {
        public void AddToTable(
            TextureAtlas textureAtlas,
            Table table,
            Emitter<NezzyEvents> emitter)
        {
            var gameScale = GameConstants.GetGameScale();

            var playButton = new PlayButtonFactory<T>(emitter).Get(textureAtlas);

            var rankingButton = new RankingButtonFactory(emitter).Get(textureAtlas);

            playButton.gamepadRightElement = rankingButton;
            rankingButton.gamepadLeftElement = playButton;

            const int actionButtonMiddlePad = 10;
            const int actionButtonBottomPad = 100;

            table.add(playButton)
                .setMinWidth(playButton.getWidth() * gameScale.X)
                .setMinHeight(playButton.getHeight() * gameScale.Y)
                .setPadRight(actionButtonMiddlePad)
                .setPadBottom(actionButtonBottomPad);
            table.add(rankingButton)
                .setMinWidth(rankingButton.getWidth() * gameScale.X)
                .setMinHeight(rankingButton.getHeight() * gameScale.Y)
                .setPadLeft(actionButtonMiddlePad)
                .setPadBottom(actionButtonBottomPad);
        }
    }
}
