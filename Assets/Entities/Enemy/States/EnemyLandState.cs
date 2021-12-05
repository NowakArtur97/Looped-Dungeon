using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class EnemyLandState : EnemyGroundedState
    {
        public EnemyLandState(Enemy entity, string animationBoolName) : base(entity, animationBoolName)
        { }

        public override void Enter()
        {
            base.Enter();

            Entity.CoreContainer.Movement.SetVelocityZero();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!IsExitingState)
            {
                if (IsAnimationFinished)
                {
                    Entity.StateMachine.ChangeState(Enemy.LookForPlayerState);
                }
            }
        }
    }
}
