using NowakArtur97.LoopedDungeon.Core;
using UnityEngine;

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
                if (IsPlayerInMinAgroRange
                    && Enemy.MeleeAttackState.StateEnterTime + Enemy.CloseCombatEnemyData.timeToWaitBeforeMeleeAttack <= Time.time)
                {
                    Entity.StateMachine.ChangeState(Enemy.MeleeAttackState);
                }
                else if (IsPlayerInMaxAgroRange
                    && Enemy.RangedAttackState.StateEnterTime + Enemy.RangedCombatEnemyData.timeToWaitBeforeRangedAttack <= Time.time)
                {
                    Entity.StateMachine.ChangeState(Enemy.RangedAttackState);
                }
                else if (!IsPlayerInMaxAgroRange)
                {
                    Entity.StateMachine.ChangeState(Enemy.LookForPlayerState);
                }
            }
        }
    }
}
