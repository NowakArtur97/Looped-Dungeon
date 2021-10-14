using NowakArtur97.LoopedDungeon.Core;

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

            Entity.CoreContainer.Animation.SetVelocityVariable();
            Entity.CoreContainer.Inventory.CurrentWeapon.SetCharacterVelocity(Entity.CoreContainer.Movement.CurrentVelocity);

            IsAbilityFinished = true;
        }
    }
}
