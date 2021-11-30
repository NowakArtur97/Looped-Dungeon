using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class EnemyGroundedState : GroundedState
    {
        protected Enemy Enemy { get; private set; }
        protected bool IsPlayerInMinAgro { get; private set; }
        protected bool IsPlayerInMaxAgro { get; private set; }

        public EnemyGroundedState(Enemy entity, string animationBoolName) : base(entity, animationBoolName)
        {
            Enemy = entity;
        }

        public override void DoChecks()
        {
            base.DoChecks();

            IsPlayerInMinAgro = Enemy.EnemyCoreContainer.EnemySenses.IsPlayerInAgroRange(Enemy.EnemyData.minAgroRange);
            IsPlayerInMaxAgro = Enemy.EnemyCoreContainer.EnemySenses.IsPlayerInAgroRange(Enemy.EnemyData.maxAgroRange);
        }
    }
}
