using NowakArtur97.LoopedDungeon.StateMachine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class ShieldBearer : Player
    {
        protected override void Awake()
        {
            base.Awake();

            // TODO: ShieldBearer: Create Protect and Toss Up states
            MainAbilityState = new PlayerAttackState(this, "mainAbility");
            SecondaryAbilityState = new PlayerThrowState(this, "secondaryAbility");
        }
    }
}