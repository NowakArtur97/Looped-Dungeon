using NowakArtur97.LoopedDungeon.StateMachine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class Player : Entity
    {
        public PlayerIdleState IdleState { get; private set; }
        public PlayerMoveState MoveState { get; private set; }
        public PlayerJumpState JumpState { get; private set; }
        public PlayerInAirState InAirState { get; private set; }
        public PlayerLandState LandState { get; private set; }
        public PlayerAttackState AttackState { get; private set; } // TODO: Change to MainAbilityState based on Character

        protected override void Awake()
        {
            base.Awake();

            IdleState = new PlayerIdleState(this, "idle");
            MoveState = new PlayerMoveState(this, "move");
            JumpState = new PlayerJumpState(this, "inAir");
            InAirState = new PlayerInAirState(this, "inAir");
            LandState = new PlayerLandState(this, "land");
            AttackState = new PlayerAttackState(this, "ability");
        }

        private void Start() => StateMachine.Initialize(IdleState);
    }
}
