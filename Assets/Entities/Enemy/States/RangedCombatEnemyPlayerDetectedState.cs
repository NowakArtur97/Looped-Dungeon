using NowakArtur97.LoopedDungeon.Core;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class RangedCombatEnemyPlayerDetectedState : EnemyPlayerDetectedState
    {
        private RangedCombatEnemy _rangedCombatEnemy;

        public RangedCombatEnemyPlayerDetectedState(RangedCombatEnemy entity, string animationBoolName) : base(entity, animationBoolName)
        {
            _rangedCombatEnemy = entity;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!IsExitingState)
            {
                if (IsPlayerInMinAgroRange)
                {
                    if (IsCloseToWallBehind || !IsGroundedBehind)
                    {
                        Debug.Log(!IsGroundedBehind);
                        _rangedCombatEnemy.BackOffState.ShouldIgnoreClosePlayer = true;
                    }
                    else
                    {
                        Entity.CoreContainer.Movement.Flip();
                    }
                    Entity.StateMachine.ChangeState(_rangedCombatEnemy.BackOffState);
                }
                else if (IsPlayerInMaxAgroRange)
                {
                    Entity.StateMachine.ChangeState(_rangedCombatEnemy.RangedAttackState);
                }
                else if (!IsPlayerInMaxAgroRange)
                {
                    Entity.StateMachine.ChangeState(Enemy.LookForPlayerState);
                }
            }
        }
    }
}
