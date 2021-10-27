using NowakArtur97.LoopedDungeon.StateMachine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class SwordMaster : Player
    {
        protected override void Awake()
        {
            base.Awake();

            MainAbilityState = new PlayerAttackState(this, "mainAbility");
            SecondaryAbilityState = new PlayerThrowState(this, "secondaryAbility");
        }
    }
}
