using Nez;
using NezzyBird.Entities;
using System.Collections.Generic;

namespace NezzyBird.Components
{
    public class GameOverState : Component, IUpdatable
    {
        private int _currentEntityIndex;
        private readonly IList<IGameOverState> _childEntities;

        public GameOverState(IList<IGameOverState> childEntities)
        {
            _childEntities = childEntities;
        }

        public override void onAddedToEntity()
        {
            foreach (var childEntity in _childEntities)
            {
                childEntity.Get().setEnabled(false);
                entity.scene.addEntity(childEntity.Get());
            }

            if (_childEntities.Count > 0)
            {
                _childEntities[0].Get().setEnabled(true);
            }
        }

        public void update() => _childEntities[_currentEntityIndex].update();

        public Entity CurrentEntity => _childEntities[_currentEntityIndex].Get();

        public void AdvanceToNextEntity()
        {
            _currentEntityIndex++;
            CurrentEntity.setEnabled(true);
        }

        public bool CurrentEntityIsComplete => _childEntities[_currentEntityIndex].IsFinished();

        public bool RemoveEntityAfterFinished => _childEntities[_currentEntityIndex].RemoveAfterFinished();
    }
}
