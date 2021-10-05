using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class PlayerInAirState : InAirState
    {
        private Player _player;

        public PlayerInAirState(Player entity, string animationBoolName) : base(entity, animationBoolName)
        {
            _player = entity;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            Entity.CoreContainer.Movement.CheckIfShouldFlip((int)_player.CoreContainer.Input.MovementInput.x);
            Entity.CoreContainer.Movement.SetVelocityX(Entity.Data.moveVelocity * _player.CoreContainer.Input.MovementInput.x);

            Entity.CoreContainer.Animation.SetVelocityVariable();

            if (IsGrounded)
            {
                if (IsGrounded)
                {
                    _player.StateMachine.ChangeState(_player.IdleState);
                }
            }
        }
    }
}
