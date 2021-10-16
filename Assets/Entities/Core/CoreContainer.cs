namespace NowakArtur97.LoopedDungeon.Core
{
    public class CoreContainer : BaseCore
    {
        private Movement _movement;

        public Movement Movement
        {
            get => GenericNotImplementedError<Movement>.TryGet(_movement, transform.parent.name);
            private set => _movement = value;
        }

        private CollisionSenses _collisionSenses;

        public CollisionSenses CollisionSenses
        {
            get => GenericNotImplementedError<CollisionSenses>.TryGet(_collisionSenses, transform.parent.name);
            private set => _collisionSenses = value;
        }

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

            Movement = GetComponentInChildren<Movement>();
            CollisionSenses = GetComponentInChildren<CollisionSenses>();
            Input = GetComponentInChildren<Input>();
            AnimationToStateMachine = GetComponentInChildren<AnimationToStateMachine>();
            Inventory = GetComponentInChildren<Inventory>();
        }

        public void LogicUpdate()
        {
            Movement.LogicUpdate();
            Input?.LogicUpdate();
        }
    }
}
