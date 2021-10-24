using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class PlayerMoveState : GroundedState
    {
        private Player _player;
        private float _xMovementInput;

        public PlayerMoveState(Player entity, string animationBoolName) : base(entity, animationBoolName)
        {
            _player = entity;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            _xMovementInput = _player.CoreContainer.Input.MovementInput.x;

            Entity.CoreContainer.Movement.CheckIfShouldFlip((int)_xMovementInput);
            Entity.CoreContainer.Inventory.CurrentWeapon?.CoreContainer.Movement.CheckIfShouldFlipWithoutRotation((int)_xMovementInput);

            Entity.CoreContainer.Movement.SetVelocityX(Entity.Data.moveVelocity * _xMovementInput);

            if (!IsExitingState)
            {
                if (!IsGrounded)
                {
                    Entity.StateMachine.ChangeState(_player.InAirState);
                }
                else if (_player.CoreContainer.Input.MainAbilityInput && _player.CoreContainer.Inventory.CurrentWeapon)
                {
                    Entity.StateMachine.ChangeState(_player.MainAbilityState);
                }
                else if (_player.CoreContainer.Input.SecondaryAbilityInput && _player.CoreContainer.Inventory.CurrentWeapon)
                {
                    Entity.StateMachine.ChangeState(_player.SecondaryAbilityState);
                }
                else if (_player.CoreContainer.Input.JumpInput)
                {
                    Entity.StateMachine.ChangeState(_player.JumpState);
                }
                else if (_xMovementInput == 0)
                {
                    Entity.StateMachine.ChangeState(_player.IdleState);
                }
            }
        }
    }
}
