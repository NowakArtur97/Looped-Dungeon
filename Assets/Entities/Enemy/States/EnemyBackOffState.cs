using NowakArtur97.LoopedDungeon.Core;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class EnemyBackOffState : EnemyGroundedState
    {
        private RangedCombatEnemy _rangedCombatEnemy;
        public bool ShouldIgnoreClosePlayer;
        public bool ShouldStartMoving;

        public EnemyBackOffState(RangedCombatEnemy entity, string animationBoolName) : base(entity, animationBoolName)
        {
            _rangedCombatEnemy = entity;
        }

        public override void Enter()
        {
            base.Enter();

            Enemy.EnemyCoreContainer.Animation.SetBattleMode(false);

            if (IsCloseToWallBehind || !IsGroundedBehind)
            {
                Enemy.BackOffState.ShouldIgnoreClosePlayer = true;
            }
            else
            {
                Entity.CoreContainer.Movement.Flip();
            }
        }

        public override void Exit()
        {
            base.Exit();

            ShouldIgnoreClosePlayer = false;
            ShouldStartMoving = false;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (ShouldStartMoving)
            {
                Entity.CoreContainer.Movement.SetVelocityX(_rangedCombatEnemy.RangedCombatEnemyData.backOffVelocity * Entity.CoreContainer.Movement.FacingDirection);
            }

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
                else if (!IsGrounded || IsCloseToWall || StateEnterTime + _rangedCombatEnemy.RangedCombatEnemyData.backOffTime <= Time.time)
                {
                    Entity.CoreContainer.Movement.Flip();
                    Entity.StateMachine.ChangeState(Enemy.LookForPlayerState);
                }
            }
        }

        public override void AnimationFinishedTrigger()
        {
            base.AnimationFinishedTrigger();

            ShouldStartMoving = true;
        }
    }
}
