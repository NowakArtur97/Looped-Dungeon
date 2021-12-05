using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class EnemyStartFallingState : State
    {
        private Stalker _stalker;

        public EnemyStartFallingState(Stalker entity, string animationBoolName) : base(entity, animationBoolName)
        {
            _stalker = entity;
        }

        public override void Exit()
        {
            base.Exit();

            Entity.CoreContainer.Movement.ResetGravityScale();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!IsExitingState)
            {
                if (IsAnimationFinished)
                {
                    Entity.StateMachine.ChangeState(_stalker.FallState);
                }
            }
        }
    }
}
