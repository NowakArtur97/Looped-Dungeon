using NowakArtur97.LoopedDungeon.Core;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class CloseCombatBackingOffEnemyPlayerDetectedState : EnemyPlayerDetectedState
    {
        public CloseCombatBackingOffEnemyPlayerDetectedState(Enemy entity, string animationBoolName) : base(entity, animationBoolName)
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
                else if (IsPlayerInMinAgroRange)
                {
                    Entity.StateMachine.ChangeState(Enemy.BackOffState);
                }
                else if (!IsPlayerInMaxAgroRange)
                {
                    Entity.StateMachine.ChangeState(Enemy.LookForPlayerState);
                }
            }
        }
    }
}
