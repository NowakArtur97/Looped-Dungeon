using NowakArtur97.LoopedDungeon.StateMachine;
using NowakArtur97.LoopedDungeon.Util;
using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    public abstract class RangedCombatEnemy : Enemy
    {
        protected override void Awake()
        {
            base.Awake();

            PlayerDetectedState = new RangedCombatEnemyPlayerDetectedState(this, "playerDetected");
            RangedAttackState = new EnemyRangedAttackState(this, "rangedAttack");
            BackOffState = new EnemyBackOffState(this, "backOff");
        }
    }
}
