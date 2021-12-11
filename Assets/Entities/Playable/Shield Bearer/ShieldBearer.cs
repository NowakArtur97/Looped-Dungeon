using NowakArtur97.LoopedDungeon.StateMachine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class ShieldBearer : Player
    {
        protected override void Awake()
        {
            base.Awake();

            // TODO: ShieldBearer: Create Protect state
            //MainAbilityState = new PlayerAttackState(this, "mainAbility");
            SecondaryAbilityState = new PlayerTossUpState(this, "secondaryAbility");
        }
    }
}