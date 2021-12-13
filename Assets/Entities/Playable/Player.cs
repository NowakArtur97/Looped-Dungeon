using NowakArtur97.LoopedDungeon.StateMachine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public abstract class Player : Entity
    {
        public PlayerIdleState IdleState { get; private set; }
        public PlayerMoveState MoveState { get; private set; }
        public PlayerJumpState JumpState { get; private set; }
        public PlayerInAirState InAirState { get; private set; }
        public PlayerLandState LandState { get; private set; }
        public PlayerAbilityState MainAbilityState { get; protected set; }
        public PlayerAbilityState SecondaryAbilityState { get; protected set; }
        public PlayerThrowState ThrowState { get; protected set; }

        public PlayerCoreContainer PlayerCoreContainer { get; private set; }
        public D_PlayerEntity PlayerData { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            if (CoreContainer.GetType() == typeof(PlayerCoreContainer))
            {
                PlayerCoreContainer = (PlayerCoreContainer)CoreContainer;
            }
            if (Data.GetType() == typeof(D_PlayerEntity))
            {
                PlayerData = (D_PlayerEntity)Data;
            }

            IdleState = new PlayerIdleState(this, "idle");
            MoveState = new PlayerMoveState(this, "move");
            JumpState = new PlayerJumpState(this, "inAir");
            InAirState = new PlayerInAirState(this, "inAir");
            LandState = new PlayerLandState(this, "land");
            HurtState = new PlayerHurtState(this, "hurt");
        }

        protected override void Start()
        {
            base.Start();

            StateMachine.Initialize(IdleState);
        }
    }
}
