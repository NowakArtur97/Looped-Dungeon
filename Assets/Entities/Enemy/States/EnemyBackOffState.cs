using NowakArtur97.LoopedDungeon.Core;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class EnemyBackOffState : EnemyGroundedState
    {
        private bool _shouldIgnoreClosePlayer;
        private bool _hasEscaped;
        public bool ShouldStartMoving;

        public EnemyBackOffState(Enemy entity, string animationBoolName) : base(entity, animationBoolName)
        { }

        public override void Enter()
        {
            base.Enter();

            Enemy.EnemyCoreContainer.Animation.SetBattleMode(false);

            if (IsCloseToWallBehind || !IsGroundedBehind)
            {
                _shouldIgnoreClosePlayer = true;
            }
            else
            {
                Entity.CoreContainer.Movement.Flip();
            }
        }

        public override void Exit()
        {
            base.Exit();

            _shouldIgnoreClosePlayer = false;
            ShouldStartMoving = false;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (ShouldStartMoving)
            {
                Entity.CoreContainer.Movement.SetVelocityX(Enemy.RangedCombatEnemyData.backOffVelocity * Entity.CoreContainer.Movement.FacingDirection);
            }

            _hasEscaped = StateEnterTime + Enemy.RangedCombatEnemyData.backOffTime <= Time.time;

            if (!IsExitingState)
            {
                if (!IsPlayerInMinAgroRange && _shouldIgnoreClosePlayer)
                {
                    _shouldIgnoreClosePlayer = false;
                }

                if (IsPlayerInMaxAgroRange && !IsPlayerInMinAgroRange && !_shouldIgnoreClosePlayer && _hasEscaped)
                {
                    Entity.StateMachine.ChangeState(Enemy.PlayerDetectedState);
                }
                else if (!IsGrounded || IsCloseToWall || _hasEscaped)
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
