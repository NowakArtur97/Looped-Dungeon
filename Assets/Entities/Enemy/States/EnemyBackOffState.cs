using NowakArtur97.LoopedDungeon.Core;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class EnemyBackOffState : EnemyGroundedState
    {
        private RangedCombatEnemy _rangedCombatEnemy;
        public bool ShouldIgnoreClosePlayer;

        public EnemyBackOffState(RangedCombatEnemy entity, string animationBoolName) : base(entity, animationBoolName)
        {
            _rangedCombatEnemy = entity;
        }

        public override void LogicUpdate()
        {
            Entity.CoreContainer.Movement.SetVelocityX(_rangedCombatEnemy.BackOffVelocity * Entity.CoreContainer.Movement.FacingDirection);

            base.LogicUpdate();

            if (!IsExitingState)
            {
                if (!IsPlayerInMinAgroRange && ShouldIgnoreClosePlayer)
                {
                    ShouldIgnoreClosePlayer = false;
                }

                if (IsPlayerInMaxAgroRange && !IsPlayerInMinAgroRange && !ShouldIgnoreClosePlayer)
                {
                    Entity.StateMachine.ChangeState(Enemy.PlayerDetectedState);
                }
                else if (!IsGrounded || IsCloseToWall || StateEnterTime + _rangedCombatEnemy.BackOffTime <= Time.time)
                {
                    Entity.CoreContainer.Movement.Flip();
                    Entity.StateMachine.ChangeState(Enemy.LookForPlayerState);
                }
            }
        }
    }
}
