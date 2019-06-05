using Nez;
using Nez.TextureAtlases;
using Nez.UI;
using NezzyBird.Scenes;

namespace NezzyBird.UI
{
    public class PlayAndRankButtonRow
    {
        public static void AddToTable(
            TextureAtlas textureAtlas,
            Table table)
        {
            var gameScale = GameConstants.GetGameScale();

            var playButton = PlayButtonFactory.Get(textureAtlas);
            playButton.onClicked += PlayButton_onClicked;

            var rankingButton = RankingButtonFactory.Get(textureAtlas);
            rankingButton.onClicked += RankingButton_onClicked;

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

        private static void RankingButton_onClicked(Button obj)
        {
            throw new System.NotImplementedException();
        }

        private static void PlayButton_onClicked(Button obj)
        {
            Core.startSceneTransition(new FadeTransition(() => new MainScene()));
        }
    }
}
