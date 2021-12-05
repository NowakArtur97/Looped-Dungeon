using NowakArtur97.LoopedDungeon.StateMachine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class Stalker : CloseCombatEnemy
    {
        public EnemySleepState EnemySleepState { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            EnemySleepState = new EnemySleepState(this, "sleep");

            DefaultState = EnemySleepState;
        }
    }
}