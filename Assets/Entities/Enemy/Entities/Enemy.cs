using NowakArtur97.LoopedDungeon.StateMachine;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public abstract class Enemy : Entity
    {
        public State DefaultState { get; protected set; }
        public EnemyIdleState IdleState { get; private set; }
        public EnemyMoveState MoveState { get; private set; }
        public EnemyPlayerDetectedState PlayerDetectedState { get; protected set; }
        public EnemyLookForPlayerState LookForPlayerState { get; private set; }

        public EnemyCoreContainer EnemyCoreContainer { get; private set; }
        public D_EnemyEntity EnemyData { get; private set; }

        public AnimationToAttackStateMachine AnimationToAttackStateMachine { get; private set; }
        public HitboxesToEnemyAttackState HitboxesToEnemyAttackState { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            if (CoreContainer.GetType() == typeof(EnemyCoreContainer))
            {
                EnemyCoreContainer = (EnemyCoreContainer)CoreContainer;
            }
            if (Data.GetType() == typeof(D_EnemyEntity))
            {
                EnemyData = (D_EnemyEntity)Data;
            }

            IdleState = new EnemyIdleState(this, "idle");
            MoveState = new EnemyMoveState(this, "move");
            LookForPlayerState = new EnemyLookForPlayerState(this, "lookForPlayer");

            DefaultState = IdleState;
        }

        protected override void Start()
        {
            base.Start();

            HitboxesToEnemyAttackState = GetComponentInChildren<HitboxesToEnemyAttackState>();
            AnimationToAttackStateMachine = GetComponentInChildren<AnimationToAttackStateMachine>();

            StateMachine.Initialize(DefaultState);
        }

        public virtual void OnTriggerEnter2D(Collider2D collision) { }

        public virtual void OnTriggerExit2D(Collider2D collision) { }
    }
}
