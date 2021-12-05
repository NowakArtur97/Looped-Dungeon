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
        public EnemyFallState FallState { get; private set; }
        public EnemyLandState LandState { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            EnemySleepState = new EnemySleepState(this, "sleep");
            StartFallingState = new EnemyStartFallingState(this, "startFalling");
            FallState = new EnemyFallState(this, "fall");
            LandState = new EnemyLandState(this, "land");

            DefaultState = EnemySleepState;
        }
    }
}