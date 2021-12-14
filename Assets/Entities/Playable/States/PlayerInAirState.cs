using NowakArtur97.LoopedDungeon.Core;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class PlayerInAirState : InAirState
    {
        private Player _player;
        private Vector2 _currentVelocity;
        private readonly float _timeToPressButtonForJumpBeforeLanding = 0.2f;

        public PlayerInAirState(Player entity, string animationBoolName) : base(entity, animationBoolName)
        {
            _player = entity;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            Entity.CoreContainer.Movement.CheckIfShouldFlip((int)_player.PlayerCoreContainer.Input.MovementInput.x);
            Entity.CoreContainer.Inventory.Weapons.ForEach(weapon => weapon.CoreContainer.Movement.CheckIfShouldFlipWithoutRotating((int)_player.PlayerCoreContainer.Input.MovementInput.x));

            SetupVelocityRelatedVariables();

            if (!IsExitingState)
            {
                if (IsGrounded && _timeToPressButtonForJumpBeforeLanding + _player.PlayerCoreContainer.Input.JumpInputStartTime >= Time.time)
                {
                    _player.StateMachine.ChangeState(_player.JumpState);
                }
                else if (IsGrounded && _currentVelocity.y < 0.01f && !_player.PlayerCoreContainer.Input.JumpInput)
                {
                    _player.StateMachine.ChangeState(_player.LandState);
                }
            }
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
