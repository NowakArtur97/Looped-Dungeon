using NowakArtur97.LoopedDungeon.StateMachine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class Assassin : Player
    {
        protected override void Awake()
        {
            base.Awake();

            MainAbilityState = new PlayerTakeAimState(this, "takeAim");
            ThrowState = new PlayerThrowState(this, "secondaryAbility");
        }
    }
}
