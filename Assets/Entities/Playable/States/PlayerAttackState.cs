using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class PlayerAttackState : PlayerAbilityState
    {
        public PlayerAttackState(Player entity, string animationBoolName) : base(entity, animationBoolName)
        { }

        public override void Enter()
        {
            base.Enter();

            Player.CoreContainer.Inventory.CurrentWeapon.UseWeapon();
        }

        public override void AnimationFinishedTrigger()
        {
            base.AnimationFinishedTrigger();

            IsAbilityFinished = true;
        }
    }
}
