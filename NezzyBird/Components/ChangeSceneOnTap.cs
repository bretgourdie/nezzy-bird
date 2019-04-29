using Nez;
using System;

namespace NezzyBird.Components
{
    public class ChangeSceneOnTap : Component
    {
        public bool IsRequestingSceneChange { get; private set; }

        private readonly Scene _transitionToScene;

        public ChangeSceneOnTap(Scene transitionToScene)
        {
            _transitionToScene = transitionToScene;
        }

        public void RequestSceneChange(bool request)
        {
            IsRequestingSceneChange = request;
        }
    }
}
