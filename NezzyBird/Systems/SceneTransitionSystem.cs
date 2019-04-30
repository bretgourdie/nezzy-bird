using Nez;
using Nez.Systems;
using NezzyBird.Components;

namespace NezzyBird.Systems
{
    public class SceneTransitionSystem : EntityProcessingSystem
    {

        public SceneTransitionSystem() : base(
            new Matcher().all(typeof(ChangeSceneOnTap)))
        { }

        public override void process(Entity entity)
        {
            var changeSceneOnTap = entity.getComponent<ChangeSceneOnTap>();

            if (changeSceneOnTap.IsRequestingSceneChange)
            {
                var theNextScene = changeSceneOnTap.TheNextScene;
                Core.startSceneTransition(new FadeTransition(theNextScene));
            }
        }
    }
}
