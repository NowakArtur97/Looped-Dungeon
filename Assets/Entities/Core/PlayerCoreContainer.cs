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

        private InputRecored _inputRecored;

        public InputRecored InputRecored
        {
            get => GenericUtil<InputRecored>.GetOrDefault(_inputRecored, transform.parent.name);
            private set => _inputRecored = value;
        }

        private InputReplayer _inputReplayer;

        public InputReplayer InputReplayer
        {
            get => GenericUtil<InputReplayer>.GetOrDefault(_inputReplayer, transform.parent.name);
            private set => _inputReplayer = value;
        }

        protected override void Awake()
        {
            base.Awake();

            Input = GetComponentInChildren<Input>();
            InputRecored = GetComponentInChildren<InputRecored>();
            InputReplayer = GetComponentInChildren<InputReplayer>();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            Input?.PhysicsUpdate();
            InputRecored?.PhysicsUpdate();
            InputReplayer?.PhysicsUpdate();
        }
    }
}
