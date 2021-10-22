using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class PlayerThrowState : PlayerAttackState
    {
        public PlayerThrowState(Player entity, string animationBoolName) : base(entity, animationBoolName)
        { }

        public override void AnimationFinishedTrigger()
        {
            Entity.CoreContainer.Inventory.RemoveCurrentWeapon();

            base.AnimationFinishedTrigger();
        }
    }
}
