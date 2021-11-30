using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class EnemyIdleState : EnemyGroundedState
    {
        private int _currentNumberOfIdleCycles;

        public EnemyIdleState(Enemy entity, string animationBoolName) : base(entity, animationBoolName)
        { }

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
                if (IsPlayerInMaxAgroRange)
                {
                    Entity.StateMachine.ChangeState(Enemy.PlayerDetectedState);
                }
                else if (_currentNumberOfIdleCycles >= Enemy.EnemyData.numberOfIdleCycles)
                {
                    Entity.CoreContainer.Movement.Flip();
                    Entity.StateMachine.ChangeState(Enemy.MoveState);
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

