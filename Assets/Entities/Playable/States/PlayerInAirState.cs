using NowakArtur97.LoopedDungeon.Core;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class PlayerInAirState : InAirState
    {
        private Player _player;
        private Vector2 _currentVelocity;

        public PlayerInAirState(Player entity, string animationBoolName) : base(entity, animationBoolName)
        {
            _player = entity;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            Entity.CoreContainer.Movement.CheckIfShouldFlip((int)_player.CoreContainer.Input.MovementInput.x);

            if (IsTouchingWall)
            {
                Entity.CoreContainer.Movement.SetVelocityX(0);
                _currentVelocity.Set(Entity.CoreContainer.Movement.CurrentVelocity.x, Entity.CoreContainer.Movement.CurrentVelocity.y);
                Entity.CoreContainer.Animation.SetVelocityVariable(0, _currentVelocity.y);
                Entity.CoreContainer.Inventory.CurrentWeapon?.CoreContainer.Animation.SetVelocityVariable(0, _currentVelocity.y);
            }
            else
            {
                Entity.CoreContainer.Movement.SetVelocityX(Entity.Data.moveVelocity * _player.CoreContainer.Input.MovementInput.x);
                _currentVelocity.Set(Mathf.Abs(Entity.CoreContainer.Input.MovementInput.x), Entity.CoreContainer.Movement.CurrentVelocity.y);
                Entity.CoreContainer.Animation.SetVelocityVariable(_currentVelocity.x, _currentVelocity.y);
                Entity.CoreContainer.Inventory.CurrentWeapon?.CoreContainer.Animation.SetVelocityVariable(_currentVelocity.x, _currentVelocity.y);
            }

            if (IsGrounded)
            {
                if (IsGrounded && _currentVelocity.y < 0.01f)
                {
                    _player.StateMachine.ChangeState(_player.LandState);
                }
            }
        }
    }
}
