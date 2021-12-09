using UnityEngine;

namespace NowakArtur97.LoopedDungeon.Core
{
    [CreateAssetMenu(fileName = "_CloseCombatData", menuName = "Data/CloseCombatEnemy")]
    public class D_CloseCombatEnemyEntity : ScriptableObject
    {
        public float meleeAttackDamage = 10;
        public float timeToWaitBeforeMeleeAttack = 3;
    }
}
