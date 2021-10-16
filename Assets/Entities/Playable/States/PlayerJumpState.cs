using NowakArtur97.LoopedDungeon.Core;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class PlayerJumpState : PlayerAbilityState
    {
        public PlayerJumpState(Player entity, string animationBoolName) : base(entity, animationBoolName)
        { }

        public override void Enter()
        {
            base.Enter();

            Player.CoreContainer.Movement.SetVelocityY(Entity.Data.jumpVelocity);

            Entity.CoreContainer.Animation
                           .SetVelocityVariable(Mathf.Abs(Entity.CoreContainer.Input.MovementInput.x),
                           Entity.CoreContainer.Movement.CurrentVelocity.y);
            Entity.CoreContainer.Inventory.CurrentWeapon.SetCharacterVelocity(Entity.CoreContainer.Movement.CurrentVelocity);

            IsAbilityFinished = true;
        }
    }
}
