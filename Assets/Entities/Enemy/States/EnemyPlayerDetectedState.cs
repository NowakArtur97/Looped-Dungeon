using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class EnemyPlayerDetectedState : EnemyGroundedState
    {
        private Enemy _enemy;

        public EnemyPlayerDetectedState(Enemy entity, string animationBoolName) : base(entity, animationBoolName)
        {
            _enemy = entity;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!IsExitingState)
            {
                if (!IsPlayerInMaxAgro || !IsPlayerInMinAgro)
                {
                    // TODO: EnemyPlayerDetectedState: Look for Player State
                    _enemy.StateMachine.ChangeState(_enemy.IdleState);
                }
            }
        }
    }
}
