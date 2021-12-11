using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public abstract class EnemyGroundedState : GroundedState
    {
        protected Enemy Enemy { get; private set; }
        protected bool IsPlayerInMinAgroRange { get; private set; }
        protected bool IsPlayerInMaxAgroRange { get; private set; }

        public EnemyGroundedState(Enemy entity, string animationBoolName) : base(entity, animationBoolName)
        {
            Enemy = entity;
        }

        public override void DoChecks()
        {
            base.DoChecks();

            IsPlayerInMinAgroRange = Enemy.EnemyCoreContainer.EnemySenses.IsPlayerInAgroRange(Enemy.EnemyData.minAgroRange);
            IsPlayerInMaxAgroRange = Enemy.EnemyCoreContainer.EnemySenses.IsPlayerInAgroRange(Enemy.EnemyData.maxAgroRange);
        }
    }
}
