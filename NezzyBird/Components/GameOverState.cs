using Nez;
using NezzyBird.Entities;
using System.Collections.Generic;

namespace NezzyBird.Components
{
    public class GameOverState : Component, IUpdatable
    {
        private int _currentEntityIndex;
        private readonly IList<Entity> _childEntities;

        public GameOverState(IList<Entity> childEntities)
        {
            _childEntities = childEntities;
        }

        public override void onAddedToEntity()
        {
            foreach (var childEntity in _childEntities)
            {
                childEntity.setEnabled(false);
                entity.scene.addEntity(childEntity);
            }
        }

        public void update() => _childEntities[_currentEntityIndex].update();

        public Entity CurrentEntity => _childEntities[_currentEntityIndex];

        public void AdvanceToNextEntity() => _currentEntityIndex++;

        public bool CurrentEntityIsComplete => !_childEntities[_currentEntityIndex].enabled;
    }
}
