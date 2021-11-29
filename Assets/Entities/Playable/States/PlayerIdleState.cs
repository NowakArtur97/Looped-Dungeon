using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class PlayerIdleState : GroundedState
    {
        private Player _player;

        public PlayerIdleState(Player entity, string animationBoolName) : base(entity, animationBoolName)
        {
            _player = entity;
        }

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
                if (!IsGrounded)
                {
                    Entity.StateMachine.ChangeState(_player.InAirState);
                }
                else if (_player.PlayerCoreContainer.Input.MainAbilityInput && _player.CoreContainer.Inventory.CurrentWeapon)
                {
                    Entity.StateMachine.ChangeState(_player.MainAbilityState);
                }
                else if (_player.PlayerCoreContainer.Input.SecondaryAbilityInput && _player.CoreContainer.Inventory.CurrentWeapon)
                {
                    Entity.StateMachine.ChangeState(_player.SecondaryAbilityState);
                }
                else if (_player.PlayerCoreContainer.Input.JumpInput)
                {
                    Entity.StateMachine.ChangeState(_player.JumpState);
                }
                else if (_player.PlayerCoreContainer.Input.MovementInput.x != 0)
                {
                    Entity.StateMachine.ChangeState(_player.MoveState);
                }
            }
        }
    }
}
