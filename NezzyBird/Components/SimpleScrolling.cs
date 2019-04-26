using Nez.Systems;
using NezzyBird.Systems;

namespace NezzyBird.Components
{
    public class SimpleScrolling : Scrolling
    {
        private readonly Emitter<NezzyEvents> _emitter;

        public SimpleScrolling(
            ScrollDirection scrollDirection,
            float rate,
            Emitter<NezzyEvents> emitter) : base(scrollDirection, rate)
        {
            _emitter = emitter;
        }

        public override void onAddedToEntity()
        {
            var caresAboutLife = new CaresAboutLife();
            _emitter.addObserver(NezzyEvents.BirdDied, caresAboutLife.OnDeath);
            entity.addComponent(caresAboutLife);
        }
    }
}
