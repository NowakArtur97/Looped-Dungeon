using NowakArtur97.LoopedDungeon.Core;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class RangedCombatEnemyPlayerDetectedState : EnemyPlayerDetectedState
    {
        public RangedCombatEnemyPlayerDetectedState(Enemy entity, string animationBoolName) : base(entity, animationBoolName)
        { }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!IsExitingState)
            {
                if (IsPlayerInMinAgroRange)
                {
                    if (IsCloseToWallBehind || !IsGroundedBehind)
                    {
                        Enemy.BackOffState.ShouldIgnoreClosePlayer = true;
                    }
                    else
                    {
                        Entity.CoreContainer.Movement.Flip();
                    }
                    Entity.StateMachine.ChangeState(Enemy.BackOffState);
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
