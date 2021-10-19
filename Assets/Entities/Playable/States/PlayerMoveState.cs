using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class PlayerMoveState : GroundedState
    {
        private Player _player;

        public PlayerMoveState(Player entity, string animationBoolName) : base(entity, animationBoolName)
        {
            _player = entity;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            Entity.CoreContainer.Movement.CheckIfShouldFlip((int)_player.CoreContainer.Input.MovementInput.x);
            Entity.CoreContainer.Movement.SetVelocityX(Entity.Data.moveVelocity * _player.CoreContainer.Input.MovementInput.x);

            if (!IsExitingState)
            {
                if (_player.CoreContainer.Input.MainAbilityInput)
                {
                    Entity.StateMachine.ChangeState(_player.MainAbilityState);
                }
                else if (_player.CoreContainer.Input.SecondaryAbilityInput)
                {
                    Entity.StateMachine.ChangeState(_player.SecondaryAbilityState);
                }
                else if (_player.CoreContainer.Input.JumpInput)
                {
                    Entity.StateMachine.ChangeState(_player.JumpState);
                }
                else if (_player.CoreContainer.Input.MovementInput.x == 0)
                {
                    Entity.StateMachine.ChangeState(_player.IdleState);
                }
            }
        }
    }
}
