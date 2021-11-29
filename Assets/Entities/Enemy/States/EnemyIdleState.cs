using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class EnemyIdleState : EnemyGroundedState
    {
        private Enemy _enemy;
        private int _currentNumberOfIdleCycles;

        public EnemyIdleState(Enemy entity, string animationBoolName) : base(entity, animationBoolName)
        {
            _enemy = entity;
        }

        public override void Enter()
        {
            base.Enter();

            Entity.CoreContainer.Movement.SetVelocityZero();

            _currentNumberOfIdleCycles = 0;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!IsExitingState)
            {
                if (IsPlayerInMinAgro)
                {
                    Entity.StateMachine.ChangeState(_enemy.PlayerDetectedState);
                }
                if (_currentNumberOfIdleCycles >= _enemy.EnemyData.numberOfIdleCycles)
                {
                    Entity.CoreContainer.Movement.Flip();
                    Entity.StateMachine.ChangeState(_enemy.MoveState);
                }
            }
        }

        public override void AnimationFinishedTrigger()
        {
            base.AnimationFinishedTrigger();

            _currentNumberOfIdleCycles++;
        }
    }
}

