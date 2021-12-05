using NowakArtur97.LoopedDungeon.StateMachine;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class Stalker : CloseCombatEnemy
    {
        [SerializeField] private float _fallVelocity = 4;
        public float FallVelocity
        {
            get => _fallVelocity;
            private set => _fallVelocity = value;
        }

        public EnemySleepState EnemySleepState { get; private set; }
        public EnemyStartFallingState StartFallingState { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            EnemySleepState = new EnemySleepState(this, "sleep");
            StartFallingState = new EnemyStartFallingState(this, "startFalling");

            DefaultState = EnemySleepState;
        }
    }
}