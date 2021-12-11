using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public abstract class EnemyAttackState : AbilityState
    {
        protected Enemy Enemy { get; private set; }
        protected bool IsPlayerInMaxAgroRange { get; private set; }

        public EnemyAttackState(Enemy entity, string animationBoolName) : base(entity, animationBoolName)
        {
            Enemy = entity;
        }

        public override void Enter()
        {
            base.Enter();

            Enemy.AnimationToAttackStateMachine.EnemyAttackState = this;

            Entity.CoreContainer.Movement.SetVelocityZero();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (IsAbilityFinished && !IsExitingState)
            {
                if (IsPlayerInMaxAgroRange)
                {
                    Entity.StateMachine.ChangeState(Enemy.PlayerDetectedState);
                }
                else
                {
                    Entity.StateMachine.ChangeState(Enemy.LookForPlayerState);
                }
            }
        }

        public override void DoChecks()
        {
            base.DoChecks();

            IsPlayerInMaxAgroRange = Enemy.EnemyCoreContainer.EnemySenses.IsPlayerInAgroRange(Enemy.EnemyData.maxAgroRange);
        }

        public abstract void TriggerAttack();

        public override void AnimationFinishedTrigger()
        {
            base.AnimationFinishedTrigger();

            IsAbilityFinished = true;
        }
    }
}
