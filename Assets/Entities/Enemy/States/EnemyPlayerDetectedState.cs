using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public abstract class EnemyPlayerDetectedState : EnemyGroundedState
    {
        public EnemyPlayerDetectedState(Enemy entity, string animationBoolName) : base(entity, animationBoolName)
        { }

        public override void Enter()
        {
            base.Enter();

            Entity.CoreContainer.Movement.SetVelocityZero();

            Enemy.EnemyCoreContainer.Animation.SetBattleMode(true);
        }
    }
}
