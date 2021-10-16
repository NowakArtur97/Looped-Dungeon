using NowakArtur97.LoopedDungeon.Core;
using UnityEngine;

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

            Entity.CoreContainer.Animation
                .SetVelocityVariable(Mathf.Abs(Entity.CoreContainer.Input.MovementInput.x),
                Entity.CoreContainer.Movement.CurrentVelocity.y);
            Entity.CoreContainer.Inventory.CurrentWeapon.SetCharacterVelocity(Entity.CoreContainer.Movement.CurrentVelocity);

            if (IsGrounded)
            {
                if (IsGrounded && Entity.CoreContainer.Movement.CurrentVelocity.y < 0.01f)
                {
                    _player.StateMachine.ChangeState(_player.LandState);
                }
            }
        }
    }
}
