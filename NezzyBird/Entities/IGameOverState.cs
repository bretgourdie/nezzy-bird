using Nez;

namespace NezzyBird.Entities
{
    public interface IGameOverState : IUpdatable
    {
        bool IsFinished();
        bool RemoveAfterFinished();
        Entity Get();
    }
}
