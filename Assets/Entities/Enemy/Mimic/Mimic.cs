using NowakArtur97.LoopedDungeon.StateMachine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class Mimic : CloseCombatEnemy
    {
        protected override void Awake()
        {
            base.Awake();

            PlayerDetectedState = new CloseCombatBackingOffEnemyPlayerDetectedState(this, "playerDetected");
            HurtState = new RangedCombatEnemyHurtState(this, "hurt");
            BackOffState = new EnemyBackOffState(this, "backOff");
        }
    }
}