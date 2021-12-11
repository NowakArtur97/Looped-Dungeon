using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class PlayerHurtState : HurtState
    {
        private Player _player;
        private float _xMovementInput;

        public PlayerHurtState(Player entity, string animationBoolName) : base(entity, animationBoolName)
        {
            _player = entity;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            _xMovementInput = _player.PlayerCoreContainer.Input.MovementInput.x;

            if (!IsExitingState && IsAnimationFinished)
            {
                if (_player.PlayerCoreContainer.Input.MainAbilityInput && _player.CoreContainer.Inventory.CurrentWeapon
                        && _player.MainAbilityState != null)
                {
                    Entity.StateMachine.ChangeState(_player.MainAbilityState);
                }
                else if (_player.PlayerCoreContainer.Input.SecondaryAbilityInput && _player.CoreContainer.Inventory.CurrentWeapon
                    && _player.SecondaryAbilityState != null)
                {
                    Entity.StateMachine.ChangeState(_player.SecondaryAbilityState);
                }
                else if (_player.PlayerCoreContainer.Input.JumpInput)
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
