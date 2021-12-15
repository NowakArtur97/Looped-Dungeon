using NowakArtur97.LoopedDungeon.Core;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class PlayerInAirState : InAirState
    {
        private Player _player;
        private Vector2 _currentVelocity;
        private bool _jumpInput;

        public PlayerInAirState(Player entity, string animationBoolName) : base(entity, animationBoolName)
        {
            _player = entity;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            Entity.CoreContainer.Movement.CheckIfShouldFlip((int)_player.PlayerCoreContainer.Input.MovementInput.x);

            if (!IsExitingState)
            {
                if (IsGrounded && _jumpInput)
                {
                    _player.StateMachine.ChangeState(_player.JumpState);
                }
                else if (IsGrounded && _currentVelocity.y < 0.01f && !_jumpInput)
                {
                    _player.StateMachine.ChangeState(_player.LandState);
                }
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            _jumpInput = _player.PlayerCoreContainer.Input.JumpInput;

            Entity.CoreContainer.Inventory.Weapons.ForEach(weapon => weapon.CoreContainer.Movement.CheckIfShouldFlipWithoutRotating((int)_player.PlayerCoreContainer.Input.MovementInput.x));

            SetupVelocityRelatedVariables();
        }

        private void SetupVelocityRelatedVariables()
        {
            if (IsTouchingWall)
            {
                Entity.CoreContainer.Movement.SetVelocityX(0);
                _currentVelocity.Set(Entity.CoreContainer.Movement.CurrentVelocity.x, Entity.CoreContainer.Movement.CurrentVelocity.y);
                Entity.CoreContainer.Animation.SetVelocityVariable(0, _currentVelocity.y);
                Entity.CoreContainer.Inventory.Weapons.ForEach(weapon => weapon.CoreContainer.Animation.SetVelocityVariable(0, _currentVelocity.y));
            }
            else
            {
                Entity.CoreContainer.Movement.SetVelocityX(Entity.Data.moveVelocity * _player.PlayerCoreContainer.Input.MovementInput.x);
                _currentVelocity.Set(Mathf.Abs(_player.PlayerCoreContainer.Input.MovementInput.x), Entity.CoreContainer.Movement.CurrentVelocity.y);
                Entity.CoreContainer.Animation.SetVelocityVariable(_currentVelocity.x, _currentVelocity.y);
                Entity.CoreContainer.Inventory.Weapons.ForEach(weapon => weapon.CoreContainer.Animation.SetVelocityVariable(_currentVelocity.x, _currentVelocity.y));
            }
        }
    }
}
