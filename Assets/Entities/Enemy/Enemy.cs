using NowakArtur97.LoopedDungeon.StateMachine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public abstract class Enemy : Entity
    {
        public EnemyIdleState IdleState { get; private set; }
        public EnemyMoveState MoveState { get; private set; }

        public D_EnemyEntity EnemyData { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            if (Data.GetType() == typeof(D_EnemyEntity))
            {
                EnemyData = (D_EnemyEntity)Data;
            }

            IdleState = new EnemyIdleState(this, "idle");
            MoveState = new EnemyMoveState(this, "move");
        }

        protected override void Start()
        {
            base.Start();

            StateMachine.Initialize(IdleState);
        }
    }
}
