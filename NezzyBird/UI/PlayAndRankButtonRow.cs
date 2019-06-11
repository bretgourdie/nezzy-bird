using Nez;
using Nez.TextureAtlases;
using Nez.UI;

namespace NezzyBird.UI
{
    public class PlayAndRankButtonRow<T> where T : Scene, new()
    {
        public void AddToTable(
            TextureAtlas textureAtlas,
            Table table)
        {
            var gameScale = GameConstants.GetGameScale();

            var playButton = new PlayButtonFactory<T>().Get(textureAtlas);

            var rankingButton = new RankingButtonFactory().Get(textureAtlas);

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
