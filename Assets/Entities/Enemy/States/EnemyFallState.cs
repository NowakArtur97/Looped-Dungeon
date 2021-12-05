using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class EnemyFallState : GroundedState
    {
        private Stalker _stalker;

        public EnemyFallState(Stalker entity, string animationBoolName) : base(entity, animationBoolName)
        {
            _stalker = entity;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            Entity.CoreContainer.Movement.SetVelocityY(_stalker.FallVelocity * -1);

            if (!IsExitingState)
            {
                if (IsGrounded)
                {
                    Entity.StateMachine.ChangeState(_stalker.LandState);
                }
            }
        }
    }
}
