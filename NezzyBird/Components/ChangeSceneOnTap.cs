using Nez;

namespace NezzyBird.Components
{
    public class ChangeSceneOnTap : Component
    {
        public readonly Scene TransitionToScene;

        public bool IsRequestingSceneChange { get; private set; }

        public ChangeSceneOnTap(Scene transitionToScene)
        {
            TransitionToScene = transitionToScene;
        }

        public void RequestSceneChange(bool request)
        {
            IsRequestingSceneChange = request;
        }
    }
}
