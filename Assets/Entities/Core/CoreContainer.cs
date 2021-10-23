namespace NowakArtur97.LoopedDungeon.Core
{
    public class CoreContainer : BaseCore
    {
        private AnimationToStateMachine _animationToStateMachine;

        public AnimationToStateMachine AnimationToStateMachine
        {
            get => GenericNotImplementedError<AnimationToStateMachine>.TryGet(_animationToStateMachine, transform.parent.name);
            private set => _animationToStateMachine = value;
        }

        private Input _input;

        public Input Input
        {
            get => GenericNotImplementedError<Input>.TryGet(_input, transform.parent.name);
            private set => _input = value;
        }

        private Inventory _inventory;

        public Inventory Inventory
        {
            get => GenericNotImplementedError<Inventory>.TryGet(_inventory, transform.parent.name);
            private set => _inventory = value;
        }

        protected override void Awake()
        {
            base.Awake();

            Input = GetComponentInChildren<Input>();
            AnimationToStateMachine = GetComponentInChildren<AnimationToStateMachine>();
            Inventory = GetComponentInChildren<Inventory>();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            Input?.LogicUpdate();
            Inventory?.LogicUpdate();
        }
    }
}
