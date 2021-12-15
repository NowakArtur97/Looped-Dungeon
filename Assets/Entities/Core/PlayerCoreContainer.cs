using NowakArtur97.LoopedDungeon.Util;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class PlayerCoreContainer : BaseCoreContainer
    {
        private Input _input;

        public Input Input
        {
            get => GenericUtil<Input>.GetOrDefault(_input, transform.parent.name);
            private set => _input = value;
        }

        protected override void Awake()
        {
            base.Awake();

            Input = GetComponentInChildren<Input>();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            Input?.PhysicsUpdate();
        }
    }
}
