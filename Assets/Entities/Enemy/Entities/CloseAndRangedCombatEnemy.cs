using NowakArtur97.LoopedDungeon.StateMachine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public abstract class CloseAndRangedCombatEnemy : Enemy
    {
        protected override void Awake()
        {
            base.Awake();

            PlayerDetectedState = new CloseAndRangedCombatEnemyPlayerDetectedState(this, "playerDetected");
            MeleeAttackState = new EnemyMeleeAttackState(this, "meleeAttack");
            RangedAttackState = new EnemyRangedAttackState(this, "rangedAttack");
        }
    }
}
