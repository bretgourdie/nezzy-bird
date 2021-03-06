﻿using Nez;
using Nez.Systems;
using Nez.TextureAtlases;
using Nez.UI;
using NezzyBird.Scenes;
using NezzyBird.Systems;
using NezzyBird.UI;

namespace NezzyBird.Entities
{
    public class GameOverMenu : Entity, IGameOverState
    {
        public GameOverMenu(
            TextureAtlas textureAtlas,
            Emitter<NezzyEvents> emitter)
        {
            var gameScale = GameConstants.GetGameScale();

            var canvas = new UICanvas();

            var stage = canvas.stage;

            var table = stage.addElement(new Table()).setFillParent(true);
            table.padTop(GameConstants.SCREEN_HEIGHT * 3 / 4);

            new PlayAndRankButtonRow<TitleScene>().AddToTable(textureAtlas, table, emitter);

            this.addComponent(canvas);

            this.name = this.GetType().Name;
        }

        public Entity Get()
        {
            return this;
        }

        public bool IsFinished()
        {
            return false;
        }

        public bool RemoveAfterFinished()
        {
            return false;
        }
    }
}
