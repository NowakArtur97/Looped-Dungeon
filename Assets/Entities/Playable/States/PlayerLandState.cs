using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class PlayerLandState : GroundedState
    {
        private Player _player;

        public PlayerLandState(Player entity, string animationBoolName) : base(entity, animationBoolName)
        {
            _player = entity;
        }

        public override void Enter()
        {
            base.Enter();

            _player.CoreContainer.Movement.SetVelocityZero();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (IsAnimationFinished)
            {
                _player.StateMachine.ChangeState(_player.IdleState);
            }
        }
    }
}
