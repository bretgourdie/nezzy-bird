using Nez;

namespace NezzyBird.Components
{
    public class FadesOnFirstJump : Component
    {
        public readonly Fades FirstJumpFade;

        public FadesOnFirstJump(Fades fade)
        {
            FirstJumpFade = fade;
        }
    }
}
