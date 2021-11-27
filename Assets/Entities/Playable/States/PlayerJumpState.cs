using NowakArtur97.LoopedDungeon.Core;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class PlayerJumpState : PlayerAbilityState
    {
        private Vector2 _currentVelocity;
        private Player _player;

        public PlayerJumpState(Player entity, string animationBoolName) : base(entity, animationBoolName)
        {
            _player = entity;
        }

        public override void Enter()
        {
            base.Enter();

            Player.CoreContainer.Movement.SetVelocityY(_player.PlayerData.jumpVelocity);

            Entity.CoreContainer.Animation
                           .SetVelocityVariable(Mathf.Abs(Entity.CoreContainer.Input.MovementInput.x),
                           Entity.CoreContainer.Movement.CurrentVelocity.y);
            _currentVelocity = Entity.CoreContainer.Movement.CurrentVelocity;
            Entity.CoreContainer.Inventory.Weapons.ForEach(weapon => weapon.CoreContainer.Animation.SetVelocityVariable(_currentVelocity.x, _currentVelocity.y));

            IsAbilityFinished = true;
        }
    }
}
