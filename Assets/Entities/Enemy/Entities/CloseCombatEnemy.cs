using NowakArtur97.LoopedDungeon.StateMachine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public abstract class CloseCombatEnemy : Enemy
    {
        protected override void Awake()
        {
            base.Awake();

            PlayerDetectedState = new CloseCombatEnemyPlayerDetectedState(this, "playerDetected");
            ChargePlayerState = new EnemyChargePlayerState(this, "chargePlayer");
            MeleeAttackState = new EnemyMeleeAttackState(this, "meleeAttack");
        }
    }
}
