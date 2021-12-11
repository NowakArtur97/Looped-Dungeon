using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class EnemyHurtState : HurtState
    {
        private Enemy _enemy;
        private bool _isPlayerInMaxAgroRange;

        public EnemyHurtState(Enemy entity, string animationBoolName) : base(entity, animationBoolName)
        {
            _enemy = entity;
        }

        public override void DoChecks()
        {
            base.DoChecks();

            _isPlayerInMaxAgroRange = _enemy.EnemyCoreContainer.EnemySenses.IsPlayerInAgroRange(_enemy.EnemyData.maxAgroRange);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!IsExitingState && IsAnimationFinished)
            {
                if (_isPlayerInMaxAgroRange)
                {
                    Entity.StateMachine.ChangeState(_enemy.PlayerDetectedState);
                }
                else
                {
                    Entity.StateMachine.ChangeState(_enemy.LookForPlayerState);
                }
            }
        }
    }
}
