using NowakArtur97.LoopedDungeon.StateMachine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public class CloseCombatEnemy : Enemy
    {
        public EnemyChargePlayerState ChargePlayerState { get; private set; }
        public EnemyMeleeAttackState MeleeAttackState { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            PlayerDetectedState = new CloseCombatEnemyPlayerDetectedState(this, "playerDetected");
            ChargePlayerState = new EnemyChargePlayerState(this, "chargePlayer");
            MeleeAttackState = new EnemyMeleeAttackState(this, "meleeAttack");
        }
    }
}
