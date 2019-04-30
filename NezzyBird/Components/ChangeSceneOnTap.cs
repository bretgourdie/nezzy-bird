using Nez;
using System;

namespace NezzyBird.Components
{
    public class ChangeSceneOnTap : Component
    {
        public readonly Func<Scene> TheNextScene;

        public bool IsRequestingSceneChange { get; private set; }

        public ChangeSceneOnTap(Func<Scene> theNextScene)
        {
            TheNextScene = theNextScene;
        }

        public void RequestSceneChange(bool request)
        {
            IsRequestingSceneChange = request;
        }
    }
}
