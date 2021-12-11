using NowakArtur97.LoopedDungeon.StateMachine;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public abstract class Entity : MonoBehaviour
    {
        [SerializeField] private D_Entity _data;
        public D_Entity Data
        {
            get => _data;
            private set => _data = value;
        }

        public DeadState DeadState { get; private set; }

        public BaseCoreContainer CoreContainer { get; private set; }
        public FiniteStateMachine StateMachine { get; private set; }
        public EntityStats EntityStats { get; private set; }

        protected virtual void Awake()
        {
            CoreContainer = GetComponentInChildren<BaseCoreContainer>();

            StateMachine = new FiniteStateMachine();
            EntityStats = new EntityStats(_data);

            DeadState = new DeadState(this, "dead");
        }

        protected virtual void Start() => CoreContainer.Combat.InitEntityStats(EntityStats);

        private void Update()
        {
            CoreContainer.LogicUpdate();
            StateMachine.CurrentState.LogicUpdate();
        }

        private void FixedUpdate() => StateMachine.CurrentState.PhysicsUpdate();
    }
}
