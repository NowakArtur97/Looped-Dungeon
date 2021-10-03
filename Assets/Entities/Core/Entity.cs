using NowakArtur97.LoopedDungeon.StateMachine;
using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.Core
{
    public class Entity : MonoBehaviour
    {
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
