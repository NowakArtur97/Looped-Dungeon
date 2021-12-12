using NowakArtur97.LoopedDungeon.Core;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public abstract class EnemyBackOffState : EnemyGroundedState
    {
        protected bool ShouldIgnoreClosePlayer { get; private set; }
        protected bool HasEscaped { get; private set; }
        public bool ShouldStartMoving;

        public EnemyBackOffState(Enemy entity, string animationBoolName) : base(entity, animationBoolName)
        { }

        public override void Enter()
        {
            base.Enter();

            Enemy.EnemyCoreContainer.Animation.SetBattleMode(false);

            if (IsCloseToWallBehind || !IsGroundedBehind)
            {
                ShouldIgnoreClosePlayer = true;
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
                Entity.CoreContainer.Movement.SetVelocityX(Enemy.RangedCombatEnemyData.backOffVelocity * Entity.CoreContainer.Movement.FacingDirection);
            }
            if (!IsPlayerInMinAgroRange && ShouldIgnoreClosePlayer)
            {
                ShouldIgnoreClosePlayer = false;
            }

            HasEscaped = StateEnterTime + Enemy.RangedCombatEnemyData.backOffTime <= Time.time;
        }

        public override void AnimationFinishedTrigger()
        {
            base.AnimationFinishedTrigger();

            ShouldStartMoving = true;
        }
    }
}
