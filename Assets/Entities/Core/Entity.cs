using NowakArtur97.LoopedDungeon.StateMachine;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public abstract class Entity : MonoBehaviour
    {
        [SerializeField] private D_Entity _data;
        public D_Entity Data
        {
            get => Data;
            private set => _data = value;
        }

        public CoreContainer CoreContainer { get; private set; }
        public FiniteStateMachine StateMachine { get; private set; }

        protected virtual void Awake()
        {
            CoreContainer = GetComponentInChildren<CoreContainer>();

            StateMachine = new FiniteStateMachine();
        }

        private void Update()
        {
            CoreContainer.LogicUpdate();
            StateMachine.CurrentState.LogicUpdate();
        }

        private void FixedUpdate() => StateMachine.CurrentState.PhysicsUpdate();
    }
}
