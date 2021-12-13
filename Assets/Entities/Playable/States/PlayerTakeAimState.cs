using NowakArtur97.LoopedDungeon.Core;

namespace NowakArtur97.LoopedDungeon.StateMachine
{
    public class PlayerTakeAimState : PlayerAttackState
    {
        public PlayerTakeAimState(Player entity, string animationBoolName) : base(entity, animationBoolName)
        { }

        public override void LogicUpdate()
        {
            if (!IsExitingState
                && IsAnimationFinished
                && !Player.PlayerCoreContainer.Input.MainAbilityInput
                && !Player.PlayerCoreContainer.Input.SecondaryAbilityInput)
            {
                Player.StateMachine.ChangeState(Player.ThrowState);
            }
        }
    }
}
