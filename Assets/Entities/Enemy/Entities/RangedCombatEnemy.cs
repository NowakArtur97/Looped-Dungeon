using NowakArtur97.LoopedDungeon.StateMachine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public abstract class RangedCombatEnemy : Enemy
    {
        protected override void Awake()
        {
            base.Awake();

            IdleState = new RangedCombatEnemyIdleState(this, "idle");
            MoveState = new RangedCombatEnemyMoveState(this, "move");
            PlayerDetectedState = new RangedCombatEnemyPlayerDetectedState(this, "playerDetected");
            RangedAttackState = new EnemyRangedAttackState(this, "rangedAttack");
            BackOffState = new RangedCombatEnemyBackOffState(this, "backOff");
            HurtState = new RangedCombatEnemyHurtState(this, "hurt");

            DefaultState = IdleState;
        }
    }
}
