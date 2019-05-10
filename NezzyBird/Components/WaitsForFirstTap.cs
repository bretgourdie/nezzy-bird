using Nez;

namespace NezzyBird.Components
{
    public class WaitsForFirstTap : Component
    {
        public bool HasTapped { get; private set; }

        public WaitsForFirstTap()
        {
            HasTapped = false;
        }

        public void RecordTap()
        {
            HasTapped = true;
        }
    }
}
