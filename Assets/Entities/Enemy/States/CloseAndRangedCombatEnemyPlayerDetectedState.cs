using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class CloseAndRangedCombatEnemyPlayerDetectedState : EnemyPlayerDetectedState
    {
        public CloseAndRangedCombatEnemyPlayerDetectedState(Enemy entity, string animationBoolName) : base(entity, animationBoolName)
        { }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!IsExitingState)
            {
                if (IsPlayerInMinAgroRange)
                {
                    Entity.StateMachine.ChangeState(Enemy.MeleeAttackState);
                }
                else if (IsPlayerInMaxAgroRange)
                {
                    Entity.StateMachine.ChangeState(Enemy.RangedAttackState);
                }
                else
                {
                    Entity.StateMachine.ChangeState(Enemy.LookForPlayerState);
                }
            }
        }
    }
}
